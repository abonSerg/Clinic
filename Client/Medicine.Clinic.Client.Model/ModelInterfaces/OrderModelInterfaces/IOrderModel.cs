using System.ComponentModel;
using Medicine.Clinic.Client.Model.OrderService;

namespace Medicine.Clinic.Client.Model
{
    public interface IOrderModel
    {
        BindingList<DtoOrder> SearchOrders(string number, string billingNumber);
    }
}
