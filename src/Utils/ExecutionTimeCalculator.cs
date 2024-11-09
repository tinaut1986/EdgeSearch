using EdgeSearch.src.Models;
using System;

namespace EdgeSearch.src.Utils
{
    public static class ExecutionTimeCalculator
    {
        public static TimeSpan CalculateTotalTime(int totalExecutions, int executionsOffset, int executionsPerStreak, int pauseBetweenExecutions,
            int pauseBetweenStreaks, int currentPauseBetweenStreaks, int elapsedSeconds, int currentPause, DateTime? streakTime, bool playing)
        {
            DateTime now = DateTime.Now;
            int streakSeconds = 0;
            if (streakTime != null && playing)
                streakSeconds = currentPauseBetweenStreaks - (int)(now - streakTime.Value).TotalSeconds;

            int totalStreaks = 0;
            int remainingExecutions = totalExecutions;

            // Calculate the number of chains required to complete all executions
            // Calculate the time for the remaining executions if any
            if (executionsPerStreak > 0)
            {
                totalStreaks = (totalExecutions - 1) / executionsPerStreak;

                remainingExecutions = totalExecutions % executionsPerStreak;
                if (remainingExecutions == 0 && totalExecutions > 0)
                    remainingExecutions = executionsPerStreak;
            }

            // Calculate the total time for all chains except the last pause
            int totalTimeInSeconds = (remainingExecutions * pauseBetweenExecutions) + (totalStreaks * pauseBetweenStreaks)
                + (totalStreaks * executionsPerStreak * pauseBetweenExecutions) + streakSeconds;

            // Return the total time as a TimeSpan object
            int total = totalTimeInSeconds - elapsedSeconds;
            if (totalExecutions > 0 && playing)
                total += -pauseBetweenExecutions + currentPause;

            return TimeSpan.FromSeconds(total);
        }

        public static TimeSpan GetDesktopExpectedTimeMin(Profile profile)
        {
            return CalculateTotalTime(totalExecutions: (profile.Preferences.DesktopPointsPersearch == 0 ? 0 : profile.Preferences.DesktopTotalPoints / profile.Preferences.DesktopPointsPersearch) - profile.Search.DesktopSearchesCount,
                                      executionsOffset: profile.Preferences.MaxStreakAmount - profile.Search.StreakCount,
                                      executionsPerStreak: profile.Preferences.MaxStreakAmount,
                                      pauseBetweenExecutions: profile.Preferences.MinWait,
                                      pauseBetweenStreaks: profile.Preferences.MinStreakDelay,
                                      currentPauseBetweenStreaks: profile.Search.StreakDelay,
                                      elapsedSeconds: profile.Search.IsDesktop ? profile.Search.ElapsedSeconds : 0,
                                      currentPause: profile.Search.IsDesktop ? profile.Search.SecondsToWait : 0,
                                      streakTime: profile.Search.StreakTime,
                                      playing: profile.Search.IsPlaying && profile.Search.IsDesktop);
        }

        public static TimeSpan GetDesktopExpectedTimeMax(Profile profile)
        {
            return CalculateTotalTime(totalExecutions: (profile.Preferences.DesktopPointsPersearch == 0 ? 0 : profile.Preferences.DesktopTotalPoints / profile.Preferences.DesktopPointsPersearch) - profile.Search.DesktopSearchesCount,
                                      executionsOffset: profile.Preferences.MinStreakAmount - profile.Search.StreakCount,
                                      executionsPerStreak: profile.Preferences.MinStreakAmount,
                                      pauseBetweenExecutions: profile.Preferences.MaxWait,
                                      pauseBetweenStreaks: profile.Preferences.MaxStreakDelay,
                                      currentPauseBetweenStreaks: profile.Search.StreakDelay,
                                      elapsedSeconds: profile.Search.IsDesktop ? profile.Search.ElapsedSeconds : 0,
                                      currentPause: profile.Search.IsDesktop ? profile.Search.SecondsToWait : 0,
                                      streakTime: profile.Search.StreakTime,
                                      playing: profile.Search.IsPlaying && profile.Search.IsDesktop);
        }

        public static TimeSpan GetMobileExpectedTimeMin(Profile profile)
        {
            return CalculateTotalTime(totalExecutions: (profile.Preferences.MobilePointsPersearch == 0 ? 0 : profile.Preferences.MobileTotalPoints / profile.Preferences.MobilePointsPersearch) - profile.Search.MobileSearchesCount,
                                      executionsOffset: profile.Preferences.MaxStreakAmount - profile.Search.StreakCount,
                                      executionsPerStreak: profile.Preferences.MaxStreakAmount,
                                      pauseBetweenExecutions: profile.Preferences.MinWait,
                                      pauseBetweenStreaks: profile.Preferences.MinStreakDelay,
                                      currentPauseBetweenStreaks: profile.Search.StreakDelay,
                                      elapsedSeconds: profile.Search.IsMobile ? profile.Search.ElapsedSeconds : 0,
                                      currentPause: profile.Search.IsMobile ? profile.Search.SecondsToWait : 0,
                                      streakTime: profile.Search.StreakTime,
                                      playing: profile.Search.IsPlaying && profile.Search.IsMobile);
        }

        public static TimeSpan GetMobileExpectedTimeMax(Profile profile)
        {
            return CalculateTotalTime(totalExecutions: (profile.Preferences.MobilePointsPersearch == 0 ? 0 : profile.Preferences.MobileTotalPoints / profile.Preferences.MobilePointsPersearch) - profile.Search.MobileSearchesCount,
                                      executionsOffset: profile.Preferences.MinStreakAmount - profile.Search.StreakCount,
                                      executionsPerStreak: profile.Preferences.MinStreakAmount,
                                      pauseBetweenExecutions: profile.Preferences.MaxWait,
                                      pauseBetweenStreaks: profile.Preferences.MaxStreakDelay,
                                      currentPauseBetweenStreaks: profile.Search.StreakDelay,
                                      elapsedSeconds: profile.Search.IsMobile ? profile.Search.ElapsedSeconds : 0,
                                      currentPause: profile.Search.IsMobile ? profile.Search.SecondsToWait : 0,
                                      streakTime: profile.Search.StreakTime,
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
            return $"{GetTotalExpectedTimeMin(profile):hh\\:mm\\:ss} - {GetTotalExpectedTimeMax(profile):hh\\:mm\\:ss}";
        }
    }
}