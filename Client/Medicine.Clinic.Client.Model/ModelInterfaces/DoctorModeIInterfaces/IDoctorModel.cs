using Medicine.Clinic.Client.Model.DoctorService;
using System.ComponentModel;

namespace Medicine.Clinic.Client.Model
{
    public interface IDoctorModel
    {
        BindingList<DtoDoctor> SearchDoctors(string code, string firstName, string lastName);
    }
}
