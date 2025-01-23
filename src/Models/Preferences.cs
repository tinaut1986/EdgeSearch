using EdgeSearch.src.Common;
using Newtonsoft.Json;
using System;
using System.Drawing;
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

        public ProgressBarColors desktopNormalProgressBarColors { get; set; }
        public ProgressBarColors desktopReverseProgressBarColors { get; set; }
        public ProgressBarColors mobileNormalProgressBarColors { get; set; }
        public ProgressBarColors mobileReverseProgressBarColors { get; set; }

        public bool SimulateKeyboardTyping { get; set; }

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
            set => MaxStreakDelay = MinStreakDelay + value;
        }

        /// <summary>
        /// After "MinExtractPointsDelay/MaxExtractPointsDelay" seconds, the points are extracted from the web.
        /// </summary>
        public int MinExtractPointsDelay { get; set; }
        /// <summary>
        /// After "MinExtractPointsDelay/MaxExtractPointsDelay" seconds, the points are extracted from the web.
        /// </summary>
        public int MaxExtractPointsDelay { get; set; }
        public int MarginExtractPointsDelay
        {
            get => MaxExtractPointsDelay - MinExtractPointsDelay;
            set => MaxExtractPointsDelay = MinExtractPointsDelay + value;
        }

        public int MinDelayBetweenRewards { get; set; }
        public int MaxDelayBetweenRewards { get; set; }
        public int MarginDelayBetweenRewards
        {
            get => MaxDelayBetweenRewards - MinDelayBetweenRewards;
            set => MaxDelayBetweenRewards = MinDelayBetweenRewards + value;
        }

        public int MinDelayToRetryRewards { get; set; }
        public int MaxDelayToRetryRewards { get; set; }
        public int MarginDelayToRetryReward
        {
            get => MaxDelayToRetryRewards - MinDelayToRetryRewards;
            set => MaxDelayToRetryRewards = MinDelayToRetryRewards + value;
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
            InitialMode = SearchMode.Desktop; // Start with desktop mode
            MobileTotalPoints = 60; // 20 searches
            DesktopTotalPoints = 90; // 30 searches
            MinStreakAmount = 0;
            MaxStreakAmount = 0;
            MinStreakDelay = 900; // 15 minutes
            MaxStreakDelay = 1200; // 20 minutes
            MinExtractPointsDelay = 300; // 5 minutes
            MaxExtractPointsDelay = 600; // 10 minutes
            MinDelayBetweenRewards = 15000; // 15 seconds
            MaxDelayBetweenRewards = 30000; // 30 seconds
            MinDelayToRetryRewards = 10 * 60 * 1000; // 10 minutes
            MaxDelayToRetryRewards = 15 * 60 * 1000; // 15 minutes
            MobileUserAgent = "Mozilla/5.0 (Linux; Android 9; ASUS_X00TD; Flow) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/359.0.0.288 Mobile Safari/537.36"; // ASUS Zenfone Max Pro M1
            DesktopUserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/100.0.0.0 Safari/537.36"; // Windows 10
            SimulateKeyboardTyping = true;

            desktopNormalProgressBarColors = new ProgressBarColors() { FilledColor = Color.Green, TextColor = Color.Black, FilledTextColor = Color.White };
            desktopReverseProgressBarColors = new ProgressBarColors() { FilledColor = Color.Orange, TextColor = Color.Black, FilledTextColor = Color.White };
            mobileNormalProgressBarColors = new ProgressBarColors() { FilledColor = Color.Blue, TextColor = Color.Black, FilledTextColor = Color.White };
            mobileReverseProgressBarColors = new ProgressBarColors() { FilledColor = Color.Red, TextColor = Color.Black, FilledTextColor = Color.White };
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
            MinDelayToRetryRewards = preferences.MinDelayToRetryRewards;
            MaxDelayToRetryRewards = preferences.MaxDelayToRetryRewards;
            MinDelayBetweenRewards = preferences.MinDelayBetweenRewards;
            MaxDelayBetweenRewards = preferences.MaxDelayBetweenRewards;
            MinExtractPointsDelay = preferences.MinExtractPointsDelay;
            MaxExtractPointsDelay = preferences.MaxExtractPointsDelay;
            DesktopUserAgent = preferences.DesktopUserAgent;
            MobileUserAgent = preferences.MobileUserAgent;
            SimulateKeyboardTyping = preferences.SimulateKeyboardTyping;
            Map(desktopNormalProgressBarColors, preferences.desktopNormalProgressBarColors);
            Map(desktopReverseProgressBarColors, preferences.desktopReverseProgressBarColors);
            Map(mobileNormalProgressBarColors, preferences.mobileNormalProgressBarColors);
            Map(mobileReverseProgressBarColors, preferences.mobileReverseProgressBarColors);
        }

        private void Map(ProgressBarColors colors1, ProgressBarColors colors2)
        {
            colors1.FilledColor = colors2.FilledColor;
            colors1.TextColor = colors2.TextColor;
            colors1.FilledTextColor = colors2.FilledTextColor;
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

        public int GetExtractPointsDelay()
        {
            return new Random().Next(MinExtractPointsDelay, MaxExtractPointsDelay);
        }

        public int GetDelayBetweenRewards()
        {
            return new Random().Next(MinDelayBetweenRewards, MaxDelayBetweenRewards);
        }

        public int GetDelayToRetryReward()
        {
            return new Random().Next(MinDelayToRetryRewards, MaxDelayToRetryRewards);
        }

        public void Save()
        {
            var jsonContent = JsonConvert.SerializeObject(this, Formatting.Indented);
            LibFileSystem.WriteFile(_configFilePath, jsonContent);
        }
        #endregion
    }
}