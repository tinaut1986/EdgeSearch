using EdgeSearch.models;
using EdgeSearch.Models;
using EdgeSearch.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        private Timer _refreshTimer;
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
            _mainForm.NextSearchClicked += _mainForm_NextSearchClicked;
            _mainForm.MobileChanged += _mainForm_MobileChanged;
            _mainForm.PlayClicked += _mainForm_PlayClicked;
        }

        private void _mainForm_OpenClicked(object sender, EventArgs e)
        {
            _mainForm.SetURL(_search.URL);
        }

        private void SetupRefreshTimer()
        {
            _refreshTimer = new Timer();
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
            string currentSearch = Search.NextSearch;
            RefreshNextSearch();
            Search.URL = new Uri($"https://www.bing.com/search?q={currentSearch}&form=QBLH&sp=-1&ghc=1&lq=0&pq={currentSearch}");

            _mainForm.SetURL(_search.URL);

            _search.UsedSearchs.Add(currentSearch);

            if (_search.IsMobile)
                _search.MobileSearchesCount++;
            else
                _search.DesktopSearchesCount++;

            _mainForm.UpdateInterface(_search);
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
            while (_search.UsedSearchs.Contains(search));

            return search;
        }

        private async void RefreshTimer_Tick(object sender, EventArgs e)
        {
            _search.ElapsedSeconds++;

            if (_search.ElapsedSeconds >= _search.SecondsToRefresh)
            {
                if (_search.ToSearch.Count == 0)
                {
                    PlayAndStop();
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
                        PlayAndStop();
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
                        PlayAndStop();
                        return;
                    }
                }

                DoSearch();
                RestartLimits();
            }

            _mainForm.UpdateInterface(_search);
        }

        private async System.Threading.Tasks.Task ChangeMobileMode(Preferences.Mode mode, bool reloadWeb)
        {
            _search.CurrentMode = mode;
            await RefreshMobileMode(reloadWeb);
        }

        private void PlayAndStop()
        {
            if (!_search.IsPlaying)
            {
                RestartLimits();
                _refreshTimer.Start(); // Inicia el temporizador cuando se presiona el botón
                _search.IsPlaying = true;
            }
            else
            {
                _refreshTimer.Stop(); // Detiene el temporizador si ya está activo
                _search.IsPlaying = false;
            }

            _mainForm.UpdateInterface(_search);
        }

        public void RestartLimits()
        {
            _search.ElapsedSeconds = 0;
            _search.SecondsToRefresh = _random.Next(_search.LowerLimit, _search.UpperLimit + 1);

            _mainForm.UpdateInterface(_search);
        }

        private async System.Threading.Tasks.Task RefreshMobileMode(bool reloadWeb)
        {
            _preferences.LastMode = _search.CurrentMode;
            _preferences.Save();

            if (_search.IsMobile)
                _mainForm.SetUserAgent(_search.MobileUserAgent);
            else
                _mainForm.SetUserAgent(_search.DesktopUserAgent);

            await _mainForm.DeleteSessionCookies();

            if (reloadWeb)
                _mainForm.ReloadWeb();

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
            _mainForm.SetURL(_search.URL);
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
            await RefreshMobileMode(true);
        }

        private void _mainForm_PlayClicked(object sender, EventArgs e)
        {
            PlayAndStop();
        }

        #endregion
    }
}
