using EdgeSearch.src.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace EdgeSearch.src.Interfaces
{
    public interface IProfilesForm : IAcceptCancelForm
    {
        void BindFields(List<Profile> profiles);
        Profile GetSelectedProfile();
        void Hide();
    }
}