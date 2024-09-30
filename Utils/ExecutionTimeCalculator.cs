using System;

namespace EdgeSearch.Utils
{
    public class ExecutionTimeCalculator
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
    }
}