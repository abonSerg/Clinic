using System;
using System.Windows.Forms;
using Medicine.Clinic.Client.Presentation;
using System.Xml.Linq;
using System.IO;
using System.Text;

namespace Medicine.Clinic.Client.UI
{
    public partial class NewIndication : Form, INewIndicationView, INewIndicationEditView
    {
        public event EventHandler NewIndicationEditLoad;
        public event EventHandler newOkClick;
        public event EventHandler EditOkClick;     

        private bool isEditView = false;
        private string address;

        public string ResultMessage { get; set; }

        public bool OkEnabled { set { buttonOk.Enabled = value; } }

        public string NewIndicationViewCode
        {
            get { return textBoxCode.Text; }
            set { this.textBoxCode.Text = value; }
        }

        public string NewIndicationViewName
        {
            get { return textBoxName.Text; }
            set { textBoxName.Text = value; }
        }
          
        public NewIndication()
        {
            InitializeComponent();
            LoadSettings();
        }

        public NewIndication(bool isEditView)
        {
            InitializeComponent();
            LoadSettings();
            this.isEditView = isEditView;
        }

        private void LoadSettings()
        {
            address = "ViewsXmlSettingNewIndicationViewXmlSetting.xml";
            ResultMessage = layoutControlNewIndication.LoadFormSettings(address);
            if (!string.IsNullOrEmpty(ResultMessage))
            {
                MessageBox.Show(ResultMessage, "Configuration file absent", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                if (newOkClick != null) 
                {
                    newOkClick(sender, e);
                    MessageBox.Show(ResultMessage);
                }
            }      
        }

        private void NewIndication_Load(object sender, EventArgs e)
        {
            if (isEditView)
            {
                if (NewIndicationEditLoad != null) 
                {
                    Text = "Edit Indication";
                    textBoxCode.Enabled = false;
                    NewIndicationEditLoad(sender, e);
                }
            }
            else
            {
                Text = "Add Indication";
            }
        }

        private void NewIndication_FormClosed(object sender, FormClosedEventArgs e)
        {
            ResultMessage = string.Empty;
            ResultMessage = layoutControlNewIndication.SaveFormSettings(address);
            if (!string.IsNullOrEmpty(ResultMessage))
            {
                MessageBox.Show(ResultMessage, "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }
    }
}
