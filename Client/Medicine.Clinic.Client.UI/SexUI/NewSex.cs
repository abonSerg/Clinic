using System;
using System.Windows.Forms;
using Medicine.Clinic.Client.Presentation;
using System.Xml.Linq;
using System.IO;
using System.Text;

namespace Medicine.Clinic.Client.UI
{
    public partial class NewSex : Form, INewSexView, INewSexEditView
    {
        public event EventHandler NewSexEditLoad;
        public event EventHandler NewOkClick;
        public event EventHandler EditOkClick;     

        private bool isEditView = false;
        private string address;

        public string ResultMessage { get; set; }

        public bool OkEnabled { set { buttonOk.Enabled = value; } }

        public string NewSexViewCode
        {
            get { return textBoxCode.Text; }
            set { textBoxCode.Text = value; }
        }

        public string NewSexViewName
        {
            get { return textBoxName.Text; }
            set { textBoxName.Text = value; }
        }
      
        public NewSex()
        {
            InitializeComponent();
            LoadSettings();
        }

        public NewSex(bool isEditView)
        {
            InitializeComponent();
            LoadSettings();
            this.isEditView = isEditView;
        }

        private void LoadSettings() 
        {
            address = "ViewsXmlSettingNewSexViewXmlSetting.xml";
            ResultMessage = layoutControlNewSex.LoadFormSettings(address);
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
        

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void NewSex_Load(object sender, EventArgs e)
        {
            if (isEditView && (NewSexEditLoad != null))
            {
                Text = "Edit Sex";
                textBoxCode.Enabled = false;
                NewSexEditLoad(sender, e);
            }
            else
            {
                Text = "Add Sex";
            }
        }

        private void NewSex_FormClosed(object sender, FormClosedEventArgs e)
        {
            ResultMessage = string.Empty;
            ResultMessage = layoutControlNewSex.SaveFormSettings(address);
            if (!string.IsNullOrEmpty(ResultMessage))
            {
                MessageBox.Show(ResultMessage, "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }
    }
}
