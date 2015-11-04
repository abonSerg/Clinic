using System;
using System.ComponentModel;
using Medicine.Clinic.Client.Model;
using Medicine.Clinic.Client.Model.TubeService;


namespace Medicine.Clinic.Client.Presentation
{
    public class TubePresenter
    {
        readonly ITubeView tubeView;
        readonly ITubeModel tubeModel;

        public TubePresenter(ITubeView tubeView)
        {
            this.tubeView = tubeView;
            this.tubeModel = new TubeModel();
            tubeView.LoadForm += LoadAllTubeGrids;
            tubeView.SearchClick += LoadSearchResultGrid;
            tubeView.ClearClick += LoadAllTubeGrids;
            tubeView.SetModel(tubeModel);
        }

        void LoadSearchResultGrid(object sender, EventArgs e)
        {
            DtoTube dtoTube = new DtoTube()
            {
                Code = tubeModel.SearchCode,
                Name = tubeModel.SearchName
            };

             tubeView.TubeViewGridControlData = new BindingList<DtoTube>(new TubeServiceClient().FindTubes(dtoTube));
        }

        void LoadAllTubeGrids(object sender, EventArgs e)
        {
            DtoTube dtoTube = new DtoTube()
            {
                Code = string.Empty,
                Name = string.Empty
            };

            tubeView.TubeViewGridControlData = new BindingList<DtoTube>(new TubeServiceClient().FindTubes(dtoTube));
        }
    }
}       
      
  
