using System;
using Medicine.Clinic.Client.Model;
using Medicine.Clinic.Client.Model.PatientService;

namespace Medicine.Clinic.Client.Presentation
{
    public class NewPatientEditPresenter
    {
        readonly INewPatientEditView newPatientEditView;
        readonly INewPatientEditModel newPatientEditModel;
        private DtoPatient editPatient;
        private int newPatientEditId;


        public NewPatientEditPresenter(INewPatientEditView newPatientEditView, DtoPatient editPatient)
        {
            this.newPatientEditView = newPatientEditView;
            newPatientEditModel = new NewPatientModel();
            newPatientEditView.NewPatientSexes = newPatientEditModel.LoadSexes();
            this.editPatient = editPatient;
            newPatientEditView.NewPatientEditLoad += LoadNewPatientEditProp;
            newPatientEditView.NewPatientEditSwitch += ChangedEnabling;
            newPatientEditView.EditOkClick += EditPatient;           
        }

        private void LoadNewPatientEditProp(object sender, EventArgs e) 
        {
            newPatientEditId = editPatient.Id;
            newPatientEditView.NewPatientViewMrn = editPatient.Mrn;
            newPatientEditView.NewPatientViewSsn = editPatient.Ssn;
            newPatientEditView.NewPatientViewFirstName = editPatient.FirstName;
            newPatientEditView.NewPatientViewLastName = editPatient.LastName;
            newPatientEditView.NewPatientViewMiddleName = editPatient.MiddleName;
            newPatientEditView.NewPatientViewDob = editPatient.Dob;
            newPatientEditView.NewPatientEditSexCode = editPatient.Sex.Code;
            newPatientEditView.NewPatientViewDod = editPatient.Dod;
            newPatientEditView.NewPatientAge = string.Format("Age   {0} years", editPatient.Age);
            newPatientEditView.NewPatientVievMrnIsReadOnly = true;
            newPatientEditView.NewPatientVievFirstNameIsReadOnly = true;
            newPatientEditView.NewPatientVievLastNameIsReadOnly = true;
            newPatientEditView.NewPatientVievMiddleNameIsReadOnly = true;
            newPatientEditView.NewPatientVievSsnIsReadOnly = true;
            newPatientEditView.NewPatientVievSexIsReadOnly = true;
            newPatientEditView.NewPatientVievDobIsReadOnly = true;
            newPatientEditView.NewPatientVievDodIsReadOnly = true;
        }

        private void ChangedEnabling(object sender, EventArgs e)
        {
            newPatientEditView.NewPatientVievFirstNameIsReadOnly = false;
            newPatientEditView.NewPatientVievLastNameIsReadOnly = false;
            newPatientEditView.NewPatientVievMiddleNameIsReadOnly = false;
            newPatientEditView.NewPatientVievSsnIsReadOnly = false;
            newPatientEditView.NewPatientVievSexIsReadOnly = false;
            newPatientEditView.NewPatientVievDobIsReadOnly = false;
            newPatientEditView.NewPatientVievDodIsReadOnly = false;
        }

        private void EditPatient(object sender, EventArgs e) 
        {
            string resultMessage = newPatientEditModel.EditPatient(newPatientEditView.NewPatientViewMrn,
                                                                   newPatientEditView.NewPatientViewSsn,
                                                                   newPatientEditView.NewPatientViewFirstName,
                                                                   newPatientEditView.NewPatientViewLastName,
                                                                   newPatientEditView.NewPatientViewMiddleName,
                                                                   newPatientEditView.NewPatientViewDob,
                                                                   newPatientEditView.NewPatientEditSexCode,
                                                                   newPatientEditView.NewPatientViewDod,
                                                                   true,
                                                                   newPatientEditView.IsSsnFull);
            if (string.IsNullOrEmpty(resultMessage))
            {
                newPatientEditView.ResultMessage = "Patient changed!";
                newPatientEditView.NewPatientVievFirstNameIsReadOnly = true;
                newPatientEditView.NewPatientVievLastNameIsReadOnly = true;
                newPatientEditView.NewPatientVievMiddleNameIsReadOnly = true;
                newPatientEditView.NewPatientVievSsnIsReadOnly = true;
                newPatientEditView.NewPatientVievSexIsReadOnly = true;
                newPatientEditView.NewPatientVievDobIsReadOnly = true;
                newPatientEditView.NewPatientVievDodIsReadOnly = true;
            }
            else 
            {
                newPatientEditView.ResultMessage = resultMessage;

            }                          
        }
    }
}
