using System.ComponentModel;
using Medicine.Clinic.Client.Model.SpecimenService;
using Medicine.Clinic.Client.Model.TubeService;


namespace Medicine.Clinic.Client.Model
{

    public class NewSpecimenModel : INewSpecimenModel, INewSpecimenEditModel
    {
        public string EditSpecimen(string code, string name, string defaultTubeCode, bool isEdit)
        {
            if (Validation.Instance.ValidateCode(code))
            {
                var dtoSpecimen = new DtoSpecimen()
                {
                    Code = code,
                    Name = name,
                    DefaultTube = new SpecimenService.DtoTube()
                    {
                        Code = defaultTubeCode
                    },
                    IsEdit = isEdit
                };
                return new SpecimenServiceClient().EditSpecimen(dtoSpecimen);
            }
            else 
            {
                return "Code field is empty!";
            }
        }

        public BindingList<TubeService.DtoTube> LoadDefaultTubes()
        {
            var dtoTube = new TubeService.DtoTube()
            {
                Code = string.Empty,
                Name = string.Empty
            };
            return new BindingList<TubeService.DtoTube>(new TubeServiceClient().FindTubes(dtoTube));
        }
    }
}
