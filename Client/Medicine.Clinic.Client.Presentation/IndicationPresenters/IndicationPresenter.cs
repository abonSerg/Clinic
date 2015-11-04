using System;
using Medicine.Clinic.Client.Model;

namespace Medicine.Clinic.Client.Presentation
{
    public class IndicationPresenter
    {
        readonly IIndicationView indicationView;
        readonly IIndicationModel indicationModel;

        public IndicationPresenter(IIndicationView indicationView)
        {
            this.indicationView = indicationView;
            indicationModel = new IndicationModel();
            indicationView.SearchClick += new EventHandler(LoadSearchResultGrid);
            indicationView.ClearClick += new EventHandler(LoadAllSexGrids);
            indicationView.LoadForm += new EventHandler(LoadAllSexGrids);
        }

        void LoadSearchResultGrid(object sender, EventArgs e)
        {
             indicationView.IndicationViewGridControlData = indicationModel.SearchIndications(indicationView.ViewSearchCode,
                                                                                              indicationView.ViewSearchName);
        }

        void LoadAllSexGrids(object sender, EventArgs e)
        {
            indicationView.IndicationViewGridControlData = indicationModel.SearchIndications(string.Empty, string.Empty);
        }
    }
}
