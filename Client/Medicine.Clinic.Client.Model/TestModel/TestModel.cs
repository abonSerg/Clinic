using System.ComponentModel;
using Medicine.Clinic.Client.Model.TestService;

namespace Medicine.Clinic.Client.Model
{
    public class TestModel: ITestModel
    {
        public BindingList<DtoTest> SearchTests(string code, string name)
        {
            DtoTest dtoTest = new DtoTest()
            {
                Code = code,
                Name = name
            };
            return new BindingList<DtoTest>(new TestServiceClient().FindTests(dtoTest));
        }
    }
}
