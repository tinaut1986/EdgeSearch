using EdgeSearch.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using static EdgeSearch.models.Preferences;

namespace EdgeSearch.Models
{
    public class Search : INotifyPropertyChanged
    {
        private int _desktopSearchesCount;
        private int _mobileSearchesCount;
        private Mode _currentMode;
        private int _elapsedSeconds;
        private int _secondsToRefresh;
        private bool _isPlaying;
        private string _nextSearch;
        private Uri _url;
        private bool _rewardsPlayed;
        private int _strikeCount;
        private DateTime? _strikeTime;

        private int _currentRewards;
        private int _totalRewards;

        private int _currentAmbassadors;
        private int _totalAmbassadors;

        private Preferences _preferences;

        public event PropertyChangedEventHandler PropertyChanged;

        // This method is called by the Set accessor of each property.  
        // The CallerMemberName attribute that is applied to the optional propertyName  
        // parameter causes the property name of the caller to be substituted as an argument.  
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #region Constructors
        public Search()
        {
            _preferences = new Preferences();

            _preferences.MinWait = 15;
            _preferences.MaxWait = 90;
            CurrentMode = Mode.Desktop;
            _preferences.MobileUserAgent = "Mozilla/5.0 (Linux; Android 9; ASUS_X00TD; Flow) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/359.0.0.288 Mobile Safari/537.36"; ;
            _preferences.DesktopUserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/127.0.0.0 Safari/537.36 Edg/128.0.0.0";
        }

        public Search(Preferences preferences)
            : base()
        {
            _preferences = preferences;
        }
        #endregion

        public int DesktopSearchesCount
        {
            get => _desktopSearchesCount;
            set
            {
                _desktopSearchesCount = value;
                NotifyPropertyChanged();
            }
        }

        public int MobileSearchesCount
        {
            get => _mobileSearchesCount;
            set
            {
                _mobileSearchesCount = value;
                NotifyPropertyChanged();
            }
        }

        public Mode CurrentMode
        {
            get => _currentMode;
            set
            {
                _currentMode = value;
                NotifyPropertyChanged();
            }
        }

        public int ElapsedSeconds
        {
            get => _elapsedSeconds;
            set
            {
                _elapsedSeconds = value;
                NotifyPropertyChanged();
            }
        }

        public int SearchesProgressBarValue
        {
            get
            {
                if (StrikeTime != null)
                    return Math.Max(0, _preferences.StrikeDelay - Convert.ToInt32((DateTime.Now - StrikeTime.Value).TotalSeconds));
                else
                    return ElapsedSeconds;
            }
        }

        public int SearchesProgressBarMax
        {
            get
            {
                if (StrikeTime != null)
                    return _preferences.StrikeDelay;
                else
                    return _secondsToRefresh;
            }
        }

        public Color SearchesProgressBarColor
        {
            get
            {
                if (StrikeTime != null)
                    return Color.Orange;
                else
                    return Color.Green;
            }
        }

        public int SecondsToRefresh
        {
            get => _secondsToRefresh;
            set
            {
                _secondsToRefresh = value;
                NotifyPropertyChanged();
            }
        }

        public DateTime? StrikeTime
        {
            get => _strikeTime;
            set
            {
                _strikeTime = value;
                NotifyPropertyChanged();
            }
        }

        public int StrikeCount
        {
            get => _strikeCount;
            set
            {
                _strikeCount = value;
                NotifyPropertyChanged();
            }
        }

        public int TotalProgressBar
        {
            get
            {
                if (StrikeCount < _preferences.StrikeAmount)
                    return SecondsToRefresh;
                else
                    return _preferences.StrikeDelay;
            }
        }
        public int CurrentProgressBar
        {
            get
            {
                if (StrikeCount < _preferences.StrikeAmount)
                    return SecondsToRefresh;
                else
                    return _preferences.StrikeDelay;
            }
        }
        public bool IsPlaying
        {
            get => _isPlaying;
            set
            {
                _isPlaying = value;
                NotifyPropertyChanged();
            }
        }
        public string NextSearch
        {
            get => _nextSearch;
            set
            {
                _nextSearch = value;
                NotifyPropertyChanged();
            }
        }
        public Uri URL
        {
            get => _url;
            set
            {
                _url = value;
                NotifyPropertyChanged();
            }
        }

        public List<string> ToSearch { get; set; } = new List<string>();
        public List<string> Sagas { get; set; } = new List<string>();
        public List<string> Hardware { get; set; } = new List<string>();
        public List<string> Retro { get; set; } = new List<string>();
        public List<string> Games { get; set; } = new List<string>();
        public List<string> Companies { get; set; } = new List<string>();
        public List<Tuple<DateTime, Mode, string>> UsedSearchs { get; set; } = new List<Tuple<DateTime, Mode, string>>();
        public bool IsMobile
        {
            get => CurrentMode == Mode.Mobile;
            set
            {
                CurrentMode = value ? Mode.Mobile : Mode.Desktop;
                NotifyPropertyChanged();
            }
        }

        public bool IsDesktop
        {
            get => CurrentMode == Mode.Desktop;
            set
            {
                CurrentMode = true ? Mode.Desktop : Mode.Mobile;
                NotifyPropertyChanged();
            }
        }

        public int SearchesCount
        {
            get => CurrentMode == Mode.Mobile ? MobileSearchesCount : DesktopSearchesCount;
            set
            {
                if (IsMobile)
                    MobileSearchesCount = value;
                else if (IsDesktop)
                    DesktopSearchesCount = value;
                NotifyPropertyChanged();
            }
        }

        public int PointsPersearch
        {
            get => CurrentMode == Mode.Mobile ? _preferences.MobilePointsPersearch : _preferences.DesktopPointsPersearch;
            set
            {
                if (IsMobile)
                    MobileSearchesCount = value;
                else if (IsDesktop)
                    DesktopSearchesCount = value;
                NotifyPropertyChanged();
            }
        }

        public int CurrentPoints
        {
            get => SearchesCount * PointsPersearch;
            set
            {
                SearchesCount = value / PointsPersearch;
                NotifyPropertyChanged();
            }
        }

        public int PointsLimit
        {
            get => CurrentMode == Mode.Mobile ? _preferences.MobileTotalPoints : _preferences.DesktopTotalPoints;
            set
            {
                if (IsMobile)
                    _preferences.MobileTotalPoints = value;
                else if (IsDesktop)
                    _preferences.DesktopTotalPoints = value;

                NotifyPropertyChanged();
            }
        }


        public bool RewardsPlayed
        {
            get => _rewardsPlayed;
            set => _rewardsPlayed = value;
        }

        public int CurrentAmbassadors
        {
            get => _currentAmbassadors;
            set => _currentAmbassadors = value;
        }

        public Preferences Preferences
        {
            get => _preferences;
            set => _preferences = value;
        }

        public int TotalAmbassadors
        {
            get => _totalAmbassadors;
            set => _totalAmbassadors = value;
        }

        public string AmbassadorsString => $"Ambassadors: {CurrentAmbassadors}/{TotalAmbassadors}";

        public int CurrentRewards
        {
            get => _currentRewards;
            set => _currentRewards = value;
        }

        public int TotalRewards
        {
            get => _totalRewards;
            set => _totalRewards = value;
        }

        public string RewardsString => $"Rewards: {CurrentRewards}/{TotalRewards}";
    }
}
