using Medicine.Clinic.Client.Model;
using Medicine.Clinic.Client.Model.ApartmentService;
using System;
using System.Windows.Forms;

namespace Medicine.Clinic.Client.Presentation
{
    public class NewApartmentEditPresenter
    {
        readonly INewApartmentEditView apartmentEditView;
        readonly INewApartmentEditModel apartmentEditModel;
        DtoApartment editApartmnet;

        public NewApartmentEditPresenter(INewApartmentEditView apartmentEditView, DtoApartment editApartmnet)
        {
            this.apartmentEditView = apartmentEditView;
            apartmentEditModel = new NewApartmentModel();
            this.editApartmnet = editApartmnet;
            apartmentEditView.NewApartmentsViewClinics = apartmentEditModel.LoadClinics();
            apartmentEditView.NewApartmentEditLoad += LoadEditApartment;
            apartmentEditView.EditOkClick += SaveApartment;
        }

        void LoadEditApartment(object sender, EventArgs e)
        {
            apartmentEditView.NewApartmentEditClinicCode = editApartmnet.Clinic.Code;
            apartmentEditView.NewApartmentViewRoomId = editApartmnet.RoomId.ToString();
            apartmentEditView.NewApartmentViewBedId = editApartmnet.BedId.ToString();
        }

        void SaveApartment(object sender, EventArgs e)
        {
            string resultMessage = apartmentEditModel.AddApartment(editApartmnet.Id,
                                                                   apartmentEditView.ClinicEditValue,
                                                                   apartmentEditView.NewApartmentViewRoomId,
                                                                   apartmentEditView.NewApartmentViewBedId);
            if (string.IsNullOrEmpty(resultMessage))
            {
                MessageBox.Show("Apartment saved!", "Add apartment", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(resultMessage, "Add apartment", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
