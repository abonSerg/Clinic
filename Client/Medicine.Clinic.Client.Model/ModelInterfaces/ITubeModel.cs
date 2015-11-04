using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ISD.Clinic.Client.Model
{
    public interface ITubeModel
    {
        BindingList<Object> TubeModelGridControlData {get;}
        string TubeModelSearchCode {set;}
        string TubeModelSearchName {set;}

    
    }
}
