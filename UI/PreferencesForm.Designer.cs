using System.Windows.Forms;

namespace EdgeSearch.UI
{
    partial class PreferencesForm
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
            txtMobileUserAgent = new TextBox();
            lblMobileUserAgent = new Label();
            txtMinWait = new TextBox();
            lblMinWait = new Label();
            txtMaxWait = new TextBox();
            lblMaxWait = new Label();
            txtMobilePointsPerSearch = new TextBox();
            lblMobilePointsPerSearch = new Label();
            grpMobile = new GroupBox();
            txtMobileTotalPoints = new TextBox();
            lblMobileTotalPoints = new Label();
            txtStrikeAmount = new TextBox();
            lblStrikeAmount = new Label();
            txtStrikeDelay = new TextBox();
            lblStrikeDelay = new Label();
            grpDesktop = new GroupBox();
            txtDesktopUserAgent = new TextBox();
            lblDesktopUserAgent = new Label();
            txtDesktopTotalPoints = new TextBox();
            lblDesktopTotalPoints = new Label();
            txtDesktopPointsPerSearch = new TextBox();
            lblDesktopPointsPerSearch = new Label();
            grpGeneral = new GroupBox();
            grpMobile.SuspendLayout();
            grpDesktop.SuspendLayout();
            grpGeneral.SuspendLayout();
            SuspendLayout();
            // 
            // txtMobileUserAgent
            // 
            txtMobileUserAgent.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtMobileUserAgent.Location = new System.Drawing.Point(112, 22);
            txtMobileUserAgent.Margin = new Padding(4, 3, 4, 3);
            txtMobileUserAgent.Name = "txtMobileUserAgent";
            txtMobileUserAgent.Size = new System.Drawing.Size(832, 23);
            txtMobileUserAgent.TabIndex = 2;
            // 
            // lblMobileUserAgent
            // 
            lblMobileUserAgent.AutoSize = true;
            lblMobileUserAgent.Location = new System.Drawing.Point(7, 26);
            lblMobileUserAgent.Margin = new Padding(4, 0, 4, 0);
            lblMobileUserAgent.Name = "lblMobileUserAgent";
            lblMobileUserAgent.Size = new System.Drawing.Size(65, 15);
            lblMobileUserAgent.TabIndex = 3;
            lblMobileUserAgent.Text = "User Agent";
            // 
            // txtMinWait
            // 
            txtMinWait.Location = new System.Drawing.Point(110, 15);
            txtMinWait.Margin = new Padding(4, 3, 4, 3);
            txtMinWait.Name = "txtMinWait";
            txtMinWait.Size = new System.Drawing.Size(67, 23);
            txtMinWait.TabIndex = 2;
            // 
            // lblMinWait
            // 
            lblMinWait.AutoSize = true;
            lblMinWait.Location = new System.Drawing.Point(21, 19);
            lblMinWait.Margin = new Padding(4, 0, 4, 0);
            lblMinWait.Name = "lblMinWait";
            lblMinWait.Size = new System.Drawing.Size(69, 15);
            lblMinWait.TabIndex = 3;
            lblMinWait.Text = "Min wait (s)";
            // 
            // txtMaxWait
            // 
            txtMaxWait.Location = new System.Drawing.Point(291, 15);
            txtMaxWait.Margin = new Padding(4, 3, 4, 3);
            txtMaxWait.Name = "txtMaxWait";
            txtMaxWait.Size = new System.Drawing.Size(67, 23);
            txtMaxWait.TabIndex = 2;
            // 
            // lblMaxWait
            // 
            lblMaxWait.AutoSize = true;
            lblMaxWait.Location = new System.Drawing.Point(200, 19);
            lblMaxWait.Margin = new Padding(4, 0, 4, 0);
            lblMaxWait.Name = "lblMaxWait";
            lblMaxWait.Size = new System.Drawing.Size(71, 15);
            lblMaxWait.TabIndex = 3;
            lblMaxWait.Text = "Max wait (s)";
            // 
            // txtMobilePointsPerSearch
            // 
            txtMobilePointsPerSearch.Location = new System.Drawing.Point(112, 51);
            txtMobilePointsPerSearch.Margin = new Padding(4, 3, 4, 3);
            txtMobilePointsPerSearch.Name = "txtMobilePointsPerSearch";
            txtMobilePointsPerSearch.Size = new System.Drawing.Size(66, 23);
            txtMobilePointsPerSearch.TabIndex = 2;
            // 
            // lblMobilePointsPerSearch
            // 
            lblMobilePointsPerSearch.AutoSize = true;
            lblMobilePointsPerSearch.Location = new System.Drawing.Point(7, 55);
            lblMobilePointsPerSearch.Margin = new Padding(4, 0, 4, 0);
            lblMobilePointsPerSearch.Name = "lblMobilePointsPerSearch";
            lblMobilePointsPerSearch.Size = new System.Drawing.Size(97, 15);
            lblMobilePointsPerSearch.TabIndex = 3;
            lblMobilePointsPerSearch.Text = "Points per search";
            // 
            // grpMobile
            // 
            grpMobile.Controls.Add(txtMobileUserAgent);
            grpMobile.Controls.Add(lblMobileUserAgent);
            grpMobile.Controls.Add(txtMobileTotalPoints);
            grpMobile.Controls.Add(lblMobileTotalPoints);
            grpMobile.Controls.Add(txtMobilePointsPerSearch);
            grpMobile.Controls.Add(lblMobilePointsPerSearch);
            grpMobile.Location = new System.Drawing.Point(12, 223);
            grpMobile.Name = "grpMobile";
            grpMobile.Size = new System.Drawing.Size(951, 108);
            grpMobile.TabIndex = 4;
            grpMobile.TabStop = false;
            grpMobile.Text = "Mobile";
            // 
            // txtMobileTotalPoints
            // 
            txtMobileTotalPoints.Location = new System.Drawing.Point(311, 51);
            txtMobileTotalPoints.Margin = new Padding(4, 3, 4, 3);
            txtMobileTotalPoints.Name = "txtMobileTotalPoints";
            txtMobileTotalPoints.ReadOnly = true;
            txtMobileTotalPoints.Size = new System.Drawing.Size(66, 23);
            txtMobileTotalPoints.TabIndex = 2;
            // 
            // lblMobileTotalPoints
            // 
            lblMobileTotalPoints.AutoSize = true;
            lblMobileTotalPoints.Location = new System.Drawing.Point(235, 55);
            lblMobileTotalPoints.Margin = new Padding(4, 0, 4, 0);
            lblMobileTotalPoints.Name = "lblMobileTotalPoints";
            lblMobileTotalPoints.Size = new System.Drawing.Size(68, 15);
            lblMobileTotalPoints.TabIndex = 3;
            lblMobileTotalPoints.Text = "Total points";
            // 
            // txtStrikeAmount
            // 
            txtStrikeAmount.Location = new System.Drawing.Point(110, 44);
            txtStrikeAmount.Margin = new Padding(4, 3, 4, 3);
            txtStrikeAmount.Name = "txtStrikeAmount";
            txtStrikeAmount.Size = new System.Drawing.Size(67, 23);
            txtStrikeAmount.TabIndex = 2;
            // 
            // lblStrikeAmount
            // 
            lblStrikeAmount.AutoSize = true;
            lblStrikeAmount.Location = new System.Drawing.Point(21, 48);
            lblStrikeAmount.Margin = new Padding(4, 0, 4, 0);
            lblStrikeAmount.Name = "lblStrikeAmount";
            lblStrikeAmount.Size = new System.Drawing.Size(81, 15);
            lblStrikeAmount.TabIndex = 3;
            lblStrikeAmount.Text = "Strike amount";
            // 
            // txtStrikeDelay
            // 
            txtStrikeDelay.Location = new System.Drawing.Point(291, 44);
            txtStrikeDelay.Margin = new Padding(4, 3, 4, 3);
            txtStrikeDelay.Name = "txtStrikeDelay";
            txtStrikeDelay.Size = new System.Drawing.Size(67, 23);
            txtStrikeDelay.TabIndex = 2;
            // 
            // lblStrikeDelay
            // 
            lblStrikeDelay.AutoSize = true;
            lblStrikeDelay.Location = new System.Drawing.Point(200, 48);
            lblStrikeDelay.Margin = new Padding(4, 0, 4, 0);
            lblStrikeDelay.Name = "lblStrikeDelay";
            lblStrikeDelay.Size = new System.Drawing.Size(83, 15);
            lblStrikeDelay.TabIndex = 3;
            lblStrikeDelay.Text = "Strike delay (s)";
            // 
            // grpDesktop
            // 
            grpDesktop.Controls.Add(txtDesktopUserAgent);
            grpDesktop.Controls.Add(lblDesktopUserAgent);
            grpDesktop.Controls.Add(txtDesktopTotalPoints);
            grpDesktop.Controls.Add(lblDesktopTotalPoints);
            grpDesktop.Controls.Add(txtDesktopPointsPerSearch);
            grpDesktop.Controls.Add(lblDesktopPointsPerSearch);
            grpDesktop.Location = new System.Drawing.Point(12, 109);
            grpDesktop.Name = "grpDesktop";
            grpDesktop.Size = new System.Drawing.Size(951, 108);
            grpDesktop.TabIndex = 4;
            grpDesktop.TabStop = false;
            grpDesktop.Text = "Desktop";
            // 
            // txtDesktopUserAgent
            // 
            txtDesktopUserAgent.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtDesktopUserAgent.Location = new System.Drawing.Point(112, 22);
            txtDesktopUserAgent.Margin = new Padding(4, 3, 4, 3);
            txtDesktopUserAgent.Name = "txtDesktopUserAgent";
            txtDesktopUserAgent.Size = new System.Drawing.Size(832, 23);
            txtDesktopUserAgent.TabIndex = 2;
            // 
            // lblDesktopUserAgent
            // 
            lblDesktopUserAgent.AutoSize = true;
            lblDesktopUserAgent.Location = new System.Drawing.Point(7, 26);
            lblDesktopUserAgent.Margin = new Padding(4, 0, 4, 0);
            lblDesktopUserAgent.Name = "lblDesktopUserAgent";
            lblDesktopUserAgent.Size = new System.Drawing.Size(65, 15);
            lblDesktopUserAgent.TabIndex = 3;
            lblDesktopUserAgent.Text = "User Agent";
            // 
            // txtDesktopTotalPoints
            // 
            txtDesktopTotalPoints.Location = new System.Drawing.Point(311, 51);
            txtDesktopTotalPoints.Margin = new Padding(4, 3, 4, 3);
            txtDesktopTotalPoints.Name = "txtDesktopTotalPoints";
            txtDesktopTotalPoints.ReadOnly = true;
            txtDesktopTotalPoints.Size = new System.Drawing.Size(66, 23);
            txtDesktopTotalPoints.TabIndex = 2;
            // 
            // lblDesktopTotalPoints
            // 
            lblDesktopTotalPoints.AutoSize = true;
            lblDesktopTotalPoints.Location = new System.Drawing.Point(235, 55);
            lblDesktopTotalPoints.Margin = new Padding(4, 0, 4, 0);
            lblDesktopTotalPoints.Name = "lblDesktopTotalPoints";
            lblDesktopTotalPoints.Size = new System.Drawing.Size(68, 15);
            lblDesktopTotalPoints.TabIndex = 3;
            lblDesktopTotalPoints.Text = "Total points";
            // 
            // txtDesktopPointsPerSearch
            // 
            txtDesktopPointsPerSearch.Location = new System.Drawing.Point(112, 51);
            txtDesktopPointsPerSearch.Margin = new Padding(4, 3, 4, 3);
            txtDesktopPointsPerSearch.Name = "txtDesktopPointsPerSearch";
            txtDesktopPointsPerSearch.Size = new System.Drawing.Size(66, 23);
            txtDesktopPointsPerSearch.TabIndex = 2;
            // 
            // lblDesktopPointsPerSearch
            // 
            lblDesktopPointsPerSearch.AutoSize = true;
            lblDesktopPointsPerSearch.Location = new System.Drawing.Point(7, 55);
            lblDesktopPointsPerSearch.Margin = new Padding(4, 0, 4, 0);
            lblDesktopPointsPerSearch.Name = "lblDesktopPointsPerSearch";
            lblDesktopPointsPerSearch.Size = new System.Drawing.Size(97, 15);
            lblDesktopPointsPerSearch.TabIndex = 3;
            lblDesktopPointsPerSearch.Text = "Points per search";
            // 
            // grpGeneral
            // 
            grpGeneral.Controls.Add(lblMaxWait);
            grpGeneral.Controls.Add(txtMinWait);
            grpGeneral.Controls.Add(txtMaxWait);
            grpGeneral.Controls.Add(lblStrikeDelay);
            grpGeneral.Controls.Add(txtStrikeAmount);
            grpGeneral.Controls.Add(lblStrikeAmount);
            grpGeneral.Controls.Add(txtStrikeDelay);
            grpGeneral.Controls.Add(lblMinWait);
            grpGeneral.Location = new System.Drawing.Point(12, 12);
            grpGeneral.Name = "grpGeneral";
            grpGeneral.Size = new System.Drawing.Size(394, 91);
            grpGeneral.TabIndex = 5;
            grpGeneral.TabStop = false;
            grpGeneral.Text = "General";
            // 
            // PreferencesForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(975, 374);
            Controls.Add(grpGeneral);
            Controls.Add(grpDesktop);
            Controls.Add(grpMobile);
            Margin = new Padding(5, 3, 5, 3);
            Name = "PreferencesForm";
            Text = "Preferences";
            Controls.SetChildIndex(grpMobile, 0);
            Controls.SetChildIndex(grpDesktop, 0);
            Controls.SetChildIndex(grpGeneral, 0);
            grpMobile.ResumeLayout(false);
            grpMobile.PerformLayout();
            grpDesktop.ResumeLayout(false);
            grpDesktop.PerformLayout();
            grpGeneral.ResumeLayout(false);
            grpGeneral.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TextBox txtMobileUserAgent;
        private System.Windows.Forms.Label lblMobileUserAgent;
        private TextBox txtMinWait;
        private Label lblMinWait;
        private TextBox txtMaxWait;
        private Label lblMaxWait;
        private TextBox txtMobilePointsPerSearch;
        private Label lblMobilePointsPerSearch;
        private GroupBox grpMobile;
        private TextBox txtStrikeAmount;
        private Label lblStrikeAmount;
        private TextBox txtStrikeDelay;
        private Label lblStrikeDelay;
        private TextBox txtMobileTotalPoints;
        private Label lblMobileTotalPoints;
        private GroupBox grpDesktop;
        private TextBox txtDesktopUserAgent;
        private Label lblDesktopUserAgent;
        private TextBox txtDesktopTotalPoints;
        private Label lblDesktopTotalPoints;
        private TextBox txtDesktopPointsPerSearch;
        private Label lblDesktopPointsPerSearch;
        private GroupBox grpGeneral;
    }
}