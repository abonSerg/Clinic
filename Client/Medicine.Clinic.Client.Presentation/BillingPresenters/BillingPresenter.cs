using Medicine.Clinic.Client.Model;
using System;
using System.ComponentModel;
using Medicine.Clinic.Client.Model.GridControlsEntities;
using System.IO;
using System.Xml.Serialization;
using Medicine.Clinic.Client.Model.VisitService;
using ClinicDataSetAccess;
using System.Linq;
using DtoOrder = Medicine.Clinic.Client.Model.OrderService.DtoOrder;
using DtoConcreteTest = Medicine.Clinic.Client.Model.TestService.DtoConcreteTest;
using Medicine.Clinic.Client.Model.OrderService;
using Medicine.Clinic.Client.Model.TestService;

namespace Medicine.Clinic.Client.Presentation
{
    public class BillingPresenter
    {
        readonly IBillingView billingView;
        readonly IBillingModel billingModel;
        private TestServiceClient testService;

        private TestServiceClient TestService
        {
            get
            {
                testService = testService ?? new TestServiceClient();
                return new TestServiceClient();
            }
        }

        public BillingPresenter(IBillingView billingView)
        {
            this.billingView = billingView;
            billingModel = new BillingModel();
            billingView.LoadForm += LoadVisits;
            billingView.SearchClick += LoadSearchedVisits;
            billingView.ClearClick += LoadVisits;
            billingView.LoadOrdersClick += LoadBilling;
            billingView.SetModel(billingModel);
        }

        private void LoadVisits(object sender, EventArgs e)
        {
            billingView.BillingViewVisitsGridControlData = SearchVisits(string.Empty);
        }

        private void LoadSearchedVisits(object sender, EventArgs e)
        {
            billingView.BillingViewVisitsGridControlData = SearchVisits(billingModel.SearchBillingNumber);
        }

        public void LoadBilling(object sender, EventArgs e)
        {
            billingView.BillingViewOrdersGridControlData =  new BindingList<DtoOrder>(new OrderServiceClient().GetOrdersByVisit(billingView.BillingViewVisitsFocuseGrid.BillingNumber));
            billingView.BillingViewTestsGridControlData = new BindingList<DtoConcreteTest>(TestService.GetConcreteTestsByVisit(billingView.BillingViewVisitsFocuseGrid.BillingNumber));
            billingModel.TotalCost = string.Format("Total cost: {0} $", TestService.GetTestsCostByVisit(billingView.BillingViewVisitsFocuseGrid.BillingNumber));
        }

        private BindingList<VisitForGrid> SearchVisits(string billingNumber)
        {
            string serializableString = new VisitServiceClient().SearchVisits(string.Empty, string.Empty, billingNumber);
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
