using System;
using System.Data;
using Medicine.Clinic.Client.Model;
using Medicine.Clinic.Client.Model.GridControlsEntities;

namespace Medicine.Clinic.Client.Presentation
{
    public class NewVisitEditPresenter
    {
        readonly INewVisitEditView newVisitEditView;
        readonly INewVisitEditModel newVisitEditModel;
        readonly string editVisitBillingNumber;

        public NewVisitEditPresenter(INewVisitEditView newVisitEditView, VisitForGrid editVisit)
        {
            this.newVisitEditView = newVisitEditView;
            newVisitEditModel = new NewVisitModel();
            editVisitBillingNumber = editVisit.BillingNumber;
            newVisitEditView.NewVisitBillingNumber = editVisitBillingNumber;
            newVisitEditModel.GetDataSet();
            newVisitEditView.NewVisitPatients = newVisitEditModel.LoadPatients();
            newVisitEditView.NewVisitDoctors = newVisitEditModel.LoadDoctors();
            newVisitEditView.NewVisitApartments = newVisitEditModel.LoadApartments();
            newVisitEditView.ApartmentChoose += LoadDefaultDoctor;
            newVisitEditView.NewVisitEditLoad += LoadVisitProperties;
            newVisitEditView.NewOkEditClick += EditVisit;
        }

        public void LoadVisitProperties(object sender, EventArgs e) 
        {
            newVisitEditView.PatientFocusedRow = newVisitEditModel.GetPatientMrnByVisit(editVisitBillingNumber);
            newVisitEditView.DoctorFocusedRow = newVisitEditModel.GetDoctorCodeByVisit(editVisitBillingNumber);
            newVisitEditView.ApartmentFocusedRow = newVisitEditModel.GetApartmentIdByVisit(editVisitBillingNumber);
        }

        public void EditVisit(object sender, EventArgs e) 
        {
            string resultMessage = newVisitEditModel.EditVisit(editVisitBillingNumber, 
                                                               newVisitEditView.PatientFocusedRow,
                                                               newVisitEditView.DoctorFocusedRow,
                                                               newVisitEditView.ApartmentFocusedRow);
            if (string.IsNullOrEmpty(resultMessage))
            {
                newVisitEditView.ResultMessage = "Visit saved!";
            }
            else 
            {
                newVisitEditView.ResultMessage = resultMessage;
            }
        }

        public void LoadDefaultDoctor(object sender, EventArgs e)
        {
            newVisitEditView.DoctorFocusedRow = newVisitEditModel.GetDefaultDoctorCode(newVisitEditView.ApartmentFocusedRow);
        }

    }
}
