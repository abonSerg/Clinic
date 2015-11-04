using Medicine.Clinic.Client.Model.DiagnosisService;
using System.ComponentModel;

namespace Medicine.Clinic.Client.Model
{
    public interface IDiagnosisModel
    {
        BindingList<DtoDiagnosis> SearchDiagnoses(string code, string name);
    }
}
