using System.Linq;
using Medicine.Clinic.DataAccess;

namespace Medicine.Clinic.Service
{
    public class InterpretationService : IInterpretationService
    {
        public DtoConcreteDiagnosis[] FindConcreteDiagnosis(string number)
        {
            ConcreteDiagnosis[] diagnoses = ConcreteDiagnosisMethods.Instance.GetConcreteDiagnosesByOrder(number);
            DtoConcreteDiagnosis[] dtoDiadnoses = diagnoses.Select(diagnosis => new DtoConcreteDiagnosis()
            {
                Code = diagnosis.Code,
                Order = new DtoOrder()
                {
                    Number = diagnosis.Order.Number
                },
                Diagnosis = new DtoDiagnosis() 
                {
                    Code = diagnosis.Diagnosis.Code
                }
            }).ToArray();
            return dtoDiadnoses;
        }

        public DtoInterpretation GetInterpretationByOrder(string orderNumber) 
        {
            Interpretation interpretation = InterpretationMethods.Instance.GetInterpretationByOrder(orderNumber);
            if (interpretation != null)
            {
                var dtoInterpretation = new DtoInterpretation()
                {
                    Id = interpretation.Id,
                    Condition = interpretation.Condition,
                    Order = new DtoOrder()
                    {
                        Id = interpretation.Order.Id
                    },
                    SignOutDt = interpretation.SignOutDt,
                    Text = interpretation.Text
                };
                return dtoInterpretation;
            }
            else 
            {
                return null;
            }
        }

        public string AddConcreteDiagnosis(DtoConcreteDiagnosis dtoConcreteDiagnosis)
        {
            var concreteDiagnosis = new ConcreteDiagnosis()
            {
                Diagnosis = new Diagnosis()
                {
                    Id = DiagnosisMethods.Instance.GetDiagnosisByCode(dtoConcreteDiagnosis.Diagnosis.Code).Id
                },
                Order = new Order()
                {
                    Id = OrderMethods.Instance.GetOrderByNumber(dtoConcreteDiagnosis.Order.Number).Id
                }
            };
            return ConcreteDiagnosisMethods.Instance.InsertConcreteDiagnosis(concreteDiagnosis);
        }

        public string EditConcreteDiagnosis(DtoConcreteDiagnosis dtoConcreteDiagnosis)
        {
            var concreteDiagnosis = new ConcreteDiagnosis()
            {
                Id = ConcreteDiagnosisMethods.Instance.GetConcreteDiagnosisByCode(dtoConcreteDiagnosis.Code).Id,
                Code = ConcreteDiagnosisMethods.Instance.GenerateConcreteDiagnosisNumber(),
                Diagnosis = new Diagnosis()
                {
                    Id = DiagnosisMethods.Instance.GetDiagnosisByCode(dtoConcreteDiagnosis.Diagnosis.Code).Id
                },
                Order = new Order()
                {
                    Id = OrderMethods.Instance.GetOrderByNumber(dtoConcreteDiagnosis.Order.Number).Id
                }
            };
           return ConcreteDiagnosisMethods.Instance.UpdateConcreteDiagnosis(concreteDiagnosis);
        }

        public string EditInterpretation(DtoInterpretation dtoInterpretation)
        {
            var uniqueInterpretation = InterpretationMethods.Instance.GetInterpretationByOrder(dtoInterpretation.Order.Number);
            if (uniqueInterpretation == null)
            {
                var interpretation = new Interpretation()
                {
                    Text = dtoInterpretation.Text,
                    Order = new Order()
                    {
                        Id = OrderMethods.Instance.GetOrderByNumber(dtoInterpretation.Order.Number).Id
                    },
                    Condition = dtoInterpretation.Condition,
                    SignOutDt = dtoInterpretation.SignOutDt
                };
                return InterpretationMethods.Instance.InsertInterpretation(interpretation);
            }
            else
            {
                var interpretation = new Interpretation()
                {
                    Id = uniqueInterpretation.Id,
                    Text = dtoInterpretation.Text,
                    Order = new Order()
                    {
                        Id = OrderMethods.Instance.GetOrderByNumber(dtoInterpretation.Order.Number).Id
                    },
                    Condition = dtoInterpretation.Condition,
                    SignOutDt = dtoInterpretation.SignOutDt
                };
                return InterpretationMethods.Instance.UpdateInterpretation(interpretation);
            }
        }
    }
}
