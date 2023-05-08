using Framework.BaseModel;
using Shopping.DomainModel.DTO.OrdersAndOrderDetials;
using Shopping.DomainModel.Models;
using System.Collections.Generic;

namespace Shopping.BusinessServiceContract.Services
{
    public interface IOrderBuss
    {
        #region Order

        OperationResult AddOrder(Orders order);
        OperationResult UpdateOrder(Orders order);
        OperationResult DeleteOrder(int OrderId);
        List<Orders> GetAllByUserId(int userId);
        Orders GetById(int OrderId);
        List<Orders> GetAll();
        Orders GetByUserId(int userId);

        #endregion

        #region OrderDetails

        OperationResult AddOrderDetails(OrderDetails orderDetails);
        OperationResult UpdateOrderDetails(OrderDetails orderDetails);
        OperationResult DeleteOrderDetails(int orderDetailsID);
        OrderDetails GetOrderDetailsById(int orderDetailsId);
        OrderDetails GetOrderDetailsByProductId(int prodictId);
        List<OrderDetails> GetAllOrderDetailsByOrderId(int orderId);
        List<OrderDetilsListItem> GetAllOrderDetailsListByOrderId(int orderId);
        List<Orders> Search(OrderSearchModel sm, out int RecordCount);


        OperationResult UpdateIsFainaly(int orderid, bool Fainaly);

        #endregion
    }
}
