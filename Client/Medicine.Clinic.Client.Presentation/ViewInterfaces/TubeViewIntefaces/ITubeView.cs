using System;
using System.ComponentModel;
using Medicine.Clinic.Client.Model;
using Medicine.Clinic.Client.Model.TubeService;

namespace Medicine.Clinic.Client.Presentation
{
    public interface ITubeView
    {
        event EventHandler SearchClick;
        event EventHandler ClearClick;
        event EventHandler LoadForm;
        void SetModel(ITubeModel tubeModel);
        BindingList<DtoTube> TubeViewGridControlData { set; }
    }
}
