
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
            btnPlay = new System.Windows.Forms.Button();
            lblNextSearch = new System.Windows.Forms.Label();
            btnNext = new System.Windows.Forms.Button();
            btnSearch = new System.Windows.Forms.Button();
            lblSearches = new System.Windows.Forms.Label();
            txtNextSearch = new System.Windows.Forms.TextBox();
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
            btnOpen = new System.Windows.Forms.Button();
            tpRewards = new System.Windows.Forms.TabPage();
            wvRewards = new Microsoft.Web.WebView2.WinForms.WebView2();
            panel1 = new System.Windows.Forms.Panel();
            panel2 = new System.Windows.Forms.Panel();
            lblRewardsPB = new System.Windows.Forms.Label();
            lblSearchesPB = new System.Windows.Forms.Label();
            toolTip1 = new System.Windows.Forms.ToolTip(components);
            menuStrip1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tabControl1.SuspendLayout();
            tpSearches.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)wvSearches).BeginInit();
            tpRewards.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)wvRewards).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
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
            // lblSearches
            // 
            lblSearches.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            lblSearches.Location = new System.Drawing.Point(9, 7);
            lblSearches.Name = "lblSearches";
            lblSearches.Size = new System.Drawing.Size(433, 17);
            lblSearches.TabIndex = 14;
            lblSearches.Text = "Searches:";
            lblSearches.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNextSearch
            // 
            txtNextSearch.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtNextSearch.Location = new System.Drawing.Point(532, 3);
            txtNextSearch.Name = "txtNextSearch";
            txtNextSearch.Size = new System.Drawing.Size(613, 23);
            txtNextSearch.TabIndex = 9;
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
            menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { fileToolStripMenuItem, searchesToolStripMenuItem, rewardsToolStripMenuItem, optionsToolStripMenuItem });
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
            // optionsToolStripMenuItem
            // 
            optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { tsmiPreferences });
            optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            optionsToolStripMenuItem.Text = "Options";
            // 
            // tsmiPreferences
            // 
            tsmiPreferences.Image = Properties.Resources.settings;
            tsmiPreferences.Name = "tsmiPreferences";
            tsmiPreferences.Size = new System.Drawing.Size(135, 22);
            tsmiPreferences.Text = "Preferences";
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
            // tabControl1
            // 
            tabControl1.Controls.Add(tpSearches);
            tabControl1.Controls.Add(tpRewards);
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
            // txtURL
            // 
            txtURL.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtURL.Location = new System.Drawing.Point(6, 6);
            txtURL.Name = "txtURL";
            txtURL.Size = new System.Drawing.Size(1135, 23);
            txtURL.TabIndex = 0;
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
            // panel1
            // 
            panel1.Controls.Add(txtNextSearch);
            panel1.Controls.Add(btnSearch);
            panel1.Controls.Add(btnNext);
            panel1.Controls.Add(lblNextSearch);
            panel1.Controls.Add(lblSearches);
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
            panel2.Controls.Add(lblRewardsPB);
            panel2.Controls.Add(lblSearchesPB);
            panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            panel2.Location = new System.Drawing.Point(3, 495);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(1213, 29);
            panel2.TabIndex = 20;
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
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tpSearches.ResumeLayout(false);
            tpSearches.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)wvSearches).EndInit();
            tpRewards.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)wvRewards).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Label lblNextSearch;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblSearches;
        private System.Windows.Forms.TextBox txtNextSearch;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiReset;
        private System.Windows.Forms.ToolStripMenuItem tsmiPlay;
        private System.Windows.Forms.ToolStripMenuItem searchesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rewardsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiPlayRewards;
        private CustomProgressBar pbSearches;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblSearchesPB;
        private System.Windows.Forms.Label lblRewardsPB;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiPreferences;
        private System.Windows.Forms.ToolStripMenuItem tsmiPlaySearches;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpSearches;
        private Microsoft.Web.WebView2.WinForms.WebView2 wvSearches;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.CheckBox chkMobile;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.TabPage tpRewards;
        private Microsoft.Web.WebView2.WinForms.WebView2 wvRewards;
    }
}

