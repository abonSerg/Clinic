using System;

namespace Medicine.Clinic.Client.Presentation
{
    public interface INewSexView
    {
        event EventHandler NewOkClick;
        string NewSexViewCode { get; set; }
        string NewSexViewName { get; set; }
        string ResultMessage { get; set; }
        bool OkEnabled { set; }
        void Close();

    }
}
