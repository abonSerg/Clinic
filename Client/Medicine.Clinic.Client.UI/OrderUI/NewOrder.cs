using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using Medicine.Clinic.Client.Model.GridControlsEntities;
using Medicine.Clinic.Client.Presentation;
using System.Xml.Linq;
using System.IO;
using System.Text;
using DtoTest = Medicine.Clinic.Client.Model.TestService.DtoTest;
using DtoSpecimen = Medicine.Clinic.Client.Model.SpecimenService.DtoSpecimen;
using DtoTube = Medicine.Clinic.Client.Model.TubeService.DtoTube;
using DtoIndication = Medicine.Clinic.Client.Model.IndicationService.DtoIndication;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraEditors.Controls;

namespace Medicine.Clinic.Client.UI
{
    public partial class NewOrder : Form, INewOrderView, INewOrderEditView
    {
        public event EventHandler LoadForm;
        public event EventHandler LoadEditForm;
        public event EventHandler TestChoose;
        public event EventHandler IndicationChoose;
        public event EventHandler OrderSaveClick;
        public event EventHandler OrderEditClick;
        public event EventHandler AddTestsToCheckBox;
        public event EventHandler AddTubesToCheckBox;
        public event EventHandler DeleteFocusedTest;
        public event EventHandler DeleteFocuseTube;

        private bool isEditView = false;
        private string address;

        public string DodResultMessage 
        {
            set { label1.Text = value; }
        }

        public string OrderNumber
        {
            get { return label5.Text; }
            set { label5.Text = value; }
        }

        public string ClinicalInfo 
        {
            get { return richTextBoxClinicalInfo.Text; }
            set { richTextBoxClinicalInfo.Text = value; }
        }

        public BindingList<TestForGrid> TestsViewGridControlData
        {
            get { return (BindingList<TestForGrid>)gridControlTests.DataSource; }
            set { gridControlTests.DataSource = value; }
        }

        public BindingList<SpecimenForGrid> SpecimensViewGridControlData
        {
            get { return (BindingList<SpecimenForGrid>)gridControlSpecimens.DataSource; }
            set { gridControlSpecimens.DataSource = value; }
        }

        public BindingList<TubeForGrid> TubesViewGridControlData
        {
            get { return (BindingList<TubeForGrid>)gridControlTubes.DataSource; }
            set { gridControlTubes.DataSource = value; }
        }

        public BindingList<IndicationForGrid> IndicationsViewGridControlData
        {
            get { return (BindingList<IndicationForGrid>)gridControlIndications.DataSource; }
            set { gridControlIndications.DataSource = value; }
        }

        public BindingList<DtoTest> NewOrderTestsList 
        {
            set { repositoryItemLookUpEdit1.DataSource = value; }
        }

        public BindingList<DtoSpecimen> NewOrderSpecimensList
        {
            set { repositoryItemLookUpEditSpecimen.DataSource = value; }
        }

        public BindingList<DtoTube> NewOrderTubesList
        {
            set { repositoryItemLookUpEdit3.DataSource = value; }
        }

        public BindingList<DtoIndication> NewOrderIndicationsList
        {
            set { repositoryItemLookUpEdit4.DataSource = value; }
        }

        public string FocusedCodeValueTest
        {
            get { return (string)gridViewTests.FocusedValue; }
            set { gridViewTests.EditingValue = value; }
        }

        public string FocusedCodeValueIndication
        {
            get { return (string)gridViewIndications.FocusedValue; }    
        }

        public bool SaveButtonEnabled 
        {
            set { buttonSave.Enabled = value; }
        }

        public TubeForGrid FocusedTubeRow 
        {
            get { return (TubeForGrid)gridViewTubes.GetFocusedRow(); }
        }

        public int FocusedTestIndex { get { return gridViewTests.GetFocusedDataSourceRowIndex(); } }

        public string FocusedCodeValueSpecimen { get { return (string)gridViewSpecimens.EditingValue ; } }

        public string FocusedCodeValueTube { get { return (string)gridViewTubes.FocusedValue; } }

        public string ResultMessage { get; set; }

        public BindingList<TestForGrid> ConcreteTestsForTubeCheckBox
        {
            set { repositoryItemCheckedComboBoxTests.DataSource = value; }
        }

        public BindingList<TubeForGrid> ConcreteTubesForSpecimenCheckBox
        {
            set { repositoryItemCheckedComboBoxEditTubes.DataSource = value; }
        }

        public NewOrder()
        {
            InitializeComponent();
            LoadSettings();
        }

        public NewOrder(bool isEditView)
        {
            this.isEditView = isEditView;
            LoadSettings();
            InitializeComponent();
        }


        private void gridViewTubes_ValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
        {
            var testsStringColumn = gridViewTubes.Columns[2];
            GridView view = sender as GridView;
            if (view.FocusedColumn.FieldName == "Tests" && TestsViewGridControlData.Count != 0)
            {
                if(string.IsNullOrEmpty((string)e.Value))
                {
                    e.ErrorText = "Mandatory field!";
                    e.Valid = false;
                }
            }

            if (view.FocusedColumn.FieldName == "ReceivedDt" && TestsViewGridControlData.Count != 0)
            {
                if ((DateTime?)e.Value > DateTime.Now)
                {
                    e.ErrorText = "Invalid Date";
                    e.Valid = false;
                }
            }

        }

        private void gridViewTubes_InvalidValueException(object sender, InvalidValueExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError;
        }


        private void gridViewSpecimens_ValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
        {
            GridView view = sender as GridView;
            if (view.FocusedColumn.FieldName == "CollectedDt" && TubesViewGridControlData.Count != 0)
            {
                if ((DateTime?)e.Value > DateTime.Now)
                {
                    e.ErrorText = "Invalid Date";
                    e.Valid = false;
                }
            }

            if (view.FocusedColumn.FieldName == "Tubes")
            {
                if (string.IsNullOrEmpty((string)e.Value))
                {
                    e.ErrorText = "Mandatory field!";
                    e.Valid = false;
                }
            }
        }

        private void gridViewSpecimens_InvalidValueException(object sender, InvalidValueExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError;
        }
       
       
        private void LoadSettings()
        {
            address = "ViewsXmlSettingNewOrderViewXmlSetting.xml";
            ResultMessage = layoutControlNewOrder.LoadFormSettings(address);
            if (!string.IsNullOrEmpty(ResultMessage))
            {
                MessageBox.Show(ResultMessage, "Configuration file absent", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void NewOrder_Load(object sender, EventArgs e)
        {
            if (isEditView)
            {
                if (LoadEditForm != null)
                {
                    buttonSave.Text = "Save changes";
                    Text = "Edit Order";
                    LoadEditForm(sender, e);
                }
            }
            else
            {
                if (LoadForm != null)
                {
                    Text = "New Order";
                    LoadForm(sender, e);
                }
            }
        }

        private void gridViewTests_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if ((TestChoose != null) && (AddTestsToCheckBox!= null)) 
            {
                TestChoose(sender, e);
                if (ResultMessage != string.Empty)
                {
                    MessageBox.Show(ResultMessage, "Invalid test", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    gridViewTests.CancelUpdateCurrentRow();
                    ResultMessage = string.Empty;
                }
                gridViewTests.RefreshData();
                AddTestsToCheckBox(sender, e);
            }
        }

        private void gridViewIndications_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (IndicationChoose != null) 
            {
                IndicationChoose(sender, e);
                if (ResultMessage != string.Empty)
                {
                    MessageBox.Show(ResultMessage, "Invalid indication", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    gridViewIndications.CancelUpdateCurrentRow();
                    ResultMessage = string.Empty;
                }
            }
        }

        private void buttonDeleteTest_Click(object sender, EventArgs e)
        {
            if ((DeleteFocusedTest != null) && (AddTestsToCheckBox != null))
            {
                DeleteFocusedTest(sender, e);
                gridViewTests.DeleteSelectedRows();
                gridViewTubes.RefreshData();
                AddTestsToCheckBox(sender, e);
            }
            
        }

        private void buttonDeleteSpecimen_Click(object sender, EventArgs e)
        {
            gridViewSpecimens.DeleteSelectedRows();
        }

        private void buttonDeleteTube_Click(object sender, EventArgs e)
        {
            if (DeleteFocuseTube != null) 
            {
                DeleteFocuseTube(sender, e);
                gridViewTubes.DeleteSelectedRows();
                AddTubesToCheckBox(sender, e);
                gridViewSpecimens.RefreshData();
            }
        }

        private void buttonDeleteIndication_Click(object sender, EventArgs e)
        {
            gridViewIndications.DeleteSelectedRows();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (isEditView)
            {
                if (OrderEditClick != null)
                {
                    OrderEditClick(sender, e);
                }
            }
            else
            {
                if (OrderSaveClick != null)
                {
                    OrderSaveClick(sender, e);
                }
            }
        }

        private void gridViewTubes_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (AddTubesToCheckBox != null)
            {
                AddTubesToCheckBox(sender, e);
            }
        }

        private void NewOrder_FormClosed(object sender, FormClosedEventArgs e)
        {
            ResultMessage = string.Empty;
            ResultMessage = layoutControlNewOrder.SaveFormSettings(address);
            if (!string.IsNullOrEmpty(ResultMessage))
            {
                MessageBox.Show(ResultMessage, "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
 
    }
}
