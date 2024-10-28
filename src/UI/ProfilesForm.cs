using EdgeSearch.src.Events;
using EdgeSearch.src.Interfaces;
using EdgeSearch.src.Models;
using System;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;

namespace EdgeSearch.UI
{
    public partial class ProfilesForm : AcceptCancelForm, IProfilesForm
    {
        #region Members
        public event EventHandler<ProfileEventArgs> ProfileDeletionRequested;
        #endregion

        #region Constructors and destructor
        public ProfilesForm()
        {
            InitializeComponent();

            ConfigureDataGridView();

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
        public void BindFields(BindingList<Profile> profiles)
        {
            dgvProfiles.DataSource = profiles;
        }

        private void ConfigureDataGridView()
        {
            dgvProfiles.AutoGenerateColumns = false;
            EnableDoubleBuffering(dgvProfiles);
        }

        private void EnableDoubleBuffering(DataGridView dgv)
        {
            // Usar reflexión para acceder a la propiedad DoubleBuffered
            PropertyInfo pi = dgv.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            if (pi != null)
                pi.SetValue(dgv, true, null);
        }

        private void InitializeEvents()
        {
            dgvProfiles.UserDeletingRow += DgvProfiles_UserDeletingRow;
        }

        private void FinalizeEvents()
        {
            dgvProfiles.UserDeletingRow -= DgvProfiles_UserDeletingRow;
        }

        public Profile GetSelectedProfile()
        {
            return (Profile)dgvProfiles.CurrentRow.DataBoundItem;
        }
        #endregion

        #region Events
        private void DgvProfiles_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (e.Row.DataBoundItem is Profile profileToDelete)
            {
                // Notifica al presentador sobre la solicitud de eliminación
                ProfileDeletionRequested?.Invoke(this, new ProfileEventArgs(profileToDelete));

                // Cancela el evento para que el presentador maneje la eliminación
                e.Cancel = true;
            }
        }
        #endregion
    }
}
