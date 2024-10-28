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
            colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvProfiles).BeginInit();
            SuspendLayout();
            // 
            // dgvProfiles
            // 
            dgvProfiles.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgvProfiles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dgvProfiles.BackgroundColor = System.Drawing.Color.White;
            dgvProfiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProfiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { colName, colPath });
            dgvProfiles.Location = new System.Drawing.Point(12, 12);
            dgvProfiles.Name = "dgvProfiles";
            dgvProfiles.Size = new System.Drawing.Size(727, 346);
            dgvProfiles.TabIndex = 0;
            // 
            // colName
            // 
            colName.DataPropertyName = "Name";
            colName.HeaderText = "Name";
            colName.Name = "colName";
            colName.Width = 64;
            // 
            // colPath
            // 
            colPath.DataPropertyName = "Path";
            colPath.HeaderText = "Path";
            colPath.Name = "colPath";
            colPath.ReadOnly = true;
            colPath.Width = 56;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPath;
    }
}