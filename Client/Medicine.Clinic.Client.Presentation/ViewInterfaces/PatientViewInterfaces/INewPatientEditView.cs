using Medicine.Clinic.Client.Model.SexService;
using System;
using System.ComponentModel;

namespace Medicine.Clinic.Client.Presentation
{
    public interface INewPatientEditView
    {
        event EventHandler NewPatientEditLoad;
        event EventHandler NewPatientEditSwitch;
        event EventHandler EditOkClick;
        string NewPatientViewMrn { get; set; }
        string NewPatientViewFirstName { get; set; }
        string NewPatientViewLastName { get; set; }
        string NewPatientViewMiddleName { get; set; }
        string NewPatientViewSsn { get; set; }
        DateTime NewPatientViewDob { get; set; }
        DateTime? NewPatientViewDod { get; set; }
        string NewPatientEditSexCode { get; set; }
        BindingList<DtoSex> NewPatientSexes { set; }
        bool NewPatientVievMrnIsReadOnly { set; }
        bool IsSsnFull { get; }
        bool NewPatientVievFirstNameIsReadOnly { set; }
        bool NewPatientVievLastNameIsReadOnly { set; }
        bool NewPatientVievMiddleNameIsReadOnly { set; }
        bool NewPatientVievSsnIsReadOnly { set; }
        bool NewPatientVievDobIsReadOnly { set; }
        bool NewPatientVievSexIsReadOnly { set; }
        bool NewPatientVievDodIsReadOnly { set; }
        string NewPatientAge { set; }
        string ResultMessage { get; set; }
        void Close();
    }
}
