using System;
using Medicine.Clinic.Client.Model;

namespace Medicine.Clinic.Client.Presentation
{
    public class NewDiagnosisPresenter
    {
        readonly INewDiagnosisView newDiagnosisView;
        readonly INewDiagnosisModel newDiagnosisModel;

        public NewDiagnosisPresenter(INewDiagnosisView diagnosisView)
        {
            this.newDiagnosisView = diagnosisView;
            newDiagnosisModel = new NewDiagnosisModel();
            newDiagnosisView.NewOkClick += AddDiagnosis;
        }

        void AddDiagnosis(object sender, EventArgs e)
        {
            string resultMessage = newDiagnosisModel.EditDiagnosis(newDiagnosisView.NewDiagnosisViewCode, 
                                                                   newDiagnosisView.NewDiagnosisViewName,
                                                                   false);
            if (string.IsNullOrEmpty(resultMessage))
            {
                newDiagnosisView.ResultMessage = "Diagnosis saved!";
                newDiagnosisView.OkEnabled = false;
            }
            else 
            {
                newDiagnosisView.ResultMessage = resultMessage;
            }
        }
    }
}
