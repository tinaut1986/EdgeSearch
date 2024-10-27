using EdgeSearch.src.Interfaces;
using System;
using System.Windows.Forms;

namespace EdgeSearch.UI
{
    public partial class AcceptCancelForm : Form, IAcceptCancelForm
    {
        public event EventHandler AcceptClick;
        public event EventHandler CancelClick;

        #region Constructors and destructor
        public AcceptCancelForm()
        {
            InitializeComponent();

            InitializeEvents();
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
            btnAccept.Click += BtnAccept_Click;
            btnCancel.Click += BtnCancel_Click;
        }

        private void FinalizeEvents()
        {
            btnAccept.Click -= BtnAccept_Click;
            btnCancel.Click -= BtnCancel_Click;
        }

        public void SetButtonsText(string acceptText, string cancelText)
        {
            if (acceptText != null)
                btnAccept.Text = acceptText;

            if (cancelText != null)
                btnCancel.Text = cancelText;
        }

        public void SetButtonsAvailability(bool? acceptEnabled, bool? cancelEnabled)
        {
            if (acceptEnabled != null)
                btnAccept.Enabled = acceptEnabled.Value;

            if (cancelEnabled != null)
                btnCancel.Enabled = cancelEnabled.Value;
        }

        public void SetButtonsVisibility(bool? acceptVisible, bool? cancelVisible)
        {
            if (acceptVisible != null)
                btnAccept.Visible = acceptVisible.Value;

            if (cancelVisible != null)
                btnCancel.Visible = cancelVisible.Value;
        }

        public void CloseFormAsCanceled()
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        public void CloseFormAsAccepted()
        {
            this.DialogResult = DialogResult.OK;
            Close();
        }

        #endregion

        #region Events
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            CancelClick?.Invoke(sender, e);
        }

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            AcceptClick?.Invoke(sender, e);
        }
        #endregion
    }
}
