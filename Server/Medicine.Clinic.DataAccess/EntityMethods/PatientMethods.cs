using System;
using System.Linq;
using NHibernate;
using NHibernate.Linq;
using log4net;


namespace Medicine.Clinic.DataAccess
{
    public class PatientMethods : DbAccess
    {
        private static PatientMethods instance;
        public static readonly ILog log = LogManager.GetLogger(typeof(PatientMethods));
                             
        public static PatientMethods Instance
        {
            get
            {
                instance = instance ?? new PatientMethods();
                return instance;
            }
        }

        internal static string ValidatePatient(Patient patient)
        {
            if (patient.Dob <= DateTime.Now)
            {
                if (!string.IsNullOrEmpty(patient.Ssn) &&
                    !string.IsNullOrEmpty(patient.FirstName) &&
                    !string.IsNullOrEmpty(patient.LastName) &&
                    (patient.Dob != DateTime.MinValue) &&
                    (!string.IsNullOrEmpty(patient.Sex.Code)))
                {
                    return string.Empty;
                }
                else
                {
                    return "Fill all mandatory fields!";
                }
            }
            else
            {
                return "Choose correct Birth date!";
            }
        }

       

        public string InsertPatient(Patient patient) 
        {
            string message = ValidatePatient(patient);
            if (string.IsNullOrEmpty(message))
            {
                patient.Sex.Id = SexMethods.Instance.GetSexByCode(patient.Sex.Code).Id;
                bool isProcessDone = InsertEntity<Patient>(patient);
                if (isProcessDone)
                {
                    log.Info(string.Format("Patient {0} saved", patient.Mrn));
                    return string.Empty;
                }
                else
                {
                    return "Ssn must be UNIQUE!";
                }
            }
            else
            {
                return message;
            }
        }

        public string UpdatePatient(Patient patient)
        {
            string message = ValidatePatient(patient);
            if (string.IsNullOrEmpty(message))
            {
                patient.Sex.Id = SexMethods.Instance.GetSexByCode(patient.Sex.Code).Id;
                if (patient.Dod == DateTime.MinValue)
                {
                    patient.Dod = null;
                    bool isProcessDone = UpdateEntity<Patient>(patient);
                    if (isProcessDone)
                    {
                        log.Info(string.Format("Patient {0} changed", patient.Mrn));
                        return string.Empty;
                    }
                    else
                    {
                        return "Ssn must be UNIQUE!";
                    }
                }
                else
                {
                    if ((patient.Dob < patient.Dod))
                    {
                        bool isProcessDone = UpdateEntity<Patient>(patient);
                        if (isProcessDone)
                        {
                            log.Info(string.Format("Patient {0} changed", patient.Mrn)); ;
                            return string.Empty;
                        }
                        else
                        {
                            return "Ssn must be UNIQUE!";
                        }
                    }
                    else
                    {
                        return "Invalid Dates";
                    }
                }
            }
            else
            {
                return message;
            }

           
        }

        public Patient[] GetPatients(string mrn, string ssn, string firstName, string lastName, string middleName)
        {
            ISession session = writeSessionsFactory.OpenSession();
            return session.Query<Patient>()
                          .Cacheable()
                          .Where(patient => patient.Mrn.Contains(mrn))
                          .Where(patient => patient.Ssn.Contains(ssn.Trim(new char[]{'-', ' '})))
                          .Where(patient => patient.FirstName.Contains(firstName))
                          .Where(patient => patient.LastName.Contains(lastName))
                          .Where(patient => patient.MiddleName.Contains(middleName))
                          .ToArray();
        }

        public Patient GetPatientByMrn(string mrn)
        {
            ISession readSession = readSessionsFactory.OpenSession();
            return readSession.Query<Patient>()
                              .Cacheable()
                              .SingleOrDefault<Patient>(patient => patient.Mrn == mrn);
        }

        public Patient GetPatientById(int id)
        {
            return GetEntityById<Patient>(id);
        }

        public string GeneratePatientMrn() 
        {
            return GenerateEntityCode<Patient>();
        }

        public int GetAge(DateTime dob, DateTime? dod) 
        {
            if (dod == null)
            {
                DateTime dtStart = dob;
                DateTime dtEnd = DateTime.Now;
                DateTime span = new DateTime((dtEnd - dtStart).Ticks);
                return Convert.ToInt32(span.Year - 1);
            }
            else
            {
                DateTime dtStart = dob;
                DateTime dtEnd = (DateTime)dod;
                DateTime span = new DateTime((dtEnd - dtStart).Ticks);
                return  Convert.ToInt32(span.Year - 1);
            }
        }
    }
}
