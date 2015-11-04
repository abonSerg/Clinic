using System;
using Medicine.Clinic.Client.Model;

namespace Medicine.Clinic.Client.Presentation
{
    public class NewTestPresenter
    {
        readonly INewTestView newTestView;
        readonly INewTestModel newTestModel;
        
        public NewTestPresenter(INewTestView testView)
        {
            newTestView = testView;
            newTestModel = new NewTestModel();
            newTestView.NewTestDefaultSpecimens = newTestModel.LoadDefaultSpecimens();
            newTestView.NewTestSexList = newTestModel.SearchSexes(string.Empty, string.Empty);
            newTestView.NewOkClick += AddTest;
        }

        void AddTest(object sender, EventArgs e)
        {
            string resultMessage = newTestModel.EditTest(newTestView.NewTestViewCode,
                                                         newTestView.NewTestViewName,
                                                         newTestView.NewTestViewCost,
                                                         newTestView.DefaultSpecimenCode,
                                                         newTestView.CheckedSexes,
                                                         false);
            if (string.IsNullOrEmpty(resultMessage))
            {
                newTestView.ResultMessage = "Test saved!";
                newTestView.OkEnabled = false;
                newTestModel.SaveAttached(newTestView.NewTestViewCode, newTestView.CheckedSexes);
            }
            else 
            {
                newTestView.ResultMessage = resultMessage;
            }
        }
    }
}
