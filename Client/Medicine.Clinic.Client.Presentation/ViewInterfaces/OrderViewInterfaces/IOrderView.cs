using System;
using System.ComponentModel;
using Medicine.Clinic.Client.Model.OrderService;

namespace Medicine.Clinic.Client.Presentation
{
    public interface IOrderView
    {
        event EventHandler SearchClick;
        event EventHandler ClearClick;
        event EventHandler LoadForm;
        BindingList<DtoOrder> OrderViewGridControlData { set; }
        string ViewSearchName { get; set; }
        string ViewSearchCode { get; set; }
    }
}
