using Medicine.Clinic.Client.Model.ClinicService;
using System;
using System.ComponentModel;

namespace Medicine.Clinic.Client.Presentation
{
    public interface INewApartmentEditView
    {
        event EventHandler NewApartmentEditLoad;
        event EventHandler EditOkClick;
        BindingList<DtoClinic> NewApartmentsViewClinics { set; }
        bool OkEnabled { set; }
        string NewApartmentEditClinicCode { set; }
        string ClinicEditValue { get; }
        string ResultMessage { get; set; }
        string NewApartmentViewRoomId { get; set; }
        string NewApartmentViewBedId { get; set; }
    }
}
