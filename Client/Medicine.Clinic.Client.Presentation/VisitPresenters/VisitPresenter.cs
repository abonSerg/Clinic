using System;
using Medicine.Clinic.Client.Model;

namespace Medicine.Clinic.Client.Presentation
{
    public class VisitPresenter
    {
        readonly IVisitView visitView;
        readonly IVisitModel visitModel;

        public VisitPresenter(IVisitView visitView)
        {
            this.visitView = visitView;
            visitModel = new VisitModel();
            visitView.LoadForm += LoadVisits;
            visitView.ClearClick += LoadVisits;
            visitView.SearchClick += SearchVisits;
        }

        public void LoadVisits(object sender, EventArgs e)
        {
            visitView.VisitViewGridControlData = visitModel.SearchVisits(string.Empty, string.Empty, string.Empty);
        }

        public void SearchVisits(object sender, EventArgs e)
        {
            visitView.VisitViewGridControlData = visitModel.SearchVisits(visitView.VisitViewSearchMrn, visitView.VisitViewSearchFirstName, visitView.VisitViewSearchBillingNumber);
        }
    }
}
