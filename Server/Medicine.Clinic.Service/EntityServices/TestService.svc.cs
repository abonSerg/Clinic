using System.ComponentModel;
using System.Linq;
using Medicine.Clinic.DataAccess;

namespace Medicine.Clinic.Service
{
    public class TestService : ITestService
    {
        public DtoTest[] FindTests(DtoTest dtoTest)
        {
            Test[] tests = TestMethods.Instance.GetTests(dtoTest.Code, dtoTest.Name);
            DtoTest[] dtoTests = tests.Select(test => new DtoTest()
                                                    {
                                                        Id = test.Id,
                                                        Code = test.Code,
                                                        Name = test.Name,
                                                        Cost = test.Cost,
                                                        DefaultSpecimen = new DtoSpecimen()
                                                        {
                                                            Code = test.DefaultSpecimen.Code,
                                                            Name = test.DefaultSpecimen.Name
                                                        }
                                                    }).ToArray();
            return dtoTests;
        }

        public string EditTest(DtoTest dtoTest)
        {
            var uniqueTest = TestMethods.Instance.GetTestByCode(dtoTest.Code);
            if (!dtoTest.IsEdit)
            {
                Test test = new Test()
                {
                    Code = dtoTest.Code,
                    Name = dtoTest.Name,
                    DefaultSpecimen = new Specimen()
                    {
                        Code = dtoTest.DefaultSpecimen.Code
                    },
                    Cost = dtoTest.Cost
                };
                return TestMethods.Instance.InsertTest(test);
            }
            else 
            {
                var test = new Test()
                {
                    Id = uniqueTest.Id,
                    Code = dtoTest.Code,
                    Name = dtoTest.Name,
                    DefaultSpecimen = new Specimen()
                    {
                        Code = dtoTest.DefaultSpecimen.Code
                    }
                };
                return TestMethods.Instance.UpdateTest(test);
            }
        }

        public DtoTest GetTestByCode(string code) 
        {
            Test test = TestMethods.Instance.GetTestByCode(code);
            var dtoTest = new DtoTest()
            {
                Id = test.Id,
                Code = test.Code,
                DefaultSpecimen = new DtoSpecimen()
                {
                    Id = test.DefaultSpecimen.Id,
                    Code = test.DefaultSpecimen.Code,
                    DefaultTube = new DtoTube()
                    {
                        Id = test.DefaultSpecimen.DefaultTube.Id,
                        Code = test.DefaultSpecimen.DefaultTube.Code
                    }     
                }
            };
            return dtoTest;
        }


        public DtoTest[] GetTestsByVisit(string billingNumber) 
        {
            string sexCode = VisitMethods.Instance.GetVisitByBillingNumber(billingNumber).Patient.Sex.Code;
            TestSexAllowed[] testSexAlloweds = TestSexAllowedMethods.Instance.GetTestSexAllowedBySex(sexCode);
            var testInstance = new Test()
            {
                Code = string.Empty,
                Name = string.Empty
            };
            Test[] tests = TestMethods.Instance.GetTests(testInstance.Code, testInstance.Name);
            var query = from testSexAllowed in testSexAlloweds
                        join test in tests
                        on testSexAllowed.Test.Id equals test.Id
                        select new DtoTest()
                        {
                            Id = test.Id,
                            Code = test.Code,
                            Name = test.Name,
                            Cost = test.Cost,
                            DefaultSpecimen = new DtoSpecimen() 
                            {
                                Id= test.DefaultSpecimen.Id,
                                Code = test.DefaultSpecimen.Code
                            }
                        };
            var testsBySex = new BindingList<DtoTest>();
            foreach (var testBySex in query)
            {
                testsBySex.Add(testBySex);
            }
            return testsBySex.ToArray<DtoTest>();
        }

        public DtoConcreteTest[] GetConcreteTestsByVisit(string billingNumber)
        {
            ConcreteTest[] concreteTests = ConcreteTestMethods.Instance.GetConcreteTestsByVisit(billingNumber);

            DtoConcreteTest[] dtoConcreteTests = concreteTests.Select(concreteTest => new DtoConcreteTest()
            {
                Code = concreteTest.Code,
                Test = new DtoTest() 
                {
                    Name = concreteTest.Test.Name
                }

            }).ToArray();
            return dtoConcreteTests;
        }

        public double GetTestsCostByVisit(string billingNumber)
        {
            ConcreteTest[] tests = ConcreteTestMethods.Instance.GetConcreteTestsByVisit(billingNumber);
            double totalCost = 0;
            foreach (var test in tests)
            {
                totalCost += test.Test.Cost;
            }
            return totalCost;
        }
    }
}
