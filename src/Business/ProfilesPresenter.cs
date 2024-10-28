using EdgeSearch.src.Config;
using EdgeSearch.src.Interfaces;
using EdgeSearch.src.Models;
using EdgeSearch.UI;
using EdgeSearch.Utils.Common;
using System;
using System.ComponentModel;
using System.IO;
using System.Linq;

namespace EdgeSearch.src.Business
{
    public class ProfilesPresenter : AcceptCancelPresenter
    {
        #region Members
        private IProfilesForm _profilesForm => (IProfilesForm)_mainForm;
        private BindingList<Profile> _profiles;
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
            _profilesForm.ProfileDeletionRequested += OnProfileDeletionRequested;
        }

        internal protected override void FinalizeEvents()
        {
            base.FinalizeEvents();

            _profilesForm.Load -= _mainView_Load;
            _profilesForm.ProfileDeletionRequested -= OnProfileDeletionRequested;
        }

        /// <summary>
        /// Loads all profiles from the "Profiles" directory and creates a default profile if none exist.
        /// </summary>
        private void LoadProfiles()
        {
            // Determine the path to the "Profiles" directory
            string profilesPath = GlobalConfig.ProfilesRootPath;

            // Ensure the "Profiles" directory exists and create a default profile if necessary
            CreateDefaultFolder(profilesPath);

            // Initialize the list to store profiles
            _profiles = new BindingList<Profile>() { AllowEdit = true, AllowNew = true, AllowRemove = true, };

            // Iterate through all directories in the "Profiles" folder
            foreach (string directory in LibFileSystem.GetDirectories(profilesPath))
            {
                // Create a new Profile object and add it to the list
                _profiles.Add(new Profile(directory));
            }
        }

        /// <summary>
        /// Creates a default profile folder if no profiles exist and initializes a profile configuration file.
        /// </summary>
        /// <param name="profilesPath">The path to the "Profiles" directory.</param>
        private void CreateDefaultFolder(string profilesPath)
        {
            // Check if the "Profiles" directory is empty
            if (!LibFileSystem.GetDirectories(profilesPath).Any())
            {
                // Generate a random name for the default profile
                string randomName = LibFileSystem.GetRandomName();
                CreateProfile(profilesPath, randomName, "Default");
            }
        }

        /// <summary>
        /// Creates a new profile with the specified name in the given directory.
        /// </summary>
        /// <param name="profilesPath">The base path where all profiles are stored.</param>
        /// <param name="folderName">The name of the folder for this specific profile.</param>
        /// <param name="profileName">The name of the profile to be created.</param>
        private static void CreateProfile(string profilesPath, string folderName, string profileName)
        {
            // Create a new Profile object with the given name and path
            Profile profile = new Profile(profileName, Path.Combine(profilesPath, folderName));

            // Create the directory for the new profile
            // This ensures that the folder structure exists before we try to save any files
            LibFileSystem.CreateDirectory(profile.Path);

            // Save the profile configuration
            // This typically creates a JSON file with the profile details
            profile.Save();
        }


        public void GetSelectedProfile()
        {
            _profilesForm.GetSelectedProfile();
        }

        /// <summary>
        /// Deletes the specified profile from the system and removes it from the list.
        /// </summary>
        /// <param name="profile">The profile to be deleted.</param>
        private void DeleteProfile(Profile profile)
        {
            // Check if the profile is null to avoid null reference exceptions
            if (profile == null)
                return;

            try
            {
                // Call the Delete method of the profile
                // This typically handles the removal of profile data from the file system
                profile.Delete();

                // Remove the profile from the list of profiles
                // This updates the in-memory collection of profiles
                _profiles.Remove(profile);
            }
            catch (Exception ex)
            {
                // Handle any exception that may occur during the deletion process
                // Display an error message to the user
                AcceptCancelForm.ShowError($"Error deleting profile: {ex.Message}");
            }
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

        private void OnProfileDeletionRequested(object sender, Events.ProfileEventArgs e)
        {
            string message = $"Are you sure you want to delete the profile '{e.Profile.Name}'?";
            if (AcceptCancelForm.ShowYesNoQuestion(message))
                DeleteProfile(e.Profile);
        }
        #endregion
    }
}
