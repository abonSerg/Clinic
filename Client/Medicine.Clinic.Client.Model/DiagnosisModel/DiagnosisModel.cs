using System.ComponentModel;
using Medicine.Clinic.Client.Model.DiagnosisService;

namespace Medicine.Clinic.Client.Model
{
    public class DiagnosisModel : IDiagnosisModel
    {
        public BindingList<DtoDiagnosis> SearchDiagnoses(string code, string name)
        {
            var dtoDiagnosis = new DtoDiagnosis()
            {
                Code = code,
                Name = name
            };
            return new BindingList<DtoDiagnosis>(new DiagnosisServiceClient().FindDiagnoses(dtoDiagnosis));
        }
    }
}
