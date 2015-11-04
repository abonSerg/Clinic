using System;
using Medicine.Clinic.Client.Model;
using Medicine.Clinic.Client.Model.DiagnosisService;

namespace Medicine.Clinic.Client.Presentation
{
    public class NewDiagnosisEditPresenter
    {
        readonly INewDiagnosisEditView newDiagnosisEditView;
        readonly INewDiagnosisEditModel newDiagnosisEditModel;

        private DtoDiagnosis editDiagnosis;

        public NewDiagnosisEditPresenter(INewDiagnosisEditView newDiagnosisEditView, DtoDiagnosis editDiagnosis)
        {
            this.newDiagnosisEditView = newDiagnosisEditView;
            newDiagnosisEditModel = new NewDiagnosisModel();
            this.editDiagnosis = editDiagnosis;
            newDiagnosisEditView.NewDiagnosisEditLoad += LoadNewDiagnosisEditProp;
            newDiagnosisEditView.EditOkClick += EditDiagnosis;                  
        }

        private void LoadNewDiagnosisEditProp(object sender, EventArgs e)
        {
            newDiagnosisEditView.NewDiagnosisViewCode = editDiagnosis.Code;
            newDiagnosisEditView.NewDiagnosisViewName = editDiagnosis.Name;
        }

        public void EditDiagnosis(object sender, EventArgs e)
        {
            string resultMessage = newDiagnosisEditModel.EditDiagnosis(newDiagnosisEditView.NewDiagnosisViewCode,
                                                                       newDiagnosisEditView.NewDiagnosisViewName,
                                                                       true);
            if (string.IsNullOrEmpty(resultMessage))
            {
                newDiagnosisEditView.ResultMessage = "Diagnosis changed";
            }
            else 
            {
                newDiagnosisEditView.ResultMessage = resultMessage;
            }
        }          
    }
}
