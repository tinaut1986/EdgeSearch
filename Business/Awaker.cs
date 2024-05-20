using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace EdgeSearch.Business
{
    internal class Awaker
    {
        // Importación de la función SetThreadExecutionState desde kernel32.dll
        [DllImport("kernel32.dll")]
        static extern uint SetThreadExecutionState(uint esFlags);

        const uint ES_CONTINUOUS = 0x80000000;
        const uint ES_SYSTEM_REQUIRED = 0x00000001;
        private Timer _awakeTimer;

        public Awaker()
        {
            _awakeTimer = new Timer();
            _awakeTimer.Interval = 60000; // Intervalo de actualización cada segundo
            _awakeTimer.Tick += RefreshTimer_Tick;
        }

        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            // Evitar que el PC entre en suspensión
            SetThreadExecutionState(ES_CONTINUOUS | ES_SYSTEM_REQUIRED);
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
