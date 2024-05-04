using EdgeSearch.models;
using EdgeSearch.Models;
using Microsoft.Web.WebView2.Core;
using System;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EdgeSearch.UI
{
    public partial class MainForm : Form
    {
        #region Members
        public event EventHandler PlayClicked;
        public event EventHandler ForceClicked;
        public event EventHandler OpenClicked;
        public event EventHandler CopyClicked;
        public event EventHandler NextSearchClicked;
        public event EventHandler MobileChanged;
        public event EventHandler<CoreWebView2InitializationCompletedEventArgs> CoreWebView2InitializationCompleted;
        #endregion

        #region Constructors & destructor
        public MainForm()
        {
            InitializeComponent();

            InitializeWebView();
            InitializeProgressBar();

            InitializeEvents();
        }

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                FinalizeEvents();

                components?.Dispose();
            }
            base.Dispose(disposing);
        }
        #endregion

        #region Methods

        public void BindFields(Search search)
        {
            txtURL.DataBindings.Clear();
            txtURL.DataBindings.Add(nameof(txtURL.Text), search, nameof(search.URL));

            chkMobile.DataBindings.Clear();
            chkMobile.DataBindings.Add(nameof(chkMobile.Checked), search, nameof(search.IsMobile));

            txtLoweLimit.DataBindings.Clear();
            txtLoweLimit.DataBindings.Add(nameof(txtLoweLimit.Text), search, nameof(search.LowerLimit));

            txtUpperLimit.DataBindings.Clear();
            txtUpperLimit.DataBindings.Add(nameof(txtUpperLimit.Text), search, nameof(search.UpperLimit));

            txtSearches.DataBindings.Clear();
            txtSearches.DataBindings.Add(nameof(txtSearches.Text), search, nameof(search.SearchesCount));

            txtCurrentPoints.DataBindings.Clear();
            txtCurrentPoints.DataBindings.Add(nameof(txtCurrentPoints.Text), search, nameof(search.CurrentPoints));

            txtPointsLimit.DataBindings.Clear();
            txtPointsLimit.DataBindings.Add(nameof(txtPointsLimit.Text), search, nameof(search.PointsLimit));
        }

        private void InitializeEvents()
        {
            webView.CoreWebView2InitializationCompleted += WebView_CoreWebView2InitializationCompleted;
            btnPlay.Click += btnPlay_Click;
            btnForce.Click += btnForce_Click;
            btnCopy.Click += btnCopy_Click;
            btnNext.Click += btnNext_Click;
            chkMobile.CheckedChanged += chkMobile_CheckedChanged;
            btnOpen.Click += btnOpen_Click;
            txtURL.KeyPress += txtURL_KeyPress;
        }

        private void FinalizeEvents()
        {
            webView.CoreWebView2InitializationCompleted -= WebView_CoreWebView2InitializationCompleted;
            btnPlay.Click -= btnPlay_Click;
            btnForce.Click -= btnForce_Click;
            btnCopy.Click -= btnCopy_Click;
            btnNext.Click -= btnNext_Click;
            chkMobile.CheckedChanged -= chkMobile_CheckedChanged;
            btnOpen.Click -= btnOpen_Click;
            txtURL.KeyPress -= txtURL_KeyPress;
        }

        public void SetUserAgent(string userAgent)
        {
            if (webView.CoreWebView2?.Settings != null)
                webView.CoreWebView2.Settings.UserAgent = userAgent;
        }

        public async Task EnsureCoreWebView2Async()
        {
            await webView.EnsureCoreWebView2Async(null);
        }

        private async void InitializeWebView()
        {
            Controls.Add(webView);

            await webView.EnsureCoreWebView2Async(); // Inicializar WebView2
        }

        public void SetURL(Uri url)
        {
            if (webView.Source != url)
                webView.Source = url;
            else
                ReloadWeb();
        }

        private void InitializeProgressBar()
        {
            Controls.Add(progressBar);
        }

        public void UpdateInterface(Search search)
        {
            if (!search.IsPlaying)
                btnPlay.Text = "Play";
            else
                btnPlay.Text = "Stop";

            btnOpen.Enabled = !search.IsPlaying;
            txtURL.ReadOnly = search.IsPlaying;
            txtURL.Text = webView.Source.AbsoluteUri;

            progressBar.Minimum = 0;
            progressBar.Maximum = search.SecondsToRefresh; // Número de segundos para la recarga
            progressBar.Value = progressBar.Maximum; // Establece el valor inicial como el máximo para empezar lleno

            lblNextSearch.Text = $"Next search: {search.NextSearch}";

            progressBar.Value = Math.Max(progressBar.Maximum - search.ElapsedSeconds, 0); // Calcula el progreso actual basado en los segundos transcurridos
            lblProgress.Text = $"{search.ElapsedSeconds}/{search.SecondsToRefresh} segs"; // Actualiza el texto del Label

            BindFields(search);
        }

        public void ReloadWeb()
        {
            if (webView.Source != null)
                webView.Reload();
        }

        public async System.Threading.Tasks.Task DeleteSessionCookies()
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
        #endregion

        #region Events
        private void WebView_CoreWebView2InitializationCompleted(object sender, CoreWebView2InitializationCompletedEventArgs e)
        {
            CoreWebView2InitializationCompleted?.Invoke(sender, e);
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            PlayClicked?.Invoke(sender, e);
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenClicked?.Invoke(sender, e);
        }

        private void txtURL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)ConsoleKey.Enter)
                btnOpen_Click(null, null);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            NextSearchClicked?.Invoke(sender, e);
        }

        private void chkMobile_CheckedChanged(object sender, EventArgs e)
        {
            MobileChanged?.Invoke(sender, e);
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            CopyClicked?.Invoke(sender, e);
        }

        private void btnForce_Click(object sender, EventArgs e)
        {
            ForceClicked?.Invoke(this, EventArgs.Empty);
        }
        #endregion
    }
}
