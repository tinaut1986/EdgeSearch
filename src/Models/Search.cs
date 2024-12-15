using EdgeSearch.src.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;

namespace EdgeSearch.src.Models
{
    public class Search : INotifyPropertyChanged
    {
        #region Members
        private int _desktopSearchesCount;
        private int _mobileSearchesCount;
        private SearchMode _currentMode;
        private int _elapsedSeconds;
        private int _secondsToWait;
        private bool _isPlaying;
        private string _nextSearch;
        private Uri _url;
        private bool _rewardsPlayed;
        private int _streakCount;
        private int? _streakAmount;
        private DateTime? _streakTime;
        private int _streakDelay;

        private int _currentRewards;
        private int _totalRewards;

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Properties
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

        public SearchMode CurrentMode
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

        public int SecondsToWait
        {
            get => _secondsToWait;
            set
            {
                _secondsToWait = value;
                NotifyPropertyChanged();
            }
        }

        public DateTime? StreakTime
        {
            get => _streakTime;
            set
            {
                _streakTime = value;
                NotifyPropertyChanged();
            }
        }

        public int StreakDelay
        {
            get => _streakDelay;
            set
            {
                _streakDelay = value;
                NotifyPropertyChanged();
            }
        }

        public int StreakCount
        {
            get => _streakCount;
            set
            {
                _streakCount = value;
                NotifyPropertyChanged();
            }
        }

        public int? StreakAmount
        {
            get => _streakAmount;
            set { _streakAmount = value; NotifyPropertyChanged(); }
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

        public IEnumerable<string> ToSearch { get; set; } = new List<string>();

        public IEnumerable<string> Sagas { get; set; } = new List<string>();

        public IEnumerable<string> Hardware { get; set; } = new List<string>();

        public IEnumerable<string> Retro { get; set; } = new List<string>();

        public IEnumerable<string> Games { get; set; } = new List<string>();

        public IEnumerable<string> Companies { get; set; } = new List<string>();

        public List<Tuple<DateTime, SearchMode, string>> UsedSearchs { get; set; } = new List<Tuple<DateTime, SearchMode, string>>();

        public bool IsMobile
        {
            get => CurrentMode == SearchMode.Mobile;
            set
            {
                CurrentMode = value ? SearchMode.Mobile : SearchMode.Desktop;
                NotifyPropertyChanged();
            }
        }

        public bool IsDesktop
        {
            get => CurrentMode == SearchMode.Desktop;
            set
            {
                CurrentMode = true ? SearchMode.Desktop : SearchMode.Mobile;
                NotifyPropertyChanged();
            }
        }

        public int SearchesCount
        {
            get => CurrentMode == SearchMode.Mobile ? MobileSearchesCount : DesktopSearchesCount;
            set
            {
                if (IsMobile)
                    MobileSearchesCount = value;
                else if (IsDesktop)
                    DesktopSearchesCount = value;
                NotifyPropertyChanged();
            }
        }

        public bool RewardsPlayed
        {
            get => _rewardsPlayed;
            set => _rewardsPlayed = value;
        }

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

        #endregion

        #region Constructors
        public Search()
        {
            CurrentMode = SearchMode.Desktop;
        }
        #endregion

        #region Methods
        public string GetRandomElement(IEnumerable<string> list)
        {
            return list.ElementAt(new Random().Next(0, list.Count()));
        }

        public string GetSearch() => GetRandomElement(ToSearch);

        public string GetSaga() => GetRandomElement(Sagas);

        public string GetGame() => GetRandomElement(Games);

        public string GetHardware() => GetRandomElement(Hardware);

        public string GetCompany() => GetRandomElement(Companies);

        public string GetRetro() => GetRandomElement(Retro);

        public string CreateSearch()
        {
            string search = "";
            do
            {
                // Selecciona un elemento al azar de la lista
                search = GetSearch();

                search = search.Replace("%year%", DateTime.Today.Year.ToString());
                if (search.Contains("%saga%"))
                    search = search.Replace("%saga%", GetSaga());
                if (search.Contains("%game%"))
                    search = search.Replace("%game%", GetGame());
                if (search.Contains("%retro%"))
                    search = search.Replace("%retro%", GetRetro());
                if (search.Contains("%hardware%"))
                    search = search.Replace("%hardware%", GetHardware());
                if (search.Contains("%company%"))
                    search = search.Replace("%company%", GetCompany());
            }
            while (UsedSearchs.Any(x => x.Item3 == search));

            return search;
        }

        public void AddHistoricSearch(string search)
        {
            if (search == null)
                return;

            UsedSearchs.Add(new Tuple<DateTime, SearchMode, string>(DateTime.Now, CurrentMode, search));
        }

        public bool EmergencyStop()
        {
            return UsedSearchs.Count(x => Math.Abs((x.Item1 - DateTime.Now).TotalSeconds) < 10) >= 3;
        }

        public void IncreaseSearchCount()
        {
            if (IsMobile)
                MobileSearchesCount++;
            else
                DesktopSearchesCount++;
        }

        public void Stop()
        {
            IsPlaying = false;
            StreakCount = 0;
            StreakAmount = null;
            StreakDelay = 0;
            StreakTime = null;
            ElapsedSeconds = 0;
            SecondsToWait = 0;
        }

        // This method is called by the Set accessor of each property.  
        // The CallerMemberName attribute that is applied to the optional propertyName  
        // parameter causes the property name of the caller to be substituted as an argument.  
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
