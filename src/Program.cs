using EdgeSearch.src.Business;
using EdgeSearch.src.Models;
using EdgeSearch.UI;
using System;
using System.IO;
using System.Windows.Forms;

namespace EdgeSearch.src
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

        private static ProfilesForm Execute()
        {
            ProfilesForm profilesForm = new ProfilesForm();
            ProfilesPresenter profilesPresenter = new ProfilesPresenter(profilesForm);
            return profilesForm;
        }
    }
}
