using Medicine.Clinic.Client.Model.ClinicService;
using System;
using System.ComponentModel;

namespace Medicine.Clinic.Client.Presentation
{
    public interface INewDoctorEditView
    {
        event EventHandler NewDoctorEditLoad;
        event EventHandler EditOkClick;
        string NewDoctorViewCode { get; set; }
        string NewDoctorViewFirstName { get; set; }
        string NewDoctorViewLastName { get; set; }
        string NewDoctorViewMiddleName { get; set; }
        string NewDoctorEditClinicCode { set; }
        BindingList<DtoClinic> NewDoctorClinics { set; }
        string ClinicFocusedValue { get; }
        string ResultMessage { get; set; }
        void Close();
    }
}
