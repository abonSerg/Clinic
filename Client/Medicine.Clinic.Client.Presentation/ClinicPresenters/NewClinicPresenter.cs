using System;
using Medicine.Clinic.Client.Model;

namespace Medicine.Clinic.Client.Presentation
{
    public class NewClinicPresenter
    {
        readonly INewClinicView newClinicView;
        readonly INewClinicModel newClinicModel;

        public NewClinicPresenter(INewClinicView clinicView)
        {
            this.newClinicView = clinicView;
            newClinicModel = new NewClinicModel();
            newClinicView.NewOkClick += AddClinic;
        }

        void AddClinic(object sender, EventArgs e)
        {
              string resultMessage = newClinicView.ResultMessage = newClinicModel.EditClinic(newClinicView.NewClinicViewCode,
                                                                                             newClinicView.NewClinicViewName,
                                                                                             newClinicView.NewClinicViewAddress,
                                                                                             false);
              if (string.IsNullOrEmpty(resultMessage))
              {
                  newClinicView.ResultMessage = "Clinic Added!";
                  newClinicView.OkEnabled = false;
              }
              else 
              {
                  newClinicView.ResultMessage = resultMessage;
              }
        }
    }
}
