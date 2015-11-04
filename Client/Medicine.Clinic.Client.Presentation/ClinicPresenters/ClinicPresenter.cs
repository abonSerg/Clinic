using System;
using Medicine.Clinic.Client.Model;

namespace Medicine.Clinic.Client.Presentation
{
    public class ClinicPresenter
    {
        readonly IClinicView clinicView;
        readonly IClinicModel clinicModel;

        public ClinicPresenter(IClinicView clinicView)
        {
            this.clinicView = clinicView;
            clinicModel = new ClinicModel();
            clinicView.SearchClick += new EventHandler(LoadSearchResultGrid);
            clinicView.ClearClick += new EventHandler(LoadAllTubeGrids);
            clinicView.LoadForm += new EventHandler(LoadAllTubeGrids);
        }

        void LoadSearchResultGrid(object sender, EventArgs e)
        {
            clinicView.ClinicViewGridControlData = clinicModel.SearchClinics(clinicView.ViewSearchCode,
                                                                             clinicView.ViewSearchName);
        }

        void LoadAllTubeGrids(object sender, EventArgs e)
        {
            clinicView.ClinicViewGridControlData = clinicModel.SearchClinics(null, null);
        }
    }
}
