using System;
using Medicine.Clinic.Client.Model;

namespace Medicine.Clinic.Client.Presentation
{
    public class SexPresenter
    {
        readonly ISexView sexView;
        readonly ISexModel sexModel;

        public SexPresenter(ISexView sexView)
        {
            this.sexView = sexView;
            sexModel = new SexModel();
            sexView.SearchClick += LoadSearchResultGrid;
            sexView.ClearClick += LoadAllSexGrids;
            sexView.LoadForm += LoadAllSexGrids;
        }

        void LoadSearchResultGrid(object sender, EventArgs e)
        {
             sexView.SexViewGridControlData = sexModel.SearchSexes(sexView.ViewSearchCode, sexView.ViewSearchName);
        }

        void LoadAllSexGrids(object sender, EventArgs e)
        {
            sexView.SexViewGridControlData = sexModel.SearchSexes(string.Empty, string.Empty);
        }
    }
}
