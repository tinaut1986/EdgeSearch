using EdgeSearch.src.Interfaces;
using System;

namespace EdgeSearch.src.Business
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

        internal protected virtual void InitializeEvents()
        {
            _mainForm.AcceptClick += _mainForm_AcceptClick;
            _mainForm.CancelClick += _mainForm_CancelClick;
        }

        internal protected virtual void FinalizeEvents()
        {
            _mainForm.AcceptClick -= _mainForm_AcceptClick;
            _mainForm.CancelClick -= _mainForm_CancelClick;
        }
        internal protected virtual void _mainForm_CancelClick(object sender, EventArgs e)
        {
            _mainForm.CloseFormAsCanceled();
        }

        internal protected virtual void _mainForm_AcceptClick(object sender, EventArgs e)
        {
            _mainForm.CloseFormAsAccepted();
        }

        #endregion
    }
}
