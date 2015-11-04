using System;
using Medicine.Clinic.Client.Model;

namespace Medicine.Clinic.Client.Presentation
{
    public class DiagnosisPresenter
    {
        readonly IDiagnosisView diagnosisView;
        readonly IDiagnosisModel diagnosisModel;

        public DiagnosisPresenter(IDiagnosisView diagnosisView)
        {
            this.diagnosisView = diagnosisView;
            diagnosisModel = new DiagnosisModel();
            diagnosisView.SearchClick += new EventHandler(LoadSearchResultGrid);
            diagnosisView.ClearClick += new EventHandler(LoadAllDiagnosisGrids);
            diagnosisView.LoadForm += new EventHandler(LoadAllDiagnosisGrids);
        }

        void LoadSearchResultGrid(object sender, EventArgs e)
        {
             diagnosisView.DiagnosisViewGridControlData = diagnosisModel.SearchDiagnoses(diagnosisView.ViewSearchCode,
                                                                                         diagnosisView.ViewSearchName);
        }

        void LoadAllDiagnosisGrids(object sender, EventArgs e)
        {
            diagnosisView.DiagnosisViewGridControlData = diagnosisModel.SearchDiagnoses(string.Empty, string.Empty);
        }
    }
}
