using System.ComponentModel;
using Medicine.Clinic.Client.Model.OrderService;

namespace Medicine.Clinic.Client.Model
{
    public class OrderModel : IOrderModel
    {
        public BindingList<DtoOrder> SearchOrders(string number, string billingNumber)
        {
            DtoOrder dtoOrder = new DtoOrder()
            {
                Number = number,
                Visit = new DtoVisit()
                {
                    BillingNumber = billingNumber
                }
            };
            return new BindingList<DtoOrder>(new OrderServiceClient().FindOrders(dtoOrder));
        }
    }
}
