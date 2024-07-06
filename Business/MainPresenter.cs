using EdgeSearch.models;
using EdgeSearch.Models;
using EdgeSearch.UI;
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
        private Search _search;
        private Random _random;
        private Preferences _preferences;
        private System.Windows.Forms.Timer _refreshTimer;
        private Awaker _awaker;
        #endregion

        #region Properties
        Search Search => _search;
        #endregion

        #region Constructors and destructor
        public MainPresenter(MainForm mainForm, Search search, Preferences preferences)
        {
            _mainForm = mainForm;
            _search = search;
            _preferences = preferences;
            _awaker = new Awaker();
            _random = new Random();

            LoadSearchesFromFile("searches.xml"); // Carga las búsquedas desde el archivo

            SetupRefreshTimer();
            InitializeEvents();
        }

        #endregion

        #region Methods

        private void InitializeEvents()
        {
            _mainForm.Load += _mainForm_Load;
            _mainForm.ForceClicked += _mainForm_ForceClicked;
            _mainForm.OpenClicked += _mainForm_OpenClicked;
            _mainForm.OpenRewardsClicked += _mainForm_OpenRewardsClicked;
            _mainForm.OpenAmbassadorsClicked += _mainForm_OpenAmbassadorsClicked;
            _mainForm.NextSearchClicked += _mainForm_NextSearchClicked;
            _mainForm.MobileChanged += _mainForm_MobileChanged;
            _mainForm.PlayClicked += _mainForm_PlayClicked;
            _mainForm.FullPlayClicked += _mainForm_FullPlayClicked;
            _mainForm.ResetClicked += _mainForm_ResetClicked;
            _mainForm.RewardsNewWindowRequested += _mainForm_RewardsNewWindowRequested;
            _mainForm.AmbassadorsNewWindowRequested += _mainForm_AmbassadorsNewWindowRequested;
        }

        /// <summary>
        /// This function handle new windows manually, but without opening the web in a new window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _mainForm_RewardsNewWindowRequested(object sender, Microsoft.Web.WebView2.Core.CoreWebView2NewWindowRequestedEventArgs e)
        {
            // Obtener el contexto de sincronización de la UI
            var uiContext = SynchronizationContext.Current;

            // Cancelar la creación de una nueva ventana
            e.Handled = true;

            // Crear una nueva instancia de WebView2 para la nueva ventana
            var newWebView = new Microsoft.Web.WebView2.WinForms.WebView2 { Dock = DockStyle.Fill };

            uiContext.Post(async _ =>
            {
                await newWebView.EnsureCoreWebView2Async();

                // Navegar a la URI solicitada
                newWebView.Source = new Uri(e.Uri);
                _mainForm.SetRewardProgressBar(ProgressBarStyle.Marquee);

                // Esperar hasta que la nueva ventana esté completamente cargada
                newWebView.CoreWebView2.NavigationCompleted += async (s, args) =>
                {
                    // Cerrar la nueva ventana después de que se haya cargado completamente
                    if (args.IsSuccess)
                    {
                        await Task.Delay(3000); // Ajusta el tiempo según sea necesario
                        newWebView.Dispose();
                    }

                    _mainForm.SetRewardProgressBar(ProgressBarStyle.Blocks);
                };

            }, null);
        }

        private void _mainForm_AmbassadorsNewWindowRequested(object sender, Microsoft.Web.WebView2.Core.CoreWebView2NewWindowRequestedEventArgs e)
        {
            int count = 0;
            // Obtener el contexto de sincronización de la UI
            var uiContext = SynchronizationContext.Current;

            // Cancelar la creación de una nueva ventana
            e.Handled = true;

            // Crear una nueva instancia de WebView2 para la nueva ventana
            var newWebView = new Microsoft.Web.WebView2.WinForms.WebView2 { Dock = DockStyle.Fill };

            uiContext.Post(async _ =>
            {
                await newWebView.EnsureCoreWebView2Async();

                // Navegar a la URI solicitada
                newWebView.Source = new Uri(e.Uri);
                _mainForm.SetAmbassadorProgressBar(ProgressBarStyle.Marquee);
                count++;

                // Esperar hasta que la nueva ventana esté completamente cargada
                newWebView.CoreWebView2.NavigationCompleted += async (s, args) =>
                {
                    // Cerrar la nueva ventana después de que se haya cargado completamente
                    if (args.IsSuccess)
                    {
                        await Task.Delay(10000); // Ajusta el tiempo según sea necesario
                        newWebView.Dispose();
                    }

                    count--;
                    if (count == 0)
                        _mainForm.SetAmbassadorProgressBar(ProgressBarStyle.Blocks);
                };

            }, null);
        }

        private void _mainForm_OpenClicked(object sender, EventArgs e)
        {
            _mainForm.SetSearchsURL(_search.URL);
        }

        private void _mainForm_OpenRewardsClicked(object sender, EventArgs e)
        {
            if (!_search.RewardsPlayed)
                _mainForm.OpenRewards(_search);
        }

        private void _mainForm_OpenAmbassadorsClicked(object sender, EventArgs e)
        {
            if (!_search.AmbassadorsPlayed)
                _mainForm.OpenAmbassadors(_search);
        }

        private void SetupRefreshTimer()
        {
            _refreshTimer = new System.Windows.Forms.Timer();
            _refreshTimer.Interval = 1000; // Intervalo de actualización cada segundo
            _refreshTimer.Tick += RefreshTimer_Tick;
        }

        private void RefreshNextSearch()
        {
            _search.NextSearch = CreateSearch();
            _mainForm.UpdateInterface(_search);
        }

        private void DoSearch()
        {
            if (!CanDoSearch())
                Stop();

            string currentSearch = _search.NextSearch;
            RefreshNextSearch();
            _search.URL = new Uri($"https://www.bing.com/search?q={currentSearch}&form=QBLH&sp=-1&ghc=1&lq=0&pq={currentSearch}");

            _mainForm.SetSearchsURL(_search.URL);

            AddHistoricSearch(currentSearch);

            if (_search.IsMobile)
                _search.MobileSearchesCount++;
            else
                _search.DesktopSearchesCount++;

            _mainForm.UpdateInterface(_search);
        }

        private void AddHistoricSearch(string currentSearch)
        {
            _search.UsedSearchs.Add(new Tuple<DateTime, Preferences.Mode, string>(DateTime.Now, _search.CurrentMode, currentSearch));
        }

        private bool CanDoSearch()
        {
            return _search.UsedSearchs.Count(x => Math.Abs((x.Item1 - DateTime.Now).TotalSeconds) < 10) < 3;
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

                _search.ToSearch = xml.Element("searches")?.Elements("item").Select(e => e.Value).ToList() ?? new List<string>();
                _search.Sagas = xml.Element("sagas")?.Elements("item").Select(e => e.Value).ToList() ?? new List<string>();
                _search.Hardware = xml.Element("hardware")?.Elements("item").Select(e => e.Value).ToList() ?? new List<string>();
                _search.Retro = xml.Element("retro")?.Elements("item").Select(e => e.Value).ToList() ?? new List<string>();
                _search.Games = xml.Element("games")?.Elements("item").Select(e => e.Value).ToList() ?? new List<string>();
                _search.Companies = xml.Element("companies")?.Elements("item").Select(e => e.Value).ToList() ?? new List<string>();
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
                search = _search.ToSearch[_random.Next(0, _search.ToSearch.Count)];

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
            while (_search.UsedSearchs.Any(x => x.Item3 == search));

            return search;
        }

        private async void RefreshTimer_Tick(object sender, EventArgs e)
        {
            _search.ElapsedSeconds++;

            if (_search.ElapsedSeconds >= _search.SecondsToRefresh)
            {
                if (_search.ToSearch.Count == 0)
                {
                    PlayAndStop(false, false);
                    return;
                }

                bool desktopPointsReached = (_search.DesktopSearchesCount * 3) >= _search.DesktopTotalPoints;
                bool MobilePointsReached = (_search.MobileSearchesCount * 3) >= _search.MobileTotalPoints;
                if (!Search.IsMobile && desktopPointsReached)
                {
                    if (!MobilePointsReached)
                    {
                        await ChangeMobileMode(Preferences.Mode.Mobile, false);
                    }
                    else
                    {
                        PlayAndStop(false, false);
                        return;
                    }
                }
                else if (Search.IsMobile && MobilePointsReached)
                {
                    if (!desktopPointsReached)
                    {
                        await ChangeMobileMode(Preferences.Mode.Desktop, false);
                    }
                    else
                    {
                        PlayAndStop(false, false);
                        return;
                    }
                }

                DoSearch();
                RestartLimits();
            }

            _mainForm.UpdateInterface(_search);
        }

        private async Task ChangeMobileMode(Preferences.Mode mode, bool reloadWeb)
        {
            _search.CurrentMode = mode;
            await RefreshMobileMode(reloadWeb);
        }

        private void PlayAndStop(bool openRewards, bool openAmbassadors)
        {
            if (!_search.IsPlaying)
            {
                Play();

                if (openRewards)
                    _mainForm.OpenRewards(_search);

                if (openAmbassadors)
                    _mainForm.OpenAmbassadors(_search);
            }
            else
                Stop();

            _mainForm.UpdateInterface(_search);
        }

        private void Stop()
        {
            _refreshTimer.Stop(); // Detiene el temporizador si ya está activo
            _search.IsPlaying = false;

            _awaker.Stop();
        }

        private void Play()
        {
            RestartLimits();

            _refreshTimer.Start(); // Inicia el temporizador cuando se presiona el botón
            _search.IsPlaying = true;
            _awaker.Start();
        }

        public void RestartLimits()
        {
            _search.ElapsedSeconds = 0;
            _search.SecondsToRefresh = _random.Next(_search.LowerLimit, _search.UpperLimit + 1);

            _mainForm.UpdateInterface(_search);
        }

        private async Task RefreshMobileMode(bool reloadWeb)
        {
            _preferences.LastMode = _search.CurrentMode;
            _preferences.Save();

            if (_search.IsMobile)
                _mainForm.SetUserAgent(_search.MobileUserAgent);
            else
                _mainForm.SetUserAgent(_search.DesktopUserAgent);

            await _mainForm.DeleteSessionCookies();

            if (!CanDoSearch())
            {
                Stop();
                return;
            }

            if (reloadWeb)
            {
                AddHistoricSearch(_search.URL.ToString());
                _mainForm.ReloadSearchsWeb();
            }

            _mainForm.UpdateInterface(_search);
        }

        private string GetSaga() => _search.Sagas[_random.Next(0, _search.Sagas.Count)];
        private string GetGame() => _search.Games[_random.Next(0, _search.Games.Count)];
        private string GetHardware() => _search.Hardware[_random.Next(0, _search.Hardware.Count)];
        private string GetCompany() => _search.Companies[_random.Next(0, _search.Companies.Count)];
        private string GetRetro() => _search.Retro[_random.Next(0, _search.Retro.Count)];

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
            _search.URL = new Uri("https://www.bing.es/");
            _mainForm.SetSearchsURL(_search.URL);
            _mainForm.SetRewardsURL(new Uri("https://rewards.bing.com/pointsbreakdown"));
            _mainForm.SetAmbassadorsURL(new Uri("https://ambassadors.microsoft.com/xbox/quests"));

            _mainForm.UpdateInterface(_search);

            _mainForm.BindFields(_search);

            RefreshNextSearch();
        }

        private void _mainForm_ForceClicked(object sender, EventArgs e)
        {
            DoSearch();
        }

        private void _mainForm_NextSearchClicked(object sender, EventArgs e)
        {
            RefreshNextSearch();
        }

        private async void _mainForm_MobileChanged(object sender, EventArgs e)
        {
            _search.IsMobile = !_search.IsMobile;
            await RefreshMobileMode(true);
        }

        private void _mainForm_PlayClicked(object sender, EventArgs e)
        {
            PlayAndStop(false, false);
        }

        private void _mainForm_FullPlayClicked(object sender, EventArgs e)
        {
            PlayAndStop(true, true);
        }

        private void _mainForm_ResetClicked(object sender, EventArgs e)
        {
            _search.MobileSearchesCount = 0;
            _search.DesktopSearchesCount = 0;
            _search.CurrentMode = Preferences.Mode.Desktop;
        }

        #endregion
    }
}
