
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
            webView = new Microsoft.Web.WebView2.WinForms.WebView2();
            progressBar = new System.Windows.Forms.ProgressBar();
            btnPlay = new System.Windows.Forms.Button();
            lblRange = new System.Windows.Forms.Label();
            lblProgress = new System.Windows.Forms.Label();
            txtURL = new System.Windows.Forms.TextBox();
            btnOpen = new System.Windows.Forms.Button();
            lblResumen = new System.Windows.Forms.Label();
            lblNextSearch = new System.Windows.Forms.Label();
            btnRefresh = new System.Windows.Forms.Button();
            chkMobile = new System.Windows.Forms.CheckBox();
            btnForce = new System.Windows.Forms.Button();
            btnCopy = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)webView).BeginInit();
            SuspendLayout();
            // 
            // webView
            // 
            webView.AllowExternalDrop = true;
            webView.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            webView.CreationProperties = null;
            webView.DefaultBackgroundColor = System.Drawing.Color.White;
            webView.Location = new System.Drawing.Point(12, 41);
            webView.Name = "webView";
            webView.Size = new System.Drawing.Size(1106, 450);
            webView.TabIndex = 0;
            webView.ZoomFactor = 1D;
            // 
            // progressBar
            // 
            progressBar.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            progressBar.Location = new System.Drawing.Point(168, 525);
            progressBar.Name = "progressBar";
            progressBar.Size = new System.Drawing.Size(869, 23);
            progressBar.TabIndex = 1;
            // 
            // btnPlay
            // 
            btnPlay.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnPlay.Location = new System.Drawing.Point(1043, 525);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new System.Drawing.Size(75, 23);
            btnPlay.TabIndex = 2;
            btnPlay.Text = "Play";
            btnPlay.UseVisualStyleBackColor = true;
            // 
            // lblRange
            // 
            lblRange.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            lblRange.AutoSize = true;
            lblRange.Location = new System.Drawing.Point(12, 529);
            lblRange.Name = "lblRange";
            lblRange.Size = new System.Drawing.Size(136, 15);
            lblRange.TabIndex = 4;
            lblRange.Text = "Refresh range (segs): 0/0";
            // 
            // lblProgress
            // 
            lblProgress.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            lblProgress.AutoSize = true;
            lblProgress.BackColor = System.Drawing.Color.Transparent;
            lblProgress.ForeColor = System.Drawing.Color.Black;
            lblProgress.Location = new System.Drawing.Point(604, 529);
            lblProgress.Name = "lblProgress";
            lblProgress.Size = new System.Drawing.Size(24, 15);
            lblProgress.TabIndex = 5;
            lblProgress.Text = "0/0";
            lblProgress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtURL
            // 
            txtURL.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtURL.Location = new System.Drawing.Point(12, 12);
            txtURL.Name = "txtURL";
            txtURL.Size = new System.Drawing.Size(965, 23);
            txtURL.TabIndex = 6;
            // 
            // btnOpen
            // 
            btnOpen.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnOpen.Location = new System.Drawing.Point(983, 12);
            btnOpen.Name = "btnOpen";
            btnOpen.Size = new System.Drawing.Size(75, 23);
            btnOpen.TabIndex = 2;
            btnOpen.Text = "Open";
            btnOpen.UseVisualStyleBackColor = true;
            // 
            // lblResumen
            // 
            lblResumen.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            lblResumen.BackColor = System.Drawing.Color.Transparent;
            lblResumen.Location = new System.Drawing.Point(831, 529);
            lblResumen.Name = "lblResumen";
            lblResumen.Size = new System.Drawing.Size(203, 15);
            lblResumen.TabIndex = 7;
            lblResumen.Text = "searches: 0 | points: 0/90";
            lblResumen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblNextSearch
            // 
            lblNextSearch.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            lblNextSearch.Location = new System.Drawing.Point(12, 501);
            lblNextSearch.Name = "lblNextSearch";
            lblNextSearch.Size = new System.Drawing.Size(863, 15);
            lblNextSearch.TabIndex = 4;
            lblNextSearch.Text = "Next search:";
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnRefresh.Location = new System.Drawing.Point(1043, 497);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new System.Drawing.Size(75, 23);
            btnRefresh.TabIndex = 2;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            // 
            // chkMobile
            // 
            chkMobile.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            chkMobile.Appearance = System.Windows.Forms.Appearance.Button;
            chkMobile.AutoSize = true;
            chkMobile.Location = new System.Drawing.Point(1064, 10);
            chkMobile.Name = "chkMobile";
            chkMobile.Size = new System.Drawing.Size(54, 25);
            chkMobile.TabIndex = 8;
            chkMobile.Text = "Mobile";
            chkMobile.UseVisualStyleBackColor = true;
            // 
            // btnForce
            // 
            btnForce.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnForce.Location = new System.Drawing.Point(962, 497);
            btnForce.Name = "btnForce";
            btnForce.Size = new System.Drawing.Size(75, 23);
            btnForce.TabIndex = 2;
            btnForce.Text = "Force";
            btnForce.UseVisualStyleBackColor = true;
            // 
            // btnCopy
            // 
            btnCopy.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnCopy.Location = new System.Drawing.Point(881, 497);
            btnCopy.Name = "btnCopy";
            btnCopy.Size = new System.Drawing.Size(75, 23);
            btnCopy.TabIndex = 2;
            btnCopy.Text = "Copy";
            btnCopy.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1130, 560);
            Controls.Add(chkMobile);
            Controls.Add(lblResumen);
            Controls.Add(txtURL);
            Controls.Add(lblProgress);
            Controls.Add(lblNextSearch);
            Controls.Add(lblRange);
            Controls.Add(btnOpen);
            Controls.Add(btnCopy);
            Controls.Add(btnForce);
            Controls.Add(btnRefresh);
            Controls.Add(btnPlay);
            Controls.Add(progressBar);
            Controls.Add(webView);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            Text = "Edge search";
            ((System.ComponentModel.ISupportInitialize)webView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Microsoft.Web.WebView2.WinForms.WebView2 webView;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Label lblRange;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Label lblResumen;
        private System.Windows.Forms.Label lblNextSearch;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.CheckBox chkMobile;
        private System.Windows.Forms.Button btnForce;
        private System.Windows.Forms.Button btnCopy;
    }
}

