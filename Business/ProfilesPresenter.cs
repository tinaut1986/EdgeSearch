using EdgeSearch.Interfaces;
using EdgeSearch.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace EdgeSearch.Business
{
    public class ProfilesPresenter
    {
        List<Profile> _profiles;
        #region Members
        private readonly IProfilesForm _mainView;
        #endregion

        #region Constructors & destructor
        public ProfilesPresenter(IProfilesForm profilesForm)
        {
            _mainView = profilesForm;

            InitializeEvents();

            LoadProfiles();
        }

        public void Dispose()
        {
            FinalizeEvents();
        }

        #endregion

        #region Methods
        private void InitializeEvents()
        {
            _mainView.Load += _mainView_Load;
        }

        private void FinalizeEvents()
        {
            _mainView.Load -= _mainView_Load;
        }

        private void LoadProfiles()
        {
            string profilesPath = Path.Combine(Environment.CurrentDirectory, "Profiles");

            // Comprobar si existe la carpeta "Profiles" y crearla si no existe
            if (!Directory.Exists(profilesPath))
                CreateDefaultFolder(profilesPath);

            // Cargar los nombres de todas las carpetas dentro de "Profiles"
            _profiles = new List<Profile>();

            foreach (string directory in Directory.GetDirectories(profilesPath))
            {
                string profileName = new DirectoryInfo(directory).Name;
                _profiles.Add(new Profile(profileName, directory));
            }

            // Imprimir los nombres de los perfiles encontrados
            Console.WriteLine("Perfiles encontrados:");
            foreach (var profile in _profiles)
                Console.WriteLine($"- {profile.Name}");
        }

        private static void CreateDefaultFolder(string profilesPath)
        {
            Directory.CreateDirectory(profilesPath);
            Console.WriteLine("Se ha creado la carpeta Profiles.");

            // Crear la carpeta "Default" dentro de "Profiles"
            Directory.CreateDirectory(Path.Combine(profilesPath, "Default"));
            Console.WriteLine("Se ha creado la carpeta Default dentro de Profiles.");
        }
        #endregion

        #region Events
        private void _mainView_Load(object sender, EventArgs e)
        {
            _mainView.BindFields(_profiles);
        }
        #endregion
    }
}
