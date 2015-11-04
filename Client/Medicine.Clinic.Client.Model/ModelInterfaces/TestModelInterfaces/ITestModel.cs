using System.ComponentModel;
using Medicine.Clinic.Client.Model.TestService;

namespace Medicine.Clinic.Client.Model
{
    public interface ITestModel
    {
        BindingList<DtoTest> SearchTests(string code, string name);
    }
}
