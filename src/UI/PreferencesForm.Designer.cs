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
            components = new System.ComponentModel.Container();
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
            lblMarginExtracPointsDelay = new Label();
            lblMarginStreakDelay = new Label();
            lblMaxExtracPointsDelay = new Label();
            lblMaxStreakDelay = new Label();
            lblMinExtracPointsDelay = new Label();
            txtMarginStreakAmount = new TextBox();
            lblMarginStreakAmount = new Label();
            txtMaxStreakAmount = new TextBox();
            lblMaxStreakAmount = new Label();
            txtMarginExtracPointsDelay = new TextBox();
            txtMaxExtracPointsDelay = new TextBox();
            txtMarginStreakDelay = new TextBox();
            txtMinExtracPointsDelay = new TextBox();
            txtMaxStreakDelay = new TextBox();
            grpGeneral = new GroupBox();
            cbSimulateKeyboardTyping = new CheckBox();
            toolTip1 = new ToolTip(components);
            grpMobile.SuspendLayout();
            grpDesktop.SuspendLayout();
            grpTimes.SuspendLayout();
            grpGeneral.SuspendLayout();
            SuspendLayout();
            // 
            // lblMessage
            // 
            lblMessage.Size = new System.Drawing.Size(1053, 532);
            // 
            // txtMobileUserAgent
            // 
            txtMobileUserAgent.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtMobileUserAgent.Location = new System.Drawing.Point(112, 22);
            txtMobileUserAgent.Margin = new Padding(4, 3, 4, 3);
            txtMobileUserAgent.Name = "txtMobileUserAgent";
            txtMobileUserAgent.Size = new System.Drawing.Size(887, 23);
            txtMobileUserAgent.TabIndex = 0;
            toolTip1.SetToolTip(txtMobileUserAgent, "Specifies the User-Agent string used to simulate searches from a mobile browser.");
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
            toolTip1.SetToolTip(lblMobileUserAgent, "Specifies the User-Agent string used to simulate searches from a mobile browser.");
            // 
            // txtMinWait
            // 
            txtMinWait.Location = new System.Drawing.Point(158, 22);
            txtMinWait.Margin = new Padding(4, 3, 4, 3);
            txtMinWait.Name = "txtMinWait";
            txtMinWait.Size = new System.Drawing.Size(67, 23);
            txtMinWait.TabIndex = 0;
            toolTip1.SetToolTip(txtMinWait, "The minimum waiting time (in seconds) between consecutive searches within a streak. A random value within the range will be selected.");
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
            toolTip1.SetToolTip(lblMinWait, "The minimum waiting time (in seconds) between consecutive searches within a streak. A random value within the range will be selected.");
            // 
            // txtMaxWait
            // 
            txtMaxWait.Location = new System.Drawing.Point(388, 22);
            txtMaxWait.Margin = new Padding(4, 3, 4, 3);
            txtMaxWait.Name = "txtMaxWait";
            txtMaxWait.Size = new System.Drawing.Size(67, 23);
            txtMaxWait.TabIndex = 1;
            toolTip1.SetToolTip(txtMaxWait, "The maximum waiting time (in seconds) between consecutive searches within a streak. A random value within the range will be selected.");
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
            toolTip1.SetToolTip(lblMaxWait, "The maximum waiting time (in seconds) between consecutive searches within a streak. A random value within the range will be selected.");
            // 
            // txtMobilePointsPerSearch
            // 
            txtMobilePointsPerSearch.Location = new System.Drawing.Point(112, 51);
            txtMobilePointsPerSearch.Margin = new Padding(4, 3, 4, 3);
            txtMobilePointsPerSearch.Name = "txtMobilePointsPerSearch";
            txtMobilePointsPerSearch.ReadOnly = true;
            txtMobilePointsPerSearch.Size = new System.Drawing.Size(66, 23);
            txtMobilePointsPerSearch.TabIndex = 1;
            toolTip1.SetToolTip(txtMobilePointsPerSearch, "The amount of points earned per search.");
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
            toolTip1.SetToolTip(lblMobilePointsPerSearch, "The amount of points earned per search.");
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
            grpMobile.Location = new System.Drawing.Point(12, 362);
            grpMobile.Name = "grpMobile";
            grpMobile.Size = new System.Drawing.Size(1029, 164);
            grpMobile.TabIndex = 4;
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
            toolTip1.SetToolTip(txtMobileTotalPoints, "Displays the total possible points to earn.");
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
            toolTip1.SetToolTip(lblMobileTotalPoints, "Displays the total possible points to earn.");
            // 
            // txtMinStreakAmount
            // 
            txtMinStreakAmount.Location = new System.Drawing.Point(158, 51);
            txtMinStreakAmount.Margin = new Padding(4, 3, 4, 3);
            txtMinStreakAmount.Name = "txtMinStreakAmount";
            txtMinStreakAmount.Size = new System.Drawing.Size(67, 23);
            txtMinStreakAmount.TabIndex = 3;
            toolTip1.SetToolTip(txtMinStreakAmount, "The minimum number of searches performed in a single streak. A random value within the range will be selected.");
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
            toolTip1.SetToolTip(lblMinStreakAmount, "The minimum number of searches performed in a single streak. A random value within the range will be selected.");
            // 
            // txtMinStreakDelay
            // 
            txtMinStreakDelay.Location = new System.Drawing.Point(158, 80);
            txtMinStreakDelay.Margin = new Padding(4, 3, 4, 3);
            txtMinStreakDelay.Name = "txtMinStreakDelay";
            txtMinStreakDelay.Size = new System.Drawing.Size(67, 23);
            txtMinStreakDelay.TabIndex = 6;
            toolTip1.SetToolTip(txtMinStreakDelay, "The minimum waiting time (in seconds) before starting a new streak after completing the current one. A random value within the range will be selected.");
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
            toolTip1.SetToolTip(lblMinStreakDelay, "The minimum waiting time (in seconds) before starting a new streak after completing the current one. A random value within the range will be selected.");
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
            grpDesktop.Location = new System.Drawing.Point(12, 176);
            grpDesktop.Name = "grpDesktop";
            grpDesktop.Size = new System.Drawing.Size(1029, 180);
            grpDesktop.TabIndex = 3;
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
            txtDesktopUserAgent.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtDesktopUserAgent.Location = new System.Drawing.Point(112, 22);
            txtDesktopUserAgent.Margin = new Padding(4, 3, 4, 3);
            txtDesktopUserAgent.Name = "txtDesktopUserAgent";
            txtDesktopUserAgent.Size = new System.Drawing.Size(887, 23);
            txtDesktopUserAgent.TabIndex = 0;
            toolTip1.SetToolTip(txtDesktopUserAgent, "Specifies the User-Agent string used to simulate searches from a desktop browser.");
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
            toolTip1.SetToolTip(lblDesktopUserAgent, "Specifies the User-Agent string used to simulate searches from a desktop browser.");
            // 
            // txtDesktopTotalPoints
            // 
            txtDesktopTotalPoints.Location = new System.Drawing.Point(311, 51);
            txtDesktopTotalPoints.Margin = new Padding(4, 3, 4, 3);
            txtDesktopTotalPoints.Name = "txtDesktopTotalPoints";
            txtDesktopTotalPoints.ReadOnly = true;
            txtDesktopTotalPoints.Size = new System.Drawing.Size(66, 23);
            txtDesktopTotalPoints.TabIndex = 2;
            toolTip1.SetToolTip(txtDesktopTotalPoints, "Displays the total possible points to earn.");
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
            toolTip1.SetToolTip(txtDesktopPointsPerSearch, "The amount of points earned per search.");
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
            toolTip1.SetToolTip(lblDesktopPointsPerSearch, "The amount of points earned per search.");
            // 
            // grpTimes
            // 
            grpTimes.Controls.Add(lblMarginWait);
            grpTimes.Controls.Add(lblMaxWait);
            grpTimes.Controls.Add(txtMinWait);
            grpTimes.Controls.Add(txtMarginWait);
            grpTimes.Controls.Add(txtMaxWait);
            grpTimes.Controls.Add(lblMarginExtracPointsDelay);
            grpTimes.Controls.Add(lblMarginStreakDelay);
            grpTimes.Controls.Add(lblMaxExtracPointsDelay);
            grpTimes.Controls.Add(lblMaxStreakDelay);
            grpTimes.Controls.Add(lblMinExtracPointsDelay);
            grpTimes.Controls.Add(lblMinStreakDelay);
            grpTimes.Controls.Add(txtMarginStreakAmount);
            grpTimes.Controls.Add(lblMarginStreakAmount);
            grpTimes.Controls.Add(txtMaxStreakAmount);
            grpTimes.Controls.Add(lblMaxStreakAmount);
            grpTimes.Controls.Add(txtMinStreakAmount);
            grpTimes.Controls.Add(lblMinStreakAmount);
            grpTimes.Controls.Add(txtMarginExtracPointsDelay);
            grpTimes.Controls.Add(txtMaxExtracPointsDelay);
            grpTimes.Controls.Add(txtMarginStreakDelay);
            grpTimes.Controls.Add(txtMinExtracPointsDelay);
            grpTimes.Controls.Add(txtMaxStreakDelay);
            grpTimes.Controls.Add(txtMinStreakDelay);
            grpTimes.Controls.Add(lblMinWait);
            grpTimes.Location = new System.Drawing.Point(12, 12);
            grpTimes.Name = "grpTimes";
            grpTimes.Size = new System.Drawing.Size(760, 158);
            grpTimes.TabIndex = 1;
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
            toolTip1.SetToolTip(lblMarginWait, "Additional random margin applied to the waiting time between searches, making the intervals less predictable.");
            // 
            // txtMarginWait
            // 
            txtMarginWait.Location = new System.Drawing.Point(663, 22);
            txtMarginWait.Margin = new Padding(4, 3, 4, 3);
            txtMarginWait.Name = "txtMarginWait";
            txtMarginWait.Size = new System.Drawing.Size(67, 23);
            txtMarginWait.TabIndex = 2;
            toolTip1.SetToolTip(txtMarginWait, "Additional random margin applied to the waiting time between searches, making the intervals less predictable.");
            // 
            // lblMarginExtracPointsDelay
            // 
            lblMarginExtracPointsDelay.AutoSize = true;
            lblMarginExtracPointsDelay.Location = new System.Drawing.Point(532, 113);
            lblMarginExtracPointsDelay.Margin = new Padding(4, 0, 4, 0);
            lblMarginExtracPointsDelay.Name = "lblMarginExtracPointsDelay";
            lblMarginExtracPointsDelay.Size = new System.Drawing.Size(117, 15);
            lblMarginExtracPointsDelay.TabIndex = 3;
            lblMarginExtracPointsDelay.Text = "Margin e. p. delay (s)";
            toolTip1.SetToolTip(lblMarginExtracPointsDelay, "Additional random margin applied to the delay for points extraction, increasing variability.");
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
            toolTip1.SetToolTip(lblMarginStreakDelay, "Additional random margin applied to the delay between streaks for added unpredictability.");
            // 
            // lblMaxExtracPointsDelay
            // 
            lblMaxExtracPointsDelay.AutoSize = true;
            lblMaxExtracPointsDelay.Location = new System.Drawing.Point(269, 113);
            lblMaxExtracPointsDelay.Margin = new Padding(4, 0, 4, 0);
            lblMaxExtracPointsDelay.Name = "lblMaxExtracPointsDelay";
            lblMaxExtracPointsDelay.Size = new System.Drawing.Size(105, 15);
            lblMaxExtracPointsDelay.TabIndex = 3;
            lblMaxExtracPointsDelay.Text = "Max. e. p. delay (s)";
            toolTip1.SetToolTip(lblMaxExtracPointsDelay, "The maximum waiting time (in seconds) before performing a points extraction to check the user's current points. A random value within the range will be selected.");
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
            toolTip1.SetToolTip(lblMaxStreakDelay, "The maximum waiting time (in seconds) before starting a new streak after completing the current one. A random value within the range will be selected.");
            // 
            // lblMinExtracPointsDelay
            // 
            lblMinExtracPointsDelay.AutoSize = true;
            lblMinExtracPointsDelay.Location = new System.Drawing.Point(21, 113);
            lblMinExtracPointsDelay.Margin = new Padding(4, 0, 4, 0);
            lblMinExtracPointsDelay.Name = "lblMinExtracPointsDelay";
            lblMinExtracPointsDelay.Size = new System.Drawing.Size(103, 15);
            lblMinExtracPointsDelay.TabIndex = 3;
            lblMinExtracPointsDelay.Text = "Min. e. p. delay (s)";
            toolTip1.SetToolTip(lblMinExtracPointsDelay, "The minimum waiting time (in seconds) before performing a points extraction to check the user's current points. A random value within the range will be selected.");
            // 
            // txtMarginStreakAmount
            // 
            txtMarginStreakAmount.Location = new System.Drawing.Point(663, 51);
            txtMarginStreakAmount.Margin = new Padding(4, 3, 4, 3);
            txtMarginStreakAmount.Name = "txtMarginStreakAmount";
            txtMarginStreakAmount.Size = new System.Drawing.Size(67, 23);
            txtMarginStreakAmount.TabIndex = 5;
            toolTip1.SetToolTip(txtMarginStreakAmount, "Additional random margin applied to the number of searches in a streak, adding variability.");
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
            toolTip1.SetToolTip(lblMarginStreakAmount, "Additional random margin applied to the number of searches in a streak, adding variability.");
            // 
            // txtMaxStreakAmount
            // 
            txtMaxStreakAmount.Location = new System.Drawing.Point(388, 51);
            txtMaxStreakAmount.Margin = new Padding(4, 3, 4, 3);
            txtMaxStreakAmount.Name = "txtMaxStreakAmount";
            txtMaxStreakAmount.Size = new System.Drawing.Size(67, 23);
            txtMaxStreakAmount.TabIndex = 4;
            toolTip1.SetToolTip(txtMaxStreakAmount, "The maximum number of searches performed in a single streak. A random value within the range will be selected.");
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
            toolTip1.SetToolTip(lblMaxStreakAmount, "The maximum number of searches performed in a single streak. A random value within the range will be selected.");
            // 
            // txtMarginExtracPointsDelay
            // 
            txtMarginExtracPointsDelay.Location = new System.Drawing.Point(663, 109);
            txtMarginExtracPointsDelay.Margin = new Padding(4, 3, 4, 3);
            txtMarginExtracPointsDelay.Name = "txtMarginExtracPointsDelay";
            txtMarginExtracPointsDelay.Size = new System.Drawing.Size(67, 23);
            txtMarginExtracPointsDelay.TabIndex = 11;
            toolTip1.SetToolTip(txtMarginExtracPointsDelay, "Additional random margin applied to the delay for points extraction, increasing variability.");
            // 
            // txtMaxExtracPointsDelay
            // 
            txtMaxExtracPointsDelay.Location = new System.Drawing.Point(388, 109);
            txtMaxExtracPointsDelay.Margin = new Padding(4, 3, 4, 3);
            txtMaxExtracPointsDelay.Name = "txtMaxExtracPointsDelay";
            txtMaxExtracPointsDelay.Size = new System.Drawing.Size(67, 23);
            txtMaxExtracPointsDelay.TabIndex = 10;
            toolTip1.SetToolTip(txtMaxExtracPointsDelay, "The maximum waiting time (in seconds) before performing a points extraction to check the user's current points. A random value within the range will be selected.");
            // 
            // txtMarginStreakDelay
            // 
            txtMarginStreakDelay.Location = new System.Drawing.Point(663, 80);
            txtMarginStreakDelay.Margin = new Padding(4, 3, 4, 3);
            txtMarginStreakDelay.Name = "txtMarginStreakDelay";
            txtMarginStreakDelay.Size = new System.Drawing.Size(67, 23);
            txtMarginStreakDelay.TabIndex = 8;
            toolTip1.SetToolTip(txtMarginStreakDelay, "Additional random margin applied to the delay between streaks for added unpredictability.");
            // 
            // txtMinExtracPointsDelay
            // 
            txtMinExtracPointsDelay.Location = new System.Drawing.Point(158, 109);
            txtMinExtracPointsDelay.Margin = new Padding(4, 3, 4, 3);
            txtMinExtracPointsDelay.Name = "txtMinExtracPointsDelay";
            txtMinExtracPointsDelay.Size = new System.Drawing.Size(67, 23);
            txtMinExtracPointsDelay.TabIndex = 9;
            toolTip1.SetToolTip(txtMinExtracPointsDelay, "The minimum waiting time (in seconds) before performing a points extraction to check the user's current points. A random value within the range will be selected.");
            // 
            // txtMaxStreakDelay
            // 
            txtMaxStreakDelay.Location = new System.Drawing.Point(388, 80);
            txtMaxStreakDelay.Margin = new Padding(4, 3, 4, 3);
            txtMaxStreakDelay.Name = "txtMaxStreakDelay";
            txtMaxStreakDelay.Size = new System.Drawing.Size(67, 23);
            txtMaxStreakDelay.TabIndex = 7;
            toolTip1.SetToolTip(txtMaxStreakDelay, "The maximum waiting time (in seconds) before starting a new streak after completing the current one. A random value within the range will be selected.");
            // 
            // grpGeneral
            // 
            grpGeneral.Controls.Add(cbSimulateKeyboardTyping);
            grpGeneral.Location = new System.Drawing.Point(778, 12);
            grpGeneral.Name = "grpGeneral";
            grpGeneral.Size = new System.Drawing.Size(263, 119);
            grpGeneral.TabIndex = 2;
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
            toolTip1.SetToolTip(cbSimulateKeyboardTyping, "Enables simulation of keyboard typing during searches to mimic human behavior and avoid detection.");
            cbSimulateKeyboardTyping.UseVisualStyleBackColor = true;
            // 
            // PreferencesForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1053, 565);
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
        private Label lblMarginExtracPointsDelay;
        private Label lblMaxExtracPointsDelay;
        private Label lblMinExtracPointsDelay;
        private TextBox txtMarginExtracPointsDelay;
        private TextBox txtMaxExtracPointsDelay;
        private TextBox txtMinExtracPointsDelay;
        private ToolTip toolTip1;
    }
}