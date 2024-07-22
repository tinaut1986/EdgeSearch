
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
            btnPlay = new System.Windows.Forms.Button();
            lblRange = new System.Windows.Forms.Label();
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
            pbSearches = new CustomProgressBar();
            tpRewards = new System.Windows.Forms.TabPage();
            pbRewards = new CustomProgressBar();
            lblRewards = new System.Windows.Forms.Label();
            wvRewards = new Microsoft.Web.WebView2.WinForms.WebView2();
            tpAmbassadors = new System.Windows.Forms.TabPage();
            pbAmbassadors = new CustomProgressBar();
            lblAmbassadors = new System.Windows.Forms.Label();
            wvAmbassadors = new Microsoft.Web.WebView2.WinForms.WebView2();
            menuStrip1 = new System.Windows.Forms.MenuStrip();
            fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            tsmiPlay = new System.Windows.Forms.ToolStripMenuItem();
            tsmiReset = new System.Windows.Forms.ToolStripMenuItem();
            searchesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            rewardsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            tsmiOpenRewards = new System.Windows.Forms.ToolStripMenuItem();
            ambassadorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            tsmiOpenAmbassadors = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)wvSearches).BeginInit();
            tabControl1.SuspendLayout();
            tpSearches.SuspendLayout();
            tpRewards.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)wvRewards).BeginInit();
            tpAmbassadors.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)wvAmbassadors).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // wvSearches
            // 
            wvSearches.AllowExternalDrop = true;
            wvSearches.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            wvSearches.CreationProperties = null;
            wvSearches.DefaultBackgroundColor = System.Drawing.Color.White;
            wvSearches.Location = new System.Drawing.Point(12, 35);
            wvSearches.Name = "wvSearches";
            wvSearches.Size = new System.Drawing.Size(1199, 400);
            wvSearches.TabIndex = 3;
            wvSearches.ZoomFactor = 1D;
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
            tabControl1.Controls.Add(tpAmbassadors);
            tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControl1.Location = new System.Drawing.Point(0, 24);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new System.Drawing.Size(1219, 527);
            tabControl1.TabIndex = 19;
            // 
            // tpSearches
            // 
            tpSearches.Controls.Add(pbSearches);
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
            // pbSearches
            // 
            pbSearches.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            pbSearches.ForeColor = System.Drawing.Color.Black;
            pbSearches.Location = new System.Drawing.Point(445, 470);
            pbSearches.Name = "pbSearches";
            pbSearches.PaintedColor = System.Drawing.Color.Green;
            pbSearches.PaintedForeColor = System.Drawing.Color.White;
            pbSearches.Size = new System.Drawing.Size(700, 23);
            pbSearches.TabIndex = 19;
            // 
            // tpRewards
            // 
            tpRewards.Controls.Add(pbRewards);
            tpRewards.Controls.Add(lblRewards);
            tpRewards.Controls.Add(wvRewards);
            tpRewards.Location = new System.Drawing.Point(4, 24);
            tpRewards.Name = "tpRewards";
            tpRewards.Padding = new System.Windows.Forms.Padding(3);
            tpRewards.Size = new System.Drawing.Size(1211, 499);
            tpRewards.TabIndex = 1;
            tpRewards.Text = "Rewards";
            tpRewards.UseVisualStyleBackColor = true;
            // 
            // pbRewards
            // 
            pbRewards.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            pbRewards.ForeColor = System.Drawing.Color.Black;
            pbRewards.Location = new System.Drawing.Point(104, 470);
            pbRewards.Name = "pbRewards";
            pbRewards.PaintedColor = System.Drawing.Color.Green;
            pbRewards.PaintedForeColor = System.Drawing.Color.White;
            pbRewards.Size = new System.Drawing.Size(1104, 23);
            pbRewards.TabIndex = 7;
            // 
            // lblRewards
            // 
            lblRewards.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            lblRewards.AutoSize = true;
            lblRewards.Location = new System.Drawing.Point(6, 474);
            lblRewards.Name = "lblRewards";
            lblRewards.Size = new System.Drawing.Size(92, 15);
            lblRewards.TabIndex = 5;
            lblRewards.Text = "Opening reward";
            lblRewards.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // wvRewards
            // 
            wvRewards.AllowExternalDrop = true;
            wvRewards.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            wvRewards.CreationProperties = null;
            wvRewards.DefaultBackgroundColor = System.Drawing.Color.White;
            wvRewards.Location = new System.Drawing.Point(3, 3);
            wvRewards.Name = "wvRewards";
            wvRewards.Size = new System.Drawing.Size(1205, 461);
            wvRewards.TabIndex = 0;
            wvRewards.ZoomFactor = 1D;
            // 
            // tpAmbassadors
            // 
            tpAmbassadors.Controls.Add(pbAmbassadors);
            tpAmbassadors.Controls.Add(lblAmbassadors);
            tpAmbassadors.Controls.Add(wvAmbassadors);
            tpAmbassadors.Location = new System.Drawing.Point(4, 24);
            tpAmbassadors.Name = "tpAmbassadors";
            tpAmbassadors.Padding = new System.Windows.Forms.Padding(3);
            tpAmbassadors.Size = new System.Drawing.Size(1211, 499);
            tpAmbassadors.TabIndex = 2;
            tpAmbassadors.Text = "Ambassadors";
            tpAmbassadors.UseVisualStyleBackColor = true;
            // 
            // pbAmbassadors
            // 
            pbAmbassadors.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            pbAmbassadors.ForeColor = System.Drawing.Color.Black;
            pbAmbassadors.Location = new System.Drawing.Point(132, 470);
            pbAmbassadors.Name = "pbAmbassadors";
            pbAmbassadors.PaintedColor = System.Drawing.Color.Green;
            pbAmbassadors.PaintedForeColor = System.Drawing.Color.White;
            pbAmbassadors.Size = new System.Drawing.Size(1076, 23);
            pbAmbassadors.TabIndex = 9;
            // 
            // lblAmbassadors
            // 
            lblAmbassadors.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            lblAmbassadors.AutoSize = true;
            lblAmbassadors.Location = new System.Drawing.Point(6, 474);
            lblAmbassadors.Name = "lblAmbassadors";
            lblAmbassadors.Size = new System.Drawing.Size(120, 15);
            lblAmbassadors.TabIndex = 7;
            lblAmbassadors.Text = "Opening ambassador";
            lblAmbassadors.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // wvAmbassadors
            // 
            wvAmbassadors.AllowExternalDrop = true;
            wvAmbassadors.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            wvAmbassadors.CreationProperties = null;
            wvAmbassadors.DefaultBackgroundColor = System.Drawing.Color.White;
            wvAmbassadors.Location = new System.Drawing.Point(3, 3);
            wvAmbassadors.Name = "wvAmbassadors";
            wvAmbassadors.Size = new System.Drawing.Size(1205, 461);
            wvAmbassadors.TabIndex = 1;
            wvAmbassadors.ZoomFactor = 1D;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { fileToolStripMenuItem, searchesToolStripMenuItem, rewardsToolStripMenuItem, ambassadorsToolStripMenuItem });
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
            tsmiPlay.Size = new System.Drawing.Size(102, 22);
            tsmiPlay.Text = "Play";
            // 
            // tsmiReset
            // 
            tsmiReset.Name = "tsmiReset";
            tsmiReset.Size = new System.Drawing.Size(102, 22);
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
            // ambassadorsToolStripMenuItem
            // 
            ambassadorsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { tsmiOpenAmbassadors });
            ambassadorsToolStripMenuItem.Name = "ambassadorsToolStripMenuItem";
            ambassadorsToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            ambassadorsToolStripMenuItem.Text = "Ambassadors";
            // 
            // tsmiOpenAmbassadors
            // 
            tsmiOpenAmbassadors.Name = "tsmiOpenAmbassadors";
            tsmiOpenAmbassadors.Size = new System.Drawing.Size(175, 22);
            tsmiOpenAmbassadors.Text = "Open ambassadors";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1219, 551);
            Controls.Add(tabControl1);
            Controls.Add(menuStrip1);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Text = "Edge search";
            ((System.ComponentModel.ISupportInitialize)wvSearches).EndInit();
            tabControl1.ResumeLayout(false);
            tpSearches.ResumeLayout(false);
            tpSearches.PerformLayout();
            tpRewards.ResumeLayout(false);
            tpRewards.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)wvRewards).EndInit();
            tpAmbassadors.ResumeLayout(false);
            tpAmbassadors.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)wvAmbassadors).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Microsoft.Web.WebView2.WinForms.WebView2 wvSearches;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Label lblRange;
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
        private System.Windows.Forms.Label lblRewards;
        private System.Windows.Forms.TabPage tpAmbassadors;
        private Microsoft.Web.WebView2.WinForms.WebView2 wvAmbassadors;
        private System.Windows.Forms.Label lblAmbassadors;
        private System.Windows.Forms.ToolStripMenuItem ambassadorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpenAmbassadors;
        private CustomProgressBar pbSearches;
        private CustomProgressBar pbRewards;
        private CustomProgressBar pbAmbassadors;
    }
}

