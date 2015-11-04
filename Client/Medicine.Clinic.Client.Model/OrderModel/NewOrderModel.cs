using System;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Medicine.Clinic.Client.Model.GridControlsEntities;
using Medicine.Clinic.Client.Model.IndicationService;
using Medicine.Clinic.Client.Model.OrderService;
using Medicine.Clinic.Client.Model.PatientService;
using Medicine.Clinic.Client.Model.SpecimenService;
using Medicine.Clinic.Client.Model.TestService;
using Medicine.Clinic.Client.Model.TubeService;
using DtoConcreteTest1 = Medicine.Clinic.Client.Model.OrderService.DtoConcreteTest;
using DtoTest1 = Medicine.Clinic.Client.Model.TestService.DtoTest;
using DtoSpecimen1 = Medicine.Clinic.Client.Model.SpecimenService.DtoSpecimen;
using DtoTube1 = Medicine.Clinic.Client.Model.TubeService.DtoTube;
using DtoIndication1 = Medicine.Clinic.Client.Model.IndicationService.DtoIndication;
using DtoOrder1 = Medicine.Clinic.Client.Model.OrderService.DtoOrder;
using DtoTest2 = Medicine.Clinic.Client.Model.OrderService.DtoTest;
using DtoSpecimen2 = Medicine.Clinic.Client.Model.OrderService.DtoSpecimen;
using DtoVisit1 = Medicine.Clinic.Client.Model.OrderService.DtoVisit;
using DtoTube2 = Medicine.Clinic.Client.Model.OrderService.DtoTube;
using DtoIndication2 = Medicine.Clinic.Client.Model.OrderService.DtoIndication;
using System.Collections.Generic;

namespace Medicine.Clinic.Client.Model
{  
    public class NewOrderModel : INewOrderModel, INewOrderEditModel
    {

        private OrderServiceClient orderService;

        private OrderServiceClient OrderService
        {
            get
            {
                orderService = orderService ?? new OrderServiceClient();
                return orderService;
            }
        }


        public BindingList<TestForGrid> SearchConcreteTests(string number)
        {
            if (string.IsNullOrEmpty(number))
            {
                return new BindingList<TestForGrid>();
            }
            else 
            {
                var listForGrid = new BindingList<TestForGrid>();
                foreach (var item in new BindingList<DtoConcreteTest1>(OrderService.FindConcreteTestsByOrder(number)))
                {
                    var test = new TestForGrid() 
                    {
                        Code = item.Test.Code,
                        ConcreteCode = item.Code
                    };
                    listForGrid.Add(test);
                }
                return listForGrid;
            }
        }

        public BindingList<TubeForGrid> SearchConcreteTubes(string number)
        {
            if (string.IsNullOrEmpty(number))
            {
                return new BindingList<TubeForGrid>();
            }
            else
            {
                var listForGrid = new BindingList<TubeForGrid>();
                foreach (var concreteTube in new BindingList<DtoConcreteTube>(OrderService.FindConcreteTubesByOrder(number)))
                {
                    var tube = new TubeForGrid()
                    {
                        Code = concreteTube.Tube.Code,
                        ConcreteCode = concreteTube.Code,
                        ReceivedDt = concreteTube.ReceivedDt,
                        Tests = OrderService.GetTestTubeAttachesStringByTube(concreteTube.Code)
                    };
                    listForGrid.Add(tube);
                }
                return listForGrid;
            }

        }

        public BindingList<SpecimenForGrid> SearchConcreteSpecimens(string number, BindingList<TubeForGrid> tubeGrids )
        {
            if (string.IsNullOrEmpty(number))
            {  
                 return  new BindingList<SpecimenForGrid>();
            }
            else 
            {
                var listForGrid = new BindingList<SpecimenForGrid>();
                foreach (var concreteSpecimen in new BindingList<DtoConcreteSpecimen>(OrderService.FindConcreteSpecimensByOrder(number)))
                {
                    var specimenTubeAttaches = new BindingList<DtoSpecimenTubeAttach>(OrderService.GetSpecimenTubeAttachesBySpecimen(concreteSpecimen.Code));
                    var query = from tubeGrid in tubeGrids
                                join specimenTube in specimenTubeAttaches
                                on tubeGrid.ConcreteCode equals specimenTube.ConcreteTube.Code
                                select tubeGrid.Id;
                    StringBuilder builder = new StringBuilder();
                    bool isLastCode = true;
                    foreach (var tubeString in query)
                    {
                        if (isLastCode)
                        {
                            builder.Append(tubeString);
                        }
                        else
                        {
                            builder.Append(", " + tubeString);
                        }
                        isLastCode = false;
                    }

                    var specimen = new SpecimenForGrid()
                    {
                        Code = concreteSpecimen.Specimen.Code,
                        ConcreteCode = concreteSpecimen.Code,
                        CollectedDt = concreteSpecimen.CollectedDt,
                        Volume = concreteSpecimen.Volume,
                        Tubes = builder.ToString()
                    };
                    listForGrid.Add(specimen);
                }
                return listForGrid;
            }
        }

        public BindingList<IndicationForGrid> SearchConcreteIndications(string number)
        {
            if (string.IsNullOrEmpty(number))
            {
                return new BindingList<IndicationForGrid>();
            }
            else
            {
                var listForGrid = new BindingList<IndicationForGrid>();
                foreach (var concreteIndication in new BindingList<DtoConcreteIndication>(OrderService.FindConcreteIndicationsByOrder(number)))
                {
                    var indication = new IndicationForGrid()
                    { 
                        Code = concreteIndication.Indication.Code,
                        ConcreteCode = concreteIndication.Code
                    };
                    listForGrid.Add(indication);
                }
                return listForGrid;
            }
        }

        public BindingList<DtoTest1> SearchAllowedTestsByVisit(string billingNumber)
        {
            return new BindingList<DtoTest1>(new TestServiceClient().GetTestsByVisit(billingNumber));
        }

        public BindingList<DtoSpecimen1> SearchSpecimens()
        {
            var dtoSpecimen = new DtoSpecimen1()
            {
                Code = string.Empty,
                Name = string.Empty
            };
            return new BindingList<DtoSpecimen1>(new SpecimenServiceClient().FindSpecimens(dtoSpecimen));
        }

        public BindingList<DtoTube1> SearchTubes()
        {
            var  dtoTube = new DtoTube1()
            {
                Code = string.Empty,
                Name = string.Empty
            };
            return new BindingList<DtoTube1>(new TubeServiceClient().FindTubes(dtoTube));
        }

        public BindingList<DtoIndication1> SearchIndications()
        {
            var dtoIndication = new DtoIndication1()
            {
                Code = string.Empty,
                Name = string.Empty
            };
            return new BindingList<DtoIndication1>(new IndicationServiceClient().FindIndications(dtoIndication));
        }

        public string LoadDefaultEntities(string code, BindingList<TestForGrid> testGrids, BindingList<SpecimenForGrid> specimenGrids, BindingList<TubeForGrid> tubeGrids)
        {
            if (testGrids.Count<TestForGrid>(test => test.Code == code) < 2)
            {
                var test = new TestServiceClient().GetTestByCode(code);
                var specimenForGrid = new SpecimenForGrid() 
                { 
                    Code = test.DefaultSpecimen.Code
                };
                specimenGrids.Add(specimenForGrid);
                LoadDefaultTube(test.DefaultSpecimen.Code, tubeGrids);
                return string.Empty;
            }
            else
            {
                return "Test is exist already!";
            }
        }

        public void LoadDefaultTube(string code, BindingList<TubeForGrid> tubeGrids)
        {
            var specimen = new SpecimenServiceClient().GetSpecimenByCode(code);
            var tubeForGrid = new TubeForGrid()
            {
                Code = specimen.DefaultTube.Code
            };
            tubeGrids.Add(tubeForGrid);
        }

        public string GetOrderNamber() 
        {
            return OrderService.GetOrderNumber();
        }

        public BindingList<TestForGrid> LoadTestsToCheckBox(BindingList<TestForGrid> testsFromGrid) 
        {
            var  dtoTest = new DtoTest1()
            {
                Code = string.Empty,
                Name = string.Empty
            };
            var tests = new TestServiceClient().FindTests(dtoTest);
            var query = from testForCheckBox in testsFromGrid
                        join test in tests
                        on testForCheckBox.Code equals test.Code
                        select new TestForGrid()
                        {
                            Code = test.Code,
                            Name = test.Name,
                            ConcreteCode =testForCheckBox.ConcreteCode
                        };
            var testsForCheckBox = new BindingList<TestForGrid>();
            foreach (var testForGrid in query)
            {
                testsForCheckBox.Add(testForGrid);
            }
            return testsForCheckBox;
        }

        public BindingList<TubeForGrid> LoadTubesToCheckBox(BindingList<TubeForGrid> tubesFromGrid)
        {
            var dtoTube = new DtoTube1()
            {
                Code = string.Empty,
                Name = string.Empty
            };
            var tubes = new TubeServiceClient().FindTubes(dtoTube);

            var query = from tubeForCheckBox in tubesFromGrid
                        join tube in tubes
                        on tubeForCheckBox.Code equals tube.Code
                        select new TubeForGrid()
                        {
                            Id = tubeForCheckBox.Id,
                            Code = tube.Code,
                            Name = tube.Name,
                            ReceivedDt = tubeForCheckBox.ReceivedDt,
                            Tests = tubeForCheckBox.Tests
                        };
            var tubesForCheckBox = new BindingList<TubeForGrid>();
            foreach (var tubeForGrid in query)
            {
                tubesForCheckBox.Add(tubeForGrid);
            }
            return tubesForCheckBox;
        }

        public string EditOrder(string number, string clinicalInfo, string billingNumber)
        {
            var dtoOrder = new DtoOrder1()
            {
                Number = number,
                Visit = new DtoVisit1()
                {
                    BillingNumber = billingNumber
                },
                ClinicalInfo = clinicalInfo,
            };
            return OrderService.EditOrder(dtoOrder);
        }

        public BindingList<TestForGrid> AddConcreteTest(BindingList<TestForGrid> testGrids, string orderNumber)
        {
            foreach (var testGrid in testGrids)
            {
                var dtoConcreteTest = new DtoConcreteTest1()
                {
                    Order = new DtoOrder1()
                    {
                        Number = orderNumber
                    },
                    Test = new DtoTest2()
                    {
                        Code = testGrid.Code
                    },
                };
                testGrid.ConcreteCode= OrderService.AddConcreteTest(dtoConcreteTest);
            }
            return testGrids;
        }

        public BindingList<TestForGrid> EditConcreteTest(BindingList<TestForGrid> testGrids, string orderNumber)
        {
            foreach (var testGrid in testGrids)
            {
                if (string.IsNullOrEmpty(testGrid.ConcreteCode))
                {
                    var dtoConcreteTest = new DtoConcreteTest1()
                    {
                        Order = new DtoOrder1()
                        {
                            Number = orderNumber
                        },
                        Test = new DtoTest2()
                        {
                            Code = testGrid.Code
                        },
                    };
                    testGrid.ConcreteCode = OrderService.AddConcreteTest(dtoConcreteTest);
                }
                else
                {
                    var dtoConcreteTest = new DtoConcreteTest1()
                    {
                        Code = testGrid.ConcreteCode,
                        Order = new DtoOrder1()
                        {
                            Number = orderNumber,
                        },
                        Test = new DtoTest2()
                        {
                            Code = testGrid.Code
                        },
                    };
                    OrderService.EditConcreteTest(dtoConcreteTest);
                }
            }
            return testGrids;
        }

        public BindingList<TubeForGrid> AddConcreteTube(BindingList<TubeForGrid> tubeGrids, string orderNumber)
        {
            foreach (var tubeGrid in tubeGrids)
            {
                var dtoConcreteTube = new DtoConcreteTube()
                {
                    Order = new DtoOrder1()
                    {
                        Number = orderNumber
                    },
                    Tube = new DtoTube2()
                    {
                        Code = tubeGrid.Code
                    },
                    ReceivedDt = tubeGrid.ReceivedDt
                };
                tubeGrid.ConcreteCode = OrderService.AddConcreteTube(dtoConcreteTube);
            }
            return tubeGrids;
        }

        public BindingList<TubeForGrid> EditConcreteTube(BindingList<TubeForGrid> tubeGrids, string orderNumber)
        {
            foreach (var tubeGrid in tubeGrids)
            {
                if (string.IsNullOrEmpty(tubeGrid.ConcreteCode))
                {
                    var dtoConcreteTube = new DtoConcreteTube()
                    {
                        Order = new DtoOrder1()
                        {
                            Number = orderNumber
                        },
                        Tube = new DtoTube2()
                        {
                            Code = tubeGrid.Code
                        },
                        ReceivedDt = tubeGrid.ReceivedDt
                    };
                    tubeGrid.ConcreteCode = OrderService.AddConcreteTube(dtoConcreteTube);
                }
                else 
                {
                    var dtoConcreteTube = new DtoConcreteTube()
                    {
                        Code = tubeGrid.ConcreteCode,
                        Tube = new DtoTube2()
                        {
                            Code = tubeGrid.Code
                        },
                        ReceivedDt = tubeGrid.ReceivedDt
                    };
                    OrderService.EditConcreteTube(dtoConcreteTube);
                }
            }
            return tubeGrids;
        }

        public BindingList<SpecimenForGrid> AddConcreteSpecimen(BindingList<SpecimenForGrid> specimenGrids, string orderNumber)
        {
            foreach (var specimenGrid in specimenGrids)
            {
                var dtoConcreteSpecimen = new DtoConcreteSpecimen()
                {
                    Order = new DtoOrder1()
                    {
                        Number = orderNumber
                    },
                    Specimen = new DtoSpecimen2()
                    {
                        Code = specimenGrid.Code
                    },
                    CollectedDt = specimenGrid.CollectedDt,
                    Volume = specimenGrid.Volume
                };
                specimenGrid.ConcreteCode = OrderService.AddConcreteSpecimen(dtoConcreteSpecimen);
            }
            return specimenGrids;
        }

        public BindingList<SpecimenForGrid> EditConcreteSpecimen(BindingList<SpecimenForGrid> specimenGrids, string orderNumber)
        {
            foreach (var specimenGrid in specimenGrids)
            {
                if (string.IsNullOrEmpty(specimenGrid.ConcreteCode))
                {
                    var dtoConcreteSpecimen = new DtoConcreteSpecimen()
                    {
                        Order = new DtoOrder1()
                        {
                            Number = orderNumber
                        },
                        Specimen = new DtoSpecimen2()
                        {
                            Code = specimenGrid.Code
                        },
                        CollectedDt = specimenGrid.CollectedDt,
                        Volume = specimenGrid.Volume
                    };
                    specimenGrid.ConcreteCode = OrderService.AddConcreteSpecimen(dtoConcreteSpecimen);
                }
                else 
                {
                    var dtoConcreteSpecimen = new DtoConcreteSpecimen()
                    {
                        Code = specimenGrid.ConcreteCode,
                        Specimen = new DtoSpecimen2()
                        {
                            Code = specimenGrid.Code
                        },
                        CollectedDt = specimenGrid.CollectedDt,
                        Volume = specimenGrid.Volume
                    };
                    OrderService.EditConcreteSpecimen(dtoConcreteSpecimen);
                }
            }
            return specimenGrids;
        }

        public BindingList<IndicationForGrid> AddConcreteIndication(BindingList<IndicationForGrid> indicationGrids, string orderNumber)
        {
            foreach (var indicationGrid in indicationGrids)
            {
                var dtoConcreteIndication = new DtoConcreteIndication()
                {
                    Order = new DtoOrder1()
                    {
                        Number = orderNumber
                    },
                    Indication = new DtoIndication2() 
                    {
                        Code = indicationGrid.Code
                    }
                };
                indicationGrid.ConcreteCode = OrderService.AddConcreteIndication(dtoConcreteIndication);
            }
            return indicationGrids;
        }

        public BindingList<IndicationForGrid> EditConcreteIndication(BindingList<IndicationForGrid> indicationGrids, string orderNumber)
        {
            foreach (var indicationGrid in indicationGrids)
            {
                if (string.IsNullOrEmpty(indicationGrid.ConcreteCode))
                {
                    var dtoConcreteIndication = new DtoConcreteIndication()
                    {
                        Order = new Medicine.Clinic.Client.Model.OrderService.DtoOrder()
                        {
                            Number = orderNumber
                        },
                        Indication = new DtoIndication2()
                        {
                            Code = indicationGrid.Code
                        }
                    };
                    indicationGrid.ConcreteCode = OrderService.AddConcreteIndication(dtoConcreteIndication);
                }
                else 
                {
                    var dtoConcreteIndication = new DtoConcreteIndication()
                    {
                        Order = new DtoOrder1()
                        {
                            Number = orderNumber
                        },
                        Code = indicationGrid.ConcreteCode,
                        Indication = new DtoIndication2()
                        {
                            Code = indicationGrid.Code
                        }
                    };
                    OrderService.EditConcreteIndication(dtoConcreteIndication);
                }
            }
            return indicationGrids;
        }

        public void AddTestTubeAttch(BindingList<TubeForGrid> tubeGrids, BindingList<TestForGrid> testGrids) 
        {
            foreach (var tubeGrid in tubeGrids) 
            {
                string testsString = tubeGrid.Tests;
                string[] testCods = testsString.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var testCode in testCods)
                {
                    string concreteTestCode = testGrids.SingleOrDefault<TestForGrid>(testGrid => testGrid.Code == testCode).ConcreteCode;
                    var dtoTestTubeAttach = new DtoTestTubeAttach()
                    {
                        DtoConctereTube = new DtoConcreteTube()
                        {
                            Id = OrderService.GetConcreteTubeByCode(tubeGrid.ConcreteCode).Id
                        },
                        DtoConcreteTest = new DtoConcreteTest1() 
                        {
                            Id = OrderService.GetConcreteTestByCode(concreteTestCode).Id
                        }
                    };
                    OrderService.AddTestTubeAttach(dtoTestTubeAttach);
                }
            }            
        }

        public void AddSpecimenTubeAttch(BindingList<SpecimenForGrid> specimenGrids, BindingList<TubeForGrid> tubeGrids)
        {
            foreach (var specimenGrid in specimenGrids)
            {
                string tubesString = specimenGrid.Tubes;
                string[] tubesId = tubesString.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var tubeId in tubesId)
                {
                    string concreteTubeCode = tubeGrids.SingleOrDefault<TubeForGrid>(tubeGrid => tubeGrid.Id == tubeId).ConcreteCode;
                    var dtoSpecimenTubeAttach = new DtoSpecimenTubeAttach()
                    {
                        ConcreteSpecimen = new DtoConcreteSpecimen()
                        {
                            Id = OrderService.GetConcreteSpecimenByCode(specimenGrid.ConcreteCode).Id
                        },

                        ConcreteTube = new DtoConcreteTube()
                        {
                            Id = OrderService.GetConcreteTubeByCode(concreteTubeCode).Id
                        }
                    };
                    OrderService.AddSpecimenTubeAttach(dtoSpecimenTubeAttach);
                }
            }

        }

        public void DeleteAttaches(string orderNumber)
        {
            OrderService.DeleteTestTubeAttach(orderNumber);
            OrderService.DeleteSpecimenTubeAttach(orderNumber);
        }

        public string CheckForConstrains(BindingList<SpecimenForGrid> specimenGrids, BindingList<TubeForGrid> tubeGrids, BindingList<TestForGrid> testGrids, BindingList<IndicationForGrid> indicationGrids)
        {
            if (!(specimenGrids.Count == 0) && !(tubeGrids.Count == 0) && !(tubeGrids.Count == 0))
            {
                int errorTestGridCount = testGrids.Where(testGrid => string.IsNullOrEmpty(testGrid.Code))
                                                  .Count();

                int errorTubeGridCount = tubeGrids.Where(tubeGrid => string.IsNullOrEmpty(tubeGrid.Code) || string.IsNullOrEmpty(tubeGrid.Tests))
                                                  .Count();

                int errorSpecimenGridCount = specimenGrids.Where(specimenGrid => string.IsNullOrEmpty(specimenGrid.Code) || specimenGrid.Volume < 1 || string.IsNullOrEmpty(specimenGrid.Tubes))
                                                          .Count();
                int errorIndicationGridCount = indicationGrids.Where(indicationGrid => string.IsNullOrEmpty(indicationGrid.Code))
                                                              .Count();

                if ((errorTestGridCount == 0) && (errorTubeGridCount == 0) && (errorSpecimenGridCount == 0) && (errorIndicationGridCount == 0))
                {
                    bool breakFlag = false;
                    string returnValue = string.Empty;
                    foreach (var specimenGrid in specimenGrids)
                    {
                        string[] tubesId = new string[0];
                        if (!breakFlag)
                        {
                            string tubesString = specimenGrid.Tubes;
                            tubesId = tubesString.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                        }
                        else
                        {
                            return returnValue;
                        }

                        foreach (var tubeId in tubesId)
                        {
                            var dtoSpecimenTubeAttach = new DtoSpecimenTubeAttach()
                            {
                                ConcreteSpecimen = new DtoConcreteSpecimen()
                                {
                                    CollectedDt = specimenGrid.CollectedDt,
                                    Volume = specimenGrid.Volume,
                                },

                                ConcreteTube = new DtoConcreteTube()
                                {
                                    ReceivedDt = tubeGrids.SingleOrDefault<TubeForGrid>(tube => tube.Id == tubeId).ReceivedDt,
                                    Tube = new DtoTube2()
                                    {
                                        Volume = new TubeServiceClient().GetTubeByCode(tubeGrids.Single<TubeForGrid>(tube => tube.Id == tubeId).Code).Volume
                                    }
                                }
                            };
                            if (dtoSpecimenTubeAttach.ConcreteTube.ReceivedDt > dtoSpecimenTubeAttach.ConcreteSpecimen.CollectedDt ||
                                (dtoSpecimenTubeAttach.ConcreteTube.ReceivedDt > DateTime.Now) ||
                                (dtoSpecimenTubeAttach.ConcreteSpecimen.CollectedDt > DateTime.Now))
                            {
                                breakFlag = true;
                                returnValue = "Invalid Date!";
                                break;
                            }
                            else if (dtoSpecimenTubeAttach.ConcreteTube.Tube.Volume < dtoSpecimenTubeAttach.ConcreteSpecimen.Volume)
                            {
                                breakFlag = true;
                                returnValue = "Invalid Specimen Volume!";
                                break;
                            }
                            else
                            {
                                returnValue = string.Empty;
                            }
                        }
                    }
                    return returnValue;

                }
                else 
                {
                    return "Check validity of grids!";
                }
            }
            else 
            {
                return "Fill all mandatory grids!";
            }
            
        }

        public string LoadIndications(string code, IEnumerable<IndicationForGrid> indicationGrids)
        {
            if (indicationGrids.Count(indication => indication.Code == code) < 2)
            {
                return string.Empty;
            }
            else
            {
                return "Indication is exist already!";
            }
        }

        public string IsDodExis(string billingNumber) 
        {
            DateTime? dod = new PatientServiceClient().GetPatientDodByOrder(billingNumber);
            if (!dod.HasValue)
            {
                return string.Empty;
            }
            else 
            {
                return "Editing exeption: Patient is dead!";
            }
        }

        public BindingList<TubeForGrid> DeleteCheckedTests(BindingList<TubeForGrid> tubeGrids, string deletedTestCode)
        {
            var updatedTubeGrids = tubeGrids;
            foreach (var tubeGrid in updatedTubeGrids)
            {
                if (!string.IsNullOrEmpty(tubeGrid.Tests)) 
                {
                    string updatedTestsString = string.Empty;
                    if (tubeGrid.Tests.Contains(string.Format(" {0},",deletedTestCode)) || tubeGrid.Tests.Contains(string.Format("{0},",deletedTestCode)))
                    {
                        updatedTestsString = tubeGrid.Tests.Replace(string.Format("{0}, ",deletedTestCode), string.Empty);

                    }
                    else if (tubeGrid.Tests.Contains(string.Format(", {0}",deletedTestCode)))
                    {
                        updatedTestsString = tubeGrid.Tests.Replace(string.Format(", {0}",deletedTestCode), string.Empty);
                    }
                    else if (tubeGrid.Tests.Contains(deletedTestCode))
                    {
                        updatedTestsString = tubeGrid.Tests.Replace(deletedTestCode, string.Empty);
                    }
                    else 
                    {
                        updatedTestsString = tubeGrid.Tests;
                    }
                    tubeGrid.Tests = updatedTestsString;
                }
            }
            return updatedTubeGrids;
        }

        public BindingList<SpecimenForGrid> DeleteCheckedTubes(BindingList<SpecimenForGrid> specimenGrids, string deletedTubeId)
        {
            var updatedSpecimenGrids = specimenGrids;
            foreach (var specimenGrid in updatedSpecimenGrids)
            {
                if (!string.IsNullOrEmpty(specimenGrid.Tubes)) 
                {
                    string updatedTubesString = string.Empty;
                    if (specimenGrid.Tubes.Contains(string.Format(" {0},",deletedTubeId)) || specimenGrid.Tubes.Contains(string.Format("{0},",deletedTubeId)))
                    {
                        updatedTubesString = specimenGrid.Tubes.Replace(string.Format("{0}, ",deletedTubeId), string.Empty);
                    }
                    else if (specimenGrid.Tubes.Contains(string.Format(", {0}",deletedTubeId)))
                    {
                        updatedTubesString = specimenGrid.Tubes.Replace(string.Format(", {0}",deletedTubeId), string.Empty);
                    }
                    else if (specimenGrid.Tubes.Contains(deletedTubeId))
                    {
                        updatedTubesString = specimenGrid.Tubes.Replace(deletedTubeId, string.Empty);
                    }
                    else 
                    {
                        updatedTubesString = specimenGrid.Tubes;
                    }
                    specimenGrid.Tubes = updatedTubesString;
                }
            }
            return updatedSpecimenGrids;
        }

        public void DeleteConcreteEntities(BindingList<TestForGrid> testGrids, BindingList<SpecimenForGrid> specimenGrids, BindingList<TubeForGrid> tubeGrids, BindingList<IndicationForGrid> indicationGrids, string orderNumber) 
        {
            var oldConcreteTests = OrderService.FindConcreteTestsByOrder(orderNumber);
            foreach (var oldConcreteTest in oldConcreteTests) 
            {
                if (!testGrids.Any(testGrid => testGrid.ConcreteCode == oldConcreteTest.Code)) 
                {
                    OrderService.DeleteConcreteTest(oldConcreteTest.Code);
                }
            }

            var oldConcreteSpecimens = OrderService.FindConcreteSpecimensByOrder(orderNumber);
            foreach (var oldConcreteSpecimen in oldConcreteSpecimens)
            {
                if (specimenGrids.SingleOrDefault<SpecimenForGrid>(specimenGrid => specimenGrid.ConcreteCode == oldConcreteSpecimen.Code) == null)
                {
                    OrderService.DeleteConcreteSpecimen(oldConcreteSpecimen.Code);
                }
            }

            var oldConcreteTubes = OrderService.FindConcreteTubesByOrder(orderNumber);
            foreach (var oldConcreteTube in oldConcreteTubes)
            {
                if (tubeGrids.SingleOrDefault<TubeForGrid>(tubeGrid => tubeGrid.ConcreteCode == oldConcreteTube.Code) == null)
                {
                    OrderService.DeleteConcreteTube(oldConcreteTube.Code);
                }
            }

            var oldConcreteIndications = OrderService.FindConcreteIndicationsByOrder(orderNumber);
            foreach (var oldConcreteIndication in oldConcreteIndications)
            {
                if (indicationGrids.SingleOrDefault<IndicationForGrid>(indicationGrid => indicationGrid.ConcreteCode == oldConcreteIndication.Code) == null)
                {
                    OrderService.DeleteConcreteIndication(oldConcreteIndication.Code);
                }
            }
        }
    }
}
