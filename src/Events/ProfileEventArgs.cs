using EdgeSearch.src.Models;

namespace EdgeSearch.src.Events
{
    public class ProfileEventArgs
    {
        public Profile Profile { get; }

        public ProfileEventArgs(Profile profile)
        {
            Profile = profile;
        }
    }
}
