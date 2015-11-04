using Medicine.Clinic.Client.Model.SexService;
using System;
using System.ComponentModel;

namespace Medicine.Clinic.Client.Presentation
{
    public interface INewPatientView
    {
        event EventHandler NewOkClick;
        string NewPatientViewMrn { get; set; }
        bool OkEnabled { set; }
        string NewPatientViewFirstName { get; }
        string NewPatientViewLastName { get; }
        string NewPatientViewMiddleName { get; }
        string NewPatientViewSsn { get; }
        bool NewPatientVievDodIsReadOnly { set; }
        bool NewPatientVievMrnIsReadOnly { set; }
        bool IsSsnFull { get; }
        DateTime NewPatientViewDob { get; }
        DateTime? NewPatientViewDod { get; }
        string ResultMessage { get; set; }
        BindingList<DtoSex> NewPatientSexes { set; }
        string NewPatientEditSexCode { get; }
        void Close();
    }
}
