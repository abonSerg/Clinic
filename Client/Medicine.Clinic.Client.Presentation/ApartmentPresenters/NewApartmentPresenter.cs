using System;
using System.Windows.Forms;
using Medicine.Clinic.Client.Model;

namespace Medicine.Clinic.Client.Presentation
{
    public class NewApartmentPresenter
    {
        readonly INewApartmentView apartmentView;
        readonly INewApartmentModel apartmentModel;

        public NewApartmentPresenter(INewApartmentView apartmentView)
        {
            this.apartmentView = apartmentView;
            apartmentModel = new NewApartmentModel();
            apartmentView.NewOkClick += AddApartment;
            apartmentView.NewApartmentsViewClinics = apartmentModel.LoadClinics();
        }

        void AddApartment(object sender, EventArgs e)
        {
            string resultMessage = apartmentModel.AddApartment(0, apartmentView.ClinicEditValue,
                                                                  apartmentView.NewApartmentViewRoomId,
                                                                  apartmentView.NewApartmentViewBedId);
            if (string.IsNullOrEmpty(resultMessage))
            {
                MessageBox.Show("Apartment saved!", "Add apartment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                apartmentView.OkEnabled = false;
            }
            else
            {
                MessageBox.Show(resultMessage, "Add apartment", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
