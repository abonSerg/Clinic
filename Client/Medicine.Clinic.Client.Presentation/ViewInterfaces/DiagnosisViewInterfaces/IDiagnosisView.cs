using Medicine.Clinic.Client.Model.DiagnosisService;
using System;
using System.ComponentModel;

namespace Medicine.Clinic.Client.Presentation
{
    public interface IDiagnosisView
    {
        event EventHandler SearchClick;
        event EventHandler ClearClick;
        event EventHandler LoadForm;
        BindingList<DtoDiagnosis> DiagnosisViewGridControlData { set; }
        string ViewSearchCode { get; set; }
        string ViewSearchName { get; set; }
    }
}
