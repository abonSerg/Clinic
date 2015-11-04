using System.ServiceModel;

namespace Medicine.Clinic.Service
{
    [ServiceContract]
    public interface IApartmentService
    {
        [OperationContract]
        DtoApartment[] FindApartments(DtoApartment dtoApartment);
        [OperationContract]
        string AddApartment(DtoApartment dtoApartment);
    }
}
