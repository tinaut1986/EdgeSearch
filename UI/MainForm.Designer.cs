
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
            wvSearches = new Microsoft.Web.WebView2.WinForms.WebView2();
            progressBar = new System.Windows.Forms.ProgressBar();
            btnPlay = new System.Windows.Forms.Button();
            lblRange = new System.Windows.Forms.Label();
            lblProgress = new System.Windows.Forms.Label();
            txtURL = new System.Windows.Forms.TextBox();
            btnOpen = new System.Windows.Forms.Button();
            lblNextSearch = new System.Windows.Forms.Label();
            btnNext = new System.Windows.Forms.Button();
            chkMobile = new System.Windows.Forms.CheckBox();
            btnSearch = new System.Windows.Forms.Button();
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
            tpSearches = new System.Windows.Forms.TabPage();
            tpRewards = new System.Windows.Forms.TabPage();
            wvRewards = new Microsoft.Web.WebView2.WinForms.WebView2();
            menuStrip1 = new System.Windows.Forms.MenuStrip();
            fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            tsmiPlay = new System.Windows.Forms.ToolStripMenuItem();
            tsmiReset = new System.Windows.Forms.ToolStripMenuItem();
            searchesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            rewardsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            tsmiOpenRewards = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)wvSearches).BeginInit();
            tabControl1.SuspendLayout();
            tpSearches.SuspendLayout();
            tpRewards.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)wvRewards).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // wvSearches
            // 
            wvSearches.AllowExternalDrop = true;
            wvSearches.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            wvSearches.CreationProperties = null;
            wvSearches.DefaultBackgroundColor = System.Drawing.Color.White;
            wvSearches.Location = new System.Drawing.Point(6, 35);
            wvSearches.Name = "wvSearches";
            wvSearches.Size = new System.Drawing.Size(1199, 400);
            wvSearches.TabIndex = 3;
            wvSearches.ZoomFactor = 1D;
            // 
            // progressBar
            // 
            progressBar.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            progressBar.Location = new System.Drawing.Point(445, 470);
            progressBar.Name = "progressBar";
            progressBar.Size = new System.Drawing.Size(700, 23);
            progressBar.TabIndex = 11;
            // 
            // btnPlay
            // 
            btnPlay.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnPlay.Location = new System.Drawing.Point(1151, 470);
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
            lblRange.Location = new System.Drawing.Point(237, 474);
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
            lblProgress.Location = new System.Drawing.Point(782, 474);
            lblProgress.Name = "lblProgress";
            lblProgress.Size = new System.Drawing.Size(24, 15);
            lblProgress.TabIndex = 12;
            lblProgress.Text = "0/0";
            lblProgress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtURL
            // 
            txtURL.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtURL.Location = new System.Drawing.Point(6, 6);
            txtURL.Name = "txtURL";
            txtURL.Size = new System.Drawing.Size(1058, 23);
            txtURL.TabIndex = 0;
            // 
            // btnOpen
            // 
            btnOpen.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnOpen.Location = new System.Drawing.Point(1070, 6);
            btnOpen.Name = "btnOpen";
            btnOpen.Size = new System.Drawing.Size(75, 23);
            btnOpen.TabIndex = 1;
            btnOpen.Text = "Open";
            btnOpen.UseVisualStyleBackColor = true;
            // 
            // lblNextSearch
            // 
            lblNextSearch.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            lblNextSearch.Location = new System.Drawing.Point(6, 443);
            lblNextSearch.Name = "lblNextSearch";
            lblNextSearch.Size = new System.Drawing.Size(78, 19);
            lblNextSearch.TabIndex = 4;
            lblNextSearch.Text = "Next search:";
            lblNextSearch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnNext
            // 
            btnNext.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnNext.Location = new System.Drawing.Point(1089, 441);
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
            chkMobile.Location = new System.Drawing.Point(1151, 6);
            chkMobile.Name = "chkMobile";
            chkMobile.Size = new System.Drawing.Size(54, 25);
            chkMobile.TabIndex = 2;
            chkMobile.Text = "Mobile";
            chkMobile.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            btnSearch.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnSearch.Location = new System.Drawing.Point(1149, 441);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new System.Drawing.Size(54, 23);
            btnSearch.TabIndex = 6;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            // 
            // txtUpperLimit
            // 
            txtUpperLimit.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            txtUpperLimit.Location = new System.Drawing.Point(411, 470);
            txtUpperLimit.Name = "txtUpperLimit";
            txtUpperLimit.Size = new System.Drawing.Size(28, 23);
            txtUpperLimit.TabIndex = 10;
            // 
            // txtLowerLimit
            // 
            txtLowerLimit.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            txtLowerLimit.Location = new System.Drawing.Point(359, 470);
            txtLowerLimit.Name = "txtLowerLimit";
            txtLowerLimit.Size = new System.Drawing.Size(28, 23);
            txtLowerLimit.TabIndex = 9;
            // 
            // lblSearches
            // 
            lblSearches.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            lblSearches.AutoSize = true;
            lblSearches.Location = new System.Drawing.Point(6, 474);
            lblSearches.Name = "lblSearches";
            lblSearches.Size = new System.Drawing.Size(56, 15);
            lblSearches.TabIndex = 14;
            lblSearches.Text = "Searches:";
            lblSearches.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSearches
            // 
            txtSearches.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            txtSearches.Location = new System.Drawing.Point(68, 470);
            txtSearches.Name = "txtSearches";
            txtSearches.Size = new System.Drawing.Size(28, 23);
            txtSearches.TabIndex = 15;
            // 
            // lblPoints
            // 
            lblPoints.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            lblPoints.AutoSize = true;
            lblPoints.Location = new System.Drawing.Point(102, 474);
            lblPoints.Name = "lblPoints";
            lblPoints.Size = new System.Drawing.Size(43, 15);
            lblPoints.TabIndex = 16;
            lblPoints.Text = "Points:";
            lblPoints.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCurrentPoints
            // 
            txtCurrentPoints.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            txtCurrentPoints.Location = new System.Drawing.Point(151, 470);
            txtCurrentPoints.Name = "txtCurrentPoints";
            txtCurrentPoints.Size = new System.Drawing.Size(28, 23);
            txtCurrentPoints.TabIndex = 17;
            // 
            // txtPointsLimit
            // 
            txtPointsLimit.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            txtPointsLimit.Location = new System.Drawing.Point(203, 470);
            txtPointsLimit.Name = "txtPointsLimit";
            txtPointsLimit.Size = new System.Drawing.Size(28, 23);
            txtPointsLimit.TabIndex = 18;
            // 
            // lblPointsSeparator
            // 
            lblPointsSeparator.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            lblPointsSeparator.AutoSize = true;
            lblPointsSeparator.Location = new System.Drawing.Point(185, 474);
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
            lblRefreshRangeSeparator.Location = new System.Drawing.Point(393, 474);
            lblRefreshRangeSeparator.Name = "lblRefreshRangeSeparator";
            lblRefreshRangeSeparator.Size = new System.Drawing.Size(12, 15);
            lblRefreshRangeSeparator.TabIndex = 14;
            lblRefreshRangeSeparator.Text = "-";
            lblRefreshRangeSeparator.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNextSearch
            // 
            txtNextSearch.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtNextSearch.Location = new System.Drawing.Point(90, 441);
            txtNextSearch.Name = "txtNextSearch";
            txtNextSearch.Size = new System.Drawing.Size(993, 23);
            txtNextSearch.TabIndex = 9;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tpSearches);
            tabControl1.Controls.Add(tpRewards);
            tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControl1.Location = new System.Drawing.Point(0, 24);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new System.Drawing.Size(1219, 527);
            tabControl1.TabIndex = 19;
            // 
            // tpSearches
            // 
            tpSearches.Controls.Add(lblProgress);
            tpSearches.Controls.Add(progressBar);
            tpSearches.Controls.Add(wvSearches);
            tpSearches.Controls.Add(txtSearches);
            tpSearches.Controls.Add(txtURL);
            tpSearches.Controls.Add(txtCurrentPoints);
            tpSearches.Controls.Add(chkMobile);
            tpSearches.Controls.Add(txtNextSearch);
            tpSearches.Controls.Add(btnOpen);
            tpSearches.Controls.Add(txtLowerLimit);
            tpSearches.Controls.Add(lblNextSearch);
            tpSearches.Controls.Add(txtPointsLimit);
            tpSearches.Controls.Add(txtUpperLimit);
            tpSearches.Controls.Add(btnPlay);
            tpSearches.Controls.Add(btnNext);
            tpSearches.Controls.Add(btnSearch);
            tpSearches.Controls.Add(lblPoints);
            tpSearches.Controls.Add(lblRange);
            tpSearches.Controls.Add(lblRefreshRangeSeparator);
            tpSearches.Controls.Add(lblSearches);
            tpSearches.Controls.Add(lblPointsSeparator);
            tpSearches.Location = new System.Drawing.Point(4, 24);
            tpSearches.Name = "tpSearches";
            tpSearches.Padding = new System.Windows.Forms.Padding(3);
            tpSearches.Size = new System.Drawing.Size(1211, 499);
            tpSearches.TabIndex = 0;
            tpSearches.Text = "Searches";
            tpSearches.UseVisualStyleBackColor = true;
            // 
            // tpRewards
            // 
            tpRewards.Controls.Add(wvRewards);
            tpRewards.Location = new System.Drawing.Point(4, 24);
            tpRewards.Name = "tpRewards";
            tpRewards.Padding = new System.Windows.Forms.Padding(3);
            tpRewards.Size = new System.Drawing.Size(1211, 499);
            tpRewards.TabIndex = 1;
            tpRewards.Text = "Rewards";
            tpRewards.UseVisualStyleBackColor = true;
            // 
            // wvRewards
            // 
            wvRewards.AllowExternalDrop = true;
            wvRewards.CreationProperties = null;
            wvRewards.DefaultBackgroundColor = System.Drawing.Color.White;
            wvRewards.Dock = System.Windows.Forms.DockStyle.Fill;
            wvRewards.Location = new System.Drawing.Point(3, 3);
            wvRewards.Name = "wvRewards";
            wvRewards.Size = new System.Drawing.Size(1205, 493);
            wvRewards.TabIndex = 0;
            wvRewards.ZoomFactor = 1D;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { fileToolStripMenuItem, searchesToolStripMenuItem, rewardsToolStripMenuItem });
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new System.Drawing.Size(1219, 24);
            menuStrip1.TabIndex = 20;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { tsmiPlay, tsmiReset });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // tsmiPlay
            // 
            tsmiPlay.Name = "tsmiPlay";
            tsmiPlay.Size = new System.Drawing.Size(180, 22);
            tsmiPlay.Text = "Play";
            // 
            // tsmiReset
            // 
            tsmiReset.Name = "tsmiReset";
            tsmiReset.Size = new System.Drawing.Size(180, 22);
            tsmiReset.Text = "Reset";
            // 
            // searchesToolStripMenuItem
            // 
            searchesToolStripMenuItem.Name = "searchesToolStripMenuItem";
            searchesToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            searchesToolStripMenuItem.Text = "Searches";
            // 
            // rewardsToolStripMenuItem
            // 
            rewardsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { tsmiOpenRewards });
            rewardsToolStripMenuItem.Name = "rewardsToolStripMenuItem";
            rewardsToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            rewardsToolStripMenuItem.Text = "Rewards";
            // 
            // tsmiOpenRewards
            // 
            tsmiOpenRewards.Name = "tsmiOpenRewards";
            tsmiOpenRewards.Size = new System.Drawing.Size(147, 22);
            tsmiOpenRewards.Text = "Open rewards";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1219, 551);
            Controls.Add(tabControl1);
            Controls.Add(menuStrip1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Text = "Edge search";
            ((System.ComponentModel.ISupportInitialize)wvSearches).EndInit();
            tabControl1.ResumeLayout(false);
            tpSearches.ResumeLayout(false);
            tpSearches.PerformLayout();
            tpRewards.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)wvRewards).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Microsoft.Web.WebView2.WinForms.WebView2 wvSearches;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Label lblRange;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Label lblNextSearch;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.CheckBox chkMobile;
        private System.Windows.Forms.Button btnSearch;
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
        private System.Windows.Forms.TabPage tpSearches;
        private System.Windows.Forms.TabPage tpRewards;
        private Microsoft.Web.WebView2.WinForms.WebView2 wvRewards;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiReset;
        private System.Windows.Forms.ToolStripMenuItem tsmiPlay;
        private System.Windows.Forms.ToolStripMenuItem searchesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rewardsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpenRewards;
    }
}

