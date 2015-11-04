using System.ServiceModel;

namespace Medicine.Clinic.Service
{
    [ServiceContract]
    public interface IIndicationService
    {
        [OperationContract]
        DtoIndication[] FindIndications(DtoIndication dtoIndication);
        [OperationContract]
        string EditIndication(DtoIndication dtoIndication);
    }
}
