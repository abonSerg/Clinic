using ClinicDataSetAccess;
using Medicine.Clinic.DataAccess;
using System.Data;
using System.IO;
using System.Xml.Serialization;
using System.Linq;
using Clinic1 = Medicine.Clinic.DataAccess.Clinic;
using PatientsRow = ClinicDataSetAccess.ClinicDataSet.PatientsRow;
using VisitsRow = ClinicDataSetAccess.ClinicDataSet.VisitsRow;
using ApartmentsRow = ClinicDataSetAccess.ClinicDataSet.ApartmentsRow;
using DoctorsRow = ClinicDataSetAccess.ClinicDataSet.DoctorsRow;
using ClinicsRow = ClinicDataSetAccess.ClinicDataSet.ClinicsRow;


namespace Medicine.Clinic.Service
{
    public class VisitService : IVisitService
    {
        private ClinicDataSet clinicDataSet;

        public string SearchVisits(string searchMrn, string searchPatientFirstName, string searchBllingNumber)
        {
            clinicDataSet = ClinicSetTables.ClinicDataSet;
              
            Visit[] visitsList = VisitMethods.Instance.GetVisits(searchMrn, searchPatientFirstName, searchBllingNumber);

            foreach (var visit in visitsList)
            {
                VisitsRow visitRow = clinicDataSet.Visits.NewVisitsRow();
                visitRow.BillingNumber = visit.BillingNumber;
                visitRow.PatientId = visit.Patient.Id;
                visitRow.ApartmentId = visit.Apartment.Id;
                clinicDataSet.Visits.AddVisitsRow(visitRow);

                if (clinicDataSet.Patients.SingleOrDefault<PatientsRow>(row => row.Id == visit.Patient.Id) == null)
                {
                    PatientsRow patientRow = clinicDataSet.Patients.NewPatientsRow();
                    patientRow.Id = visit.Patient.Id;
                    patientRow.Mrn = visit.Patient.Mrn;
                    patientRow.FirstName = visit.Patient.FirstName;
                    patientRow.LastName = visit.Patient.LastName;
                    clinicDataSet.Patients.AddPatientsRow(patientRow);
                }

                if (clinicDataSet.Apartments.SingleOrDefault<ApartmentsRow>(row => row.Id == visit.Apartment.Id) == null)
                {
                    ApartmentsRow apartmentRow = clinicDataSet.Apartments.NewApartmentsRow();
                    apartmentRow.Id = visit.Apartment.Id;
                    apartmentRow.ClinicId = visit.Apartment.Clinic.Id;
                    apartmentRow.RoomId = visit.Apartment.RoomId;
                    apartmentRow.BedId = visit.Apartment.BedId;
                    clinicDataSet.Apartments.AddApartmentsRow(apartmentRow);
                }

                if (clinicDataSet.Doctors.SingleOrDefault<DoctorsRow>(row => row.Id == visit.Doctor.Id) == null)
                {
                    DoctorsRow doctorRow = clinicDataSet.Doctors.NewDoctorsRow();
                    doctorRow.Id = visit.Doctor.Id;
                    doctorRow.Code = visit.Doctor.Code;
                    doctorRow.FirstName = visit.Doctor.FirstName;
                    doctorRow.LastName = visit.Doctor.LastName;
                    clinicDataSet.Doctors.AddDoctorsRow(doctorRow);
                }

                if (clinicDataSet.Clinics.SingleOrDefault<ClinicsRow>(row => row.Id == visit.Apartment.Clinic.Id) == null)
                {
                    ClinicsRow clinicRow = clinicDataSet.Clinics.NewClinicsRow();
                    clinicRow.Id = visit.Apartment.Clinic.Id;
                    clinicRow.Code = visit.Apartment.Clinic.Code;
                    clinicRow.Name = visit.Apartment.Clinic.Name;
                    clinicRow.DoctorId = visit.Doctor.Id;
                    clinicDataSet.Clinics.AddClinicsRow(clinicRow);
                }
            }

            XmlSerializer serializer = new XmlSerializer(typeof(ClinicDataSet));
            StringWriter writer = new StringWriter();
            serializer.Serialize(writer, clinicDataSet);
            writer.Close();

            return writer.ToString();
        }

        public string SearchNewVisitProperties() 
        {
            clinicDataSet = ClinicSetTables.ClinicDataSet;

            Patient[] patientsList = PatientMethods.Instance.GetPatients(string.Empty, string.Empty,string.Empty,string.Empty,string.Empty);

            foreach (var patient in patientsList)
            {
                PatientsRow patientRow = clinicDataSet.Patients.NewPatientsRow();
                patientRow.Id = patient.Id;
                patientRow.Mrn = patient.Mrn;
                patientRow.FirstName = patient.FirstName;
                patientRow.LastName = patient.LastName;
                clinicDataSet.Patients.AddPatientsRow(patientRow);
            }

            Doctor[] doctorsList = DoctorMethods.Instance.GetDoctors(string.Empty, string.Empty, string.Empty);

            foreach (var doctor in doctorsList) 
            {
                DoctorsRow doctorRow = clinicDataSet.Doctors.NewDoctorsRow();
                doctorRow.Id = doctor.Id;
                doctorRow.Code = doctor.Code;
                doctorRow.FirstName = doctor.FirstName;
                doctorRow.LastName = doctor.LastName;
                clinicDataSet.Doctors.AddDoctorsRow(doctorRow);
            }

            Apartment[] apartmentsList = ApartmentMethods.Instance.GetAllApartments();

            foreach (var apartment in apartmentsList) 
            {
                ApartmentsRow apartmentRow = clinicDataSet.Apartments.NewApartmentsRow();
                apartmentRow.Id = apartment.Id;
                apartmentRow.ClinicId = apartment.Clinic.Id;
                apartmentRow.RoomId = apartment.RoomId;
                apartmentRow.BedId = apartment.BedId;
                clinicDataSet.Apartments.AddApartmentsRow(apartmentRow);
            }

            Clinic1[] clinicsList = ClinicMethods.Instance.GetClinics(string.Empty, string.Empty);

            foreach (var clinic in clinicsList)
            {
                ClinicsRow clinicRow = clinicDataSet.Clinics.NewClinicsRow();
                clinicRow.Id = clinic.Id;
                clinicRow.Code = clinic.Code;
                clinicRow.Name = clinic.Name;
                clinicRow.DoctorId = DoctorMethods.Instance.GetDoctorByClinic(clinic.Code).Id;
                clinicDataSet.Clinics.AddClinicsRow(clinicRow);
            }

            XmlSerializer serializer = new XmlSerializer(typeof(ClinicDataSet));
            StringWriter writer = new StringWriter();
            serializer.Serialize(writer, clinicDataSet);
            writer.Close();

            return writer.ToString();
        }

        public string GetBillingNumber() 
        {
            return VisitMethods.Instance.GenerateBillingNumber();
        }

        public string EditVisit(string billingNumber, string mrn, string doctorCode, int apartmentId)
        {
            var uniqueVisit = VisitMethods.Instance.GetVisitByBillingNumber(billingNumber);
            if (uniqueVisit == null)
            {
                var visit = new Visit()
                {
                    BillingNumber = billingNumber,
                    Patient = new Patient()
                    {
                        Mrn = mrn
                    },
                    Doctor = new Doctor()
                    {
                        Code = doctorCode
                    },
                    Apartment = new Apartment()
                    {
                        Id = apartmentId
                    }
                };
                return VisitMethods.Instance.InsertVisit(visit);
            }
            else
            {
                var visit = new Visit()
                {
                    Id = uniqueVisit.Id,
                    BillingNumber = billingNumber,
                    Patient = new Patient()
                    {
                        Mrn = mrn
                    },
                    Doctor = new Doctor()
                    {
                        Code = doctorCode
                    },
                    Apartment = new Apartment()
                    {
                        Id = apartmentId
                    }
                };
                return VisitMethods.Instance.UpdateVisit(visit);
            }
        }
        

        public string GetPatientMrn(string billingNumber) 
        {
            return VisitMethods.Instance.GetVisitByBillingNumber(billingNumber).Patient.Mrn;
        }

        public string GetDoctorCode(string billingNumber)
        {
            return VisitMethods.Instance.GetVisitByBillingNumber(billingNumber).Doctor.Code;
        }

        public int GetApartmentId(string billingNumber) 
        {
            return VisitMethods.Instance.GetVisitByBillingNumber(billingNumber).Apartment.Id;
        }

        public string GetDefaultDoctorCode(int apartmentId)
        {
            string clinicCode = ApartmentMethods.Instance.GetApartmentById(apartmentId).Clinic.Code;

            var doctor = DoctorMethods.Instance.GetDoctorByClinic(clinicCode);
            if (doctor != null)
            {
                return doctor.Code;
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
