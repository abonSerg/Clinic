using Medicine.Clinic.Client.Model.ClinicService;
using System.ComponentModel;

namespace Medicine.Clinic.Client.Model
{
    public interface INewDoctorModel
    {
        string EditDoctor(string code, string firstName, string lastName, string middleName, string clinicCode, bool IsEdit);
        BindingList<DtoClinic> LoadClinics();
    }
}
