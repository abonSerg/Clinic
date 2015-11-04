using System;
using System.ComponentModel;
using System.Data;
using Medicine.Clinic.Client.Model.GridControlsEntities;

namespace Medicine.Clinic.Client.Presentation
{
    public interface INewVisitView
    {
        event EventHandler NewOkClick;
        event EventHandler ApartmentChoose;
        BindingList<PatientForGrid> NewVisitPatients { set; }
        BindingList<DoctorForGrid> NewVisitDoctors { set; }
        BindingList<ApartmentForGrid> NewVisitApartments { set; }
        string PatientFocusedRow { get; }
        string DoctorFocusedRow { get; set; }
        int ApartmentFocusedRow { get; }
        string NewVisitBillingNumber { set; get;}
        string ResultMessage { get; set; }
        bool OkEnabled { set; }
    }
}
