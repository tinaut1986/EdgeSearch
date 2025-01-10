using EdgeSearch.src.Models;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EdgeSearch.src.Business
{
    public class ExtractPointsTimer
    {
        private Preferences _preferences;
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
        public ExtractPointsTimer(Preferences preferences, Func<System.Threading.Tasks.Task> extractPoints)
        {
            _preferences = preferences;
            _extractPoints = extractPoints;

            _timer = new Timer(); // Initializes the timer

            _timer.Tick += RefreshTimer_Tick; // Associates the Tick event with the RefreshTimer_Tick method
        }

        /// <summary>
        /// Method that runs each time the timer reaches its interval.
        /// </summary>
        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                _extractPoints?.Invoke(); // Extracts points

                _timer.Interval = _preferences.GetExtractPointsDelay() * 1000; // Update interval on a random interval between MinWait and MaxWait
                lastExtraction = DateTime.Now; // Updates the last awake time
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error extracting points: {ex.Message}");
            }
        }

        /// <summary>
        /// Method to stop the timer and reset the system state.
        /// </summary>
        public void Stop()
        {
            _timer?.Stop(); // Stops the timer
        }

        /// <summary>
        /// Method to start the timer.
        /// </summary>
        public void Start()
        {
            _timer.Interval = _preferences.GetExtractPointsDelay() * 1000; // Update interval on a random interval between MinWait and MaxWait

            _timer?.Start(); // Starts the timer
            startTime = DateTime.Now;
        }
    }
}
