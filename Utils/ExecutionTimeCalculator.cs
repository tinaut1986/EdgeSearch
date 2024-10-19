using EdgeSearch.Models;
using System;

namespace EdgeSearch.Utils
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
            int totalTimeInSeconds = (remainingExecutions * pauseBetweenExecutions) + (totalStrikes * pauseBetweenStrikes) + (totalStrikes * executionsPerStrike * pauseBetweenExecutions) + strikeSeconds;

            // Return the total time as a TimeSpan object
            int total = totalTimeInSeconds - elapsedSeconds;
            if (totalExecutions > 0 && playing)
                total += -pauseBetweenExecutions + currentPause;

            return TimeSpan.FromSeconds(total);
        }

        public static TimeSpan GetDesktopExpectedTimeMin(Search search)
        {
            return CalculateTotalTime(totalExecutions: (search.Preferences.DesktopPointsPersearch == 0 ? 0 : (search.Preferences.DesktopTotalPoints / search.Preferences.DesktopPointsPersearch)) - (search.DesktopSearchesCount),
                                      executionsOffset: search.Preferences.StrikeAmount - search.StrikeCount,
                                      executionsPerStrike: search.Preferences.StrikeAmount,
                                      pauseBetweenExecutions: search.Preferences.MinWait,
                                      pauseBetweenStrikes: search.Preferences.StrikeDelay,
                                      elapsedSeconds: search.IsDesktop ? search.ElapsedSeconds : 0,
                                      currentPause: search.IsDesktop ? search.SecondsToRefresh : 0,
                                      strikeTime: search.StrikeTime,
                                      playing: search.IsPlaying && search.IsDesktop);
        }

        public static TimeSpan GetDesktopExpectedTimeMax(Search search)
        {
            return CalculateTotalTime(totalExecutions: (search.Preferences.DesktopPointsPersearch == 0 ? 0 : (search.Preferences.DesktopTotalPoints / search.Preferences.DesktopPointsPersearch)) - (search.DesktopSearchesCount),
                                      executionsOffset: search.Preferences.StrikeAmount - search.StrikeCount,
                                      executionsPerStrike: search.Preferences.StrikeAmount,
                                      pauseBetweenExecutions: search.Preferences.MaxWait,
                                      pauseBetweenStrikes: search.Preferences.StrikeDelay,
                                      elapsedSeconds: search.IsDesktop ? search.ElapsedSeconds : 0,
                                      currentPause: search.IsDesktop ? search.SecondsToRefresh : 0,
                                      strikeTime: search.StrikeTime,
                                      playing: search.IsPlaying && search.IsDesktop);
        }

        public static TimeSpan GetMobileExpectedTimeMin(Search search)
        {
            return CalculateTotalTime(totalExecutions: (search.Preferences.MobilePointsPersearch == 0 ? 0 : (search.Preferences.MobileTotalPoints / search.Preferences.MobilePointsPersearch)) - (search.MobileSearchesCount),
                                      executionsOffset: search.Preferences.StrikeAmount - search.StrikeCount,
                                      executionsPerStrike: search.Preferences.StrikeAmount,
                                      pauseBetweenExecutions: search.Preferences.MinWait,
                                      pauseBetweenStrikes: search.Preferences.StrikeDelay,
                                      elapsedSeconds: search.IsMobile ? search.ElapsedSeconds : 0,
                                      currentPause: search.IsMobile ? search.SecondsToRefresh : 0,
                                      strikeTime: search.StrikeTime,
                                      playing: search.IsPlaying && search.IsMobile);
        }

        public static TimeSpan GetMobileExpectedTimeMax(Search search)
        {
            return CalculateTotalTime(totalExecutions: (search.Preferences.MobilePointsPersearch == 0 ? 0 : (search.Preferences.MobileTotalPoints / search.Preferences.MobilePointsPersearch)) - (search.MobileSearchesCount),
                                      executionsOffset: search.Preferences.StrikeAmount - search.StrikeCount,
                                      executionsPerStrike: search.Preferences.StrikeAmount,
                                      pauseBetweenExecutions: search.Preferences.MaxWait,
                                      pauseBetweenStrikes: search.Preferences.StrikeDelay,
                                      elapsedSeconds: search.IsMobile ? search.ElapsedSeconds : 0,
                                      currentPause: search.IsMobile ? search.SecondsToRefresh : 0,
                                      strikeTime: search.StrikeTime,
                                      playing: search.IsPlaying && search.IsMobile);
        }

        public static TimeSpan GetTotalExpectedTimeMin(Search search)
        {
            return GetMobileExpectedTimeMin(search) + GetDesktopExpectedTimeMin(search);
        }

        public static TimeSpan GetTotalExpectedTimeMax(Search search)
        {
            return GetMobileExpectedTimeMax(search) + GetDesktopExpectedTimeMax(search);
        }

        public static String GetTotalExpectedTime(Search search)
        {
            return $"Expected time: {GetTotalExpectedTimeMin(search):hh\\:mm\\:ss} - {GetTotalExpectedTimeMax(search):hh\\:mm\\:ss}";
        }
    }
}