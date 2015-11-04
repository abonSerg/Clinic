using System;
using Medicine.Clinic.Client.Model;

namespace Medicine.Clinic.Client.Presentation
{
    public class OrderPresenter
    {
        readonly IOrderView orderView;
        readonly IOrderModel orderModel;

        public OrderPresenter(IOrderView orderView)
        {
            this.orderView = orderView;
            orderModel = new OrderModel();
            orderView.SearchClick += LoadSearchResultGrid;
            orderView.ClearClick += LoadAllOrderGrids;
            orderView.LoadForm += LoadAllOrderGrids;
        }

        void LoadSearchResultGrid(object sender, EventArgs e)
        {
             orderView.OrderViewGridControlData = orderModel.SearchOrders(orderView.ViewSearchName, orderView.ViewSearchCode);
        }

        void LoadAllOrderGrids(object sender, EventArgs e)
        {
            orderView.OrderViewGridControlData = orderModel.SearchOrders(string.Empty, string.Empty);
        }

    }
}
