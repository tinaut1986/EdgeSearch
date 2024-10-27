using EdgeSearch.src.Models;
using System;

namespace EdgeSearch.src.Utils
{
    public static class ExecutionTimeCalculator
    {
        public static TimeSpan CalculateTotalTime(int totalExecutions, int executionsOffset, int executionsPerStrike,
            int pauseBetweenExecutions, int pauseBetweenStrikes, int elapsedSeconds, int currentPause, DateTime? strikeTime, bool playing)
        {
            DateTime now = DateTime.Now;
            int strikeSeconds = 0;
            if (strikeTime != null && playing)
                strikeSeconds = pauseBetweenStrikes - (int)(now - strikeTime.Value).TotalSeconds;

            int totalStrikes = 0;
            int remainingExecutions = totalExecutions;

            // Calculate the number of chains required to complete all executions
            // Calculate the time for the remaining executions if any
            if (executionsPerStrike > 0)
            {
                totalStrikes = (totalExecutions - 1) / executionsPerStrike;

                remainingExecutions = totalExecutions % executionsPerStrike;
                if (remainingExecutions == 0 && totalExecutions > 0)
                    remainingExecutions = executionsPerStrike;
            }

            // Calculate the total time for all chains except the last pause
            int totalTimeInSeconds = remainingExecutions * pauseBetweenExecutions + totalStrikes * pauseBetweenStrikes + totalStrikes * executionsPerStrike * pauseBetweenExecutions + strikeSeconds;

            // Return the total time as a TimeSpan object
            int total = totalTimeInSeconds - elapsedSeconds;
            if (totalExecutions > 0 && playing)
                total += -pauseBetweenExecutions + currentPause;

            return TimeSpan.FromSeconds(total);
        }

        public static TimeSpan GetDesktopExpectedTimeMin(Profile profile)
        {
            return CalculateTotalTime(totalExecutions: (profile.Preferences.DesktopPointsPersearch == 0 ? 0 : profile.Preferences.DesktopTotalPoints / profile.Preferences.DesktopPointsPersearch) - profile.Search.DesktopSearchesCount,
                                      executionsOffset: profile.Preferences.StrikeAmount - profile.Search.StrikeCount,
                                      executionsPerStrike: profile.Preferences.StrikeAmount,
                                      pauseBetweenExecutions: profile.Preferences.MinWait,
                                      pauseBetweenStrikes: profile.Preferences.StrikeDelay,
                                      elapsedSeconds: profile.Search.IsDesktop ? profile.Search.ElapsedSeconds : 0,
                                      currentPause: profile.Search.IsDesktop ? profile.Search.SecondsToRefresh : 0,
                                      strikeTime: profile.Search.StrikeTime,
                                      playing: profile.Search.IsPlaying && profile.Search.IsDesktop);
        }

        public static TimeSpan GetDesktopExpectedTimeMax(Profile profile)
        {
            return CalculateTotalTime(totalExecutions: (profile.Preferences.DesktopPointsPersearch == 0 ? 0 : profile.Preferences.DesktopTotalPoints / profile.Preferences.DesktopPointsPersearch) - profile.Search.DesktopSearchesCount,
                                      executionsOffset: profile.Preferences.StrikeAmount - profile.Search.StrikeCount,
                                      executionsPerStrike: profile.Preferences.StrikeAmount,
                                      pauseBetweenExecutions: profile.Preferences.MaxWait,
                                      pauseBetweenStrikes: profile.Preferences.StrikeDelay,
                                      elapsedSeconds: profile.Search.IsDesktop ? profile.Search.ElapsedSeconds : 0,
                                      currentPause: profile.Search.IsDesktop ? profile.Search.SecondsToRefresh : 0,
                                      strikeTime: profile.Search.StrikeTime,
                                      playing: profile.Search.IsPlaying && profile.Search.IsDesktop);
        }

        public static TimeSpan GetMobileExpectedTimeMin(Profile profile)
        {
            return CalculateTotalTime(totalExecutions: (profile.Preferences.MobilePointsPersearch == 0 ? 0 : profile.Preferences.MobileTotalPoints / profile.Preferences.MobilePointsPersearch) - profile.Search.MobileSearchesCount,
                                      executionsOffset: profile.Preferences.StrikeAmount - profile.Search.StrikeCount,
                                      executionsPerStrike: profile.Preferences.StrikeAmount,
                                      pauseBetweenExecutions: profile.Preferences.MinWait,
                                      pauseBetweenStrikes: profile.Preferences.StrikeDelay,
                                      elapsedSeconds: profile.Search.IsMobile ? profile.Search.ElapsedSeconds : 0,
                                      currentPause: profile.Search.IsMobile ? profile.Search.SecondsToRefresh : 0,
                                      strikeTime: profile.Search.StrikeTime,
                                      playing: profile.Search.IsPlaying && profile.Search.IsMobile);
        }

        public static TimeSpan GetMobileExpectedTimeMax(Profile profile)
        {
            return CalculateTotalTime(totalExecutions: (profile.Preferences.MobilePointsPersearch == 0 ? 0 : profile.Preferences.MobileTotalPoints / profile.Preferences.MobilePointsPersearch) - profile.Search.MobileSearchesCount,
                                      executionsOffset: profile.Preferences.StrikeAmount - profile.Search.StrikeCount,
                                      executionsPerStrike: profile.Preferences.StrikeAmount,
                                      pauseBetweenExecutions: profile.Preferences.MaxWait,
                                      pauseBetweenStrikes: profile.Preferences.StrikeDelay,
                                      elapsedSeconds: profile.Search.IsMobile ? profile.Search.ElapsedSeconds : 0,
                                      currentPause: profile.Search.IsMobile ? profile.Search.SecondsToRefresh : 0,
                                      strikeTime: profile.Search.StrikeTime,
                                      playing: profile.Search.IsPlaying && profile.Search.IsMobile);
        }

        public static TimeSpan GetTotalExpectedTimeMin(Profile profile)
        {
            return GetMobileExpectedTimeMin(profile) + GetDesktopExpectedTimeMin(profile);
        }

        public static TimeSpan GetTotalExpectedTimeMax(Profile profile)
        {
            return GetMobileExpectedTimeMax(profile) + GetDesktopExpectedTimeMax(profile);
        }

        public static string GetTotalExpectedTime(Profile profile)
        {
            return $"Expected time: {GetTotalExpectedTimeMin(profile):hh\\:mm\\:ss} - {GetTotalExpectedTimeMax(profile):hh\\:mm\\:ss}";
        }
    }
}