using EdgeSearch.Interfaces;
using System;

namespace EdgeSearch.Business
{
    public class AcceptCancelPresenter : IDisposable
    {
        #region Members
        internal readonly IAcceptCancelForm _mainForm;
        #endregion

        #region Constructors and Destructor
        public AcceptCancelPresenter(IAcceptCancelForm mainForm)
        {
            _mainForm = mainForm;

            InitializeEvents();
        }

        public virtual void Dispose()
        {
            FinalizeEvents();
        }
        #endregion

        #region Methods

        public virtual void InitializeEvents()
        {
            _mainForm.AcceptClick += _mainForm_AcceptClick;
            _mainForm.CancelClick += _mainForm_CancelClick;
        }

        public virtual void FinalizeEvents()
        {
            _mainForm.AcceptClick -= _mainForm_AcceptClick;
            _mainForm.CancelClick -= _mainForm_CancelClick;
        }
        private void _mainForm_CancelClick(object sender, EventArgs e)
        {
            _mainForm.CloseFormAsCanceled();
        }

        private void _mainForm_AcceptClick(object sender, EventArgs e)
        {
            _mainForm.CloseFormAsAccepted();
        }

        #endregion
    }
}
