using System.ServiceModel;

namespace Medicine.Clinic.Service
{
    [ServiceContract]
    public interface ITestService
    {
        [OperationContract]
        DtoTest[] FindTests(DtoTest dtoSpecimen);
        [OperationContract]
        string EditTest(DtoTest dtoSpecimen);
        [OperationContract]
        DtoTest GetTestByCode(string code);
        [OperationContract]
        DtoTest[] GetTestsByVisit(string billingNumber);
        [OperationContract]
        DtoConcreteTest[] GetConcreteTestsByVisit(string billingNumber);
        [OperationContract]
        double GetTestsCostByVisit(string billingNumber);
    }
}
