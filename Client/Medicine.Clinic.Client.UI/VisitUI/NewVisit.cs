using System;
using System.Data;
using System.Windows.Forms;
using Medicine.Clinic.Client.Presentation;
using System.Xml.Linq;
using System.IO;
using System.Text;
using Medicine.Clinic.Client.Model.GridControlsEntities;
using System.ComponentModel;

namespace Medicine.Clinic.Client.UI
{
    public partial class NewVisit : Form, INewVisitView, INewVisitEditView
    {
        public event EventHandler NewOkClick;
        public event EventHandler NewVisitEditLoad;
        public event EventHandler NewOkEditClick;
        public event EventHandler ApartmentChoose;

        private bool isEditView = false;
        private string address;

        public BindingList<PatientForGrid> NewVisitPatients { set { lookUpEditPatient.Properties.DataSource = value; } }

        public BindingList<DoctorForGrid> NewVisitDoctors { set { lookUpEditDoctor.Properties.DataSource = value; } }

        public BindingList<ApartmentForGrid> NewVisitApartments { set { lookUpEditApartment.Properties.DataSource = value; } }

        public bool OkEnabled { set { buttonOk.Enabled = value; } }

        public string PatientFocusedRow
        {
            get { return (string)lookUpEditPatient.EditValue; }
            set { lookUpEditPatient.EditValue = value; }
        }
        public string DoctorFocusedRow
        {
            get { return (string)lookUpEditDoctor.EditValue; }
            set { lookUpEditDoctor.EditValue = value; }
        }
        public int ApartmentFocusedRow
        {
            get { return (int)lookUpEditApartment.EditValue; }
            set { lookUpEditApartment.EditValue = value; }
        }

        public string NewVisitBillingNumber 
        {
            get { return textBoxBilling.Text;}
            set { textBoxBilling.Text = value; }
        }
        public string ResultMessage { get; set; }

        public NewVisit()
        {
            InitializeComponent();
            LoadSettings();
        }

        public NewVisit(bool isEditView)
        {
            this.isEditView = isEditView;
            InitializeComponent();
            LoadSettings();
        }

        private void LoadSettings()
        {
            address = "ViewsXmlSettingNewVisitViewXmlSetting.xml";
            ResultMessage = layoutControlNewVisit.LoadFormSettings(address);
            if (!string.IsNullOrEmpty(ResultMessage))
            {
                MessageBox.Show(ResultMessage, "Configuration file absent", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

       
        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (isEditView && (NewOkClick != null))
            {
                NewOkEditClick(sender, e);
                MessageBox.Show(ResultMessage);
            }
            else if(NewOkClick != null)
            {
                NewOkClick(sender, e);
                MessageBox.Show(ResultMessage);
            }
        }

        private void NewVisit_Load(object sender, EventArgs e)
        {
            if (isEditView && ( NewVisitEditLoad != null))
            {
                Text = "Edit Visit";
                buttonOk.Text = "Save Changes";
                NewVisitEditLoad(sender, e);
            }
            else 
            {
                Text = "New Visit";
                buttonAddOrder.Enabled = false;
            }
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            NewOrder newOrder = new NewOrder();
            var newOrderPresenter = new NewOrderPresenter(newOrder, NewVisitBillingNumber);
            newOrder.ShowDialog();
        }

        private void lookUpEditApartment_EditValueChanged(object sender, EventArgs e)
        {
            if (ApartmentChoose != null) 
            {
                ApartmentChoose(sender, e);
            }
        }

        private void NewVisit_FormClosed(object sender, FormClosedEventArgs e)
        {
            ResultMessage = string.Empty;
            ResultMessage = layoutControlNewVisit.SaveFormSettings(address);
            if (!string.IsNullOrEmpty(ResultMessage))
            {
                MessageBox.Show(ResultMessage, "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }
    }
}
