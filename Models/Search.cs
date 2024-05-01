using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
