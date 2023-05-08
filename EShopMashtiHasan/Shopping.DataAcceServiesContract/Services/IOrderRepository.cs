using Framework.BaseModel;
using Framework.Shopping.Base;
using Shopping.DomainModel.DTO.Category;
using Shopping.DomainModel.DTO.OrdersAndOrderDetials;
using Shopping.DomainModel.Models;
using System.Collections.Generic;

namespace DataAccessServiceContract.Services
{
    public interface IOrderRepository
    {
        #region Order
        OperationResult AddOrder(Orders order);
        OperationResult UpdateOrder(Orders order);
        OperationResult DeleteOrder(int OrderId);
        Orders GetById(int OrderId);
        List<Orders> GetAll();
        List<Orders> GetAllByUserId(int userId);

        #endregion

        #region OrderDetails

        OperationResult AddOrderDetails(OrderDetails orderDetails);
        OperationResult UpdateOrderDetails(OrderDetails orderDetails);
        OperationResult DeleteOrderDetails(int orderDetailsID);
        OrderDetails GetOrderDetailsById(int OrderDetailsId);
        List<OrderDetails> GetAllOrderDetails();

       // List<Orders> Search(OrderSearchModel sm, out int RecordCount);

        #endregion
    }
}
