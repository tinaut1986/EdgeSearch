using EdgeSearch.src.Models;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Utils.Common;

namespace EdgeSearch.src.Business
{
    public class WebViewSearchesController : IDisposable
    {
        #region Members
        private WebView2 _wvSearches;
        private Profile _profile;

        public event EventHandler<CoreWebView2InitializationCompletedEventArgs> CoreWebView2InitializationCompleted;
        public event EventHandler<CoreWebView2NavigationCompletedEventArgs> NavigationCompleted;
        #endregion

        #region Constructors
        public WebViewSearchesController(Profile profile)
        {
            _profile = profile;
        }

        public void Dispose()
        {
            FinalizeEvents();
        }

        /// <summary>
        /// Deletes cache files that accumulate in the user profile.
        /// </summary>
        /// <remarks>
        /// This method targets specific cache folders within the WebView2 user data directory.
        /// It attempts to delete individual files rather than entire directories to maintain
        /// folder structure and permissions.
        /// </remarks>
        public void DeleteOldCache()
        {
            string[] cachePaths = new string[]
            {
                Path.Combine(_profile.Path, "EBWebView", "Default", "Cache"),
                Path.Combine(_profile.Path, "EBWebView", "Default", "Code Cache")

            };
            foreach (var path in cachePaths)
            {
                TryDeleteFiles(path);
            }
        }

        /// <summary>
        /// Attempts to delete all files within a specified directory and its subdirectories.
        /// </summary>
        /// <param name="path">The path to the directory containing files to delete.</param>
        /// <remarks>
        /// This method catches and ignores exceptions for individual file deletions,
        /// allowing the process to continue even if some files cannot be deleted.
        /// Consider logging exceptions for debugging purposes.
        /// </remarks>
        private void TryDeleteFiles(string path)
        {
            if (!Directory.Exists(path))
                return; // Exit if the directory doesn't exist

            foreach (var file in LibFileSystem.GetEntries(path, LibFileSystem.EntryType.Files, true))
            {
                try
                {
                    File.Delete(file);
                }
                catch (Exception ex)
                {
                    // Consider logging the exception for debugging
                    // Logger.LogWarning($"Failed to delete file: {file}. Error: {ex.Message}");
                }
            }
        }

        /// <summary>
        /// Function to simulate random horizontal scroll
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task SimulateHorizontalScrollAsync(CancellationToken cancellationToken)
        {
            Random random = new Random();

            while (!cancellationToken.IsCancellationRequested)
            {
                // Generate random delay (e.g., between 10 to 25 seconds)
                int delay = random.Next(10000, 25000);

                Console.WriteLine($"Waiting {delay / 1000} secs to scroll.");
                try
                {
                    // Wait for the delay before scrolling
                    await Task.Delay(delay, cancellationToken);
                }
                catch (OperationCanceledException)
                {
                    Console.WriteLine("Delay task was canceled.");
                    return;
                }

                for (int i = 0; i < random.Next(1, 10); i++)
                {
                    // Generate random scroll distance (e.g., between -800 and 800 pixels)
                    int scrollAmount = random.Next(-800, 801);
                    Console.WriteLine($"Scroll will be of {scrollAmount} amount of pixels");

                    // JavaScript to scroll the page horizontally
                    string script = $"window.scrollBy({{top: {scrollAmount}, left: 0, behavior: 'smooth'}});";

                    try
                    {
                        // Execute the script in the WebView
                        await _wvSearches.ExecuteScriptAsync(script);
                        Console.WriteLine($"Scrolling {scrollAmount} amount of pixels");

                        // Wait a short time before the next scroll
                        await Task.Delay(random.Next(100, 2000), cancellationToken);
                    }
                    catch (OperationCanceledException)
                    {
                        // Stop execution if cancellation is requested
                        return;
                    }
                    catch (Exception ex)
                    {
                        // Handle errors (e.g., WebView not ready or script execution failed)
                        Console.WriteLine($"Error executing script: {ex.Message}");
                    }
                }
            }
        }

        public void InitializeWebView(WebView2 webView2)
        {
            _wvSearches = webView2;
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
            CoreWebView2InitializationCompleted?.Invoke(sender, e);
        }

        private void wvSearches_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            NavigationCompleted?.Invoke(sender, e);
        }

        #endregion
    }
}
