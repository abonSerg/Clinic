using System;
using Medicine.Clinic.Client.Model;
using Medicine.Clinic.Client.Model.TestService;

namespace Medicine.Clinic.Client.Presentation
{
    public class NewTestEditPresenter
    {
        readonly INewTestEditView newTestEditView;
        readonly INewTestEditModel newTestEditModel;
        private DtoTest editTest;

        public NewTestEditPresenter(INewTestEditView newTestEditView, DtoTest editTest)
        {
            this.newTestEditView = newTestEditView;
            newTestEditModel = new NewTestModel();
            newTestEditView.NewTestDefaultSpecimens = newTestEditModel.LoadDefaultSpecimens();
            this.editTest = editTest;
            newTestEditView.NewTestEditLoad += LoadNewTestEditProp;
            newTestEditView.EditOkClick += EditTest;           
        }

        private void LoadNewTestEditProp(object sender, EventArgs e) 
        {
            newTestEditView.NewTestViewCode = editTest.Code;
            newTestEditView.NewTestViewName = editTest.Name;
            newTestEditView.NewTestViewCost = editTest.Cost.ToString();
            newTestEditView.DefaultSpecimenCode = editTest.DefaultSpecimen.Code;
            newTestEditView.NewTestSexList = newTestEditModel.SearchSexes(string.Empty, string.Empty);
            newTestEditView.CheckedTestSexAllowed = newTestEditModel.LoadChekedSexes(editTest.Code);
        }

        private void EditTest(object sender, EventArgs e)
        {
            string resultMessage = newTestEditModel.EditTest(newTestEditView.NewTestViewCode,
                                                                  newTestEditView.NewTestViewName,
                                                                  newTestEditView.NewTestViewCost,
                                                                  newTestEditView.DefaultSpecimenCode,
                                                                  newTestEditView.CheckedSexes,
                                                                  true);

            if (string.IsNullOrEmpty(resultMessage))
            {
                newTestEditModel.EditAttach(editTest.Code, newTestEditView.CheckedSexes);
                newTestEditView.ResultMessage = "Test changed!";
            }
            else 
            {
                newTestEditView.ResultMessage = resultMessage;
            }
        }
    }
}
