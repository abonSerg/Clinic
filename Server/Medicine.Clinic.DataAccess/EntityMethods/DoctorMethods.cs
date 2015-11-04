using System.Linq;
using NHibernate;
using NHibernate.Linq;
using log4net;


namespace Medicine.Clinic.DataAccess
{
    public class DoctorMethods : DbAccess
    {
        private static DoctorMethods instance;
        public static readonly ILog log = LogManager.GetLogger(typeof(DoctorMethods));

        public static DoctorMethods Instance
        {
            get
            {
                instance = instance ?? new DoctorMethods();
                return instance;
            }
        }


        private static string ValidateDoctor(Doctor doctor) 
        {
            if (!string.IsNullOrEmpty(doctor.FirstName) && !string.IsNullOrEmpty(doctor.LastName))
            {
                if(!string.IsNullOrEmpty(doctor.Clinic.Code))
                {
                    return string.Empty;
                }
                else
                {
                    return "Choose CLinic!";
                }
            }
            else 
            {
                return "Last Name and Fist Name are mandatory fields!";
            }
        }

        public string InsertDoctor(Doctor doctor)
        {
            string message = ValidateDoctor(doctor);
            if (string.IsNullOrEmpty(message))
            {
                Doctor uniqueDoctorInClinic = DoctorMethods.Instance.GetDoctorByClinic(ClinicMethods.Instance.GetClinicByCode(doctor.Clinic.Code).Code);
                if (uniqueDoctorInClinic == null)
                {
                    doctor.Clinic.Id = ClinicMethods.Instance.GetClinicByCode(doctor.Clinic.Code).Id;
                    bool isProcessDone = InsertEntity<Doctor>(doctor);
                    if (isProcessDone)
                    {
                        log.Info(string.Format("Doctor {0} saved", doctor.Code));
                        return string.Empty;
                    }
                    else
                    {
                        return "Code will be UNIQE!";
                    }
                }
                else
                {
                    return "Doctor for this Clinic is exists already!";
                }

            }
            else 
            {
                return message;
            }
            
        }

        public string UpdateDoctor(Doctor doctor)
        {
            string message = ValidateDoctor(doctor);
            if (string.IsNullOrEmpty(message))
            {
                Doctor uniqueDoctorInClinic = DoctorMethods.Instance.GetDoctorByClinic(ClinicMethods.Instance.GetClinicByCode(doctor.Clinic.Code).Code);
                if (uniqueDoctorInClinic == null)
                {
                    doctor.Clinic.Id = ClinicMethods.Instance.GetClinicByCode(doctor.Clinic.Code).Id;
                    bool isProcessDone = InsertEntity<Doctor>(doctor);
                    if (isProcessDone)
                    {
                        log.Info(string.Format("Doctor {0} changed", doctor.Code));
                        return string.Empty;
                    }
                    else
                    {
                        return "Code will be UNIQE!";
                    }
                }
                else
                {
                    return "Doctor for this Clinic is exists already!";
                }
            }
            else 
            {
                return message;
            }
            
          
        }

 
        public Doctor[] GetDoctors (string code, string firstName, string lastName) 
        {
            return GetPersonEntities<Doctor>(code, firstName, lastName);
        }


        public Doctor GetDoctorByCode(string code)
        {
            return GetEntityByCode<Doctor>(code);
        }

        public Doctor GetDoctorByClinic(string clinicCode)
        {
            ISession readSession = readSessionsFactory.OpenSession();
            return readSession.Query<Doctor>()
                              .Cacheable()
                              .SingleOrDefault<Doctor>(doctor => doctor.Clinic.Code == clinicCode);
        }
    }
}
