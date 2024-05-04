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
        private int mobileTotalPoints;
        private int desktopTotalPoints;
        private int desktopSearchesCount;
        private int mobileSearchesCount;
        private Mode currentMode;
        private int elapsedSeconds;
        private int secondsToRefresh;
        private bool isPlaying;
        private string nextSearch;
        private Uri uRL;
        private int upperLimit;
        private int lowerLimit;

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
        }
        #endregion

        public int LowerLimit
        {
            get => lowerLimit;
            set
            {
                lowerLimit = value;
                NotifyPropertyChanged();
            }
        }
        public int UpperLimit
        {
            get => upperLimit;
            set
            {
                upperLimit = value;
                NotifyPropertyChanged();
            }
        }
        public string MobileUserAgent { get; set; }
        public string DesktopUserAgent { get; set; }

        public int MobileTotalPoints
        {
            get => mobileTotalPoints;
            set
            {
                mobileTotalPoints = value;
                NotifyPropertyChanged();
            }
        }

        public int DesktopTotalPoints
        {
            get => desktopTotalPoints;
            set
            {
                desktopTotalPoints = value;
                NotifyPropertyChanged();
            }
        }
        public int DesktopSearchesCount
        {
            get => desktopSearchesCount;
            set
            {
                desktopSearchesCount = value;
                NotifyPropertyChanged();
            }
        }
        public int MobileSearchesCount
        {
            get => mobileSearchesCount;
            set
            {
                mobileSearchesCount = value;
                NotifyPropertyChanged();
            }
        }
        public Mode CurrentMode
        {
            get => currentMode;
            set
            {
                currentMode = value;
                NotifyPropertyChanged();
            }
        }
        public int ElapsedSeconds
        {
            get => elapsedSeconds;
            set
            {
                elapsedSeconds = value;
                NotifyPropertyChanged();
            }
        }
        public int SecondsToRefresh
        {
            get => secondsToRefresh;
            set
            {
                secondsToRefresh = value;
                NotifyPropertyChanged();
            }
        }
        public bool IsPlaying
        {
            get => isPlaying;
            set
            {
                isPlaying = value;
                NotifyPropertyChanged();
            }
        }
        public string NextSearch
        {
            get => nextSearch;
            set
            {
                nextSearch = value;
                NotifyPropertyChanged();
            }
        }
        public Uri URL
        {
            get => uRL;
            set
            {
                uRL = value;
                NotifyPropertyChanged();
            }
        }

        public List<string> ToSearch { get; set; } = new List<string>();
        public List<string> Sagas { get; set; } = new List<string>();
        public List<string> Hardware { get; set; } = new List<string>();
        public List<string> Retro { get; set; } = new List<string>();
        public List<string> Games { get; set; } = new List<string>();
        public List<string> Companies { get; set; } = new List<string>();
        public List<string> UsedSearchs { get; set; } = new List<string>();
        public bool IsMobile
        {
            get => CurrentMode == Mode.Mobile;
            set
            {
                CurrentMode = true ? Mode.Mobile : Mode.Desktop;
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
    }
}
