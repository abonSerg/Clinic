using System;
using Medicine.Clinic.Client.Model;

namespace Medicine.Clinic.Client.Presentation
{
    public class NewSpecimenPresenter
    {
        readonly INewSpecimenView newSpecimenView;
        readonly INewSpecimenModel newSpecimenModel;

        public NewSpecimenPresenter(INewSpecimenView specimenView)
        {
            this.newSpecimenView = specimenView;
            newSpecimenModel = new NewSpecimenModel();
            newSpecimenView.NewSpecimenDefaultTubes = newSpecimenModel.LoadDefaultTubes();
            newSpecimenView.NewOkClick += EditSpecimen;
        }

        void EditSpecimen(object sender, EventArgs e)
        {
            string resultMessage = newSpecimenModel.EditSpecimen(newSpecimenView.NewSpecimenViewCode,
                                                                      newSpecimenView.NewSpecimenViewName,
                                                                      newSpecimenView.NewSpecimenEditDefaultTubeCode, false);
            if (string.IsNullOrEmpty(resultMessage))
            {
                newSpecimenView.ResultMessage = "Specimen Added!";
                newSpecimenView.OkEnabled = false;
            }
            else 
            {
                newSpecimenView.ResultMessage = resultMessage;
            }
        }
    }
}
