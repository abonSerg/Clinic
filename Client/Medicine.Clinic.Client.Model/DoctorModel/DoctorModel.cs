using System.ComponentModel;
using Medicine.Clinic.Client.Model.DoctorService;

namespace Medicine.Clinic.Client.Model
{
    public class DoctorModel : IDoctorModel
    {
        public BindingList<DtoDoctor> SearchDoctors(string code, string firstName, string lastName)
        {
            var dtoDoctor = new DtoDoctor()
            {
                Code = code,
                FirstName = firstName,
                LastName = lastName
            };
            return new BindingList<DtoDoctor>(new DoctorServiceClient().FindDoctors(dtoDoctor));
        }
    }
}
