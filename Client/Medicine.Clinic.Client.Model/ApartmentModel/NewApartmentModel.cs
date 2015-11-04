using System.ComponentModel;
using Medicine.Clinic.Client.Model.ApartmentService;
using Medicine.Clinic.Client.Model.ClinicService;
using DtoClinic = Medicine.Clinic.Client.Model.ClinicService.DtoClinic;

namespace Medicine.Clinic.Client.Model
{
    public class NewApartmentModel : INewApartmentModel, INewApartmentEditModel
    {
        static int ValidateRoomId(string stringRoomId) 
        {
            int roomId;
            if (int.TryParse(stringRoomId, out roomId)) 
            {
                return roomId;
            }
            else
            {
                return 0;
            }
        }

        static int ValidateBedId(string stringBedId)
        {
            int bedId;
            if (int.TryParse(stringBedId, out bedId))
            {
                return bedId;
            }
            else
            {
                return 0;
            }
        }

        public string AddApartment(int id, string clinicCode, string roomId, string bedId)
        {
            int validRoomId = ValidateRoomId(roomId);
            int validBedId = ValidateBedId(bedId);
            if (validBedId != 0 && validRoomId != 0) 
            {
                var dtoApartment = new DtoApartment()
                {
                    Id = id,
                    Clinic = new Medicine.Clinic.Client.Model.ApartmentService.DtoClinic()
                    {
                        Code = clinicCode
                    },
                    RoomId = int.Parse(roomId),
                    BedId = int.Parse(bedId),
                };
                return new ApartmentServiceClient().AddApartment(dtoApartment);
            }
            return "Invalid fields format!";
        }

        public BindingList<DtoClinic> LoadClinics()
        {
            var dtoClinic = new DtoClinic()
            {
                Code = string.Empty,
                Name = string.Empty
            };
            return new BindingList<DtoClinic>(new ClinicServiceClient().FindClinics(dtoClinic));
        }
    }
}
