using System.ComponentModel;
using Medicine.Clinic.Client.Model.SpecimenService;
using Medicine.Clinic.Client.Model.SexService;

namespace Medicine.Clinic.Client.Model
{
    public interface INewTestModel
    {
        string EditTest(string code, string name, string cost, string specimenCode, string sexes, bool isEdit);
        BindingList<DtoSpecimen> LoadDefaultSpecimens();
        BindingList<DtoSex> SearchSexes(string code, string name);
        void SaveAttached(string testCode, string sexesString);
    }
}
