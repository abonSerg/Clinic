using Medicine.Clinic.Client.Model.TubeService;
using System;
using System.ComponentModel;

namespace Medicine.Clinic.Client.Presentation
{
    public interface INewSpecimenEditView
    {
        string NewSpecimenViewCode { get; set; }
        string NewSpecimenViewName { get; set; }
        BindingList<DtoTube> NewSpecimenDefaultTubes { set; }
        event EventHandler NewSpecimenEditLoad;
        event EventHandler EditOkClick;
        string NewSpecimenEditDefaultTubeCode { get; set; }
        string ResultMessage { get; set; }
        void Close();
    }
}
