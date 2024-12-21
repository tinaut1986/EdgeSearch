using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace EdgeSearch.src.Business
{
    public class Awaker
    {
        // Importing the SetThreadExecutionState function from kernel32.dll
        [DllImport("kernel32.dll")]
        static extern uint SetThreadExecutionState(uint esFlags);

        const uint ES_CONTINUOUS = 0x80000000; // Maintain continuous state
        const uint ES_SYSTEM_REQUIRED = 0x00000001; // Prevent the system from entering sleep mode

        private Timer _awakeTimer; // Timer to send periodic signals
        private DateTime? lastAwake; // Stores the last time a signal was sent

        /// <summary>
        /// Property that indicates if the timer is enabled.
        /// </summary>
        public bool Enabled => _awakeTimer?.Enabled ?? false;

        /// <summary>
        /// Property to get and set the last awake time.
        /// </summary>
        public DateTime? LastAwake
        {
            get => lastAwake;
            set => lastAwake = value;
        }

        /// <summary>
        /// Constructor of the Awaker class.
        /// </summary>
        public Awaker()
        {
            _awakeTimer = new Timer(); // Initializes the timer
            _awakeTimer.Interval = 60000; // Update interval every minute (60,000 ms)
            _awakeTimer.Tick += RefreshTimer_Tick; // Associates the Tick event with the RefreshTimer_Tick method
        }

        /// <summary>
        /// Method that runs each time the timer reaches its interval.
        /// </summary>
        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                SetThreadExecutionState(ES_CONTINUOUS | ES_SYSTEM_REQUIRED);
                lastAwake = DateTime.Now; // Updates the last awake time
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending activity signal: {ex.Message}");
            }
        }

        /// <summary>
        /// Method to stop the timer and reset the system state.
        /// </summary>
        public void Stop()
        {
            _awakeTimer?.Stop(); // Stops the timer

            try
            {
                SetThreadExecutionState(ES_CONTINUOUS);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error resetting state: {ex.Message}");
            }
        }

        /// <summary>
        /// Method to start the timer.
        /// </summary>
        public void Start()
        {
            _awakeTimer?.Start(); // Starts the timer
        }
    }
}
