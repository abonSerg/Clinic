using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medicine.Clinic.Client.Model;
using Medicine.Clinic.Client.Model.IndicationService;

namespace Medicine.Clinic.Client.Presentation
{
    public class NewIndicationEditPresenter
    {
        readonly INewIndicationEditView newIndicationEditView;
        readonly INewIndicationEditModel newIndicationEditModel;

        private DtoIndication editIndication;

        public NewIndicationEditPresenter(INewIndicationEditView newIndicationEditView, DtoIndication editIndication)
        {
            this.newIndicationEditView = newIndicationEditView;
            newIndicationEditModel = new NewIndicationModel();
            this.editIndication = editIndication;
            newIndicationEditView.NewIndicationEditLoad += LoadNewIndicationEditProp;
            newIndicationEditView.EditOkClick += EditIndication;                  
        }

        private void LoadNewIndicationEditProp(object sender, EventArgs e)
        {
            newIndicationEditView.NewIndicationViewCode = editIndication.Code;
            newIndicationEditView.NewIndicationViewName = editIndication.Name;
        }

        public void EditIndication(object sender, EventArgs e)
        {
            string resultMessage = newIndicationEditModel.EditIndication(newIndicationEditView.NewIndicationViewCode,
                                                                         newIndicationEditView.NewIndicationViewName,
                                                                         false);
            if (string.IsNullOrEmpty(resultMessage))
            {
                newIndicationEditView.ResultMessage = "Indication changed!";
            }
            else 
            {
                newIndicationEditView.ResultMessage = resultMessage;
            }                                                  
        }           
    }
}
