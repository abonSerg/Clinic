using Medicine.Clinic.Client.Model.ClinicService;
using System;
using System.ComponentModel;

namespace Medicine.Clinic.Client.Presentation
{
    public interface IClinicView
    {
        event EventHandler SearchClick;
        event EventHandler ClearClick;
        event EventHandler LoadForm;
        BindingList<DtoClinic> ClinicViewGridControlData { set; }
        string ViewSearchCode { get; set; }
        string ViewSearchName { get; set; }
    }
}
