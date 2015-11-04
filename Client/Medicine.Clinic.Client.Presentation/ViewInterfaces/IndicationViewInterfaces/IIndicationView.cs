using Medicine.Clinic.Client.Model.IndicationService;
using System;
using System.ComponentModel;

namespace Medicine.Clinic.Client.Presentation
{
    public interface IIndicationView
    {
        event EventHandler SearchClick;
        event EventHandler ClearClick;
        event EventHandler LoadForm;
        BindingList<DtoIndication> IndicationViewGridControlData { set; }
        string ViewSearchCode { get; set; }
        string ViewSearchName { get; set; }
    }
}
