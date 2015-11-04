using System;
using System.ComponentModel;
using System.Windows.Forms;
using Medicine.Clinic.Client.Model;
using Medicine.Clinic.Client.Model.GridControlsEntities;

namespace Medicine.Clinic.Client.Presentation
{
    public class NewOrderPresenter
    {
        readonly INewOrderView newOrderView;
        readonly INewOrderModel newOrderModel;
        readonly string billingNumber = string.Empty;

        public NewOrderPresenter(INewOrderView orderView, string billingNumber)
        {
            newOrderView = orderView;
            newOrderModel = new NewOrderModel();
            this.billingNumber = billingNumber;
            newOrderView.LoadForm += LoadGridControls;
            newOrderView.TestChoose += LoadDefaultEntities;
            newOrderView.IndicationChoose += LoadIndications;
            newOrderView.OrderSaveClick += SaveOrder;
            newOrderView.AddTestsToCheckBox += LoadTestsToCheckBox;
            newOrderView.AddTubesToCheckBox += LoadTubesToCheckBox;
            newOrderView.DeleteFocusedTest += UpdateTestsForCheckBox;
            newOrderView.DeleteFocuseTube += UpdateTubesForCheckBox;
        }

        public void LoadGridControls(object sender, EventArgs e)
        {
            string dodResultMessage = newOrderModel.IsDodExis(billingNumber);
            if (dodResultMessage != string.Empty)
            {
                newOrderView.DodResultMessage = dodResultMessage;
                newOrderView.SaveButtonEnabled = false;
            }
            newOrderView.NewOrderTestsList = newOrderModel.SearchAllowedTestsByVisit(billingNumber);
            newOrderView.NewOrderSpecimensList = newOrderModel.SearchSpecimens();
            newOrderView.NewOrderTubesList = newOrderModel.SearchTubes();
            newOrderView.NewOrderIndicationsList = newOrderModel.SearchIndications();
            newOrderView.TestsViewGridControlData = newOrderModel.SearchConcreteTests(null);
            newOrderView.SpecimensViewGridControlData = newOrderModel.SearchConcreteSpecimens(string.Empty, null);
            newOrderView.TubesViewGridControlData = newOrderModel.SearchConcreteTubes(string.Empty);
            newOrderView.IndicationsViewGridControlData = newOrderModel.SearchConcreteIndications(string.Empty);
            newOrderView.OrderNumber = newOrderModel.GetOrderNamber();
        }

        public void LoadDefaultEntities(object sender, EventArgs e) 
        {
            newOrderView.ResultMessage = newOrderModel.LoadDefaultEntities(newOrderView.FocusedCodeValueTest, newOrderView.TestsViewGridControlData, newOrderView.SpecimensViewGridControlData, newOrderView.TubesViewGridControlData);
        }

        public void LoadIndications(object sender, EventArgs e)
        {
            //newOrderView.ResultMessage = newOrderModel.LoadIndications(newOrderView.FocusedCodeValueIndication, newOrderView.IndicationsViewGridControlData);
        }

        public void SaveOrder(object sender, EventArgs e) 
        {
            var errorMessage = newOrderModel.CheckForConstrains(newOrderView.SpecimensViewGridControlData,
                                                                newOrderView.TubesViewGridControlData,
                                                                newOrderView.TestsViewGridControlData,
                                                                newOrderView.IndicationsViewGridControlData);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                MessageBox.Show(errorMessage, "Error saving!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else 
            {
                var result = newOrderModel.EditOrder(newOrderView.OrderNumber, newOrderView.ClinicalInfo, billingNumber);
                if (result == "o")
                {
                    newOrderView.TestsViewGridControlData = newOrderModel.AddConcreteTest(newOrderView.TestsViewGridControlData, newOrderView.OrderNumber);
                    newOrderView.TubesViewGridControlData = newOrderModel.AddConcreteTube(newOrderView.TubesViewGridControlData, newOrderView.OrderNumber);
                    newOrderView.SpecimensViewGridControlData = newOrderModel.AddConcreteSpecimen(newOrderView.SpecimensViewGridControlData, newOrderView.OrderNumber);
                    newOrderView.IndicationsViewGridControlData = newOrderModel.AddConcreteIndication(newOrderView.IndicationsViewGridControlData, newOrderView.OrderNumber);
                    newOrderModel.AddTestTubeAttch(newOrderView.TubesViewGridControlData, newOrderView.TestsViewGridControlData);
                    newOrderModel.AddSpecimenTubeAttch(newOrderView.SpecimensViewGridControlData, newOrderView.TubesViewGridControlData);
                    newOrderView.SaveButtonEnabled = false;
                    MessageBox.Show("Order saved!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
                    
                }
                if (result == "d")
                {
                    MessageBox.Show("Patient is dead!", "Error saving!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (result == "c")
                {
                    MessageBox.Show("Clinical info is empty", "Error saving!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void LoadTestsToCheckBox(object sender, EventArgs e) 
        {
            newOrderView.ConcreteTestsForTubeCheckBox = newOrderModel.LoadTestsToCheckBox(newOrderView.TestsViewGridControlData);
        }

        public void LoadTubesToCheckBox(object sender, EventArgs e)
        {
            newOrderView.ConcreteTubesForSpecimenCheckBox = newOrderModel.LoadTubesToCheckBox(newOrderView.TubesViewGridControlData);
        }

        public void UpdateTestsForCheckBox(object sender, EventArgs e) 
        {
            newOrderView.TubesViewGridControlData = newOrderModel.DeleteCheckedTests(newOrderView.TubesViewGridControlData, newOrderView.FocusedCodeValueTest);
        }

        public void UpdateTubesForCheckBox(object sender, EventArgs e)
        {
            if (newOrderView.FocusedTubeRow != null) 
            {
                newOrderView.SpecimensViewGridControlData = newOrderModel.DeleteCheckedTubes(newOrderView.SpecimensViewGridControlData, newOrderView.FocusedTubeRow.Id);
            }
            
        } 
    }
}
