using System;
using Medicine.Clinic.Client.Model;
using Medicine.Clinic.Client.Model.SexService;

namespace Medicine.Clinic.Client.Presentation
{
    public class NewSexEditPresenter
    {
        readonly INewSexEditView newSexEditView;
        readonly INewSexEditModel newSexEditModel;

        private DtoSex editSex;
        private int newSexEditId;

        public NewSexEditPresenter(INewSexEditView newSexEditView, DtoSex editSex)
        {
            this.newSexEditView = newSexEditView;
            newSexEditModel = new NewSexModel();
            this.editSex = editSex;
            newSexEditView.NewSexEditLoad += LoadNewSexEditProp;
            newSexEditView.EditOkClick += EditSex;                  
        }

        private void LoadNewSexEditProp(object sender, EventArgs e)
        {
            newSexEditId = editSex.Id;
            newSexEditView.NewSexViewCode = editSex.Code;
            newSexEditView.NewSexViewName = editSex.Name;
        }

        public void EditSex(object sender, EventArgs e)
        {
            string resultMessage = newSexEditModel.EditSex(newSexEditView.NewSexViewCode,
                                                           newSexEditView.NewSexViewName,true);
            if (string.IsNullOrEmpty(resultMessage))
            {
                newSexEditView.ResultMessage = "Sex changed!";
            }
            else 
            {
                newSexEditView.ResultMessage = resultMessage;
            }
        }        

    }
}
