
namespace Test_web
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            webView = new Microsoft.Web.WebView2.WinForms.WebView2();
            progressBar = new System.Windows.Forms.ProgressBar();
            btnPlay = new System.Windows.Forms.Button();
            txtLowerUpdate = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            txtUpperUpdate = new System.Windows.Forms.TextBox();
            lblProgress = new System.Windows.Forms.Label();
            txtURL = new System.Windows.Forms.TextBox();
            btnOpen = new System.Windows.Forms.Button();
            lblResumen = new System.Windows.Forms.Label();
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
            webView.Size = new System.Drawing.Size(1106, 486);
            webView.TabIndex = 0;
            webView.ZoomFactor = 1D;
            // 
            // progressBar
            // 
            progressBar.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            progressBar.Location = new System.Drawing.Point(225, 533);
            progressBar.Name = "progressBar";
            progressBar.Size = new System.Drawing.Size(809, 23);
            progressBar.TabIndex = 1;
            // 
            // btnPlay
            // 
            btnPlay.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnPlay.Location = new System.Drawing.Point(1040, 533);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new System.Drawing.Size(75, 23);
            btnPlay.TabIndex = 2;
            btnPlay.Text = "Play";
            btnPlay.UseVisualStyleBackColor = true;
            btnPlay.Click += btnPlay_Click;
            // 
            // txtLowerUpdate
            // 
            txtLowerUpdate.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            txtLowerUpdate.Location = new System.Drawing.Point(123, 533);
            txtLowerUpdate.Name = "txtLowerUpdate";
            txtLowerUpdate.Size = new System.Drawing.Size(45, 23);
            txtLowerUpdate.TabIndex = 3;
            txtLowerUpdate.Text = "15";
            // 
            // label1
            // 
            label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(9, 537);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(108, 15);
            label1.TabIndex = 4;
            label1.Text = "Refresh range (seg)";
            // 
            // txtUpperUpdate
            // 
            txtUpperUpdate.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            txtUpperUpdate.Location = new System.Drawing.Point(174, 533);
            txtUpperUpdate.Name = "txtUpperUpdate";
            txtUpperUpdate.Size = new System.Drawing.Size(45, 23);
            txtUpperUpdate.TabIndex = 3;
            txtUpperUpdate.Text = "90";
            // 
            // lblProgress
            // 
            lblProgress.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            lblProgress.AutoSize = true;
            lblProgress.BackColor = System.Drawing.Color.Transparent;
            lblProgress.ForeColor = System.Drawing.Color.Black;
            lblProgress.Location = new System.Drawing.Point(601, 537);
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
            txtURL.Size = new System.Drawing.Size(1022, 23);
            txtURL.TabIndex = 6;
            txtURL.KeyPress += txtURL_KeyPress;
            // 
            // btnOpen
            // 
            btnOpen.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnOpen.Location = new System.Drawing.Point(1040, 11);
            btnOpen.Name = "btnOpen";
            btnOpen.Size = new System.Drawing.Size(75, 23);
            btnOpen.TabIndex = 2;
            btnOpen.Text = "Open";
            btnOpen.UseVisualStyleBackColor = true;
            btnOpen.Click += btnOpen_Click;
            // 
            // lblResumen
            // 
            lblResumen.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            lblResumen.AutoSize = true;
            lblResumen.BackColor = System.Drawing.Color.Transparent;
            lblResumen.Location = new System.Drawing.Point(896, 537);
            lblResumen.Name = "lblResumen";
            lblResumen.Size = new System.Drawing.Size(135, 15);
            lblResumen.TabIndex = 7;
            lblResumen.Text = "searches: 0 | points: 0/90";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1130, 568);
            Controls.Add(lblResumen);
            Controls.Add(txtURL);
            Controls.Add(lblProgress);
            Controls.Add(label1);
            Controls.Add(txtUpperUpdate);
            Controls.Add(txtLowerUpdate);
            Controls.Add(btnOpen);
            Controls.Add(btnPlay);
            Controls.Add(progressBar);
            Controls.Add(webView);
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
        private System.Windows.Forms.TextBox txtLowerUpdate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUpperUpdate;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Label lblResumen;
    }
}

