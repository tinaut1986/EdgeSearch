using EdgeSearch.src.Business;
using EdgeSearch.src.Common;
using EdgeSearch.src.Models;
using EdgeSearch.src.Properties;
using EdgeSearch.src.Utils;
using Microsoft.Web.WebView2.Core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utils.Common;
using Utils.Extensions;

namespace EdgeSearch.UI
{
    public partial class MainForm : Form
    {
        #region Members
        private Profile _profile;

        public event EventHandler PlayClicked;
        public event EventHandler FullPlayClicked;
        public event EventHandler ForceClicked;
        public event EventHandler ResetClicked;
        public event EventHandler PlaySearchesClicked;
        public event EventHandler PlayRewardsClicked;
        public event EventHandler NextSearchClicked;
        public event EventHandler PreferencesClciked;
        public event EventHandler MobileChanged;

        #endregion

        #region Constructors & destructor
        public MainForm(Profile profile)
        {
            InitializeComponent();

            _profile = profile;

            FixButtons();

            InitializeEvents();

            this.Text = $"Edge Search - {_profile.Name}";

#if DEBUG
            Icon = Resources.EdgeSearch_dev;
#else
            Icon = Resources.EdgeSearch;
#endif
        }

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                FinalizeEvents();

                components?.Dispose();
            }
            base.Dispose(disposing);
        }
        #endregion

        #region Methods

        public void InitializeWebViewSearchesController(WebViewSearchesController searchesController, WebViewRewardsController rewardsController)
        {
            searchesController.InitializeWebView(wvSearches);
            rewardsController.InitializeWebView(wvRewards);
        }

        public void SelectTab(TabType tabType)
        {
            tabControl1.SelectedTab = GetTabPage(tabType);
        }

        public void SelectTabAndReturn(TabType tabType)
        {
            TabPage selectedTab = tabControl1.SelectedTab;
            TabPage tabPage = GetTabPage(tabType);

            if (selectedTab == tabPage)
                return;

            SelectTab(tabType);
            tabControl1.SelectedTab = selectedTab;
        }

        public TabPage GetTabPage(TabType tabType)
        {
            switch (tabType)
            {
                case TabType.Searches:
                    return tpSearches;
                case TabType.Rewards:
                    return tpRewards;
                default:
                    throw new ArgumentOutOfRangeException(nameof(tabType), tabType, null);
            };
        }

        private void FixButtons()
        {
            btnPlay.FitImage();
            chkMobile.FitImage();
            btnSearch.FitImage();
            btnNext.FitImage();
        }

        public void BindFields()
        {
            txtURL.DataBindings.Clear();
            txtURL.DataBindings.Add(nameof(txtURL.Text), _profile.Search, nameof(_profile.Search.URL));

            cbNextSearch.DataBindings.Clear();
            cbNextSearch.DataBindings.Add(nameof(cbNextSearch.Text), _profile.Search, nameof(_profile.Search.NextSearch));

            chkMobile.DataBindings.Clear();
            chkMobile.DataBindings.Add(nameof(chkMobile.Checked), _profile.Search, nameof(_profile.Search.IsMobile));
        }

        public void AddHistoricSearch(string search)
        {
            if (search == null)
                return;

            cbNextSearch.Items.Insert(0, search);
        }

        /// <summary>
        /// Initializes all event subscriptions for the form.
        /// </summary>
        private void InitializeEvents()
        {
            // Menu item events
            var menuItems = new (ToolStripMenuItem item, EventHandler handler)[]
            {
                (tsmiPlayRewards, TsmiPlayRewards_Click),
                (tsmiPlaySearches, TsmiPlaySearches_Click),
                (tsmiPreferences, TsmiPreferences_Click),
                (tsmiPlay, TsmiPlay_Click),
                (tsmiReset, TsmiReset_Click)
            };

            foreach (var (item, handler) in menuItems)
                item.Click += handler;

            // Button events
            var buttons = new (Button button, EventHandler handler)[]
            {
                (btnPlay, btnPlay_Click),
                (btnSearch, btnForce_Click),
                (btnNext, btnNext_Click)
            };

            foreach (var (button, handler) in buttons)
                button.Click += handler;

            // Checkbox event
            chkMobile.Click += ChkMobile_Click;
        }

        /// <summary>
        /// Removes all event subscriptions for the form.
        /// This is important for proper cleanup and to prevent memory leaks.
        /// </summary>
        private void FinalizeEvents()
        {
            // Menu item events
            var menuItems = new (ToolStripMenuItem item, EventHandler handler)[]
            {
                (tsmiPlayRewards, TsmiPlayRewards_Click),
                (tsmiPlaySearches, TsmiPlaySearches_Click),
                (tsmiPreferences, TsmiPreferences_Click),
                (tsmiPlay, TsmiPlay_Click),
                (tsmiReset, TsmiReset_Click)
            };

            foreach (var (item, handler) in menuItems)
                item.Click -= handler;

            // Button events
            var buttons = new (Button button, EventHandler handler)[]
            {
                (btnPlay, btnPlay_Click),
                (btnSearch, btnForce_Click),
                (btnNext, btnNext_Click)
            };

            foreach (var (button, handler) in buttons)
                button.Click -= handler;

            // Checkbox event
            chkMobile.Click -= ChkMobile_Click;
        }

        public void RefreshSearchesURL()
        {
            _profile.Search.URL = wvSearches.Source;
        }

        public void UpdateInterface(Awaker awaker, ExtractPointsTimer extractPointsTimer)
        {
            if (!_profile.Search.IsPlaying)
            {
                btnPlay.Image = Resources.play;

                tsmiPlay.Text = "Play";
                tsmiPlay.Image = Resources.play;

                tsmiPlaySearches.Text = "Play searches";
                tsmiPlaySearches.Image = Resources.play;
            }
            else
            {
                btnPlay.Image = Resources.stop;

                tsmiPlay.Text = "Stop";
                tsmiPlay.Image = Resources.stop;

                tsmiPlaySearches.Text = "Stop searches";
                tsmiPlaySearches.Image = Resources.stop;
            }

            btnPlay.FitImage();

            txtURL.Text = wvSearches.Source.AbsoluteUri;

            UpdateProgressBarSearches(_profile);

            UpdateProgressBarRewards(_profile.Search);

            UpdateProgressBarExtractPoints(extractPointsTimer);

            UpdateResumeLabels();

            UpdateAwakerLabel(awaker);
        }

        private void UpdateProgressBarExtractPoints(ExtractPointsTimer extractPointsTimer)
        {
            DateTime? previousTime = LibDateTime.MaxDate(extractPointsTimer.LastExtraction, extractPointsTimer.StartTime);
            if (previousTime == null)
            {
                pbExtractPoints.Text = "Extract points";

                pbExtractPoints.Minimum = 0;
                pbExtractPoints.Maximum = 0;
                pbExtractPoints.Value = 0;
            }
            else
            {
                pbExtractPoints.Minimum = 0;
                int maximum = (extractPointsTimer.Interval / 1000);
                int value = maximum - Convert.ToInt32((DateTime.Now - previousTime.Value).TotalSeconds);
                pbExtractPoints.Maximum = maximum;
                pbExtractPoints.Value = value;

                pbExtractPoints.Text = $"Next extraction: {TimeSpan.FromSeconds(value):mm\\:ss} / {TimeSpan.FromSeconds(maximum):mm\\:ss}";
            }
        }

        private void UpdateResumeLabels()
        {
            string pcSearches = $"PC: {_profile.Search.DesktopSearchesCount} (x{_profile.Preferences.DesktopPointsPersearch})";
            string pcPoints = $"Points: {_profile.DesktopCurrentPoints}/{_profile.Preferences.DesktopTotalPoints}";
            lblPCSearches.Text = $"{pcSearches} | {pcPoints}";

            string mobileSearches = $"Mobile: {_profile.Search.MobileSearchesCount} (x{_profile.Preferences.MobilePointsPersearch})";
            string mobilePoints = $"Points: {_profile.MobileCurrentPoints}/{_profile.Preferences.MobileTotalPoints}";
            lblMobileSearches.Text = $"{mobileSearches} | {mobilePoints}";

            string refreshRange = $"Refresh range (s): {_profile.Preferences.MinWait}/{_profile.Preferences.MaxWait}";
            string streaks = $"Streaks: {_profile.Preferences.MinStreakAmount}/{_profile.Preferences.MaxStreakAmount}";
            string streaksDelay = $"Streak delay (s): {_profile.Preferences.MinStreakDelay}/{_profile.Preferences.MaxStreakDelay}";
            lblRefreshRange.Text = $"{refreshRange} | {streaks} | {streaksDelay}";

            SetLabelFont();

            FixLabelsWidth();
        }

        private void UpdateAwakerLabel(Awaker awaker)
        {
            string state = awaker.Enabled ? "ON" : "OFF";
            string lastAwake = $"{awaker.LastAwake?.ToShortDateString()} {awaker.LastAwake?.ToShortTimeString()}";
            lblAwaker.Text = $"Awaker: {state}";
            if (!string.IsNullOrWhiteSpace(lastAwake))
                lblAwaker.Text = $"{lblAwaker.Text} | Last awake: {lastAwake}";
        }

        private void FixLabelsWidth()
        {
            FixLabelWitdh(lblPCSearches);
            FixLabelWitdh(lblMobileSearches);
            FixLabelWitdh(lblRefreshRange);
        }

        private void SetLabelFont()
        {
            if (_profile.Search.IsMobile)
            {
                lblMobileSearches.Font = new Font(lblMobileSearches.Font, FontStyle.Bold);
                lblPCSearches.Font = new Font(lblMobileSearches.Font, FontStyle.Regular);
            }
            else
            {
                lblMobileSearches.Font = new Font(lblMobileSearches.Font, FontStyle.Regular);
                lblPCSearches.Font = new Font(lblMobileSearches.Font, FontStyle.Bold);
            }
        }

        public void UpdateProgressBarRewards(Search search)
        {
            pbRewards.Text = search.RewardsString;
        }

        public void UpdateProgressBarSearches(Profile profile)
        {
            DateTime now = DateTime.Now;
            DateTime streakTime = (profile.Search.StreakTime ?? now);

            string streakCount = $"{profile.Search.StreakCount}/{profile.Search.StreakAmount}";
            int streakDelay = profile.Search.StreakDelay;
            int elapsedStreakDelay = Convert.ToInt32((now - streakTime).TotalSeconds);
            string streakSeconds = $"{TimeSpan.FromSeconds(streakDelay - elapsedStreakDelay):mm\\:ss} / {TimeSpan.FromSeconds(streakDelay):mm\\:ss}";
            string searchsSeconds = $"{TimeSpan.FromSeconds(profile.Search.ElapsedSeconds):mm\\:ss} / {TimeSpan.FromSeconds(profile.Search.SecondsToWait):mm\\:ss}";

            UpdateProgressBar(profile, streakCount, streakSeconds, searchsSeconds);
        }

        private void UpdateProgressBar(Profile profile, string streakCount, string streakSeconds, string searchsSeconds)
        {
            string seconds = searchsSeconds;
            if (profile.Search.StreakTime != null)
                seconds = streakSeconds;

            pbSearches.Text = $"Searches: {streakCount} - {seconds} | Expected time: {ExecutionTimeCalculator.GetTotalExpectedTime(profile)}";

            pbSearches.Maximum = profile.SearchesProgressBarMax;
            pbSearches.Value = profile.SearchesProgressBarValue;

            if (profile.Search.IsMobile)
            {
                if (profile.Search.StreakTime == null)
                    UpdateProgressBarColors(profile.Preferences.mobileNormalProgressBarColors);
                else
                    UpdateProgressBarColors(profile.Preferences.mobileReverseProgressBarColors);
            }
            else // profile.Search.IsDesktop
            {
                if (profile.Search.StreakTime == null)
                    UpdateProgressBarColors(profile.Preferences.desktopNormalProgressBarColors);
                else
                    UpdateProgressBarColors(profile.Preferences.desktopReverseProgressBarColors);
            }
        }

        public void FixLabelWitdh(Label label)
        {
            // Calculate the needed width
            using (Graphics g = label.CreateGraphics())
            {
                SizeF size = g.MeasureString(label.Text, label.Font);
                label.Width = (int)Math.Ceiling(size.Width);
            }
        }

        private void UpdateProgressBarColors(ProgressBarColors colors)
        {
            pbSearches.PaintedColor = colors.FilledColor;
            pbSearches.ForeColor = colors.TextColor;
            pbSearches.PaintedForeColor = colors.FilledTextColor;
        }

        public void SetRewardsProgressBarState(bool play)
        {
            if (play)
                pbRewards.Style = ProgressBarStyle.Marquee;
            else
                pbRewards.Style = ProgressBarStyle.Continuous;
        }

        #endregion

        #region Events

        private void TsmiPlayRewards_Click(object sender, EventArgs e)
        {
            PlayRewardsClicked?.Invoke(sender, e);
        }

        private void TsmiPlaySearches_Click(object sender, EventArgs e)
        {
            PlaySearchesClicked?.Invoke(sender, e);
        }

        private void TsmiPreferences_Click(object sender, EventArgs e)
        {
            PreferencesClciked?.Invoke(sender, e);
        }

        private void TsmiPlay_Click(object sender, EventArgs e)
        {
            FullPlayClicked?.Invoke(sender, e);
        }

        private void TsmiReset_Click(object sender, EventArgs e)
        {
            ResetClicked?.Invoke(sender, e);
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            FullPlayClicked?.Invoke(sender, e);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            NextSearchClicked?.Invoke(sender, e);
        }

        private void ChkMobile_Click(object sender, EventArgs e)
        {
            MobileChanged?.Invoke(sender, e);
        }

        private void btnForce_Click(object sender, EventArgs e)
        {
            ForceClicked?.Invoke(this, EventArgs.Empty);
        }

        #endregion
    }
}
