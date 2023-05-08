using Shopping.DomainModel.ViewModel.Orders;
using System.Collections.Generic;

namespace EShopMashtiHasan.ViewModel
{
    public class Basket
    {
        #region Ctor

        public Basket()
        {
            Orders = new OrdersViewModel();
            OrderDetails = new List<OrderItemsViewModel>();
        }

        #endregion

        public OrdersViewModel Orders { get; set; }
        public List<OrderItemsViewModel> OrderDetails { get; set; }
    }
}
