using System;
using System.ComponentModel;
using System.Linq;
using Medicine.Clinic.Client.Model.DiagnosisService;
using Medicine.Clinic.Client.Model.GridControlsEntities;
using Medicine.Clinic.Client.Model.InterpretationService;
using Medicine.Clinic.Client.Model.OrderService;
using DtoOrder1 = Medicine.Clinic.Client.Model.OrderService.DtoOrder;
using DtoDiagnosis1 = Medicine.Clinic.Client.Model.DiagnosisService.DtoDiagnosis;
using DtoOrder2 = Medicine.Clinic.Client.Model.InterpretationService.DtoOrder;
using DtoDiagnosis2 = Medicine.Clinic.Client.Model.InterpretationService.DtoDiagnosis;
using DtoVisit1 = Medicine.Clinic.Client.Model.OrderService.DtoVisit;

namespace Medicine.Clinic.Client.Model
{
    public class InterpretationModel : IInterpretationModel
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

        private InterpretationServiceClient interpretationService;

        private InterpretationServiceClient InterpretationService
        {
            get
            {
                interpretationService = interpretationService ?? new InterpretationServiceClient();
                return interpretationService;
            }
        }


        public BindingList<DtoOrder1> SearchOrders(string number, string billingNumber)
        {
            var dtoOrder = new DtoOrder1()
            {
                Number = number,
                Visit = new DtoVisit1() { BillingNumber = billingNumber }
            };
            return new BindingList<DtoOrder1>(OrderService.FindOrders(dtoOrder));
        }

        public BindingList<DtoDiagnosis1> SearchDiagnoses()
        {
            var dtoDiagnosis = new DtoDiagnosis1()
            {
                Code = string.Empty,
                Name = string.Empty
            };
            return new BindingList<DtoDiagnosis1>(new DiagnosisServiceClient().FindDiagnoses(dtoDiagnosis));
        }

        public BindingList<DiagnosisForGrid> SearchConcreteDiagnoses(string number)
        {
            var listForGrid = new BindingList<DiagnosisForGrid>();
            foreach (var concreteDiagnosis in new BindingList<DtoConcreteDiagnosis>(InterpretationService.FindConcreteDiagnosis(number)))
            {
                var diagnosis = new DiagnosisForGrid()
                {
                    Code = concreteDiagnosis.Diagnosis.Code,
                    ConcreteCode = concreteDiagnosis.Code,
                };
                listForGrid.Add(diagnosis);
            }
            return listForGrid;
        }

        public int GetInterpretationId(string orderNumber) 
        {
            DtoInterpretation dtoIndication = InterpretationService.GetInterpretationByOrder(orderNumber);
            if (dtoIndication == null) 
            {
                return 0;
            }
            else
            {
                return dtoIndication.Id;
            }
        }

        public string GetInterpretationText(string orderNumber)
        {
            return InterpretationService.GetInterpretationByOrder(orderNumber).Text;
        }

        public char  GetInterpretationCondition(string orderNumber)
        {
            return InterpretationService.GetInterpretationByOrder(orderNumber).Condition;
        }

        public string GetInterpretationSignOutDt(string orderNumber)
        {
            DateTime? dateTime = InterpretationService.GetInterpretationByOrder(orderNumber).SignOutDt;
            if (dateTime != null)
            {
                return "Sign Out Date " + dateTime.ToString();
            }
            else 
            {
                return string.Empty;
            }
        }

        public string EditInterpretation(string text, char condition, string orderNumber, DateTime? signOutDt) 
        {
            var  dtoInterpretation = new DtoInterpretation()
            {
                Text = text,
                Condition = condition,
                Order = new DtoOrder2()
                {
                    Number = orderNumber
                },
                SignOutDt = signOutDt
            };
            return InterpretationService.EditInterpretation(dtoInterpretation);
        }

        public string SignOutInterpretation(string text, char condition, string orderNumber) 
        {
            return EditInterpretation(text, condition, orderNumber, DateTime.Now);
        }

        public string LoadDiagnosis(string code, BindingList<DiagnosisForGrid> diagnosisGrids)
        {
            if (diagnosisGrids.Count<DiagnosisForGrid>(diagnosis => diagnosis.Code == code) < 2)
            {
                return string.Empty;
            }
            else
            {
                return "Diagnosis is exist already!";
            }
        }

        public BindingList<DiagnosisForGrid> EditConcreteDiagnosis(BindingList<DiagnosisForGrid> diagnosisGrids, string orderNumber)
        {
            foreach (var diagnosisGrid in diagnosisGrids)
            {
                if (string.IsNullOrEmpty(diagnosisGrid.ConcreteCode))
                {
                    var dtoConcreteDiagnosis = new DtoConcreteDiagnosis()
                    {
                        Order = new DtoOrder2()
                        {
                            Number = orderNumber
                        },
                        Diagnosis = new DtoDiagnosis2()
                        {
                            Code = diagnosisGrid.Code
                        }
                    };
                    diagnosisGrid.ConcreteCode = InterpretationService.AddConcreteDiagnosis(dtoConcreteDiagnosis);
                }
                else
                {
                    var dtoConcreteDiagnosis = new DtoConcreteDiagnosis()
                    {
                        Order = new DtoOrder2()
                        {
                            Number = orderNumber
                        },
                        Code = diagnosisGrid.ConcreteCode,
                        Diagnosis = new DtoDiagnosis2()
                        {
                            Code = diagnosisGrid.Code
                        }
                    };
                    InterpretationService.EditConcreteDiagnosis(dtoConcreteDiagnosis);
                }
            }
            return diagnosisGrids;
        }
    }
}
