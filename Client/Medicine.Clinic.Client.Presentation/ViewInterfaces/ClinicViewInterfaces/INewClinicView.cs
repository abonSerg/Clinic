using System;

namespace Medicine.Clinic.Client.Presentation
{
    public interface INewClinicView
    {
        event EventHandler NewOkClick;
        string NewClinicViewCode { get; set; }
        string NewClinicViewName { get; set; }
        string NewClinicViewAddress { get; set; }
        string ResultMessage { get; set; }
        bool OkEnabled { set; }
        void Close();
    }
}
