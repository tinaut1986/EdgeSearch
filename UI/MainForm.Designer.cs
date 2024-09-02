
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
            components = new System.ComponentModel.Container();
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
            tpRewards = new System.Windows.Forms.TabPage();
            wvRewards = new Microsoft.Web.WebView2.WinForms.WebView2();
            tpAmbassadors = new System.Windows.Forms.TabPage();
            wvAmbassadors = new Microsoft.Web.WebView2.WinForms.WebView2();
            pbSearches = new CustomProgressBar();
            menuStrip1 = new System.Windows.Forms.MenuStrip();
            fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            tsmiPlay = new System.Windows.Forms.ToolStripMenuItem();
            tsmiReset = new System.Windows.Forms.ToolStripMenuItem();
            searchesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            tsmiPlaySearches = new System.Windows.Forms.ToolStripMenuItem();
            rewardsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            tsmiPlayRewards = new System.Windows.Forms.ToolStripMenuItem();
            ambassadorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            tsmiPlayAmbassadors = new System.Windows.Forms.ToolStripMenuItem();
            optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            tsmISettings = new System.Windows.Forms.ToolStripMenuItem();
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            panel1 = new System.Windows.Forms.Panel();
            panel2 = new System.Windows.Forms.Panel();
            lblAmbassadorsPB = new System.Windows.Forms.Label();
            lblRewardsPB = new System.Windows.Forms.Label();
            lblSearchesPB = new System.Windows.Forms.Label();
            toolTip1 = new System.Windows.Forms.ToolTip(components);
            ((System.ComponentModel.ISupportInitialize)wvSearches).BeginInit();
            tabControl1.SuspendLayout();
            tpSearches.SuspendLayout();
            tpRewards.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)wvRewards).BeginInit();
            tpAmbassadors.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)wvAmbassadors).BeginInit();
            menuStrip1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
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
            wvSearches.Size = new System.Drawing.Size(1193, 382);
            wvSearches.TabIndex = 3;
            wvSearches.ZoomFactor = 1D;
            // 
            // btnPlay
            // 
            btnPlay.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnPlay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            btnPlay.Image = Properties.Resources.play;
            btnPlay.Location = new System.Drawing.Point(1180, 2);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new System.Drawing.Size(25, 25);
            btnPlay.TabIndex = 13;
            btnPlay.UseVisualStyleBackColor = true;
            // 
            // lblRange
            // 
            lblRange.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            lblRange.AutoSize = true;
            lblRange.Location = new System.Drawing.Point(240, 7);
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
            txtURL.Size = new System.Drawing.Size(1135, 23);
            txtURL.TabIndex = 0;
            // 
            // btnOpen
            // 
            btnOpen.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnOpen.Image = Properties.Resources.open_url;
            btnOpen.Location = new System.Drawing.Point(1147, 5);
            btnOpen.Name = "btnOpen";
            btnOpen.Size = new System.Drawing.Size(25, 25);
            btnOpen.TabIndex = 1;
            btnOpen.UseVisualStyleBackColor = true;
            // 
            // lblNextSearch
            // 
            lblNextSearch.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            lblNextSearch.Location = new System.Drawing.Point(448, 5);
            lblNextSearch.Name = "lblNextSearch";
            lblNextSearch.Size = new System.Drawing.Size(78, 19);
            lblNextSearch.TabIndex = 4;
            lblNextSearch.Text = "Next search:";
            lblNextSearch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnNext
            // 
            btnNext.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnNext.Image = Properties.Resources.update;
            btnNext.Location = new System.Drawing.Point(1151, 2);
            btnNext.Name = "btnNext";
            btnNext.Size = new System.Drawing.Size(25, 25);
            btnNext.TabIndex = 7;
            btnNext.UseVisualStyleBackColor = true;
            // 
            // chkMobile
            // 
            chkMobile.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            chkMobile.Appearance = System.Windows.Forms.Appearance.Button;
            chkMobile.Image = Properties.Resources.mobile;
            chkMobile.Location = new System.Drawing.Point(1176, 5);
            chkMobile.Name = "chkMobile";
            chkMobile.Size = new System.Drawing.Size(25, 25);
            chkMobile.TabIndex = 2;
            chkMobile.Tag = "";
            chkMobile.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            btnSearch.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnSearch.Image = Properties.Resources.search;
            btnSearch.Location = new System.Drawing.Point(1180, 2);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new System.Drawing.Size(25, 25);
            btnSearch.TabIndex = 6;
            btnSearch.UseVisualStyleBackColor = true;
            // 
            // txtUpperLimit
            // 
            txtUpperLimit.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            txtUpperLimit.Location = new System.Drawing.Point(414, 3);
            txtUpperLimit.Name = "txtUpperLimit";
            txtUpperLimit.Size = new System.Drawing.Size(28, 23);
            txtUpperLimit.TabIndex = 10;
            // 
            // txtLowerLimit
            // 
            txtLowerLimit.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            txtLowerLimit.Location = new System.Drawing.Point(362, 3);
            txtLowerLimit.Name = "txtLowerLimit";
            txtLowerLimit.Size = new System.Drawing.Size(28, 23);
            txtLowerLimit.TabIndex = 9;
            // 
            // lblSearches
            // 
            lblSearches.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            lblSearches.AutoSize = true;
            lblSearches.Location = new System.Drawing.Point(9, 7);
            lblSearches.Name = "lblSearches";
            lblSearches.Size = new System.Drawing.Size(56, 15);
            lblSearches.TabIndex = 14;
            lblSearches.Text = "Searches:";
            lblSearches.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSearches
            // 
            txtSearches.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            txtSearches.Location = new System.Drawing.Point(71, 3);
            txtSearches.Name = "txtSearches";
            txtSearches.Size = new System.Drawing.Size(28, 23);
            txtSearches.TabIndex = 15;
            // 
            // lblPoints
            // 
            lblPoints.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            lblPoints.AutoSize = true;
            lblPoints.Location = new System.Drawing.Point(105, 7);
            lblPoints.Name = "lblPoints";
            lblPoints.Size = new System.Drawing.Size(43, 15);
            lblPoints.TabIndex = 16;
            lblPoints.Text = "Points:";
            lblPoints.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCurrentPoints
            // 
            txtCurrentPoints.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            txtCurrentPoints.Location = new System.Drawing.Point(154, 3);
            txtCurrentPoints.Name = "txtCurrentPoints";
            txtCurrentPoints.Size = new System.Drawing.Size(28, 23);
            txtCurrentPoints.TabIndex = 17;
            // 
            // txtPointsLimit
            // 
            txtPointsLimit.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            txtPointsLimit.Location = new System.Drawing.Point(206, 3);
            txtPointsLimit.Name = "txtPointsLimit";
            txtPointsLimit.Size = new System.Drawing.Size(28, 23);
            txtPointsLimit.TabIndex = 18;
            // 
            // lblPointsSeparator
            // 
            lblPointsSeparator.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            lblPointsSeparator.AutoSize = true;
            lblPointsSeparator.Location = new System.Drawing.Point(188, 7);
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
            lblRefreshRangeSeparator.Location = new System.Drawing.Point(396, 7);
            lblRefreshRangeSeparator.Name = "lblRefreshRangeSeparator";
            lblRefreshRangeSeparator.Size = new System.Drawing.Size(12, 15);
            lblRefreshRangeSeparator.TabIndex = 14;
            lblRefreshRangeSeparator.Text = "-";
            lblRefreshRangeSeparator.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNextSearch
            // 
            txtNextSearch.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtNextSearch.Location = new System.Drawing.Point(532, 3);
            txtNextSearch.Name = "txtNextSearch";
            txtNextSearch.Size = new System.Drawing.Size(613, 23);
            txtNextSearch.TabIndex = 9;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tpSearches);
            tabControl1.Controls.Add(tpRewards);
            tabControl1.Controls.Add(tpAmbassadors);
            tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControl1.Location = new System.Drawing.Point(3, 3);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new System.Drawing.Size(1213, 451);
            tabControl1.TabIndex = 19;
            // 
            // tpSearches
            // 
            tpSearches.Controls.Add(wvSearches);
            tpSearches.Controls.Add(txtURL);
            tpSearches.Controls.Add(chkMobile);
            tpSearches.Controls.Add(btnOpen);
            tpSearches.Location = new System.Drawing.Point(4, 24);
            tpSearches.Name = "tpSearches";
            tpSearches.Padding = new System.Windows.Forms.Padding(3);
            tpSearches.Size = new System.Drawing.Size(1205, 423);
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
            tpRewards.Size = new System.Drawing.Size(1205, 423);
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
            wvRewards.Size = new System.Drawing.Size(1199, 417);
            wvRewards.TabIndex = 0;
            wvRewards.ZoomFactor = 1D;
            // 
            // tpAmbassadors
            // 
            tpAmbassadors.Controls.Add(wvAmbassadors);
            tpAmbassadors.Location = new System.Drawing.Point(4, 24);
            tpAmbassadors.Name = "tpAmbassadors";
            tpAmbassadors.Padding = new System.Windows.Forms.Padding(3);
            tpAmbassadors.Size = new System.Drawing.Size(1205, 423);
            tpAmbassadors.TabIndex = 2;
            tpAmbassadors.Text = "Ambassadors";
            tpAmbassadors.UseVisualStyleBackColor = true;
            // 
            // wvAmbassadors
            // 
            wvAmbassadors.AllowExternalDrop = true;
            wvAmbassadors.CreationProperties = null;
            wvAmbassadors.DefaultBackgroundColor = System.Drawing.Color.White;
            wvAmbassadors.Dock = System.Windows.Forms.DockStyle.Fill;
            wvAmbassadors.Location = new System.Drawing.Point(3, 3);
            wvAmbassadors.Name = "wvAmbassadors";
            wvAmbassadors.Size = new System.Drawing.Size(1199, 417);
            wvAmbassadors.TabIndex = 1;
            wvAmbassadors.ZoomFactor = 1D;
            // 
            // pbSearches
            // 
            pbSearches.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            pbSearches.ForeColor = System.Drawing.Color.Black;
            pbSearches.Location = new System.Drawing.Point(66, 3);
            pbSearches.Name = "pbSearches";
            pbSearches.PaintedColor = System.Drawing.Color.Green;
            pbSearches.PaintedForeColor = System.Drawing.Color.White;
            pbSearches.Size = new System.Drawing.Size(324, 23);
            pbSearches.TabIndex = 19;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { fileToolStripMenuItem, searchesToolStripMenuItem, rewardsToolStripMenuItem, ambassadorsToolStripMenuItem, optionsToolStripMenuItem });
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
            tsmiPlay.Image = Properties.Resources.play;
            tsmiPlay.Name = "tsmiPlay";
            tsmiPlay.Size = new System.Drawing.Size(102, 22);
            tsmiPlay.Text = "Play";
            // 
            // tsmiReset
            // 
            tsmiReset.Image = Properties.Resources.update;
            tsmiReset.Name = "tsmiReset";
            tsmiReset.Size = new System.Drawing.Size(102, 22);
            tsmiReset.Text = "Reset";
            // 
            // searchesToolStripMenuItem
            // 
            searchesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { tsmiPlaySearches });
            searchesToolStripMenuItem.Name = "searchesToolStripMenuItem";
            searchesToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            searchesToolStripMenuItem.Text = "Searches";
            // 
            // tsmiPlaySearches
            // 
            tsmiPlaySearches.Image = Properties.Resources.play;
            tsmiPlaySearches.Name = "tsmiPlaySearches";
            tsmiPlaySearches.Size = new System.Drawing.Size(144, 22);
            tsmiPlaySearches.Text = "Play searches";
            // 
            // rewardsToolStripMenuItem
            // 
            rewardsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { tsmiPlayRewards });
            rewardsToolStripMenuItem.Name = "rewardsToolStripMenuItem";
            rewardsToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            rewardsToolStripMenuItem.Text = "Rewards";
            // 
            // tsmiPlayRewards
            // 
            tsmiPlayRewards.Image = Properties.Resources.play;
            tsmiPlayRewards.Name = "tsmiPlayRewards";
            tsmiPlayRewards.Size = new System.Drawing.Size(140, 22);
            tsmiPlayRewards.Text = "Play rewards";
            // 
            // ambassadorsToolStripMenuItem
            // 
            ambassadorsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { tsmiPlayAmbassadors });
            ambassadorsToolStripMenuItem.Name = "ambassadorsToolStripMenuItem";
            ambassadorsToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            ambassadorsToolStripMenuItem.Text = "Ambassadors";
            // 
            // tsmiPlayAmbassadors
            // 
            tsmiPlayAmbassadors.Image = Properties.Resources.play;
            tsmiPlayAmbassadors.Name = "tsmiPlayAmbassadors";
            tsmiPlayAmbassadors.Size = new System.Drawing.Size(168, 22);
            tsmiPlayAmbassadors.Text = "Play ambassadors";
            // 
            // optionsToolStripMenuItem
            // 
            optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { tsmISettings });
            optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            optionsToolStripMenuItem.Text = "Options";
            // 
            // tsmISettings
            // 
            tsmISettings.Image = Properties.Resources.settings;
            tsmISettings.Name = "tsmISettings";
            tsmISettings.Size = new System.Drawing.Size(116, 22);
            tsmISettings.Text = "Settings";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(tabControl1, 0, 0);
            tableLayoutPanel1.Controls.Add(panel1, 0, 1);
            tableLayoutPanel1.Controls.Add(panel2, 0, 2);
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            tableLayoutPanel1.Size = new System.Drawing.Size(1219, 527);
            tableLayoutPanel1.TabIndex = 21;
            // 
            // panel1
            // 
            panel1.Controls.Add(txtNextSearch);
            panel1.Controls.Add(btnSearch);
            panel1.Controls.Add(txtSearches);
            panel1.Controls.Add(btnNext);
            panel1.Controls.Add(lblNextSearch);
            panel1.Controls.Add(txtCurrentPoints);
            panel1.Controls.Add(txtUpperLimit);
            panel1.Controls.Add(lblPointsSeparator);
            panel1.Controls.Add(lblSearches);
            panel1.Controls.Add(txtLowerLimit);
            panel1.Controls.Add(lblRefreshRangeSeparator);
            panel1.Controls.Add(txtPointsLimit);
            panel1.Controls.Add(lblRange);
            panel1.Controls.Add(lblPoints);
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(3, 460);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(1213, 29);
            panel1.TabIndex = 20;
            // 
            // panel2
            // 
            panel2.Controls.Add(pbSearches);
            panel2.Controls.Add(btnPlay);
            panel2.Controls.Add(lblAmbassadorsPB);
            panel2.Controls.Add(lblRewardsPB);
            panel2.Controls.Add(lblSearchesPB);
            panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            panel2.Location = new System.Drawing.Point(3, 495);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(1213, 29);
            panel2.TabIndex = 20;
            // 
            // lblAmbassadorsPB
            // 
            lblAmbassadorsPB.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            lblAmbassadorsPB.AutoSize = true;
            lblAmbassadorsPB.Location = new System.Drawing.Point(686, 7);
            lblAmbassadorsPB.Name = "lblAmbassadorsPB";
            lblAmbassadorsPB.Size = new System.Drawing.Size(81, 15);
            lblAmbassadorsPB.TabIndex = 14;
            lblAmbassadorsPB.Text = "Ambassadors:";
            lblAmbassadorsPB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRewardsPB
            // 
            lblRewardsPB.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            lblRewardsPB.AutoSize = true;
            lblRewardsPB.Location = new System.Drawing.Point(396, 7);
            lblRewardsPB.Name = "lblRewardsPB";
            lblRewardsPB.Size = new System.Drawing.Size(54, 15);
            lblRewardsPB.TabIndex = 14;
            lblRewardsPB.Text = "Rewards:";
            lblRewardsPB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSearchesPB
            // 
            lblSearchesPB.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            lblSearchesPB.AutoSize = true;
            lblSearchesPB.Location = new System.Drawing.Point(4, 7);
            lblSearchesPB.Name = "lblSearchesPB";
            lblSearchesPB.Size = new System.Drawing.Size(56, 15);
            lblSearchesPB.TabIndex = 14;
            lblSearchesPB.Text = "Searches:";
            lblSearchesPB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1219, 551);
            Controls.Add(tableLayoutPanel1);
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
            ((System.ComponentModel.ISupportInitialize)wvRewards).EndInit();
            tpAmbassadors.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)wvAmbassadors).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
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
        private System.Windows.Forms.ToolStripMenuItem tsmiPlayRewards;
        private System.Windows.Forms.TabPage tpAmbassadors;
        private Microsoft.Web.WebView2.WinForms.WebView2 wvAmbassadors;
        private System.Windows.Forms.ToolStripMenuItem ambassadorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiPlayAmbassadors;
        private CustomProgressBar pbSearches;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblSearchesPB;
        private System.Windows.Forms.Label lblRewardsPB;
        private System.Windows.Forms.Label lblAmbassadorsPB;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmISettings;
        private System.Windows.Forms.ToolStripMenuItem tsmiPlaySearches;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

