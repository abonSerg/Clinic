using System.ComponentModel;
using Medicine.Clinic.Client.Model.PatientService;

namespace Medicine.Clinic.Client.Model
{
    public class PatientModel : IPatientModel
    {
        public BindingList<DtoPatient> SearchPatients(string mrn,
                                                      string ssn,
                                                      string firstName,
                                                      string lastName,
                                                      string middleName)
        {
            var dtoPatient = new DtoPatient()
            {
                Mrn = mrn,
                Ssn = ssn,
                FirstName = firstName,
                LastName = lastName,
                MiddleName = middleName,
            };
            return new BindingList<DtoPatient>(new PatientServiceClient().FindPatients(dtoPatient));
        }
    }
}
