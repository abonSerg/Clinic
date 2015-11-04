using System;
using Medicine.Clinic.Client.Model;
using Medicine.Clinic.Client.Model.TubeService;
using Medicine.Clinic.Client.Presentation.ViewInterfaces;

namespace Medicine.Clinic.Client.Presentation
{
    public class NewTubePresenter
    {
        private INewTubeView newTubeView;
        private INewTubeModel newTubeModel;
        private DtoTube editTube;
        private bool isEdit;

        public NewTubePresenter(INewTubeView newTubeView)
        {
            this.newTubeView = newTubeView;
            this.newTubeModel = new NewTubeModel();
            newTubeView.SetModel(newTubeModel);
            newTubeView.NewOkClick += EditTube;
        }

        public NewTubePresenter(INewTubeView newTubeView, DtoTube editTube)
        {
            this.newTubeView = newTubeView;
            this.newTubeModel = new NewTubeModel();
            newTubeView.SetModel(newTubeModel);
            newTubeModel.Code = editTube.Code;
            newTubeModel.Name = editTube.Name;
            newTubeModel.Volume = editTube.Volume.ToString();
            newTubeView.NewOkClick += EditTube;
            this.editTube = editTube;
            isEdit = true;
        }

        void EditTube(object sender, EventArgs e)
        {
            int volume = ValidateVolume(newTubeModel.Volume);
            if (volume != 0 && ValidateCode(newTubeModel.Code))
            {
                var dtoTube = new DtoTube()
                {
                    Code = newTubeModel.Code,
                    Name = newTubeModel.Name,
                    Volume = volume,
                    IsEdit = isEdit
                };
                string resultMessage = new TubeServiceClient().EditTube(dtoTube);
                if (resultMessage == "s")
                {
                    newTubeView.ResultMessage = "Tube saved!";
                    newTubeModel.OkEnabling = false;
                }
                else if (resultMessage == "c")
                {
                    newTubeView.ResultMessage = "Tube changed";
                }
                else
                {
                    newTubeView.ResultMessage = resultMessage;
                }
            }
            else 
            {
                newTubeView.ResultMessage = "Invalid fields format!";
            }
        }

        static int ValidateVolume(string volumeString) 
        {
            int volume;
            if (int.TryParse(volumeString, out volume))
            {
                return volume;
            }
            else 
            {
                return 0;
            }
        }

        static bool ValidateCode(string code)
        {
            if (!string.IsNullOrEmpty(code)) 
            {
                return true;
            }
            else
            {
                return false;
            }
        }
           
    }
}

