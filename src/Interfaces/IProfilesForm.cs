using EdgeSearch.src.Events;
using EdgeSearch.src.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace EdgeSearch.src.Interfaces
{
    public interface IProfilesForm : IAcceptCancelForm
    {
        event EventHandler<ProfileEventArgs> ProfileDeletionRequested;

        void BindFields(BindingList<Profile> profiles);
        Profile GetSelectedProfile();
        void Hide();
    }
}