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
            cpbsMobileReverse = new src.UI.CustomProgressBarSettings();
            cpbsMobileNormal = new src.UI.CustomProgressBarSettings();
            txtMobileTotalPoints = new TextBox();
            lblMobileTotalPoints = new Label();
            txtMinStreakAmount = new TextBox();
            lblMinStreakAmount = new Label();
            txtMinStreakDelay = new TextBox();
            lblMinStreakDelay = new Label();
            grpDesktop = new GroupBox();
            cpbsDesktopReverse = new src.UI.CustomProgressBarSettings();
            cpbsDesktopNormal = new src.UI.CustomProgressBarSettings();
            txtDesktopUserAgent = new TextBox();
            lblDesktopUserAgent = new Label();
            txtDesktopTotalPoints = new TextBox();
            lblDesktopTotalPoints = new Label();
            txtDesktopPointsPerSearch = new TextBox();
            lblDesktopPointsPerSearch = new Label();
            grpTimes = new GroupBox();
            lblMarginWait = new Label();
            txtMarginWait = new TextBox();
            lblMarginStreakDelay = new Label();
            lblMaxStreakDelay = new Label();
            txtMarginStreakAmount = new TextBox();
            lblMarginStreakAmount = new Label();
            txtMaxStreakAmount = new TextBox();
            lblMaxStreakAmount = new Label();
            txtMarginStreakDelay = new TextBox();
            txtMaxStreakDelay = new TextBox();
            grpGeneral = new GroupBox();
            cbSimulateKeyboardTyping = new CheckBox();
            grpMobile.SuspendLayout();
            grpDesktop.SuspendLayout();
            grpTimes.SuspendLayout();
            grpGeneral.SuspendLayout();
            SuspendLayout();
            // 
            // lblMessage
            // 
            lblMessage.Size = new System.Drawing.Size(1053, 494);
            // 
            // txtMobileUserAgent
            // 
            txtMobileUserAgent.Location = new System.Drawing.Point(112, 22);
            txtMobileUserAgent.Margin = new Padding(4, 3, 4, 3);
            txtMobileUserAgent.Name = "txtMobileUserAgent";
            txtMobileUserAgent.Size = new System.Drawing.Size(618, 23);
            txtMobileUserAgent.TabIndex = 0;
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
            txtMinWait.Location = new System.Drawing.Point(158, 22);
            txtMinWait.Margin = new Padding(4, 3, 4, 3);
            txtMinWait.Name = "txtMinWait";
            txtMinWait.Size = new System.Drawing.Size(67, 23);
            txtMinWait.TabIndex = 0;
            // 
            // lblMinWait
            // 
            lblMinWait.AutoSize = true;
            lblMinWait.Location = new System.Drawing.Point(21, 26);
            lblMinWait.Margin = new Padding(4, 0, 4, 0);
            lblMinWait.Name = "lblMinWait";
            lblMinWait.Size = new System.Drawing.Size(72, 15);
            lblMinWait.TabIndex = 3;
            lblMinWait.Text = "Min. wait (s)";
            // 
            // txtMaxWait
            // 
            txtMaxWait.Location = new System.Drawing.Point(388, 22);
            txtMaxWait.Margin = new Padding(4, 3, 4, 3);
            txtMaxWait.Name = "txtMaxWait";
            txtMaxWait.Size = new System.Drawing.Size(67, 23);
            txtMaxWait.TabIndex = 1;
            // 
            // lblMaxWait
            // 
            lblMaxWait.AutoSize = true;
            lblMaxWait.Location = new System.Drawing.Point(269, 26);
            lblMaxWait.Margin = new Padding(4, 0, 4, 0);
            lblMaxWait.Name = "lblMaxWait";
            lblMaxWait.Size = new System.Drawing.Size(74, 15);
            lblMaxWait.TabIndex = 3;
            lblMaxWait.Text = "Max. wait (s)";
            // 
            // txtMobilePointsPerSearch
            // 
            txtMobilePointsPerSearch.Location = new System.Drawing.Point(112, 51);
            txtMobilePointsPerSearch.Margin = new Padding(4, 3, 4, 3);
            txtMobilePointsPerSearch.Name = "txtMobilePointsPerSearch";
            txtMobilePointsPerSearch.ReadOnly = true;
            txtMobilePointsPerSearch.Size = new System.Drawing.Size(66, 23);
            txtMobilePointsPerSearch.TabIndex = 1;
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
            grpMobile.Controls.Add(cpbsMobileReverse);
            grpMobile.Controls.Add(txtMobileUserAgent);
            grpMobile.Controls.Add(cpbsMobileNormal);
            grpMobile.Controls.Add(lblMobileUserAgent);
            grpMobile.Controls.Add(txtMobileTotalPoints);
            grpMobile.Controls.Add(lblMobileTotalPoints);
            grpMobile.Controls.Add(txtMobilePointsPerSearch);
            grpMobile.Controls.Add(lblMobilePointsPerSearch);
            grpMobile.Location = new System.Drawing.Point(12, 323);
            grpMobile.Name = "grpMobile";
            grpMobile.Size = new System.Drawing.Size(760, 164);
            grpMobile.TabIndex = 2;
            grpMobile.TabStop = false;
            grpMobile.Text = "Mobile";
            // 
            // cpbsMobileReverse
            // 
            cpbsMobileReverse.BorderStyle = BorderStyle.FixedSingle;
            cpbsMobileReverse.Location = new System.Drawing.Point(319, 80);
            cpbsMobileReverse.Name = "cpbsMobileReverse";
            cpbsMobileReverse.ProgressBarColor = System.Drawing.Color.Khaki;
            cpbsMobileReverse.ProgressBarText = "Reverse";
            cpbsMobileReverse.ProgressBarTextColor = System.Drawing.SystemColors.ControlText;
            cpbsMobileReverse.ProgressBarTextFilledColor = System.Drawing.Color.DarkOrchid;
            cpbsMobileReverse.Size = new System.Drawing.Size(302, 66);
            cpbsMobileReverse.TabIndex = 4;
            // 
            // cpbsMobileNormal
            // 
            cpbsMobileNormal.BorderStyle = BorderStyle.FixedSingle;
            cpbsMobileNormal.Location = new System.Drawing.Point(7, 80);
            cpbsMobileNormal.Name = "cpbsMobileNormal";
            cpbsMobileNormal.ProgressBarColor = System.Drawing.Color.DodgerBlue;
            cpbsMobileNormal.ProgressBarText = "Normal";
            cpbsMobileNormal.ProgressBarTextColor = System.Drawing.SystemColors.ControlText;
            cpbsMobileNormal.ProgressBarTextFilledColor = System.Drawing.Color.White;
            cpbsMobileNormal.Size = new System.Drawing.Size(302, 66);
            cpbsMobileNormal.TabIndex = 4;
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
            // txtMinStreakAmount
            // 
            txtMinStreakAmount.Location = new System.Drawing.Point(158, 51);
            txtMinStreakAmount.Margin = new Padding(4, 3, 4, 3);
            txtMinStreakAmount.Name = "txtMinStreakAmount";
            txtMinStreakAmount.Size = new System.Drawing.Size(67, 23);
            txtMinStreakAmount.TabIndex = 3;
            // 
            // lblMinStreakAmount
            // 
            lblMinStreakAmount.AutoSize = true;
            lblMinStreakAmount.Location = new System.Drawing.Point(21, 55);
            lblMinStreakAmount.Margin = new Padding(4, 0, 4, 0);
            lblMinStreakAmount.Name = "lblMinStreakAmount";
            lblMinStreakAmount.Size = new System.Drawing.Size(110, 15);
            lblMinStreakAmount.TabIndex = 3;
            lblMinStreakAmount.Text = "Min. streak amount";
            // 
            // txtMinStreakDelay
            // 
            txtMinStreakDelay.Location = new System.Drawing.Point(158, 80);
            txtMinStreakDelay.Margin = new Padding(4, 3, 4, 3);
            txtMinStreakDelay.Name = "txtMinStreakDelay";
            txtMinStreakDelay.Size = new System.Drawing.Size(67, 23);
            txtMinStreakDelay.TabIndex = 6;
            // 
            // lblMinStreakDelay
            // 
            lblMinStreakDelay.AutoSize = true;
            lblMinStreakDelay.Location = new System.Drawing.Point(21, 84);
            lblMinStreakDelay.Margin = new Padding(4, 0, 4, 0);
            lblMinStreakDelay.Name = "lblMinStreakDelay";
            lblMinStreakDelay.Size = new System.Drawing.Size(112, 15);
            lblMinStreakDelay.TabIndex = 3;
            lblMinStreakDelay.Text = "Min. streak delay (s)";
            // 
            // grpDesktop
            // 
            grpDesktop.Controls.Add(cpbsDesktopReverse);
            grpDesktop.Controls.Add(cpbsDesktopNormal);
            grpDesktop.Controls.Add(txtDesktopUserAgent);
            grpDesktop.Controls.Add(lblDesktopUserAgent);
            grpDesktop.Controls.Add(txtDesktopTotalPoints);
            grpDesktop.Controls.Add(lblDesktopTotalPoints);
            grpDesktop.Controls.Add(txtDesktopPointsPerSearch);
            grpDesktop.Controls.Add(lblDesktopPointsPerSearch);
            grpDesktop.Location = new System.Drawing.Point(12, 137);
            grpDesktop.Name = "grpDesktop";
            grpDesktop.Size = new System.Drawing.Size(760, 180);
            grpDesktop.TabIndex = 1;
            grpDesktop.TabStop = false;
            grpDesktop.Text = "Desktop";
            // 
            // cpbsDesktopReverse
            // 
            cpbsDesktopReverse.BorderStyle = BorderStyle.FixedSingle;
            cpbsDesktopReverse.Location = new System.Drawing.Point(319, 97);
            cpbsDesktopReverse.Name = "cpbsDesktopReverse";
            cpbsDesktopReverse.ProgressBarColor = System.Drawing.Color.Orange;
            cpbsDesktopReverse.ProgressBarText = "Reverse";
            cpbsDesktopReverse.ProgressBarTextColor = System.Drawing.SystemColors.ControlText;
            cpbsDesktopReverse.ProgressBarTextFilledColor = System.Drawing.Color.White;
            cpbsDesktopReverse.Size = new System.Drawing.Size(302, 66);
            cpbsDesktopReverse.TabIndex = 4;
            // 
            // cpbsDesktopNormal
            // 
            cpbsDesktopNormal.BorderStyle = BorderStyle.FixedSingle;
            cpbsDesktopNormal.Location = new System.Drawing.Point(7, 97);
            cpbsDesktopNormal.Name = "cpbsDesktopNormal";
            cpbsDesktopNormal.ProgressBarColor = System.Drawing.Color.Green;
            cpbsDesktopNormal.ProgressBarText = "Normal";
            cpbsDesktopNormal.ProgressBarTextColor = System.Drawing.SystemColors.ControlText;
            cpbsDesktopNormal.ProgressBarTextFilledColor = System.Drawing.Color.White;
            cpbsDesktopNormal.Size = new System.Drawing.Size(302, 66);
            cpbsDesktopNormal.TabIndex = 4;
            // 
            // txtDesktopUserAgent
            // 
            txtDesktopUserAgent.Location = new System.Drawing.Point(112, 22);
            txtDesktopUserAgent.Margin = new Padding(4, 3, 4, 3);
            txtDesktopUserAgent.Name = "txtDesktopUserAgent";
            txtDesktopUserAgent.Size = new System.Drawing.Size(618, 23);
            txtDesktopUserAgent.TabIndex = 0;
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
            txtDesktopPointsPerSearch.ReadOnly = true;
            txtDesktopPointsPerSearch.Size = new System.Drawing.Size(66, 23);
            txtDesktopPointsPerSearch.TabIndex = 1;
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
            // grpTimes
            // 
            grpTimes.Controls.Add(lblMarginWait);
            grpTimes.Controls.Add(lblMaxWait);
            grpTimes.Controls.Add(txtMinWait);
            grpTimes.Controls.Add(txtMarginWait);
            grpTimes.Controls.Add(txtMaxWait);
            grpTimes.Controls.Add(lblMarginStreakDelay);
            grpTimes.Controls.Add(lblMaxStreakDelay);
            grpTimes.Controls.Add(lblMinStreakDelay);
            grpTimes.Controls.Add(txtMarginStreakAmount);
            grpTimes.Controls.Add(lblMarginStreakAmount);
            grpTimes.Controls.Add(txtMaxStreakAmount);
            grpTimes.Controls.Add(lblMaxStreakAmount);
            grpTimes.Controls.Add(txtMinStreakAmount);
            grpTimes.Controls.Add(lblMinStreakAmount);
            grpTimes.Controls.Add(txtMarginStreakDelay);
            grpTimes.Controls.Add(txtMaxStreakDelay);
            grpTimes.Controls.Add(txtMinStreakDelay);
            grpTimes.Controls.Add(lblMinWait);
            grpTimes.Location = new System.Drawing.Point(12, 12);
            grpTimes.Name = "grpTimes";
            grpTimes.Size = new System.Drawing.Size(760, 119);
            grpTimes.TabIndex = 0;
            grpTimes.TabStop = false;
            grpTimes.Text = "Times";
            // 
            // lblMarginWait
            // 
            lblMarginWait.AutoSize = true;
            lblMarginWait.Location = new System.Drawing.Point(532, 26);
            lblMarginWait.Margin = new Padding(4, 0, 4, 0);
            lblMarginWait.Name = "lblMarginWait";
            lblMarginWait.Size = new System.Drawing.Size(86, 15);
            lblMarginWait.TabIndex = 3;
            lblMarginWait.Text = "Margin wait (s)";
            // 
            // txtMarginWait
            // 
            txtMarginWait.Location = new System.Drawing.Point(663, 22);
            txtMarginWait.Margin = new Padding(4, 3, 4, 3);
            txtMarginWait.Name = "txtMarginWait";
            txtMarginWait.Size = new System.Drawing.Size(67, 23);
            txtMarginWait.TabIndex = 2;
            // 
            // lblMarginStreakDelay
            // 
            lblMarginStreakDelay.AutoSize = true;
            lblMarginStreakDelay.Location = new System.Drawing.Point(532, 84);
            lblMarginStreakDelay.Margin = new Padding(4, 0, 4, 0);
            lblMarginStreakDelay.Name = "lblMarginStreakDelay";
            lblMarginStreakDelay.Size = new System.Drawing.Size(126, 15);
            lblMarginStreakDelay.TabIndex = 3;
            lblMarginStreakDelay.Text = "Margin streak delay (s)";
            // 
            // lblMaxStreakDelay
            // 
            lblMaxStreakDelay.AutoSize = true;
            lblMaxStreakDelay.Location = new System.Drawing.Point(269, 84);
            lblMaxStreakDelay.Margin = new Padding(4, 0, 4, 0);
            lblMaxStreakDelay.Name = "lblMaxStreakDelay";
            lblMaxStreakDelay.Size = new System.Drawing.Size(114, 15);
            lblMaxStreakDelay.TabIndex = 3;
            lblMaxStreakDelay.Text = "Max. streak delay (s)";
            // 
            // txtMarginStreakAmount
            // 
            txtMarginStreakAmount.Location = new System.Drawing.Point(663, 51);
            txtMarginStreakAmount.Margin = new Padding(4, 3, 4, 3);
            txtMarginStreakAmount.Name = "txtMarginStreakAmount";
            txtMarginStreakAmount.Size = new System.Drawing.Size(67, 23);
            txtMarginStreakAmount.TabIndex = 5;
            // 
            // lblMarginStreakAmount
            // 
            lblMarginStreakAmount.AutoSize = true;
            lblMarginStreakAmount.Location = new System.Drawing.Point(532, 55);
            lblMarginStreakAmount.Margin = new Padding(4, 0, 4, 0);
            lblMarginStreakAmount.Name = "lblMarginStreakAmount";
            lblMarginStreakAmount.Size = new System.Drawing.Size(124, 15);
            lblMarginStreakAmount.TabIndex = 3;
            lblMarginStreakAmount.Text = "Margin streak amount";
            // 
            // txtMaxStreakAmount
            // 
            txtMaxStreakAmount.Location = new System.Drawing.Point(388, 51);
            txtMaxStreakAmount.Margin = new Padding(4, 3, 4, 3);
            txtMaxStreakAmount.Name = "txtMaxStreakAmount";
            txtMaxStreakAmount.Size = new System.Drawing.Size(67, 23);
            txtMaxStreakAmount.TabIndex = 4;
            // 
            // lblMaxStreakAmount
            // 
            lblMaxStreakAmount.AutoSize = true;
            lblMaxStreakAmount.Location = new System.Drawing.Point(269, 55);
            lblMaxStreakAmount.Margin = new Padding(4, 0, 4, 0);
            lblMaxStreakAmount.Name = "lblMaxStreakAmount";
            lblMaxStreakAmount.Size = new System.Drawing.Size(112, 15);
            lblMaxStreakAmount.TabIndex = 3;
            lblMaxStreakAmount.Text = "Max. streak amount";
            // 
            // txtMarginStreakDelay
            // 
            txtMarginStreakDelay.Location = new System.Drawing.Point(663, 80);
            txtMarginStreakDelay.Margin = new Padding(4, 3, 4, 3);
            txtMarginStreakDelay.Name = "txtMarginStreakDelay";
            txtMarginStreakDelay.Size = new System.Drawing.Size(67, 23);
            txtMarginStreakDelay.TabIndex = 8;
            // 
            // txtMaxStreakDelay
            // 
            txtMaxStreakDelay.Location = new System.Drawing.Point(388, 80);
            txtMaxStreakDelay.Margin = new Padding(4, 3, 4, 3);
            txtMaxStreakDelay.Name = "txtMaxStreakDelay";
            txtMaxStreakDelay.Size = new System.Drawing.Size(67, 23);
            txtMaxStreakDelay.TabIndex = 7;
            // 
            // grpGeneral
            // 
            grpGeneral.Controls.Add(cbSimulateKeyboardTyping);
            grpGeneral.Location = new System.Drawing.Point(778, 12);
            grpGeneral.Name = "grpGeneral";
            grpGeneral.Size = new System.Drawing.Size(263, 119);
            grpGeneral.TabIndex = 3;
            grpGeneral.TabStop = false;
            grpGeneral.Text = "General";
            // 
            // cbSimulateKeyboardTyping
            // 
            cbSimulateKeyboardTyping.AutoSize = true;
            cbSimulateKeyboardTyping.Location = new System.Drawing.Point(24, 22);
            cbSimulateKeyboardTyping.Name = "cbSimulateKeyboardTyping";
            cbSimulateKeyboardTyping.Size = new System.Drawing.Size(161, 19);
            cbSimulateKeyboardTyping.TabIndex = 0;
            cbSimulateKeyboardTyping.Text = "Simulate keyboard typing";
            cbSimulateKeyboardTyping.UseVisualStyleBackColor = true;
            // 
            // PreferencesForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1053, 527);
            Controls.Add(grpGeneral);
            Controls.Add(grpTimes);
            Controls.Add(grpDesktop);
            Controls.Add(grpMobile);
            Margin = new Padding(5, 3, 5, 3);
            Name = "PreferencesForm";
            Text = "Preferences";
            Controls.SetChildIndex(lblMessage, 0);
            Controls.SetChildIndex(grpMobile, 0);
            Controls.SetChildIndex(grpDesktop, 0);
            Controls.SetChildIndex(grpTimes, 0);
            Controls.SetChildIndex(grpGeneral, 0);
            grpMobile.ResumeLayout(false);
            grpMobile.PerformLayout();
            grpDesktop.ResumeLayout(false);
            grpDesktop.PerformLayout();
            grpTimes.ResumeLayout(false);
            grpTimes.PerformLayout();
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
        private TextBox txtMinStreakAmount;
        private Label lblMinStreakAmount;
        private TextBox txtMinStreakDelay;
        private Label lblMinStreakDelay;
        private TextBox txtMobileTotalPoints;
        private Label lblMobileTotalPoints;
        private GroupBox grpDesktop;
        private TextBox txtDesktopUserAgent;
        private Label lblDesktopUserAgent;
        private TextBox txtDesktopTotalPoints;
        private Label lblDesktopTotalPoints;
        private TextBox txtDesktopPointsPerSearch;
        private Label lblDesktopPointsPerSearch;
        private GroupBox grpTimes;
        private Label lblMarginWait;
        private TextBox txtMarginWait;
        private Label lblMarginStreakDelay;
        private Label lblMaxStreakDelay;
        private TextBox txtMarginStreakAmount;
        private Label lblMarginStreakAmount;
        private TextBox txtMaxStreakAmount;
        private Label lblMaxStreakAmount;
        private TextBox txtMarginStreakDelay;
        private TextBox txtMaxStreakDelay;
        private src.UI.CustomProgressBarSettings cpbsDesktopNormal;
        private src.UI.CustomProgressBarSettings cpbsDesktopReverse;
        private src.UI.CustomProgressBarSettings cpbsMobileReverse;
        private src.UI.CustomProgressBarSettings cpbsMobileNormal;
        private GroupBox grpGeneral;
        private CheckBox cbSimulateKeyboardTyping;
    }
}