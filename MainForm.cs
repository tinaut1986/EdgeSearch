using Microsoft.Web.WebView2.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Test_web
{
    public partial class MainForm : Form
    {
        private const string mobileUserAgent = "Mozilla/5.0 (Linux; Android 9; ASUS_X00TD; Flow) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/359.0.0.288 Mobile Safari/537.36";
        private const string desktopUserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/100.0.0.0 Safari/537.36";
        private Preferences _preferences;

        private Timer refreshTimer;
        private int elapsedSeconds;
        private int refreshSeconds;
        private int desktopSearchesCount = 0;
        private int mobileSearchesCount = 0;
        private int desktopPointsLimit = 90;
        private int mobilePointsLimit = 60;
        private Random _random;
        private bool _isPlaying;
        private string _nextSearch;

        private List<string> toSearch = new List<string>();
        private List<string> sagas = new List<string>();
        private List<string> hardware = new List<string>();
        private List<string> retro = new List<string>();
        private List<string> games = new List<string>();
        private List<string> companies = new List<string>();
        private List<string> usedSearchs = new List<string>();

        public MainForm()
        {
            InitializeComponent();

            _random = new Random();
            InitializeWebView();
            InitializeProgressBar();
            SetupRefreshTimer();

            // Ruta al archivo de configuración
            string configFilePath = "config.json";

            // Carga las preferencias
            _preferences = new Preferences(configFilePath);

            RefreshUpdateRange();

            _isPlaying = false;

            LoadSearchesFromFile("searches.xml"); // Carga las búsquedas desde el archivo
            SetNextSearch();

            Load += Form_Load;
            webView.CoreWebView2InitializationCompleted += WebView_CoreWebView2InitializationCompleted;
        }

        private void SetNextSearch()
        {
            _nextSearch = CreateSearch();
            lblNextSearch.Text = $"Next search: {_nextSearch}";
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

                toSearch = xml.Element("searches")?.Elements("item").Select(e => e.Value).ToList() ?? new List<string>();
                sagas = xml.Element("sagas")?.Elements("item").Select(e => e.Value).ToList() ?? new List<string>();
                hardware = xml.Element("hardware")?.Elements("item").Select(e => e.Value).ToList() ?? new List<string>();
                retro = xml.Element("retro")?.Elements("item").Select(e => e.Value).ToList() ?? new List<string>();
                games = xml.Element("games")?.Elements("item").Select(e => e.Value).ToList() ?? new List<string>();
                companies = xml.Element("companies")?.Elements("item").Select(e => e.Value).ToList() ?? new List<string>();
            }
            else
                MessageBox.Show($"El archivo {finalPath} no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void RefreshUpdateRange()
        {
            lblRange.Text = $"Refresh range (segs): {_preferences.LowerLimit}/{_preferences.UpperLimit}";
        }

        private void WebView_CoreWebView2InitializationCompleted(object sender, CoreWebView2InitializationCompletedEventArgs e)
        {
            webView.CoreWebView2.Settings.UserAgent = chkMobile.Checked ? mobileUserAgent : desktopUserAgent;

            webView.Source = new Uri("https://www.google.es/");
            RefreshURLText();
        }

        private void RefreshURLText()
        {
            txtURL.Text = webView.Source.AbsoluteUri;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            webView.EnsureCoreWebView2Async(null);

            if (_preferences.LastMode == Preferences.Mode.Mobile)
                chkMobile.Checked = true;
        }

        private async void InitializeWebView()
        {
            Controls.Add(webView);

            await webView.EnsureCoreWebView2Async(); // Inicializar WebView2
        }

        private void SetupRefreshTimer()
        {
            refreshTimer = new Timer();
            refreshTimer.Interval = 1000; // Intervalo de actualización cada segundo
            refreshTimer.Tick += RefreshTimer_Tick;
        }

        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            elapsedSeconds++;

            if (elapsedSeconds >= refreshSeconds)
            {
                if (toSearch.Count == 0
                    || (!chkMobile.Checked && (desktopSearchesCount * 3) >= desktopPointsLimit)
                    || (chkMobile.Checked && (mobileSearchesCount * 3) >= mobilePointsLimit))
                {
                    btnPlay_Click(null, null);
                    return;
                }

                string search = _nextSearch;
                SetNextSearch();

                webView.Source = new Uri($"https://www.bing.com/search?q={search}&form=QBLH&sp=-1&ghc=1&lq=0&pq={search}");

                usedSearchs.Add(search);
                elapsedSeconds = 0; // Reinicia el contador de segundos
                UpdateLimits();
                txtURL.Text = webView.Source.AbsoluteUri;

                if (chkMobile.Checked)
                    mobileSearchesCount++;
                else
                    desktopSearchesCount++;

                UpdateLblResume();
            }

            UpdateProgressBar();
        }

        private void UpdateLblResume()
        {
            int searchesCount = chkMobile.Checked ? mobileSearchesCount : desktopSearchesCount;
            int pointsLimit = chkMobile.Checked ? mobilePointsLimit : desktopPointsLimit;

            lblResumen.Text = $"searches: {searchesCount} | points: {searchesCount * 3}/{pointsLimit}";
        }

        private string CreateSearch()
        {
            string search = "";
            do
            {
                // Selecciona un elemento al azar de la lista
                search = toSearch[_random.Next(0, toSearch.Count)];

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
            while (usedSearchs.Contains(search));

            return search;
        }

        private string GetSaga() => sagas[_random.Next(0, sagas.Count)];
        private string GetGame() => games[_random.Next(0, games.Count)];
        private string GetHardware() => hardware[_random.Next(0, hardware.Count)];
        private string GetCompany() => companies[_random.Next(0, companies.Count)];
        private string GetRetro() => retro[_random.Next(0, retro.Count)];

        private void InitializeProgressBar()
        {
            Controls.Add(progressBar);
        }

        private void UpdateProgressBar()
        {
            progressBar.Value = progressBar.Maximum - elapsedSeconds; // Calcula el progreso actual basado en los segundos transcurridos

            lblProgress.Text = $"{elapsedSeconds}/{refreshSeconds} segs"; // Actualiza el texto del Label
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (!_isPlaying)
            {
                UpdateLimits();
                refreshTimer.Start(); // Inicia el temporizador cuando se presiona el botón
                _isPlaying = true;
                btnPlay.Text = "Stop"; // Cambia el texto del botón a "Stop"
            }
            else
            {
                refreshTimer.Stop(); // Detiene el temporizador si ya está activo
                _isPlaying = false;
                btnPlay.Text = "Play"; // Cambia el texto del botón a "Play"
            }

            btnOpen.Enabled = !_isPlaying;
            txtURL.ReadOnly = _isPlaying;
        }

        private void UpdateLimits()
        {
            refreshSeconds = _random.Next(_preferences.LowerLimit, _preferences.UpperLimit + 1);
            elapsedSeconds = 0;

            UpdateProgressBarLimits();
        }

        private void UpdateProgressBarLimits()
        {
            progressBar.Minimum = 0;
            progressBar.Maximum = refreshSeconds; // Número de segundos para la recarga
            progressBar.Value = progressBar.Maximum; // Establece el valor inicial como el máximo para empezar lleno
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (txtURL.Text != webView.Source.ToString())
                webView.Source = new Uri(txtURL.Text);
            else
                webView.Reload();
        }

        private void txtURL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)ConsoleKey.Enter)
                btnOpen_Click(null, null);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            SetNextSearch();
        }

        private void chkMobile_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMobile.Checked)
            {
                if (webView.CoreWebView2?.Settings != null)
                    webView.CoreWebView2.Settings.UserAgent = mobileUserAgent;
                _preferences.LastMode = Preferences.Mode.Mobile;
            }
            else
            {
                if (webView.CoreWebView2?.Settings != null)
                    webView.CoreWebView2.Settings.UserAgent = desktopUserAgent;
                _preferences.LastMode = Preferences.Mode.Desktop;
            }

            _preferences.Save();
            if (webView.Source != null)
                webView.Reload();

            UpdateLblResume();
        }
    }
}
