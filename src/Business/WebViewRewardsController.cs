using EdgeSearch.src.Models;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EdgeSearch.src.Business
{
    public class WebViewRewardsController : IDisposable
    {
        #region Members
        private WebView2 _wvRewards;
        private Profile _profile;

        public event EventHandler<CoreWebView2InitializationCompletedEventArgs> CoreWebView2InitializationCompleted;
        public event EventHandler<CoreWebView2NavigationCompletedEventArgs> NavigationCompleted;
        public event EventHandler<CoreWebView2NewWindowRequestedEventArgs> NewWindowRequested;
        #endregion

        #region Constructors
        public WebViewRewardsController(Profile profile)
        {
            _profile = profile;
        }

        public void Dispose()
        {
            FinalizeEvents();
        }
        #endregion

        #region Methods
        public void InitializeWebView(WebView2 webView2)
        {
            _wvRewards = webView2;
        }

        public void InitializeEvents()
        {
            _wvRewards.CoreWebView2InitializationCompleted += WebView_CoreWebView2InitializationCompleted;
        }

        public void FinalizeEvents()
        {
            _wvRewards.CoreWebView2InitializationCompleted -= WebView_CoreWebView2InitializationCompleted;
        }

        public async void OpenRewards()
        {
            if (_profile.Search.RewardsPlayed)
                return;

            _profile.Search.RewardsPlayed = true;

            // Definir las clases CSS que se usarán
            string className = "mee-icon-AddMedium";
            string excludeClassName = "exclusiveLockedPts";

            while (true)
            {
                // Refrescar la página
                await _wvRewards.ExecuteScriptAsync("location.reload();");
                await Task.Delay(5000); // Esperar 5 segundos para asegurar que la página carga

                // Verificar si hay botones disponibles
                string checkScript = string.Format(@"
                    (function() {{
                        var buttons = document.getElementsByClassName('{0}');
                        var validButtons = Array.prototype.filter.call(buttons, function(button) {{
                            return !button.classList.contains('{1}');
                        }});
                        return validButtons.length;
                    }})()
                ", className, excludeClassName);

                var buttonCountResult = await _wvRewards.ExecuteScriptAsync(checkScript);
                if (buttonCountResult == null || int.Parse(buttonCountResult.ToString()) == 0)
                {
                    Console.WriteLine("No hay más botones disponibles para pulsar.");
                    break;
                }

                // Recorrer y pulsar botones uno por uno
                int buttonCount = int.Parse(buttonCountResult.ToString());
                Console.WriteLine($"Se encontraron {buttonCount} botones válidos.");
                for (int i = 0; i < buttonCount; i++)
                {
                    string clickScript = string.Format(@"
                        (function() {{
                            var buttons = document.getElementsByClassName('{0}');
                            var validButtons = Array.prototype.filter.call(buttons, function(button) {{
                                return !button.classList.contains('{1}');
                            }});
                            if (validButtons.length > {2}) {{
                                validButtons[{2}].click();
                                return true;
                            }}
                            return false;
                        }})()
                    ", className, excludeClassName, i);

                    var clickResult = await _wvRewards.ExecuteScriptAsync(clickScript);
                    if (clickResult == null || clickResult.ToString().ToLower() != "true")
                    {
                        Console.WriteLine($"Error al pulsar el botón {i + 1}.");
                        break;
                    }

                    Console.WriteLine($"Botón {i + 1} pulsado correctamente.");
                    int delay = new Random().Next(15000, 30001); // Esperar entre 15 y 30 segundos
                    await Task.Delay(delay);
                }

                // Esperar entre 10 y 15 minutos antes de volver a intentarlo
                int waitTime = new Random().Next(10 * 60 * 1000, 15 * 60 * 1000);
                Console.WriteLine($"Esperando {waitTime / 60000} minutos antes de continuar.");
                await Task.Delay(waitTime);
            }

            _profile.Search.RewardsPlayed = false;
        }

        public async Task SetRewardsURL(Uri url)
        {
            if (_wvRewards.Source != url)
                _wvRewards.Source = url;
            else
                await ReloadRewardsWeb();
        }

        public async Task ReloadRewardsWeb()
        {
            if ((_wvRewards.Source?.ToString() ?? "about:blank") != "about:blank")
            {
                while ((_wvRewards?.CoreWebView2?.Source ?? "about:blank") == "about:blank" || _wvRewards.Source.ToString() != Uri.UnescapeDataString(_wvRewards.CoreWebView2.Source))
                    await Task.Delay(500);

                _wvRewards.Reload();
            }
        }

        public async Task EnsureCoreWebView2Async()
        {
            // Crea el entorno de WebView2 con la carpeta de datos especificada
            var env = await CoreWebView2Environment.CreateAsync(null, _profile.Path);

            await _wvRewards.EnsureCoreWebView2Async(env);

            _wvRewards.CoreWebView2.NewWindowRequested += Rewards_CoreWebView2_NewWindowRequested;
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
            while ((_wvRewards?.CoreWebView2?.Source ?? "about:blank") == "about:blank")
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
                string result = await _wvRewards.CoreWebView2?.ExecuteScriptAsync(jsCode);

                if (result == "true")
                    return true; // Return true if the text is found

                // Wait before checking again
                await Task.Delay(1000); // Delay for 1 second before rechecking
            }

            // If the text was not found within the timeout period (if specified), return false
            return false;
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
                            var match = descriptionText.match(/(\d+)\s+puntos?\s+por\s+búsqueda/); // Regex to find points per search
                            if (match) {{
                                result.pointsPerSearch = match[1]; // Store the matched points per search
                            }}
                        }}
                    }});

                    return JSON.stringify(result); // Return the result as a JSON string
                }})();";

            // Execute the JavaScript code and get the result as a JSON string
            string resultJson = await _wvRewards.CoreWebView2.ExecuteScriptAsync(jsCode);

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
        #endregion

        #region Events
        private void WebView_CoreWebView2InitializationCompleted(object sender, CoreWebView2InitializationCompletedEventArgs e)
        {
            CoreWebView2InitializationCompleted?.Invoke(sender, e);
        }

        private void WvRewards_CoreWebView2InitializationCompleted(object sender, CoreWebView2InitializationCompletedEventArgs e)
        {
            CoreWebView2InitializationCompleted?.Invoke(sender, e);
        }

        private void WebView_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            NavigationCompleted?.Invoke(sender, e);
        }

        private void Rewards_CoreWebView2_NewWindowRequested(object sender, CoreWebView2NewWindowRequestedEventArgs e)
        {
            NewWindowRequested?.Invoke(sender, e);
        }

        #endregion
    }
}
