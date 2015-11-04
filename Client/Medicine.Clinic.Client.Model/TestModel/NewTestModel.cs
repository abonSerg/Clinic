using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text;
using System.Linq;
using Medicine.Clinic.Client.Model.SpecimenService;
using Medicine.Clinic.Client.Model.TestService;
using Medicine.Clinic.Client.Model.SexService;
using Medicine.Clinic.Client.Model.OrderService;
using System;
using DtoTest = Medicine.Clinic.Client.Model.TestService.DtoTest;
using DtoSex = Medicine.Clinic.Client.Model.SexService.DtoSex;
using DtoSpecimen = Medicine.Clinic.Client.Model.SpecimenService.DtoSpecimen;
using DtoTest1 = Medicine.Clinic.Client.Model.OrderService.DtoTest;
using DtoSex1 = Medicine.Clinic.Client.Model.OrderService.DtoSex;


namespace Medicine.Clinic.Client.Model
{
    public class NewTestModel : INewTestModel, INewTestEditModel
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

        private TestServiceClient testService;

        private TestServiceClient TestService
        {
            get
            {
                testService = testService ?? new TestServiceClient();
                return testService;
            }
        }

        public string EditTest(string code, string name, string cost, string specimenCode, string sexes, bool isEdit)
        {
            if (Validation.Instance.ValidateCode(code) && !string.IsNullOrEmpty(sexes))
            {
                double newTestEditCost;
                if (double.TryParse(cost, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out newTestEditCost))
                {
                    var dtoTest = new DtoTest()
                    {
                        Code = code,
                        Name = name,
                        Cost = newTestEditCost,
                        DefaultSpecimen = new TestService.DtoSpecimen() { Code = specimenCode },
                        IsEdit = isEdit
                    };
                    return TestService.EditTest(dtoTest);
                }
                else
                {
                    return "Error Cost Value!";
                }
            }
            else 
            {
                return "Fill all mandatory fields";
            }
        }

        public BindingList<DtoSpecimen> LoadDefaultSpecimens()
        {
            var dtoSpecimen = new SpecimenService.DtoSpecimen()
            {
                Code = string.Empty,
                Name = string.Empty,
            };

            return new BindingList<DtoSpecimen>(new SpecimenServiceClient().FindSpecimens(dtoSpecimen));
        }

        public BindingList<DtoSex> SearchSexes(string code, string name)
        {
            var dtoSex = new DtoSex()
            {
                Code = code,
                Name = name
            };
            return new BindingList<DtoSex>(new SexServiceClient().FindSexes(dtoSex));
        }

        public string LoadChekedSexes(string testCode)
        {
            var sexCodes = OrderService.SearchTestSexAllowedsByTest(testCode)
                                       .Select(item => item.Sex.Code);
            return string.Join(", ", sexCodes);
        }

        public void SaveAttached(string testCode, string sexesString) 
        {
            string[] sexCods = sexesString.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

            int testId = TestService.GetTestByCode(testCode).Id;
            foreach (var sexItem in sexCods)
            {
                int sexId = new SexServiceClient().GetSexByCode(sexItem.ToString()).Id;
                var dtoTestSexAllowed = new DtoTestSexAllowed()
                {
                    Test = new DtoTest1 { Id = testId },
                    Sex = new DtoSex1 { Id = sexId }
                };
                OrderService.AddTestSexAllowed(dtoTestSexAllowed);
            }
        }

        public void EditAttach(string testCode, string sexesString)
        {
            string[] sexCods = sexesString.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

            DtoTestSexAllowed[] dtoTestSexAlloweds = OrderService.SearchTestSexAllowedsByTest(testCode);

            foreach (var testSexAllowed in dtoTestSexAlloweds)
            {
                OrderService.DeleteTestSexAllowed(testSexAllowed);
            }

            foreach (var sexCode in sexCods)
            {
                int sexId = new SexServiceClient().GetSexByCode(sexCode).Id;
                var dtoTestSexAllowed = new DtoTestSexAllowed()
                {
                    Test = new Medicine.Clinic.Client.Model.OrderService.DtoTest
                    {
                        Id = TestService.GetTestByCode(testCode).Id
                    },
                    Sex = new OrderService.DtoSex { Id = sexId }
                };
                OrderService.AddTestSexAllowed(dtoTestSexAllowed);
            }
        }

    }
}
