using System.Linq;
using NHibernate;
using NHibernate.Linq;
using log4net;

namespace Medicine.Clinic.DataAccess
{
    public class ApartmentMethods : DbAccess
    {
        private static ApartmentMethods instance;
        public static readonly ILog log = LogManager.GetLogger(typeof(ApartmentMethods));

        public static ApartmentMethods Instance
        {
            get
            {
                instance = instance ?? new ApartmentMethods();
                return instance;
            }
        }

        public static string ValidateApartment(Apartment apartment) 
        {
            if (!string.IsNullOrEmpty(apartment.Clinic.Code) && apartment.RoomId != 0 && apartment.BedId != 0)
            {
                return string.Empty;
            }
            else 
            {
                return "Fill mandatory fields!";
            }
        } 

        public string InsertApartment(Apartment apartment)
        {
            string result = ValidateApartment(apartment);
            if (string.IsNullOrEmpty(result))
            {
                apartment.Clinic.Id = ClinicMethods.Instance.GetClinicByCode(apartment.Clinic.Code).Id;
                bool isProcessDone = InsertEntity<Apartment>(apartment);
                if (isProcessDone)
                {
                    log.Info(string.Format("Apartment: Clinic '{0}', roomId '{1}', bedId '{2}' saved", apartment.Clinic.Code, apartment.RoomId, apartment.BedId));
                    return string.Empty;
                }
                else
                {
                    return "Apartment must be UNIQUE!";
                }
            }
            else 
            {
                return result;
            }
        }

        public string UpdateApartment(Apartment apartment)
        {
            string result = ValidateApartment(apartment);
            if (string.IsNullOrEmpty(result))
            {
                apartment.Clinic.Id = ClinicMethods.Instance.GetClinicByCode(apartment.Clinic.Code).Id;
                bool isProcessDone = UpdateEntity<Apartment>(apartment);
                if (isProcessDone)
                {
                    log.Info(string.Format("Apartment: Clinic '{0}', roomId '{1}', bedId '{2}' changed", apartment.Clinic.Code, apartment.RoomId, apartment.BedId));
                    return string.Empty;
                }
                else
                {
                    return "Apartment must be UNIQUE!";
                }
            }
            else
            {
                return result;
            }
        }

        public Apartment[] GetAllApartments()
        {
            return GetAllEntities<Apartment>();
        }

        public Apartment GetApartmentById(int id) 
        {
            return GetEntityById<Apartment>(id);
        }

        public Apartment[] GetApartmentsByClinic(string clinicName)
        {
            ISession readSession = readSessionsFactory.OpenSession();
            return readSession.Query<Apartment>()
                              .Cacheable()
                              .Where(apartment => apartment.Clinic.Name.Contains(clinicName))
                              .ToArray();
        }

        public Apartment GetUniqueApartment(string clinicCode, int roomId, int bedId)
        {
            ISession readSession = readSessionsFactory.OpenSession();
            return readSession.Query<Apartment>()
                              .SingleOrDefault<Apartment>(apartment => (apartment.Clinic.Code == clinicCode) && (apartment.RoomId == roomId) && (apartment.BedId == bedId));
        }
    }
}
