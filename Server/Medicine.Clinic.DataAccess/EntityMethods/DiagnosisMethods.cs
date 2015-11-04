using log4net;

namespace Medicine.Clinic.DataAccess
{
    public class DiagnosisMethods : DbAccess
    {
        private static DiagnosisMethods instance;
        public static readonly ILog log = LogManager.GetLogger(typeof(DiagnosisMethods));

        public static DiagnosisMethods Instance
        {
            get
            {
                instance = instance ?? new DiagnosisMethods();
                return instance;
            }
        }

        private static string ValidateDiagnosis(Diagnosis diagnosis)
        {
            if (string.IsNullOrEmpty(diagnosis.Name))
            {
                return "Fill Name field!";
            }
            else 
            {
                return string.Empty;
            }
        }

        public string InsertDiagnosis(Diagnosis diagnosis)
        {
            string message = ValidateDiagnosis(diagnosis);
            if (string.IsNullOrEmpty(message))
            {
                bool isProcessDone = InsertEntity<Diagnosis>(diagnosis);
                if (isProcessDone)
                {
                    log.Info(string.Format("Diagnosis {0} saved", diagnosis.Code));
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

        public string UpdateDiagnosis(Diagnosis diagnosis)
        {
            string message = ValidateDiagnosis(diagnosis);
            if (string.IsNullOrEmpty(message))
            {
                bool isProcessDone = UpdateEntity<Diagnosis>(diagnosis);
                if (isProcessDone)
                {
                    log.Info(string.Format("Diagnosis {0} changed", diagnosis.Code));
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

        public Diagnosis[] GetDiagnoses(string code, string name)
        {
            return GetEntities<Diagnosis>(code, name);
        }

        public Diagnosis GetDiagnosisByCode(string code)
        {
            return GetEntityByCode<Diagnosis>(code);
        }                     
    }
}
