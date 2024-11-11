using EdgeSearch.src.Common;
using EdgeSearch.src.Models;
using EdgeSearch.src.Properties;
using EdgeSearch.src.Utils;
using Microsoft.Web.WebView2.Core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utils.Extensions;

namespace EdgeSearch.UI
{
    public partial class MainForm : Form
    {
        #region Members
        private Profile _profile;

        public event EventHandler PlayClicked;
        public event EventHandler FullPlayClicked;
        public event EventHandler ForceClicked;
        public event EventHandler ResetClicked;
        public event EventHandler PlaySearchesClicked;
        public event EventHandler PlayRewardsClicked;
        public event EventHandler NextSearchClicked;
        public event EventHandler PreferencesClciked;
        public event EventHandler MobileChanged;
        public event EventHandler<CoreWebView2InitializationCompletedEventArgs> SearchesCoreWebView2InitializationCompleted;
        public event EventHandler<CoreWebView2InitializationCompletedEventArgs> RewardsCoreWebView2InitializationCompleted;
        public event EventHandler<CoreWebView2NewWindowRequestedEventArgs> RewardsNewWindowRequested;
        public event EventHandler<CoreWebView2NavigationCompletedEventArgs> SearchesNavigationCompleted;

        #endregion

        #region Constructors & destructor
        public MainForm(Profile profile)
        {
            InitializeComponent();

            _profile = profile;

            FixButtons();

            InitializeEvents();

            this.Text = $"Edge Search - {_profile.Name}";

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

        public async Task SetSearchBoxText(string text)
        {
            if (text == null)
                return;

            Random random = new Random();
            for (int i = 0; i <= text.Length; i++)
            {
                string partialText = text.Substring(0, i);
                string script = @"
                    (function() {
                        var searchBox = document.getElementById('sb_form_q');
                        if (searchBox) {
                            searchBox.value = '" + partialText + @"';
                            return true;
                        }
                        return false;
                    })();
                ";

                var result = await wvSearches.ExecuteScriptAsync(script);
                if (result != "true")
                {
                    Console.WriteLine("Search box not found.");
                    return;
                }

                // Simulates a random delay between 7 and 80 milliseconds
                await Task.Delay(random.Next(7, 80));
            }

            Console.WriteLine("Search box text set successfully.");
            await Task.Delay(random.Next(100, 150));
            await SimulateEnterInSearchBox();
        }

        private async Task SimulateEnterInSearchBox()
        {
            string script = @"
                (function() {
                    var searchBox = document.getElementById('sb_form_q');
                    if (searchBox) {
                        var event = new KeyboardEvent('keydown', {
                            'key': 'Enter',
                            'code': 'Enter',
                            'which': 13,
                            'keyCode': 13,
                            'bubbles': true,
                            'cancelable': true
                        });
                        searchBox.dispatchEvent(event);

                        // Simular el evento 'submit' del formulario
                        var form = searchBox.form;
                        if (form) {
                            var submitEvent = new Event('submit', {
                                'bubbles': true,
                                'cancelable': true
                            });
                            form.dispatchEvent(submitEvent);
                        }
                        return true;
                    }
                    return false;
                })();
            ";

            var result = await wvSearches.ExecuteScriptAsync(script);
            if (result == "true")
                Console.WriteLine("Search initiated successfully.");
            else
                Console.WriteLine("Failed to initiate the search.");
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
            btnSearch.FitImage();
            btnNext.FitImage();
        }

        public void BindFields()
        {
            txtURL.DataBindings.Clear();
            txtURL.DataBindings.Add(nameof(txtURL.Text), _profile.Search, nameof(_profile.Search.URL));

            cbNextSearch.DataBindings.Clear();
            cbNextSearch.DataBindings.Add(nameof(cbNextSearch.Text), _profile.Search, nameof(_profile.Search.NextSearch));

            chkMobile.DataBindings.Clear();
            chkMobile.DataBindings.Add(nameof(chkMobile.Checked), _profile.Search, nameof(_profile.Search.IsMobile));
        }

        public void AddHistoricSearch(string search)
        {
            if (search == null)
                return;

            cbNextSearch.Items.Insert(0, search);
        }

        /// <summary>
        /// Initializes all event subscriptions for the form.
        /// </summary>
        private void InitializeEvents()
        {
            // WebView2 initialization events
            wvSearches.CoreWebView2InitializationCompleted += WvSearches_CoreWebView2InitializationCompleted;
            wvRewards.CoreWebView2InitializationCompleted += WvRewards_CoreWebView2InitializationCompleted;

            // Menu item events
            var menuItems = new (ToolStripMenuItem item, EventHandler handler)[]
            {
                (tsmiPlayRewards, TsmiPlayRewards_Click),
                (tsmiPlaySearches, TsmiPlaySearches_Click),
                (tsmiPreferences, TsmiPreferences_Click),
                (tsmiPlay, TsmiPlay_Click),
                (tsmiReset, TsmiReset_Click)
            };

            foreach (var (item, handler) in menuItems)
                item.Click += handler;

            // Button events
            var buttons = new (Button button, EventHandler handler)[]
            {
                (btnPlay, btnPlay_Click),
                (btnSearch, btnForce_Click),
                (btnNext, btnNext_Click)
            };

            foreach (var (button, handler) in buttons)
                button.Click += handler;

            // Checkbox event
            chkMobile.Click += ChkMobile_Click;
        }

        /// <summary>
        /// Removes all event subscriptions for the form.
        /// This is important for proper cleanup and to prevent memory leaks.
        /// </summary>
        private void FinalizeEvents()
        {
            // WebView2 initialization events
            wvSearches.CoreWebView2InitializationCompleted -= WvSearches_CoreWebView2InitializationCompleted;
            wvRewards.CoreWebView2InitializationCompleted -= WvRewards_CoreWebView2InitializationCompleted;

            // Menu item events
            var menuItems = new (ToolStripMenuItem item, EventHandler handler)[]
            {
                (tsmiPlayRewards, TsmiPlayRewards_Click),
                (tsmiPlaySearches, TsmiPlaySearches_Click),
                (tsmiPreferences, TsmiPreferences_Click),
                (tsmiPlay, TsmiPlay_Click),
                (tsmiReset, TsmiReset_Click)
            };

            foreach (var (item, handler) in menuItems)
                item.Click -= handler;

            // Button events
            var buttons = new (Button button, EventHandler handler)[]
            {
                (btnPlay, btnPlay_Click),
                (btnSearch, btnForce_Click),
                (btnNext, btnNext_Click)
            };

            foreach (var (button, handler) in buttons)
                button.Click -= handler;

            // Checkbox event
            chkMobile.Click -= ChkMobile_Click;
        }

        public void SetUserAgent(string userAgent)
        {
            if (wvSearches.CoreWebView2?.Settings != null)
                wvSearches.CoreWebView2.Settings.UserAgent = userAgent;
        }

        public async Task EnsureCoreWebView2Async()
        {
            // Crea el entorno de WebView2 con la carpeta de datos especificada
            var env = await CoreWebView2Environment.CreateAsync(null, _profile.Path);

            await wvSearches.EnsureCoreWebView2Async(env);
            await wvRewards.EnsureCoreWebView2Async(env);

            wvRewards.CoreWebView2.NewWindowRequested += Rewards_CoreWebView2_NewWindowRequested;
            wvSearches.NavigationCompleted += wvSearches_NavigationCompleted;
        }

        public async Task OpenSearchesURL(Uri url)
        {
            if (wvSearches.Source != url)
                wvSearches.Source = url;

            await ReloadSearchsWeb();
        }

        public void RefreshSearchesURL()
        {
            _profile.Search.URL = wvSearches.Source;
        }

        public async Task SetRewardsURL(Uri url)
        {
            if (wvRewards.Source != url)
                wvRewards.Source = url;
            else
                await ReloadRewardsWeb();
        }

        public async void OpenRewards()
        {
            if (_profile.Search.RewardsPlayed)
                return;

            _profile.Search.RewardsPlayed = true;

            SetRewardsProgressBarState(true);

            // Definir la clase CSS que se va a usar
            string className = "mee-icon-AddMedium";
            string excludeClassName = "exclusiveLockedPts";


            while (true)
            {
                // Definir el script de JavaScript para ejecutar en la página usando string.Format
                string script = string.Format(@"
                    (function() {{
                        // Obtener una referencia a los botones por su clase CSS
                        var buttons = document.getElementsByClassName('{0}');

                        // Filtrar los botones que no tengan la clase 'exclusiveLockedPts'
                        var validButtons = Array.prototype.filter.call(buttons, function(button) {{
                            return !button.classList.contains('{1}');
                        }});

                        // Verificar si hay elementos con esa clase filtrados
                        if (validButtons.length > 0) {{
                            // Mostrar en la consola el número de elementos válidos encontrados
                            console.log('Elementos válidos encontrados con la clase {0}: ' + validButtons.length);

                            // Simular el clic en el primer botón válido encontrado
                            validButtons[0].click();

                            // Esperar 5 segundos antes de recargar
                            setTimeout(function() {{
                                // Refrescar la página después de que el bucle haya terminado
                                location.reload();
                            }}, 5000);

                            // Guardar el resultado en window para accederlo más tarde
                            window.scriptResult = true;
                        }} else {{
                            console.log('No se encontraron elementos válidos con la clase {0}');
                            // Guardar el resultado en window para accederlo más tarde
                            window.scriptResult = false;
                        }}
                    }})();
                ", className, excludeClassName);

                // Ejecutar el script
                await wvRewards.ExecuteScriptAsync(script);

                // Esperar un breve momento para asegurarse de que el script se ejecuta
                await Task.Delay(100);

                // Recuperar el resultado almacenado en window.scriptResult
                var result = await wvRewards.ExecuteScriptAsync("window.scriptResult");

                // Verificar el resultado y salir si ya no quedan más elementos
                if (result == null || result.ToString().ToLower() != "true")
                {
                    Console.WriteLine("No quedan más botones para pulsar.");
                    break;
                }

                await Task.Delay(6000); // Espera 6 segundos antes de volver a ejecutar la función
            }

            _profile.Search.RewardsPlayed = false;
            SetRewardsProgressBarState(false);
        }

        public void UpdateInterface()
        {
            if (!_profile.Search.IsPlaying)
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

            txtURL.Text = wvSearches.Source.AbsoluteUri;

            UpdateProgressBarSearches(_profile);

            UpdateProgressBarRewards(_profile.Search);

            UpdateResumeLabels();
        }

        private void UpdateResumeLabels()
        {
            string pcSearches = $"PC: {_profile.Search.DesktopSearchesCount} (x{_profile.Preferences.DesktopPointsPersearch})";
            string pcPoints = $"Points: {_profile.DesktopCurrentPoints}/{_profile.Preferences.DesktopTotalPoints}";
            lblPCSearches.Text = $"{pcSearches} | {pcPoints}";

            string mobileSearches = $"Mobile: {_profile.Search.MobileSearchesCount} (x{_profile.Preferences.MobilePointsPersearch})";
            string mobilePoints = $"Points: {_profile.MobileCurrentPoints}/{_profile.Preferences.MobileTotalPoints}";
            lblMobileSearches.Text = $"{mobileSearches} | {mobilePoints}";

            string refreshRange = $"Refresh range (s): {_profile.Preferences.MinWait}/{_profile.Preferences.MaxWait}";
            string streaks = $"Streaks: {_profile.Preferences.MinStreakAmount}/{_profile.Preferences.MaxStreakAmount}";
            string streaksDelay = $"Streak delay (s): {_profile.Preferences.MinStreakDelay}/{_profile.Preferences.MaxStreakDelay}";
            lblRefreshRange.Text = $"{refreshRange} | {streaks} | {streaksDelay}";

            SetLabelFont();
            
            FixLabelsWidth();
        }

        private void FixLabelsWidth()
        {
            FixLabelWitdh(lblPCSearches);
            FixLabelWitdh(lblMobileSearches);
            FixLabelWitdh(lblRefreshRange);
        }

        private void SetLabelFont()
        {
            if (_profile.Search.IsMobile)
            {
                lblMobileSearches.Font = new Font(lblMobileSearches.Font, FontStyle.Bold);
                lblPCSearches.Font = new Font(lblMobileSearches.Font, FontStyle.Regular);
            }
            else
            {
                lblMobileSearches.Font = new Font(lblMobileSearches.Font, FontStyle.Regular);
                lblPCSearches.Font = new Font(lblMobileSearches.Font, FontStyle.Bold);
            }
        }

        public void UpdateProgressBarRewards(Search search)
        {
            pbRewards.Text = search.RewardsString;
        }

        public void UpdateProgressBarSearches(Profile profile)
        {
            DateTime now = DateTime.Now;
            DateTime streakTime = (profile.Search.StreakTime ?? now);

            string streakCount = $"{profile.Search.StreakCount}/{profile.Search.StreakAmount}";
            string streakSeconds = $"{Convert.ToInt32((now - streakTime).TotalSeconds)}/{profile.Search.StreakDelay} sec";
            string searchsSeconds = $"{profile.Search.ElapsedSeconds}/{profile.Search.SecondsToWait} sec";

            UpdateProgressBar(profile, streakCount, streakSeconds, searchsSeconds);
        }

        private void UpdateProgressBar(Profile profile, string streakCount, string streakSeconds, string searchsSeconds)
        {
            string seconds = searchsSeconds;
            if (profile.Search.StreakTime != null)
                seconds = streakSeconds;

            pbSearches.Text = $"Searches: {streakCount} ({seconds}) | Expected time: {ExecutionTimeCalculator.GetTotalExpectedTime(profile)}";

            pbSearches.Maximum = profile.SearchesProgressBarMax;
            pbSearches.Value = profile.SearchesProgressBarValue;
            
            if (profile.Search.IsMobile)
            {
                if (profile.Search.StreakTime == null)
                    UpdateProgressBarColors(profile.Preferences.mobileNormalProgressBarColors);
                else
                    UpdateProgressBarColors(profile.Preferences.mobileReverseProgressBarColors);
            }
            else // profile.Search.IsDesktop
            {
                if (profile.Search.StreakTime == null)
                    UpdateProgressBarColors(profile.Preferences.desktopNormalProgressBarColors);
                else
                    UpdateProgressBarColors(profile.Preferences.desktopReverseProgressBarColors);
            }
        }

        public void FixLabelWitdh(Label label)
        {
            // Calculate the needed width
            using (Graphics g = label.CreateGraphics())
            {
                SizeF size = g.MeasureString(label.Text, label.Font);
                label.Width = (int)Math.Ceiling(size.Width);
            }
        }

        private void UpdateProgressBarColors(ProgressBarColors colors)
        {
            pbSearches.PaintedColor = colors.FilledColor;
            pbSearches.ForeColor = colors.TextColor;
            pbSearches.PaintedForeColor = colors.FilledTextColor;
        }

        public async Task ReloadSearchsWeb()
        {
            if ((wvSearches.Source?.ToString() ?? "about:blank") != "about:blank")
            {
                while ((wvSearches?.CoreWebView2?.Source ?? "about:blank") == "about:blank" || wvSearches.Source.ToString() != Uri.UnescapeDataString(wvSearches.CoreWebView2.Source))
                    await Task.Delay(500);

                wvSearches.Reload();
            }
        }

        public async Task ReloadRewardsWeb()
        {
            if ((wvRewards.Source?.ToString() ?? "about:blank") != "about:blank")
            {
                while ((wvRewards?.CoreWebView2?.Source ?? "about:blank") == "about:blank" || wvRewards.Source.ToString() != Uri.UnescapeDataString(wvRewards.CoreWebView2.Source))
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

        public void SetRewardsProgressBarState(bool play)
        {
            if (play)
                pbRewards.Style = ProgressBarStyle.Marquee;
            else
                pbRewards.Style = ProgressBarStyle.Continuous;
        }

        /// <summary>
        /// Extracts the current points, maximum points, and points per search 
        /// from the WebView2 document based on the specified search type.
        /// </summary>
        /// <param name="searchType">The type of search to filter the points.</param>
        /// <returns>A tuple containing current points, maximum points, and points per search.</returns>
        public async Task<(int currentPoints, int maxPoints, int pointsPerSearch)> ExtractPoints(string searchType)
        {
            // JavaScript code to execute in the context of the WebView2
            string jsCode = $@"
                (function() {{
                    var result = {{}}; // Initialize an empty object to hold results
                    // Find all elements that contain point breakdown information
                    var pointElements = document.querySelectorAll('.pointsBreakdownCard');

                    // Iterate over each point element
                    pointElements.forEach(function(element) {{
                        var label = element.querySelector('a').innerText; // Get the label text
                        if (label.includes('{searchType}')) {{ // Check if it includes the specified search type
                            // Extract the points from the detail section
                            var pointsText = element.querySelector('.pointsDetail p.pointsDetail').innerText;
                            result.points = pointsText.trim(); // Store the trimmed points text

                            // Extract points per search from the description text
                            var descriptionText = element.querySelector('.description').innerText;
                            var match = descriptionText.match(/(\\d+)\\s+puntos?\\s+por\\s+búsqueda/); // Regex to find points per search
                            if (match) {{
                                result.pointsPerSearch = match[1]; // Store the matched points per search
                            }}
                        }}
                    }});

                    return JSON.stringify(result); // Return the result as a JSON string
                }})();";

            // Execute the JavaScript code and get the result as a JSON string
            string resultJson = await wvRewards.CoreWebView2.ExecuteScriptAsync(jsCode);

            resultJson = resultJson.Trim('"').Replace("\\\"", "\""); // Clean up the JSON string

            // Deserialize the JSON result into a dictionary for easy access
            var resultObj = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, string>>(resultJson);

            // Check if we have valid data in the result object
            if (resultObj != null && resultObj.ContainsKey("points") && resultObj.ContainsKey("pointsPerSearch"))
            {
                string[] pointsArray = resultObj["points"].Split('/'); // Split current and max points
                if (pointsArray.Length == 2)
                {
                    int currentPoints = int.Parse(pointsArray[0].Trim()); // Parse current points
                    int maxPoints = int.Parse(pointsArray[1].Trim()); // Parse maximum points
                    int pointsPerSearch = int.Parse(resultObj["pointsPerSearch"]); // Parse points per search

                    return (currentPoints, maxPoints, pointsPerSearch); // Return the extracted values as a tuple
                }
            }

            // If no values are found or there is an error, return 0, 0, 0
            return (0, 0, 0);
        }

        /// <summary>
        /// Waits for the specified text to be visible in the WebView2 document.
        /// </summary>
        /// <param name="textToFind">The text to search for in the document.</param>
        /// <param name="timeoutMilliseconds">Optional timeout in milliseconds. If specified, the method will stop waiting after this duration.</param>
        /// <returns>True if the text is found, otherwise false.</returns>
        public async Task<bool> WaitForTextToBeVisible(string textToFind, int? timeoutMilliseconds = null)
        {
            // Wait until the WebView2 page is loaded and is not "about:blank"
            while ((wvRewards?.CoreWebView2?.Source ?? "about:blank") == "about:blank")
                await Task.Delay(1000); // Delay for 1 second before checking again

            // Maximum wait time
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

            // If a timeout is specified, configure the CancellationToken to cancel after that duration
            if (timeoutMilliseconds.HasValue)
                cancellationTokenSource.CancelAfter(timeoutMilliseconds.Value);

            // Loop to check if the specified text is present in the document
            while (!cancellationTokenSource.IsCancellationRequested)
            {
                // JavaScript code that checks if the text is present in the body of the document
                string jsCode = $@"
                    (function() {{
                        return document.body.innerText.includes('{textToFind}');
                    }})();";

                // Execute the script and get the result as a string ("true" or "false")
                string result = await wvRewards.CoreWebView2?.ExecuteScriptAsync(jsCode);

                if (result == "true")
                    return true; // Return true if the text is found

                // Wait before checking again
                await Task.Delay(1000); // Delay for 1 second before rechecking
            }

            // If the text was not found within the timeout period (if specified), return false
            return false;
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

        private void wvSearches_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            SearchesNavigationCompleted?.Invoke(sender, e);
        }

        private void TsmiPlayRewards_Click(object sender, EventArgs e)
        {
            PlayRewardsClicked?.Invoke(sender, e);
        }

        private void TsmiPlaySearches_Click(object sender, EventArgs e)
        {
            PlaySearchesClicked?.Invoke(sender, e);
        }

        private void TsmiPreferences_Click(object sender, EventArgs e)
        {
            PreferencesClciked?.Invoke(sender, e);
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            SetSearchBoxText("C# programming");
        }
        #endregion
    }
}
