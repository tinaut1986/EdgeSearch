using EdgeSearch.src.Models;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EdgeSearch.src.Business
{
    public class ExtractPointsTimer
    {
        private Profile _profile;
        private readonly Func<Task> _extractPoints;
        private Timer _timer; // Timer to send periodic signals
        private DateTime? lastExtraction; // Stores the last time a extraction has been done
        private DateTime? startTime; // Stores the time the timer started

        /// <summary>
        /// Property that indicates if the timer is enabled.
        /// </summary>
        public bool Enabled => _timer?.Enabled ?? false;

        /// <summary>
        /// Property to get and set the interval of the timer.
        /// </summary>
        public int Interval
        {
            get => _timer.Interval;
            private set => _timer.Interval = value;
        }

        /// <summary>
        /// Property to get and set the last extraction time.
        /// </summary>
        public DateTime? LastExtraction
        {
            get => lastExtraction;
            set => lastExtraction = value;
        }
        public DateTime? StartTime { get => startTime; set => startTime = value; }

        /// <summary>
        /// Constructor of the Awaker class.
        /// </summary>
        public ExtractPointsTimer(Profile profile, Func<Task> extractPoints)
        {
            _profile = profile;
            _extractPoints = extractPoints;

            _timer = new Timer(); // Initializes the timer

            _timer.Tick += RefreshTimer_Tick; // Associates the Tick event with the RefreshTimer_Tick method
        }

        /// <summary>
        /// Get the next random interval between MinWait and MaxWait
        /// </summary>
        /// <returns>Next random interval between MinWait and MaxWait</returns>
        private int GetNextInterval()
        {
            return _profile.Preferences.GetExtractPointsDelay() * 1000;
        }

        /// <summary>
        /// Method to stop the timer and reset the system state.
        /// </summary>
        public void Stop()
        {
            _timer?.Stop();
            startTime = null;
        }

        /// <summary>
        /// Method to start the timer.
        /// </summary>
        public void Start()
        {
            if (_timer.Enabled)
                return;

            _timer.Interval = GetNextInterval();

            _timer?.Start();
            startTime = DateTime.Now;
        }

        /// <summary>
        /// Method that runs each time the timer reaches its interval.
        /// </summary>
        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                // Extracts points
                _extractPoints?.Invoke();

                // Stops the timer if the search is on a streak delay
                if (_profile.Search.State == Common.SearchState.OnStreaksDelay)
                    _timer.Stop();

                _timer.Interval = GetNextInterval();

                // Updates the last awake time
                lastExtraction = DateTime.Now;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error extracting points: {ex.Message}");
            }
        }

    }
}
