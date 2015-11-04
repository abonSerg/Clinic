using System;
using System.ComponentModel;
using Medicine.Clinic.Client.Model.DiagnosisService;
using Medicine.Clinic.Client.Model.GridControlsEntities;
using Medicine.Clinic.Client.Model.OrderService;

namespace Medicine.Clinic.Client.Presentation
{
    public interface IInterpretationView
    {
        event EventHandler SearchClick;
        event EventHandler ClearClick;
        event EventHandler LoadForm;
        event EventHandler LoadClick;
        event EventHandler DiagnosisChoose;
        event EventHandler SaveClick;
        event EventHandler SignOutClick;
        string InterpretationViewSearchOrderNumber { get; set; }
        string InterpretationViewSearchBillingNumber { get; set; }
        BindingList<DtoOrder> InterpretationViewGridControlData { set; }
        BindingList<DiagnosisForGrid> InterpretationViewDiagnosisGridControlData { get; set; }
        BindingList<DtoDiagnosis> InterpretationViewDiagnosesList { set; }
        bool SaveButtonEnabled { set; }
        bool SignOutButtonEnabled { set; }
        DtoOrder InterpretationViewFocusedOrder { get; }
        DiagnosisForGrid InterpretationViewFocusedDiagnosis { get; }
        string InterpretationViewOrderNumber { get; set; }
        string InterpretationViewInterpretationStatus { get; set; }
        string InterpretationViewSignOutDt { get; set; }
        string InterpretationViewText { get; set; }
        char InterpretationViewCondition { get; set; }
        string ResultMessage { get; set; }

    }
}
