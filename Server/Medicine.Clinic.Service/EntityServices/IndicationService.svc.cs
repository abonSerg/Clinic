using System.Linq;
using Medicine.Clinic.DataAccess;

namespace Medicine.Clinic.Service
{
    public class IndicationService : IIndicationService
    {
        public DtoIndication[] FindIndications(DtoIndication dtoIndication)
        {
            Indication[] indications = IndicationMethods.Instance.GetIndications(dtoIndication.Code, dtoIndication.Name);
            DtoIndication[] dtoIndications = indications.Select(indication => new DtoIndication()
            {
                Code = indication.Code,
                Name = indication.Name,
            }).ToArray();
            return dtoIndications;
        }

        public string EditIndication(DtoIndication dtoIndication)
        {
            var uniqueIndication = IndicationMethods.Instance.GetIndicationByCode(dtoIndication.Code);
            if (!dtoIndication.IsEdit)
            {
                var indication = new Indication()
                {
                    Code = dtoIndication.Code,
                    Name = dtoIndication.Name
                };
                return IndicationMethods.Instance.InsertIndication(indication);
            }
            else 
            {
                var indication = new Indication()
                {
                    Id = uniqueIndication.Id,
                    Code = dtoIndication.Code,
                    Name = dtoIndication.Name
                };
                return IndicationMethods.Instance.UpdateIndication(indication);
            }
        }
    }
}
