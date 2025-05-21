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

        public async Task OpenRewards()
        {
            // Marcar que empezamos a ejecutar los puntos - This should be done by the caller (MainPresenter.Play)
            // _profile.Search.RewardsPlaying = true; 

            // Definir las clases CSS que se usarán
            string className = "mee-icon-AddMedium";
            string excludeClassName = "exclusiveLockedPts";

            // Iniciar un bucle infinito para ejecutar los puntos

            // Initial refresh to load the page for counting total rewards
            await _wvRewards.ExecuteScriptAsync("location.reload();");
            await Task.Delay(5000); // Esperar 5 segundos para asegurar que la página carga

            // Initial count of total available reward buttons
            string initialCheckScript = string.Format(@"
                (function() {{
                    var buttons = document.getElementsByClassName('{0}');
                    var validButtons = Array.prototype.filter.call(buttons, function(button) {{
                        return !button.classList.contains('{1}');
                    }});
                    return validButtons.length;
                }})()
            ", className, excludeClassName);

            var initialButtonCountResult = await _wvRewards.ExecuteScriptAsync(initialCheckScript);
            int initialButtonCount;
            int.TryParse(initialButtonCountResult, out initialButtonCount);

            _profile.Search.TotalRewards = initialButtonCount;
            _profile.Search.CurrentRewards = 0;
            Console.WriteLine($"OpenRewards: Initial TotalRewards set to {initialButtonCount}");

            while (_profile.Search.RewardsPlaying) // Loop while RewardsPlaying is true
            {
                // Check if we should still be playing rewards (controlled by MainPresenter)
                // This check is now the main loop condition, but an explicit break can still be useful
                if (!_profile.Search.RewardsPlaying)
                {
                    Console.WriteLine("OpenRewards: RewardsPlaying is false, stopping.");
                    break;
                }

                // Refrescar la página (already done for the first iteration)
                // For subsequent iterations, a refresh might be needed if the page doesn't auto-update after clicks.
                // However, the current logic clicks all found buttons in one pass, then does a long delay.
                // So, a refresh should happen at the start of each "pass".
                if (_profile.Search.CurrentRewards > 0 && _profile.Search.CurrentRewards < _profile.Search.TotalRewards) // Avoid refresh if it's the first time or all done
                {
                    await _wvRewards.ExecuteScriptAsync("location.reload();");
                    await Task.Delay(5000); 
                }


                // Verificar si hay botones disponibles for the current pass
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
                int currentPassButtonCount;
                int.TryParse(buttonCountResult, out currentPassButtonCount);

                // Si no hay botones disponibles en ESTA PASADA, salir del bucle
                if (buttonCountResult == null || currentPassButtonCount == 0)
                {
                    Console.WriteLine("No hay más botones disponibles para pulsar en esta pasada.");
                    // This might mean all rewards are collected, or the page state is unexpected.
                    // If CurrentRewards < TotalRewards, it might be an issue.
                    // For now, we break and rely on RewardsPlaying being set to false eventually.
                    break; 
                }

                Console.WriteLine($"Se encontraron {currentPassButtonCount} botones válidos en esta pasada.");
                for (int i = 0; i < currentPassButtonCount; i++)
                {
                    // Check before each click if we should still be playing
                    if (!_profile.Search.RewardsPlaying)
                    {
                        Console.WriteLine("OpenRewards: RewardsPlaying became false during button clicking, stopping.");
                        goto end_loop; // Break outer loop
                    }

                    string clickScript = string.Format(@"
                        (function() {{
                            var buttons = document.getElementsByClassName('{0}');
                            var validButtons = Array.prototype.filter.call(buttons, function(button) {{
                                return !button.classList.contains('{1}');
                            }});
                            if (validButtons.length > {2}) {{ // Check against current i
                                validButtons[{2}].click(); // Click the i-th button in the filtered list
                                return true;
                            }}
                            return false;
                        }})()
                    ", className, excludeClassName, i); // Corrected to use i

                    var clickResult = await _wvRewards.ExecuteScriptAsync(clickScript);
                    if (clickResult == null || clickResult.ToString().ToLower() != "true")
                    {
                        Console.WriteLine($"Error al pulsar el botón {i + 1}.");
                        // Potentially a button disappeared or an error occurred.
                        // Decide if this means stop all rewards or just try to refresh and continue.
                        // For now, let's break this inner loop and let the outer loop refresh.
                        break;
                    }

                    _profile.Search.CurrentRewards++; // Increment after successful click
                    Console.WriteLine($"Botón {i + 1} pulsado correctamente. CurrentRewards: {_profile.Search.CurrentRewards}");

                    _profile.SetDelayBetweenRewards();
                    // Interruptible delay
                    for (int t = 0; t < _profile.Search.DelayBetweenRewards.Value / 100; t++)
                    {
                        if (!_profile.Search.RewardsPlaying) { goto end_loop; }
                        await Task.Delay(100);
                    }
                    _profile.ResetDelayBetweenRewards();

                    // If all initially counted rewards have been clicked, exit.
                    if (_profile.Search.CurrentRewards >= _profile.Search.TotalRewards)
                    {
                        Console.WriteLine("OpenRewards: All initially counted rewards have been processed.");
                        goto end_loop;
                    }
                }

                // If no buttons were processed in this pass (e.g. all were filtered out or an error occurred mid-loop)
                // and we haven't collected all rewards, we might need to break or wait.
                // The current logic will perform a long delay if RewardsPlaying is still true.

                // Check if we should still be playing before the long delay
                if (!_profile.Search.RewardsPlaying)
                {
                    Console.WriteLine("OpenRewards: RewardsPlaying is false before long delay, stopping.");
                    break;
                }
                
                // If after a full pass of clicks, no more buttons are found on the page, but not all rewards collected
                // (e.g. TotalRewards was 10, clicked 3, currentPassButtonCount is 0 next time)
                // then the long delay might be pointless. However, the page might dynamically load more later.
                // For now, the logic proceeds to the long delay if RewardsPlaying is true.

                _profile.SetDelayToRetryRewards();
                Console.WriteLine($"Esperando {_profile.Search.DelayToRetryRewards.Value / 60000} minutos antes de continuar.");
                // Interruptible long delay
                for (int t = 0; t < _profile.Search.DelayToRetryRewards.Value / 1000; t++) // Check every second
                {
                    if (!_profile.Search.RewardsPlaying) { goto end_loop; }
                    await Task.Delay(1000);
                }
                _profile.ResetDelayToRetryRewards();
            }

        end_loop:;
            // Al salir del bucle (either by break or natural completion), marcar que ya no se están ejecutando los puntos.
            // This ensures that if OpenRewards finishes on its own, the flag is updated.
            _profile.Search.RewardsPlaying = false;
            Console.WriteLine("OpenRewards: Exited main loop, RewardsPlaying set to false.");
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
