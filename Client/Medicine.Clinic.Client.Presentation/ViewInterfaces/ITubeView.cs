using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISD.Clinic.Client.Model;

namespace ISD.Clinic.Client.Presentation
{
    public interface ITubeView
    {
        event EventHandler searchClick;
        event EventHandler clearClick;
        BindingList<Object> TubeViewGridControlData { set; }
        string TubeViewSearchCode { get; set; }
        string TubeViewSearchName { get; set; }
    }
}
