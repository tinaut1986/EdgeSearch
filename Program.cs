using EdgeSearch.Business;
using EdgeSearch.models;
using EdgeSearch.Models;
using EdgeSearch.UI;
using System;
using System.IO;
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
            Application.Run(Execute());
        }

        private static MainForm Execute()
        {
            Preferences preferences = new Preferences("Config\\Profiles\\config.json");
            Search search = new Search();
            Profile profile = new Profile(search, preferences, "Default", Path.Combine(Environment.CurrentDirectory, "Profiles", "Default"));
            MainForm mainForm = new MainForm(profile);
            // Carga las preferencias
            MainPresenter presenter = new MainPresenter(mainForm, profile);
            return mainForm;
        }
    }
}
