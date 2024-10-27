using EdgeSearch.Interfaces;
using EdgeSearch.Models;
using System.Collections.Generic;

namespace EdgeSearch.UI
{
    public partial class ProfilesForm : AcceptCancelForm, IProfilesForm
    {
        #region Constructors and destructor
        public ProfilesForm()
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
        public void BindFields(List<Profile> profiles)
        {
            dgvProfiles.DataSource = profiles;
        }

        private void InitializeEvents()
        {
        }

        private void FinalizeEvents()
        {
        }
        #endregion
    }
}
