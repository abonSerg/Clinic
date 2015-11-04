using System.ComponentModel;
using Medicine.Clinic.Client.Model.ClinicService;

namespace Medicine.Clinic.Client.Model
{
    public class ClinicModel : IClinicModel
    {
        public BindingList<DtoClinic> SearchClinics(string code, string name)
        {
            var dtoClinic = new DtoClinic()
            {
                Code = code,
                Name = name
            };
            return new BindingList<DtoClinic>(new ClinicServiceClient().FindClinics(dtoClinic));
        }
    }
}
