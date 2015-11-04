using System;
using System.ComponentModel;
using System.Windows.Forms;
using Medicine.Clinic.Client.Model.OrderService;
using Medicine.Clinic.Client.Presentation;
using System.Xml.Linq;
using System.IO;
using System.Text;

namespace Medicine.Clinic.Client.UI
{
    public partial class Order : Form, IOrderView
    {
        public event EventHandler SearchClick;
        public event EventHandler ClearClick;
        public event EventHandler LoadForm;

        private Main mainView;
        private string address;
        private string resultMessage;

        public string ViewSearchName
        {
            get { return textBoxOrderNumber.Text; }
            set { textBoxOrderNumber.Text = value; }
        }

        public string ViewSearchCode
        {
            get { return textBoxBillingNumber.Text; }
            set { textBoxBillingNumber.Text = value; }
        }

        public BindingList<DtoOrder> OrderViewGridControlData { set { gridControlOrders.DataSource = value; } }

        public Order(Main mainView)
        {
            InitializeComponent();
            Name = FormEnum.Order.ToString();
            address = "ViewsXmlSettingOrderViewXmlSetting.xml";
            resultMessage = layoutControlOrder.LoadFormSettings(address);
            if (!string.IsNullOrEmpty(resultMessage))
            {
                MessageBox.Show(resultMessage, "Configuration file absent", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            this.mainView = mainView;
        }

        private void Order_Load(object sender, EventArgs e)
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

        private void buttonNew_Click(object sender, EventArgs e)
        {
            if (!FormBuilder.IsFormUnique(mainView, FormEnum.Visit))
            {
                var visit = new Visit();
                var VisitPresenter = new VisitPresenter(visit);
                visit.MdiParent = mainView;
                visit.Show();
            }
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            var  newOrderEdit = new NewOrder(true);
            var newOrderEditPresenter = new NewOrderEditPresenter(newOrderEdit, (DtoOrder)gridView1.GetFocusedRow());
            newOrderEdit.ShowDialog();
        }

        private void Order_FormClosed(object sender, FormClosedEventArgs e)
        {
            resultMessage = string.Empty;
            resultMessage = layoutControlOrder.SaveFormSettings(address);
            if (!string.IsNullOrEmpty(resultMessage))
            {
                MessageBox.Show(resultMessage, "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
