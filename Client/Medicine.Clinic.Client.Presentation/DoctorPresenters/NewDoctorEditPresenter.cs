using System;
using Medicine.Clinic.Client.Model;
using Medicine.Clinic.Client.Model.DoctorService;

namespace Medicine.Clinic.Client.Presentation
{
    public class NewDoctorEditPresenter
    {
        readonly INewDoctorEditView newDoctorEditView;
        readonly INewDoctorEditModel newDoctorEditModel;
        private DtoDoctor editDoctor;
        private int newDoctorEditId;

        public NewDoctorEditPresenter(INewDoctorEditView newDoctorEditView, DtoDoctor editDoctor)
        {
            this.newDoctorEditView = newDoctorEditView;
            newDoctorEditModel = new NewDoctorModel();
            newDoctorEditView.NewDoctorClinics = newDoctorEditModel.LoadClinics();
            this.editDoctor = editDoctor;
            newDoctorEditView.NewDoctorEditLoad += LoadNewDoctorEditProp;
            newDoctorEditView.EditOkClick += EditDoctor;           
        }

        private void LoadNewDoctorEditProp(object sender, EventArgs e) 
        {
            newDoctorEditId = editDoctor.Id;
            newDoctorEditView.NewDoctorViewCode = editDoctor.Code;
            newDoctorEditView.NewDoctorViewFirstName = editDoctor.FirstName;
            newDoctorEditView.NewDoctorViewLastName = editDoctor.LastName;
            newDoctorEditView.NewDoctorViewMiddleName = editDoctor.MiddleName;
            newDoctorEditView.NewDoctorEditClinicCode = editDoctor.Clinic.Code;
        }

        private void EditDoctor(object sender, EventArgs e)
        {

            string resultMessage = newDoctorEditModel.EditDoctor(newDoctorEditView.NewDoctorViewCode,
                                                                 newDoctorEditView.NewDoctorViewFirstName,
                                                                 newDoctorEditView.NewDoctorViewLastName,
                                                                 newDoctorEditView.NewDoctorViewMiddleName,
                                                                 newDoctorEditView.ClinicFocusedValue,
                                                                 true);
            if (string.IsNullOrEmpty(resultMessage))
            {
                newDoctorEditView.ResultMessage = "Doctor changed!";
            }
            else 
            {
                newDoctorEditView.ResultMessage = resultMessage;
            }
        }
    }
}
