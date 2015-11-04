using System.ComponentModel;
using Medicine.Clinic.Client.Model.SpecimenService;
using Medicine.Clinic.Client.Model.SexService;

namespace Medicine.Clinic.Client.Model
{
    public interface INewTestEditModel
    {
        BindingList<DtoSpecimen> LoadDefaultSpecimens();
        string EditTest(string code, string name, string cost, string specimenCode, string sexes, bool isEdit);
        BindingList<DtoSex> SearchSexes(string code, string name);
        void EditAttach(string testCode, string sexesString);
        string LoadChekedSexes(string testCode);
    }
}
