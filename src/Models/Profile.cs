using EdgeSearch.src.Common;
using EdgeSearch.src.Config;
using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Utils.Common;
using static EdgeSearch.src.Models.Preferences;

namespace EdgeSearch.src.Models
{
    public class Profile : INotifyPropertyChanged
    {
        #region Members
        private string _name;
        private string _path;
        private Search _search;
        private Preferences _preferences;

        public event PropertyChangedEventHandler PropertyChanged;

        // This method is called by the Set accessor of each property.  
        // The CallerMemberName attribute that is applied to the optional propertyName  
        // parameter causes the property name of the caller to be substituted as an argument.  
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region Constructor
        public Profile()
        {
            _path = System.IO.Path.Combine(GlobalConfig.ProfilesRootPath, LibFileSystem.GetRandomName());
        }

        public Profile(string path)
        {
            _path = path;
            Load();
        }

        public Profile(string name, string path)
        {
            _name = name;
            _path = path;
        }

        public Profile(Search search, Preferences preferences, string name, string path)
            : this(name, path)
        {
            _search = search;
            _preferences = preferences;
        }
        #endregion

        #region Properties
        public Search Search
        {
            get => _search;
            set
            {
                _search = value;
                NotifyPropertyChanged();
            }
        }

        public Preferences Preferences
        {
            get => _preferences;
            set
            {
                _preferences = value;
                NotifyPropertyChanged();
            }
        }

        public string Name
        {
            get => _name;
            set
            {
                if (_name != value)
                {
                    _name = value;
                    Save();
                    NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets the path of the profile.
        /// </summary>
        /// <remarks>
        /// When setting a new path:
        /// - If the new path is the same as the current one, no action is taken.
        /// - If the current path is null, it's considered a new profile creation.
        /// - If the current path is not null, the profile is moved to the new location.
        /// </remarks>
        public string Path
        {
            get => _path;
            set
            {
                // If the new value is the same as the current one, do nothing
                if (_path == value)
                    return;

                // If _path was null, we're creating a new profile
                if (_path == null)
                {
                    _path = value;
                    Save(); // Save the profile with the new path
                }

                // If _path was not null, we're moving the profile
                else
                    MoveProfile(value);

                NotifyPropertyChanged();
            }
        }

        public string JsonPath => System.IO.Path.Combine(_path, "profile.json");

        public int SearchesProgressBarValue
        {
            get
            {
                if (_search.StreakTime != null)
                    return Math.Max(0, _search.StreakDelay - Convert.ToInt32((DateTime.Now - _search.StreakTime.Value).TotalSeconds));
                else
                    return _search.ElapsedSeconds;
            }
        }

        public int SearchesProgressBarMax
        {
            get
            {
                if (_search.StreakTime != null)
                    return _search.StreakDelay;
                else
                    return _search.SecondsToWait;
            }
        }

        public int TotalProgressBar
        {
            get
            {
                if (_search.StreakCount < _search.StreakAmount)
                    return _search.SecondsToWait;
                else
                    return _search.StreakDelay;
            }
        }

        public int CurrentProgressBar
        {
            get
            {
                if (_search.StreakCount < _preferences.MinStreakAmount)
                    return _search.SecondsToWait;
                else
                    return _preferences.MaxStreakDelay;
            }
        }

        public int PointsPersearch
        {
            get => _search.CurrentMode == SearchMode.Mobile ? _preferences.MobilePointsPersearch : _preferences.DesktopPointsPersearch;
            set
            {
                if (_search.IsMobile)
                    _search.MobileSearchesCount = value;
                else if (_search.IsDesktop)
                    _search.DesktopSearchesCount = value;
                NotifyPropertyChanged();
            }
        }

        public int CurrentPoints
        {
            get => _search.SearchesCount * PointsPersearch;
            set
            {
                _search.SearchesCount = value / PointsPersearch;
                NotifyPropertyChanged();
            }
        }

        public int PointsLimit
        {
            get => _search.CurrentMode == SearchMode.Mobile ? _preferences.MobileTotalPoints : _preferences.DesktopTotalPoints;
            set
            {
                if (_search.IsMobile)
                    _preferences.MobileTotalPoints = value;
                else if (_search.IsDesktop)
                    _preferences.DesktopTotalPoints = value;

                NotifyPropertyChanged();
            }
        }

        #endregion

        #region Methods
        public void InitializeData()
        {
            if (_preferences == null)
                _preferences = new Preferences($"{this.Path}\\Config\\config.json");

            if (_search == null)
                _search = new Search();
        }

        public void RestartLimits()
        {
            _search.ElapsedSeconds = 0;
            _search.SecondsToWait = _preferences.GetSearchWaitTime();
        }

        public void Delete()
        {
            LibFileSystem.DeleteDirectory(_path, false);
        }

        /// <summary>
        /// Saves the profile name to a JSON file.
        /// </summary>
        public void Save()
        {
            LibFileSystem.CreateDirectory(Path);
            var profileData = new { Name };
            string jsonString = JsonSerializer.Serialize(profileData, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(JsonPath, jsonString);
        }

        /// <summary>
        /// Loads the profile name from a JSON file. If the file doesn't exist, it creates a new one with the directory name.
        /// </summary>
        public void Load()
        {
            // Check if the JSON file exists
            if (LibFileSystem.FileExists(JsonPath))
            {
                // Read the JSON file content
                string jsonString = LibFileSystem.ReadFile(JsonPath);

                try
                {
                    // Deserialize the JSON content
                    var profileData = JsonSerializer.Deserialize<dynamic>(jsonString);
                    // Set the Name property from the deserialized data
                    Name = profileData.GetProperty("Name").GetString();
                }
                catch (JsonException ex)
                {
                    SetNameFromDirectory();
                }
            }
            else
            {
                // If the file doesn't exist, use the directory name as the profile name
                SetNameFromDirectory();
                // Save the new profile data
                Save();
            }
        }

        /// <summary>
        /// Sets the Name property to the name of the directory.
        /// </summary>
        private void SetNameFromDirectory()
        {
            Name = new DirectoryInfo(_path).Name;
        }

        /// <summary>
        /// Moves the profile to a new location.
        /// </summary>
        /// <param name="newPath">The new path where the profile should be moved.</param>
        /// <remarks>
        /// This method moves the profile directory, updates the path, and saves the profile information.
        /// If an error occurs during the process, it's logged to the console.
        /// </remarks>
        private void MoveProfile(string newPath)
        {
            try
            {
                // Move the directory
                Directory.Move(_path, newPath);

                // Update the path
                _path = newPath;

                // Update the JSON file with the new path
                Save();

                Console.WriteLine($"Profile successfully moved to: {newPath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error moving the profile: {ex.Message}");
                // Here you could throw a custom exception or handle the error in another way
            }
        }

        #endregion
    }
}
