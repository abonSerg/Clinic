using System;
using System.ComponentModel;
using Medicine.Clinic.Client.Model.SpecimenService;
using Medicine.Clinic.Client.Model.SexService;

namespace Medicine.Clinic.Client.Presentation
{
    public interface INewTestView
    {
        event EventHandler NewOkClick;
        string NewTestViewCode { get; }
        string NewTestViewName { get; }
        string NewTestViewCost { get; set; }
        string ResultMessage { get; set; }
        string DefaultSpecimenCode { get;}
        bool OkEnabled { set; }
        BindingList<DtoSpecimen> NewTestDefaultSpecimens { set; }
        BindingList<DtoSex> NewTestSexList { set; }
        string CheckedSexes { get; }
        void Close();
    }
}
