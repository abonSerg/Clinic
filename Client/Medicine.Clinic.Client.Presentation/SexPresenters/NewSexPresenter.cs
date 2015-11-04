using System;
using Medicine.Clinic.Client.Model;

namespace Medicine.Clinic.Client.Presentation
{
    public class NewSexPresenter
    {
        readonly INewSexView newSexView;
        readonly INewSexModel newSexModel;

        public NewSexPresenter(INewSexView sexView)
        {
            this.newSexView = sexView;
            newSexModel = new NewSexModel();
            newSexView.NewOkClick += AddSex;
        }

        void AddSex(object sender, EventArgs e)
        {
            string resultMessage = newSexModel.EditSex(newSexView.NewSexViewCode, newSexView.NewSexViewName,false);
            if (string.IsNullOrEmpty(resultMessage))
            {
                newSexView.ResultMessage = "Sex saved!";
                newSexView.OkEnabled = false;
            }
            else 
            {
                newSexView.ResultMessage = resultMessage;
            }
        }
    }
}
