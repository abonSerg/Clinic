using System;
using System.ComponentModel;
using System.Windows.Forms;
using Medicine.Clinic.Client.Presentation;
using Medicine.Clinic.Client.Model.TubeService;
using Medicine.Clinic.Client.Model;
using System.Xml.Linq;
using System.IO;
using System.Text;

namespace Medicine.Clinic.Client.UI
{
    public partial class Tube : Form, ITubeView
    {
        public event EventHandler SearchClick;
        public event EventHandler ClearClick;
        public event EventHandler LoadForm;

        private string address;
        private string resultMessage;

        public BindingList<DtoTube> TubeViewGridControlData { set { gridControlTubes.DataSource = value; } }

        public void SetModel(ITubeModel tubeModel) 
        {
            textBoxSearchCode.DataBindings.Add(new Binding("Text", tubeModel, "SearchCode"));
            textBoxSearchName.DataBindings.Add(new Binding("Text", tubeModel, "SearchName"));
        }

        public Tube()
        {
            InitializeComponent();
            Name = FormEnum.Tube.ToString();
            address = "ViewsXmlSettingTubeViewXmlSetting.xml";
            resultMessage = layoutControlTube.LoadFormSettings(address);
            if (!string.IsNullOrEmpty(resultMessage))
            {
                MessageBox.Show(resultMessage, "Configuration file absent", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
                  
        private void buttonNew_Click(object sender, EventArgs e)
        {
            var newTube = new NewTube();
            var newTubePresenter = new NewTubePresenter(newTube);
            newTube.ShowDialog();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if (SearchClick != null) 
            {
                SearchClick(sender, e);
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            if (ClearClick != null)
            {
                ClearClick(sender, e);
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            bool isEditView = true;
            var newTubeEdit = new NewTube(isEditView);

            var newTubeEditPresenter = new NewTubePresenter(newTubeEdit, (DtoTube)gridView1.GetFocusedRow());
            newTubeEdit.Show();
        }

        private void Tube_Load(object sender, EventArgs e)
        {
            if (LoadForm != null)
            {
                LoadForm(sender, e);
            } 
        }

        private void Tube_FormClosed(object sender, FormClosedEventArgs e)
        {
            resultMessage = string.Empty;
            resultMessage = layoutControlTube.SaveFormSettings(address);
            if (!string.IsNullOrEmpty(resultMessage))
            {
                MessageBox.Show(resultMessage, "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
