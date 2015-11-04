using System.Linq;
using Medicine.Clinic.DataAccess;
using Clinic = Medicine.Clinic.DataAccess.Clinic;


namespace Medicine.Clinic.Service
{
    public class ClinicService : IClinicService
    {
        public DtoClinic[] FindClinics(DtoClinic dtoClinic)
        {
            string code = dtoClinic.Code;
            string name = dtoClinic.Name;
            string adress = dtoClinic.Address;
            Clinic.DataAccess.Clinic[] clinics = ClinicMethods.Instance.GetClinics(code, name);
            DtoClinic[] dtoClinics = clinics.Select(clinic => new DtoClinic()
                                      {
                                          Id = clinic.Id,
                                          Code = clinic.Code,
                                          Name = clinic.Name,
                                          Address = clinic.Address

                                      }).ToArray();
            return dtoClinics; 
        }

        public string EditClinic(DtoClinic dtoClinic)
        {
            var unigueClinic = ClinicMethods.Instance.GetClinicByCode(dtoClinic.Code);
            if (!dtoClinic.IsEdit)
            {
                var clinic = new DataAccess.Clinic()
                {
                    Code = dtoClinic.Code,
                    Name = dtoClinic.Name,
                    Address = dtoClinic.Address
                };
                return ClinicMethods.Instance.InsertClinic(clinic);
            }
            else
            {
                var clinic = new DataAccess.Clinic()
                  {
                      Id = unigueClinic.Id,
                      Code = dtoClinic.Code,
                      Name = dtoClinic.Name,
                      Address = dtoClinic.Address
                  };
                return ClinicMethods.Instance.UpdateClinic(clinic);

            }
        }
    }
}
