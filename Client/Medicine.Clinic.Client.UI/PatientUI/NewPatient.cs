using System;
using System.ComponentModel;
using System.Windows.Forms;
using Medicine.Clinic.Client.Presentation;
using Medicine.Clinic.Client.Model.SexService;
using System.Xml.Linq;
using System.IO;
using System.Text;

namespace Medicine.Clinic.Client.UI
{
    public partial class NewPatient : Form, INewPatientView, INewPatientEditView
    {
        public event EventHandler NewPatientEditLoad;
        public event EventHandler NewPatientEditSwitch;
        public event EventHandler EditOkClick;
        public event EventHandler NewOkClick;

        private bool isEditView = false;
        private bool isReadyToEdit = false;
        private string address;

        public BindingList<DtoSex> NewPatientSexes { set { lookUpEditSex.Properties.DataSource = value; } }
        public string NewPatientEditSexCode
        {
            get { return (string)lookUpEditSex.EditValue; }
            set { lookUpEditSex.EditValue = value; }
        }
                                                
        public DtoSex SexFocusedRow { get { return (DtoSex)lookUpEditSex.GetSelectedDataRow(); } }

        public string ResultMessage { get; set; }

        public bool OkEnabled { set { buttonOk.Enabled = value; } }

        public bool NewPatientVievMrnIsReadOnly { set { textBoxMrn.ReadOnly = value; } }

        public bool NewPatientVievFirstNameIsReadOnly { set { textBoxFirstName.ReadOnly = value; } }

        public bool NewPatientVievLastNameIsReadOnly { set { textBoxLastName.ReadOnly = value; } }

        public bool NewPatientVievMiddleNameIsReadOnly { set { textBoxMiddleName.ReadOnly = value; } }

        public bool NewPatientVievSsnIsReadOnly { set { maskedTextBoxSsn.ReadOnly = value; } }

        public bool NewPatientVievDobIsReadOnly { set { dateEditDob.Properties.ReadOnly = value; } }

        public bool NewPatientVievSexIsReadOnly { set { lookUpEditSex.Properties.ReadOnly = value; } }

        public bool NewPatientVievDodIsReadOnly { set { dateEditDod.Properties.ReadOnly = value; } }

        public string NewPatientAge { set { label10.Text = value; } }

        public bool IsSsnFull { get { return maskedTextBoxSsn.MaskFull; } }
         
        public string NewPatientViewMrn
        {
            get { return textBoxMrn.Text; }
            set { textBoxMrn.Text = value; }
        }
        public string NewPatientViewFirstName
        {
            get { return textBoxFirstName.Text; }
            set { textBoxFirstName.Text = value; }
        }
        public string NewPatientViewLastName
        {
            get { return textBoxLastName.Text; }
            set { textBoxLastName.Text = value; }
        }
        public string NewPatientViewMiddleName
        {
            get { return textBoxMiddleName.Text; }
            set { textBoxMiddleName.Text = value; }
        }

        public string NewPatientViewSsn
        {
            get { return maskedTextBoxSsn.Text; }
            set { maskedTextBoxSsn.Text = value; }
        }

        public DateTime NewPatientViewDob
        {
            get { return dateEditDob.DateTime; }
            set { dateEditDob.DateTime = value; }
        }

        public DateTime? NewPatientViewDod
        {
            get { return dateEditDod.DateTime; }
            set
            {
                if (value != null) 
                {
                    dateEditDod.DateTime = (DateTime)value;
                }
            }
        }
       
        public NewPatient()
        {
            InitializeComponent();
            LoadSettings();
        }

        public NewPatient(bool isEditView)
        {
            InitializeComponent();
            LoadSettings();
            this.isEditView = isEditView;
        }

        private void LoadSettings()
        {
            address = "ViewsXmlSettingNewPatientViewXmlSetting.xml";
            ResultMessage = layoutControlNewPatient.LoadFormSettings(address);
            if (!string.IsNullOrEmpty(ResultMessage))
            {
                MessageBox.Show(ResultMessage, "Configuration file absent", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (isEditView)
            {
                if (isReadyToEdit)
                {
                    if (EditOkClick != null) 
                    {
                        EditOkClick(sender, e);
                        MessageBox.Show(ResultMessage);
                    }
                }
                else 
                {
                    Close();
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

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (NewPatientEditSwitch != null) 
            {
                NewPatientEditSwitch(sender, e);
                isReadyToEdit = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void NewPatient_Load(object sender, EventArgs e)
        {
            if (isEditView && NewPatientEditLoad != null)
            {
                NewPatientEditLoad(sender, e);
            }
        }

        private void NewPatient_FormClosed(object sender, FormClosedEventArgs e)
        {
            ResultMessage = string.Empty;
            ResultMessage = layoutControlNewPatient.SaveFormSettings(address);
            if (!string.IsNullOrEmpty(ResultMessage))
            {
                MessageBox.Show(ResultMessage, "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }
    }
}
