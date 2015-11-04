using System;
using System.ComponentModel;
using System.Windows.Forms;
using Medicine.Clinic.Client.Presentation;
using Medicine.Clinic.Client.Model.TubeService;
using System.Xml.Linq;
using System.IO;
using System.Text;

namespace Medicine.Clinic.Client.UI
{
    public partial class NewSpecimen : Form, INewSpecimenView, INewSpecimenEditView
    {
        public event EventHandler NewSpecimenEditLoad;
        public event EventHandler EditOkClick;
        public event EventHandler NewOkClick;

        private bool isEditView = false;
        private string address;

        public BindingList<DtoTube> NewSpecimenDefaultTubes { set { lookUpEditDefaultTube.Properties.DataSource = value; } }

        public bool OkEnabled { set { buttonOk.Enabled = value; } }

        public string NewSpecimenEditDefaultTubeCode
        {
            set { lookUpEditDefaultTube.EditValue = value; }
            get { return (string)lookUpEditDefaultTube.EditValue; }
        }

        public string ResultMessage { get; set; }

        public string NewSpecimenViewCode
        { 
            get { return textBoxCode.Text; }
            set { textBoxCode.Text = value; }
        }

        public string NewSpecimenViewName
        {
            get { return textBoxName.Text; }
            set { textBoxName.Text = value; }
        }

        public NewSpecimen()
        {
           InitializeComponent();
           LoadSettings();
        }

        public NewSpecimen(bool isEditView)
        {
            this.isEditView = isEditView;
            InitializeComponent();
            LoadSettings();
        }

        private void LoadSettings()
        {
            address = "ViewsXmlSettingNewSpecimentViewXmlSetting.xml";
            ResultMessage = layoutControlNewSpecimen.LoadFormSettings(address);
            if (!string.IsNullOrEmpty(ResultMessage))
            {
                MessageBox.Show(ResultMessage, "Configuration file absent", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
       
        private void NewSpecimen_Load(object sender, EventArgs e)
        {
            if (isEditView && (NewSpecimenEditLoad != null))
            {
                Text = "Edit Specimen";
                textBoxCode.Enabled = false;
                NewSpecimenEditLoad(sender, e);
            }
            else 
            {
                Text = "Add Specimen";
            }
        }
               
        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (isEditView && (EditOkClick != null))
            {
                EditOkClick(sender, e);
                MessageBox.Show(ResultMessage);
            }
            else if (NewOkClick != null) 
            {
                NewOkClick(sender, e);
                MessageBox.Show(ResultMessage);
                
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void NewSpecimen_FormClosed(object sender, FormClosedEventArgs e)
        {
            ResultMessage = string.Empty;
            ResultMessage = layoutControlNewSpecimen.SaveFormSettings(address);
            if (!string.IsNullOrEmpty(ResultMessage))
            {
                MessageBox.Show(ResultMessage, "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }
    }
}
