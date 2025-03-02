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
            cpbsMobileReverse = new EdgeSearch.src.UI.CustomProgressBarSettings();
            cpbsMobileNormal = new EdgeSearch.src.UI.CustomProgressBarSettings();
            txtMobileTotalPoints = new TextBox();
            lblMobileTotalPoints = new Label();
            txtMinStreakAmount = new TextBox();
            lblMinStreakAmount = new Label();
            txtMinStreakDelay = new TextBox();
            lblMinStreakDelay = new Label();
            grpDesktop = new GroupBox();
            cpbsDesktopReverse = new EdgeSearch.src.UI.CustomProgressBarSettings();
            cpbsDesktopNormal = new EdgeSearch.src.UI.CustomProgressBarSettings();
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
            grpExtras = new GroupBox();
            cbSimulateKeyboardTyping = new CheckBox();
            toolTip1 = new ToolTip(components);
            tabControl = new TabControl();
            tpGeneral = new TabPage();
            grpUrls = new GroupBox();
            lblUrlRewards = new Label();
            lblUrlSearches = new Label();
            txtUrlRewards = new TextBox();
            txtUrlSearches = new TextBox();
            tpUserAgents = new TabPage();
            lblSearchesParameter = new Label();
            txtSearchesParameter = new TextBox();
            grpMobile.SuspendLayout();
            grpDesktop.SuspendLayout();
            grpTimes.SuspendLayout();
            grpExtras.SuspendLayout();
            tabControl.SuspendLayout();
            tpGeneral.SuspendLayout();
            grpUrls.SuspendLayout();
            tpUserAgents.SuspendLayout();
            SuspendLayout();
            // 
            // lblMessage
            // 
            lblMessage.Margin = new Padding(9, 0, 9, 0);
            lblMessage.Size = new System.Drawing.Size(1805, 1064);
            // 
            // txtMobileUserAgent
            // 
            txtMobileUserAgent.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtMobileUserAgent.Location = new System.Drawing.Point(192, 44);
            txtMobileUserAgent.Margin = new Padding(7, 6, 7, 6);
            txtMobileUserAgent.Name = "txtMobileUserAgent";
            txtMobileUserAgent.Size = new System.Drawing.Size(1518, 35);
            txtMobileUserAgent.TabIndex = 0;
            toolTip1.SetToolTip(txtMobileUserAgent, "Specifies the User-Agent string used to simulate searches from a mobile browser.");
            // 
            // lblMobileUserAgent
            // 
            lblMobileUserAgent.AutoSize = true;
            lblMobileUserAgent.Location = new System.Drawing.Point(12, 52);
            lblMobileUserAgent.Margin = new Padding(7, 0, 7, 0);
            lblMobileUserAgent.Name = "lblMobileUserAgent";
            lblMobileUserAgent.Size = new System.Drawing.Size(116, 30);
            lblMobileUserAgent.TabIndex = 3;
            lblMobileUserAgent.Text = "User Agent";
            toolTip1.SetToolTip(lblMobileUserAgent, "Specifies the User-Agent string used to simulate searches from a mobile browser.");
            // 
            // txtMinWait
            // 
            txtMinWait.Location = new System.Drawing.Point(271, 44);
            txtMinWait.Margin = new Padding(7, 6, 7, 6);
            txtMinWait.Name = "txtMinWait";
            txtMinWait.Size = new System.Drawing.Size(112, 35);
            txtMinWait.TabIndex = 0;
            toolTip1.SetToolTip(txtMinWait, "The minimum waiting time (in seconds) between consecutive searches within a streak. A random value within the range will be selected.");
            // 
            // lblMinWait
            // 
            lblMinWait.AutoSize = true;
            lblMinWait.Location = new System.Drawing.Point(36, 52);
            lblMinWait.Margin = new Padding(7, 0, 7, 0);
            lblMinWait.Name = "lblMinWait";
            lblMinWait.Size = new System.Drawing.Size(125, 30);
            lblMinWait.TabIndex = 3;
            lblMinWait.Text = "Min. wait (s)";
            toolTip1.SetToolTip(lblMinWait, "The minimum waiting time (in seconds) between consecutive searches within a streak. A random value within the range will be selected.");
            // 
            // txtMaxWait
            // 
            txtMaxWait.Location = new System.Drawing.Point(665, 44);
            txtMaxWait.Margin = new Padding(7, 6, 7, 6);
            txtMaxWait.Name = "txtMaxWait";
            txtMaxWait.Size = new System.Drawing.Size(112, 35);
            txtMaxWait.TabIndex = 1;
            toolTip1.SetToolTip(txtMaxWait, "The maximum waiting time (in seconds) between consecutive searches within a streak. A random value within the range will be selected.");
            // 
            // lblMaxWait
            // 
            lblMaxWait.AutoSize = true;
            lblMaxWait.Location = new System.Drawing.Point(461, 52);
            lblMaxWait.Margin = new Padding(7, 0, 7, 0);
            lblMaxWait.Name = "lblMaxWait";
            lblMaxWait.Size = new System.Drawing.Size(129, 30);
            lblMaxWait.TabIndex = 3;
            lblMaxWait.Text = "Max. wait (s)";
            toolTip1.SetToolTip(lblMaxWait, "The maximum waiting time (in seconds) between consecutive searches within a streak. A random value within the range will be selected.");
            // 
            // txtMobilePointsPerSearch
            // 
            txtMobilePointsPerSearch.Location = new System.Drawing.Point(192, 102);
            txtMobilePointsPerSearch.Margin = new Padding(7, 6, 7, 6);
            txtMobilePointsPerSearch.Name = "txtMobilePointsPerSearch";
            txtMobilePointsPerSearch.ReadOnly = true;
            txtMobilePointsPerSearch.Size = new System.Drawing.Size(110, 35);
            txtMobilePointsPerSearch.TabIndex = 1;
            toolTip1.SetToolTip(txtMobilePointsPerSearch, "The amount of points earned per search.");
            // 
            // lblMobilePointsPerSearch
            // 
            lblMobilePointsPerSearch.AutoSize = true;
            lblMobilePointsPerSearch.Location = new System.Drawing.Point(12, 110);
            lblMobilePointsPerSearch.Margin = new Padding(7, 0, 7, 0);
            lblMobilePointsPerSearch.Name = "lblMobilePointsPerSearch";
            lblMobilePointsPerSearch.Size = new System.Drawing.Size(171, 30);
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
            grpMobile.Location = new System.Drawing.Point(8, 381);
            grpMobile.Margin = new Padding(5, 6, 5, 6);
            grpMobile.Name = "grpMobile";
            grpMobile.Padding = new Padding(5, 6, 5, 6);
            grpMobile.Size = new System.Drawing.Size(1764, 328);
            grpMobile.TabIndex = 4;
            grpMobile.TabStop = false;
            grpMobile.Text = "Mobile";
            // 
            // cpbsMobileReverse
            // 
            cpbsMobileReverse.BorderStyle = BorderStyle.FixedSingle;
            cpbsMobileReverse.Location = new System.Drawing.Point(547, 160);
            cpbsMobileReverse.Margin = new Padding(9, 12, 9, 12);
            cpbsMobileReverse.Name = "cpbsMobileReverse";
            cpbsMobileReverse.ProgressBarColor = System.Drawing.Color.Khaki;
            cpbsMobileReverse.ProgressBarText = "Reverse";
            cpbsMobileReverse.ProgressBarTextColor = System.Drawing.SystemColors.ControlText;
            cpbsMobileReverse.ProgressBarTextFilledColor = System.Drawing.Color.DarkOrchid;
            cpbsMobileReverse.Size = new System.Drawing.Size(516, 130);
            cpbsMobileReverse.TabIndex = 4;
            // 
            // cpbsMobileNormal
            // 
            cpbsMobileNormal.BorderStyle = BorderStyle.FixedSingle;
            cpbsMobileNormal.Location = new System.Drawing.Point(12, 160);
            cpbsMobileNormal.Margin = new Padding(9, 12, 9, 12);
            cpbsMobileNormal.Name = "cpbsMobileNormal";
            cpbsMobileNormal.ProgressBarColor = System.Drawing.Color.DodgerBlue;
            cpbsMobileNormal.ProgressBarText = "Normal";
            cpbsMobileNormal.ProgressBarTextColor = System.Drawing.SystemColors.ControlText;
            cpbsMobileNormal.ProgressBarTextFilledColor = System.Drawing.Color.White;
            cpbsMobileNormal.Size = new System.Drawing.Size(516, 130);
            cpbsMobileNormal.TabIndex = 4;
            // 
            // txtMobileTotalPoints
            // 
            txtMobileTotalPoints.Location = new System.Drawing.Point(533, 102);
            txtMobileTotalPoints.Margin = new Padding(7, 6, 7, 6);
            txtMobileTotalPoints.Name = "txtMobileTotalPoints";
            txtMobileTotalPoints.ReadOnly = true;
            txtMobileTotalPoints.Size = new System.Drawing.Size(110, 35);
            txtMobileTotalPoints.TabIndex = 2;
            toolTip1.SetToolTip(txtMobileTotalPoints, "Displays the total possible points to earn.");
            // 
            // lblMobileTotalPoints
            // 
            lblMobileTotalPoints.AutoSize = true;
            lblMobileTotalPoints.Location = new System.Drawing.Point(403, 110);
            lblMobileTotalPoints.Margin = new Padding(7, 0, 7, 0);
            lblMobileTotalPoints.Name = "lblMobileTotalPoints";
            lblMobileTotalPoints.Size = new System.Drawing.Size(120, 30);
            lblMobileTotalPoints.TabIndex = 3;
            lblMobileTotalPoints.Text = "Total points";
            toolTip1.SetToolTip(lblMobileTotalPoints, "Displays the total possible points to earn.");
            // 
            // txtMinStreakAmount
            // 
            txtMinStreakAmount.Location = new System.Drawing.Point(271, 102);
            txtMinStreakAmount.Margin = new Padding(7, 6, 7, 6);
            txtMinStreakAmount.Name = "txtMinStreakAmount";
            txtMinStreakAmount.Size = new System.Drawing.Size(112, 35);
            txtMinStreakAmount.TabIndex = 3;
            toolTip1.SetToolTip(txtMinStreakAmount, "The minimum number of searches performed in a single streak. A random value within the range will be selected.");
            // 
            // lblMinStreakAmount
            // 
            lblMinStreakAmount.AutoSize = true;
            lblMinStreakAmount.Location = new System.Drawing.Point(36, 110);
            lblMinStreakAmount.Margin = new Padding(7, 0, 7, 0);
            lblMinStreakAmount.Name = "lblMinStreakAmount";
            lblMinStreakAmount.Size = new System.Drawing.Size(193, 30);
            lblMinStreakAmount.TabIndex = 3;
            lblMinStreakAmount.Text = "Min. streak amount";
            toolTip1.SetToolTip(lblMinStreakAmount, "The minimum number of searches performed in a single streak. A random value within the range will be selected.");
            // 
            // txtMinStreakDelay
            // 
            txtMinStreakDelay.Location = new System.Drawing.Point(271, 160);
            txtMinStreakDelay.Margin = new Padding(7, 6, 7, 6);
            txtMinStreakDelay.Name = "txtMinStreakDelay";
            txtMinStreakDelay.Size = new System.Drawing.Size(112, 35);
            txtMinStreakDelay.TabIndex = 6;
            toolTip1.SetToolTip(txtMinStreakDelay, "The minimum waiting time (in seconds) before starting a new streak after completing the current one. A random value within the range will be selected.");
            // 
            // lblMinStreakDelay
            // 
            lblMinStreakDelay.AutoSize = true;
            lblMinStreakDelay.Location = new System.Drawing.Point(36, 168);
            lblMinStreakDelay.Margin = new Padding(7, 0, 7, 0);
            lblMinStreakDelay.Name = "lblMinStreakDelay";
            lblMinStreakDelay.Size = new System.Drawing.Size(197, 30);
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
            grpDesktop.Location = new System.Drawing.Point(10, 9);
            grpDesktop.Margin = new Padding(5, 6, 5, 6);
            grpDesktop.Name = "grpDesktop";
            grpDesktop.Padding = new Padding(5, 6, 5, 6);
            grpDesktop.Size = new System.Drawing.Size(1764, 360);
            grpDesktop.TabIndex = 3;
            grpDesktop.TabStop = false;
            grpDesktop.Text = "Desktop";
            // 
            // cpbsDesktopReverse
            // 
            cpbsDesktopReverse.BorderStyle = BorderStyle.FixedSingle;
            cpbsDesktopReverse.Location = new System.Drawing.Point(547, 194);
            cpbsDesktopReverse.Margin = new Padding(9, 12, 9, 12);
            cpbsDesktopReverse.Name = "cpbsDesktopReverse";
            cpbsDesktopReverse.ProgressBarColor = System.Drawing.Color.Orange;
            cpbsDesktopReverse.ProgressBarText = "Reverse";
            cpbsDesktopReverse.ProgressBarTextColor = System.Drawing.SystemColors.ControlText;
            cpbsDesktopReverse.ProgressBarTextFilledColor = System.Drawing.Color.White;
            cpbsDesktopReverse.Size = new System.Drawing.Size(516, 130);
            cpbsDesktopReverse.TabIndex = 4;
            // 
            // cpbsDesktopNormal
            // 
            cpbsDesktopNormal.BorderStyle = BorderStyle.FixedSingle;
            cpbsDesktopNormal.Location = new System.Drawing.Point(12, 194);
            cpbsDesktopNormal.Margin = new Padding(9, 12, 9, 12);
            cpbsDesktopNormal.Name = "cpbsDesktopNormal";
            cpbsDesktopNormal.ProgressBarColor = System.Drawing.Color.Green;
            cpbsDesktopNormal.ProgressBarText = "Normal";
            cpbsDesktopNormal.ProgressBarTextColor = System.Drawing.SystemColors.ControlText;
            cpbsDesktopNormal.ProgressBarTextFilledColor = System.Drawing.Color.White;
            cpbsDesktopNormal.Size = new System.Drawing.Size(516, 130);
            cpbsDesktopNormal.TabIndex = 4;
            // 
            // txtDesktopUserAgent
            // 
            txtDesktopUserAgent.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtDesktopUserAgent.Location = new System.Drawing.Point(192, 44);
            txtDesktopUserAgent.Margin = new Padding(7, 6, 7, 6);
            txtDesktopUserAgent.Name = "txtDesktopUserAgent";
            txtDesktopUserAgent.Size = new System.Drawing.Size(1518, 35);
            txtDesktopUserAgent.TabIndex = 0;
            toolTip1.SetToolTip(txtDesktopUserAgent, "Specifies the User-Agent string used to simulate searches from a desktop browser.");
            // 
            // lblDesktopUserAgent
            // 
            lblDesktopUserAgent.AutoSize = true;
            lblDesktopUserAgent.Location = new System.Drawing.Point(12, 52);
            lblDesktopUserAgent.Margin = new Padding(7, 0, 7, 0);
            lblDesktopUserAgent.Name = "lblDesktopUserAgent";
            lblDesktopUserAgent.Size = new System.Drawing.Size(116, 30);
            lblDesktopUserAgent.TabIndex = 3;
            lblDesktopUserAgent.Text = "User Agent";
            toolTip1.SetToolTip(lblDesktopUserAgent, "Specifies the User-Agent string used to simulate searches from a desktop browser.");
            // 
            // txtDesktopTotalPoints
            // 
            txtDesktopTotalPoints.Location = new System.Drawing.Point(533, 102);
            txtDesktopTotalPoints.Margin = new Padding(7, 6, 7, 6);
            txtDesktopTotalPoints.Name = "txtDesktopTotalPoints";
            txtDesktopTotalPoints.ReadOnly = true;
            txtDesktopTotalPoints.Size = new System.Drawing.Size(110, 35);
            txtDesktopTotalPoints.TabIndex = 2;
            toolTip1.SetToolTip(txtDesktopTotalPoints, "Displays the total possible points to earn.");
            // 
            // lblDesktopTotalPoints
            // 
            lblDesktopTotalPoints.AutoSize = true;
            lblDesktopTotalPoints.Location = new System.Drawing.Point(403, 110);
            lblDesktopTotalPoints.Margin = new Padding(7, 0, 7, 0);
            lblDesktopTotalPoints.Name = "lblDesktopTotalPoints";
            lblDesktopTotalPoints.Size = new System.Drawing.Size(120, 30);
            lblDesktopTotalPoints.TabIndex = 3;
            lblDesktopTotalPoints.Text = "Total points";
            // 
            // txtDesktopPointsPerSearch
            // 
            txtDesktopPointsPerSearch.Location = new System.Drawing.Point(192, 102);
            txtDesktopPointsPerSearch.Margin = new Padding(7, 6, 7, 6);
            txtDesktopPointsPerSearch.Name = "txtDesktopPointsPerSearch";
            txtDesktopPointsPerSearch.ReadOnly = true;
            txtDesktopPointsPerSearch.Size = new System.Drawing.Size(110, 35);
            txtDesktopPointsPerSearch.TabIndex = 1;
            toolTip1.SetToolTip(txtDesktopPointsPerSearch, "The amount of points earned per search.");
            // 
            // lblDesktopPointsPerSearch
            // 
            lblDesktopPointsPerSearch.AutoSize = true;
            lblDesktopPointsPerSearch.Location = new System.Drawing.Point(12, 110);
            lblDesktopPointsPerSearch.Margin = new Padding(7, 0, 7, 0);
            lblDesktopPointsPerSearch.Name = "lblDesktopPointsPerSearch";
            lblDesktopPointsPerSearch.Size = new System.Drawing.Size(171, 30);
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
            grpTimes.Location = new System.Drawing.Point(10, 9);
            grpTimes.Margin = new Padding(5, 6, 5, 6);
            grpTimes.Name = "grpTimes";
            grpTimes.Padding = new Padding(5, 6, 5, 6);
            grpTimes.Size = new System.Drawing.Size(1303, 316);
            grpTimes.TabIndex = 1;
            grpTimes.TabStop = false;
            grpTimes.Text = "Times";
            // 
            // lblMarginWait
            // 
            lblMarginWait.AutoSize = true;
            lblMarginWait.Location = new System.Drawing.Point(912, 52);
            lblMarginWait.Margin = new Padding(7, 0, 7, 0);
            lblMarginWait.Name = "lblMarginWait";
            lblMarginWait.Size = new System.Drawing.Size(150, 30);
            lblMarginWait.TabIndex = 3;
            lblMarginWait.Text = "Margin wait (s)";
            toolTip1.SetToolTip(lblMarginWait, "Additional random margin applied to the waiting time between searches, making the intervals less predictable.");
            // 
            // txtMarginWait
            // 
            txtMarginWait.Location = new System.Drawing.Point(1137, 44);
            txtMarginWait.Margin = new Padding(7, 6, 7, 6);
            txtMarginWait.Name = "txtMarginWait";
            txtMarginWait.Size = new System.Drawing.Size(112, 35);
            txtMarginWait.TabIndex = 2;
            toolTip1.SetToolTip(txtMarginWait, "Additional random margin applied to the waiting time between searches, making the intervals less predictable.");
            // 
            // lblMarginExtracPointsDelay
            // 
            lblMarginExtracPointsDelay.AutoSize = true;
            lblMarginExtracPointsDelay.Location = new System.Drawing.Point(912, 226);
            lblMarginExtracPointsDelay.Margin = new Padding(7, 0, 7, 0);
            lblMarginExtracPointsDelay.Name = "lblMarginExtracPointsDelay";
            lblMarginExtracPointsDelay.Size = new System.Drawing.Size(206, 30);
            lblMarginExtracPointsDelay.TabIndex = 3;
            lblMarginExtracPointsDelay.Text = "Margin e. p. delay (s)";
            toolTip1.SetToolTip(lblMarginExtracPointsDelay, "Additional random margin applied to the delay for points extraction, increasing variability.");
            // 
            // lblMarginStreakDelay
            // 
            lblMarginStreakDelay.AutoSize = true;
            lblMarginStreakDelay.Location = new System.Drawing.Point(912, 168);
            lblMarginStreakDelay.Margin = new Padding(7, 0, 7, 0);
            lblMarginStreakDelay.Name = "lblMarginStreakDelay";
            lblMarginStreakDelay.Size = new System.Drawing.Size(222, 30);
            lblMarginStreakDelay.TabIndex = 3;
            lblMarginStreakDelay.Text = "Margin streak delay (s)";
            toolTip1.SetToolTip(lblMarginStreakDelay, "Additional random margin applied to the delay between streaks for added unpredictability.");
            // 
            // lblMaxExtracPointsDelay
            // 
            lblMaxExtracPointsDelay.AutoSize = true;
            lblMaxExtracPointsDelay.Location = new System.Drawing.Point(461, 226);
            lblMaxExtracPointsDelay.Margin = new Padding(7, 0, 7, 0);
            lblMaxExtracPointsDelay.Name = "lblMaxExtracPointsDelay";
            lblMaxExtracPointsDelay.Size = new System.Drawing.Size(185, 30);
            lblMaxExtracPointsDelay.TabIndex = 3;
            lblMaxExtracPointsDelay.Text = "Max. e. p. delay (s)";
            toolTip1.SetToolTip(lblMaxExtracPointsDelay, "The maximum waiting time (in seconds) before performing a points extraction to check the user's current points. A random value within the range will be selected.");
            // 
            // lblMaxStreakDelay
            // 
            lblMaxStreakDelay.AutoSize = true;
            lblMaxStreakDelay.Location = new System.Drawing.Point(461, 168);
            lblMaxStreakDelay.Margin = new Padding(7, 0, 7, 0);
            lblMaxStreakDelay.Name = "lblMaxStreakDelay";
            lblMaxStreakDelay.Size = new System.Drawing.Size(201, 30);
            lblMaxStreakDelay.TabIndex = 3;
            lblMaxStreakDelay.Text = "Max. streak delay (s)";
            toolTip1.SetToolTip(lblMaxStreakDelay, "The maximum waiting time (in seconds) before starting a new streak after completing the current one. A random value within the range will be selected.");
            // 
            // lblMinExtracPointsDelay
            // 
            lblMinExtracPointsDelay.AutoSize = true;
            lblMinExtracPointsDelay.Location = new System.Drawing.Point(36, 226);
            lblMinExtracPointsDelay.Margin = new Padding(7, 0, 7, 0);
            lblMinExtracPointsDelay.Name = "lblMinExtracPointsDelay";
            lblMinExtracPointsDelay.Size = new System.Drawing.Size(181, 30);
            lblMinExtracPointsDelay.TabIndex = 3;
            lblMinExtracPointsDelay.Text = "Min. e. p. delay (s)";
            toolTip1.SetToolTip(lblMinExtracPointsDelay, "The minimum waiting time (in seconds) before performing a points extraction to check the user's current points. A random value within the range will be selected.");
            // 
            // txtMarginStreakAmount
            // 
            txtMarginStreakAmount.Location = new System.Drawing.Point(1137, 102);
            txtMarginStreakAmount.Margin = new Padding(7, 6, 7, 6);
            txtMarginStreakAmount.Name = "txtMarginStreakAmount";
            txtMarginStreakAmount.Size = new System.Drawing.Size(112, 35);
            txtMarginStreakAmount.TabIndex = 5;
            toolTip1.SetToolTip(txtMarginStreakAmount, "Additional random margin applied to the number of searches in a streak, adding variability.");
            // 
            // lblMarginStreakAmount
            // 
            lblMarginStreakAmount.AutoSize = true;
            lblMarginStreakAmount.Location = new System.Drawing.Point(912, 110);
            lblMarginStreakAmount.Margin = new Padding(7, 0, 7, 0);
            lblMarginStreakAmount.Name = "lblMarginStreakAmount";
            lblMarginStreakAmount.Size = new System.Drawing.Size(218, 30);
            lblMarginStreakAmount.TabIndex = 3;
            lblMarginStreakAmount.Text = "Margin streak amount";
            toolTip1.SetToolTip(lblMarginStreakAmount, "Additional random margin applied to the number of searches in a streak, adding variability.");
            // 
            // txtMaxStreakAmount
            // 
            txtMaxStreakAmount.Location = new System.Drawing.Point(665, 102);
            txtMaxStreakAmount.Margin = new Padding(7, 6, 7, 6);
            txtMaxStreakAmount.Name = "txtMaxStreakAmount";
            txtMaxStreakAmount.Size = new System.Drawing.Size(112, 35);
            txtMaxStreakAmount.TabIndex = 4;
            toolTip1.SetToolTip(txtMaxStreakAmount, "The maximum number of searches performed in a single streak. A random value within the range will be selected.");
            // 
            // lblMaxStreakAmount
            // 
            lblMaxStreakAmount.AutoSize = true;
            lblMaxStreakAmount.Location = new System.Drawing.Point(461, 110);
            lblMaxStreakAmount.Margin = new Padding(7, 0, 7, 0);
            lblMaxStreakAmount.Name = "lblMaxStreakAmount";
            lblMaxStreakAmount.Size = new System.Drawing.Size(197, 30);
            lblMaxStreakAmount.TabIndex = 3;
            lblMaxStreakAmount.Text = "Max. streak amount";
            toolTip1.SetToolTip(lblMaxStreakAmount, "The maximum number of searches performed in a single streak. A random value within the range will be selected.");
            // 
            // txtMarginExtracPointsDelay
            // 
            txtMarginExtracPointsDelay.Location = new System.Drawing.Point(1137, 218);
            txtMarginExtracPointsDelay.Margin = new Padding(7, 6, 7, 6);
            txtMarginExtracPointsDelay.Name = "txtMarginExtracPointsDelay";
            txtMarginExtracPointsDelay.Size = new System.Drawing.Size(112, 35);
            txtMarginExtracPointsDelay.TabIndex = 11;
            toolTip1.SetToolTip(txtMarginExtracPointsDelay, "Additional random margin applied to the delay for points extraction, increasing variability.");
            // 
            // txtMaxExtracPointsDelay
            // 
            txtMaxExtracPointsDelay.Location = new System.Drawing.Point(665, 218);
            txtMaxExtracPointsDelay.Margin = new Padding(7, 6, 7, 6);
            txtMaxExtracPointsDelay.Name = "txtMaxExtracPointsDelay";
            txtMaxExtracPointsDelay.Size = new System.Drawing.Size(112, 35);
            txtMaxExtracPointsDelay.TabIndex = 10;
            toolTip1.SetToolTip(txtMaxExtracPointsDelay, "The maximum waiting time (in seconds) before performing a points extraction to check the user's current points. A random value within the range will be selected.");
            // 
            // txtMarginStreakDelay
            // 
            txtMarginStreakDelay.Location = new System.Drawing.Point(1137, 160);
            txtMarginStreakDelay.Margin = new Padding(7, 6, 7, 6);
            txtMarginStreakDelay.Name = "txtMarginStreakDelay";
            txtMarginStreakDelay.Size = new System.Drawing.Size(112, 35);
            txtMarginStreakDelay.TabIndex = 8;
            toolTip1.SetToolTip(txtMarginStreakDelay, "Additional random margin applied to the delay between streaks for added unpredictability.");
            // 
            // txtMinExtracPointsDelay
            // 
            txtMinExtracPointsDelay.Location = new System.Drawing.Point(271, 218);
            txtMinExtracPointsDelay.Margin = new Padding(7, 6, 7, 6);
            txtMinExtracPointsDelay.Name = "txtMinExtracPointsDelay";
            txtMinExtracPointsDelay.Size = new System.Drawing.Size(112, 35);
            txtMinExtracPointsDelay.TabIndex = 9;
            toolTip1.SetToolTip(txtMinExtracPointsDelay, "The minimum waiting time (in seconds) before performing a points extraction to check the user's current points. A random value within the range will be selected.");
            // 
            // txtMaxStreakDelay
            // 
            txtMaxStreakDelay.Location = new System.Drawing.Point(665, 160);
            txtMaxStreakDelay.Margin = new Padding(7, 6, 7, 6);
            txtMaxStreakDelay.Name = "txtMaxStreakDelay";
            txtMaxStreakDelay.Size = new System.Drawing.Size(112, 35);
            txtMaxStreakDelay.TabIndex = 7;
            toolTip1.SetToolTip(txtMaxStreakDelay, "The maximum waiting time (in seconds) before starting a new streak after completing the current one. A random value within the range will be selected.");
            // 
            // grpExtras
            // 
            grpExtras.Controls.Add(cbSimulateKeyboardTyping);
            grpExtras.Location = new System.Drawing.Point(1336, 9);
            grpExtras.Margin = new Padding(5, 6, 5, 6);
            grpExtras.Name = "grpExtras";
            grpExtras.Padding = new Padding(5, 6, 5, 6);
            grpExtras.Size = new System.Drawing.Size(451, 238);
            grpExtras.TabIndex = 2;
            grpExtras.TabStop = false;
            grpExtras.Text = "Extras";
            // 
            // cbSimulateKeyboardTyping
            // 
            cbSimulateKeyboardTyping.AutoSize = true;
            cbSimulateKeyboardTyping.Location = new System.Drawing.Point(41, 44);
            cbSimulateKeyboardTyping.Margin = new Padding(5, 6, 5, 6);
            cbSimulateKeyboardTyping.Name = "cbSimulateKeyboardTyping";
            cbSimulateKeyboardTyping.Size = new System.Drawing.Size(274, 34);
            cbSimulateKeyboardTyping.TabIndex = 0;
            cbSimulateKeyboardTyping.Text = "Simulate keyboard typing";
            toolTip1.SetToolTip(cbSimulateKeyboardTyping, "Enables simulation of keyboard typing during searches to mimic human behavior and avoid detection.");
            cbSimulateKeyboardTyping.UseVisualStyleBackColor = true;
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tpGeneral);
            tabControl.Controls.Add(tpUserAgents);
            tabControl.Dock = DockStyle.Fill;
            tabControl.Location = new System.Drawing.Point(0, 0);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new System.Drawing.Size(1805, 1064);
            tabControl.TabIndex = 5;
            // 
            // tpGeneral
            // 
            tpGeneral.Controls.Add(grpUrls);
            tpGeneral.Controls.Add(grpTimes);
            tpGeneral.Controls.Add(grpExtras);
            tpGeneral.Location = new System.Drawing.Point(4, 39);
            tpGeneral.Name = "tpGeneral";
            tpGeneral.Padding = new Padding(3);
            tpGeneral.Size = new System.Drawing.Size(1797, 1021);
            tpGeneral.TabIndex = 0;
            tpGeneral.Text = "General";
            tpGeneral.UseVisualStyleBackColor = true;
            // 
            // grpUrls
            // 
            grpUrls.Controls.Add(lblSearchesParameter);
            grpUrls.Controls.Add(txtSearchesParameter);
            grpUrls.Controls.Add(lblUrlRewards);
            grpUrls.Controls.Add(lblUrlSearches);
            grpUrls.Controls.Add(txtUrlRewards);
            grpUrls.Controls.Add(txtUrlSearches);
            grpUrls.Location = new System.Drawing.Point(10, 334);
            grpUrls.Name = "grpUrls";
            grpUrls.Size = new System.Drawing.Size(1779, 205);
            grpUrls.TabIndex = 4;
            grpUrls.TabStop = false;
            grpUrls.Text = "URLs";
            // 
            // lblUrlRewards
            // 
            lblUrlRewards.AutoSize = true;
            lblUrlRewards.Location = new System.Drawing.Point(36, 133);
            lblUrlRewards.Name = "lblUrlRewards";
            lblUrlRewards.Size = new System.Drawing.Size(90, 30);
            lblUrlRewards.TabIndex = 4;
            lblUrlRewards.Text = "Rewards";
            // 
            // lblUrlSearches
            // 
            lblUrlSearches.AutoSize = true;
            lblUrlSearches.Location = new System.Drawing.Point(36, 51);
            lblUrlSearches.Name = "lblUrlSearches";
            lblUrlSearches.Size = new System.Drawing.Size(95, 30);
            lblUrlSearches.TabIndex = 4;
            lblUrlSearches.Text = "Searches";
            // 
            // txtUrlRewards
            // 
            txtUrlRewards.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtUrlRewards.Location = new System.Drawing.Point(158, 131);
            txtUrlRewards.Name = "txtUrlRewards";
            txtUrlRewards.Size = new System.Drawing.Size(1540, 35);
            txtUrlRewards.TabIndex = 3;
            // 
            // txtUrlSearches
            // 
            txtUrlSearches.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtUrlSearches.Location = new System.Drawing.Point(158, 49);
            txtUrlSearches.Name = "txtUrlSearches";
            txtUrlSearches.Size = new System.Drawing.Size(1540, 35);
            txtUrlSearches.TabIndex = 3;
            // 
            // tpUserAgents
            // 
            tpUserAgents.Controls.Add(grpDesktop);
            tpUserAgents.Controls.Add(grpMobile);
            tpUserAgents.Location = new System.Drawing.Point(4, 39);
            tpUserAgents.Name = "tpUserAgents";
            tpUserAgents.Padding = new Padding(3);
            tpUserAgents.Size = new System.Drawing.Size(1797, 1021);
            tpUserAgents.TabIndex = 1;
            tpUserAgents.Text = "User Agents";
            tpUserAgents.UseVisualStyleBackColor = true;
            // 
            // lblSearchesParameter
            // 
            lblSearchesParameter.AutoSize = true;
            lblSearchesParameter.Location = new System.Drawing.Point(36, 92);
            lblSearchesParameter.Name = "lblSearchesParameter";
            lblSearchesParameter.Size = new System.Drawing.Size(116, 30);
            lblSearchesParameter.TabIndex = 6;
            lblSearchesParameter.Text = "Parameters";
            // 
            // txtSearchesParameter
            // 
            txtSearchesParameter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSearchesParameter.Location = new System.Drawing.Point(158, 90);
            txtSearchesParameter.Name = "txtSearchesParameter";
            txtSearchesParameter.Size = new System.Drawing.Size(1540, 35);
            txtSearchesParameter.TabIndex = 5;
            // 
            // PreferencesForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1805, 1130);
            Controls.Add(tabControl);
            Margin = new Padding(9, 6, 9, 6);
            Name = "PreferencesForm";
            Text = "Preferences";
            Controls.SetChildIndex(lblMessage, 0);
            Controls.SetChildIndex(tabControl, 0);
            grpMobile.ResumeLayout(false);
            grpMobile.PerformLayout();
            grpDesktop.ResumeLayout(false);
            grpDesktop.PerformLayout();
            grpTimes.ResumeLayout(false);
            grpTimes.PerformLayout();
            grpExtras.ResumeLayout(false);
            grpExtras.PerformLayout();
            tabControl.ResumeLayout(false);
            tpGeneral.ResumeLayout(false);
            grpUrls.ResumeLayout(false);
            grpUrls.PerformLayout();
            tpUserAgents.ResumeLayout(false);
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
        private GroupBox grpExtras;
        private CheckBox cbSimulateKeyboardTyping;
        private Label lblMarginExtracPointsDelay;
        private Label lblMaxExtracPointsDelay;
        private Label lblMinExtracPointsDelay;
        private TextBox txtMarginExtracPointsDelay;
        private TextBox txtMaxExtracPointsDelay;
        private TextBox txtMinExtracPointsDelay;
        private ToolTip toolTip1;
        private TabControl tabControl;
        private TabPage tpGeneral;
        private TabPage tpUserAgents;
        private GroupBox grpUrls;
        private TextBox txtUrlSearches;
        private Label lblUrlRewards;
        private Label lblUrlSearches;
        private TextBox txtUrlRewards;
        private Label lblSearchesParameter;
        private TextBox txtSearchesParameter;
    }
}