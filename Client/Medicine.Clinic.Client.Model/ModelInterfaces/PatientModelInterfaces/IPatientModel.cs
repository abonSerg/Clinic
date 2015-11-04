using Medicine.Clinic.Client.Model.PatientService;
using System.ComponentModel;

namespace Medicine.Clinic.Client.Model
{
    public interface IPatientModel
    {
        BindingList<DtoPatient> SearchPatients(string mrn, string ssn, string firstName, string lastName, string middleName);
    }
}
