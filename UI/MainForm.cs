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
        public event EventHandler FullPlayClicked;
        public event EventHandler ForceClicked;
        public event EventHandler OpenClicked;
        public event EventHandler ResetClicked;
        public event EventHandler OpenRewardsClicked;
        public event EventHandler NextSearchClicked;
        public event EventHandler MobileChanged;
        public event EventHandler<CoreWebView2InitializationCompletedEventArgs> SearchesCoreWebView2InitializationCompleted;
        public event EventHandler<CoreWebView2InitializationCompletedEventArgs> RewardsCoreWebView2InitializationCompleted;
        public event EventHandler<CoreWebView2InitializationCompletedEventArgs> AmbassadorsCoreWebView2InitializationCompleted;
        public event EventHandler<CoreWebView2NewWindowRequestedEventArgs> RewardsNewWindowRequested;
        public event EventHandler<CoreWebView2NewWindowRequestedEventArgs> AmbassadorsNewWindowRequested;
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
            wvSearches.CoreWebView2InitializationCompleted += WvSearches_CoreWebView2InitializationCompleted;
            wvRewards.CoreWebView2InitializationCompleted += WvRewards_CoreWebView2InitializationCompleted;
            wvAmbassadors.CoreWebView2InitializationCompleted += WvAmbassadors_CoreWebView2InitializationCompleted;
            tsmiOpenRewards.Click += TsmiOpenRewards_Click;
            tsmiPlay.Click += TsmiPlay_Click;
            tsmiReset.Click += TsmiReset_Click;

            btnPlay.Click += btnPlay_Click;
            btnSearch.Click += btnForce_Click;
            btnNext.Click += btnNext_Click;
            chkMobile.Click += ChkMobile_Click;
            btnOpen.Click += btnOpen_Click;
            txtURL.KeyPress += txtURL_KeyPress;
        }

        private void FinalizeEvents()
        {
            wvSearches.CoreWebView2InitializationCompleted -= WvSearches_CoreWebView2InitializationCompleted;
            wvRewards.CoreWebView2InitializationCompleted -= WvRewards_CoreWebView2InitializationCompleted;
            wvAmbassadors.CoreWebView2InitializationCompleted -= WvAmbassadors_CoreWebView2InitializationCompleted;
            tsmiOpenRewards.Click -= TsmiOpenRewards_Click;
            tsmiPlay.Click -= TsmiPlay_Click;
            tsmiReset.Click -= TsmiReset_Click;

            btnPlay.Click -= btnPlay_Click;
            btnSearch.Click -= btnForce_Click;
            btnNext.Click -= btnNext_Click;
            chkMobile.Click -= ChkMobile_Click;
            btnOpen.Click -= btnOpen_Click;
            txtURL.KeyPress -= txtURL_KeyPress;
        }

        public void SetUserAgent(string userAgent)
        {
            if (wvSearches.CoreWebView2?.Settings != null)
                wvSearches.CoreWebView2.Settings.UserAgent = userAgent;
        }

        public async Task EnsureCoreWebView2Async()
        {
            await wvSearches.EnsureCoreWebView2Async(null);
            await wvRewards.EnsureCoreWebView2Async(null);
            await wvAmbassadors.EnsureCoreWebView2Async(null);

            wvRewards.CoreWebView2.NewWindowRequested += Rewards_CoreWebView2_NewWindowRequested;
            wvAmbassadors.CoreWebView2.NewWindowRequested += Ambassadors_CoreWebView2_NewWindowRequested;
        }

        private async void InitializeWebView()
        {
            //Controls.Add(wvSearchs);

            await wvSearches.EnsureCoreWebView2Async();
            await wvRewards.EnsureCoreWebView2Async();
            await wvAmbassadors.EnsureCoreWebView2Async();
        }

        public void SetSearchsURL(Uri url)
        {
            if (wvSearches.Source != url)
                wvSearches.Source = url;
            else
                ReloadSearchsWeb();
        }

        public void SetRewardsURL(Uri url)
        {
            if (wvRewards.Source != url)
                wvRewards.Source = url;
            else
                ReloadRewardsWeb();
        }

        public void SetAmbassadorsURL(Uri url)
        {
            if (wvAmbassadors.Source != url)
                wvAmbassadors.Source = url;
            else
                ReloadAmbassadorsWeb();
        }

        public async void OpenRewards()
        {
            // Definir la clase CSS que se va a usar
            string className = "mee-icon-AddMedium";

            while (true)
            {
                // Definir el script de JavaScript para ejecutar en la página usando string.Format
                string script = string.Format(@"
                    (function() {{
                        // Obtener una referencia a los botones por su clase CSS
                        var buttons = document.getElementsByClassName('{0}');

                        // Verificar si hay elementos con esa clase
                        if (buttons.length > 0) {{
                            // Mostrar en la consola el número de elementos encontrados
                            console.log('Elementos encontrados con la clase {0}: ' + buttons.length);

                            // Simular el clic en el primer botón encontrado
                            buttons[0].click();

                            // Esperar 5 segundos antes de recargar
                            setTimeout(function() {{
                                // Refrescar la página después de que el bucle haya terminado
                                location.reload();
                            }}, 5000);

                            // Guardar el resultado en window para accederlo más tarde
                            window.scriptResult = true;
                        }} else {{
                            console.log('No se encontraron elementos con la clase {0}');
                            // Guardar el resultado en window para accederlo más tarde
                            window.scriptResult = false;
                        }}
                    }})();
                ", className);

                // Ejecutar el script
                await wvRewards.ExecuteScriptAsync(script);

                // Esperar un breve momento para asegurarse de que el script se ejecuta
                await Task.Delay(100);

                // Recuperar el resultado almacenado en window.scriptResult
                var result = await wvRewards.ExecuteScriptAsync("window.scriptResult");

                // Verificar el resultado y volver a llamar a la función si es necesario
                if (result == null || result.ToString().ToLower() != "true")
                {
                    Console.WriteLine("No quedan más botones para pulsar.");
                    break;

                }
                await Task.Delay(6000); // Espera 6 segundos antes de volver a ejecutar la función
            }
        }

        public void UpdateInterface(Search search)
        {
            if (!search.IsPlaying)
            {
                btnPlay.Text = "Play";
                tsmiPlay.Text = "Play";
            }
            else
            {
                btnPlay.Text = "Stop";
                tsmiPlay.Text = "Stop";
            }

            btnOpen.Enabled = !search.IsPlaying;
            txtURL.ReadOnly = search.IsPlaying;
            txtURL.Text = wvSearches.Source.AbsoluteUri;

            lblProgress.Text = $"{search.ElapsedSeconds}/{search.SecondsToRefresh} segs";
        }

        public void ReloadSearchsWeb()
        {
            if (wvSearches.Source != null)
                wvSearches.Reload();
        }

        public void ReloadRewardsWeb()
        {
            if (wvRewards.Source != null)
                wvRewards.Reload();
        }

        public void ReloadAmbassadorsWeb()
        {
            if (wvAmbassadors.Source != null)
                wvAmbassadors.Reload();
        }

        public async Task DeleteSessionCookies()
        {
            if (wvSearches.CoreWebView2?.Settings != null)
            {
                foreach (CoreWebView2Cookie cookie in (await wvSearches.CoreWebView2.CookieManager.GetCookiesAsync(null)).ToList())
                {
                    if (cookie.IsSession)
                        wvSearches.CoreWebView2.CookieManager.DeleteCookie(cookie);
                }
            }
        }

        public void SetRewardProgressBar(ProgressBarStyle style)
        {
            pbRewards.Style = style;
        }
        #endregion

        #region Events
        private void WvSearches_CoreWebView2InitializationCompleted(object sender, CoreWebView2InitializationCompletedEventArgs e)
        {
            SearchesCoreWebView2InitializationCompleted?.Invoke(sender, e);
        }

        private void WvRewards_CoreWebView2InitializationCompleted(object sender, CoreWebView2InitializationCompletedEventArgs e)
        {
            RewardsCoreWebView2InitializationCompleted?.Invoke(sender, e);
        }

        private void WvAmbassadors_CoreWebView2InitializationCompleted(object sender, CoreWebView2InitializationCompletedEventArgs e)
        {
            AmbassadorsCoreWebView2InitializationCompleted?.Invoke(sender, e);
        }

        private void Rewards_CoreWebView2_NewWindowRequested(object sender, CoreWebView2NewWindowRequestedEventArgs e)
        {
            RewardsNewWindowRequested?.Invoke(sender, e);
        }

        private void Ambassadors_CoreWebView2_NewWindowRequested(object sender, CoreWebView2NewWindowRequestedEventArgs e)
        {
            AmbassadorsNewWindowRequested?.Invoke(sender, e);
        }

        private void TsmiOpenRewards_Click(object sender, EventArgs e)
        {
            OpenRewardsClicked?.Invoke(sender, e);
        }

        private void TsmiPlay_Click(object sender, EventArgs e)
        {
            FullPlayClicked?.Invoke(sender, e);
        }

        private void TsmiReset_Click(object sender, EventArgs e)
        {
            ResetClicked?.Invoke(sender, e);
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
