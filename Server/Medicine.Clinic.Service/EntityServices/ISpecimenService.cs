using System.ServiceModel;

namespace Medicine.Clinic.Service
{
    [ServiceContract]
    public interface ISpecimenService
    {
        [OperationContract]
        DtoSpecimen[] FindSpecimens(DtoSpecimen dtoSpecimen);
        [OperationContract]
        string EditSpecimen(DtoSpecimen dtoSpecimen);
        [OperationContract]
        DtoSpecimen GetSpecimenByCode(string code);
    }
}
