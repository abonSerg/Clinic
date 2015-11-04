using System;

namespace Medicine.Clinic.Client.Presentation
{
    public interface INewIndicationEditView
    {
        event EventHandler EditOkClick;
        event EventHandler NewIndicationEditLoad;
        string NewIndicationViewCode { get; set; }
        string NewIndicationViewName { get; set; }
        string ResultMessage { get; set; }
        void Close();
    }
}
