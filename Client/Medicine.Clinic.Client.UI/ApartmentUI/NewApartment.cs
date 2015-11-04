using System;
using System.ComponentModel;
using System.Windows.Forms;
using Medicine.Clinic.Client.Model.ClinicService;
using Medicine.Clinic.Client.Presentation;
using System.Xml.Linq;
using System.IO;
using System.Text;

namespace Medicine.Clinic.Client.UI
{
    public partial class NewApartment : Form, INewApartmentView, INewApartmentEditView
    {
        public event EventHandler NewApartmentEditLoad;
        public event EventHandler EditOkClick;
        public event EventHandler NewOkClick;

        string address;
        string resultMessage;

        private bool isEditView = false;

        public BindingList<DtoClinic> NewApartmentsViewClinics { set { lookUpEditClinic.Properties.DataSource = value; } }

        public string NewApartmentEditClinicCode { set { lookUpEditClinic.EditValue = value; } }

        public string ClinicEditValue { get { return (string)lookUpEditClinic.EditValue; } }

        public string ResultMessage { get; set; }

        public bool OkEnabled { set { buttonOk.Enabled = value; } }

        public string NewApartmentViewRoomId
        {
            get { return this.textBoxRoom.Text; }
            set { this.textBoxRoom.Text = value; }
        }

        public string NewApartmentViewBedId
        {
            get { return this.textBoxBed.Text; }
            set { this.textBoxBed.Text = value; }
        }

        public NewApartment()
        {
            InitializeComponent();
            LoadSettings();
        }

        public NewApartment(bool isEditView)
        {
            this.isEditView = isEditView;
            InitializeComponent();
            LoadSettings();
        }

        private void LoadSettings() 
        {
            address = "ViewsXmlSettingNewApartmentViewXmlSetting.xml";
            resultMessage = layoutControlNewApartment.LoadFormSettings(address);
            if (!string.IsNullOrEmpty(resultMessage))
            {
                MessageBox.Show(resultMessage, "Configuration file absent", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        void lookUpEditClinic_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (string.IsNullOrEmpty((string)e.NewValue))
            {
                dxErrorProviderClinic.SetError(lookUpEditClinic, "Invalid field value!");
            }
            dxErrorProviderClinic.ClearErrors();
        }
        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ClinicEditValue))
            {
                dxErrorProviderClinic.SetError(lookUpEditClinic, "Invalid field value!");
            }
            else 
            {
                if (isEditView)
                {
                    if (EditOkClick != null)
                    {
                        EditOkClick(sender, e);
                    }
                }
                else
                {
                    if (NewOkClick != null)
                    {
                        NewOkClick(sender, e);
                    }
                }
            }
            
        }

        private void NewApartment_Load(object sender, EventArgs e)
        {
            if (isEditView && (NewApartmentEditLoad != null)) 
            {
                NewApartmentEditLoad(sender, e);
            }
        }

        private void NewApartment_FormClosed(object sender, FormClosedEventArgs e)
        {
            resultMessage = string.Empty;
            resultMessage = layoutControlNewApartment.SaveFormSettings(address);
            if (!string.IsNullOrEmpty(resultMessage))
            {
                MessageBox.Show(resultMessage, "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

    }
}
