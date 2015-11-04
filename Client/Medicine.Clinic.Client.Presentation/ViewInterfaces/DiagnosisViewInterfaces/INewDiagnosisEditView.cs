using System;

namespace Medicine.Clinic.Client.Presentation
{
    public interface INewDiagnosisEditView
    {
        event EventHandler EditOkClick;
        event EventHandler NewDiagnosisEditLoad;
        string NewDiagnosisViewCode { get; set; }
        string NewDiagnosisViewName { get; set; }
        string ResultMessage { get; set; }
        void Close();
    }
}
