using Medicine.Clinic.Client.Model.DoctorService;
using System;
using System.ComponentModel;

namespace Medicine.Clinic.Client.Presentation
{
    public interface IDoctorView
    {
        event EventHandler SearchClick;
        event EventHandler ClearClick;
        event EventHandler LoadForm;
        BindingList<DtoDoctor> DoctorViewGridControlData { set; }
        string DoctorViewSearchCode { get; set; }
        string DoctorViewSearchFirstName { get; set; }
        string DoctorViewSearchLastName { get; set; }
    }
}
