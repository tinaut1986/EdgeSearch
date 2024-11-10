using EdgeSearch.src.Models;

namespace EdgeSearch.src.Interfaces
{
    public interface IPreferencesForm : IAcceptCancelForm
    {
        void BindFields(Preferences model);
    }
}