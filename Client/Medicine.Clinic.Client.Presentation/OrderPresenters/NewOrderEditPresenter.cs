using System;
using System.Windows.Forms;
using Medicine.Clinic.Client.Model;
using Medicine.Clinic.Client.Model.OrderService;

namespace Medicine.Clinic.Client.Presentation
{
    public class NewOrderEditPresenter
    {
        readonly INewOrderEditView newOrderEditView;
        readonly INewOrderEditModel newOrderEditModel;
        private DtoOrder newOrderEdit;

        public NewOrderEditPresenter(INewOrderEditView newOrderEditView, DtoOrder editOrder )
        {
            this.newOrderEditView = newOrderEditView;
            newOrderEditModel = new NewOrderModel();
            newOrderEdit = editOrder;
            newOrderEditView.LoadEditForm += LoadGridControls;
            newOrderEditView.TestChoose += LoadDefaultEntities;
            newOrderEditView.IndicationChoose += LoadIndications;
            newOrderEditView.AddTestsToCheckBox += LoadTestsToCheckBox;
            newOrderEditView.AddTubesToCheckBox += LoadTubesToCheckBox;
            newOrderEditView.OrderEditClick += EditOrder;
            newOrderEditView.DeleteFocusedTest += UpdateTestsForCheckBox;
            newOrderEditView.DeleteFocuseTube += UpdateTubesForCheckBox;
        }

        public void LoadGridControls(object sender, EventArgs e) 
        {
            string dodResultMessage = newOrderEditModel.IsDodExis(newOrderEdit.Visit.BillingNumber);
            if (!string.IsNullOrEmpty(dodResultMessage)) 
            {
                newOrderEditView.DodResultMessage = dodResultMessage;
                newOrderEditView.SaveButtonEnabled = false;
            }
            newOrderEditView.TestsViewGridControlData = newOrderEditModel.SearchConcreteTests(newOrderEdit.Number);
            newOrderEditView.NewOrderTestsList = newOrderEditModel.SearchAllowedTestsByVisit(newOrderEdit.Visit.BillingNumber);

            newOrderEditView.TubesViewGridControlData = newOrderEditModel.SearchConcreteTubes(newOrderEdit.Number);
            newOrderEditView.NewOrderTubesList = newOrderEditModel.SearchTubes();
            newOrderEditView.ConcreteTestsForTubeCheckBox = newOrderEditModel.LoadTestsToCheckBox(newOrderEditView.TestsViewGridControlData);

            newOrderEditView.SpecimensViewGridControlData = newOrderEditModel.SearchConcreteSpecimens(newOrderEdit.Number, newOrderEditView.TubesViewGridControlData);
            newOrderEditView.NewOrderSpecimensList = newOrderEditModel.SearchSpecimens();
            newOrderEditView.ConcreteTubesForSpecimenCheckBox = newOrderEditModel.LoadTubesToCheckBox(newOrderEditView.TubesViewGridControlData);

            newOrderEditView.NewOrderIndicationsList = newOrderEditModel.SearchIndications();
            newOrderEditView.IndicationsViewGridControlData = newOrderEditModel.SearchConcreteIndications(newOrderEdit.Number);
            newOrderEditView.OrderNumber = newOrderEdit.Number;
            newOrderEditView.ClinicalInfo = newOrderEdit.ClinicalInfo;
        }

        public void LoadDefaultEntities(object sender, EventArgs e)
        {
            newOrderEditView.ResultMessage = newOrderEditModel.LoadDefaultEntities(newOrderEditView.FocusedCodeValueTest, newOrderEditView.TestsViewGridControlData, newOrderEditView.SpecimensViewGridControlData, newOrderEditView.TubesViewGridControlData);
        }

        public void LoadIndications(object sender, EventArgs e)
        {
            //newOrderEditView.ResultMessage = newOrderEditModel.LoadIndications(newOrderEditView.FocusedCodeValueIndication, newOrderEditView.IndicationsViewGridControlData);
        }

        public void EditOrder(object sender, EventArgs e)
        {
            var errorMessage = newOrderEditModel.CheckForConstrains(newOrderEditView.SpecimensViewGridControlData,
                                                                    newOrderEditView.TubesViewGridControlData,
                                                                    newOrderEditView.TestsViewGridControlData,
                                                                    newOrderEditView.IndicationsViewGridControlData);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                newOrderEditView.ResultMessage = errorMessage;
                MessageBox.Show(errorMessage, "Error editing!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var result = newOrderEditModel.EditOrder(newOrderEdit.Number, newOrderEditView.ClinicalInfo, newOrderEdit.Visit.BillingNumber);
                if (result == "o")
                {
                    newOrderEditView.TestsViewGridControlData = newOrderEditModel.EditConcreteTest(newOrderEditView.TestsViewGridControlData, newOrderEdit.Number);
                    newOrderEditView.TubesViewGridControlData = newOrderEditModel.EditConcreteTube(newOrderEditView.TubesViewGridControlData, newOrderEdit.Number);
                    newOrderEditView.SpecimensViewGridControlData = newOrderEditModel.EditConcreteSpecimen(newOrderEditView.SpecimensViewGridControlData, newOrderEdit.Number);
                    newOrderEditView.IndicationsViewGridControlData = newOrderEditModel.EditConcreteIndication(newOrderEditView.IndicationsViewGridControlData, newOrderEdit.Number);
                    newOrderEditModel.DeleteAttaches(newOrderEdit.Number);
                    newOrderEditModel.AddTestTubeAttch(newOrderEditView.TubesViewGridControlData, newOrderEditView.TestsViewGridControlData);
                    newOrderEditModel.AddSpecimenTubeAttch(newOrderEditView.SpecimensViewGridControlData, newOrderEditView.TubesViewGridControlData);
                    MessageBox.Show("Order saved!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (result == "d")
                {
                    MessageBox.Show("Patient is dead!", "Error editing!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (result == "c")
                {
                    MessageBox.Show("Clinical info is empty", "Error editing!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (result == "s")
                {
                    MessageBox.Show("Interpretation for this Order is SignOuted!", "Error editing!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            newOrderEditModel.DeleteConcreteEntities(newOrderEditView.TestsViewGridControlData, newOrderEditView.SpecimensViewGridControlData, newOrderEditView.TubesViewGridControlData, newOrderEditView.IndicationsViewGridControlData, newOrderEdit.Number);

        }

        public void LoadTestsToCheckBox(object sender, EventArgs e)
        {
            newOrderEditView.ConcreteTestsForTubeCheckBox = newOrderEditModel.LoadTestsToCheckBox(newOrderEditView.TestsViewGridControlData);
        }

        public void LoadTubesToCheckBox(object sender, EventArgs e)
        {
            newOrderEditView.ConcreteTubesForSpecimenCheckBox = newOrderEditModel.LoadTubesToCheckBox(newOrderEditView.TubesViewGridControlData);
        }

        public void UpdateTestsForCheckBox(object sender, EventArgs e)
        {
            newOrderEditView.TubesViewGridControlData = newOrderEditModel.DeleteCheckedTests(newOrderEditView.TubesViewGridControlData, newOrderEditView.FocusedCodeValueTest);
        }

        public void UpdateTubesForCheckBox(object sender, EventArgs e)
        {
            if (newOrderEditView.FocusedTubeRow != null)
            {
                newOrderEditView.SpecimensViewGridControlData = newOrderEditModel.DeleteCheckedTubes(newOrderEditView.SpecimensViewGridControlData, newOrderEditView.FocusedTubeRow.Id);
            }

        } 
    }
}
