using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace EdgeSearch.src.Business
{
    public class Awaker
    {
        // Importación de la función SetThreadExecutionState desde kernel32.dll
        [DllImport("kernel32.dll")]
        static extern uint SetThreadExecutionState(uint esFlags);

        const uint ES_CONTINUOUS = 0x80000000;
        const uint ES_SYSTEM_REQUIRED = 0x00000001;
        private Timer _awakeTimer;
        private DateTime? lastAwake;

        public bool Enabled => _awakeTimer?.Enabled ?? false;
        public DateTime? LastAwake
        {
            get => lastAwake;
            set => lastAwake = value;
        }

        public Awaker()
        {
            _awakeTimer = new Timer();
            _awakeTimer.Interval = 60000; // Intervalo de actualización cada minuto
            _awakeTimer.Tick += RefreshTimer_Tick;
        }

        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            // Evitar que el PC entre en suspensión
            SetThreadExecutionState(ES_CONTINUOUS | ES_SYSTEM_REQUIRED);
            lastAwake = DateTime.Now;
        }

        public void Stop()
        {
            _awakeTimer?.Stop();

            // Evitar que el PC entre en suspensión
            SetThreadExecutionState(ES_CONTINUOUS);
        }

        public void Start()
        {
            _awakeTimer?.Start();
        }
    }
}
