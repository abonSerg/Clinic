using System;
using Medicine.Clinic.Client.Model;

namespace Medicine.Clinic.Client.Presentation
{
    public class NewPatientPresenter
    {
        readonly INewPatientView newPatientView;
        readonly INewPatientModel newPatientModel;

        public NewPatientPresenter(INewPatientView patientView)
        {
            this.newPatientView = patientView;
            newPatientModel = new NewPatientModel();
            newPatientView.NewPatientSexes = newPatientModel.LoadSexes();
            newPatientView.NewPatientViewMrn = newPatientModel.LoadPatientMrn();
            newPatientView.NewPatientVievMrnIsReadOnly = true;
            newPatientView.NewPatientVievDodIsReadOnly = true;
            newPatientView.NewOkClick += AddPatient;
        }

        public void AddPatient(object sender, EventArgs e)
        {

            string resultMessage = newPatientModel.EditPatient(newPatientView.NewPatientViewMrn,
                                                               newPatientView.NewPatientViewSsn,
                                                               newPatientView.NewPatientViewFirstName,
                                                               newPatientView.NewPatientViewLastName,
                                                               newPatientView.NewPatientViewMiddleName,
                                                               newPatientView.NewPatientViewDob,
                                                               newPatientView.NewPatientEditSexCode,
                                                               null,
                                                               false,
                                                               newPatientView.IsSsnFull);
            if (string.IsNullOrEmpty(resultMessage))
            {
                newPatientView.ResultMessage = "Patient added!";
                newPatientView.OkEnabled = false;
            }
            else 
            {
                newPatientView.ResultMessage = resultMessage;
            }
        }
    }
}
