using System.ServiceModel;

namespace Medicine.Clinic.Service
{
    [ServiceContract]
    public interface IClinicService
    {
        [OperationContract]
        DtoClinic[] FindClinics(DtoClinic dtoClinic);
        [OperationContract]
        string EditClinic(DtoClinic dtoClinic);
    }
}
