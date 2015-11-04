using Medicine.Clinic.Client.Model.ClinicService;
using System;
using System.ComponentModel;

namespace Medicine.Clinic.Client.Presentation
{
    public interface INewDoctorView
    {
        event EventHandler NewOkClick;
        string NewDoctorViewCode { get; }
        bool OkEnabled { set; }
        string NewDoctorViewFirstName { get; }
        string NewDoctorViewLastName { get; }
        string NewDoctorViewMiddleName { get; }
        string ResultMessage { get; set; }
        BindingList<DtoClinic> NewDoctorClinics { set; }
        string ClinicFocusedValue { get; }
        void Close();
    }
}
