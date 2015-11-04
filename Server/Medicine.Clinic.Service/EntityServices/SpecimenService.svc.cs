using System.Linq;
using Medicine.Clinic.DataAccess;

namespace Medicine.Clinic.Service
{
    public class SpecimenService : ISpecimenService
    {
        public DtoSpecimen[] FindSpecimens(DtoSpecimen dtoSpecimen)
        {
            Specimen[] specimens = SpecimenMethods.Instance.GetSpecimens(dtoSpecimen.Code, dtoSpecimen.Name);
            DtoSpecimen[] dtoSpecimens = specimens.Select(specimen => new DtoSpecimen()
                                                                 {
                                                                     Code = specimen.Code,
                                                                     Name = specimen.Name,
                                                                     DefaultTube = new DtoTube()
                                                                     {
                                                                         Code = specimen.DefaultTube.Code,
                                                                         Name = specimen.DefaultTube.Name,
                                                                     }
                                                                 }).ToArray();
          return dtoSpecimens;
        }

        public string EditSpecimen(DtoSpecimen dtoSpecimen)
        {
            var uniqueSpecimen = SpecimenMethods.Instance.GetSpecimenByCode(dtoSpecimen.Code);
            if (!dtoSpecimen.IsEdit)
            {
                var specimen = new Specimen()
                {
                    Code = dtoSpecimen.Code,
                    Name = dtoSpecimen.Name,
                    DefaultTube = new Tube()
                    {
                        Code = dtoSpecimen.DefaultTube.Code
                    }
                };
                return SpecimenMethods.Instance.InsertSpecimen(specimen);
            }
            else 
            {
                var specimen = new Specimen()
                {
                    Id = uniqueSpecimen.Id,
                    Code = dtoSpecimen.Code,
                    Name = dtoSpecimen.Name,
                    DefaultTube = new Tube()
                    {
                        Code = dtoSpecimen.DefaultTube.Code
                    }
                };
                return SpecimenMethods.Instance.UpdateSpecimen(specimen);
            }
        }

        public DtoSpecimen GetSpecimenByCode(string code)
        {
            var specimen = SpecimenMethods.Instance.GetSpecimenByCode(code);
            var dtoSpecimen = new DtoSpecimen()
            {
                Id = specimen.Id,
                Code = specimen.Code,
                DefaultTube = new DtoTube()
                {
                    Id = specimen.DefaultTube.Id,
                    Code = specimen.DefaultTube.Code
                }
            };
            return dtoSpecimen;
        }
    }
}
