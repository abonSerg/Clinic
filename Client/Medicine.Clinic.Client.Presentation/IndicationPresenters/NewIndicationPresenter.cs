using System;
using Medicine.Clinic.Client.Model;

namespace Medicine.Clinic.Client.Presentation
{
    public class NewIndicationPresenter
    {
        readonly INewIndicationView newIndicationView;
        readonly INewIndicationModel newIndicationModel;

        public NewIndicationPresenter(INewIndicationView indicationView)
        {
            this.newIndicationView = indicationView;
            newIndicationModel = new NewIndicationModel();
            newIndicationView.newOkClick += new EventHandler(AddIndication);
        }

        void AddIndication(object sender, EventArgs e)
        {
            string resultMessage = newIndicationModel.EditIndication(newIndicationView.NewIndicationViewCode, 
                                                                     newIndicationView.NewIndicationViewName,
                                                                     true);
            if (string.IsNullOrEmpty(resultMessage))
            {
                newIndicationView.ResultMessage = "Indication saved!";
                newIndicationView.OkEnabled = false;
            }
            else 
            {
                newIndicationView.ResultMessage = resultMessage;
            }
        }
    }
}
