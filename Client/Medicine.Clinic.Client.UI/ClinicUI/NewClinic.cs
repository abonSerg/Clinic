using System;
using System.Windows.Forms;
using Medicine.Clinic.Client.Presentation;
using System.Xml.Linq;
using System.IO;
using System.Text;

namespace Medicine.Clinic.Client.UI
{
    public partial class NewClinic : Form, INewClinicView, INewClinicEditView
    {
        public event EventHandler NewClinicEditLoad;
        public event EventHandler NewOkClick;
        public event EventHandler EditOkClick;     

        private bool isEditView = false;
        private string address;
  
        public string ResultMessage { get; set; }

        public bool OkEnabled { set { buttonOk.Enabled = value; } }

        public string NewClinicViewCode
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }

        public string NewClinicViewName
        {
            get { return textBox2.Text; }
            set { textBox2.Text = value; }
        }
        public string NewClinicViewAddress
        {
            get { return textBox3.Text; }
            set { textBox3.Text = value; }
        }   
       
        public NewClinic()
        {
            InitializeComponent();
            LoadSettings();
        }

        public NewClinic(bool isEditView)
        {
            InitializeComponent();
            LoadSettings();
            this.isEditView = isEditView;
        }

        private void LoadSettings()
        {
            address = "ViewsXmlSetting/NewClinicViewXmlSetting.xml";
            ResultMessage = layoutControlNewClinic.LoadFormSettings(address);
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
                if (NewOkClick != null) 
                {
                    NewOkClick(sender, e);
                    MessageBox.Show(ResultMessage);
                }
            }      
        }
        
        private void NewClinic_Load(object sender, EventArgs e)
        {
            if (isEditView)
            {
                this.Text = "Edit Clinic";
                this.textBox1.Enabled = false;
                if (NewClinicEditLoad != null)
                {
                    NewClinicEditLoad(sender, e);
                }
            }
        }

        private void NewClinic_FormClosed(object sender, FormClosedEventArgs e)
        {
            ResultMessage = string.Empty;
            ResultMessage = layoutControlNewClinic.SaveFormSettings(address);
            if (!string.IsNullOrEmpty(ResultMessage))
            {
                MessageBox.Show(ResultMessage, "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }
    }
}
