using EdgeSearch.src.Interfaces;
using EdgeSearch.src.Models;

namespace EdgeSearch.src.Business
{
    public class PreferencesPresenter : AcceptCancelPresenter
    {
        #region Members
        private readonly Preferences _model;
        private IPreferencesForm PreferencesForm => (IPreferencesForm)_mainForm;

        #endregion

        #region Constructors and Destructor
        public PreferencesPresenter(IPreferencesForm mainForm, Preferences model) : base(mainForm)
        {
            _model = model;
        }

        public override void Dispose()
        {
            base.Dispose();
        }
        #endregion

        #region Methods
        internal protected override void InitializeEvents()
        {
            base.InitializeEvents();

            _mainForm.AcceptClick += _mainForm_AcceptClick;
        }

        internal protected override void FinalizeEvents()
        {
            base.FinalizeEvents();

            _mainForm.AcceptClick -= _mainForm_AcceptClick;
        }

        #endregion

        #region Events

        private void _mainForm_AcceptClick(object sender, System.EventArgs e)
        {
            _model.Save();
        }
        #endregion
    }
}
