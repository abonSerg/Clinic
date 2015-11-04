using System.ComponentModel;
using DtoClinic = Medicine.Clinic.Client.Model.ClinicService.DtoClinic;

namespace Medicine.Clinic.Client.Model
{
    public interface INewApartmentModel
    {
        string AddApartment(int id, string clinicCode, string roomId, string bedId);
        BindingList<DtoClinic> LoadClinics();
        
    }
}
