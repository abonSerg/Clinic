using System;
using System.Linq;
using Medicine.Clinic.DataAccess;

namespace Medicine.Clinic.Service
{
    public class PatientService : IPatientService
    {
        public string EditPatient(DtoPatient dtoPatient)
        {
            var uniquePatient = PatientMethods.Instance.GetPatientByMrn(dtoPatient.Mrn);
            if (!dtoPatient.IsEdit)
            {
                var patient = new Patient()
                {
                    Mrn = dtoPatient.Mrn,
                    Ssn = dtoPatient.Ssn,
                    FirstName = dtoPatient.FirstName,
                    LastName = dtoPatient.LastName,
                    MiddleName = dtoPatient.MiddleName,
                    Dob = dtoPatient.Dob,
                    Dod = dtoPatient.Dod,
                    Sex = new Sex()
                    {
                        Code = dtoPatient.Sex.Code
                    }
                };
                return PatientMethods.Instance.InsertPatient(patient);
            }
            else 
            {
                var patient = new Patient()
                {
                    Id = uniquePatient.Id,
                    Mrn = dtoPatient.Mrn,
                    Ssn = dtoPatient.Ssn,
                    FirstName = dtoPatient.FirstName,
                    LastName = dtoPatient.LastName,
                    MiddleName = dtoPatient.MiddleName,
                    Dob = dtoPatient.Dob,
                    Dod = dtoPatient.Dod,
                    Sex = new Sex()
                    {
                        Code = dtoPatient.Sex.Code
                    }
                };
                return PatientMethods.Instance.UpdatePatient(patient);
            }

            
        }

        public DtoPatient[] FindPatients(DtoPatient dtoPatient)
        {
            Patient[] patients = PatientMethods.Instance.GetPatients(dtoPatient.Mrn,
                                                                     dtoPatient.Ssn,
                                                                     dtoPatient.FirstName,
                                                                     dtoPatient.LastName,
                                                                     dtoPatient.MiddleName);
            DtoPatient[] dtoPatients = patients.Select(patient => new DtoPatient()
            {
                Id = patient.Id,
                Mrn = patient.Mrn,
                Ssn = patient.Ssn,
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                MiddleName = patient.MiddleName,
                Sex = new DtoSex (){ Id = patient.Sex.Id,
                                     Code = patient.Sex.Code,
                                     Name = patient.Sex.Name
                                   },
                Dob = patient.Dob,
                Dod = patient.Dod,
                Age = PatientMethods.Instance.GetAge(patient.Dob, patient.Dod)
            }).ToArray();
            return dtoPatients;
        }

        public string GetPatientMrn() 
        {
            return PatientMethods.Instance.GeneratePatientMrn();
        }

        public DateTime? GetPatientDodByOrder(string billingNumber) 
        {
            return PatientMethods.Instance.GetPatientById(VisitMethods.Instance.GetVisitByBillingNumber(billingNumber).Patient.Id).Dod;
        }

    }
}
