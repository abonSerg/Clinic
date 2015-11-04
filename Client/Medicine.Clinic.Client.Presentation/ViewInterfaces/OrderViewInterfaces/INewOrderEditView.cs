using System;
using System.ComponentModel;
using System.Data;
using Medicine.Clinic.Client.Model.GridControlsEntities;
using DtoTest = Medicine.Clinic.Client.Model.TestService.DtoTest;
using DtoSpecimen = Medicine.Clinic.Client.Model.SpecimenService.DtoSpecimen;
using DtoTube = Medicine.Clinic.Client.Model.TubeService.DtoTube;
using DtoIndication = Medicine.Clinic.Client.Model.IndicationService.DtoIndication;

namespace Medicine.Clinic.Client.Presentation
{
    public interface INewOrderEditView
    {
        event EventHandler LoadEditForm;
        event EventHandler OrderEditClick;
        event EventHandler AddTestsToCheckBox;
        event EventHandler AddTubesToCheckBox;
        event EventHandler TestChoose;
        event EventHandler IndicationChoose;
        event EventHandler DeleteFocusedTest;
        event EventHandler DeleteFocuseTube;
        string DodResultMessage { set; }
        TubeForGrid FocusedTubeRow { get; }
        bool SaveButtonEnabled { set; }
        string ResultMessage { get; set; }
        string ClinicalInfo { get; set; }
        string FocusedCodeValueTest { get; set; }
        string FocusedCodeValueIndication { get; }
        string OrderNumber { get; set; }
        BindingList<TestForGrid> TestsViewGridControlData { get; set; }
        BindingList<SpecimenForGrid> SpecimensViewGridControlData { get; set; }
        BindingList<TubeForGrid> TubesViewGridControlData { get; set; }
        BindingList<IndicationForGrid> IndicationsViewGridControlData { get; set; }
        BindingList<DtoTest> NewOrderTestsList { set; }
        BindingList<DtoSpecimen> NewOrderSpecimensList { set; }
        BindingList<DtoTube> NewOrderTubesList { set; }
        BindingList<DtoIndication> NewOrderIndicationsList { set; }
        BindingList<TestForGrid> ConcreteTestsForTubeCheckBox { set; }
        BindingList<TubeForGrid> ConcreteTubesForSpecimenCheckBox { set; }
    }
}
