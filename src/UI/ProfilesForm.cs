using EdgeSearch.src.Interfaces;
using EdgeSearch.src.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Reflection;
using System.Windows.Forms;

namespace EdgeSearch.UI
{
    public partial class ProfilesForm : AcceptCancelForm, IProfilesForm
    {
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
        public void BindFields(List<Profile> profiles)
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
        }

        private void FinalizeEvents()
        {
        }

        public Profile GetSelectedProfile()
        {
            return (Profile)dgvProfiles.CurrentRow.DataBoundItem;
        }
        #endregion
    }
}
