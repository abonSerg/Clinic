using System.ServiceModel;

namespace Medicine.Clinic.Service
{
    [ServiceContract]
    public interface ISexService
    {
        [OperationContract]
        DtoSex[] FindSexes(DtoSex dtoSex);
        [OperationContract]
        string EditSex(DtoSex dtoSex);
        [OperationContract]
        DtoSex GetSexByCode(string code);
    }
}
