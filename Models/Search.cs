using System;
using System.Collections.Generic;
using static EdgeSearch.models.Preferences;

namespace EdgeSearch.Models
{
    public class Search
    {
        public int LowerLimit { get; set; }
        public int UpperLimit { get; set; }
        public string MobileUserAgent { get; set; }
        public string DesktopUserAgent { get; set; }
        public int DesktopSearchesCount { get; set; }
        public int MobileSearchesCount { get; set; }
        public Mode CurrentMode { get; set; }
        public int ElapsedSeconds { get; set; }
        public int RefreshSeconds { get; set; }
        public bool IsPlaying { get; set; }
        public string NextSearch { get; set; }
        public Uri URL { get; set; }

        public List<string> ToSearch { get; set; } = new List<string>();
        public List<string> Sagas { get; set; } = new List<string>();
        public List<string> Hardware { get; set; } = new List<string>();
        public List<string> Retro { get; set; } = new List<string>();
        public List<string> Games { get; set; } = new List<string>();
        public List<string> Companies { get; set; } = new List<string>();
        public List<string> UsedSearchs { get; set; } = new List<string>();
        public bool IsMobile => CurrentMode == Mode.Mobile;
        public bool IsDesktop => CurrentMode == Mode.Desktop;

        public Search()
        {
            LowerLimit = 15;
            UpperLimit = 90;
            CurrentMode = Mode.Desktop;
            MobileUserAgent = "Mozilla/5.0 (Linux; Android 9; ASUS_X00TD; Flow) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/359.0.0.288 Mobile Safari/537.36"; ;
            DesktopUserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/100.0.0.0 Safari/537.36";
        }
    }
}
