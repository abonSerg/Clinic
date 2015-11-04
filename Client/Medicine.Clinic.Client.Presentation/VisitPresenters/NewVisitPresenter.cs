using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medicine.Clinic.Client.Model;

namespace Medicine.Clinic.Client.Presentation
{
    public class NewVisitPresenter
    {
        readonly INewVisitView newVisitView;
        readonly INewVisitModel newVisitModel;

        public NewVisitPresenter(INewVisitView newVisitView)
        {
            this.newVisitView = newVisitView;
            newVisitModel = new NewVisitModel();
            newVisitView.NewOkClick += AddVisit;
            newVisitView.ApartmentChoose += LoadDefaultDoctor;
            newVisitView.NewVisitBillingNumber = newVisitModel.GetBillingNumber();
            newVisitModel.GetDataSet();
            newVisitView.NewVisitPatients = newVisitModel.LoadPatients();
            newVisitView.NewVisitDoctors = newVisitModel.LoadDoctors();
            newVisitView.NewVisitApartments = newVisitModel.LoadApartments();
        }

        public void AddVisit(object sender, EventArgs e)
        {

            string resultMessage = newVisitView.ResultMessage = newVisitModel.EditVisit(newVisitView.NewVisitBillingNumber,
                                                                                        newVisitView.PatientFocusedRow,
                                                                                        newVisitView.DoctorFocusedRow,
                                                                                        newVisitView.ApartmentFocusedRow);
            if (string.IsNullOrEmpty(resultMessage))
            {
                newVisitView.ResultMessage = "Visit saved!";
                newVisitView.OkEnabled = false;
            }
            else 
            {
                newVisitView.ResultMessage = resultMessage;
            }
        }

        public void LoadDefaultDoctor(object sender, EventArgs e) 
        {
            newVisitView.DoctorFocusedRow = newVisitModel.GetDefaultDoctorCode(newVisitView.ApartmentFocusedRow);
        }
    }
}
