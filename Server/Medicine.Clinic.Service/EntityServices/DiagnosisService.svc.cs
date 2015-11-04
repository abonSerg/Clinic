using System.Linq;
using Medicine.Clinic.DataAccess;

namespace Medicine.Clinic.Service
{
    public class DiagnosisService : IDiagnosisService
    {
        public DtoDiagnosis[] FindDiagnoses(DtoDiagnosis dtoDiagnosis)
        {
            Diagnosis[] diagnoses = DiagnosisMethods.Instance.GetDiagnoses(dtoDiagnosis.Code, dtoDiagnosis.Name);
            DtoDiagnosis[] dtoDiagnoses = diagnoses.Select(emp => new DtoDiagnosis()
            {
                Id = emp.Id,
                Code = emp.Code,
                Name = emp.Name,
            }).ToArray();
            return dtoDiagnoses;
        }

        public string EditDiagnosis(DtoDiagnosis dtoDiagnosis)
        {
            var uniqueDiagnosis = DiagnosisMethods.Instance.GetDiagnosisByCode(dtoDiagnosis.Code);
            if (!dtoDiagnosis.IsEdit)
            {
                var diagnosis = new Diagnosis()
                {
                    Code = dtoDiagnosis.Code,
                    Name = dtoDiagnosis.Name
                };
                return DiagnosisMethods.Instance.InsertDiagnosis(diagnosis);
            }
            else 
            {
                var diagnosis = new Diagnosis()
                {
                    Id = uniqueDiagnosis.Id,
                    Code = dtoDiagnosis.Code,
                    Name = dtoDiagnosis.Name
                };
                return DiagnosisMethods.Instance.UpdateDiagnosis(diagnosis);
            }
           
        }
    }
}
