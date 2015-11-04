using log4net;

namespace Medicine.Clinic.DataAccess
{
    public class ClinicMethods : DbAccess
    {
        private static ClinicMethods instance;
        public static readonly ILog log = LogManager.GetLogger(typeof(ClinicMethods));

        public static ClinicMethods Instance
        {
            get
            {
                instance = instance ?? new ClinicMethods();
                return instance;
            }
        }

        public static string ValidateClinic(Clinic clinic) 
        {
            if (!string.IsNullOrEmpty(clinic.Name) && !string.IsNullOrEmpty(clinic.Address)) 
            {
                return string.Empty;
            }
            else
            {
                return "Fill all mandatory fields!";
            }
        }

        public string InsertClinic(Clinic clinic)
        {
            string message = ValidateClinic(clinic);
            if (string.IsNullOrEmpty(message))
            {
                bool isProcessDone = InsertEntity<Clinic>(clinic);
                if (isProcessDone)
                {
                    log.Info(string.Format("Clinic {0} added", clinic.Code));
                    return string.Empty;
                }
                else
                {
                    return "Code will be UNIQE!";
                }
            }
            else 
            {
                return message;
            }
        }

        public string UpdateClinic(Clinic clinic)
        {
            string message = ValidateClinic(clinic);
            if (string.IsNullOrEmpty(message))
            {
                bool isProcessDone = UpdateEntity<Clinic>(clinic);
                if (isProcessDone)
                {
                    log.Info(string.Format("Clinic {0} changed", clinic.Code));
                    return string.Empty;
                }
                else
                {
                    return "Code will be UNIQE!";
                }
            }
            else
            {
                return message;
            }
        }

        public Clinic[] GetClinics(string code, string name)
        {
            return GetEntities<Clinic>(code, name);
        }

        public Clinic GetClinicById(int clinicId)
        {
            return GetEntityById<Clinic>(clinicId);
        }

        public Clinic GetClinicByCode(string clinicCode)
        {
            return GetEntityByCode<Clinic>(clinicCode);
        }
    }
}
