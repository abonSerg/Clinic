using System;
using Medicine.Clinic.Client.Model;

namespace Medicine.Clinic.Client.Presentation
{
    public class InterpretationPresenter
    {
        readonly IInterpretationView interpretationView;
        readonly IInterpretationModel interpretationModel;

        public InterpretationPresenter(IInterpretationView interpretationView)
        {
            this.interpretationView = interpretationView;
            interpretationModel = new InterpretationModel();
            interpretationView.SearchClick += LoadSearchResultGrid;
            interpretationView.ClearClick += LoadAllTubeGrids;
            interpretationView.LoadForm += LoadAllTubeGrids;
            interpretationView.LoadClick += LoadDiagnosis;
            interpretationView.DiagnosisChoose += CheckDiagnosis;
            interpretationView.SaveClick += EditInterpretation;
            interpretationView.SignOutClick += SignOutInterpretation;
        }

        public void LoadSearchResultGrid(object sender, EventArgs e)
        {
            interpretationView.InterpretationViewGridControlData = interpretationModel.SearchOrders(interpretationView.InterpretationViewSearchOrderNumber, interpretationView.InterpretationViewSearchBillingNumber);
        }

        public void LoadAllTubeGrids(object sender, EventArgs e)
        {
            interpretationView.InterpretationViewGridControlData = interpretationModel.SearchOrders(string.Empty, string.Empty);
        }

        public void LoadDiagnosis(object sender, EventArgs e) 
        {
            interpretationView.SaveButtonEnabled = true;
            interpretationView.SignOutButtonEnabled = true;
            interpretationView.InterpretationViewSignOutDt = string.Empty;
            interpretationView.InterpretationViewInterpretationStatus = string.Empty;
            interpretationView.InterpretationViewText = string.Empty;
            interpretationView.InterpretationViewDiagnosisGridControlData = interpretationModel.SearchConcreteDiagnoses(interpretationView.InterpretationViewFocusedOrder.Number);
            interpretationView.InterpretationViewDiagnosesList = interpretationModel.SearchDiagnoses();
            interpretationView.InterpretationViewOrderNumber = interpretationView.InterpretationViewFocusedOrder.Number;
            int orderId = interpretationModel.GetInterpretationId(interpretationView.InterpretationViewFocusedOrder.Number);
            if (orderId == 0)
            {
                interpretationView.InterpretationViewInterpretationStatus = "Interpretation is absent for this Order!";
            }
            else
            {
                interpretationView.InterpretationViewText = interpretationModel.GetInterpretationText(interpretationView.InterpretationViewFocusedOrder.Number);
                string signOutDt = interpretationModel.GetInterpretationSignOutDt(interpretationView.InterpretationViewFocusedOrder.Number);
                if (signOutDt != string.Empty)
                {
                    interpretationView.SaveButtonEnabled = false;
                    interpretationView.SignOutButtonEnabled = false;
                    interpretationView.InterpretationViewInterpretationStatus = "Interpretation is Sign Outed already!";
                }

                interpretationView.InterpretationViewCondition = interpretationModel.GetInterpretationCondition(interpretationView.InterpretationViewFocusedOrder.Number);
                interpretationView.InterpretationViewSignOutDt = signOutDt;
            }
        }

        public void EditInterpretation(object sender, EventArgs e) 
        {
            string resultMessage = interpretationModel.EditInterpretation(interpretationView.InterpretationViewText,
                                                                          interpretationView.InterpretationViewCondition,
                                                                          interpretationView.InterpretationViewOrderNumber,
                                                                          null);
            if (string.IsNullOrEmpty(resultMessage))
            {
                interpretationModel.EditConcreteDiagnosis(interpretationView.InterpretationViewDiagnosisGridControlData, interpretationView.InterpretationViewOrderNumber);
                interpretationView.ResultMessage = "Interpretation Save!";
            }
            else
            {
                interpretationView.ResultMessage = resultMessage;
            }
        }

        public void SignOutInterpretation(object sender, EventArgs e) 
        {
            string resultMessage = interpretationModel.SignOutInterpretation(interpretationView.InterpretationViewText,
                                                                              interpretationView.InterpretationViewCondition,
                                                                              interpretationView.InterpretationViewOrderNumber);                                                                         
            if (resultMessage != null)
            {
                interpretationModel.EditConcreteDiagnosis(interpretationView.InterpretationViewDiagnosisGridControlData, interpretationView.InterpretationViewOrderNumber);
                interpretationView.ResultMessage = resultMessage;
                interpretationView.SaveButtonEnabled = false;
                interpretationView.SignOutButtonEnabled = false;
            }
            else
            {
                interpretationView.ResultMessage = "Error!";
            }
        } 

        public void CheckDiagnosis(object sender, EventArgs e) 
        {    
            interpretationView.ResultMessage =  interpretationModel.LoadDiagnosis(interpretationView.InterpretationViewFocusedDiagnosis.Code,interpretationView.InterpretationViewDiagnosisGridControlData);
        }
    }
}
