namespace EdgeSearch.src.Common
{
    public enum TabType
    {
        Searches = 0,
        Rewards = 1,
    }

    public enum SearchMode
    {
        Desktop = 0,
        Mobile = 1,
    }

    public enum SearchState
    {
        Stopped = 0,
        BetweenSearches = 1,
        OnStreaksDelay = 2,
        PendingEnterOnStreakDelay = 3,
        PendingStartNextSearch = 4,
    }
}
