using System.Linq;
using Medicine.Clinic.DataAccess;

namespace Medicine.Clinic.Service
{
    public class ApartmentService : IApartmentService
    {
        public DtoApartment[] FindApartments(DtoApartment dtoApartment)
        {
            Apartment[] apartments = ApartmentMethods.Instance.GetApartmentsByClinic(dtoApartment.Clinic.Name);
            DtoApartment[] dtoApartments = apartments.Select(apartment => new DtoApartment()
            {
                Id = apartment.Id,
                RoomId = apartment.RoomId,
                BedId = apartment.BedId,
                Clinic = new DtoClinic() 
                {
                    Code = apartment.Clinic.Code,
                    Name = apartment.Clinic.Name
                }
            }).ToArray();
            return dtoApartments;
        }

        public string AddApartment(DtoApartment dtoApartment)
        {
            if (dtoApartment.Id == 0)
            {
                var apartment = new Apartment()
                {
                    Clinic = new Medicine.Clinic.DataAccess.Clinic()
                    {
                        Code = dtoApartment.Clinic.Code
                    },
                    RoomId = dtoApartment.RoomId,
                    BedId = dtoApartment.BedId
                };
                return ApartmentMethods.Instance.InsertApartment(apartment);
            }
            else
            {
                var apartment = new Apartment()
                {
                    Id = dtoApartment.Id,
                    Clinic = new Medicine.Clinic.DataAccess.Clinic()
                    {
                        Code = dtoApartment.Clinic.Code
                    },
                    RoomId = dtoApartment.RoomId,
                    BedId = dtoApartment.BedId
                };
                return ApartmentMethods.Instance.UpdateApartment(apartment);
            }
        }
    }
}
