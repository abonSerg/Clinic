using System.ServiceModel;

namespace Medicine.Clinic.Service
{
    [ServiceContract]
    public interface IDiagnosisService
    {
        [OperationContract]
        DtoDiagnosis[] FindDiagnoses(DtoDiagnosis dtoDiagnosis);
        [OperationContract]
        string EditDiagnosis(DtoDiagnosis dtoDiagnosis);
    }
}
