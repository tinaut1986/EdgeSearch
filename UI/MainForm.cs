using EdgeSearch.models;
using EdgeSearch.Models;
using Microsoft.Web.WebView2.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace EdgeSearch.UI
{
    public partial class MainForm : Form
    {

        private bool _isPlaying;
        private string _nextSearch;

        public MainForm()
        {
            InitializeComponent();

            InitializeWebView();
            InitializeProgressBar();
            SetupRefreshTimer();

            RefreshUpdateRange();

            _isPlaying = false;

            SetNextSearch();

            Load += Form_Load;
            webView.CoreWebView2InitializationCompleted += WebView_CoreWebView2InitializationCompleted;
        }

        public void UpdateNextSearch(string nextSearch)
        {
            lblNextSearch.Text = $"Next search: {nextSearch}";
        }

        private void RefreshUpdateRange()
        {
            lblRange.Text = $"Refresh range (segs): {_preferences.LowerLimit}/{_preferences.UpperLimit}";
        }

        private void WebView_CoreWebView2InitializationCompleted(object sender, CoreWebView2InitializationCompletedEventArgs e)
        {
            webView.CoreWebView2.Settings.UserAgent = chkMobile.Checked ? _preferences.MobileUserAgent : _preferences.DesktopUserAgent;

            webView.Source = new Uri("https://www.bing.es/");
            RefreshURLText();
        }

        private void RefreshURLText()
        {
            txtURL.Text = webView.Source.AbsoluteUri;
        }

        public void SetUserAgent(string userAgent)
        {
            if (webView.CoreWebView2?.Settings != null)
                webView.CoreWebView2.Settings.UserAgent = userAgent;
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

        public void SetSource(string search)
        {
            webView.Source = new Uri($"https://www.bing.com/search?q={search}&form=QBLH&sp=-1&ghc=1&lq=0&pq={search}");
            txtURL.Text = webView.Source.AbsoluteUri;
        }

        public void UpdateLblResume(Search search, Preferences preferences)
        {
            int searchesCount = search.CurrentMode == Preferences.Mode.Mobile ? search.MobileSearchesCount : search.DesktopSearchesCount;
            int pointsLimit = search.CurrentMode == Preferences.Mode.Mobile ? preferences.MobileTotalPoints : preferences.DesktopTotalPoints;

            lblResumen.Text = $"searches: {searchesCount} | points: {searchesCount * 3}/{pointsLimit}";
        }

        private void InitializeProgressBar()
        {
            Controls.Add(progressBar);
        }

        private void UpdateProgressBar(Search search, Preferences preferences)
        {
            progressBar.Value = progressBar.Maximum - search.elapsedSeconds; // Calcula el progreso actual basado en los segundos transcurridos

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

        private void UpdateProgressBarLimits(Search search)
        {
            progressBar.Minimum = 0;
            progressBar.Maximum = search.RefreshSeconds; // Número de segundos para la recarga
            progressBar.Value = progressBar.Maximum; // Establece el valor inicial como el máximo para empezar lleno
        }

        private async System.Threading.Tasks.Task ChangeMobileMode(Preferences.Mode mode, bool reloadWeb)
        {
            chkMobile.Checked = mode == Preferences.Mode.Mobile;
            await RefreshMobileMode(reloadWeb);
        }

        private async System.Threading.Tasks.Task DeleteSessionCookies()
        {
            if (webView.CoreWebView2?.Settings != null)
            {
                foreach (CoreWebView2Cookie cookie in (await webView.CoreWebView2.CookieManager.GetCookiesAsync(null)).ToList())
                {
                    if (cookie.IsSession)
                        webView.CoreWebView2.CookieManager.DeleteCookie(cookie);
                }
            }
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

        private async void chkMobile_CheckedChanged(object sender, EventArgs e)
        {
            await RefreshMobileMode(true);
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(lblNextSearch.Text);
        }

        private void btnForce_Click(object sender, EventArgs e)
        {
            DoSearch();
        }
    }
}
