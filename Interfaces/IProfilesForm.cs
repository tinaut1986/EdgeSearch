using EdgeSearch.Models;
using System;
using System.Collections.Generic;

namespace EdgeSearch.Interfaces
{
    public interface IProfilesForm
    {
        public event EventHandler Load;
        void BindFields(List<Profile> profiles);
    }
}