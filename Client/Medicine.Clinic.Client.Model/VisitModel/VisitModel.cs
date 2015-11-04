using System.ComponentModel;
using System.Data;
using System.IO;
using System.Xml.Serialization;
using ClinicDataSetAccess;
using System.Linq;
using Medicine.Clinic.Client.Model.GridControlsEntities;
using Medicine.Clinic.Client.Model.VisitService;

namespace Medicine.Clinic.Client.Model
{
    public class VisitModel : IVisitModel
    {
        public BindingList<VisitForGrid> SearchVisits(string mrn, string patientFirstName, string billingNumber)
        {
            string serializableString = new VisitServiceClient().SearchVisits(mrn, patientFirstName, billingNumber);
            var serializer = new XmlSerializer(typeof(ClinicDataSet));
            var reader = new StringReader(serializableString);
            ClinicDataSet clinicDataSet = serializer.Deserialize(reader) as ClinicDataSet;
            reader.Close();

            var visitList = new BindingList<VisitForGrid>();

            visitList = new BindingList<VisitForGrid>(clinicDataSet.Visits.Join(clinicDataSet.Apartments, visitRow => visitRow.ApartmentId, apartmentRow => apartmentRow.Id, (visitRow, apartmentRow) => new
            {
                BillingNumber = visitRow.BillingNumber,
                Room = apartmentRow.RoomId,
                Bed = apartmentRow.BedId,
                PatientId = visitRow.PatientId,
                ClinicId = apartmentRow.ClinicId

            }).Join(clinicDataSet.Clinics, visitRow => visitRow.ClinicId, clinicRow => clinicRow.Id, (visitRow, clinicRow) => new
            {
                BillingNumber = visitRow.BillingNumber,
                Room = visitRow.Room,
                Bed = visitRow.Bed,
                PatientId = visitRow.PatientId,
                Clinic = clinicRow.Name,
                DoctorId = clinicRow.DoctorId

            }).Join(clinicDataSet.Doctors, visitRow => visitRow.DoctorId, doctorRow => doctorRow.Id, (visitRow, doctorRow) => new
            {
                BillingNumber = visitRow.BillingNumber,
                Room = visitRow.Room,
                Bed = visitRow.Bed,
                PatientId = visitRow.PatientId,
                Clinic = visitRow.Clinic,
                DoctorFirstName = doctorRow.FirstName,
                DoctorLastName = doctorRow.LastName

            }).Join(clinicDataSet.Patients, visitRow => visitRow.PatientId, patientRow => patientRow.Id, (visitRow, patientRow) => new VisitForGrid
            {
                BillingNumber = visitRow.BillingNumber,
                Room = visitRow.Room,
                Bed = visitRow.Bed,
                ClinicName = visitRow.Clinic,
                DoctorFirstName = visitRow.DoctorFirstName,
                DoctorLastName = visitRow.DoctorLastName,
                PatientFirstName = patientRow.FirstName,
                PatientLastName = patientRow.LastName
            }).ToArray());

            return visitList;
        }
    }
}
