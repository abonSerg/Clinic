using Medicine.Clinic.Client.Model.DiagnosisService;

namespace Medicine.Clinic.Client.Model
{
    public class NewDiagnosisModel : INewDiagnosisModel, INewDiagnosisEditModel
    {
        public string EditDiagnosis(string code, string name, bool isEdit)
        {
            if (Validation.Instance.ValidateCode(code))
            {
                var dtoDiagnosis = new DtoDiagnosis()
                {
                    Code = code,
                    Name = name,
                    IsEdit = isEdit
                };
                return new DiagnosisServiceClient().EditDiagnosis(dtoDiagnosis);
            }
            else 
            {
                return "Invalid Code field!";
            }
           
        }
    }
}
