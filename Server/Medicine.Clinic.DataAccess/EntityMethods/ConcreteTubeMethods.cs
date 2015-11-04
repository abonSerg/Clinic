using log4net;

namespace Medicine.Clinic.DataAccess
{
    public class ConcreteTubeMethods : DbAccess
    {
        private static ConcreteTubeMethods instance;
        public static readonly ILog log = LogManager.GetLogger(typeof(ConcreteTubeMethods));

        public static ConcreteTubeMethods Instance
        {
            get
            {
                instance = instance ?? new ConcreteTubeMethods();
                return instance;
            }
        }

        public string InsertConcreteTube(ConcreteTube tube)
        {
            tube.Code = GenerateConcreteTubeNumber();
            var result = InsertEntity<ConcreteTube>(tube);
            if (result)
            {
                log.Info(string.Format("Concrete tube {0} saved", tube.Code));
                return tube.Code;
            }
            else
            {
                return string.Empty;
            }
        }

        public bool UpdateConcreteTube(ConcreteTube tube)
        {
            var result = UpdateEntity<ConcreteTube>(tube);
            if (result)
            {
                log.Info(string.Format("Concrete tube {0} saved", tube.Code));
                return true;
            }
            else 
            {
                return false;
            }
        }

        public bool DeleteConcreteTube(ConcreteTube tube)
        {
            tube.Id = ConcreteTubeMethods.Instance.GetConcreteTubeByCode(tube.Code).Id;
            var result = DeleteEntity<ConcreteTube>(tube);
            if (result)
            {
                log.Info(string.Format("Concrete tube {0} deleted", tube.Code));
                return true;
            }
            else
            {
                return false;
            }
        }

        public ConcreteTube[] GetConcreteTubesByOrder(string number)
        {
            return GetEntitiesByOrder<ConcreteTube>(number);
        }

        public ConcreteTube GetConcreteTubeId(int id)
        {
            return GetEntityById<ConcreteTube>(id);
        }

        public string GenerateConcreteTubeNumber()
        {
            return GenerateEntityCode<ConcreteTube>();
        }

        public ConcreteTube GetConcreteTubeByCode(string code)
        {
            return GetEntityByCode<ConcreteTube>(code);
        }
    }
}
