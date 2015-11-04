using System.Linq;
using NHibernate;
using NHibernate.Linq;
using log4net;


namespace Medicine.Clinic.DataAccess
{
    public class VisitMethods : DbAccess
    {
        private static VisitMethods instance;
        public static readonly ILog log = LogManager.GetLogger(typeof(VisitMethods));

        public static VisitMethods Instance
        {
            get
            {
                instance = instance ?? new VisitMethods();
                return instance;
            }
        }

        public static string ValidateVisit(Visit visit) 
        {
            if (!string.IsNullOrEmpty(visit.Patient.Mrn))
            {
                if (PatientMethods.Instance.GetPatientByMrn(visit.Patient.Mrn).Dod == null)
                {
                    if (visit.Apartment.Id != 0)
                    {
                        if (DoctorMethods.Instance.GetDoctorByCode(visit.Doctor.Code).Clinic.Id == ApartmentMethods.Instance.GetApartmentById(visit.Apartment.Id).Clinic.Id)
                        {
                            return string.Empty;
                        }
                        else
                        {
                            return "Invalid Doctor for chosen Clinic!";
                        }
                    }
                    else 
                    {
                        return "Choose apartment!";
                    }
                    
                }
                else 
                {
                    return "Patient is dead!";
                }
            }
            else 
            {
                return "Choose patient!";
            }
        }

        public string InsertVisit(Visit visit)
        {
            string message = ValidateVisit(visit);
            if (string.IsNullOrEmpty(message))
            {
                visit.Doctor.Id = DoctorMethods.Instance.GetDoctorByCode(visit.Doctor.Code).Id;
                visit.Patient.Id = PatientMethods.Instance.GetPatientByMrn(visit.Patient.Mrn).Id;
                bool isProcessDone = InsertEntity<Visit>(visit);
                if (isProcessDone)
                {
                    log.Info(string.Format("Visit {0} saved",visit.BillingNumber));
                    return string.Empty;
                }
                else
                {
                    return "Error!";
                }
            }
            else 
            {
                return message;
            }
            
        }

        public string UpdateVisit(Visit visit)
        {
            string message = ValidateVisit(visit);
            if (string.IsNullOrEmpty(message))
            {
                visit.Doctor.Id = DoctorMethods.Instance.GetDoctorByCode(visit.Doctor.Code).Id;
                visit.Patient.Id = PatientMethods.Instance.GetPatientByMrn(visit.Patient.Mrn).Id;
                bool isProcessDone = UpdateEntity<Visit>(visit);
                if (isProcessDone)
                {
                    log.Info(string.Format("Visit {0} changed", visit.BillingNumber));
                    return string.Empty;
                }
                else
                {
                    return "Error!";
                }
            }
            else
            {
                return message;
            }
        }

        public Visit GetVisitById(int id)
        {
            return GetEntityById<Visit>(id);
        }

        public Visit GetVisitByBillingNumber(string billingNumber)
        {
            ISession readSession = readSessionsFactory.OpenSession();
            return readSession.Query<Visit>()
                              .SingleOrDefault<Visit>(visit => visit.BillingNumber == billingNumber);
        }

        public Visit[] GetVisits(string mrn, string patientfirstName, string billingNumber) 
        {
            ISession readSession = readSessionsFactory.OpenSession();
            return readSession.Query<Visit>()
                              .Cacheable()
                              .Where(visit => visit.Patient.Mrn.Contains(mrn))
                              .Where(visit => visit.Patient.FirstName.Contains(patientfirstName))
                              .Where(visit => visit.BillingNumber.Contains(billingNumber))
                              .ToArray();
        }

        public string GenerateBillingNumber()
        {
            return GenerateEntityCode<Visit>();
        }

    }
}
