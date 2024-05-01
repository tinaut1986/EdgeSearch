using EdgeSearch.models;
using EdgeSearch.UI;
using Newtonsoft.Json;
using System.IO;
using System;
using EdgeSearch.Models;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Linq;

namespace EdgeSearch.Business
{
    internal class MainPresenter
    {
        #region Members
        private MainForm _mainForm;
        private Search _search;
        private string _nextSearch;
        private Random _random;
        private Preferences _preferences;
        private Timer _refreshTimer;

        private List<string> _toSearch = new List<string>();
        private List<string> _sagas = new List<string>();
        private List<string> _hardware = new List<string>();
        private List<string> _retro = new List<string>();
        private List<string> _games = new List<string>();
        private List<string> _companies = new List<string>();
        private List<string> _usedSearchs = new List<string>();
        #endregion

        #region Properties
        Search Search => _search;
        #endregion

        #region Constructors and destructor
        public MainPresenter(MainForm mainForm, Search search)
        {
            _mainForm = mainForm;
            _search = search;

            _random = new Random();

            // Carga las preferencias
            _preferences = new Preferences("config.json");

            LoadSearchesFromFile("searches.xml"); // Carga las búsquedas desde el archivo

        }
        #endregion

        #region Methods
        private void SetupRefreshTimer()
        {
            _refreshTimer = new Timer();
            _refreshTimer.Interval = 1000; // Intervalo de actualización cada segundo
            _refreshTimer.Tick += RefreshTimer_Tick;
        }

        private void SetNextSearch()
        {
            _nextSearch = CreateSearch();
            _mainForm.UpdateNextSearch(_nextSearch);
        }

        private void DoSearch()
        {
            string nextSearch = _nextSearch;
            SetNextSearch();

            _mainForm.SetSource(nextSearch);

            _usedSearchs.Add(nextSearch);

            if (_search.IsMobile)
                _search.MobileSearchesCount++;
            else
                _search.DesktopSearchesCount++;

            _mainForm.UpdateLblResume(_search, _preferences);
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

                _toSearch = xml.Element("searches")?.Elements("item").Select(e => e.Value).ToList() ?? new List<string>();
                _sagas = xml.Element("sagas")?.Elements("item").Select(e => e.Value).ToList() ?? new List<string>();
                _hardware = xml.Element("hardware")?.Elements("item").Select(e => e.Value).ToList() ?? new List<string>();
                _retro = xml.Element("retro")?.Elements("item").Select(e => e.Value).ToList() ?? new List<string>();
                _games = xml.Element("games")?.Elements("item").Select(e => e.Value).ToList() ?? new List<string>();
                _companies = xml.Element("companies")?.Elements("item").Select(e => e.Value).ToList() ?? new List<string>();
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
                search = _toSearch[_random.Next(0, _toSearch.Count)];

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
            while (_usedSearchs.Contains(search));

            return search;
        }

        private async void RefreshTimer_Tick(object sender, EventArgs e)
        {
            _search.ElapsedSeconds++;

            if (_search.ElapsedSeconds >= _search.RefreshSeconds)
            {
                if (_toSearch.Count == 0)
                {
                    btnPlay_Click(null, null);
                    return;
                }

                bool desktopPointsReached = (Search.DesktopSearchesCount * 3) >= _preferences.DesktopTotalPoints;
                bool MobilePointsReached = (Search.MobileSearchesCount * 3) >= _preferences.MobileTotalPoints;
                if (!Search.IsMobile && desktopPointsReached)
                {
                    if (!MobilePointsReached)
                    {
                        await ChangeMobileMode(Preferences.Mode.Mobile, false);
                    }
                    else
                    {
                        btnPlay_Click(null, null);
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
                        btnPlay_Click(null, null);
                        return;
                    }
                }

                DoSearch();

                _mainForm.UpdateLimits();
            }

            UpdateProgressBar();
        }

        public void UpdateLimits()
        {
            _search.RefreshSeconds = _random.Next(_preferences.LowerLimit, _preferences.UpperLimit + 1);
            _search.ElapsedSeconds = 0;

            UpdateProgressBarLimits();
        }

        private async System.Threading.Tasks.Task RefreshMobileMode(bool reloadWeb)
        {
            _preferences.LastMode = _search.CurrentMode;
            if (_search.IsMobile)
                _mainForm.SetUserAgent(_search.MobileUserAgent);
            else
                _mainForm.SetUserAgent(_search.DesktopUserAgent);

            _preferences.Save();

            await DeleteSessionCookies();

            if (webView.Source != null && reloadWeb)
                webView.Reload();

            UpdateLblResume();
        }

        private string GetSaga() => _sagas[_random.Next(0, _sagas.Count)];
        private string GetGame() => _games[_random.Next(0, _games.Count)];
        private string GetHardware() => _hardware[_random.Next(0, _hardware.Count)];
        private string GetCompany() => _companies[_random.Next(0, _companies.Count)];
        private string GetRetro() => _retro[_random.Next(0, _retro.Count)];

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
    }
}
