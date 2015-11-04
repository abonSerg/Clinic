using Medicine.Clinic.Client.Model.PatientService;
using System;
using System.ComponentModel;

namespace Medicine.Clinic.Client.Presentation
{
    public interface IPatientView
    {
        event EventHandler SearchClick;
        event EventHandler ClearClick;
        event EventHandler LoadForm;
        BindingList<DtoPatient> PatientViewGridControlData { set; }
        string PatientViewSearchMrn { get; set; }
        string PatientViewSearchSsn { get; set; }
        string PatientViewSearchFirstName { get; set; }
        string PatientViewSearchLastName { get; set; }
        string PatientViewSearchMiddleName { get; set; }
    }
}
