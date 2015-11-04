using log4net;



namespace Medicine.Clinic.DataAccess
{
    public class SexMethods : DbAccess
    {
        private static SexMethods instance;
        public static readonly ILog log = LogManager.GetLogger(typeof(SexMethods));

        public static SexMethods Instance
        {
            get
            {
                instance = instance ?? new SexMethods();
                return instance;
            }
        }

        private static string ValidateSex(Sex sex) 
        {
            if (!string.IsNullOrEmpty(sex.Code) && !string.IsNullOrEmpty(sex.Name))
            {
                return string.Empty;
            }
            else 
            {
                return "Fill all fields!";
            }
        }

        public string InsertSex(Sex sex)
        {
            string message = ValidateSex(sex);
            if (string.IsNullOrEmpty(message))
            {
                bool isProcessDone = InsertEntity<Sex>(sex);
                if (isProcessDone)
                {
                    log.Info(string.Format("Sex {0} saved",sex.Code));
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

        public string UpdateSex(Sex sex)
        {
            string message = ValidateSex(sex);
            if (string.IsNullOrEmpty(message))
            {
                bool isProcessDone = UpdateEntity<Sex>(sex);
                if (isProcessDone)
                {
                    log.Info(string.Format("Sex {0} changed", sex.Code));
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

        public Sex[] GetSexes(string code, string name)
        {
            return GetEntities<Sex>(code, name);
        }

        public Sex GetSexById(int id)
        {
            return GetEntityById<Sex>(id);
        }

        public Sex GetSexByCode(string code)
        {
            return GetEntityByCode<Sex>(code);
        }
    }
}
