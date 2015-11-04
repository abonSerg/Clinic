using System;
using System.ComponentModel;
using System.Windows.Forms;
using Medicine.Clinic.Client.Model.ApartmentService;
using Medicine.Clinic.Client.Presentation;
using System.Xml.Linq;
using System.Text;
using System.IO;

namespace Medicine.Clinic.Client.UI
{
    public partial class Apartment : Form, IApartmentView
    {
        public event EventHandler SearchClick;
        public event EventHandler ClearClick;
        public event EventHandler LoadForm;

        private string address;
        private string resultMessage;

        public string ApartmentViewSearchClinicName
        {
            get { return textBoxClinic.Text; }
            set { textBoxClinic.Text = value;}
        }
                     
        public BindingList<DtoApartment> ApartmentViewGridControlData
        {
            set { gridControlApartments.DataSource = value; }
        }

        public Apartment()
        {
            InitializeComponent();
            Name = FormEnum.Apartment.ToString();
            address = "ViewsXmlSettingApartmentViewXmlSetting.xml";
            resultMessage = layoutControlApartment.LoadFormSettings(address);
            if (!string.IsNullOrEmpty(resultMessage))
            {
                MessageBox.Show(resultMessage, "Configuration file absent", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void Apartment_Load(object sender, EventArgs e)
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
            textBoxClinic.Clear();
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            var newApartment = new NewApartment();
            var newApartmentPresenter = new NewApartmentPresenter(newApartment);
            newApartment.ShowDialog();
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            var newApartmentEdit = new NewApartment(true);
            var newApartmentEditPresenter = new NewApartmentEditPresenter(newApartmentEdit, (DtoApartment)gridView1.GetFocusedRow());
            newApartmentEdit.ShowDialog();
        }

        private void Apartment_FormClosed(object sender, FormClosedEventArgs e)
        {
            resultMessage = string.Empty;
            resultMessage = layoutControlApartment.SaveFormSettings(address);
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
