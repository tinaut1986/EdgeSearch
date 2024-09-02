using EdgeSearch.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using static EdgeSearch.models.Preferences;

namespace EdgeSearch.Models
{
    public class Search : INotifyPropertyChanged
    {
        private const int _pointsPerSearch = 3;
        private int _mobileTotalPoints;
        private int _desktopTotalPoints;
        private int _desktopSearchesCount;
        private int _mobileSearchesCount;
        private Mode _currentMode;
        private int _elapsedSeconds;
        private int _secondsToRefresh;
        private bool _isPlaying;
        private string _nextSearch;
        private Uri _url;
        private int _upperLimit;
        private int _lowerLimit;
        private bool _ambassadorsPlayed;
        private bool _rewardsPlayed;
        private int _strikeCount;
        private int _totalStrikeCount;
        private DateTime? _strikeTime;
        private int _strikeDelay;
        private int _pointsPersearch;

        private int _currentRewards;
        private int _totalRewards;

        private int _currentAmbassadors;
        private int _totalAmbassadors;

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
            LowerLimit = 15;
            UpperLimit = 90;
            CurrentMode = Mode.Desktop;
            MobileUserAgent = "Mozilla/5.0 (Linux; Android 9; ASUS_X00TD; Flow) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/359.0.0.288 Mobile Safari/537.36"; ;
            DesktopUserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/100.0.0.0 Safari/537.36";
        }

        public Search(Preferences preferences)
        {
            UpperLimit = preferences.UpperLimit;
            LowerLimit = preferences.LowerLimit;
            DesktopTotalPoints = preferences.DesktopTotalPoints;
            DesktopUserAgent = preferences.DesktopUserAgent;
            MobileTotalPoints = preferences.MobileTotalPoints;
            MobileUserAgent = preferences.MobileUserAgent;
            StrikeDelay = preferences.StrikeDelay;
            TotalStrikeCount = preferences.StrikeAmount;
            PointsPersearch = preferences.PointsPersearch;
        }
        #endregion

        public int LowerLimit
        {
            get => _lowerLimit;
            set
            {
                _lowerLimit = value;
                NotifyPropertyChanged();
            }
        }
        public int UpperLimit
        {
            get => _upperLimit;
            set
            {
                _upperLimit = value;
                NotifyPropertyChanged();
            }
        }
        public string MobileUserAgent { get; set; }
        public string DesktopUserAgent { get; set; }

        public int MobileTotalPoints
        {
            get => _mobileTotalPoints;
            set
            {
                _mobileTotalPoints = value;
                NotifyPropertyChanged();
            }
        }

        public int DesktopTotalPoints
        {
            get => _desktopTotalPoints;
            set
            {
                _desktopTotalPoints = value;
                NotifyPropertyChanged();
            }
        }
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
        public int StrikeDelay
        {
            get => _strikeDelay;
            set
            {
                _strikeDelay = value;
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
        public int TotalStrikeCount
        {
            get => _totalStrikeCount;
            set
            {
                _totalStrikeCount = value;
                NotifyPropertyChanged();
            }
        }

        public int PointsPersearch
        {
            get => _pointsPersearch;
            set
            {
                _pointsPersearch = value;
                NotifyPropertyChanged();
            }
        }

        public int TotalProgressBar
        {
            get
            {
                if (StrikeCount < TotalStrikeCount)
                    return SecondsToRefresh;
                else
                    return StrikeDelay;
            }
        }
        public int CurrentProgressBar
        {
            get
            {
                if (StrikeCount < TotalStrikeCount)
                    return SecondsToRefresh;
                else
                    return StrikeDelay;
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

        public int CurrentPoints
        {
            get => SearchesCount * _pointsPerSearch;
            set
            {
                SearchesCount = value / _pointsPerSearch;
                NotifyPropertyChanged();
            }
        }

        public int PointsLimit
        {
            get => CurrentMode == Mode.Mobile ? MobileTotalPoints : DesktopTotalPoints;
            set
            {
                if (IsMobile)
                    MobileTotalPoints = value;
                else if (IsDesktop)
                    DesktopTotalPoints = value;
                NotifyPropertyChanged();
            }
        }

        public bool AmbassadorsPlayed
        {
            get => _ambassadorsPlayed;
            set => _ambassadorsPlayed = value;
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
