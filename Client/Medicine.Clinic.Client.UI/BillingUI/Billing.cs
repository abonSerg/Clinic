using Medicine.Clinic.Client.Presentation;
using System;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using DtoOrder = Medicine.Clinic.Client.Model.OrderService.DtoOrder;
using DtoConcreteTest = Medicine.Clinic.Client.Model.TestService.DtoConcreteTest;
using Medicine.Clinic.Client.Model.GridControlsEntities;
using Medicine.Clinic.Client.Model;

namespace Medicine.Clinic.Client.UI
{
    public partial class Billing : Form, IBillingView
    {
        public event EventHandler SearchClick;
        public event EventHandler ClearClick;
        public event EventHandler LoadForm;
        public event EventHandler LoadOrdersClick;

        private string address;
        private string resultMessage;

        public void SetModel(IBillingModel billingModel)
        {
            textBoxBillingNumber.DataBindings.Add(new Binding("Text", billingModel, "SearchBillingNumber"));
            labelStatus.DataBindings.Add(new Binding("Text", billingModel, "TotalCost"));
        }

        public BindingList<VisitForGrid> BillingViewVisitsGridControlData { set { gridControlVisits.DataSource = value; } }

        public VisitForGrid BillingViewVisitsFocuseGrid { get { return (VisitForGrid)gridView1.GetFocusedRow(); } }

        public BindingList<DtoOrder> BillingViewOrdersGridControlData { set { gridControlOrders.DataSource = value; } }

        public BindingList<DtoConcreteTest> BillingViewTestsGridControlData { set { gridControlTests.DataSource = value; } }

        public Billing()
        {
            InitializeComponent();
            Name = FormEnum.Billing.ToString();
            address = "ViewsXmlSettingBillingViewXmlSetting.xml";
            resultMessage = layoutControlBilling.LoadFormSettings(address);
            if (!string.IsNullOrEmpty(resultMessage))
            {
                MessageBox.Show(resultMessage, "Configuration file absent", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                textBoxBillingNumber.Clear();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Billing_Load(object sender, EventArgs e)
        {
            if (LoadForm != null) 
            {
                LoadForm(sender, e);
            }
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            if (LoadOrdersClick != null) 
            {
                LoadOrdersClick(sender, e);
            }
        }

        private void Billing_FormClosed(object sender, FormClosedEventArgs e)
        {
            resultMessage = string.Empty;
            resultMessage = layoutControlBilling.SaveFormSettings(address);
            if (!string.IsNullOrEmpty(resultMessage))
            {
                MessageBox.Show(resultMessage, "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }
    }
}
