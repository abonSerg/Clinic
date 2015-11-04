using System.ComponentModel;
using Medicine.Clinic.Client.Model.SpecimenService;

namespace Medicine.Clinic.Client.Model
{
    public class SpecimenModel : ISpecimenModel
    {
        public BindingList<DtoSpecimen> SearchSpecimens(string code, string name)
        {
            var dtoSpecimen = new DtoSpecimen()
            {
                Code = code,
                Name = name
            };
            return new BindingList<DtoSpecimen>(new SpecimenServiceClient().FindSpecimens(dtoSpecimen));
        }
    }
}
