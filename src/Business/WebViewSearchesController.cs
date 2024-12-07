using EdgeSearch.src.Models;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdgeSearch.src.Business
{
    public class WebViewSearchesController
    {
        #region Members
        private WebView2 _wvSearches;
        private Profile _profile;

        public event EventHandler<CoreWebView2InitializationCompletedEventArgs> SearchesCoreWebView2InitializationCompleted;
        public event EventHandler<CoreWebView2NavigationCompletedEventArgs> SearchesNavigationCompleted;
        #endregion

        #region Constructors
        public WebViewSearchesController(Profile profile)
        {
            _profile = profile;
        }
        #endregion

        #region Methods
        public void InitializeWebView(WebView2 wvSearches)
        {
            _wvSearches = wvSearches;
        }

        public void InitializeEvents()
        {
            _wvSearches.CoreWebView2InitializationCompleted += WvSearches_CoreWebView2InitializationCompleted;
        }

        public void FinalizeEvents()
        {
            _wvSearches.CoreWebView2InitializationCompleted -= WvSearches_CoreWebView2InitializationCompleted;
        }

        public string GetAbsoluteUri()
        {
            return _wvSearches.Source.AbsoluteUri;
        }

        public async Task EnsureCoreWebView2Async()
        {
            // Crea el entorno de WebView2 con la carpeta de datos especificada
            var env = await CoreWebView2Environment.CreateAsync(null, _profile.Path);

            await _wvSearches.EnsureCoreWebView2Async(env);

            _wvSearches.NavigationCompleted += wvSearches_NavigationCompleted;
        }

        public async Task OpenSearchesURL(Uri url)
        {
            if (_wvSearches.Source != url)
                _wvSearches.Source = url;

            await ReloadSearchsWeb();
        }

        public async Task ReloadSearchsWeb()
        {
            if ((_wvSearches.Source?.ToString() ?? "about:blank") != "about:blank")
            {
                while ((_wvSearches?.CoreWebView2?.Source ?? "about:blank") == "about:blank" || _wvSearches.Source.ToString() != Uri.UnescapeDataString(_wvSearches.CoreWebView2.Source))
                    await Task.Delay(500);

                _wvSearches.Reload();
            }
        }

        public void SetUserAgent(string userAgent)
        {
            if (_wvSearches.CoreWebView2?.Settings != null)
                _wvSearches.CoreWebView2.Settings.UserAgent = userAgent;
        }

        /// <summary>
        /// Attempts to set the search box text, falling back to direct URL navigation if the search box is not found.
        /// </summary>
        /// <param name="text">The text to be set in the search box.</param>
        /// <returns>A boolean indicating whether the search box was found and text was set successfully.</returns>
        public async Task<bool> SetSearchBoxText(string text)
        {
            if (string.IsNullOrEmpty(text))
                return false;

            DateTime startTime = DateTime.Now;
            bool searchBoxFound = false;

            // Try to find the search box control for 1 second
            while ((DateTime.Now - startTime).TotalSeconds < 1 && !searchBoxFound)
            {
                string script = @"
                    (function() {
                        var searchBox = document.getElementById('sb_form_q');
                        return searchBox ? true : false;
                    })();
                ";

                var result = await _wvSearches.ExecuteScriptAsync(script);
                if (result == "true")
                    searchBoxFound = true;
                else
                    await Task.Delay(50); // Short delay before retrying
            }

            if (!searchBoxFound)
            {
                Console.WriteLine("Search box control not found within 1 second.");
                return false;
            }

            // If the control is found, proceed with entering the text
            Random random = new Random();
            for (int i = 0; i <= text.Length; i++)
            {
                string partialText = text.Substring(0, i);
                string updateScript = @"
                    (function() {
                        var searchBox = document.getElementById('sb_form_q');
                        if (searchBox) {
                            searchBox.value = '" + partialText + @"';
                            return true;
                        }
                        return false;
                    })();
                ";

                var updateResult = await _wvSearches.ExecuteScriptAsync(updateScript);
                if (updateResult != "true")
                {
                    Console.WriteLine("Error updating the text in the search box control.");
                    return false;
                }

                await Task.Delay(random.Next(7, 80));
            }

            Console.WriteLine("Search box text set successfully.");
            await Task.Delay(random.Next(100, 150));
            await SimulateEnterInSearchBox();
            return true;
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

            var result = await _wvSearches.ExecuteScriptAsync(script);
            if (result == "true")
                Console.WriteLine("Search initiated successfully.");
            else
                Console.WriteLine("Failed to initiate the search.");
        }

        public async Task DeleteSessionCookies()
        {
            if (_wvSearches.CoreWebView2?.Settings != null)
            {
                foreach (CoreWebView2Cookie cookie in (await _wvSearches.CoreWebView2.CookieManager.GetCookiesAsync(null)).ToList())
                {
                    if (cookie.IsSession)
                        _wvSearches.CoreWebView2.CookieManager.DeleteCookie(cookie);
                }
            }
        }

        #endregion

        #region Events
        private void WvSearches_CoreWebView2InitializationCompleted(object sender, CoreWebView2InitializationCompletedEventArgs e)
        {
            SearchesCoreWebView2InitializationCompleted?.Invoke(sender, e);
        }

        private void wvSearches_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            SearchesNavigationCompleted?.Invoke(sender, e);
        }

        #endregion
    }
}
