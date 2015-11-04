using Medicine.Clinic.Client.Model.ClinicService;
using System.ComponentModel;

namespace Medicine.Clinic.Client.Model
{
    public interface IClinicModel
    {
        BindingList<DtoClinic> SearchClinics(string code, string name);
    }
}
