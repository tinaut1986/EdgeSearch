
namespace EdgeSearch.UI
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            wvSearchs = new Microsoft.Web.WebView2.WinForms.WebView2();
            progressBar = new System.Windows.Forms.ProgressBar();
            btnPlay = new System.Windows.Forms.Button();
            lblRange = new System.Windows.Forms.Label();
            lblProgress = new System.Windows.Forms.Label();
            txtURL = new System.Windows.Forms.TextBox();
            btnOpen = new System.Windows.Forms.Button();
            lblNextSearch = new System.Windows.Forms.Label();
            btnNext = new System.Windows.Forms.Button();
            chkMobile = new System.Windows.Forms.CheckBox();
            btnForce = new System.Windows.Forms.Button();
            txtUpperLimit = new System.Windows.Forms.TextBox();
            txtLowerLimit = new System.Windows.Forms.TextBox();
            lblSearches = new System.Windows.Forms.Label();
            txtSearches = new System.Windows.Forms.TextBox();
            lblPoints = new System.Windows.Forms.Label();
            txtCurrentPoints = new System.Windows.Forms.TextBox();
            txtPointsLimit = new System.Windows.Forms.TextBox();
            lblPointsSeparator = new System.Windows.Forms.Label();
            lblRefreshRangeSeparator = new System.Windows.Forms.Label();
            txtNextSearch = new System.Windows.Forms.TextBox();
            tabControl1 = new System.Windows.Forms.TabControl();
            tpSearchs = new System.Windows.Forms.TabPage();
            tpMissions = new System.Windows.Forms.TabPage();
            wvMissions = new Microsoft.Web.WebView2.WinForms.WebView2();
            ((System.ComponentModel.ISupportInitialize)wvSearchs).BeginInit();
            tabControl1.SuspendLayout();
            tpSearchs.SuspendLayout();
            tpMissions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)wvMissions).BeginInit();
            SuspendLayout();
            // 
            // wvSearchs
            // 
            wvSearchs.AllowExternalDrop = true;
            wvSearchs.CreationProperties = null;
            wvSearchs.DefaultBackgroundColor = System.Drawing.Color.White;
            wvSearchs.Dock = System.Windows.Forms.DockStyle.Fill;
            wvSearchs.Location = new System.Drawing.Point(3, 3);
            wvSearchs.Name = "wvSearchs";
            wvSearchs.Size = new System.Drawing.Size(1102, 394);
            wvSearchs.TabIndex = 3;
            wvSearchs.ZoomFactor = 1D;
            // 
            // progressBar
            // 
            progressBar.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            progressBar.Location = new System.Drawing.Point(220, 504);
            progressBar.Name = "progressBar";
            progressBar.Size = new System.Drawing.Size(838, 23);
            progressBar.TabIndex = 11;
            // 
            // btnPlay
            // 
            btnPlay.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnPlay.Location = new System.Drawing.Point(1064, 504);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new System.Drawing.Size(54, 23);
            btnPlay.TabIndex = 13;
            btnPlay.Text = "Play";
            btnPlay.UseVisualStyleBackColor = true;
            // 
            // lblRange
            // 
            lblRange.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            lblRange.AutoSize = true;
            lblRange.Location = new System.Drawing.Point(12, 508);
            lblRange.Name = "lblRange";
            lblRange.Size = new System.Drawing.Size(116, 15);
            lblRange.TabIndex = 8;
            lblRange.Text = "Refresh range (segs):";
            lblRange.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblProgress
            // 
            lblProgress.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            lblProgress.AutoSize = true;
            lblProgress.BackColor = System.Drawing.Color.Transparent;
            lblProgress.ForeColor = System.Drawing.Color.Black;
            lblProgress.Location = new System.Drawing.Point(604, 508);
            lblProgress.Name = "lblProgress";
            lblProgress.Size = new System.Drawing.Size(24, 15);
            lblProgress.TabIndex = 12;
            lblProgress.Text = "0/0";
            lblProgress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtURL
            // 
            txtURL.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtURL.Location = new System.Drawing.Point(12, 12);
            txtURL.Name = "txtURL";
            txtURL.Size = new System.Drawing.Size(965, 23);
            txtURL.TabIndex = 0;
            // 
            // btnOpen
            // 
            btnOpen.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnOpen.Location = new System.Drawing.Point(983, 12);
            btnOpen.Name = "btnOpen";
            btnOpen.Size = new System.Drawing.Size(75, 23);
            btnOpen.TabIndex = 1;
            btnOpen.Text = "Open";
            btnOpen.UseVisualStyleBackColor = true;
            // 
            // lblNextSearch
            // 
            lblNextSearch.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            lblNextSearch.Location = new System.Drawing.Point(12, 478);
            lblNextSearch.Name = "lblNextSearch";
            lblNextSearch.Size = new System.Drawing.Size(78, 19);
            lblNextSearch.TabIndex = 4;
            lblNextSearch.Text = "Next search:";
            lblNextSearch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnNext
            // 
            btnNext.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnNext.Location = new System.Drawing.Point(1064, 476);
            btnNext.Name = "btnNext";
            btnNext.Size = new System.Drawing.Size(54, 23);
            btnNext.TabIndex = 7;
            btnNext.Text = "Next";
            btnNext.UseVisualStyleBackColor = true;
            // 
            // chkMobile
            // 
            chkMobile.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            chkMobile.Appearance = System.Windows.Forms.Appearance.Button;
            chkMobile.AutoSize = true;
            chkMobile.Location = new System.Drawing.Point(1064, 11);
            chkMobile.Name = "chkMobile";
            chkMobile.Size = new System.Drawing.Size(54, 25);
            chkMobile.TabIndex = 2;
            chkMobile.Text = "Mobile";
            chkMobile.UseVisualStyleBackColor = true;
            // 
            // btnForce
            // 
            btnForce.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnForce.Location = new System.Drawing.Point(1004, 476);
            btnForce.Name = "btnForce";
            btnForce.Size = new System.Drawing.Size(54, 23);
            btnForce.TabIndex = 6;
            btnForce.Text = "Force";
            btnForce.UseVisualStyleBackColor = true;
            // 
            // txtUpperLimit
            // 
            txtUpperLimit.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            txtUpperLimit.Location = new System.Drawing.Point(186, 504);
            txtUpperLimit.Name = "txtUpperLimit";
            txtUpperLimit.Size = new System.Drawing.Size(28, 23);
            txtUpperLimit.TabIndex = 10;
            // 
            // txtLowerLimit
            // 
            txtLowerLimit.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            txtLowerLimit.Location = new System.Drawing.Point(134, 504);
            txtLowerLimit.Name = "txtLowerLimit";
            txtLowerLimit.Size = new System.Drawing.Size(28, 23);
            txtLowerLimit.TabIndex = 9;
            // 
            // lblSearches
            // 
            lblSearches.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            lblSearches.AutoSize = true;
            lblSearches.Location = new System.Drawing.Point(12, 537);
            lblSearches.Name = "lblSearches";
            lblSearches.Size = new System.Drawing.Size(56, 15);
            lblSearches.TabIndex = 14;
            lblSearches.Text = "Searches:";
            lblSearches.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSearches
            // 
            txtSearches.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            txtSearches.Location = new System.Drawing.Point(74, 533);
            txtSearches.Name = "txtSearches";
            txtSearches.Size = new System.Drawing.Size(28, 23);
            txtSearches.TabIndex = 15;
            // 
            // lblPoints
            // 
            lblPoints.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            lblPoints.AutoSize = true;
            lblPoints.Location = new System.Drawing.Point(134, 537);
            lblPoints.Name = "lblPoints";
            lblPoints.Size = new System.Drawing.Size(43, 15);
            lblPoints.TabIndex = 16;
            lblPoints.Text = "Points:";
            lblPoints.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCurrentPoints
            // 
            txtCurrentPoints.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            txtCurrentPoints.Location = new System.Drawing.Point(183, 533);
            txtCurrentPoints.Name = "txtCurrentPoints";
            txtCurrentPoints.Size = new System.Drawing.Size(28, 23);
            txtCurrentPoints.TabIndex = 17;
            // 
            // txtPointsLimit
            // 
            txtPointsLimit.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            txtPointsLimit.Location = new System.Drawing.Point(235, 533);
            txtPointsLimit.Name = "txtPointsLimit";
            txtPointsLimit.Size = new System.Drawing.Size(28, 23);
            txtPointsLimit.TabIndex = 18;
            // 
            // lblPointsSeparator
            // 
            lblPointsSeparator.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            lblPointsSeparator.AutoSize = true;
            lblPointsSeparator.Location = new System.Drawing.Point(217, 537);
            lblPointsSeparator.Name = "lblPointsSeparator";
            lblPointsSeparator.Size = new System.Drawing.Size(12, 15);
            lblPointsSeparator.TabIndex = 14;
            lblPointsSeparator.Text = "/";
            lblPointsSeparator.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRefreshRangeSeparator
            // 
            lblRefreshRangeSeparator.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            lblRefreshRangeSeparator.AutoSize = true;
            lblRefreshRangeSeparator.Location = new System.Drawing.Point(168, 508);
            lblRefreshRangeSeparator.Name = "lblRefreshRangeSeparator";
            lblRefreshRangeSeparator.Size = new System.Drawing.Size(12, 15);
            lblRefreshRangeSeparator.TabIndex = 14;
            lblRefreshRangeSeparator.Text = "-";
            lblRefreshRangeSeparator.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNextSearch
            // 
            txtNextSearch.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            txtNextSearch.Location = new System.Drawing.Point(96, 476);
            txtNextSearch.Name = "txtNextSearch";
            txtNextSearch.Size = new System.Drawing.Size(902, 23);
            txtNextSearch.TabIndex = 9;
            // 
            // tabControl1
            // 
            tabControl1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tabControl1.Controls.Add(tpSearchs);
            tabControl1.Controls.Add(tpMissions);
            tabControl1.Location = new System.Drawing.Point(2, 42);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new System.Drawing.Size(1116, 428);
            tabControl1.TabIndex = 19;
            // 
            // tpSearchs
            // 
            tpSearchs.Controls.Add(wvSearchs);
            tpSearchs.Location = new System.Drawing.Point(4, 24);
            tpSearchs.Name = "tpSearchs";
            tpSearchs.Padding = new System.Windows.Forms.Padding(3);
            tpSearchs.Size = new System.Drawing.Size(1108, 400);
            tpSearchs.TabIndex = 0;
            tpSearchs.Text = "Searchs";
            tpSearchs.UseVisualStyleBackColor = true;
            // 
            // tpMissions
            // 
            tpMissions.Controls.Add(wvMissions);
            tpMissions.Location = new System.Drawing.Point(4, 24);
            tpMissions.Name = "tpMissions";
            tpMissions.Padding = new System.Windows.Forms.Padding(3);
            tpMissions.Size = new System.Drawing.Size(1108, 442);
            tpMissions.TabIndex = 1;
            tpMissions.Text = "Missions";
            tpMissions.UseVisualStyleBackColor = true;
            // 
            // wvMissions
            // 
            wvMissions.AllowExternalDrop = true;
            wvMissions.CreationProperties = null;
            wvMissions.DefaultBackgroundColor = System.Drawing.Color.White;
            wvMissions.Dock = System.Windows.Forms.DockStyle.Fill;
            wvMissions.Location = new System.Drawing.Point(3, 3);
            wvMissions.Name = "wvMissions";
            wvMissions.Size = new System.Drawing.Size(1102, 436);
            wvMissions.TabIndex = 0;
            wvMissions.ZoomFactor = 1D;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1130, 570);
            Controls.Add(tabControl1);
            Controls.Add(txtSearches);
            Controls.Add(txtCurrentPoints);
            Controls.Add(txtNextSearch);
            Controls.Add(txtLowerLimit);
            Controls.Add(txtPointsLimit);
            Controls.Add(txtUpperLimit);
            Controls.Add(chkMobile);
            Controls.Add(txtURL);
            Controls.Add(lblProgress);
            Controls.Add(lblNextSearch);
            Controls.Add(lblPoints);
            Controls.Add(lblRefreshRangeSeparator);
            Controls.Add(lblPointsSeparator);
            Controls.Add(lblSearches);
            Controls.Add(lblRange);
            Controls.Add(btnOpen);
            Controls.Add(btnForce);
            Controls.Add(btnNext);
            Controls.Add(btnPlay);
            Controls.Add(progressBar);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            Text = "Edge search";
            ((System.ComponentModel.ISupportInitialize)wvSearchs).EndInit();
            tabControl1.ResumeLayout(false);
            tpSearchs.ResumeLayout(false);
            tpMissions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)wvMissions).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Microsoft.Web.WebView2.WinForms.WebView2 wvSearchs;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Label lblRange;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Label lblNextSearch;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.CheckBox chkMobile;
        private System.Windows.Forms.Button btnForce;
        private System.Windows.Forms.TextBox txtUpperLimit;
        private System.Windows.Forms.TextBox txtLowerLimit;
        private System.Windows.Forms.Label lblSearches;
        private System.Windows.Forms.TextBox txtSearches;
        private System.Windows.Forms.Label lblPoints;
        private System.Windows.Forms.TextBox txtCurrentPoints;
        private System.Windows.Forms.TextBox txtPointsLimit;
        private System.Windows.Forms.Label lblPointsSeparator;
        private System.Windows.Forms.Label lblRefreshRangeSeparator;
        private System.Windows.Forms.TextBox txtNextSearch;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpSearchs;
        private System.Windows.Forms.TabPage tpMissions;
        private Microsoft.Web.WebView2.WinForms.WebView2 wvMissions;
    }
}

