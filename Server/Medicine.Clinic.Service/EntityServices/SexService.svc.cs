using System.Linq;
using Medicine.Clinic.DataAccess;



namespace Medicine.Clinic.Service
{
    public class SexService : ISexService
    {
        public DtoSex[] FindSexes(DtoSex dtoSex)
        {
            
            Sex[] tubes = SexMethods.Instance.GetSexes(dtoSex.Code, dtoSex.Name);
            DtoSex[] dtoSexes = tubes.Select(sex => new DtoSex()
            {
                Code = sex.Code,
                Name = sex.Name,
            }).ToArray();
            return dtoSexes;
        }

        public string EditSex(DtoSex dtoSex)
        {
            var uniqueSex = SexMethods.Instance.GetSexByCode(dtoSex.Code);
            if (!dtoSex.IsEdit)
            {
                Sex sex = new Sex()
                {
                    Code = dtoSex.Code,
                    Name = dtoSex.Name,
                };
                return SexMethods.Instance.InsertSex(sex);
            }
            else 
            {
                var sex = new Sex()
                {
                    Id = uniqueSex.Id,
                    Code = dtoSex.Code,
                    Name = dtoSex.Name,
                };
                return SexMethods.Instance.UpdateSex(sex);
            }
        }

        public DtoSex GetSexByCode(string code)
        {
            var sex = SexMethods.Instance.GetSexByCode(code);
            DtoSex dtoSex = new DtoSex()
            {
                Id = sex.Id 
            };
            return dtoSex;
        }
    }
}
