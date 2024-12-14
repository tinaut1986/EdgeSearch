
using UtilsForms.Controls;

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
            btnPlay = new System.Windows.Forms.Button();
            lblNextSearch = new System.Windows.Forms.Label();
            btnNext = new System.Windows.Forms.Button();
            btnSearch = new System.Windows.Forms.Button();
            lblPCSearches = new System.Windows.Forms.Label();
            pbSearches = new CustomProgressBar();
            menuStrip1 = new System.Windows.Forms.MenuStrip();
            fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            tsmiPlay = new System.Windows.Forms.ToolStripMenuItem();
            tsmiReset = new System.Windows.Forms.ToolStripMenuItem();
            searchesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            tsmiPlaySearches = new System.Windows.Forms.ToolStripMenuItem();
            rewardsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            tsmiPlayRewards = new System.Windows.Forms.ToolStripMenuItem();
            optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            tsmiPreferences = new System.Windows.Forms.ToolStripMenuItem();
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            tabControl1 = new System.Windows.Forms.TabControl();
            tpSearches = new System.Windows.Forms.TabPage();
            wvSearches = new Microsoft.Web.WebView2.WinForms.WebView2();
            txtURL = new System.Windows.Forms.TextBox();
            chkMobile = new System.Windows.Forms.CheckBox();
            tpRewards = new System.Windows.Forms.TabPage();
            wvRewards = new Microsoft.Web.WebView2.WinForms.WebView2();
            panel2 = new System.Windows.Forms.Panel();
            flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            pbRewards = new CustomProgressBar();
            lblAwaker = new System.Windows.Forms.Label();
            tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            lblSeparator1 = new System.Windows.Forms.Label();
            lblMobileSearches = new System.Windows.Forms.Label();
            lblSeparator2 = new System.Windows.Forms.Label();
            lblRefreshRange = new System.Windows.Forms.Label();
            panel1 = new System.Windows.Forms.Panel();
            cbNextSearch = new System.Windows.Forms.ComboBox();
            menuStrip1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tabControl1.SuspendLayout();
            tpSearches.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)wvSearches).BeginInit();
            tpRewards.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)wvRewards).BeginInit();
            panel2.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnPlay
            // 
            btnPlay.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnPlay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            btnPlay.Image = src.Properties.Resources.play;
            btnPlay.Location = new System.Drawing.Point(1343, 3);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new System.Drawing.Size(25, 25);
            btnPlay.TabIndex = 13;
            btnPlay.UseVisualStyleBackColor = true;
            // 
            // lblNextSearch
            // 
            lblNextSearch.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lblNextSearch.Location = new System.Drawing.Point(11, 3);
            lblNextSearch.Name = "lblNextSearch";
            lblNextSearch.Size = new System.Drawing.Size(78, 23);
            lblNextSearch.TabIndex = 4;
            lblNextSearch.Text = "Next search:";
            lblNextSearch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnNext
            // 
            btnNext.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnNext.Image = src.Properties.Resources.update;
            btnNext.Location = new System.Drawing.Point(507, 3);
            btnNext.Name = "btnNext";
            btnNext.Size = new System.Drawing.Size(25, 25);
            btnNext.TabIndex = 7;
            btnNext.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            btnSearch.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnSearch.Image = src.Properties.Resources.search;
            btnSearch.Location = new System.Drawing.Point(538, 3);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new System.Drawing.Size(25, 25);
            btnSearch.TabIndex = 6;
            btnSearch.UseVisualStyleBackColor = true;
            // 
            // lblPCSearches
            // 
            lblPCSearches.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            lblPCSearches.Location = new System.Drawing.Point(0, 0);
            lblPCSearches.Margin = new System.Windows.Forms.Padding(0);
            lblPCSearches.Name = "lblPCSearches";
            lblPCSearches.Size = new System.Drawing.Size(110, 23);
            lblPCSearches.TabIndex = 14;
            lblPCSearches.Text = "PC: 0/0 | Points: 0/0";
            lblPCSearches.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbSearches
            // 
            pbSearches.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            pbSearches.ForeColor = System.Drawing.Color.Black;
            pbSearches.Location = new System.Drawing.Point(3, 3);
            pbSearches.Name = "pbSearches";
            pbSearches.PaintedColor = System.Drawing.Color.Green;
            pbSearches.PaintedForeColor = System.Drawing.Color.White;
            pbSearches.Size = new System.Drawing.Size(523, 23);
            pbSearches.TabIndex = 19;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { fileToolStripMenuItem, searchesToolStripMenuItem, rewardsToolStripMenuItem, optionsToolStripMenuItem });
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new System.Drawing.Size(1382, 24);
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
            tsmiPlay.Image = src.Properties.Resources.play;
            tsmiPlay.Name = "tsmiPlay";
            tsmiPlay.Size = new System.Drawing.Size(102, 22);
            tsmiPlay.Text = "Play";
            // 
            // tsmiReset
            // 
            tsmiReset.Image = src.Properties.Resources.update;
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
            tsmiPlaySearches.Image = src.Properties.Resources.play;
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
            tsmiPlayRewards.Image = src.Properties.Resources.play;
            tsmiPlayRewards.Name = "tsmiPlayRewards";
            tsmiPlayRewards.Size = new System.Drawing.Size(140, 22);
            tsmiPlayRewards.Text = "Play rewards";
            // 
            // optionsToolStripMenuItem
            // 
            optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { tsmiPreferences });
            optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            optionsToolStripMenuItem.Text = "Options";
            // 
            // tsmiPreferences
            // 
            tsmiPreferences.Image = src.Properties.Resources.settings;
            tsmiPreferences.Name = "tsmiPreferences";
            tsmiPreferences.Size = new System.Drawing.Size(135, 22);
            tsmiPreferences.Text = "Preferences";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(tabControl1, 0, 0);
            tableLayoutPanel1.Controls.Add(panel2, 0, 2);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 1);
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            tableLayoutPanel1.Size = new System.Drawing.Size(1382, 527);
            tableLayoutPanel1.TabIndex = 21;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tpSearches);
            tabControl1.Controls.Add(tpRewards);
            tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControl1.Location = new System.Drawing.Point(3, 3);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new System.Drawing.Size(1376, 451);
            tabControl1.TabIndex = 19;
            // 
            // tpSearches
            // 
            tpSearches.Controls.Add(wvSearches);
            tpSearches.Controls.Add(txtURL);
            tpSearches.Controls.Add(chkMobile);
            tpSearches.Location = new System.Drawing.Point(4, 24);
            tpSearches.Name = "tpSearches";
            tpSearches.Padding = new System.Windows.Forms.Padding(3);
            tpSearches.Size = new System.Drawing.Size(1368, 423);
            tpSearches.TabIndex = 0;
            tpSearches.Text = "Searches";
            tpSearches.UseVisualStyleBackColor = true;
            // 
            // wvSearches
            // 
            wvSearches.AllowExternalDrop = true;
            wvSearches.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            wvSearches.CreationProperties = null;
            wvSearches.DefaultBackgroundColor = System.Drawing.Color.White;
            wvSearches.Location = new System.Drawing.Point(3, 36);
            wvSearches.Name = "wvSearches";
            wvSearches.Size = new System.Drawing.Size(1359, 384);
            wvSearches.TabIndex = 3;
            wvSearches.ZoomFactor = 1D;
            // 
            // txtURL
            // 
            txtURL.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtURL.Location = new System.Drawing.Point(6, 6);
            txtURL.Name = "txtURL";
            txtURL.ReadOnly = true;
            txtURL.Size = new System.Drawing.Size(1327, 23);
            txtURL.TabIndex = 0;
            // 
            // chkMobile
            // 
            chkMobile.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            chkMobile.Appearance = System.Windows.Forms.Appearance.Button;
            chkMobile.Image = src.Properties.Resources.mobile;
            chkMobile.Location = new System.Drawing.Point(1339, 5);
            chkMobile.Name = "chkMobile";
            chkMobile.Size = new System.Drawing.Size(25, 25);
            chkMobile.TabIndex = 2;
            chkMobile.Tag = "";
            chkMobile.UseVisualStyleBackColor = true;
            // 
            // tpRewards
            // 
            tpRewards.Controls.Add(wvRewards);
            tpRewards.Location = new System.Drawing.Point(4, 24);
            tpRewards.Name = "tpRewards";
            tpRewards.Padding = new System.Windows.Forms.Padding(3);
            tpRewards.Size = new System.Drawing.Size(1368, 423);
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
            wvRewards.Size = new System.Drawing.Size(1362, 417);
            wvRewards.TabIndex = 0;
            wvRewards.ZoomFactor = 1D;
            // 
            // panel2
            // 
            panel2.Controls.Add(flowLayoutPanel1);
            panel2.Controls.Add(btnPlay);
            panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            panel2.Location = new System.Drawing.Point(3, 495);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(1376, 29);
            panel2.TabIndex = 20;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            flowLayoutPanel1.Controls.Add(pbSearches);
            flowLayoutPanel1.Controls.Add(pbRewards);
            flowLayoutPanel1.Controls.Add(lblAwaker);
            flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new System.Drawing.Size(1337, 29);
            flowLayoutPanel1.TabIndex = 20;
            // 
            // pbRewards
            // 
            pbRewards.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            pbRewards.ForeColor = System.Drawing.Color.Black;
            pbRewards.Location = new System.Drawing.Point(532, 3);
            pbRewards.Name = "pbRewards";
            pbRewards.PaintedColor = System.Drawing.Color.Green;
            pbRewards.PaintedForeColor = System.Drawing.Color.White;
            pbRewards.Size = new System.Drawing.Size(324, 23);
            pbRewards.TabIndex = 19;
            // 
            // lblAwaker
            // 
            lblAwaker.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            lblAwaker.Location = new System.Drawing.Point(859, 6);
            lblAwaker.Margin = new System.Windows.Forms.Padding(0);
            lblAwaker.Name = "lblAwaker";
            lblAwaker.Size = new System.Drawing.Size(301, 23);
            lblAwaker.TabIndex = 20;
            lblAwaker.Text = "Awaker OFF";
            lblAwaker.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 566F));
            tableLayoutPanel2.Controls.Add(flowLayoutPanel2, 0, 0);
            tableLayoutPanel2.Controls.Add(panel1, 1, 0);
            tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel2.Location = new System.Drawing.Point(3, 460);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            tableLayoutPanel2.Size = new System.Drawing.Size(1376, 29);
            tableLayoutPanel2.TabIndex = 15;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(lblPCSearches);
            flowLayoutPanel2.Controls.Add(lblSeparator1);
            flowLayoutPanel2.Controls.Add(lblMobileSearches);
            flowLayoutPanel2.Controls.Add(lblSeparator2);
            flowLayoutPanel2.Controls.Add(lblRefreshRange);
            flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            flowLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new System.Drawing.Size(804, 23);
            flowLayoutPanel2.TabIndex = 15;
            // 
            // lblSeparator1
            // 
            lblSeparator1.Location = new System.Drawing.Point(110, 0);
            lblSeparator1.Margin = new System.Windows.Forms.Padding(0);
            lblSeparator1.Name = "lblSeparator1";
            lblSeparator1.Size = new System.Drawing.Size(10, 23);
            lblSeparator1.TabIndex = 15;
            lblSeparator1.Text = "|";
            lblSeparator1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMobileSearches
            // 
            lblMobileSearches.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            lblMobileSearches.Location = new System.Drawing.Point(120, 0);
            lblMobileSearches.Margin = new System.Windows.Forms.Padding(0);
            lblMobileSearches.Name = "lblMobileSearches";
            lblMobileSearches.Size = new System.Drawing.Size(133, 23);
            lblMobileSearches.TabIndex = 14;
            lblMobileSearches.Text = "Mobile: 0/0 | Points: 0/0";
            lblMobileSearches.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSeparator2
            // 
            lblSeparator2.Location = new System.Drawing.Point(253, 0);
            lblSeparator2.Margin = new System.Windows.Forms.Padding(0);
            lblSeparator2.Name = "lblSeparator2";
            lblSeparator2.Size = new System.Drawing.Size(10, 23);
            lblSeparator2.TabIndex = 15;
            lblSeparator2.Text = "|";
            lblSeparator2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRefreshRange
            // 
            lblRefreshRange.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            lblRefreshRange.Location = new System.Drawing.Point(263, 0);
            lblRefreshRange.Margin = new System.Windows.Forms.Padding(0);
            lblRefreshRange.Name = "lblRefreshRange";
            lblRefreshRange.Size = new System.Drawing.Size(301, 23);
            lblRefreshRange.TabIndex = 14;
            lblRefreshRange.Text = "Refresh range (s): 0/0 | Streaks: 0/0 | Streak delay (s): 0/0";
            lblRefreshRange.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.Controls.Add(lblNextSearch);
            panel1.Controls.Add(btnNext);
            panel1.Controls.Add(cbNextSearch);
            panel1.Controls.Add(btnSearch);
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(810, 0);
            panel1.Margin = new System.Windows.Forms.Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(566, 29);
            panel1.TabIndex = 16;
            // 
            // cbNextSearch
            // 
            cbNextSearch.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            cbNextSearch.FormattingEnabled = true;
            cbNextSearch.Location = new System.Drawing.Point(95, 3);
            cbNextSearch.Name = "cbNextSearch";
            cbNextSearch.Size = new System.Drawing.Size(406, 23);
            cbNextSearch.TabIndex = 4;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1382, 551);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(menuStrip1);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Text = "Edge search";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tpSearches.ResumeLayout(false);
            tpSearches.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)wvSearches).EndInit();
            tpRewards.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)wvRewards).EndInit();
            panel2.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Label lblNextSearch;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblPCSearches;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiReset;
        private System.Windows.Forms.ToolStripMenuItem tsmiPlay;
        private System.Windows.Forms.ToolStripMenuItem searchesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rewardsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiPlayRewards;
        private CustomProgressBar pbSearches;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiPreferences;
        private System.Windows.Forms.ToolStripMenuItem tsmiPlaySearches;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpSearches;
        private Microsoft.Web.WebView2.WinForms.WebView2 wvSearches;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.CheckBox chkMobile;
        private System.Windows.Forms.TabPage tpRewards;
        private Microsoft.Web.WebView2.WinForms.WebView2 wvRewards;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private CustomProgressBar pbRewards;
        private System.Windows.Forms.ComboBox cbNextSearch;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblMobileSearches;
        private System.Windows.Forms.Label lblRefreshRange;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblSeparator1;
        private System.Windows.Forms.Label lblSeparator2;
        private System.Windows.Forms.Label lblAwaker;
    }
}

