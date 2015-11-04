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
    public interface INewOrderView
    {
        event EventHandler LoadForm;
        event EventHandler TestChoose;
        event EventHandler AddTestsToCheckBox;
        event EventHandler AddTubesToCheckBox;
        event EventHandler OrderSaveClick;
        event EventHandler IndicationChoose;
        event EventHandler DeleteFocusedTest;
        event EventHandler DeleteFocuseTube;
        string DodResultMessage { set; }
        bool SaveButtonEnabled { set; }
        TubeForGrid FocusedTubeRow { get; }
        BindingList<TestForGrid> TestsViewGridControlData { get; set; }
        BindingList<SpecimenForGrid> SpecimensViewGridControlData { get; set; }
        BindingList<TubeForGrid> TubesViewGridControlData { get; set; }
        BindingList<TestForGrid> ConcreteTestsForTubeCheckBox { set; }
        BindingList<TubeForGrid> ConcreteTubesForSpecimenCheckBox { set; }
        BindingList<IndicationForGrid> IndicationsViewGridControlData { get; set; }
        BindingList<DtoTest> NewOrderTestsList { set; }
        BindingList<DtoSpecimen> NewOrderSpecimensList { set; }
        BindingList<DtoTube> NewOrderTubesList { set; }
        BindingList<DtoIndication> NewOrderIndicationsList { set; }
        string FocusedCodeValueIndication { get; }
        string FocusedCodeValueTest { get; set; }
        string FocusedCodeValueSpecimen { get; }
        string FocusedCodeValueTube { get; }
        string ResultMessage { get; set; }
        int FocusedTestIndex { get; }
        string OrderNumber { get; set; }
        string ClinicalInfo { get; set; }
    }
}
