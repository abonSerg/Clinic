using Medicine.Clinic.Client.Model.SexService;
using System;
using System.ComponentModel;

namespace Medicine.Clinic.Client.Presentation
{
    public interface ISexView
    {
        event EventHandler SearchClick;
        event EventHandler ClearClick;
        event EventHandler LoadForm;
        BindingList<DtoSex> SexViewGridControlData { set; }
        string ViewSearchCode { get; set; }
        string ViewSearchName { get; set; }
        
    }
}
