using System;
using System.ServiceModel;

namespace Medicine.Clinic.Service
{
    [ServiceContract]
    public interface IPatientService
    {
        [OperationContract]
        string EditPatient(DtoPatient dtoPatient);
        [OperationContract]
        DtoPatient[] FindPatients(DtoPatient dtoPatient);
        [OperationContract]
        string GetPatientMrn();
        [OperationContract]
        DateTime? GetPatientDodByOrder(string orderNumber);
    }    
        
    
}
