using System;

namespace Medicine.Clinic.Client.Presentation
{
    public interface INewDiagnosisView
    {
        event EventHandler NewOkClick;
        bool OkEnabled { set; }
        string NewDiagnosisViewCode { get; set; }
        string NewDiagnosisViewName { get; set; }
        string ResultMessage { get; set; }
        void Close();
    }
}
