using System;
using Medicine.Clinic.Client.Model;

namespace Medicine.Clinic.Client.Presentation
{
    public class TestPresenter
    {
        readonly ITestView testView;
        readonly ITestModel testModel;

        public TestPresenter(ITestView testView)
        {
            this.testView = testView;
            testModel = new TestModel();
            testView.SearchClick += LoadSearchResultGrid;
            testView.ClearClick += LoadAllTestGrids;
            testView.LoadForm += LoadAllTestGrids;
        }

        void LoadSearchResultGrid(object sender, EventArgs e)
        {
            testView.TestViewGridControlData = testModel.SearchTests(testView.ViewSearchCode, testView.ViewSearchName);
        }

        void LoadAllTestGrids(object sender, EventArgs e)
        {
            testView.TestViewGridControlData = testModel.SearchTests(string.Empty, string.Empty);
        }
    }
}
