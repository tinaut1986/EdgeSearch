using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace EdgeSearch.src.Models
{
    public class ProgressBarColors : INotifyPropertyChanged
    {
        #region Members
        public event PropertyChangedEventHandler PropertyChanged;

        private Color _filledColor;
        private Color _textColor;
        private Color _filledTextColor;
        #endregion

        #region Properties
        public Color FilledColor
        {
            get => _filledColor;
            set
            {
                _filledColor = value;
                NotifyPropertyChanged();
            }
        }
        public Color TextColor
        {
            get => _textColor;
            set
            {
                _textColor = value;
                NotifyPropertyChanged();
            }
        }
        public Color FilledTextColor
        {
            get => _filledTextColor;
            set
            {
                _filledTextColor = value;
                NotifyPropertyChanged();
            }
        }
        #endregion

        #region Methods
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
