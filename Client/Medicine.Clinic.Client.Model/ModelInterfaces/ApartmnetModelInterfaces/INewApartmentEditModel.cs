using System.ComponentModel;
using DtoClinic = Medicine.Clinic.Client.Model.ClinicService.DtoClinic;

namespace Medicine.Clinic.Client.Model
{
    public interface INewApartmentEditModel
    {
        string AddApartment(int id, string clinicCode, string roomId, string bedId);
        BindingList<DtoClinic> LoadClinics();
    }
}
