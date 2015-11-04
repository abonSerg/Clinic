using System;
using System.ComponentModel;
using Medicine.Clinic.Client.Model.ApartmentService;

namespace Medicine.Clinic.Client.Presentation
{
    public interface IApartmentView
    {
        event EventHandler SearchClick;
        event EventHandler ClearClick;
        event EventHandler LoadForm;
        BindingList<DtoApartment> ApartmentViewGridControlData { set; }
        string ApartmentViewSearchClinicName { get; set; }
    }
}
