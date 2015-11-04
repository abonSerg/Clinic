using Medicine.Clinic.Client.Model.TubeService;
using System;
using System.ComponentModel;

namespace Medicine.Clinic.Client.Presentation
{
    public interface INewSpecimenView
    {
        event EventHandler NewOkClick;
        string NewSpecimenViewCode { get; }
        string NewSpecimenViewName { get; }
        string ResultMessage { get; set; }
        bool OkEnabled { set; }
        BindingList<DtoTube> NewSpecimenDefaultTubes { set; }
        string NewSpecimenEditDefaultTubeCode { get; }
        void Close();
    }
}
