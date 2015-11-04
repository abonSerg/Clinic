using System;
using System.ComponentModel;
using Medicine.Clinic.Client.Model.GridControlsEntities;
using Medicine.Clinic.Client.Model.OrderService;
using DtoDiagnosis = Medicine.Clinic.Client.Model.DiagnosisService.DtoDiagnosis;

namespace Medicine.Clinic.Client.Model
{
    public interface IInterpretationModel
    {
        BindingList<DtoOrder> SearchOrders(string number, string billingNumber);
        BindingList<DiagnosisForGrid> SearchConcreteDiagnoses(string number);
        BindingList<DtoDiagnosis> SearchDiagnoses();
        BindingList<DiagnosisForGrid> EditConcreteDiagnosis(BindingList<DiagnosisForGrid> diagnosisGrids, string orderNumber);
        int GetInterpretationId(string orderNumber);
        string GetInterpretationText(string orderNumber);
        char GetInterpretationCondition(string orderNumber);
        string GetInterpretationSignOutDt(string orderNumber);
        string EditInterpretation(string text, char condition, string orderNumber, DateTime? signOutDt);
        string SignOutInterpretation(string text, char condition, string orderNumber);
        string LoadDiagnosis(string code, BindingList<DiagnosisForGrid> diagnosisGrids);
    }
}
