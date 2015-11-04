using System;
using System.ComponentModel;
using System.Windows.Forms;
using Medicine.Clinic.Client.Model;
using Medicine.Clinic.Client.Presentation.ViewInterfaces;
using System.Xml.Linq;
using System.IO;
using System.Text;

namespace Medicine.Clinic.Client.UI
{
    public partial class NewTube : Form, INewTubeView, INewTubeEditView
    {
        public event EventHandler NewOkClick;  

        private bool isEditView = false;
        private string address;

        public string ResultMessage { get; set; }

        public NewTube()
        {
            InitializeComponent();
            LoadSettings();
        }

        public void SetModel(INewTubeModel newTubeModel)
        {
            textBoxCode.DataBindings.Add(new Binding("Text", newTubeModel, "Code"));
            textBoxName.DataBindings.Add(new Binding("Text", newTubeModel, "Name"));
            textBoxVolume.DataBindings.Add(new Binding("Text", newTubeModel, "Volume"));
            buttonOk.DataBindings.Add(new Binding("Enabled", newTubeModel, "OkEnabling"));
        }

        public NewTube(bool isEditView)
        {
            InitializeComponent();
            LoadSettings();
            this.isEditView = isEditView;
        }

        private void LoadSettings()
        {
            address = "ViewsXmlSettingNewTubeViewXmlSetting.xml";
            ResultMessage = layoutControlNewTube.LoadFormSettings(address);
            if (!string.IsNullOrEmpty(ResultMessage))
            {
                MessageBox.Show(ResultMessage, "Configuration file absent", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (NewOkClick != null)
            {
                NewOkClick(sender, e);
                MessageBox.Show(ResultMessage);
            }
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void NewTube_Load(object sender, EventArgs e)
        {
            if (isEditView)
            {
                this.Text = "Edit Tube";
                this.textBoxCode.ReadOnly = true;
            }
            else
            {
                this.Text = "Add Tube";
            }
        }

        private void textBoxVolume_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void NewTube_FormClosed(object sender, FormClosedEventArgs e)
        {
            ResultMessage = string.Empty;
            ResultMessage = layoutControlNewTube.SaveFormSettings(address);
            if (!string.IsNullOrEmpty(ResultMessage))
            {
                MessageBox.Show(ResultMessage, "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }      
    }
}
