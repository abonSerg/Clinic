using System;
using System.Windows.Forms;
using Medicine.Clinic.Client.Presentation;
using System.Xml.Linq;
using System.IO;
using System.Text;

namespace Medicine.Clinic.Client.UI
{
    public partial class NewDiagnosis : Form, INewDiagnosisView, INewDiagnosisEditView
    {
        public event EventHandler NewDiagnosisEditLoad;
        public event EventHandler NewOkClick;
        public event EventHandler EditOkClick;     

        private bool isEditView = false;

        public string ResultMessage { get; set; }

        public bool OkEnabled { set { buttonOk.Enabled = value; } }

        public string NewDiagnosisViewCode
        {
            get { return textBoxCode.Text; }
            set { textBoxCode.Text = value; }
        }

        public string NewDiagnosisViewName
        {
            get { return textBoxName.Text; }
            set { textBoxName.Text = value; }
        }
          
        public NewDiagnosis()
        {
            InitializeComponent();
            LoadSettings();
        }

        public NewDiagnosis(bool isEditView)
        {
            InitializeComponent();
            LoadSettings();
            this.isEditView = isEditView;
        }

        private void LoadSettings()
        {
            //try
            //{
            //    string xmlSettings = XDocument.Load("ViewsXmlSetting/NewDiagnosisViewXmlSetting.xml").ToString();
            //    layoutControlNewDiagnosis.SetLayoutXml(xmlSettings);
            //}
            //catch (Exception)
            //{
            //}

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
        

        private void NewDiagnosis_Load(object sender, EventArgs e)
        {
            if (isEditView)
            {
                Text = "Edit Diagnosis";
                textBoxCode.Enabled = false;
                if (NewDiagnosisEditLoad != null) 
                {
                    NewDiagnosisEditLoad(sender, e);
                }
            }
            else
            {
                Text = "Add Diagnosis";
            }
        }

        private void NewDiagnosis_FormClosed(object sender, FormClosedEventArgs e)
        {
            //string address = "ViewsXmlSetting/NewDiagnosisViewXmlSetting.xml";
            //if (!new FileInfo(address).Exists)
            //{
            //    new XDocument(new XElement("root", new XElement("someNode", "someValue"))).Save(address);
            //}
            //try
            //{
            //    File.WriteAllText(address, layoutControlNewDiagnosis.GetLayoutXml(), Encoding.ASCII);
            //}
            //catch (Exception) { };
        }
    }
}
