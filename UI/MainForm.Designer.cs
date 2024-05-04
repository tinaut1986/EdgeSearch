
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
            lblNextSearch = new System.Windows.Forms.Label();
            btnNext = new System.Windows.Forms.Button();
            chkMobile = new System.Windows.Forms.CheckBox();
            btnForce = new System.Windows.Forms.Button();
            btnCopy = new System.Windows.Forms.Button();
            txtUpperLimit = new System.Windows.Forms.TextBox();
            txtLoweLimit = new System.Windows.Forms.TextBox();
            lblSearches = new System.Windows.Forms.Label();
            txtSearches = new System.Windows.Forms.TextBox();
            lblPoints = new System.Windows.Forms.Label();
            txtCurrentPoints = new System.Windows.Forms.TextBox();
            txtPointsLimit = new System.Windows.Forms.TextBox();
            lblPointsSeparator = new System.Windows.Forms.Label();
            lblRefreshRangeSeparator = new System.Windows.Forms.Label();
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
            webView.Size = new System.Drawing.Size(1106, 429);
            webView.TabIndex = 3;
            webView.ZoomFactor = 1D;
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
            lblNextSearch.Size = new System.Drawing.Size(926, 19);
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
            chkMobile.Location = new System.Drawing.Point(1064, 10);
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
            // btnCopy
            // 
            btnCopy.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnCopy.Location = new System.Drawing.Point(944, 476);
            btnCopy.Name = "btnCopy";
            btnCopy.Size = new System.Drawing.Size(54, 23);
            btnCopy.TabIndex = 5;
            btnCopy.Text = "Copy";
            btnCopy.UseVisualStyleBackColor = true;
            // 
            // txtUpperLimit
            // 
            txtUpperLimit.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            txtUpperLimit.Location = new System.Drawing.Point(186, 504);
            txtUpperLimit.Name = "txtUpperLimit";
            txtUpperLimit.Size = new System.Drawing.Size(28, 23);
            txtUpperLimit.TabIndex = 10;
            // 
            // txtLoweLimit
            // 
            txtLoweLimit.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            txtLoweLimit.Location = new System.Drawing.Point(134, 504);
            txtLoweLimit.Name = "txtLoweLimit";
            txtLoweLimit.Size = new System.Drawing.Size(28, 23);
            txtLoweLimit.TabIndex = 9;
            // 
            // lblSearches
            // 
            lblSearches.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            lblSearches.AutoSize = true;
            lblSearches.Location = new System.Drawing.Point(12, 536);
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
            lblPoints.Location = new System.Drawing.Point(134, 536);
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
            lblPointsSeparator.Location = new System.Drawing.Point(217, 536);
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
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1130, 570);
            Controls.Add(txtSearches);
            Controls.Add(txtCurrentPoints);
            Controls.Add(txtLoweLimit);
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
            Controls.Add(btnCopy);
            Controls.Add(btnForce);
            Controls.Add(btnNext);
            Controls.Add(btnPlay);
            Controls.Add(progressBar);
            Controls.Add(webView);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
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
        private System.Windows.Forms.Label lblNextSearch;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.CheckBox chkMobile;
        private System.Windows.Forms.Button btnForce;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.TextBox txtUpperLimit;
        private System.Windows.Forms.TextBox txtLoweLimit;
        private System.Windows.Forms.Label lblSearches;
        private System.Windows.Forms.TextBox txtSearches;
        private System.Windows.Forms.Label lblPoints;
        private System.Windows.Forms.TextBox txtCurrentPoints;
        private System.Windows.Forms.TextBox txtPointsLimit;
        private System.Windows.Forms.Label lblPointsSeparator;
        private System.Windows.Forms.Label lblRefreshRangeSeparator;
    }
}

