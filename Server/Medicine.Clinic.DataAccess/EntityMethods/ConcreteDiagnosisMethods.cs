using log4net;

namespace Medicine.Clinic.DataAccess
{
    public class ConcreteDiagnosisMethods : DbAccess
    {
        private static ConcreteDiagnosisMethods instance;
        public static readonly ILog log = LogManager.GetLogger(typeof(ConcreteDiagnosisMethods));

        public static ConcreteDiagnosisMethods Instance
        {
            get
            {
                instance = instance ?? new ConcreteDiagnosisMethods();
                return instance;
            }
        }

        public string InsertConcreteDiagnosis(ConcreteDiagnosis diagnosis)
        {
            diagnosis.Code = ConcreteDiagnosisMethods.Instance.GenerateConcreteDiagnosisNumber();
            var result = InsertEntity<ConcreteDiagnosis>(diagnosis);
            if (result)
            {
                log.Info(string.Format("Concrete diagnosis {0} saved", diagnosis.Code));
                return diagnosis.Code;
            }
            else 
            {
                return string.Empty;
            }
        }

        public string UpdateConcreteDiagnosis(ConcreteDiagnosis diagnosis)
        {
            var result = UpdateEntity<ConcreteDiagnosis>(diagnosis);;
            if (result)
            {
                log.Info(string.Format("Concrete diagnosis {0} changed", diagnosis.Code));
                return diagnosis.Code;
            }
            else
            {
                return string.Empty;
            }
        }

        public ConcreteDiagnosis[] GetConcreteDiagnosesByOrder(string number)
        {
            return GetEntitiesByOrder<ConcreteDiagnosis>(number);
        }

        public string GenerateConcreteDiagnosisNumber()
        {
            return GenerateEntityCode<ConcreteDiagnosis>();
        }

        public ConcreteDiagnosis GetConcreteDiagnosisByCode(string code)
        {
            return GetEntityByCode<ConcreteDiagnosis>(code);
        }
     }
        
}
