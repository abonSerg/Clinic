using System;
using System.ComponentModel;
using System.Windows.Forms;
using Medicine.Clinic.Client.Presentation;
using Medicine.Clinic.Client.Model.ClinicService;
using System.Xml.Linq;
using System.IO;
using System.Text;
using Medicine.Clinic.Client.Model.DiagnosisService;
using Medicine.Clinic.Client.Model.IndicationService;
using Medicine.Clinic.Client.Model.OrderService;
using DtoClinic = Medicine.Clinic.Client.Model.ClinicService.DtoClinic;
using DtoIndication = Medicine.Clinic.Client.Model.IndicationService.DtoIndication;
using DtoSex = Medicine.Clinic.Client.Model.SexService.DtoSex;
using DtoSpecimen = Medicine.Clinic.Client.Model.SpecimenService.DtoSpecimen;
using DtoTest = Medicine.Clinic.Client.Model.TestService.DtoTest;


namespace Medicine.Clinic.Client.UI
{
    public partial class SetupForm : Form, IClinicView, IDiagnosisView, IIndicationView, ISexView, ISpecimenView, ITestView
    {
        public event EventHandler SearchClick;
        public event EventHandler ClearClick;
        public event EventHandler LoadForm;
        private FormEnum form;
        private string address;
        private string resultMessage;


        public string ViewSearchCode
        {
            get { return textBoxCode.Text; }
            set { textBoxCode.Text = value;}
        }

        public string ViewSearchName
        {
            get { return textBoxName.Text; }
            set { textBoxName.Text = value;}
        }
                     
        public BindingList<DtoClinic> ClinicViewGridControlData
        {
            set { gridControlView.DataSource = value; }
        }

        public BindingList<DtoIndication> IndicationViewGridControlData
        {
            set { gridControlView.DataSource = value; }
        }
        public BindingList<DtoDiagnosis> DiagnosisViewGridControlData
        {
            set { gridControlView.DataSource = value; }
        }
      
        public BindingList<DtoSex> SexViewGridControlData
        {
            set { gridControlView.DataSource = value; }
        }

        public BindingList<DtoSpecimen> SpecimenViewGridControlData
        {
            set { gridControlView.DataSource = value; }
        }

        public BindingList<DtoTest> TestViewGridControlData
        {
            set { gridControlView.DataSource = value; }
        }


        public SetupForm(FormEnum form)
        {
            InitializeComponent();
            switch (form)
            {
                case FormEnum.Clinic:
                    {
                        InitializeClinicGridControlComponent();
                        Name = FormEnum.Clinic.ToString();
                        address = "ViewsXmlSetting/ClinicViewXmlSetting.xml";
                        break;
                    }
                case FormEnum.Test:
                    {
                        InitializeTestGridControlComponent();
                        Name = FormEnum.Test.ToString();
                        address = "ViewsXmlSetting/TestViewXmlSetting.xml";
                        break;
                    }
                case FormEnum.Diagnosis:
                    {
                        InitializeDiagnosisGridControlComponent();
                        Name = FormEnum.Diagnosis.ToString();
                        address = "ViewsXmlSetting/DiagnosisViewXmlSetting.xml";
                        break;
                    }
                case FormEnum.Indication:
                    {
                        InitializeIndicationGridControlComponent();
                        Name = FormEnum.Indication.ToString();
                        address = "ViewsXmlSetting/IndicationViewXmlSetting.xml";
                        break;
                    }
                case FormEnum.Sex:
                    {
                        InitializeSexGridControlComponent();
                        Name = FormEnum.Sex.ToString();
                        address = "ViewsXmlSetting/SexViewXmlSetting.xml";
                        break;
                    }
                case FormEnum.Specimen:
                    {
                        InitializeSpecimenGridControlComponent();
                        Name = FormEnum.Specimen.ToString();
                        address = "ViewsXmlSetting/SpecimenViewXmlSetting.xml";
                        break;
                    }
            }

            resultMessage = layoutControl.LoadFormSettings(address);
            if (!string.IsNullOrEmpty(resultMessage))
            {
                MessageBox.Show(resultMessage, "Configuration file absent", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            Text = Name;
            this.form = form;
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            switch (form)
            {
                case FormEnum.Clinic:
                    {
                        var newClinic = new NewClinic();
                        var newClinicPresenter = new NewClinicPresenter(newClinic);
                        newClinic.ShowDialog();
                        break;
                    }
                case FormEnum.Test:
                    {
                        var newTest = new NewTest();
                        var newTestPresenter = new NewTestPresenter(newTest);
                        newTest.ShowDialog();
                        break;
                    }
                case FormEnum.Diagnosis:
                    {
                        var newDiagnosis = new NewDiagnosis();
                        var newDiagnosisPresenter = new NewDiagnosisPresenter(newDiagnosis);
                        newDiagnosis.ShowDialog();
                        break;
                    }
                case FormEnum.Indication:
                    {
                        var newIndication = new NewIndication();
                        var newIndicationPresenter = new NewIndicationPresenter(newIndication);
                        newIndication.ShowDialog();
                        break;
                    }
                case FormEnum.Sex:
                    {
                        var newSex = new NewSex();
                        var newSexPresenter = new NewSexPresenter(newSex);
                        newSex.ShowDialog();
                        break;
                    }
                case FormEnum.Specimen:
                    {
                        var newSpecimen = new NewSpecimen();
                        var newSpecimenPresenter = new NewSpecimenPresenter(newSpecimen);
                        newSpecimen.ShowDialog();
                        break;
                    }
            }

        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            switch (form)
            {
                case FormEnum.Clinic:
                    {
                        bool isEditView = true;
                        var newClinicEdit = new NewClinic(isEditView);
                        var newClinicEditPresenter = new NewClinicEditPresenter(newClinicEdit, (DtoClinic)gridView.GetFocusedRow());
                        newClinicEdit.ShowDialog();
                        break;
                    }
                case FormEnum.Test:
                    {
                        bool isEditView = true;
                        var newTestEdit = new NewTest(isEditView);
                        var newTestEditPresenter = new NewTestEditPresenter(newTestEdit, (DtoTest)gridView.GetFocusedRow());
                        newTestEdit.ShowDialog();
                        break;
                    }
                case FormEnum.Diagnosis:
                    {
                        bool isEditView = true;
                        var newDiagnosisEdit = new NewDiagnosis(isEditView);
                        var newDiagnosisEditPresenter = new NewDiagnosisEditPresenter(newDiagnosisEdit, (DtoDiagnosis)gridView.GetFocusedRow());
                        newDiagnosisEdit.ShowDialog();
                        break;
                    }
                case FormEnum.Indication:
                    {
                        bool isEditView = true;
                        var newIndicationEdit = new NewIndication(isEditView);
                        var newIndicationEditPresenter = new NewIndicationEditPresenter(newIndicationEdit, (DtoIndication)gridView.GetFocusedRow());
                        newIndicationEdit.ShowDialog();
                        break;
                    }
                case FormEnum.Sex:
                    {
                        bool isEditView = true;
                        var newSexEdit = new NewSex(isEditView);
                        var newSexEditPresenter = new NewSexEditPresenter(newSexEdit, (DtoSex)gridView.GetFocusedRow());
                        newSexEdit.ShowDialog();
                        break;
                    }
                case FormEnum.Specimen:
                    {
                        bool isEditView = true;
                        var newSpecimenEdit = new NewSpecimen(isEditView);
                        var newSpecimenEditPresenter = new NewSpecimenEditPresenter(newSpecimenEdit, (DtoSpecimen)gridView.GetFocusedRow());
                        newSpecimenEdit.ShowDialog();
                        break;
                    }
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
                textBoxCode.Clear();
                textBoxName.Clear();
                ClearClick(sender, e);
            } 
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

       

        private void Clinic_Load(object sender, EventArgs e)
        {
            if (LoadForm != null) 
            {
                LoadForm(sender, e);
            }
        }

        private void Clinic_FormClosed(object sender, FormClosedEventArgs e)
        {
            resultMessage = layoutControl.SaveFormSettings(address);
            if (!string.IsNullOrEmpty(resultMessage))
            {
                MessageBox.Show(resultMessage, "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private void buttonCancel_Click_1(object sender, EventArgs e)
        {
            Close();
        } 
 

    }
}
