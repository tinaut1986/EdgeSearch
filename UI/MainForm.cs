using EdgeSearch.Common;
using EdgeSearch.Models;
using EdgeSearch.Properties;
using EdgeSearch.Utils;
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
        public event EventHandler PlaySearchesClicked;
        public event EventHandler PlayRewardsClicked;
        public event EventHandler NextSearchClicked;
        public event EventHandler MobileChanged;
        public event EventHandler PbSearchesMouseMove;
        public event EventHandler<CoreWebView2InitializationCompletedEventArgs> SearchesCoreWebView2InitializationCompleted;
        public event EventHandler<CoreWebView2InitializationCompletedEventArgs> RewardsCoreWebView2InitializationCompleted;
        public event EventHandler<CoreWebView2NewWindowRequestedEventArgs> RewardsNewWindowRequested;
        #endregion

        #region Constructors & destructor
        public MainForm()
        {
            InitializeComponent();

            FixButtons();

            InitializeWebView();

            InitializeEvents();

#if DEBUG
            Icon = Resources.EdgeSearch_dev;
#else
            Icon = Resources.EdgeSearch;
#endif
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


        public void SelectTab(TabType tabType)
        {
            tabControl1.SelectedTab = GetTabPage(tabType);
        }

        public void SelectTabAndReturn(TabType tabType)
        {
            TabPage selectedTab = tabControl1.SelectedTab;
            TabPage tabPage = GetTabPage(tabType);

            if (selectedTab == tabPage)
                return;

            SelectTab(tabType);
            tabControl1.SelectedTab = selectedTab;
        }

        public TabPage GetTabPage(TabType tabType)
        {
            switch (tabType)
            {
                case TabType.Searches:
                    return tpSearches;
                case TabType.Rewards:
                    return tpRewards;
                default:
                    throw new ArgumentOutOfRangeException(nameof(tabType), tabType, null);
            };
        }

        private void FixButtons()
        {
            btnPlay.FitImage();
            chkMobile.FitImage();
            btnOpen.FitImage();
            btnSearch.FitImage();
            btnNext.FitImage();
        }

        public void BindFields(Search search)
        {
            txtURL.DataBindings.Clear();
            txtURL.DataBindings.Add(nameof(txtURL.Text), search, nameof(search.URL));

            txtNextSearch.DataBindings.Clear();
            txtNextSearch.DataBindings.Add(nameof(txtNextSearch.Text), search, nameof(search.NextSearch));

            chkMobile.DataBindings.Clear();
            chkMobile.DataBindings.Add(nameof(chkMobile.Checked), search, nameof(search.IsMobile));

            txtLowerLimit.DataBindings.Clear();
            txtLowerLimit.DataBindings.Add(nameof(txtLowerLimit.Text), search.Preferences, nameof(search.Preferences.LowerLimit));

            txtUpperLimit.DataBindings.Clear();
            txtUpperLimit.DataBindings.Add(nameof(txtUpperLimit.Text), search.Preferences, nameof(search.Preferences.UpperLimit));

            txtSearches.DataBindings.Clear();
            txtSearches.DataBindings.Add(nameof(txtSearches.Text), search, nameof(search.SearchesCount));

            txtCurrentPoints.DataBindings.Clear();
            txtCurrentPoints.DataBindings.Add(nameof(txtCurrentPoints.Text), search, nameof(search.CurrentPoints));

            txtPointsLimit.DataBindings.Clear();
            txtPointsLimit.DataBindings.Add(nameof(txtPointsLimit.Text), search, nameof(search.PointsLimit));

            //pbSearches.DataBindings.Clear();
            //pbSearches.DataBindings.Add(nameof(pbSearches.Maximum), search, nameof(search.SearchesProgressBarMax), true);
            //pbSearches.DataBindings.Add(nameof(pbSearches.Value), search, nameof(search.SearchesProgressBarValue), true);

            lblRewardsPB.DataBindings.Clear();
            lblRewardsPB.DataBindings.Add(nameof(lblRewardsPB.Text), search, nameof(search.RewardsString));
        }

        private void InitializeEvents()
        {
            wvSearches.CoreWebView2InitializationCompleted += WvSearches_CoreWebView2InitializationCompleted;
            wvRewards.CoreWebView2InitializationCompleted += WvRewards_CoreWebView2InitializationCompleted;

            tsmiPlayRewards.Click += TsmiPlayRewards_Click;
            tsmiPlaySearches.Click += TsmiPlaySearches_Click;

            tsmiPlay.Click += TsmiPlay_Click;
            tsmiReset.Click += TsmiReset_Click;

            btnPlay.Click += btnPlay_Click;
            btnSearch.Click += btnForce_Click;
            btnNext.Click += btnNext_Click;
            chkMobile.Click += ChkMobile_Click;
            btnOpen.Click += btnOpen_Click;
            txtURL.KeyPress += txtURL_KeyPress;

            pbSearches.MouseMove += PbSearches_MouseMove;
        }

        private void FinalizeEvents()
        {
            wvSearches.CoreWebView2InitializationCompleted -= WvSearches_CoreWebView2InitializationCompleted;
            wvRewards.CoreWebView2InitializationCompleted -= WvRewards_CoreWebView2InitializationCompleted;
            tsmiPlayRewards.Click -= TsmiPlayRewards_Click;
            tsmiPlaySearches.Click -= TsmiPlaySearches_Click;

            tsmiPlay.Click -= TsmiPlay_Click;
            tsmiReset.Click -= TsmiReset_Click;

            btnPlay.Click -= btnPlay_Click;
            btnSearch.Click -= btnForce_Click;
            btnNext.Click -= btnNext_Click;
            chkMobile.Click -= ChkMobile_Click;
            btnOpen.Click -= btnOpen_Click;
            txtURL.KeyPress -= txtURL_KeyPress;

            pbSearches.MouseMove -= PbSearches_MouseMove;
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

            wvRewards.CoreWebView2.NewWindowRequested += Rewards_CoreWebView2_NewWindowRequested;
        }

        private async void InitializeWebView()
        {
            //Controls.Add(wvSearchs);

            await wvSearches.EnsureCoreWebView2Async();
            await wvRewards.EnsureCoreWebView2Async();
        }

        public async Task SetSearchsURL(Uri url)
        {
            if (wvSearches.Source != url)
                wvSearches.Source = url;

            await ReloadSearchsWeb();
        }

        public async Task SetRewardsURL(Uri url)
        {
            if (wvRewards.Source != url)
                wvRewards.Source = url;
            else
                await ReloadRewardsWeb();
        }

        public async void OpenRewards(Search search)
        {
            if (search.RewardsPlayed)
                return;

            search.RewardsPlayed = true;

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

                // Verificar el resultado y salir si ya no quedan mas elementos
                if (result == null || result.ToString().ToLower() != "true")
                {
                    Console.WriteLine("No quedan más botones para pulsar.");
                    break;

                }
                await Task.Delay(6000); // Espera 6 segundos antes de volver a ejecutar la función
            }

            search.RewardsPlayed = false;
        }

        public void UpdateInterface(Search search)
        {
            if (!search.IsPlaying)
            {
                btnPlay.Image = Resources.play;

                tsmiPlay.Text = "Play";
                tsmiPlay.Image = Resources.play;

                tsmiPlaySearches.Text = "Play searches";
                tsmiPlaySearches.Image = Resources.play;
            }
            else
            {
                btnPlay.Image = Resources.stop;

                tsmiPlay.Text = "Stop";
                tsmiPlay.Image = Resources.stop;

                tsmiPlaySearches.Text = "Stop searches";
                tsmiPlaySearches.Image = Resources.stop;
            }

            btnPlay.FitImage();

            btnOpen.Enabled = !search.IsPlaying;
            txtURL.ReadOnly = search.IsPlaying;
            txtURL.Text = wvSearches.Source.AbsoluteUri;

            DateTime now = DateTime.Now;
            DateTime strikeTime = (search.StrikeTime ?? now);

            string strikeCount = $"{search.StrikeCount}/{search.Preferences.StrikeAmount}";
            string strikeSeconds = $"{Convert.ToInt32((now - strikeTime).TotalSeconds)}/{search.Preferences.StrikeDelay} sec";
            string searchsSeconds = $"{search.ElapsedSeconds}/{search.SecondsToRefresh} sec";

            pbSearches.Text = $"{strikeCount} ({strikeSeconds}) - {searchsSeconds}";

            pbSearches.Maximum = search.SearchesProgressBarMax;
            pbSearches.Value = search.SearchesProgressBarValue;
            pbSearches.PaintedColor = search.SearchesProgressBarColor;
        }

        public async Task ReloadSearchsWeb()
        {
            if ((wvSearches.Source?.ToString() ?? "about:blank") != "about:blank")
            {
                while ((wvSearches?.CoreWebView2?.Source ?? "about:blank") == "about:blank" || wvSearches.Source.ToString().Replace(" ", "%20") != wvSearches.CoreWebView2.Source)
                    await Task.Delay(500);

                wvSearches.Reload();
            }
        }

        public async Task ReloadRewardsWeb()
        {
            if ((wvRewards.Source?.ToString() ?? "about:blank") != "about:blank")
            {
                while ((wvRewards?.CoreWebView2?.Source ?? "about:blank") == "about:blank" || wvRewards.Source.ToString().Replace(" ", "%20") != wvRewards.CoreWebView2.Source)
                    await Task.Delay(500);

                wvRewards.Reload();
            }
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

        public void SetExecutionExpectedTime(TimeSpan minTime, TimeSpan maxTime)
        {
            toolTip1.SetToolTip(pbSearches, $"Expected time: {minTime:hh\\:mm\\:ss} - {maxTime:hh\\:mm\\:ss}");
        }

        public async Task<(int currentPoints, int maxPoints)> ExtractPoints(string searchType)
        {
            string jsCode = $@"
                (function() {{
                    var result = '';
                    // Buscar el contenedor que contiene el texto específico
                    var pointElements = document.querySelectorAll('.pointsBreakdownCard');
            
                    pointElements.forEach(function(element) {{
                        var label = element.querySelector('a').innerText;  // Obtener el texto del label (por ejemplo, 'Búsqueda en PC')
                        if (label.includes('{searchType}')) {{
                            // Si coincide con el tipo de búsqueda, extraer los puntos
                            var pointsText = element.querySelector('.pointsDetail p.pointsDetail').innerText;
                            result = pointsText.trim();  // Guardar los puntos en el resultado
                        }}
                    }});

                    return result;  // Devolver los puntos (ejemplo: '12 / 90')
                }})();";

            string result = await wvRewards.CoreWebView2.ExecuteScriptAsync(jsCode);

            // Limpiar las comillas del resultado
            result = result.Replace("\"", "").Trim();

            // Verificar si el resultado contiene valores
            if (!string.IsNullOrEmpty(result))
            {
                // Separar los puntos (ejemplo: '12 / 90' -> [12, 90])
                string[] pointsArray = result.Split('/');
                if (pointsArray.Length == 2)
                {
                    // Convertir los valores a enteros
                    int currentPoints = int.Parse(pointsArray[0].Trim());
                    int maxPoints = int.Parse(pointsArray[1].Trim());

                    // Devolver los dos valores
                    return (currentPoints, maxPoints);
                }
            }

            // Si no se encuentran valores o hay un error, devolver 0, 0
            return (0, 0);
        }

        public async Task WaitForTextToBeVisible(string textToFind)
        {
            // Esperar hasta que la página en el WebView2 esté cargada y no sea "about:blank"
            while ((wvRewards?.CoreWebView2?.Source ?? "about:blank") == "about:blank")
                await Task.Delay(1000);

            // Bucle para comprobar si el texto está presente
            bool textFound = false;
            while (!textFound)
            {
                // Código JavaScript que comprueba si el texto está presente
                string jsCode = $@"
                    (function() {{
                        return document.body.innerText.includes('{textToFind}');
                    }})();";

                // Ejecutar el script y obtener el resultado como string ("true" o "false")
                string result = await wvRewards.CoreWebView2.ExecuteScriptAsync(jsCode);

                if (result == "true")
                    textFound = true;
                else
                    await Task.Delay(1000);
            }
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

        private void Rewards_CoreWebView2_NewWindowRequested(object sender, CoreWebView2NewWindowRequestedEventArgs e)
        {
            RewardsNewWindowRequested?.Invoke(sender, e);
        }

        private void TsmiPlayRewards_Click(object sender, EventArgs e)
        {
            PlayRewardsClicked?.Invoke(sender, e);
        }

        private void TsmiPlaySearches_Click(object sender, EventArgs e)
        {
            PlaySearchesClicked?.Invoke(sender, e);
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
            FullPlayClicked?.Invoke(sender, e);
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

        private void PbSearches_MouseMove(object sender, MouseEventArgs e)
        {
            PbSearchesMouseMove?.Invoke(sender, e);
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
