using EdgeSearch.src.Models;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace EdgeSearch.src.UI
{
    public partial class CustomProgressBarSettings : UserControl, INotifyPropertyChanged
    {
        #region Members
        private readonly ColorDialog _colorDialog;

        public event PropertyChangedEventHandler PropertyChanged;

        [Browsable(true)]
        [Description("Set the text of the progressBar")]
        public string ProgressBarText
        {
            get => progressBar.Text;
            set
            {
                progressBar.Text = value;
                NotifyPropertyChanged();
            }
        }

        [Browsable(true)]
        [Description("Set the color of the filled part of the progressBar")]
        public Color ProgressBarColor
        {
            get => progressBar.PaintedColor;
            set
            {
                progressBar.PaintedColor = value;
                pbFilledColor.BackColor = value;
                NotifyPropertyChanged();
            }
        }

        [Browsable(true)]
        [Description("Set the text color of the progressBar")]
        public Color ProgressBarTextColor
        {
            get => pbTextColor.ForeColor;
            set
            {
                progressBar.ForeColor = value;
                pbTextColor.BackColor = value;
                NotifyPropertyChanged();
            }
        }

        [Browsable(true)]
        [Description("Set the text color of the filled part of the progressBar")]
        public Color ProgressBarTextFilledColor
        {
            get => pbFilledTextColor.BackColor;
            set
            {
                progressBar.PaintedForeColor = value;
                pbFilledTextColor.BackColor = value;
                NotifyPropertyChanged();
            }
        }
        #endregion

        #region Constructors
        public CustomProgressBarSettings()
        {
            InitializeComponent();

            _colorDialog = new ColorDialog();
            InitializeEvents();
        }

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                FinalizeEvents();

                components?.Dispose();
            }
            base.Dispose(disposing);
        }

        #endregion

        #region Methods

        private void InitializeEvents()
        {
            pbFilledColor.Click += PbFilledColor_Click;
            pbFilledTextColor.Click += PbFilledTextColor_Click;
            pbTextColor.Click += PbTextColor_Click;
        }

        private void FinalizeEvents()
        {
            pbFilledColor.Click -= PbFilledColor_Click;
            pbFilledTextColor.Click -= PbFilledTextColor_Click;
            pbTextColor.Click -= PbTextColor_Click;
        }

        public void BindFields(ProgressBarColors colors)
        {
            DataBindings.Clear();
            DataBindings.Add(nameof(ProgressBarColor), colors, nameof(colors.FilledColor), true, DataSourceUpdateMode.OnPropertyChanged);
            DataBindings.Add(nameof(ProgressBarTextFilledColor), colors, nameof(colors.FilledTextColor), true, DataSourceUpdateMode.OnPropertyChanged);
            DataBindings.Add(nameof(ProgressBarTextColor), colors, nameof(colors.TextColor), true, DataSourceUpdateMode.OnPropertyChanged);
        }

        // This method is called by the Set accessor of each property.  
        // The CallerMemberName attribute that is applied to the optional propertyName  
        // parameter causes the property name of the caller to be substituted as an argument.  
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region Events

        private void PbTextColor_Click(object sender, EventArgs e)
        {
            if (_colorDialog.ShowDialog() == DialogResult.OK)
                ProgressBarTextColor = _colorDialog.Color;
        }

        private void PbFilledTextColor_Click(object sender, EventArgs e)
        {
            if (_colorDialog.ShowDialog() == DialogResult.OK)
                ProgressBarTextFilledColor = _colorDialog.Color;
        }

        private void PbFilledColor_Click(object sender, EventArgs e)
        {
            if (_colorDialog.ShowDialog() == DialogResult.OK)
                ProgressBarColor = _colorDialog.Color;
        }
        #endregion
    }
}
