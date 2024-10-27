using System;

namespace EdgeSearch.src.Interfaces
{
    public interface IAcceptCancelForm
    {
        event EventHandler Load;
        event EventHandler AcceptClick;
        event EventHandler CancelClick;

        void CloseFormAsAccepted();
        void CloseFormAsCanceled();
        void SetButtonsAvailability(bool? acceptEnabled, bool? cancelEnabled);
        void SetButtonsText(string acceptText, string cancelText);
        void SetButtonsVisibility(bool? acceptVisible, bool? cancelVisible);
    }
}