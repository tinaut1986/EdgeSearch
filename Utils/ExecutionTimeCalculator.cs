using System;

namespace EdgeSearch.Utils
{
    public class ExecutionTimeCalculator
    {
        public static TimeSpan CalculateTotalTime(int totalExecutions, int executionsOffset, int executionsPerStrike,
            int pauseBetweenExecutions, int pauseBetweenStrikes, int elapsedSeconds, int currentPause, DateTime? strikeTime, bool playing)
        {
            if (executionsPerStrike == 0)
                return TimeSpan.Zero;

            DateTime now = DateTime.Now;
            int strikeSeconds = 0;
            if (strikeTime != null && playing)
                strikeSeconds = pauseBetweenStrikes - (int)(now - strikeTime.Value).TotalSeconds;

            // Calculate the number of chains required to complete all executions
            int totalStrikes = (totalExecutions - 1) / executionsPerStrike;

            // Calculate the time for the remaining executions if any
            int remainingExecutions = totalExecutions % executionsPerStrike;
            if (remainingExecutions == 0 && totalExecutions > 0)
                remainingExecutions = executionsPerStrike;

            // Calculate the total time for all chains except the last pause
            int totalTimeInSeconds = (remainingExecutions * pauseBetweenExecutions) + (totalStrikes * pauseBetweenStrikes) + (totalStrikes * executionsPerStrike * pauseBetweenExecutions) + strikeSeconds;

            // Return the total time as a TimeSpan object
            int total = totalTimeInSeconds - elapsedSeconds;
            if (totalExecutions > 0 && playing)
                total += -pauseBetweenExecutions + currentPause;

            return TimeSpan.FromSeconds(total);
        }
    }
}