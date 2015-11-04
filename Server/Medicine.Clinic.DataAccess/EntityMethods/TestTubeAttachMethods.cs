using System.Linq;
using log4net;
using NHibernate;
using NHibernate.Linq;

namespace Medicine.Clinic.DataAccess
{
    public class TestTubeAttachMethods : DbAccess
    {
        private static TestTubeAttachMethods instance;
        public static readonly ILog log = LogManager.GetLogger(typeof(TestTubeAttachMethods));

        public static TestTubeAttachMethods Instance
        {
            get
            {
                instance = instance ?? new TestTubeAttachMethods();
                return instance;
            }
        }

        public void InsertTestTubeAttach(TestTubeAttach testTubeAttach)
        {
            var result = InsertEntity<TestTubeAttach>(testTubeAttach);
            if (result) 
            {
                log.Info(string.Format("Test {0} to Tube {1} attached", testTubeAttach.ConcreteTest.Id, testTubeAttach.ConcreteTube.Id)); 
            }
        }

        public void DeleteTestTubeAttach(TestTubeAttach testTubeAttach)
        {
            DeleteEntity<TestTubeAttach>(testTubeAttach);
        }

        public TestTubeAttach[] GetTestTubeAttachesByTube(string concreteTubeCode)
        {
            ISession session = writeSessionsFactory.OpenSession();
            return session.Query<TestTubeAttach>()
                          .Cacheable()
                          .Where(testTube => testTube.ConcreteTube.Code == concreteTubeCode)
                          .ToArray();
        }

        public TestTubeAttach[] GetTestTubeAttachesByOrder(string orderNumdber)
        {
            ISession session = writeSessionsFactory.OpenSession();
            return session.Query<TestTubeAttach>()
                          .Cacheable()
                          .Where(testTube => testTube.ConcreteTest.Order.Number == orderNumdber)
                          .ToArray();
        }
    }
}
