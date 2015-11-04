using System;
using Medicine.Clinic.Client.Model;
using Medicine.Clinic.Client.Model.ClinicService;

namespace Medicine.Clinic.Client.Presentation
{
    public class NewClinicEditPresenter
    {
        readonly INewClinicEditView newClinicEditView;
        readonly INewClinicEditModel newClinicEditModel;

        private DtoClinic editClinic;

        public NewClinicEditPresenter(INewClinicEditView newClinicEditView, DtoClinic editClinic)
        {
            this.newClinicEditView = newClinicEditView;
            newClinicEditModel = new NewClinicModel();
            this.editClinic = editClinic;
            newClinicEditView.NewClinicEditLoad += LoadNewClinicEditProp;
            newClinicEditView.EditOkClick += EditClinic;                  
        }

        private void LoadNewClinicEditProp(object sender, EventArgs e)
        {
            newClinicEditView.NewClinicViewCode = editClinic.Code;
            newClinicEditView.NewClinicViewName = editClinic.Name;
            newClinicEditView.NewClinicViewAddress = editClinic.Address;
        }

        public void EditClinic(object sender, EventArgs e)
        { 
            string resultMessage = newClinicEditView.ResultMessage = newClinicEditModel.EditClinic(newClinicEditView.NewClinicViewCode,
                                                                                                   newClinicEditView.NewClinicViewName,
                                                                                                   newClinicEditView.NewClinicViewAddress,
                                                                                                   true);
            if (string.IsNullOrEmpty(resultMessage))
            {
                newClinicEditView.ResultMessage = "Clinic cahnged!";
            }
            else 
            {
                newClinicEditView.ResultMessage = resultMessage;
            }
        }            
    }
}
