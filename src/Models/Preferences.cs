using EdgeSearch.src.Common;
using Newtonsoft.Json;
using System;
using System.IO;
using Utils.Common;

namespace EdgeSearch.src.Models
{
    public class Preferences
    {
        #region Properties
        public int MobilePointsPersearch { get; set; }
        public int DesktopPointsPersearch { get; set; }
        public int MinWait { get; set; }
        public int MaxWait { get; set; }

        public int MarginWait
        {
            get => MaxWait - MinWait;
            set => MaxWait = MinWait + value;
        }
        public int MobileTotalPoints { get; set; }
        public int DesktopTotalPoints { get; set; }
        public string MobileUserAgent { get; set; }
        public string DesktopUserAgent { get; set; }

        /// <summary>
        /// After "MinStreakAmount/MaxStreakAmount" searches, a pause of "MinStreakDelay/MaxStreakDelay" seconds is done.
        /// </summary>
        public int MinStreakAmount { get; set; }

        /// <summary>
        /// After "MinStreakAmount/MaxStreakAmount" searches, a pause of "MinStreakDelay/MaxStreakDelay" seconds is done.
        /// </summary>
        public int MaxStreakAmount { get; set; }
        /// <summary>
        /// After "MinStreakAmount/MaxStreakAmount" searches, a pause of "MinStreakDelay/MaxStreakDelay" seconds is done.
        /// </summary>
        public int MarginStreakAmount
        {
            get => MaxStreakAmount - MinStreakAmount;
            set => MaxStreakAmount = MinStreakAmount + value;
        }

        /// <summary>
        /// After "MinStreakAmount/MaxStreakAmount" searches, a pause of "MinStreakDelay/MaxStreakDelay" seconds is done.
        /// </summary>
        public int MinStreakDelay { get; set; }
        /// <summary>
        /// After "MinStreakAmount/MaxStreakAmount" searches, a pause of "MinStreakDelay/MaxStreakDelay" seconds is done.
        /// </summary>
        public int MaxStreakDelay { get; set; }

        public int MarginStreakDelay
        {
            get => MaxStreakDelay - MinStreakDelay;
            set => MaxStreakDelay = MinStreakDelay
                + value;
        }

        public SearchMode InitialMode { get; set; }

        private readonly string _configFilePath;
        #endregion

        #region Constructors
        public Preferences()
        {
            MobilePointsPersearch = 3;
            DesktopPointsPersearch = 3;
            MinWait = 20;
            MaxWait = 40;
            InitialMode = SearchMode.Desktop;
            MobileTotalPoints = 60;
            DesktopTotalPoints = 90;
            MinStreakAmount = 0;
            MaxStreakAmount = 0;
            MinStreakDelay = 900;
            MaxStreakDelay = 1200;
            MobileUserAgent = "Mozilla/5.0 (Linux; Android 9; ASUS_X00TD; Flow) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/359.0.0.288 Mobile Safari/537.36"; ;
            DesktopUserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/100.0.0.0 Safari/537.36";
        }

        public Preferences(string configFilePath)
            : this()
        {
            _configFilePath = configFilePath;

            string solutionDir = AppDomain.CurrentDomain.BaseDirectory;
            string finalPath = configFilePath;
            if (!File.Exists(configFilePath))
                finalPath = Path.Combine(solutionDir, configFilePath);

            Preferences preferences = null;

            if (!File.Exists(finalPath))
            {
                _configFilePath = configFilePath;

                preferences = new Preferences();
                Map(preferences);
                Save();
            }
            else
            {
                _configFilePath = finalPath;

                var jsonContent = File.ReadAllText(_configFilePath);
                preferences = JsonConvert.DeserializeObject<Preferences>(jsonContent);

                Map(preferences);
            }
        }
        #endregion

        #region Methods
        private void Map(Preferences preferences)
        {
            MobilePointsPersearch = preferences.MobilePointsPersearch;
            DesktopPointsPersearch = preferences.DesktopPointsPersearch;
            MinWait = preferences.MinWait;
            MaxWait = preferences.MaxWait;
            InitialMode = preferences.InitialMode;
            MobileTotalPoints = preferences.MobileTotalPoints;
            DesktopTotalPoints = preferences.DesktopTotalPoints;
            MinStreakAmount = preferences.MinStreakAmount;
            MaxStreakAmount = preferences.MaxStreakAmount;
            MinStreakDelay = preferences.MinStreakDelay;
            MaxStreakDelay = preferences.MaxStreakDelay;
            DesktopUserAgent = preferences.DesktopUserAgent;
            MobileUserAgent = preferences.MobileUserAgent;
        }

        public int GetSearchWaitTime()
        {
            return new Random().Next(MinWait, MaxWait);
        }

        public int GetStreakAmount()
        {
            return new Random().Next(MinStreakAmount, MaxStreakAmount);
        }

        public int GetStreakDelay()
        {
            return new Random().Next(MinStreakDelay, MaxStreakDelay);
        }

        public void Save()
        {
            var jsonContent = JsonConvert.SerializeObject(this, Formatting.Indented);
            LibFileSystem.WriteFile(_configFilePath, jsonContent);
        }
        #endregion
    }
}