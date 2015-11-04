using System;
using System.ComponentModel;
using System.Windows.Forms;
using Medicine.Clinic.Client.Presentation;
using Medicine.Clinic.Client.Model.DoctorService;
using System.Xml.Linq;
using System.IO;
using System.Text;

namespace Medicine.Clinic.Client.UI
{
    public partial class Doctor : Form, IDoctorView
    {
        public event EventHandler SearchClick;
        public event EventHandler ClearClick;
        public event EventHandler LoadForm;

        private string address;
        private string resultMessage;
        private Main mainView;

        public string DoctorViewSearchCode
        {
            get { return textBoxCode.Text; }
            set { textBoxCode.Text = value; }
        }

        public string DoctorViewSearchFirstName
        {
            get { return textBoxFirstName.Text; }
            set { textBoxFirstName.Text = value; }
        }

        public string DoctorViewSearchLastName
        {
            get { return textBoxLastName.Text; }
            set { textBoxLastName.Text = value; }
        }

        public BindingList<DtoDoctor> DoctorViewGridControlData { set { gridControlDoctors.DataSource = value; } }
   
        public Doctor(Main mainView)
        {
            InitializeComponent();
            Name = FormEnum.Doctor.ToString();
            address = "ViewsXmlSettingDoctorViewXmlSetting.xml";
            resultMessage = layoutControlDoctor.LoadFormSettings(address);
            if (!string.IsNullOrEmpty(resultMessage))
            {
                MessageBox.Show(resultMessage, "Configuration file absent", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            this.mainView = mainView;
        }

        private void Doctor_Load(object sender, EventArgs e)
        {
            if (LoadForm != null) 
            {
                LoadForm(sender, e);
            }
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

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            var newDoctor = new NewDoctor();
            var newDoctorPresenter = new NewDoctorPresenter(newDoctor);
            newDoctor.ShowDialog();
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            bool isEditView = true;
            var newDoctorEdit = new NewDoctor(isEditView);
            var newDoctorEditPresenter = new NewDoctorEditPresenter(newDoctorEdit, (DtoDoctor)gridView1.GetFocusedRow());
            newDoctorEdit.ShowDialog();

        }

        private void Doctor_FormClosed(object sender, FormClosedEventArgs e)
        {
            resultMessage = string.Empty;
            resultMessage = layoutControlDoctor.SaveFormSettings(address);
            if (!string.IsNullOrEmpty(resultMessage))
            {
                MessageBox.Show(resultMessage, "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }
    }
}
