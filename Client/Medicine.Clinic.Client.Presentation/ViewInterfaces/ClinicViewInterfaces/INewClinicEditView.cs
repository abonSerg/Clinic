using System;

namespace Medicine.Clinic.Client.Presentation
{
    public interface INewClinicEditView
    {
        event EventHandler EditOkClick;
        event EventHandler NewClinicEditLoad;
        string NewClinicViewCode { get; set; }
        string NewClinicViewName { get; set; }
        string NewClinicViewAddress { get; set; }
        string ResultMessage { get; set; }
        void Close();
    }

}
