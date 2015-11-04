using System.ComponentModel;
using System.Data;
using Medicine.Clinic.Client.Model.GridControlsEntities;
using Medicine.Clinic.Client.Model.OrderService;
using DtoConcreteTest = Medicine.Clinic.Client.Model.TestService.DtoConcreteTest;

namespace Medicine.Clinic.Client.Model
{
    public interface IBillingModel
    {
        //BindingList<VisitForGrid> SearchVisits(string billingNumber);
        //BindingList<DtoOrder> LoadOrders(VisitForGrid visitFocusedRow);
        //BindingList<DtoConcreteTest> LoadConcreteTests(VisitForGrid visitFocusedRow);
        //string LoadTestsTotalCost(VisitForGrid visitFocusedRow);
        string SearchBillingNumber { get; set; }
        string TotalCost { get; set; }

    }
}
