using System;
using Medicine.Clinic.Client.Model;

namespace Medicine.Clinic.Client.Presentation
{
    public class NewDoctorPresenter
    {
        readonly INewDoctorView newDoctorView;
        readonly INewDoctorModel newDoctorModel;

        public NewDoctorPresenter(INewDoctorView newDoctorView)
        {
            this.newDoctorView = newDoctorView;
            newDoctorModel = new NewDoctorModel();
            newDoctorView.NewDoctorClinics = newDoctorModel.LoadClinics();
            newDoctorView.NewOkClick += AddDoctor;
        }

        void AddDoctor(object sender, EventArgs e)
        {
            string resultMessage = newDoctorModel.EditDoctor(newDoctorView.NewDoctorViewCode,
                                                             newDoctorView.NewDoctorViewFirstName,
                                                             newDoctorView.NewDoctorViewLastName,
                                                             newDoctorView.NewDoctorViewMiddleName,
                                                             newDoctorView.ClinicFocusedValue,
                                                             false);
            if (string.IsNullOrEmpty(resultMessage))
            {
                newDoctorView.ResultMessage = "Doctor saved!";
                newDoctorView.OkEnabled = false;
            }
            else 
            {
                newDoctorView.ResultMessage = resultMessage;
            }                        
        }
    }
}
