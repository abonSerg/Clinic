using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISD.Clinic.Client.Presentation.ViewInterfaces
{
    public interface INewTubeView
    {
        event EventHandler okClick;
        string NewTubeViewCode { get; }
        string NewTubeViewName { get;}
        int NewTubeViewVolume { get;}
    }
}
