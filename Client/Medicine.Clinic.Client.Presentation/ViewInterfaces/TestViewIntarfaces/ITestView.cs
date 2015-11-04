using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medicine.Clinic.Client.Model.TestService;

namespace Medicine.Clinic.Client.Presentation
{
    public interface ITestView
    {
        event EventHandler SearchClick;
        event EventHandler ClearClick;
        event EventHandler LoadForm;
        BindingList<DtoTest> TestViewGridControlData { set; }
        string ViewSearchCode { get; set; }
        string ViewSearchName { get; set; }
    }
}
