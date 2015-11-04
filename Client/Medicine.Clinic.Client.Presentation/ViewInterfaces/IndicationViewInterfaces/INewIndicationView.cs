using System;

namespace Medicine.Clinic.Client.Presentation
{
    public interface INewIndicationView
    {
        event EventHandler newOkClick;
        bool OkEnabled { set; }
        string NewIndicationViewCode { get; set; }
        string NewIndicationViewName { get; set; }
        string ResultMessage { get; set; }
        void Close();
    }
}
