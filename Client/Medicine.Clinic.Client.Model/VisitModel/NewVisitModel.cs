using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using ClinicDataSetAccess;
using Medicine.Clinic.Client.Model.GridControlsEntities;
using Medicine.Clinic.Client.Model.VisitService;
using ClinicsRow = ClinicDataSetAccess.ClinicDataSet.ClinicsRow;

namespace Medicine.Clinic.Client.Model
{
    public class NewVisitModel : INewVisitModel, INewVisitEditModel
    {
        private ClinicDataSet clinicDataSet;
        private VisitServiceClient visitService;

        private VisitServiceClient VisitService
        {
            get
            {
                visitService = visitService ?? new VisitServiceClient();
                return new VisitServiceClient();
            }
        } 


        public void GetDataSet() 
        {
            string serializableString = VisitService.SearchNewVisitProperties();
            var serializer = new XmlSerializer(typeof(ClinicDataSet));
            var reader = new StringReader(serializableString);
            clinicDataSet = serializer.Deserialize(reader) as ClinicDataSet;
            reader.Close();
        }

        public BindingList<PatientForGrid> LoadPatients() 
        {
            var patientsList = new BindingList<PatientForGrid>();

            foreach (var patientRow in clinicDataSet.Patients) 
            {
                var patient = new PatientForGrid()
                {
                    Mrn = patientRow.Mrn,
                    FirstName = patientRow.FirstName,
                    LastName = patientRow.LastName
                };
                patientsList.Add(patient);
            }
            return patientsList;
        }

        public BindingList<DoctorForGrid> LoadDoctors()
        {
            var doctorsList = new BindingList<DoctorForGrid>();

            foreach (var doctorRow in clinicDataSet.Doctors)
            {
                var doctor = new DoctorForGrid()
                {
                   Code = doctorRow.Code,
                   FirstName = doctorRow.FirstName,
                   LastName = doctorRow.LastName,
                   Clinic = clinicDataSet.Clinics.SingleOrDefault<ClinicsRow>(row => row.DoctorId == doctorRow.Id).Name
                };
                doctorsList.Add(doctor);
            }
            return doctorsList;
        }

        public BindingList<ApartmentForGrid> LoadApartments()
        {
            var apartmentsList = new BindingList<ApartmentForGrid>();

            foreach (var apartmentRow in clinicDataSet.Apartments)
            {
                var apartment = new ApartmentForGrid()
                {
                    Id = Convert.ToInt32(apartmentRow.Id),
                    ClinicCode = clinicDataSet.Clinics.SingleOrDefault<ClinicsRow>(row => row.Id == apartmentRow.ClinicId).Code,
                    ClinicName = clinicDataSet.Clinics.SingleOrDefault<ClinicsRow>(row => row.Id == apartmentRow.ClinicId).Name, 
                    Room = apartmentRow.RoomId,
                    Bed = apartmentRow.BedId
                };
                apartmentsList.Add(apartment);
            }
            return apartmentsList;
        }

        public string GetBillingNumber() 
        {
            return VisitService.GetBillingNumber();
        }

        public string EditVisit(string billingNumber, string mrn, string doctorCode, int apartmentId)
        {
            return VisitService.EditVisit(billingNumber, mrn, doctorCode, apartmentId);
        }

        public string GetPatientMrnByVisit(string billingNumber) 
        {
            return VisitService.GetPatientMrn(billingNumber);
        }

        public int GetApartmentIdByVisit(string billingNumber) 
        {
            return VisitService.GetApartmentId(billingNumber);
        }

        public string GetDoctorCodeByVisit(string billingNumber) 
        {
            return VisitService.GetDoctorCode(billingNumber);
        }

        public string GetDefaultDoctorCode(int apartmentId)
        {
            return VisitService.GetDefaultDoctorCode(apartmentId);
        }
    }
}
