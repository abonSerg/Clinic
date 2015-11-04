using System.Linq;
using System.Text;
using Medicine.Clinic.DataAccess;

namespace Medicine.Clinic.Service
{
    
    public class OrderService : IOrderService
    {
        public string EditOrder(DtoOrder dtoOrder)
        {
            var visit = VisitMethods.Instance.GetVisitByBillingNumber(dtoOrder.Visit.BillingNumber);
            var uniqueOrder = OrderMethods.Instance.GetOrderByNumber(dtoOrder.Number);
            if (PatientMethods.Instance.GetPatientById(visit.Patient.Id).Dod == null)
            {
                if (uniqueOrder == null)
                {
                    var order = new Order()
                    {
                        Number = dtoOrder.Number,
                        Visit = new Visit()
                        {
                            Id = visit.Id
                        },
                        ClinicalInfo = dtoOrder.ClinicalInfo
                    };
                    return OrderMethods.Instance.InsertOrder(order);
                }
                else
                {
                    Order order = new Order()
                    {
                        Number = dtoOrder.Number,
                        Id = uniqueOrder.Id,
                        ClinicalInfo = dtoOrder.ClinicalInfo,
                        Visit = new Visit()
                        {
                            Id = visit.Id
                        }
                    };
                    return OrderMethods.Instance.UpdateOrder(order);
                }
            }
            else 
            {
                return "d";
            }
        }

        public DtoOrder[] FindOrders(DtoOrder dtoOrder)
        {
            Order[] orders = OrderMethods.Instance.GetOrders(dtoOrder.Number, dtoOrder.Visit.BillingNumber);
            DtoOrder[] dtoOrders = orders.Select(order => new DtoOrder()
            {
                Id = order.Id,
                Number = order.Number,
                Visit = new DtoVisit()
                {
                    Id = order.Visit.Id,
                    BillingNumber = order.Visit.BillingNumber,
                    Patient = new DtoPatient() 
                    {
                        Id = order.Visit.Patient.Id,
                        FirstName = order.Visit.Patient.FirstName,
                        LastName = order.Visit.Patient.LastName
                    }
                },
                ClinicalInfo = order.ClinicalInfo,
            }).ToArray();
            return dtoOrders;

        }

        public DtoConcreteTest[] FindConcreteTestsByOrder(string number) 
        {
            ConcreteTest[] tests = ConcreteTestMethods.Instance.GetConcreteTestsByOrder(number);
            DtoConcreteTest[] dtoTests = tests.Select(test => new DtoConcreteTest()
            {
                Code = test.Code,
                Order = new DtoOrder() 
                {
                    Number = test.Order.Number
                },
                Test = new DtoTest() 
                {
                    Code = test.Test.Code
                }
            }).ToArray();
            return dtoTests;
        }

        public DtoConcreteSpecimen[] FindConcreteSpecimensByOrder(string number)
        {
            ConcreteSpecimen[] specimens = ConcreteSpecimenMethods.Instance.GetConcreteSpecimensByOrder(number);
            DtoConcreteSpecimen[] dtoSpecimens = specimens.Select(specimen => new DtoConcreteSpecimen()
            {
                Code = specimen.Code,
                Order = new DtoOrder() 
                {
                    Id = specimen.Order.Id
                },
                Specimen = new DtoSpecimen()
                { 
                    Code = specimen.Specimen.Code
                },
                CollectedDt = specimen.CollectedDt,
                Volume = specimen.Volume
            }).ToArray();
            return dtoSpecimens;
        }

        public DtoConcreteTube[] FindConcreteTubesByOrder(string number)
        {
            ConcreteTube[] tubes = ConcreteTubeMethods.Instance.GetConcreteTubesByOrder(number);
            DtoConcreteTube[] dtoTubes = tubes.Select(tube => new DtoConcreteTube()
            {
                Code = tube.Code,
                Order = new DtoOrder() 
                {
                    Number = tube.Order.Number
                },
                Tube = new DtoTube()
                {
                    Code = tube.Tube.Code 
                },
                ReceivedDt = tube.ReceivedDt,
            }).ToArray();
            return dtoTubes;
        }

        public DtoConcreteIndication[] FindConcreteIndicationsByOrder(string number)
        {
            ConcreteIndication[] indications = ConcreteIndicationMethods.Instance.GetConcreteIndicationsByOrder(number);
            DtoConcreteIndication[] dtoIndications = indications.Select(indication => new DtoConcreteIndication()
            {
                Code = indication.Code,
                Order = new DtoOrder()
                {
                    Id = indication.Order.Id
                },
                Indication = new DtoIndication()
                {
                    Code = indication.Indication.Code
                }
            }).ToArray();
            return dtoIndications;
        }


        public string AddTestSexAllowed(DtoTestSexAllowed dtoTestSexAllowed)
        {
            var testSexAllowed = new TestSexAllowed()
            {
                Test = new Test() 
                {
                    Id = dtoTestSexAllowed.Test.Id
                },
                Sex = new Sex()
                {
                    Id =dtoTestSexAllowed.Sex.Id
                }
            };
             TestSexAllowedMethods.Instance.InsertTestSexAllowed(testSexAllowed);
             return string.Empty;
        }

        public DtoTestSexAllowed[] SearchTestSexAllowedsByTest(string testCode) 
        {
            TestSexAllowed[] testSexAlloweds = TestSexAllowedMethods.Instance.GetTestSexAllowedByTestId(testCode);
            DtoTestSexAllowed[] dtoTestSexAlloweds = testSexAlloweds.Select(testSex => new DtoTestSexAllowed()
            {
                Id = testSex.Id,
                Sex = new DtoSex() 
                {
                    Id = testSex.Sex.Id,
                    Code = testSex.Sex.Code
                },
                Test = new DtoTest()
                {
                   Id = testSex.Test.Id,
                }
            }).ToArray();
            return dtoTestSexAlloweds;
        }

        public string DeleteTestSexAllowed(DtoTestSexAllowed dtoTestSexAllowed)
        {
            var testSexAllowed = new TestSexAllowed()
            {
                Id = dtoTestSexAllowed.Id
            };

            TestSexAllowedMethods.Instance.DeleteTestSexAllowed(testSexAllowed);
            return string.Empty;
        }

        public string AddConcreteTest(DtoConcreteTest dtoConcreteTest)
        {
            var concreteTest = new ConcreteTest()
                {
                    Order = new Order
                    {
                        Id = OrderMethods.Instance.GetOrderByNumber(dtoConcreteTest.Order.Number).Id
                    },
                    Test = new Test()
                    {
                        Id = TestMethods.Instance.GetTestByCode(dtoConcreteTest.Test.Code).Id
                    }
                };
             return   ConcreteTestMethods.Instance.InsertConcreteTest(concreteTest);
        }

        public bool EditConcreteTest(DtoConcreteTest dtoConcreteTest)
        {
            var concreteTest = new ConcreteTest()
            {
                Id = ConcreteTestMethods.Instance.GetConcreteTestByCode(dtoConcreteTest.Code).Id,
                Code = dtoConcreteTest.Code,
                Test = new Test()
                {
                    Id = TestMethods.Instance.GetTestByCode(dtoConcreteTest.Test.Code).Id,
                },
                Order = new Order() 
                {
                    Id = ConcreteTestMethods.Instance.GetConcreteTestByCode(dtoConcreteTest.Code).Order.Id,
                }
            };
            return ConcreteTestMethods.Instance.UpdateConcreteTest(concreteTest);
        }

        public string AddConcreteTube(DtoConcreteTube dtoConcreteTube)
        {
            var concreteTube = new ConcreteTube()
            {
                Order = new Order
                {
                    Id = OrderMethods.Instance.GetOrderByNumber(dtoConcreteTube.Order.Number).Id
                },
                Tube = new Tube()
                {
                    Id = TubeMethods.Instance.GetTubeByCode(dtoConcreteTube.Tube.Code).Id
                },
                ReceivedDt = dtoConcreteTube.ReceivedDt
            };
            return ConcreteTubeMethods.Instance.InsertConcreteTube(concreteTube);
        }

        public bool EditConcreteTube(DtoConcreteTube dtoConcreteTube)
        {
            var concreteTube = new ConcreteTube()
            {
                Id = ConcreteTubeMethods.Instance.GetConcreteTubeByCode(dtoConcreteTube.Code).Id,
                Code = dtoConcreteTube.Code,
                Tube = new Tube()
                {
                    Id = TubeMethods.Instance.GetTubeByCode(dtoConcreteTube.Tube.Code).Id
                },
                Order = new Order()
                {
                    Id = ConcreteTubeMethods.Instance.GetConcreteTubeByCode(dtoConcreteTube.Code).Order.Id
                },
                ReceivedDt = dtoConcreteTube.ReceivedDt,
            };
            return ConcreteTubeMethods.Instance.UpdateConcreteTube(concreteTube);
        }

        public string AddConcreteSpecimen(DtoConcreteSpecimen dtoConcreteSpecimen)
        {
            var concreteSpecimen = new ConcreteSpecimen()
            {
                Order = new Order
                {
                    Id = OrderMethods.Instance.GetOrderByNumber(dtoConcreteSpecimen.Order.Number).Id
                },
                Specimen = new Specimen()
                {
                    Id = SpecimenMethods.Instance.GetSpecimenByCode(dtoConcreteSpecimen.Specimen.Code).Id
                },
                Volume = dtoConcreteSpecimen.Volume,
                CollectedDt = dtoConcreteSpecimen.CollectedDt
            };
            return ConcreteSpecimenMethods.Instance.InsertConcreteSpecimen(concreteSpecimen);
        }

        public bool EditConcreteSpecimen(DtoConcreteSpecimen dtoConcreteSpecimen)
        {
            var concreteSpecimen = new ConcreteSpecimen()
            {
             
                Id = ConcreteSpecimenMethods.Instance.GetConcreteSpecimenByCode(dtoConcreteSpecimen.Code).Id,
                Code = dtoConcreteSpecimen.Code,
                Specimen = new Specimen()
                {
                    Id = SpecimenMethods.Instance.GetSpecimenByCode(dtoConcreteSpecimen.Specimen.Code).Id
                },
                Order = new Order()
                {
                    Id = ConcreteSpecimenMethods.Instance.GetConcreteSpecimenByCode(dtoConcreteSpecimen.Code).Order.Id
                },
                Volume = dtoConcreteSpecimen.Volume,
                CollectedDt = dtoConcreteSpecimen.CollectedDt
            };
            return ConcreteSpecimenMethods.Instance.UpdateConcreteSpecimen(concreteSpecimen);
        }

        public string GetOrderNumber() 
        {
            return OrderMethods.Instance.GenerateConcreteOrderNumber();
        }

        public void AddTestTubeAttach(DtoTestTubeAttach dtoTestTubeAttach) 
        {
            var testTubeAttach = new TestTubeAttach()
            {
                ConcreteTest = new ConcreteTest()
                {
                    Id = dtoTestTubeAttach.DtoConcreteTest.Id
                },
                ConcreteTube = new ConcreteTube()
                {
                    Id = dtoTestTubeAttach.DtoConctereTube.Id
                }
            };
            TestTubeAttachMethods.Instance.InsertTestTubeAttach(testTubeAttach);
        }

        public void DeleteTestTubeAttach(string orderNumber)
        {
            TestTubeAttach[] testTubeAttaches = TestTubeAttachMethods.Instance.GetTestTubeAttachesByOrder(orderNumber);
            foreach (var testTube in testTubeAttaches) 
            {
                TestTubeAttach testTubeAttach = new TestTubeAttach()
                {
                    Id = testTube.Id
                };
                TestTubeAttachMethods.Instance.DeleteTestTubeAttach(testTubeAttach);
            }
        }

        public void DeleteSpecimenTubeAttach(string orderNumber)
        {
            SpecimenTubeAttach[] specimenTubeAttaches = SpecimenTubeAttachMethods.Instance.GetSpecimenTubeAttachesByOrder(orderNumber);
            foreach (var testTube in specimenTubeAttaches)
            {
                var specimenTubeAttach = new SpecimenTubeAttach()
                {
                    Id = testTube.Id
                };
                SpecimenTubeAttachMethods.Instance.DeleteSpecimenTubeAttach(specimenTubeAttach);
            }
        }

        public void AddSpecimenTubeAttach(DtoSpecimenTubeAttach dtoSpecimenTubeAttach)
        {
            var specimenTubeAttach = new SpecimenTubeAttach()
            {
                ConcreteSpecimen = new ConcreteSpecimen()
                {
                    Id = dtoSpecimenTubeAttach.ConcreteSpecimen.Id
                },
                ConcreteTube = new ConcreteTube() 
                {
                    Id = dtoSpecimenTubeAttach.ConcreteTube.Id
                }
            };
            SpecimenTubeAttachMethods.Instance.InsertSpecimenTubeAttach(specimenTubeAttach);
        }

        public DtoConcreteTest GetConcreteTestByCode(string code) 
        {
            var concreteTest =  ConcreteTestMethods.Instance.GetConcreteTestByCode(code);
            var dtoConcreteTest = new DtoConcreteTest()
            {
                Id = concreteTest.Id,
            };
            return dtoConcreteTest;
        }

        public DtoConcreteTube GetConcreteTubeByCode(string code)
        {
            var concreteTube = ConcreteTubeMethods.Instance.GetConcreteTubeByCode(code);
            var dtoConcreteTube = new DtoConcreteTube()
            {
                Id = concreteTube.Id,
            };
            return dtoConcreteTube;
        }

        public DtoConcreteSpecimen GetConcreteSpecimenByCode(string code)
        {
            var concreteSpecimen = ConcreteSpecimenMethods.Instance.GetConcreteSpecimenByCode(code);
            var dtoConcreteSpecimen = new DtoConcreteSpecimen()
            {
                Id = concreteSpecimen.Id,
            };
            return dtoConcreteSpecimen;
        }

        public string AddConcreteIndication(DtoConcreteIndication dtoConcreteIndication)
        {
            var concreteIndication = new ConcreteIndication()
            {
                Order = new Order()
                {
                    Id = OrderMethods.Instance.GetOrderByNumber(dtoConcreteIndication.Order.Number).Id
                },
                Indication = new Indication() 
                {
                    Id = IndicationMethods.Instance.GetIndicationByCode(dtoConcreteIndication.Indication.Code).Id
                }
            };
            return ConcreteIndicationMethods.Instance.InsertConcreteIndication(concreteIndication);
        }

        public bool EditConcreteIndication(DtoConcreteIndication dtoConcreteIndication)
        {
            var concreteIndication = new ConcreteIndication()
            {
                Id = ConcreteIndicationMethods.Instance.GetConcreteIndicationByCode(dtoConcreteIndication.Code).Id,
                Code = dtoConcreteIndication.Code,
                Indication = new Indication()
                {
                    Id = IndicationMethods.Instance.GetIndicationByCode(dtoConcreteIndication.Indication.Code).Id
                },
                Order = new Order()
                {
                    Id = ConcreteIndicationMethods.Instance.GetConcreteIndicationByCode(dtoConcreteIndication.Code).Order.Id
                }
            };
            return ConcreteIndicationMethods.Instance.UpdateConcreteIndication(concreteIndication);
        }

        public string GetTestTubeAttachesStringByTube(string concreteTubeCode)
        {
            TestTubeAttach[] testTubeAttaches = TestTubeAttachMethods.Instance.GetTestTubeAttachesByTube(concreteTubeCode);
            StringBuilder builder = new StringBuilder();
            int i = 0;
            foreach (var testTubeAttach in testTubeAttaches)
            {
                if (i == 0)
                {
                    builder.Append(testTubeAttach.ConcreteTest.Test.Code);
                }
                else
                {
                    builder.Append(", " + testTubeAttach.ConcreteTest.Test.Code);
                }
                i++;
            }
            return builder.ToString();
        }

        public DtoSpecimenTubeAttach[] GetSpecimenTubeAttachesBySpecimen(string concreteSpecimenCode)
        {
            SpecimenTubeAttach[] specimenTubeAttaches = SpecimenTubeAttachMethods.Instance.GetSpecimenTubeAttachesBySpecimen(concreteSpecimenCode);
            DtoSpecimenTubeAttach[] dtoSpecimenTubeAttaches = specimenTubeAttaches.Select(specimenTube => new DtoSpecimenTubeAttach()
            {
                ConcreteTube = new DtoConcreteTube()
                {
                    Code = specimenTube.ConcreteTube.Code
                }

            }).ToArray();
            return dtoSpecimenTubeAttaches;
        }

        public DtoOrder[] GetOrdersByVisit(string billingNumber)
        {
            Order[] orders = OrderMethods.Instance.GetOrdersByVisit(billingNumber);
            DtoOrder[] dtoOrders = orders.Select(order => new DtoOrder()
            {
                Number = order.Number,
            }).ToArray();
            return dtoOrders;
        }

        public void DeleteConcreteTest(string code) 
        {
            var concreteTest = new ConcreteTest()
            {
                Code = code
            };
            ConcreteTestMethods.Instance.DeleteConcreteTest(concreteTest);
        }

        public void DeleteConcreteSpecimen(string code)
        {
            var concreteSpecimen = new ConcreteSpecimen()
            {
                Code = code
            };
            ConcreteSpecimenMethods.Instance.DeleteConcreteSpecimen(concreteSpecimen);
        }

        public void DeleteConcreteTube(string code)
        {
            var concreteTube = new ConcreteTube()
            {
                Code = code
            };
            ConcreteTubeMethods.Instance.DeleteConcreteTube(concreteTube);
        }

        public void DeleteConcreteIndication(string code)
        {
            var concreteIndication = new ConcreteIndication()
            {
                Code = code
            };
            ConcreteIndicationMethods.Instance.DeleteConcreteIndication(concreteIndication);
        }
    }

}
