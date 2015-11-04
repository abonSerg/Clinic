using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DtoOrder = Medicine.Clinic.Client.Model.OrderService.DtoOrder;
using DtoConcreteTest = Medicine.Clinic.Client.Model.TestService.DtoConcreteTest;
using Medicine.Clinic.Client.Model.GridControlsEntities;
using Medicine.Clinic.Client.Model;

namespace Medicine.Clinic.Client.Presentation
{
    public interface IBillingView
    {
        event EventHandler SearchClick;
        event EventHandler ClearClick;
        event EventHandler LoadForm;
        event EventHandler LoadOrdersClick;
        BindingList<VisitForGrid> BillingViewVisitsGridControlData { set; }
        BindingList<DtoOrder> BillingViewOrdersGridControlData { set; }
        BindingList<DtoConcreteTest> BillingViewTestsGridControlData { set; }
        VisitForGrid BillingViewVisitsFocuseGrid { get; }
        void SetModel(IBillingModel billingModel);
    }
}
