using System;
using System.ComponentModel;
using System.Windows.Forms;
using Medicine.Clinic.Client.Presentation;
using Medicine.Clinic.Client.Model.PatientService;
using System.Xml.Linq;
using System.IO;
using System.Text;

namespace Medicine.Clinic.Client.UI
{
    public partial class Patient : Form, IPatientView
    {
        public event EventHandler SearchClick ;
        public event EventHandler ClearClick;
        public event EventHandler LoadForm;

        private string address;
        private string resultMessage;

        public string PatientViewSearchSsn
        {
            get { return maskedTextBoxSsn.Text; }
            set { maskedTextBoxSsn.Text = value; }
        }

        public string PatientViewSearchMrn
        {
            get { return textBoxMrn.Text; }
            set { textBoxMrn.Text = value; }
        }

        public string PatientViewSearchFirstName
        {
            get { return textBoxFirstName.Text; }
            set { textBoxFirstName.Text = value; }
        }

        public string PatientViewSearchLastName
        {
            get { return textBoxLastName.Text; }
            set { textBoxLastName.Text = value; }
        }

        public string PatientViewSearchMiddleName
        {
            get { return textBoxMiddleName.Text; }
            set { textBoxMiddleName.Text = value; }
        }

        public BindingList<DtoPatient> PatientViewGridControlData { set { gridControlPatients.DataSource = value; } }
   
        public Patient()
        {
            InitializeComponent();
            Name = FormEnum.Patient.ToString();
            address = "ViewsXmlSettingPatientViewXmlSetting.xml";
            resultMessage = layoutControlPatient.LoadFormSettings(address);
            if (!string.IsNullOrEmpty(resultMessage))
            {
                MessageBox.Show(resultMessage, "Configuration file absent", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        private void Patient_Load(object sender, EventArgs e)
        {
            if (LoadForm != null) 
            {
                LoadForm(sender, e);
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            SearchClick(sender, e);
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            if (ClearClick != null) 
            {
                ClearClick(sender, e);
                textBoxFirstName.Clear();
                textBoxLastName.Clear();
                textBoxMiddleName.Clear();
                textBoxMrn.Clear();
                maskedTextBoxSsn.Clear();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            NewPatient newPatient = new NewPatient();
            var newPatientPresenter = new NewPatientPresenter(newPatient);
            newPatient.ShowDialog();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            bool isEditView = true;
            var  newPatientEdit = new NewPatient(isEditView);
            var newPatientEditPresenter = new NewPatientEditPresenter(newPatientEdit,(DtoPatient)gridView1.GetFocusedRow());
            newPatientEdit.ShowDialog();
        }

        private void buttonNewVisit_Click(object sender, EventArgs e)
        {
            var newVisit = new NewVisit();
            var newVisitPresenter = new NewVisitPresenter(newVisit);
            newVisit.ShowDialog();
        }

        private void gridControlPatients_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                buttonEdit_Click(sender, e);
            }
        }

        private void Patient_FormClosed(object sender, FormClosedEventArgs e)
        {
            resultMessage = string.Empty;
            resultMessage = layoutControlPatient.SaveFormSettings(address);
            if (!string.IsNullOrEmpty(resultMessage))
            {
                MessageBox.Show(resultMessage, "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }
    }
}
