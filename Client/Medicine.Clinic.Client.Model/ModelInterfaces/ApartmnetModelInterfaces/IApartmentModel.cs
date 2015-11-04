using System.ComponentModel;
using Medicine.Clinic.Client.Model.ApartmentService;

namespace Medicine.Clinic.Client.Model
{
    public interface IApartmentModel
    {
        BindingList<DtoApartment> SearchApartments(string clinicName);
    }
}
