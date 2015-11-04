using Medicine.Clinic.Client.Model.SpecimenService;
using System.ComponentModel;

namespace Medicine.Clinic.Client.Model
{
    public interface ISpecimenModel
    {
        BindingList<DtoSpecimen> SearchSpecimens(string code, string name);
    }
}
