using System;

namespace EdgeSearch.Interfaces
{
    public interface IAcceptCancelForm
    {
        event EventHandler AcceptClick;
        event EventHandler CancelClick;

        void CloseFormAsAccepted();
        void CloseFormAsCanceled();
        void SetButtonsAvailability(bool? acceptEnabled, bool? cancelEnabled);
        void SetButtonsText(string acceptText, string cancelText);
        void SetButtonsVisibility(bool? acceptVisible, bool? cancelVisible);
    }
}