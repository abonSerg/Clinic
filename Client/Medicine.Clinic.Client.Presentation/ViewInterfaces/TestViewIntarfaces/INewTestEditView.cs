using System;
using System.ComponentModel;
using Medicine.Clinic.Client.Model.SexService;
using Medicine.Clinic.Client.Model.SpecimenService;

namespace Medicine.Clinic.Client.Presentation
{
    public interface INewTestEditView
    {
        string NewTestViewCode { get; set; }
        string NewTestViewName { get; set; }
        string NewTestViewCost { get; set; }
        string DefaultSpecimenCode { get; set; }
        BindingList<DtoSpecimen> NewTestDefaultSpecimens { set; }
        event EventHandler NewTestEditLoad;
        event EventHandler EditOkClick;
        string ResultMessage { get; set; }
        BindingList<DtoSex> NewTestSexList { set; }
        string CheckedTestSexAllowed { set; }
        string CheckedSexes { get; }
        void Close();      
    }
}
