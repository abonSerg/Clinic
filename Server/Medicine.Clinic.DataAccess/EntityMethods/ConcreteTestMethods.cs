using System.Linq;
using NHibernate;
using NHibernate.Linq;
using log4net;

namespace Medicine.Clinic.DataAccess
{
    public class ConcreteTestMethods : DbAccess
    {
        private static ConcreteTestMethods instance;
        public static readonly ILog log = LogManager.GetLogger(typeof(ConcreteTestMethods));

        public static ConcreteTestMethods Instance
        {
            get
            {
                instance = instance ?? new ConcreteTestMethods();
                return instance;
            }
        }

        public string InsertConcreteTest(ConcreteTest test)
        {
            test.Code = GenerateConcreteTestNumber();           
            var result = InsertEntity<ConcreteTest>(test);
            if (result)
            {
                log.Info(string.Format("Concrete test {0} saved",test.Code));
                return test.Code;
            }
            else 
            {
                return string.Empty;
            }
        }

        public bool UpdateConcreteTest(ConcreteTest test)
        {
           var result = UpdateEntity<ConcreteTest>(test);
           if (result)
           {
               log.Info(string.Format("Concrete test {0} changed", test.Code));
               return true;
           }
           else 
           {
               return false;
           }
        }

        public bool DeleteConcreteTest(ConcreteTest test)
        {
            test.Id = ConcreteTestMethods.Instance.GetConcreteTestByCode(test.Code).Id;
            var result = DeleteEntity<ConcreteTest>(test);
            if (result)
            {
                log.Info(string.Format("Concrete test {0} deleted", test.Code));
                return true;
            }
            else
            {
                return false;
            }
        }
       
        public ConcreteTest[] GetConcreteTestsByOrder(string number)
        {
            return GetEntitiesByOrder<ConcreteTest>(number);
        }

        public string GenerateConcreteTestNumber()
        {
            return GenerateEntityCode<ConcreteTest>();
        }

        public ConcreteTest GetConcreteTestByCode(string code)
        {
            return GetEntityByCode<ConcreteTest>(code);
        }

        public ConcreteTest[] GetConcreteTestsByVisit(string billingNumber)
        {
            ISession session = writeSessionsFactory.OpenSession();
            return session.Query<ConcreteTest>()
                          .Cacheable()
                          .Where(test => test.Order.Visit.BillingNumber == billingNumber)
                          .ToArray();
        }
    }
}
