using log4net;

namespace Medicine.Clinic.DataAccess
{
    public class IndicationMethods : DbAccess
    {
        private static IndicationMethods instance;
        public static readonly ILog log = LogManager.GetLogger(typeof(DoctorMethods));

        public static IndicationMethods Instance
        {
            get
            {
                instance = instance ?? new IndicationMethods();
                return instance;
            }
        }

        private static string ValidateIndication(Indication indication) 
        {
            if (!string.IsNullOrEmpty(indication.Name))
            {
                return string.Empty;
            }
            else
            {
                return "Fill Name field!";
            }

        }
        public string InsertIndication(Indication indication)
        {
            var message = ValidateIndication(indication);
            if (string.IsNullOrEmpty(message))
            {
                bool isProcessDone = InsertEntity<Indication>(indication);
                if (isProcessDone)
                {
                    log.Info(string.Format("Indication {0} saved", indication.Code));
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

        public string UpdateIndication(Indication indication)
        {
            var message = ValidateIndication(indication);
            if (string.IsNullOrEmpty(message))
            {
                bool isProcessDone = UpdateEntity<Indication>(indication);
                if (isProcessDone)
                {
                    log.Info(string.Format("Indication {0} changed", indication.Code));
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

        public Indication[] GetIndications(string code, string name)
        {
            return GetEntities<Indication>(code, name);
        }

        public Indication GetIndicationByCode(string code)
        {
            return GetEntityByCode<Indication>(code);
        }
    }
}
