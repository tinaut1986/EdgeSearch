using EdgeSearch.models;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using static EdgeSearch.models.Preferences;

namespace EdgeSearch.Models
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
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region Constructor
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
                _name = value;
                NotifyPropertyChanged();
            }
        }
        public string Path
        {
            get => _path;
            set { _path = value; NotifyPropertyChanged(); }
        }
        #endregion

        public int SearchesProgressBarValue
        {
            get
            {
                if (_search.StrikeTime != null)
                    return Math.Max(0, _preferences.StrikeDelay - Convert.ToInt32((DateTime.Now - _search.StrikeTime.Value).TotalSeconds));
                else
                    return _search.ElapsedSeconds;
            }
        }

        public int SearchesProgressBarMax
        {
            get
            {
                if (_search.StrikeTime != null)
                    return _preferences.StrikeDelay;
                else
                    return _search.SecondsToRefresh;
            }
        }
        public int TotalProgressBar
        {
            get
            {
                if (_search.StrikeCount < _preferences.StrikeAmount)
                    return _search.SecondsToRefresh;
                else
                    return _preferences.StrikeDelay;
            }
        }

        public int CurrentProgressBar
        {
            get
            {
                if (_search.StrikeCount < _preferences.StrikeAmount)
                    return _search.SecondsToRefresh;
                else
                    return _preferences.StrikeDelay;
            }
        }

        public int PointsPersearch
        {
            get => _search.CurrentMode == Mode.Mobile ? _preferences.MobilePointsPersearch : _preferences.DesktopPointsPersearch;
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
            get => _search.CurrentMode == Mode.Mobile ? _preferences.MobileTotalPoints : _preferences.DesktopTotalPoints;
            set
            {
                if (_search.IsMobile)
                    _preferences.MobileTotalPoints = value;
                else if (_search.IsDesktop)
                    _preferences.DesktopTotalPoints = value;

                NotifyPropertyChanged();
            }
        }
    }
}
