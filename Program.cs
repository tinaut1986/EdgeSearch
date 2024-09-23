using EdgeSearch.Business;
using EdgeSearch.models;
using EdgeSearch.Models;
using EdgeSearch.UI;
using System;
using System.Windows.Forms;

namespace EdgeSearch
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(NewMethod());
        }

        private static MainForm NewMethod()
        {
            Preferences preferences = new Preferences("Config\\config.json");
            Search search = new Search(preferences);
            MainForm mainForm = new MainForm();
            // Carga las preferencias
            MainPresenter presenter = new MainPresenter(mainForm, search, preferences);
            return mainForm;
        }
    }
}
