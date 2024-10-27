using EdgeSearch.models;
using EdgeSearch.Models;
using EdgeSearch.UI;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace EdgeSearch.Business
{
    internal class MainPresenter
    {
        #region Members
        private MainForm _mainForm;
        private Profile _profile;
        private Random _random;
        private System.Windows.Forms.Timer _refreshTimer;
        private Awaker _awaker;
        #endregion

        #region Properties
        Profile Profile => _profile;
        #endregion

        #region Constructors and destructor
        public MainPresenter(MainForm mainForm, Profile profile)
        {
            _mainForm = mainForm;
            _profile = profile;
            _awaker = new Awaker();
            _random = new Random();

            LoadSearchesFromFile("Config\\searches.xml"); // Carga las búsquedas desde el archivo

            SetupRefreshTimer();
            InitializeEvents();
        }

        #endregion

        #region Methods

        private void InitializeEvents()
        {
            _mainForm.Load += _mainForm_Load;
            _mainForm.ForceClicked += _mainForm_ForceClicked;
            _mainForm.PlayRewardsClicked += _mainForm_PlayRewardsClicked;
            _mainForm.PlaySearchesClicked += _mainForm_PlaySearchesClicked;
            _mainForm.NextSearchClicked += _mainForm_NextSearchClicked;
            _mainForm.MobileChanged += _mainForm_MobileChanged;
            _mainForm.PlayClicked += _mainForm_PlayClicked;
            _mainForm.FullPlayClicked += _mainForm_FullPlayClicked;
            _mainForm.ResetClicked += _mainForm_ResetClicked;
            _mainForm.RewardsNewWindowRequested += _mainForm_RewardsNewWindowRequested;
            _mainForm.SearchesNavigationCompleted += _mainForm_SearchesNavigationCompleted;
            _mainForm.PreferencesClciked += _mainForm_PreferencesClciked;

            _mainForm.SearchesCoreWebView2InitializationCompleted += _mainForm_SearchesCoreWebView2InitializationCompleted;
            _mainForm.RewardsCoreWebView2InitializationCompleted += _mainForm_RewardsCoreWebView2InitializationCompleted;
        }

        private void _mainForm_SearchesCoreWebView2InitializationCompleted(object sender, CoreWebView2InitializationCompletedEventArgs e)
        {

        }

        private async void _mainForm_RewardsCoreWebView2InitializationCompleted(object sender, CoreWebView2InitializationCompletedEventArgs e)
        {
            await ExtractPoints();
        }

        /// <summary>
        /// This function handle new windows manually, but without opening the web in a new window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _mainForm_RewardsNewWindowRequested(object sender, CoreWebView2NewWindowRequestedEventArgs e)
        {
            // Obtener el contexto de sincronización de la UI
            var uiContext = SynchronizationContext.Current;

            // Cancelar la creación de una nueva ventana
            e.Handled = true;

            // Crear una nueva instancia de WebView2 para la nueva ventana
            var newWebView = new WebView2 { Dock = DockStyle.Fill };

            uiContext.Post(async _ =>
            {
                await newWebView.EnsureCoreWebView2Async();

                // Navegar a la URI solicitada
                newWebView.Source = new Uri(e.Uri);
                _profile.Search.CurrentRewards++;
                _profile.Search.TotalRewards++;
                _mainForm.UpdateProgressBarRewards(_profile.Search);

                // Asociar el evento de navegación completada
                EventHandler<CoreWebView2NavigationCompletedEventArgs> handler = null;

                handler = async (s, args) =>
                {
                    // Cerrar la nueva ventana después de que se haya cargado completamente
                    if (args.IsSuccess)
                    {
                        await Task.Delay(15000); // Espera 15 segundos antes de cerrar la ventana

                        // TODO: Por algún motivo, pasa por este codigo más de una vez. Necesito mirar como hacerlo para que no reduzca el contador más veces de la cuenta.
                        //newWebView.CoreWebView2.NavigationCompleted -= handler; // Desvincular el evento

                        newWebView.Dispose();
                        _profile.Search.CurrentRewards--;
                        _mainForm.UpdateProgressBarRewards(_profile.Search);
                    }
                };

                newWebView.CoreWebView2.NavigationCompleted += handler; // Vincular el evento

            }, null);

            _mainForm.BindFields();
        }


        private void _mainForm_SearchesNavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            _mainForm.RefreshSearchesURL();
        }

        private void _mainForm_PlayRewardsClicked(object sender, EventArgs e)
        {
            if (!_profile.Search.RewardsPlayed)
                _mainForm.OpenRewards();
        }

        private void _mainForm_PlaySearchesClicked(object sender, EventArgs e)
        {
            _mainForm_PlayClicked(sender, e);
        }

        private void SetupRefreshTimer()
        {
            _refreshTimer = new System.Windows.Forms.Timer();
            _refreshTimer.Interval = 1000; // Intervalo de actualización cada segundo
            _refreshTimer.Tick += RefreshTimer_Tick;
        }

        private void RefreshNextSearch()
        {
            _profile.Search.NextSearch = CreateSearch();
            _mainForm.UpdateInterface();
        }

        private async Task DoSearch()
        {
            if (!CanDoSearch())
                Stop();

            string currentSearch = _profile.Search.NextSearch;
            RefreshNextSearch();
            _profile.Search.URL = new Uri($"https://www.bing.com/search?q={currentSearch}&form=QBLH&sp=-1&ghc=1&lq=0&pq={currentSearch}");

            AddHistoricSearch(currentSearch);

            if (_profile.Search.IsMobile)
                _profile.Search.MobileSearchesCount++;
            else
                _profile.Search.DesktopSearchesCount++;

            _mainForm.UpdateInterface();

            await _mainForm.OpenSearchesURL(_profile.Search.URL);
        }

        private void AddHistoricSearch(string currentSearch)
        {
            _profile.Search.UsedSearchs.Add(new Tuple<DateTime, Preferences.Mode, string>(DateTime.Now, _profile.Search.CurrentMode, currentSearch));
        }

        private bool CanDoSearch()
        {
            return _profile.Search.UsedSearchs.Count(x => Math.Abs((x.Item1 - DateTime.Now).TotalSeconds) < 10) < 3;
        }

        private void LoadSearchesFromFile(string filePath)
        {
            string solutionDir = AppDomain.CurrentDomain.BaseDirectory;
            string finalPath = Path.Combine(solutionDir, filePath);
            if (!File.Exists(finalPath))
            {
                solutionDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../..");
                finalPath = Path.Combine(solutionDir, filePath);
            }

            if (File.Exists(finalPath))
            {
                var xml = XElement.Load(finalPath);

                _profile.Search.ToSearch = xml.Element("searches")?.Elements("item").Select(e => e.Value).ToList() ?? new List<string>();
                _profile.Search.Sagas = xml.Element("sagas")?.Elements("item").Select(e => e.Value).ToList() ?? new List<string>();
                _profile.Search.Hardware = xml.Element("hardware")?.Elements("item").Select(e => e.Value).ToList() ?? new List<string>();
                _profile.Search.Retro = xml.Element("retro")?.Elements("item").Select(e => e.Value).ToList() ?? new List<string>();
                _profile.Search.Games = xml.Element("games")?.Elements("item").Select(e => e.Value).ToList() ?? new List<string>();
                _profile.Search.Companies = xml.Element("companies")?.Elements("item").Select(e => e.Value).ToList() ?? new List<string>();
            }
            else
                MessageBox.Show($"El archivo {finalPath} no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private string CreateSearch()
        {
            string search = "";
            do
            {
                // Selecciona un elemento al azar de la lista
                search = _profile.Search.ToSearch[_random.Next(0, _profile.Search.ToSearch.Count)];

                search = search.Replace("%year%", DateTime.Today.Year.ToString());
                if (search.Contains("%saga%"))
                    search = search.Replace("%saga%", GetSaga());
                if (search.Contains("%game%"))
                    search = search.Replace("%game%", GetGame());
                if (search.Contains("%retro%"))
                    search = search.Replace("%retro%", GetRetro());
                if (search.Contains("%hardware%"))
                    search = search.Replace("%hardware%", GetHardware());
                if (search.Contains("%company%"))
                    search = search.Replace("%company%", GetCompany());
            }
            while (_profile.Search.UsedSearchs.Any(x => x.Item3 == search));

            return search;
        }

        private async void RefreshTimer_Tick(object sender, EventArgs e)
        {
            if (_profile.Preferences.StrikeAmount > 0)
            {
                if (_profile.Search.StrikeCount >= _profile.Preferences.StrikeAmount)
                {
                    DateTime now = DateTime.Now;

                    if (_profile.Search.StrikeTime == null)
                        _profile.Search.StrikeTime = now;

                    if (Convert.ToInt32((now - _profile.Search.StrikeTime.Value).TotalSeconds) > _profile.Preferences.StrikeDelay)
                    {
                        _profile.Search.StrikeCount = 0;
                        _profile.Search.StrikeTime = null;
                    }
                    else
                    {
                        _mainForm.UpdateProgressBarSearches(_profile);
                        return;
                    }
                }
            }

            _profile.Search.ElapsedSeconds++;

            if (_profile.Search.ElapsedSeconds >= _profile.Search.SecondsToRefresh)
            {
                if (_profile.Search.ToSearch.Count == 0)
                {
                    PlayAndStop(false);
                    return;
                }

                bool desktopPointsReached = (_profile.Search.DesktopSearchesCount * _profile.Preferences.DesktopPointsPersearch) >= _profile.Preferences.DesktopTotalPoints;
                bool mobilePointsReached = (_profile.Search.MobileSearchesCount * _profile.Preferences.MobilePointsPersearch) >= _profile.Preferences.MobileTotalPoints;
                if (!_profile.Search.IsMobile && desktopPointsReached)
                {
                    if (!mobilePointsReached)
                    {
                        await ChangeMobileMode(Preferences.Mode.Mobile, false);
                    }
                    else
                    {
                        PlayAndStop(false);
                        return;
                    }
                }
                else if (_profile.Search.IsMobile && mobilePointsReached)
                {
                    if (!desktopPointsReached)
                    {
                        await ChangeMobileMode(Preferences.Mode.Desktop, false);
                    }
                    else
                    {
                        PlayAndStop(false);
                        return;
                    }
                }

                RestartLimits();
                if (_profile.Preferences.StrikeAmount > 0)
                    _profile.Search.StrikeCount++;

                await DoSearch();

                await ExtractPoints();
            }

            _mainForm.UpdateInterface();
        }

        private async Task ExtractPoints()
        {
            await _mainForm.ReloadRewardsWeb();
            await Task.Delay(2000);

            // Buscar primero "Búsqueda en PC"
            await _mainForm.WaitForTextToBeVisible("Búsqueda en PC");
            (int currentPoints, int maxPoints, int pointsPerSearch) desktop = await _mainForm.ExtractPoints("Búsqueda en PC");
            _profile.Preferences.DesktopPointsPersearch = desktop.pointsPerSearch;
            _profile.Preferences.DesktopTotalPoints = desktop.maxPoints;
            _profile.Search.DesktopSearchesCount = desktop.currentPoints / _profile.Preferences.DesktopPointsPersearch;

            // Intentar encontrar "Búsqueda en móviles" con un tiempo límite de 10 segundos
            bool mobileSearchVisible = await _mainForm.WaitForTextToBeVisible("Búsqueda en móviles", 1000);

            if (mobileSearchVisible)
            {
                (int currentPoints, int maxPoints, int pointsPerSearch) mobile = await _mainForm.ExtractPoints("Búsqueda en móviles");
                _profile.Preferences.MobilePointsPersearch = mobile.pointsPerSearch;
                _profile.Preferences.MobileTotalPoints = mobile.maxPoints;
                _profile.Search.MobileSearchesCount = mobile.currentPoints / _profile.Preferences.MobilePointsPersearch;
            }
            else
            {
                // Manejar el caso cuando "Búsqueda en móviles" no está disponible
                _profile.Search.MobileSearchesCount = 0;
                _profile.Preferences.MobileTotalPoints = 0;
                _profile.Preferences.MobilePointsPersearch = 0;
            }

            _mainForm.BindFields();
        }


        private async Task ChangeMobileMode(Preferences.Mode mode, bool reloadWeb)
        {
            _profile.Search.CurrentMode = mode;
            await RefreshMobileMode(reloadWeb);
        }

        private void PlayAndStop(bool openRewards)
        {
            if (!_profile.Search.IsPlaying)
            {
                Play();

                if (openRewards)
                    _mainForm.OpenRewards();
            }
            else
                Stop();

            _mainForm.UpdateInterface();
        }

        private void Stop()
        {
            _refreshTimer.Stop(); // Detiene el temporizador si ya está activo
            _profile.Search.IsPlaying = false;
            _profile.Search.StrikeCount = 0;
            _profile.Search.StrikeTime = null;
            _profile.Search.ElapsedSeconds = 0;

            _awaker.Stop();
        }

        private void Play()
        {
            RestartLimits();

            _refreshTimer.Start(); // Inicia el temporizador cuando se presiona el botón
            _profile.Search.IsPlaying = true;
            _awaker.Start();
        }

        public void RestartLimits()
        {
            _profile.Search.ElapsedSeconds = 0;
            _profile.Search.SecondsToRefresh = _random.Next(_profile.Preferences.MinWait, _profile.Preferences.MaxWait + 1);

            _mainForm.UpdateInterface();
        }

        private async Task RefreshMobileMode(bool reloadWeb)
        {
            _profile.Preferences.Save();

            if (_profile.Search.IsMobile)
                _mainForm.SetUserAgent(_profile.Preferences.MobileUserAgent);
            else
                _mainForm.SetUserAgent(_profile.Preferences.DesktopUserAgent);

            await _mainForm.DeleteSessionCookies();

            if (!CanDoSearch())
            {
                Stop();
                return;
            }

            if (reloadWeb)
            {
                AddHistoricSearch(_profile.Search.URL.ToString());
                await _mainForm.ReloadSearchsWeb();
            }

            _mainForm.UpdateInterface();
        }

        private string GetSaga() => _profile.Search.Sagas[_random.Next(0, _profile.Search.Sagas.Count)];
        private string GetGame() => _profile.Search.Games[_random.Next(0, _profile.Search.Games.Count)];
        private string GetHardware() => _profile.Search.Hardware[_random.Next(0, _profile.Search.Hardware.Count)];
        private string GetCompany() => _profile.Search.Companies[_random.Next(0, _profile.Search.Companies.Count)];
        private string GetRetro() => _profile.Search.Retro[_random.Next(0, _profile.Search.Retro.Count)];

        public void Show()
        {
        }
        public void Hide()
        {
        }
        public void Close()
        {
        }
        public void Update()
        {
        }
        public void UpdateSearch()
        {
        }
        #endregion

        #region Events

        private async void _mainForm_Load(object sender, EventArgs e)
        {
            await _mainForm.EnsureCoreWebView2Async();
            _profile.Search.URL = new Uri("https://www.bing.es/");
            await _mainForm.OpenSearchesURL(_profile.Search.URL);
            await _mainForm.SetRewardsURL(new Uri("https://rewards.bing.com/pointsbreakdown"));
            _mainForm.SelectTabAndReturn(Common.TabType.Rewards);

            await ExtractPoints();

            _mainForm.UpdateInterface();

            _mainForm.BindFields();

            RefreshNextSearch();
        }

        private async void _mainForm_ForceClicked(object sender, EventArgs e)
        {
            await DoSearch();
            await ExtractPoints();
        }

        private void _mainForm_NextSearchClicked(object sender, EventArgs e)
        {
            RefreshNextSearch();
        }

        private async void _mainForm_MobileChanged(object sender, EventArgs e)
        {
            _profile.Search.IsMobile = !_profile.Search.IsMobile;
            await RefreshMobileMode(true);
        }

        private void _mainForm_PlayClicked(object sender, EventArgs e)
        {
            PlayAndStop(false);
        }

        private void _mainForm_FullPlayClicked(object sender, EventArgs e)
        {
            PlayAndStop(true);
        }

        private async void _mainForm_ResetClicked(object sender, EventArgs e)
        {
            _profile.Search.MobileSearchesCount = 0;
            _profile.Search.DesktopSearchesCount = 0;
            await ChangeMobileMode(Preferences.Mode.Desktop, true);
            _mainForm.UpdateInterface();
        }

        private void _mainForm_PreferencesClciked(object sender, EventArgs e)
        {
            using (PreferencesForm form = new PreferencesForm(_profile.Preferences))
            using (PreferencesPresenter presenter = new PreferencesPresenter(form, _profile.Preferences))
            {
                form.ShowDialog();
                _profile.Preferences = new Preferences("Config\\config.json");
                _mainForm.BindFields();
                _mainForm.UpdateInterface();
            }
        }

        #endregion
    }
}
