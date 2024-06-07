using EdgeSearch.Models;
using Microsoft.Web.WebView2.Core;
using System;
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
        public event EventHandler NextSearchClicked;
        public event EventHandler MobileChanged;
        public event EventHandler<CoreWebView2InitializationCompletedEventArgs> SearchesCoreWebView2InitializationCompleted;
        public event EventHandler<CoreWebView2InitializationCompletedEventArgs> MissionCoreWebView2InitializationCompleted;
        #endregion

        #region Constructors & destructor
        public MainForm()
        {
            InitializeComponent();

            InitializeWebView();

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

            txtNextSearch.DataBindings.Clear();
            txtNextSearch.DataBindings.Add(nameof(txtNextSearch.Text), search, nameof(search.NextSearch));

            chkMobile.DataBindings.Clear();
            chkMobile.DataBindings.Add(nameof(chkMobile.Checked), search, nameof(search.IsMobile));

            txtLowerLimit.DataBindings.Clear();
            txtLowerLimit.DataBindings.Add(nameof(txtLowerLimit.Text), search, nameof(search.LowerLimit));

            txtUpperLimit.DataBindings.Clear();
            txtUpperLimit.DataBindings.Add(nameof(txtUpperLimit.Text), search, nameof(search.UpperLimit));

            txtSearches.DataBindings.Clear();
            txtSearches.DataBindings.Add(nameof(txtSearches.Text), search, nameof(search.SearchesCount));

            txtCurrentPoints.DataBindings.Clear();
            txtCurrentPoints.DataBindings.Add(nameof(txtCurrentPoints.Text), search, nameof(search.CurrentPoints));

            txtPointsLimit.DataBindings.Clear();
            txtPointsLimit.DataBindings.Add(nameof(txtPointsLimit.Text), search, nameof(search.PointsLimit));

            progressBar.DataBindings.Clear();
            progressBar.DataBindings.Add(nameof(progressBar.Maximum), search, nameof(search.SecondsToRefresh));
            progressBar.DataBindings.Add(nameof(progressBar.Value), search, nameof(search.ElapsedSeconds));
        }

        private void InitializeEvents()
        {
            //wvSearchs.CoreWebView2InitializationCompleted += WvSearchs_CoreWebView2InitializationCompleted;
            //wvMissions.CoreWebView2InitializationCompleted += WvMissions_CoreWebView2InitializationCompleted;

            btnPlay.Click += btnPlay_Click;
            btnSearch.Click += btnForce_Click;
            btnNext.Click += btnNext_Click;
            chkMobile.Click += ChkMobile_Click;
            btnOpen.Click += btnOpen_Click;
            txtURL.KeyPress += txtURL_KeyPress;
        }

        private void FinalizeEvents()
        {
            //wvSearchs.CoreWebView2InitializationCompleted -= WvSearchs_CoreWebView2InitializationCompleted;
            //wvMissions.CoreWebView2InitializationCompleted -= WvMissions_CoreWebView2InitializationCompleted;

            btnPlay.Click -= btnPlay_Click;
            btnSearch.Click -= btnForce_Click;
            btnNext.Click -= btnNext_Click;
            chkMobile.Click -= ChkMobile_Click;
            btnOpen.Click -= btnOpen_Click;
            txtURL.KeyPress -= txtURL_KeyPress;
        }

        public void SetUserAgent(string userAgent)
        {
            if (wvSearchs.CoreWebView2?.Settings != null)
                wvSearchs.CoreWebView2.Settings.UserAgent = userAgent;
        }

        public async Task EnsureCoreWebView2Async()
        {
            await wvSearchs.EnsureCoreWebView2Async(null);
            await wvMissions.EnsureCoreWebView2Async(null);
        }

        private async void InitializeWebView()
        {
            //Controls.Add(wvSearchs);

            await wvSearchs.EnsureCoreWebView2Async();
            await wvMissions.EnsureCoreWebView2Async();
        }

        public void SetSearchsURL(Uri url)
        {
            if (wvSearchs.Source != url)
                wvSearchs.Source = url;
            else
                ReloadSearchsWeb();
        }

        public void SetMissionsURL(Uri url)
        {
            if (wvMissions.Source != url)
                wvMissions.Source = url;
            else
                ReloadSearchsWeb();


        }

        public void UpdateInterface(Search search)
        {
            if (!search.IsPlaying)
                btnPlay.Text = "Play";
            else
                btnPlay.Text = "Stop";

            btnOpen.Enabled = !search.IsPlaying;
            txtURL.ReadOnly = search.IsPlaying;
            txtURL.Text = wvSearchs.Source.AbsoluteUri;

            lblProgress.Text = $"{search.ElapsedSeconds}/{search.SecondsToRefresh} segs";
        }

        public void ReloadSearchsWeb()
        {
            if (wvSearchs.Source != null)
                wvSearchs.Reload();
        }

        public void ReloadMissionsWeb()
        {
            if (wvMissions.Source != null)
                wvMissions.Reload();
        }

        public async System.Threading.Tasks.Task DeleteSessionCookies()
        {
            if (wvSearchs.CoreWebView2?.Settings != null)
            {
                foreach (CoreWebView2Cookie cookie in (await wvSearchs.CoreWebView2.CookieManager.GetCookiesAsync(null)).ToList())
                {
                    if (cookie.IsSession)
                        wvSearchs.CoreWebView2.CookieManager.DeleteCookie(cookie);
                }
            }
        }
        #endregion

        #region Events
        private void WvSearchs_CoreWebView2InitializationCompleted(object sender, CoreWebView2InitializationCompletedEventArgs e)
        {
            SearchesCoreWebView2InitializationCompleted?.Invoke(sender, e);
        }

        private void WvMissions_CoreWebView2InitializationCompleted(object sender, CoreWebView2InitializationCompletedEventArgs e)
        {
            MissionCoreWebView2InitializationCompleted?.Invoke(sender, e);
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

        private void ChkMobile_Click(object sender, EventArgs e)
        {
            MobileChanged?.Invoke(sender, e);
        }

        private void btnForce_Click(object sender, EventArgs e)
        {
            ForceClicked?.Invoke(this, EventArgs.Empty);
        }
        #endregion
    }
}
