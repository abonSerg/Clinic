using System.Linq;
using log4net;
using NHibernate;
using NHibernate.Linq;


namespace Medicine.Clinic.DataAccess
{
    public class OrderMethods : DbAccess
    {
        private static OrderMethods instance;
        public static readonly ILog log = LogManager.GetLogger(typeof(OrderMethods));

        public static OrderMethods Instance
        {
            get
            {
                instance = instance ?? new OrderMethods();
                return instance;
            }
        }

        public static string ValidateOrder(Order order) 
        {
            if (!string.IsNullOrEmpty(order.ClinicalInfo))
            {
                return string.Empty;
            }
            else
            {
                return "c";
            }
        }

        public string InsertOrder(Order order)
        {
            var message = ValidateOrder(order);
            if (string.IsNullOrEmpty(message))
            {
                bool isProcessDone = InsertEntity<Order>(order);
                if (isProcessDone)
                {
                    log.Info(string.Format("Order {0} saved", order.Number));
                    return "o";
                }
                else
                {
                    return "e";
                }
            }
            else 
            {
                return message;
            }
        }

        public string UpdateOrder(Order order)
        {
            var message = ValidateOrder(order);
            if (string.IsNullOrEmpty(message))
            {
                if (InterpretationMethods.Instance.GetInterpretationByOrder(order.Number).SignOutDt == null)
                {
                    bool isProcessDone = UpdateEntity<Order>(order);
                    if (isProcessDone)
                    {
                        log.Info(string.Format("Order {0} changed", order.Number));
                        return "o";
                    }
                    else
                    {
                        return "e";
                    }
                }
                else 
                {
                    return "s";
                }
            }
            else
            {
                return message;
            }
        }

        public Order[] GetOrders(string number, string billingNumber)
        {
            ISession session = writeSessionsFactory.OpenSession();
            return session.Query<Order>()
                          .Cacheable()
                          .Where(order => order.Number.Contains(number))
                          .Where(order => order.Number.Contains(billingNumber))
                          .ToArray();
        }

        public string GenerateConcreteOrderNumber()
        {
            return GenerateEntityCode<Order>();
        }

        public Order GetOrderByNumber(string number)
        {
            ISession readSession = readSessionsFactory.OpenSession();
            return readSession.Query<Order>()
                              .Cacheable()
                              .SingleOrDefault<Order>(order => order.Number == number);
        }

        public Order[] GetOrdersByVisit(string billingNumber)
        {
            ISession session = writeSessionsFactory.OpenSession();
            return session.Query<Order>()
                          .Cacheable()
                          .Where(order => order.Visit.BillingNumber == billingNumber)
                          .ToArray();
        }
    }
}
