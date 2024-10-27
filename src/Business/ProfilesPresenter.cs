using EdgeSearch.src.Interfaces;
using EdgeSearch.src.Models;
using EdgeSearch.UI;
using EdgeSearch.Utils.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;

namespace EdgeSearch.src.Business
{
    public class ProfilesPresenter : AcceptCancelPresenter
    {
        #region Members
        private IProfilesForm _profilesForm => (IProfilesForm)_mainForm;
        private List<Profile> _profiles;
        #endregion

        #region Constructors & destructor
        public ProfilesPresenter(IProfilesForm profilesForm)
            : base(profilesForm)
        {
            LoadProfiles();
        }

        public override void Dispose()
        {
            base.Dispose();
        }

        #endregion

        #region Methods
        internal protected override void InitializeEvents()
        {
            base.InitializeEvents();

            _profilesForm.Load += _mainView_Load;
        }

        internal protected override void FinalizeEvents()
        {
            base.FinalizeEvents();

            _profilesForm.Load -= _mainView_Load;
        }

        private void LoadProfiles()
        {
            string profilesPath = Path.Combine(Environment.CurrentDirectory, "Profiles");

            // Comprobar si existe la carpeta "Profiles" y crearla si no existe
            CreateDefaultFolder(profilesPath);

            // Cargar los nombres de todas las carpetas dentro de "Profiles"
            _profiles = new List<Profile>();

            foreach (string directory in LibFileSystem.GetDirectories(profilesPath))
            {
                string profileName = new DirectoryInfo(directory).Name;
                _profiles.Add(new Profile(profileName, directory));
            }

            // Imprimir los nombres de los perfiles encontrados
            Console.WriteLine("Perfiles encontrados:");
            foreach (var profile in _profiles)
                Console.WriteLine($"- {profile.Name}");
        }

        private void CreateDefaultFolder(string profilesPath)
        {
            if (!LibFileSystem.GetDirectories(profilesPath).Any())
            {
                // Crear la carpeta "Default" dentro de "Profiles"
                LibFileSystem.CreateDirectory(Path.Combine(profilesPath, "Default"));
                Console.WriteLine("Se ha creado la carpeta Profiles\\Default.");
            }
        }

        public void GetSelectedProfile()
        {
            _profilesForm.GetSelectedProfile();
        }
        #endregion

        #region Events
        private void _mainView_Load(object sender, EventArgs e)
        {
            _profilesForm.BindFields(_profiles);
        }

        protected internal override void _mainForm_AcceptClick(object sender, EventArgs e)
        {
            _profilesForm.Hide();

            Profile profile = _profilesForm.GetSelectedProfile();
            profile.InitializeData();
            MainForm form = new MainForm(profile);
            MainPresenter presenter = new MainPresenter(form, profile);
            form.ShowDialog();

            _profilesForm.CloseFormAsAccepted();
        }
        #endregion
    }
}
