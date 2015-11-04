using System.ServiceModel;

namespace Medicine.Clinic.Service
{
    [ServiceContract]
    public interface IInterpretationService
    {
        [OperationContract]
        DtoConcreteDiagnosis[] FindConcreteDiagnosis(string number);
        [OperationContract]
        DtoInterpretation GetInterpretationByOrder(string orderNumber);
        [OperationContract]
        string AddConcreteDiagnosis(DtoConcreteDiagnosis dtoConcreteDiagnosis);
        [OperationContract]
        string EditConcreteDiagnosis(DtoConcreteDiagnosis dtoConcreteDiagnosis);
        [OperationContract]
        string EditInterpretation(DtoInterpretation dtoInterpretation);
    }
}
