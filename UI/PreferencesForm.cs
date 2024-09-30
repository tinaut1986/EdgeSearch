using EdgeSearch.Interfaces;
using EdgeSearch.models;
using System.Windows.Forms;

namespace EdgeSearch.UI
{
    public partial class PreferencesForm : AcceptCancelForm, IPreferencesForm
    {
        #region Members

        private readonly Preferences _model;
        #endregion

        #region Constructors and Destructor
        public PreferencesForm(Preferences model) : base()
        {
            InitializeComponent();

            InitializeEvents();

            FitButtons();

            _model = model;

            BindFields();
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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

        }

        private void FinalizeEvents()
        {

        }

        public void BindFields()
        {
            txtMinWait.DataBindings.Clear();
            txtMinWait.DataBindings.Add(nameof(txtMinWait.Text), _model, nameof(_model.MinWait), true, DataSourceUpdateMode.OnPropertyChanged);

            txtMaxWait.DataBindings.Clear();
            txtMaxWait.DataBindings.Add(nameof(txtMaxWait.Text), _model, nameof(_model.MaxWait), true, DataSourceUpdateMode.OnPropertyChanged);

            txtStrikeAmount.DataBindings.Clear();
            txtStrikeAmount.DataBindings.Add(nameof(txtStrikeAmount.Text), _model, nameof(_model.StrikeAmount), true, DataSourceUpdateMode.OnPropertyChanged);

            txtStrikeDelay.DataBindings.Clear();
            txtStrikeDelay.DataBindings.Add(nameof(txtStrikeDelay.Text), _model, nameof(_model.StrikeDelay), true, DataSourceUpdateMode.OnPropertyChanged);

            txtMobileUserAgent.DataBindings.Clear();
            txtMobileUserAgent.DataBindings.Add(nameof(txtMobileUserAgent.Text), _model, nameof(_model.MobileUserAgent), true, DataSourceUpdateMode.OnPropertyChanged);

            txtMobilePointsPerSearch.DataBindings.Clear();
            txtMobilePointsPerSearch.DataBindings.Add(nameof(txtMobilePointsPerSearch.Text), _model, nameof(_model.MobilePointsPersearch), true, DataSourceUpdateMode.OnPropertyChanged);

            txtMobileTotalPoints.DataBindings.Clear();
            txtMobileTotalPoints.DataBindings.Add(nameof(txtMobileTotalPoints.Text), _model, nameof(_model.MobileTotalPoints), true, DataSourceUpdateMode.OnPropertyChanged);

            txtDesktopUserAgent.DataBindings.Clear();
            txtDesktopUserAgent.DataBindings.Add(nameof(txtDesktopUserAgent.Text), _model, nameof(_model.DesktopUserAgent), true, DataSourceUpdateMode.OnPropertyChanged);

            txtDesktopPointsPerSearch.DataBindings.Clear();
            txtDesktopPointsPerSearch.DataBindings.Add(nameof(txtDesktopPointsPerSearch.Text), _model, nameof(_model.DesktopPointsPersearch), true, DataSourceUpdateMode.OnPropertyChanged);

            txtDesktopTotalPoints.DataBindings.Clear();
            txtDesktopTotalPoints.DataBindings.Add(nameof(txtDesktopTotalPoints.Text), _model, nameof(_model.DesktopTotalPoints), true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void FitButtons()
        {
        }
        #endregion

        #region Events

        #endregion
    }
}
