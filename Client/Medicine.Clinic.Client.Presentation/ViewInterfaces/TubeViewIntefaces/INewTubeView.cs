using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medicine.Clinic.Client.Model;

namespace Medicine.Clinic.Client.Presentation.ViewInterfaces
{
    public interface INewTubeView
    {
        event EventHandler NewOkClick;
        string ResultMessage { get; set; }
        void SetModel(INewTubeModel newTubeModel);
        //event EventHandler NewOkClick;
        //string NewTubeViewCode { get; set; }
        //string NewTubeViewName { get; set; }
        //string NewTubeViewVolume { get; set; }
        //string ResultMessage { get; set;}
        //void Close();
    }
}
