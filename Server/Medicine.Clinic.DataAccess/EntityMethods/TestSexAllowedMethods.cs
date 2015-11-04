using System.Linq;
using NHibernate;
using NHibernate.Linq;
using log4net;

namespace Medicine.Clinic.DataAccess
{
    public class TestSexAllowedMethods : DbAccess
    {
        private static TestSexAllowedMethods instance;
        public static readonly ILog log = LogManager.GetLogger(typeof(TestSexAllowedMethods));

        public static TestSexAllowedMethods Instance
        {
            get
            {
                instance = instance ?? new TestSexAllowedMethods();
                return instance;
            }
        }

        public void InsertTestSexAllowed(TestSexAllowed testSexAllowed)
        {
            var result = InsertEntity<TestSexAllowed>(testSexAllowed);
            if (result) 
            {
               log.Info(string.Format("Test {0} to Sex {1} alloweded", testSexAllowed.Test.Id, testSexAllowed.Sex.Id)); 
            }
        }

        public void DeleteTestSexAllowed(TestSexAllowed testSexAllowed)
        {
            DeleteEntity<TestSexAllowed>(testSexAllowed);
        }

        public TestSexAllowed[] GetTestSexAllowedByTestId(string testCode)
        {
            ISession session = writeSessionsFactory.OpenSession();
            return session.Query<TestSexAllowed>()
                          .Cacheable()
                          .Where(testSex => testSex.Test.Code == testCode)                                                     
                          .ToArray();
        }

        public TestSexAllowed[] GetTestSexAllowedBySex(string sexCode)
        {
            ISession session = writeSessionsFactory.OpenSession();
            return session.Query<TestSexAllowed>()
                          .Cacheable()
                          .Where(testSex => testSex.Sex.Code ==sexCode)
                          .ToArray();
        }
    }
}
