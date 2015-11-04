using System;
using System.ComponentModel;
using System.Data;
using ClinicDataSetAccess;
using Medicine.Clinic.Client.Model.GridControlsEntities;

namespace Medicine.Clinic.Client.Presentation
{
    public interface IVisitView
    {
        event EventHandler SearchClick;
        event EventHandler ClearClick;
        event EventHandler LoadForm;
        string VisitViewSearchMrn { get; set; }
        string VisitViewSearchFirstName { get; set; }
        string VisitViewSearchBillingNumber { get; set; }
        BindingList<VisitForGrid> VisitViewGridControlData { set; }
    }
}
