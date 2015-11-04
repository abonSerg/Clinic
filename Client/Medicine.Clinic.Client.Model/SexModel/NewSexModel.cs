using Medicine.Clinic.Client.Model.SexService;

namespace Medicine.Clinic.Client.Model
{
    public class NewSexModel : INewSexModel, INewSexEditModel
    {
 
        public string EditSex(string code, string name, bool isEditMode)
        {
            if (Validation.Instance.ValidateCode(code))
            {
                var dtoSex = new DtoSex()
                {
                    Code = code,
                    Name = name,
                    IsEdit = isEditMode

                };
                return new SexServiceClient().EditSex(dtoSex);
            }
            else 
            {
                return "Invalid code format!";
            }
            
        }
    }
}
