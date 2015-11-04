using System;
using System.ComponentModel;
using System.Windows.Forms;
using Medicine.Clinic.Client.Model.SpecimenService;
using Medicine.Clinic.Client.Presentation;
using Medicine.Clinic.Client.Model.SexService;
using System.Xml.Linq;
using System.IO;
using System.Text;

namespace Medicine.Clinic.Client.UI
{
    public partial class NewTest : Form, INewTestEditView, INewTestView
    {
        public event EventHandler NewTestEditLoad;
        public event EventHandler EditOkClick;
        public event EventHandler NewOkClick;

        private string address;
        private bool isEditView = false;

        public BindingList<DtoSpecimen> NewTestDefaultSpecimens { set { lookUpEditDefaultSpecimen.Properties.DataSource = value; } }

        public string DefaultSpecimenCode
        {
            get { return (string)lookUpEditDefaultSpecimen.EditValue; }
            set { lookUpEditDefaultSpecimen.EditValue = value; }
        }

        public string ResultMessage { get; set; }

        public BindingList<DtoSex> NewTestSexList { set { checkedComboBoxEditSexAllowed.Properties.DataSource= value; }}

        public string CheckedTestSexAllowed { set { checkedComboBoxEditSexAllowed.EditValue = value; } }

        public string CheckedSexes { get { return (string)checkedComboBoxEditSexAllowed.EditValue; } }

        public bool OkEnabled { set { buttonOk.Enabled = value; } }

        public string NewTestViewCode
        { 
            get { return textBoxCode.Text; }
            set { textBoxCode.Text = value; }
        }

        public string NewTestViewName
        {
            get { return textBoxName.Text; }
            set { textBoxName.Text = value; }
        }

        public string NewTestViewCost
        {
            get { return textBoxCost.Text; }
            set { textBoxCost.Text = value; }
        }

        public NewTest()
        {
           InitializeComponent();
           LoadSettings();
        }

        public NewTest(bool isEditView)
        {
            this.isEditView = isEditView;
            InitializeComponent();
            LoadSettings();
        }

        private void LoadSettings()
        {
            address = "ViewsXmlSettingNewTestViewXmlSetting.xml";
            ResultMessage = layoutControlNewTest.LoadFormSettings(address);
            if (!string.IsNullOrEmpty(ResultMessage))
            {
                MessageBox.Show(ResultMessage, "Configuration file absent", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        
        private void NewTest_Load(object sender, EventArgs e)
        {
            if (isEditView && (NewTestEditLoad != null))
            {
                Text = "Edit Test";
                textBoxCode.Enabled = false;
                NewTestEditLoad(sender, e);
            }
            else 
            {
                Text = "Add Test";
            }
        }
               
        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (isEditView && (EditOkClick!= null))
            {
                EditOkClick(sender, e);
                MessageBox.Show(ResultMessage);
            }
            else if( NewOkClick != null)
            {
                NewOkClick(sender, e);
                MessageBox.Show(ResultMessage);
            } 
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBoxCost_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == '.' && textBoxCost.Text.IndexOf('.') != -1)
            {
                e.Handled = true;
                return;
            }
            if (!Char.IsDigit(ch) && ch != '.' && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void NewTest_FormClosed(object sender, FormClosedEventArgs e)
        {
            ResultMessage = string.Empty;
            ResultMessage = layoutControlNewTest.SaveFormSettings(address);
            if (!string.IsNullOrEmpty(ResultMessage))
            {
                MessageBox.Show(ResultMessage, "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

    }
}
