using Medicine.Clinic.Client.Model.IndicationService;

namespace Medicine.Clinic.Client.Model
{
    public class NewIndicationModel : INewIndicationModel, INewIndicationEditModel
    {
        public string EditIndication(string code, string name, bool isEdit)
        {
            if (Validation.Instance.ValidateCode(code))
            {
                var dtoIndication = new DtoIndication()
                {
                    Code = code,
                    Name = name,
                    IsEdit = isEdit
                };
                return new IndicationServiceClient().EditIndication(dtoIndication);
            }
            else 
            {
                return "Fill Code field!";
            }
            
        }
    }
}
