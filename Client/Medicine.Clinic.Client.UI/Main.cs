using System;
using System.Windows.Forms;
using Medicine.Clinic.Client.Presentation;
using System.Linq;




namespace Medicine.Clinic.Client.UI
{
    public partial class Main : Form, IMainView
    {

        public Main()
        {
            InitializeComponent();
            menuStrip1.MdiWindowListItem = windowToolStripMenuItem;
        }

        public new void Show()
        {
            Application.Run(this);
 
        }

        private void tubeToolStripMenuItem_Click_3(object sender, EventArgs e)
        {
            if (!FormBuilder.IsFormUnique(this, FormEnum.Tube))
            {
                var tube = new Tube();
                var tubePresenter = new TubePresenter(tube);
                tube.MdiParent = this;
                tube.Show();
            }
        }

        private void clinicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FormBuilder.IsFormUnique(this, FormEnum.Clinic))
            {
                var clinic = new SetupForm(FormEnum.Clinic);
                var clinicPresenter = new ClinicPresenter(clinic);
                clinic.MdiParent = this;
                clinic.Show();   
            }
        }

        private void apecimenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FormBuilder.IsFormUnique(this, FormEnum.Specimen))
            {
                var specimen = new SetupForm(FormEnum.Specimen);
                var specimenPresenter = new SpecimenPresenter(specimen);
                specimen.MdiParent = this;
                specimen.Show();
            }
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FormBuilder.IsFormUnique(this, FormEnum.Test))
            {
                var test = new SetupForm(FormEnum.Test);
                var testPresenter = new TestPresenter(test);
                test.MdiParent = this;
                test.Show();
            }
        }

        private void sexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FormBuilder.IsFormUnique(this, FormEnum.Sex))
            {
                var sex = new SetupForm(FormEnum.Sex);
                var sexPresenter = new SexPresenter(sex);
                sex.MdiParent = this;
                sex.Show();
            }
        }

        private void doctorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FormBuilder.IsFormUnique(this, FormEnum.Doctor))
            {
                var doctor = new Doctor(this);
                var doctorPresenter = new DoctorPresenter(doctor);
                doctor.MdiParent = this;
                doctor.Show();
            }
        }

        private void diagnosisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FormBuilder.IsFormUnique(this, FormEnum.Diagnosis))
            {
                var diagnosis = new SetupForm(FormEnum.Diagnosis);
                var diagnosisPresenter = new DiagnosisPresenter(diagnosis);
                diagnosis.MdiParent = this;
                diagnosis.Show();
            }
        }

        private void indicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FormBuilder.IsFormUnique(this, FormEnum.Indication))
            {
                var indication = new SetupForm(FormEnum.Indication);
                var indicationPresenter = new IndicationPresenter(indication);
                indication.MdiParent = this;
                indication.Show();
            }
        }

        private void patientEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FormBuilder.IsFormUnique(this, FormEnum.Patient))
            {
                var patient = new Patient();
                var PatientPresenter = new PatientPresenter(patient);
                patient.MdiParent = this;
                patient.Show();
            }
        }

        private void orderEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FormBuilder.IsFormUnique(this, FormEnum.Order))
            {
                var order = new Order(this);
                var OrderPresenter = new OrderPresenter(order);
                order.MdiParent = this;
                order.Show();
            }
        }

        private void visitEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FormBuilder.IsFormUnique(this, FormEnum.Visit))
            {
                var visit = new Visit();
                var VisitPresenter = new VisitPresenter(visit);
                visit.MdiParent = this;
                visit.Show();
            }
        }

        private void resultEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FormBuilder.IsFormUnique(this, FormEnum.Interpretation))
            {
                var interpretation = new Interpretation();
                var InterpretationPresenter = new InterpretationPresenter(interpretation);
                interpretation.MdiParent = this;
                interpretation.Show();
            }
        }

        private void billingEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FormBuilder.IsFormUnique(this, FormEnum.Billing))
            {
                var billing = new Billing();
                var BillingPresenter = new BillingPresenter(billing);
                billing.MdiParent = this;
                billing.Show();
            } 
        }

        private void apartmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FormBuilder.IsFormUnique(this, FormEnum.Apartment))
            {
                var apartment = new Apartment();
                var ApartmentPresenter = new ApartmentPresenter(apartment);
                apartment.MdiParent = this;
                apartment.Show();
            } 
        }
    }
}
