using System;
using System.ComponentModel;
using System.Windows.Forms;
using Medicine.Clinic.Client.Model.DiagnosisService;
using Medicine.Clinic.Client.Model.GridControlsEntities;
using Medicine.Clinic.Client.Model.OrderService;
using Medicine.Clinic.Client.Presentation;
using System.Xml.Linq;
using System.IO;
using System.Text;

namespace Medicine.Clinic.Client.UI
{
    public partial class Interpretation : Form, IInterpretationView
    {
        public event EventHandler SearchClick;
        public event EventHandler ClearClick;
        public event EventHandler LoadForm;
        public event EventHandler LoadClick;
        public event EventHandler DiagnosisChoose;
        public event EventHandler SaveClick;
        public event EventHandler SignOutClick;

        private string address;
        private string resultMessage;

        public string InterpretationViewSearchOrderNumber
        {
            get { return textBoxOrderNumber.Text; }
            set { textBoxOrderNumber.Text = value; }
        }

        public string InterpretationViewSearchBillingNumber
        {
            get { return textBoxBillingNumber.Text; }
            set { textBoxBillingNumber.Text = value; }
        }

        public string InterpretationViewOrderNumber
        {
            get { return labelInfo.Text; }
            set { labelInfo.Text = value; }
        }

        public string InterpretationViewInterpretationStatus
        {
            get { return labelCondition.Text; }
            set { labelCondition.Text = value; }
        }

        public string InterpretationViewSignOutDt
        {
            get { return labelDate.Text; }
            set { labelDate.Text = value; }
        }

        public string InterpretationViewText
        {
            get { return richTextBoxInterpretation.Text; }
            set { richTextBoxInterpretation.Text = value; }
        }

        public char InterpretationViewCondition
        {
            get { return (char)radioGroupCondition.EditValue; }
            set { radioGroupCondition.EditValue = value; }
        }

        public bool SaveButtonEnabled { set { buttonSave.Enabled = value; } }

        public bool SignOutButtonEnabled { set { buttonSignOut.Enabled = value; } }

        public string ResultMessage { get; set; }

        public BindingList<DtoOrder> InterpretationViewGridControlData { set { gridControlOrders.DataSource = value; } }

        public BindingList<DiagnosisForGrid> InterpretationViewDiagnosisGridControlData
        {
            get { return (BindingList<DiagnosisForGrid>)gridControlDiagnoses.DataSource; }
            set { gridControlDiagnoses.DataSource = value; }
        }

        public BindingList<DtoDiagnosis> InterpretationViewDiagnosesList
        {
            set { repositoryItemLookUpEdit1.DataSource = value; }
        }

        public DtoOrder InterpretationViewFocusedOrder { get { return (DtoOrder)gridViewOrders.GetFocusedRow(); } }

        public DiagnosisForGrid InterpretationViewFocusedDiagnosis { get { return (DiagnosisForGrid)gridViewDiagnoses.GetFocusedRow(); } }

        public Interpretation()
        {
            InitializeComponent();
            Name = FormEnum.Interpretation.ToString();
            address = "ViewsXmlSettingInterpretationViewXmlSetting.xml";
            resultMessage = layoutControlInterpretation.LoadFormSettings(address);
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
            }
            textBoxOrderNumber.Clear();
            textBoxBillingNumber.Clear();
        }

        private void Interpretation_Load(object sender, EventArgs e)
        {
            LoadForm(sender, e);
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            if (LoadClick != null) 
            {
                LoadClick(sender, e);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (SaveClick != null) 
            {
                SaveClick(sender, e);
                MessageBox.Show(ResultMessage);
                ResultMessage = string.Empty;
            }
        }

        private void buttonSignOut_Click(object sender, EventArgs e)
        {
            if (SignOutClick != null) 
            {
                SignOutClick(sender, e);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void gridViewDiagnoses_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (DiagnosisChoose != null) 
            {
                DiagnosisChoose(sender, e);
                if (ResultMessage != string.Empty)
                {
                    MessageBox.Show(ResultMessage);
                    gridViewDiagnoses.CancelUpdateCurrentRow();
                    ResultMessage = string.Empty;
                }
            }
        }

        private void buttonDeleteDiagnosis_Click(object sender, EventArgs e)
        {
            gridViewDiagnoses.DeleteSelectedRows();
        }

        private void Interpretation_FormClosed(object sender, FormClosedEventArgs e)
        {
            resultMessage = string.Empty;
            resultMessage = layoutControlInterpretation.SaveFormSettings(address);
            if (!string.IsNullOrEmpty(resultMessage))
            {
                MessageBox.Show(resultMessage, "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }
    }
}
