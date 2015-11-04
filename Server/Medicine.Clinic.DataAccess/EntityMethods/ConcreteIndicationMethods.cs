using log4net;

namespace Medicine.Clinic.DataAccess
{
    public class ConcreteIndicationMethods : DbAccess
    {
        private static ConcreteIndicationMethods instance;
        public static readonly ILog log = LogManager.GetLogger(typeof(ConcreteIndicationMethods));

        public static ConcreteIndicationMethods Instance
        {
            get
            {
                instance = instance ?? new ConcreteIndicationMethods();
                return instance;
            }
        }

        public string InsertConcreteIndication(ConcreteIndication concreteIndication)
        {
            concreteIndication.Code = GenerateConcreteIndicationNumber();
            var result = InsertEntity<ConcreteIndication>(concreteIndication);
            if (result)
            {
                log.Info(string.Format("Concrete Indication {0} saved", concreteIndication.Code));
                return concreteIndication.Code;
            }
            else
            {
                return string.Empty;
            }
        }

        public bool UpdateConcreteIndication(ConcreteIndication concreteIndication)
        {
            var result = UpdateEntity<ConcreteIndication>(concreteIndication);
            if (result)
            {
                log.Info(string.Format("Concrete Indication {0} changed", concreteIndication.Code));
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteConcreteIndication(ConcreteIndication indication)
        {
            indication.Id = ConcreteIndicationMethods.Instance.GetConcreteIndicationByCode(indication.Code).Id;
            var result = DeleteEntity<ConcreteIndication>(indication);
            if (result)
            {
                log.Info(string.Format("Concrete indication {0} deleted", indication.Code));
                return true;
            }
            else
            {
                return false;
            }
        }

        public ConcreteIndication[] GetAllConcreteIndications()
        {
            return GetAllEntities<ConcreteIndication>();
        }

        public ConcreteIndication[] GetConcreteIndicationsByOrder(string number)
        {
            return GetEntitiesByOrder<ConcreteIndication>(number);
        }

        public string GenerateConcreteIndicationNumber()
        {
            return GenerateEntityCode<ConcreteIndication>();
        }

        public ConcreteIndication GetConcreteIndicationByCode(string code)
        {
            return GetEntityByCode<ConcreteIndication>(code);
        }
    }
}
