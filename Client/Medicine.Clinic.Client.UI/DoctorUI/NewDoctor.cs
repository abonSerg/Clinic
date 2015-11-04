using System;
using System.ComponentModel;
using System.Windows.Forms;
using Medicine.Clinic.Client.Presentation;
using Medicine.Clinic.Client.Model.ClinicService;
using System.Xml.Linq;
using System.IO;
using System.Text;

namespace Medicine.Clinic.Client.UI
{
    public partial class NewDoctor : Form, INewDoctorView, INewDoctorEditView
    {
        public event EventHandler NewDoctorEditLoad;
        public event EventHandler EditOkClick;
        public event EventHandler NewOkClick;

        private bool isEditView = false;
        private string address;

        public BindingList<DtoClinic> NewDoctorClinics { set { this.lookUpEditClinic.Properties.DataSource = value; } }

        public string NewDoctorEditClinicCode { set { lookUpEditClinic.EditValue = value; } }

        public string ClinicFocusedValue { get { return (string)lookUpEditClinic.EditValue; } }

        public string ResultMessage { get; set; }

        public bool OkEnabled { set { buttonOk.Enabled = value; } }

        public string NewDoctorViewCode
        { 
            get { return this.textBoxCode.Text; }
            set { this.textBoxCode.Text = value; }
        }

        public string NewDoctorViewFirstName
        {
            get { return this.textBoxFirstName.Text; }
            set { this.textBoxFirstName.Text = value; }
        }

        public string NewDoctorViewLastName
        {
            get { return this.textBoxLastName.Text; }
            set { this.textBoxLastName.Text = value; }
        }

        public string NewDoctorViewMiddleName
        {
            get { return this.textBoxMiddleName.Text; }
            set { this.textBoxMiddleName.Text = value; }
        }

        public NewDoctor()
        {
           InitializeComponent();
           LoadSettings();
        }

        public NewDoctor(bool isEditView)
        {
            this.isEditView = isEditView;
            InitializeComponent();
            LoadSettings();
        }

        private void LoadSettings()
        {
            address = "ViewsXmlSettingNewDoctorViewXmlSetting.xml";
            ResultMessage = layoutControlNewDoctor.LoadFormSettings(address);
            if (!string.IsNullOrEmpty(ResultMessage))
            {
                MessageBox.Show(ResultMessage, "Configuration file absent", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }
       
        private void NewDoctor_Load(object sender, EventArgs e)
        {
            if (isEditView)
            {
                if (NewDoctorEditLoad != null) 
                {
                    this.Text = "Edit Doctor";
                    this.textBoxCode.Enabled = false;
                    NewDoctorEditLoad(sender, e);
                }
            }
            else 
            {
                this.Text = "Add Doctor";
            }
        }
               
        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (isEditView)
            {
                if (EditOkClick != null) 
                {
                    EditOkClick(sender, e);
                    MessageBox.Show(ResultMessage);
                }
            }
            else 
            {
                if (NewOkClick != null) 
                {
                    NewOkClick(sender, e);
                    MessageBox.Show(ResultMessage);
                }
            }
        }

        private void NewDoctor_FormClosed(object sender, FormClosedEventArgs e)
        {
            //string address = "ViewsXmlSetting/NewDoctorViewXmlSetting.xml";
            //if (!new FileInfo(address).Exists)
            //{
            //    new XDocument(new XElement("root", new XElement("someNode", "someValue"))).Save(address);
            //}
            //try
            //{
            //    File.WriteAllText(address, layoutControlNewDoctor.GetLayoutXml(), Encoding.ASCII);
            //}
            //catch (Exception) { };
        }
    }
}
