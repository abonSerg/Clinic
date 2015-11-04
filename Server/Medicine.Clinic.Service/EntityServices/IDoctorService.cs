using System.ServiceModel;

namespace Medicine.Clinic.Service
{
    [ServiceContract]
    public interface IDoctorService
    {
        [OperationContract]
        DtoDoctor[] FindDoctors(DtoDoctor dtoDoctor);
        [OperationContract]
        string EditDoctor(DtoDoctor dtoDoctor);
    }
}
