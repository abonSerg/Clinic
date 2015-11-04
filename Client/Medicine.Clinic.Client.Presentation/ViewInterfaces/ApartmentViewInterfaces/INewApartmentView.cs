using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medicine.Clinic.Client.Model.ClinicService;

namespace Medicine.Clinic.Client.Presentation
{
    public interface INewApartmentView
    {
        event EventHandler NewOkClick;
        BindingList<DtoClinic> NewApartmentsViewClinics { set; }
        string NewApartmentEditClinicCode { set; }
        bool OkEnabled { set; }
        string ClinicEditValue { get; }
        string ResultMessage { get; set; }
        string NewApartmentViewRoomId { get; set; }
        string NewApartmentViewBedId { get; set; }
    }
}
