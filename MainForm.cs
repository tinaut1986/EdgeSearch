using Microsoft.Web.WebView2.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace Test_web
{
    public partial class MainForm : Form
    {
        private Timer refreshTimer;
        private int elapsedSeconds;
        private int refreshSeconds;
        private int lowerLimit;
        private int upperLimit;
        private int searchesCount = 0;
        private int pointsLimit = 90;
        private Random random;
        private bool isPlaying;

        List<string> searches = new List<string>();

        public MainForm()
        {
            InitializeComponent();
            InitializeWebView();
            InitializeProgressBar();
            SetupRefreshTimer();
            isPlaying = false;
            random = new Random();

            LoadSearchesFromFile("searches.txt"); // Carga las búsquedas desde el archivo

            Load += Form_Load;
            webView.CoreWebView2InitializationCompleted += WebView_CoreWebView2InitializationCompleted;
        }

        private void LoadSearchesFromFile(string filePath)
        {
            string solutionDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../..");
            string finalPath = Path.Combine(solutionDir, filePath);

            if (File.Exists(finalPath))
            {
                string[] lines = File.ReadAllLines(finalPath);
                searches.AddRange(lines.Select(line => line.Trim())); // Añade cada línea a la lista
            }
            else
                MessageBox.Show($"El archivo {finalPath} no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);            
        }

        private async void WebView_CoreWebView2InitializationCompleted(object sender, CoreWebView2InitializationCompletedEventArgs e)
        {
            // Espera a que WebView2 esté inicializado antes de cargar la página
            await webView.CoreWebView2.AddScriptToExecuteOnDocumentCreatedAsync(
                       "var userAgent = 'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/100.0.0.0 Safari/537.36';" +
                       "window.navigator.__defineGetter__('userAgent', function(){ return userAgent; });");

            webView.Source = new Uri("https://www.bing.com/");
            txtURL.Text = webView.Source.AbsoluteUri;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            webView.EnsureCoreWebView2Async(null);
        }

        private async void InitializeWebView()
        {
            Controls.Add(webView);
            await webView.EnsureCoreWebView2Async(); // Inicializar WebView2
        }

        private void SetupRefreshTimer()
        {
            refreshTimer = new Timer();
            refreshTimer.Interval = 1000; // Intervalo de actualización cada segundo
            refreshTimer.Tick += RefreshTimer_Tick;
        }

        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            elapsedSeconds++;

            if (elapsedSeconds >= refreshSeconds)
            {
                if (searches.Count == 0 || (searchesCount * 3) >= pointsLimit)
                {
                    btnPlay_Click(null, null);
                    return;
                }

                // Selecciona un elemento al azar de la lista
                int randomIndex = random.Next(0, searches.Count);
                string search = searches[randomIndex];

                webView.Source = new Uri($"https://www.bing.com/search?q={search}&form=QBLH&sp=-1&ghc=1&lq=0&pq={search}");

                // Elimina el elemento seleccionado para que no se repita
                searches.RemoveAt(randomIndex);

                elapsedSeconds = 0; // Reinicia el contador de segundos
                UpdateLimits();
                txtURL.Text = webView.Source.AbsoluteUri;
                searchesCount++;
                lblResumen.Text = $"searches: {searchesCount} | points: {searchesCount * 3}/{pointsLimit}";
            }

            UpdateProgressBar();
        }

        private void InitializeProgressBar()
        {
            Controls.Add(progressBar);
        }

        private void UpdateProgressBar()
        {
            progressBar.Value = progressBar.Maximum - elapsedSeconds; // Calcula el progreso actual basado en los segundos transcurridos

            lblProgress.Text = $"{elapsedSeconds}/{refreshSeconds} s"; // Actualiza el texto del Label
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (!isPlaying)
            {
                UpdateLimits();
                refreshTimer.Start(); // Inicia el temporizador cuando se presiona el botón
                isPlaying = true;
                btnPlay.Text = "Stop"; // Cambia el texto del botón a "Stop"
            }
            else
            {
                refreshTimer.Stop(); // Detiene el temporizador si ya está activo
                isPlaying = false;
                btnPlay.Text = "Play"; // Cambia el texto del botón a "Play"
            }

            btnOpen.Enabled = !isPlaying;
            txtURL.ReadOnly = isPlaying;
        }

        private void UpdateLimits()
        {
            lowerLimit = int.Parse(txtLowerUpdate.Text);
            upperLimit = int.Parse(txtUpperUpdate.Text);
            refreshSeconds = random.Next(lowerLimit, upperLimit + 1);
            elapsedSeconds = 0;

            UpdateProgressBarLimits();
        }

        private void UpdateProgressBarLimits()
        {
            progressBar.Minimum = 0;
            progressBar.Maximum = refreshSeconds; // Número de segundos para la recarga
            progressBar.Value = progressBar.Maximum; // Establece el valor inicial como el máximo para empezar lleno
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            webView.Source = new Uri(txtURL.Text);
        }

        private void txtURL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)ConsoleKey.Enter)
                btnOpen_Click(null, null);
        }
    }
}
