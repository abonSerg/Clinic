using System;
using System.Data;
using System.Windows.Forms;
using Medicine.Clinic.Client.Presentation;
using System.Xml.Linq;
using System.IO;
using System.Text;
using ClinicDataSetAccess;
using Medicine.Clinic.Client.Model.GridControlsEntities;
using System.ComponentModel;

namespace Medicine.Clinic.Client.UI
{
    public partial class Visit : Form, IVisitView
    {
        public event EventHandler SearchClick;
        public event EventHandler ClearClick;
        public event EventHandler LoadForm;

        private string address;
        private string resultMessage;

        public string VisitViewSearchMrn
        {
            get { return textBoxMrn.Text; }
            set { textBoxMrn.Text = value; }
        }

        public string VisitViewSearchFirstName
        {
            get { return textBoxPatientFirstName.Text; }
            set { textBoxPatientFirstName.Text = value; }
        }

        public string VisitViewSearchBillingNumber
        {
            get { return textBoxBillingNumber.Text; }
            set { textBoxBillingNumber.Text = value; }
        }

        public BindingList<VisitForGrid> VisitViewGridControlData { set { gridControlVisits.DataSource = value; } }

        public Visit()
        {
            InitializeComponent();
            Name = FormEnum.Visit.ToString();
            address = "ViewsXmlSettingVisitViewXmlSetting.xml";
            resultMessage = layoutControlVisit.LoadFormSettings(address);
            if (!string.IsNullOrEmpty(resultMessage))
            {
                MessageBox.Show(resultMessage, "Configuration file absent", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void Visit_Load(object sender, EventArgs e)
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
                textBoxMrn.Clear();
                textBoxPatientFirstName.Clear();
                textBoxBillingNumber.Clear();
            }
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            bool isEditView = true;
            var newVisitEdit = new NewVisit(isEditView);
            var newVisitEditPresenter = new NewVisitEditPresenter(newVisitEdit, (VisitForGrid)gridViewVisits.GetFocusedRow());
            newVisitEdit.Show();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            var newVisit = new NewVisit();
            var newVisitPresenter = new NewVisitPresenter(newVisit);
            newVisit.ShowDialog();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonAddOrder_Click(object sender, EventArgs e)
        {
            var newOrder = new NewOrder();
            VisitForGrid focusedVisit = (VisitForGrid)gridViewVisits.GetFocusedRow();
            var newOrderPresenter = new NewOrderPresenter(newOrder, focusedVisit.BillingNumber);
            newOrder.ShowDialog();
        }

        private void Visit_FormClosed(object sender, FormClosedEventArgs e)
        {
            resultMessage = string.Empty;
            resultMessage = layoutControlVisit.SaveFormSettings(address);
            if (!string.IsNullOrEmpty(resultMessage))
            {
                MessageBox.Show(resultMessage, "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }
    }
}
