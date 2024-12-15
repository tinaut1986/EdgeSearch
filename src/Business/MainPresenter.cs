using EdgeSearch.src.Common;
using EdgeSearch.src.Models;
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

namespace EdgeSearch.src.Business
{
    internal class MainPresenter
    {
        #region Members
        private MainForm _mainForm;
        private Profile _profile;
        private Random _random;
        private System.Windows.Forms.Timer _refreshTimer;
        private Awaker _awaker;
        private WebViewSearchesController _wvSearchesController;
        private WebViewRewardsController _wvRewardsController;
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

            _wvSearchesController = new WebViewSearchesController(_profile);
            _wvRewardsController = new WebViewRewardsController(_profile);

            _mainForm.InitializeWebViewSearchesController(_wvSearchesController, _wvRewardsController);

            LoadSearchesFromFile("src\\Config\\searches.xml"); // Carga las búsquedas desde el archivo

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
            _mainForm.PreferencesClciked += _mainForm_PreferencesClciked;
        }

        private void _mainForm_SearchesCoreWebView2InitializationCompleted(object sender, CoreWebView2InitializationCompletedEventArgs e)
        {

        }

        private async void _mainForm_RewardsCoreWebView2InitializationCompleted(object sender, CoreWebView2InitializationCompletedEventArgs e)
        {
            await ExtractPoints();
        }

        /// <summary>
        /// Handles new window requests manually without opening the web in a new window.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event arguments containing information about the new window request.</param>
        private void _mainForm_RewardsNewWindowRequested(object sender, CoreWebView2NewWindowRequestedEventArgs e)
        {
            // Get the UI synchronization context
            var uiContext = SynchronizationContext.Current;

            // Cancel the creation of a new window
            e.Handled = true;

            // Create a new instance of WebView2 for the new window
            var newWebView = new WebView2 { Dock = DockStyle.Fill };

            // Post the following code to the UI context
            uiContext.Post(async _ =>
            {
                // Ensure that the CoreWebView2 environment is initialized
                await newWebView.EnsureCoreWebView2Async();

                // Navigate to the requested URI
                newWebView.Source = new Uri(e.Uri);
                _mainForm.SetRewardsProgressBarState(_profile.Search.RewardsPlayed);

                _profile.Search.CurrentRewards++; // Increment current rewards count
                _profile.Search.TotalRewards++; // Increment total rewards count
                _mainForm.UpdateProgressBarRewards(_profile.Search); // Update progress bar

                // Event handler for navigation completed
                EventHandler<CoreWebView2NavigationCompletedEventArgs> handler = null;

                handler = async (s, args) =>
                {
                    // Close the new window after it has fully loaded
                    if (args.IsSuccess)
                    {
                        await Task.Delay(15000); // Wait for 15 seconds before closing the window

                        // TODO: For some reason, this code runs more than once. 
                        // Investigate how to prevent the counter from decrementing multiple times.
                        // newWebView.CoreWebView2.NavigationCompleted -= handler; // Unsubscribe from the event

                        newWebView.Dispose(); // Dispose of the WebView2 instance
                        _profile.Search.CurrentRewards--; // Decrement current rewards count
                        _mainForm.SetRewardsProgressBarState(_profile.Search.RewardsPlayed);
                        _mainForm.UpdateProgressBarRewards(_profile.Search); // Update progress bar again
                    }
                };

                newWebView.CoreWebView2.NavigationCompleted += handler; // Subscribe to navigation completed event

            }, null);

            _mainForm.SetRewardsProgressBarState(_profile.Search.RewardsPlayed);
            _mainForm.BindFields(); // Bind fields in the main form
        }

        private void _mainForm_SearchesNavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            _mainForm.RefreshSearchesURL();
        }

        private void _mainForm_PlayRewardsClicked(object sender, EventArgs e)
        {
            if (!_profile.Search.RewardsPlayed)
                _wvRewardsController.OpenRewards();
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
            _profile.Search.NextSearch = _profile.Search.CreateSearch();
            _mainForm.UpdateInterface(_awaker);
        }

        /// <summary>
        /// Executes the search process, checking if a search can be performed,
        /// refreshing the next search, and updating the search history.
        /// </summary>
        private async Task ExecuteSearchProcess()
        {
            // Check if a search can be performed; if not, stop the process
            if (_profile.Search.EmergencyStop())
                Stop();

            string currentSearch = _profile.Search.NextSearch; // Get the next search term
            RefreshNextSearch(); // Refresh the next search term

            await InitiateSearch(currentSearch); // Initiate the search with the current term

            AddHistoryicSearch(currentSearch); // Add the current search to history

            //_profile.Search.IncreaseSearchCount(); // Increment the search count

            _mainForm.UpdateInterface(_awaker); // Update the main interface to reflect changes
        }

        /// <summary>
        /// Initiates the search action based on user preferences.
        /// If keyboard typing simulation is enabled, it attempts to simulate typing;
        /// if unsuccessful or disabled, it opens the search URL directly.
        /// </summary>
        /// <param name="currentSearch">The search term to be executed.</param>
        private async Task InitiateSearch(string currentSearch)
        {
            bool useDirectSearch = true;

            if (_profile.Preferences.SimulateKeyboardTyping)
            {
                bool success = await _wvSearchesController.SetSearchBoxText(currentSearch);
                if (success)
                {
                    useDirectSearch = false;
                    Console.WriteLine("Search initiated successfully through simulation.");
                }
                else
                    Console.WriteLine("Simulation failed, falling back to direct URL navigation.");
            }

            if (useDirectSearch)
            {
                // Construct and open the search URL directly
                string encodedSearch = Uri.EscapeDataString(currentSearch);
                _profile.Search.URL = new Uri($"https://www.bing.com/search?q={encodedSearch}&form=QBLH&sp=-1&ghc=1&lq=0&pq={encodedSearch}");
                await _wvSearchesController.OpenSearchesURL(_profile.Search.URL);
                Console.WriteLine("Search initiated through direct URL navigation.");
            }
        }


        private void AddHistoryicSearch(string search)
        {
            _profile.Search.AddHistoricSearch(search);
            _mainForm.AddHistoricSearch(search);
        }

        private void LoadSearchesFromFile(string filePath)
        {
            string solutionDir = AppDomain.CurrentDomain.BaseDirectory;
            string finalPath = Path.Combine(solutionDir, filePath);
            if (!File.Exists(finalPath))
            {
                solutionDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..");
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

        private async void RefreshTimer_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;

            // Si estamos en espera entre rachas
            if (_profile.Search.StreakTime != null)
            {
                // Si todavia no hemos superado el tiempo que hay que esperar entre rachas
                if (Convert.ToInt32((now - _profile.Search.StreakTime.Value).TotalSeconds) <= _profile.Search.StreakDelay)
                {
                    _mainForm.UpdateInterface(_awaker);
                    return;
                }
                // Una vez superado el tiempo de espera entre rachas, se reincia la racha para empezar una nueva
                else
                {
                    _profile.Search.StreakCount = 0;
                    _profile.Search.StreakTime = null;
                    _profile.Search.StreakDelay = 0;
                    _profile.Search.StreakAmount = _profile.Preferences.GetStreakAmount();
                }
            }

            // Si hay configurado algun numero de repeticiones por rachas en preferencias
            if (_profile.Preferences.MaxStreakAmount > 0)
            {
                // Si estamos iniciando una racha, obtenemos la cantidad de repeticiones para la racha actual
                if (_profile.Search.StreakAmount == null)
                    _profile.Search.StreakAmount = _profile.Preferences.GetStreakAmount();

                // Si hemos alcanzado el numero maximo de repeticiones, acabamos la racha y iniciamos el "tiempo de espera" entre rachas
                if (_profile.Search.StreakCount >= _profile.Search.StreakAmount)
                {
                    if (_profile.Search.StreakTime == null)
                    {
                        _profile.Search.StreakTime = now;
                        _profile.Search.StreakDelay = _profile.Preferences.GetStreakDelay();
                        _profile.Search.StreakAmount = 0;
                    }
                }
            }

            _profile.Search.ElapsedSeconds++;

            // Si superamos el tiempo de espera entre repeticiones, pasaremos a la siguiente repeticion
            if (_profile.Search.ElapsedSeconds >= _profile.Search.SecondsToWait)
            {
                // Si no hay ninguna busqueda por hacer, paramos las busquedas
                if (_profile.Search.ToSearch.Count() == 0)
                {
                    Stop();
                    _mainForm.UpdateInterface(_awaker);
                    return;
                }

                // puntos de escritorio alcanzados
                bool desktopPointsReached = _profile.Search.DesktopSearchesCount * _profile.Preferences.DesktopPointsPersearch >= _profile.Preferences.DesktopTotalPoints;
                // puntos mobiles alcanzados
                bool mobilePointsReached = _profile.Search.MobileSearchesCount * _profile.Preferences.MobilePointsPersearch >= _profile.Preferences.MobileTotalPoints;

                // Si estamos haciendo la busqueda de escritorio y hemos alcanzado los puntos de escritorio
                if (!_profile.Search.IsMobile && desktopPointsReached)
                {
                    // Si no hemos alcanzado los puntos mobiles, cambiamos a modo "movil"
                    if (!mobilePointsReached)
                    {
                        await ChangeMobileMode(SearchMode.Mobile, false);
                    }
                    // En caso contrario, paramos la ejecucion
                    else
                    {
                        Stop();
                        _mainForm.UpdateInterface(_awaker);
                        return;
                    }
                }
                // Si estamos haciendo la busqueda movil y hemos alcanzado los puntos moviles
                else if (_profile.Search.IsMobile && mobilePointsReached)
                {
                    // Si no hemos alcanzado los puntos de escritorio, cambiamos al modo "Escritorio"
                    if (!desktopPointsReached)
                    {
                        await ChangeMobileMode(SearchMode.Desktop, false);
                    }
                    // En caso contrario, paramos la ejecucion
                    else
                    {
                        PlayAndStop(false);
                        _mainForm.UpdateInterface(_awaker);
                        return;
                    }
                }

                // Reiniciamos los limites de la repeticion
                RestartRepetitionsLimits();
                if (_profile.Preferences.MinStreakAmount > 0)
                    _profile.Search.StreakCount++;

                // Hacemos la busqueda
                await ExecuteSearchProcess();

                // Extraemos los puntos alcanzados del html de rewards
                await ExtractPoints();
            }

            _mainForm.UpdateInterface(_awaker);
        }

        private async Task ExtractPoints()
        {
            await _wvRewardsController.SetRewardsURL(new Uri("https://rewards.bing.com/pointsbreakdown"));
            await Task.Delay(2000);

            // Buscar primero "Búsqueda en PC"
            await _wvRewardsController.WaitForTextToBeVisible("Búsqueda en PC");
            (int currentPoints, int maxPoints, int pointsPerSearch) desktop = await _wvRewardsController.ExtractPoints("Búsqueda en PC");
            _profile.Preferences.DesktopPointsPersearch = desktop.pointsPerSearch;
            _profile.Preferences.DesktopTotalPoints = desktop.maxPoints;

            if (_profile.Preferences.DesktopPointsPersearch != 0)
                _profile.Search.DesktopSearchesCount = desktop.currentPoints / _profile.Preferences.DesktopPointsPersearch;
            else
                _profile.Search.DesktopSearchesCount = 0;

            // Intentar encontrar "Búsqueda en móviles" con un tiempo límite de 10 segundos
            bool mobileSearchVisible = await _wvRewardsController.WaitForTextToBeVisible("Búsqueda en móviles", 1000);

            if (mobileSearchVisible)
            {
                (int currentPoints, int maxPoints, int pointsPerSearch) mobile = await _wvRewardsController.ExtractPoints("Búsqueda en móviles");
                _profile.Preferences.MobilePointsPersearch = mobile.pointsPerSearch;
                _profile.Preferences.MobileTotalPoints = mobile.maxPoints;

                if (_profile.Preferences.MobilePointsPersearch != 0)
                    _profile.Search.MobileSearchesCount = mobile.currentPoints / _profile.Preferences.MobilePointsPersearch;
                else
                    _profile.Search.MobileSearchesCount = 0;
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


        private async Task ChangeMobileMode(SearchMode mode, bool reloadWeb)
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
                    _wvRewardsController.OpenRewards();
            }
            else
                Stop();

            _mainForm.UpdateInterface(_awaker);
        }

        private void Stop()
        {
            _refreshTimer.Stop(); // Detiene el temporizador si ya está activo
            _profile.Search.Stop();

            _awaker.Stop();
        }

        private void Play()
        {
            RestartRepetitionsLimits();

            _refreshTimer.Start(); // Inicia el temporizador cuando se presiona el botón
            _profile.Search.IsPlaying = true;
            _awaker.Start();
        }

        public void RestartRepetitionsLimits()
        {
            _profile.RestartLimits();

            _mainForm.UpdateInterface(_awaker);
        }

        private async Task RefreshMobileMode(bool reloadWeb)
        {
            _profile.Preferences.Save();

            if (_profile.Search.IsMobile)
                _wvSearchesController.SetUserAgent(_profile.Preferences.MobileUserAgent);
            else
                _wvSearchesController.SetUserAgent(_profile.Preferences.DesktopUserAgent);

            await _wvSearchesController.DeleteSessionCookies();

            if (_profile.Search.EmergencyStop())
            {
                Stop();
                return;
            }

            if (reloadWeb)
            {
                _profile.Search.AddHistoricSearch(_profile.Search.URL.ToString());
                await _wvSearchesController.ReloadSearchsWeb();
            }

            _mainForm.UpdateInterface(_awaker);
        }

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
            _wvSearchesController.NavigationCompleted += _mainForm_SearchesNavigationCompleted;
            _wvRewardsController.NewWindowRequested += _mainForm_RewardsNewWindowRequested;

            _wvSearchesController.CoreWebView2InitializationCompleted += _mainForm_SearchesCoreWebView2InitializationCompleted;
            _wvRewardsController.CoreWebView2InitializationCompleted += _mainForm_RewardsCoreWebView2InitializationCompleted;

            _wvSearchesController.InitializeEvents();
            _wvRewardsController.InitializeEvents();

            await _wvSearchesController.EnsureCoreWebView2Async();
            await _wvRewardsController.EnsureCoreWebView2Async();
            _profile.Search.URL = new Uri("https://www.bing.es/");
            await _wvSearchesController.OpenSearchesURL(_profile.Search.URL);
            await _wvRewardsController.SetRewardsURL(new Uri("https://rewards.bing.com/pointsbreakdown"));
            _mainForm.SelectTabAndReturn(TabType.Rewards);

            await ExtractPoints();

            _mainForm.UpdateInterface(_awaker);

            _mainForm.BindFields();

            RefreshNextSearch();
        }

        private async void _mainForm_ForceClicked(object sender, EventArgs e)
        {
            await ExecuteSearchProcess();
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
            await ChangeMobileMode(SearchMode.Desktop, true);
            _mainForm.UpdateInterface(_awaker);
        }

        private void _mainForm_PreferencesClciked(object sender, EventArgs e)
        {
            using (PreferencesForm form = new PreferencesForm())
            using (PreferencesPresenter presenter = new PreferencesPresenter(form, _profile.Preferences))
            {
                form.ShowDialog();
                _profile.Preferences = new Preferences($"{_profile.Path}\\Config\\config.json");
                _mainForm.BindFields();
                _mainForm.UpdateInterface(_awaker);
            }
        }

        #endregion
    }
}
