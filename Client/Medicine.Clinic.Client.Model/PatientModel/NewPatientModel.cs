using System;
using System.ComponentModel;
using Medicine.Clinic.Client.Model.PatientService;
using Medicine.Clinic.Client.Model.SexService;

namespace Medicine.Clinic.Client.Model
{
    public class NewPatientModel : INewPatientModel, INewPatientEditModel
    {

        private PatientServiceClient patientService;

        private PatientServiceClient PatientService
        {
            get
            {
                patientService = patientService ?? new PatientServiceClient();
                return new PatientServiceClient();
            }
        }

        public string EditPatient(string mrn,
                                  string ssn,
                                  string firstName,
                                  string lastName,
                                  string middleName,
                                  DateTime dob,
                                  string sexCode,
                                  DateTime? dod,
                                  bool isEdit,
                                  bool isSsnFull)
                               
        {
            if (isSsnFull)
            {
                var dtoPatient = new DtoPatient()
                {
                    Mrn = mrn,
                    Ssn = ssn,
                    FirstName = firstName,
                    LastName = lastName,
                    MiddleName = middleName,
                    Dob = dob,
                    Sex = new PatientService.DtoSex() { Code = sexCode },
                    Dod = dod,
                    IsEdit = isEdit
                };

                return PatientService.EditPatient(dtoPatient);
            }
            else 
            {
                return "Fill validate Ssn!";
            }
            
        }


        public BindingList<SexService.DtoSex> LoadSexes()
        {
            SexService.DtoSex dtoSex = new SexService.DtoSex()
            {
                Code = string.Empty,
                Name = string.Empty
            };

            return new BindingList<SexService.DtoSex>(new SexServiceClient().FindSexes(dtoSex));
        }

        public string LoadPatientMrn()
        {
            return PatientService.GetPatientMrn();
        }
    }
}
