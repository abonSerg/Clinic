using System.ComponentModel;
using Medicine.Clinic.Client.Model.ClinicService;
using Medicine.Clinic.Client.Model.DoctorService;
using DtoClinic1 = Medicine.Clinic.Client.Model.DoctorService.DtoClinic;
using DtoClinic2 = Medicine.Clinic.Client.Model.ClinicService.DtoClinic;

namespace Medicine.Clinic.Client.Model
{
    public class NewDoctorModel : INewDoctorModel, INewDoctorEditModel
    {
        public string EditDoctor(string code, string firstName, string lastName, string middleName, string clinicCode, bool IsEdit)
        {
            if (Validation.Instance.ValidateCode(code))
            {
                var dtoDoctor = new DtoDoctor()
                {
                    Code = code,
                    FirstName = firstName,
                    LastName = lastName,
                    MiddleName = middleName,
                    Clinic = new DtoClinic1() { Code = clinicCode },
                    IsEdit = IsEdit
                };

                return new DoctorServiceClient().EditDoctor(dtoDoctor);
            }
            else 
            {
                return "Fill Code field!";
            }
            
        }

        public BindingList<DtoClinic2> LoadClinics()
        {
            var dtoClinic = new ClinicService.DtoClinic()
            {
                Code = string.Empty,
                Name = string.Empty
            };
            return new BindingList<DtoClinic2>(new ClinicServiceClient().FindClinics(dtoClinic));
        }
    }
}
