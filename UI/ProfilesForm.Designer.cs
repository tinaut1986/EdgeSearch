namespace EdgeSearch.UI
{
    partial class ProfilesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvProfiles = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvProfiles).BeginInit();
            SuspendLayout();
            // 
            // dgvProfiles
            // 
            dgvProfiles.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgvProfiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProfiles.Location = new System.Drawing.Point(12, 12);
            dgvProfiles.Name = "dgvProfiles";
            dgvProfiles.Size = new System.Drawing.Size(727, 346);
            dgvProfiles.TabIndex = 0;
            // 
            // ProfilesForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(751, 397);
            Controls.Add(dgvProfiles);
            Name = "ProfilesForm";
            Text = "Profiles";
            Controls.SetChildIndex(dgvProfiles, 0);
            ((System.ComponentModel.ISupportInitialize)dgvProfiles).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProfiles;
    }
}