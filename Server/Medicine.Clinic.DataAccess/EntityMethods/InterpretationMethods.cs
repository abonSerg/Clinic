using System.Linq;
using NHibernate;
using NHibernate.Linq;
using log4net;

namespace Medicine.Clinic.DataAccess
{
    public class InterpretationMethods : DbAccess
    {
        private static InterpretationMethods instance;
        public static readonly ILog log = LogManager.GetLogger(typeof(InterpretationMethods));

        public static InterpretationMethods Instance
        {
            get
            {
                instance = instance ?? new InterpretationMethods();
                return instance;
            }
        }

        public string InsertInterpretation(Interpretation interpretation)
        {
            bool isProcessDone = InsertEntity<Interpretation>(interpretation);
            if (isProcessDone)
            {
                log.Info(string.Format("Interpretation to Order {0} saved", interpretation.Order.Id));
                return string.Empty;
            }
            else
            {
                return "Interpertation is exist for this ORDER!";
            }
        }

        public string UpdateInterpretation(Interpretation interpretation)
        {
            bool isProcessDone = UpdateEntity<Interpretation>(interpretation);
            if (isProcessDone)
            {
                log.Info(string.Format("Interpretation to Order {0} changed", interpretation.Order.Id));
                return string.Empty;
            }
            else
            {
                return "Interpertation is exist for this ORDER!";
            }
        }

        public Interpretation[] GetAllInterpretations()
        {
            return GetAllEntities<Interpretation>();
        }

        public Interpretation GetInterpretationByOrder(string orderNumber) 
        {
            ISession readSession = readSessionsFactory.OpenSession();
            return readSession.Query<Interpretation>()
                              .Cacheable()
                              .SingleOrDefault<Interpretation>(interpretation => interpretation.Order.Number == orderNumber);
        }
    }
}
