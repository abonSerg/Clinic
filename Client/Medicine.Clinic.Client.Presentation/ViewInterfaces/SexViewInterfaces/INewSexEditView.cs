using System;

namespace Medicine.Clinic.Client.Presentation
{
    public interface INewSexEditView
    {
        event EventHandler EditOkClick;
        event EventHandler NewSexEditLoad;
        string NewSexViewCode { get; set; }
        string NewSexViewName { get; set; }
        string ResultMessage { get; set; }
        void Close();
    }
}
