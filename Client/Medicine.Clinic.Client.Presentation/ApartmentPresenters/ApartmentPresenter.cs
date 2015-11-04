using System;
using Medicine.Clinic.Client.Model;

namespace Medicine.Clinic.Client.Presentation
{
    public class ApartmentPresenter
    {
        readonly IApartmentView apartmentView;
        readonly IApartmentModel apartmentModel;

        public ApartmentPresenter(IApartmentView apartmentView)
        {
            this.apartmentView = apartmentView;
            apartmentModel = new ApartmentModel();
            apartmentView.SearchClick += LoadSearchResultGrid;
            apartmentView.ClearClick += LoadAllApartmentGrids;
            apartmentView.LoadForm += LoadAllApartmentGrids;
        }

        void LoadSearchResultGrid(object sender, EventArgs e)
        {
            apartmentView.ApartmentViewGridControlData = apartmentModel.SearchApartments(this.apartmentView.ApartmentViewSearchClinicName);
        }

        void LoadAllApartmentGrids(object sender, EventArgs e)
        {
            apartmentView.ApartmentViewGridControlData = apartmentModel.SearchApartments(string.Empty);
        }
    }
}
