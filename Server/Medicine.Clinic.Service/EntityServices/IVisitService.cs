using System.ServiceModel;

namespace Medicine.Clinic.Service
{
    [ServiceContract]
    public interface IVisitService
    {
        [OperationContract]
        string SearchVisits(string searchMrn, string searchPatientFirstName, string searchBllingNumber);
        [OperationContract]
        string SearchNewVisitProperties();
        [OperationContract]
        string GetBillingNumber();
        [OperationContract]
        string EditVisit(string billingNumber, string mrn, string doctorCode, int apartmentId);
        [OperationContract]
        string GetPatientMrn(string billingNumber);
        [OperationContract]
        string GetDoctorCode(string billingNumber);
        [OperationContract]
        int GetApartmentId(string billingNumber);
        [OperationContract]
        string GetDefaultDoctorCode(int apartmentId);
    }
}
