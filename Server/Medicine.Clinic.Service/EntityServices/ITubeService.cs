using System.ServiceModel;

namespace Medicine.Clinic.Service
{
    [ServiceContract]
    public interface ITubeService
    {
        [OperationContract]
        string EditTube(DtoTube dtoTube);
        [OperationContract]
        DtoTube[] FindTubes(DtoTube dtoTube);
        [OperationContract]
        DtoTube GetTubeByCode(string code);
    }
}
