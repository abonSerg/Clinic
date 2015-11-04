using System.ComponentModel;
using Medicine.Clinic.Client.Model.ApartmentService;

namespace Medicine.Clinic.Client.Model
{
    public class ApartmentModel : IApartmentModel
    {
        public BindingList<DtoApartment> SearchApartments(string clinicName)
        {
            var dtoApartment = new DtoApartment()
            {
                Clinic =new DtoClinic()
                {
                    Name = clinicName
                }
            };
            return new BindingList<DtoApartment>(new ApartmentServiceClient().FindApartments(dtoApartment));
        }
    }
}
