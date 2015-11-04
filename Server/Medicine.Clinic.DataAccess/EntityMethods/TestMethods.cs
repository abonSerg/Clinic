using System.Linq;
using NHibernate;
using NHibernate.Linq;
using log4net;

namespace Medicine.Clinic.DataAccess
{
    public class TestMethods : DbAccess
    {
        private static TestMethods instance;
        public static readonly ILog log = LogManager.GetLogger(typeof(TestMethods));

        public static TestMethods Instance
        {
            get
            {
                instance = instance ?? new TestMethods();
                return instance;
            }
        }

        private static string ValidateTest(Test test) 
        {
            if (!string.IsNullOrEmpty(test.Name) || !string.IsNullOrEmpty(test.DefaultSpecimen.Code))
            {
                if (!string.IsNullOrEmpty(test.DefaultSpecimen.Code))
                {
                    return string.Empty;
                }
                else 
                {
                    return "Choose default specimen!";
                }
            }
            else 
            {
                return "Fill all fields!";
            }
        }

        public string InsertTest(Test test)
        {
            string message = ValidateTest(test);
            if (string.IsNullOrEmpty(message))
            {
                test.DefaultSpecimen.Id = SpecimenMethods.Instance.GetSpecimenByCode(test.DefaultSpecimen.Code).Id;
                bool isProcessDone = InsertEntity<Test>(test);
                if (isProcessDone)
                {
                    log.Info(string.Format("Test {0} saved",test.Code));
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

        public string UpdateTest(Test test)
        {
            string message = ValidateTest(test);
            if (string.IsNullOrEmpty(message))
            {
                test.DefaultSpecimen.Id = SpecimenMethods.Instance.GetSpecimenByCode(test.DefaultSpecimen.Code).Id;
                bool isProcessDone = UpdateEntity<Test>(test);
                if (isProcessDone)
                {
                    log.Info(string.Format("Test {0} chaged", test.Code));
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

        public Test[] GetTests(string code, string name)
        {
            return GetEntities<Test>(code, name);
        }

        public Test[] GetTestsBySex(string sexCode)
        {
            ISession readSession = readSessionsFactory.OpenSession();
            return readSession.Query<Test>()
                              .Cacheable()
                              .Where(test => test.Code == sexCode)
                              .ToArray();
        }

        public Test GetTestByCode(string code)
        {
            return GetEntityByCode<Test>(code);
        }
    }
}
