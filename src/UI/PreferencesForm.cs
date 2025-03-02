using EdgeSearch.src.Interfaces;
using EdgeSearch.src.Models;
using System.Windows.Forms;

namespace EdgeSearch.UI
{
    public partial class PreferencesForm : AcceptCancelForm, IPreferencesForm
    {
        #region Members

        #endregion

        #region Constructors and Destructor
        public PreferencesForm() : base()
        {
            InitializeComponent();

            InitializeEvents();

            FitButtons();
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

        public void BindFields(Preferences model)
        {
            txtMinWait.DataBindings.Clear();
            txtMinWait.DataBindings.Add(nameof(txtMinWait.Text), model, nameof(model.MinWait), true, DataSourceUpdateMode.OnPropertyChanged);

            txtMaxWait.DataBindings.Clear();
            txtMaxWait.DataBindings.Add(nameof(txtMaxWait.Text), model, nameof(model.MaxWait), true, DataSourceUpdateMode.OnPropertyChanged);

            txtMarginWait.DataBindings.Clear();
            txtMarginWait.DataBindings.Add(nameof(txtMarginWait.Text), model, nameof(model.MarginWait), true, DataSourceUpdateMode.OnPropertyChanged);

            txtMinStreakAmount.DataBindings.Clear();
            txtMinStreakAmount.DataBindings.Add(nameof(txtMinStreakAmount.Text), model, nameof(model.MinStreakAmount), true, DataSourceUpdateMode.OnPropertyChanged);

            txtMaxStreakAmount.DataBindings.Clear();
            txtMaxStreakAmount.DataBindings.Add(nameof(txtMaxStreakAmount.Text), model, nameof(model.MaxStreakAmount), true, DataSourceUpdateMode.OnPropertyChanged);

            txtMarginStreakAmount.DataBindings.Clear();
            txtMarginStreakAmount.DataBindings.Add(nameof(txtMarginStreakAmount.Text), model, nameof(model.MarginStreakAmount), true, DataSourceUpdateMode.OnPropertyChanged);

            txtMinStreakDelay.DataBindings.Clear();
            txtMinStreakDelay.DataBindings.Add(nameof(txtMinStreakDelay.Text), model, nameof(model.MinStreakDelay), true, DataSourceUpdateMode.OnPropertyChanged);

            txtMaxStreakDelay.DataBindings.Clear();
            txtMaxStreakDelay.DataBindings.Add(nameof(txtMaxStreakDelay.Text), model, nameof(model.MaxStreakDelay), true, DataSourceUpdateMode.OnPropertyChanged);

            txtMarginStreakDelay.DataBindings.Clear();
            txtMarginStreakDelay.DataBindings.Add(nameof(txtMarginStreakDelay.Text), model, nameof(model.MarginStreakDelay), true, DataSourceUpdateMode.OnPropertyChanged);

            txtMinExtracPointsDelay.DataBindings.Clear();
            txtMinExtracPointsDelay.DataBindings.Add(nameof(txtMinExtracPointsDelay.Text), model, nameof(model.MinExtractPointsDelay), true, DataSourceUpdateMode.OnPropertyChanged);

            txtMaxExtracPointsDelay.DataBindings.Clear();
            txtMaxExtracPointsDelay.DataBindings.Add(nameof(txtMaxExtracPointsDelay.Text), model, nameof(model.MaxExtractPointsDelay), true, DataSourceUpdateMode.OnPropertyChanged);

            txtMarginExtracPointsDelay.DataBindings.Clear();
            txtMarginExtracPointsDelay.DataBindings.Add(nameof(txtMarginExtracPointsDelay.Text), model, nameof(model.MarginExtractPointsDelay), true, DataSourceUpdateMode.OnPropertyChanged);

            txtMobileUserAgent.DataBindings.Clear();
            txtMobileUserAgent.DataBindings.Add(nameof(txtMobileUserAgent.Text), model, nameof(model.MobileUserAgent), true, DataSourceUpdateMode.OnPropertyChanged);

            txtMobilePointsPerSearch.DataBindings.Clear();
            txtMobilePointsPerSearch.DataBindings.Add(nameof(txtMobilePointsPerSearch.Text), model, nameof(model.MobilePointsPersearch), true, DataSourceUpdateMode.OnPropertyChanged);

            txtMobileTotalPoints.DataBindings.Clear();
            txtMobileTotalPoints.DataBindings.Add(nameof(txtMobileTotalPoints.Text), model, nameof(model.MobileTotalPoints), true, DataSourceUpdateMode.OnPropertyChanged);

            txtDesktopUserAgent.DataBindings.Clear();
            txtDesktopUserAgent.DataBindings.Add(nameof(txtDesktopUserAgent.Text), model, nameof(model.DesktopUserAgent), true, DataSourceUpdateMode.OnPropertyChanged);

            txtDesktopPointsPerSearch.DataBindings.Clear();
            txtDesktopPointsPerSearch.DataBindings.Add(nameof(txtDesktopPointsPerSearch.Text), model, nameof(model.DesktopPointsPersearch), true, DataSourceUpdateMode.OnPropertyChanged);

            txtDesktopTotalPoints.DataBindings.Clear();
            txtDesktopTotalPoints.DataBindings.Add(nameof(txtDesktopTotalPoints.Text), model, nameof(model.DesktopTotalPoints), true, DataSourceUpdateMode.OnPropertyChanged);

            cbSimulateKeyboardTyping.DataBindings.Clear();
            cbSimulateKeyboardTyping.DataBindings.Add(nameof(cbSimulateKeyboardTyping.Checked), model, nameof(model.SimulateKeyboardTyping), true, DataSourceUpdateMode.OnPropertyChanged);

            txtUrlSearches.DataBindings.Clear();
            txtUrlSearches.DataBindings.Add(nameof(txtUrlSearches.Text), model, nameof(model.SearchesBaseUrl), true, DataSourceUpdateMode.OnPropertyChanged);

            txtSearchesParameter.DataBindings.Clear();
            txtSearchesParameter.DataBindings.Add(nameof(txtSearchesParameter.Text), model, nameof(model.SearchesParameterUrl), true, DataSourceUpdateMode.OnPropertyChanged);

            txtUrlRewards.DataBindings.Clear();
            txtUrlRewards.DataBindings.Add(nameof(txtUrlRewards.Text), model, nameof(model.RewardsUrl), true, DataSourceUpdateMode.OnPropertyChanged);

            cpbsMobileNormal.BindFields(model.mobileNormalProgressBarColors);

            cpbsMobileReverse.BindFields(model.mobileReverseProgressBarColors);

            cpbsDesktopNormal.BindFields(model.desktopNormalProgressBarColors);

            cpbsDesktopReverse.BindFields(model.desktopReverseProgressBarColors);
        }

        private void FitButtons()
        {
        }
        #endregion

        #region Events

        #endregion        
    }
}
