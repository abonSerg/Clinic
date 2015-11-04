using Medicine.Clinic.Client.Model.ClinicService;

namespace Medicine.Clinic.Client.Model
{
    public class NewClinicModel : INewClinicModel, INewClinicEditModel
    {
        public string EditClinic(string code, string name, string address, bool isEdit)
        {
            if (Validation.Instance.ValidateCode(code))
            {
                var dtoClinic = new DtoClinic()
                {
                    Code = code,
                    Name = name,
                    Address = address,
                    IsEdit = isEdit
                };
                return new ClinicServiceClient().EditClinic(dtoClinic);
            }
            else
            {
                return "Invalid Code field!";
            }
        }     
    }
}
