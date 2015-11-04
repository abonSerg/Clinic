using System;
using Medicine.Clinic.Client.Model;

namespace Medicine.Clinic.Client.Presentation
{
    public class SpecimenPresenter
    {
        readonly ISpecimenView specimenView;
        readonly ISpecimenModel specimenModel;

        public SpecimenPresenter(ISpecimenView specimenView)
        {
            this.specimenView = specimenView;
            specimenModel = new SpecimenModel();
            specimenView.SearchClick += LoadSearchResultGrid;
            specimenView.ClearClick += LoadAllSpesimenGrids;
            specimenView.LoadForm += LoadAllSpesimenGrids;
        }

        void LoadSearchResultGrid(object sender, EventArgs e)
        {
            specimenView.SpecimenViewGridControlData = specimenModel.SearchSpecimens(specimenView.ViewSearchCode, specimenView.ViewSearchName);
        }

        void LoadAllSpesimenGrids(object sender, EventArgs e)
        {
            specimenView.SpecimenViewGridControlData = specimenModel.SearchSpecimens(string.Empty, string.Empty);
        }

    }
}
