using System.Linq;
using Medicine.Clinic.DataAccess;

namespace Medicine.Clinic.Service
{
    public class DoctorService : IDoctorService
    {
        public DtoDoctor[] FindDoctors(DtoDoctor dtoDoctor)
        {
            Doctor[] doctors = DoctorMethods.Instance.GetDoctors(dtoDoctor.Code, dtoDoctor.FirstName, dtoDoctor.LastName);
            DtoDoctor[] dtoDoctors = doctors.Select(doctor => new DtoDoctor()
            {
                Id = doctor.Id,
                Code = doctor.Code,
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
                MiddleName = doctor.MiddleName,
                Clinic = new DtoClinic()
                {
                    Id = doctor.Clinic.Id,
                    Code = doctor.Clinic.Code,
                    Name = doctor.Clinic.Name,
                }
            }).ToArray();
            return dtoDoctors;
        }

        public string EditDoctor(DtoDoctor dtoDoctor)
        {
            var uniqueDoctor = DoctorMethods.Instance.GetDoctorByCode(dtoDoctor.Code);
            if (!dtoDoctor.IsEdit)
            {
                var doctor = new Doctor()
                {
                    Code = dtoDoctor.Code,
                    FirstName = dtoDoctor.FirstName,
                    LastName = dtoDoctor.LastName,
                    MiddleName = dtoDoctor.MiddleName,
                    Clinic = new DataAccess.Clinic()
                    {
                        Code = dtoDoctor.Clinic.Code
                    }
                };
                return DoctorMethods.Instance.InsertDoctor(doctor);
            }
            else
            {
                var doctor = new Doctor()
                {
                    Id = uniqueDoctor.Id,
                    Code = dtoDoctor.Code,
                    FirstName = dtoDoctor.FirstName,
                    LastName = dtoDoctor.LastName,
                    MiddleName = dtoDoctor.MiddleName,
                    Clinic = new DataAccess.Clinic()
                    {
                        Code = dtoDoctor.Clinic.Code
                    }
                };
                return DoctorMethods.Instance.UpdateDoctor(doctor);
            }
        }
    }
}
