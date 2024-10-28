using EdgeSearch.src.Interfaces;
using System;
using System.Windows.Forms;

namespace EdgeSearch.UI
{
    /// <summary>
    /// Represents a form with Accept and Cancel buttons, implementing IAcceptCancelForm interface.
    /// </summary>
    public partial class AcceptCancelForm : Form, IAcceptCancelForm
    {
        /// <summary>
        /// Event triggered when the Accept button is clicked.
        /// </summary>
        public event EventHandler AcceptClick;

        /// <summary>
        /// Event triggered when the Cancel button is clicked.
        /// </summary>
        public event EventHandler CancelClick;

        #region Constructors and destructor
        /// <summary>
        /// Initializes a new instance of the AcceptCancelForm.
        /// </summary>
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
        /// <summary>
        /// Initializes event handlers for the buttons.
        /// </summary>
        private void InitializeEvents()
        {
            btnAccept.Click += BtnAccept_Click;
            btnCancel.Click += BtnCancel_Click;
        }

        /// <summary>
        /// Removes event handlers from the buttons.
        /// </summary>
        private void FinalizeEvents()
        {
            btnAccept.Click -= BtnAccept_Click;
            btnCancel.Click -= BtnCancel_Click;
        }

        /// <summary>
        /// Sets the text for the Accept and Cancel buttons.
        /// </summary>
        /// <param name="acceptText">Text for the Accept button. If null or empty, the text remains unchanged.</param>
        /// <param name="cancelText">Text for the Cancel button. If null or empty, the text remains unchanged.</param>
        public void SetButtonsText(string acceptText, string cancelText)
        {
            if (!string.IsNullOrEmpty(acceptText))
                btnAccept.Text = acceptText;

            if (!string.IsNullOrEmpty(cancelText))
                btnCancel.Text = cancelText;
        }

        /// <summary>
        /// Sets the enabled state of the Accept and Cancel buttons.
        /// </summary>
        /// <param name="acceptEnabled">Enabled state for the Accept button. If null, the state remains unchanged.</param>
        /// <param name="cancelEnabled">Enabled state for the Cancel button. If null, the state remains unchanged.</param>
        public void SetButtonsAvailability(bool? acceptEnabled, bool? cancelEnabled)
        {
            if (acceptEnabled.HasValue)
                btnAccept.Enabled = acceptEnabled.Value;

            if (cancelEnabled.HasValue)
                btnCancel.Enabled = cancelEnabled.Value;
        }

        /// <summary>
        /// Sets the visibility of the Accept and Cancel buttons.
        /// </summary>
        /// <param name="acceptVisible">Visibility for the Accept button. If null, the visibility remains unchanged.</param>
        /// <param name="cancelVisible">Visibility for the Cancel button. If null, the visibility remains unchanged.</param>
        public void SetButtonsVisibility(bool? acceptVisible, bool? cancelVisible)
        {
            if (acceptVisible.HasValue)
                btnAccept.Visible = acceptVisible.Value;

            if (cancelVisible.HasValue)
                btnCancel.Visible = cancelVisible.Value;
        }

        /// <summary>
        /// Closes the form with a Canceled result.
        /// </summary>
        public void CloseFormAsCanceled()
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        /// <summary>
        /// Closes the form with an OK result.
        /// </summary>
        public void CloseFormAsAccepted()
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        /// Displays an error message box.
        /// </summary>
        /// <param name="message">The error message to display.</param>
        /// <param name="caption">The caption for the message box. Defaults to "Error".</param>
        public static void ShowError(string message, string caption = "Error")
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Displays a Yes/No question message box.
        /// </summary>
        /// <param name="message">The question to display.</param>
        /// <param name="caption">The caption for the message box.</param>
        /// <returns>True if the user clicked Yes, false otherwise.</returns>
        public static bool ShowYesNoQuestion(string message, string caption = "")
        {
            return MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        /// <summary>
        /// Creates, configures, and shows an AcceptCancelForm.
        /// </summary>
        /// <param name="title">The title of the form.</param>
        /// <param name="message">The message to display on the form.</param>
        /// <param name="acceptText">Text for the Accept button.</param>
        /// <param name="cancelText">Text for the Cancel button.</param>
        /// <returns>True if the user accepted, false if canceled.</returns>
        public static bool ShowForm(string title, string message, string acceptText = "Accept", string cancelText = "Cancel")
        {
            using (var form = new AcceptCancelForm())
            {
                form.Text = title;
                form.lblMessage.Text = message;
                form.SetButtonsText(acceptText, cancelText);
                return form.ShowDialog() == DialogResult.OK;
            }
        }
        #endregion

        #region Events
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            CancelClick?.Invoke(this, EventArgs.Empty);
        }

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            AcceptClick?.Invoke(this, EventArgs.Empty);
        }
        #endregion

        #region Factory Methods
        /// <summary>
        /// Creates a preconfigured AcceptCancelForm for confirming an action.
        /// </summary>
        /// <param name="message">The confirmation message.</param>
        /// <returns>A configured AcceptCancelForm instance.</returns>
        public static AcceptCancelForm CreateConfirmationForm(string message)
        {
            var form = new AcceptCancelForm();
            form.Text = "Confirm Action";
            form.lblMessage.Text = message;
            form.lblMessage.Visible = true;
            form.SetButtonsText("Yes", "No");
            return form;
        }

        /// <summary>
        /// Creates a preconfigured AcceptCancelForm for warning about an action.
        /// </summary>
        /// <param name="message">The warning message.</param>
        /// <returns>A configured AcceptCancelForm instance.</returns>
        public static AcceptCancelForm CreateWarningForm(string message)
        {
            var form = new AcceptCancelForm();
            form.Text = "Warning";
            form.lblMessage.Text = message;
            form.lblMessage.Visible = true;
            form.SetButtonsText("Proceed", "Cancel");
            return form;
        }
        #endregion
    }
}
