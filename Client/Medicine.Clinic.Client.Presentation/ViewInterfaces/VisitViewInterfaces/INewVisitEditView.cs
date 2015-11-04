using System;
using System.ComponentModel;
using System.Data;
using Medicine.Clinic.Client.Model.GridControlsEntities;

namespace Medicine.Clinic.Client.Presentation
{
    public interface INewVisitEditView
    {
        event EventHandler NewOkEditClick;
        event EventHandler NewVisitEditLoad;
        event EventHandler ApartmentChoose;
        BindingList<PatientForGrid> NewVisitPatients { set; }
        BindingList<DoctorForGrid> NewVisitDoctors { set; }
        BindingList<ApartmentForGrid> NewVisitApartments { set; }
        string PatientFocusedRow { get; set; }
        string DoctorFocusedRow { get; set; }
        int ApartmentFocusedRow { get; set; }
        string NewVisitBillingNumber { set; get; }
        string ResultMessage { get; set; }
    }
}
