using System;
using Medicine.Clinic.Client.Model;
using Medicine.Clinic.Client.Model.SpecimenService;

namespace Medicine.Clinic.Client.Presentation
{
    public class NewSpecimenEditPresenter
    {
        readonly INewSpecimenEditView newSpecimenEditView;
        readonly INewSpecimenEditModel newSpecimenEditModel;
        private DtoSpecimen editSpecimen;

        public NewSpecimenEditPresenter(INewSpecimenEditView newSpecimenEditView, DtoSpecimen editSpecimen)
        {
            this.newSpecimenEditView = newSpecimenEditView;
            newSpecimenEditModel = new NewSpecimenModel();
            newSpecimenEditView.NewSpecimenDefaultTubes = newSpecimenEditModel.LoadDefaultTubes();
            this.editSpecimen = editSpecimen;
            newSpecimenEditView.NewSpecimenEditLoad += LoadNewSpecimenEditProp;
            newSpecimenEditView.EditOkClick += EditSpecimen;           
        }

        private void LoadNewSpecimenEditProp(object sender, EventArgs e) 
        {
            newSpecimenEditView.NewSpecimenViewCode = editSpecimen.Code;
            newSpecimenEditView.NewSpecimenViewName = editSpecimen.Name;
            newSpecimenEditView.NewSpecimenEditDefaultTubeCode = editSpecimen.DefaultTube.Code;
        }

        private void EditSpecimen(object sender, EventArgs e)
        {
            string resultMessage = newSpecimenEditModel.EditSpecimen(newSpecimenEditView.NewSpecimenViewCode,
                                                                     newSpecimenEditView.NewSpecimenViewName,
                                                                     newSpecimenEditView.NewSpecimenEditDefaultTubeCode, true);
            if (string.IsNullOrEmpty(resultMessage))
            {
                newSpecimenEditView.ResultMessage = "Specimen changed!";
            }
            else 
            {
                newSpecimenEditView.ResultMessage = resultMessage;
            }
        }          
    }
}

