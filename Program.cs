using EdgeSearch.Business;
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
            Search search = new Search();
            MainForm mainForm = new MainForm();
            MainPresenter presenter = new MainPresenter(mainForm, search);
            return mainForm;
        }
    }
}
