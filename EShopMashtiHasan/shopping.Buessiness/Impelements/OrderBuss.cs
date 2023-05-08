using Framework.BaseModel;
using Microsoft.EntityFrameworkCore;
using Shopping.BusinessServiceContract.Services;
using Shopping.DomainModel.DTO.OrdersAndOrderDetials;
using Shopping.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace shopping.Buessiness.Impelements
{
    public class OrderBuss : IOrderBuss
    {
        #region Fields

        private readonly EshopMashtiHasanContext _context;
      // private readonly IOrderBuss orderBuss;

        #endregion

        #region Ctor

        public OrderBuss(EshopMashtiHasanContext context/*, IOrderBuss orderBuss*/)
        {
            _context = context;
            //this.orderBuss = orderBuss;
        }

        #endregion

        #region Order

        public OperationResult AddOrder(Orders order)
        {
            var op = new OperationResult("Add new Order");
            try
            {
                _context.Orders.Add(order);
                _context.SaveChanges();
                return op.Succeed("Add Successfully", order.OrderID);
            }
            catch (System.Exception ex)
            {
                return op.Failed("Add Failed " + ex.Message, order.OrderID);
            }
        }

        public OperationResult DeleteOrder(int orderId)
        {
            var op = new OperationResult("Delete Order");
            var order = _context.Orders.FirstOrDefault(o => o.OrderID == orderId);
            if (order == null)
            {
                return op.Failed("order does not Exist", orderId);
            }

            try
            {
                _context.Orders.Remove(order);
                _context.SaveChanges();
                return op.Succeed("Delete Successfully", orderId);
            }
            catch (System.Exception ex)
            {
                return op.Failed("Delete Successfully" + ex.Message, orderId);
            }
        }

        public List<Orders> GetAll()
        {
            return _context.Orders.ToList();
        }

        public Orders GetByUserId(int userId)
        {
            return _context.Orders.FirstOrDefault(o => o.UserID == userId);
        }
        public List<Orders> GetAllByUserId(int userId)
        {
            return _context.Orders.Where(o => o.UserID == userId).ToList();
        }

        public Orders GetById(int orderId)
        {
            return _context.Orders.FirstOrDefault(o => o.OrderID == orderId);
        }

        public OperationResult UpdateOrder(Orders order)
        {
            OperationResult op = new OperationResult("Update Orders", order.OrderID);
            try
            {
                var o = _context.Orders.FirstOrDefault(o => o.OrderID == order.OrderID);
                o.RequiredDate = order.RequiredDate;
                o.OrderDate = order.OrderDate;
                o.TotalAmount = order.TotalAmount;
                o.OrderDescription = order.OrderDescription;
                o.UserID = order.UserID;
                o.IsFainaly = order.IsFainaly;

                _context.SaveChanges();
                return op.Succeed("Update Successfully", order.OrderID);
            }
            catch (Exception ex)
            {
                return op.Failed("Update Failed " + ex.Message, order.OrderID);
            }
        }

        #endregion

        #region OrderDetails

        public OperationResult UpdateOrderDetails(OrderDetails orderDetails)
        {
            OperationResult op = new OperationResult("Update Orders", orderDetails.OrderDetailsID);
            try
            {
                _context.OrderDetails.Attach(orderDetails);
                _context.Entry(orderDetails).State = EntityState.Modified;
                _context.SaveChanges();
                return op.Succeed("Update Successfully", orderDetails.OrderDetailsID);
            }
            catch (Exception ex)
            {
                return op.Failed("Update Failed " + ex.Message, orderDetails.OrderDetailsID);
            }
        }

        public OrderDetails GetOrderDetailsById(int orderDetailsId)
        {
            return _context.OrderDetails.FirstOrDefault(od => od.OrderDetailsID == orderDetailsId);
        }

        public List<OrderDetails> GetAllOrderDetailsByOrderId(int orderId)
        {
            return _context.OrderDetails.Where(od => od.OrderID == orderId).ToList();
             

        }
        public List<OrderDetilsListItem> GetAllOrderDetailsListByOrderId(int orderId)
        {
            var q = _context.OrderDetails.Where(od => od.OrderID == orderId).Select(x => new OrderDetilsListItem
            {
                OrderDetailsID = x.OrderDetailsID,
                OrderID = x.OrderID,
                ProductName = x.Product.ProductName,
                Quantity = x.Quantity,
                UnitPrice = x.UnitPrice,
                TotalPrice = x.TotalPrice,
            }).ToList();

            return q;

        }

        public OperationResult DeleteOrderDetails(int orderDetailsID)
        {
            var op = new OperationResult("Delete OrderDEtails");
            var orderDeteil = _context.OrderDetails.FirstOrDefault(o => o.OrderDetailsID == orderDetailsID);
            if (orderDeteil == null)
            {
                return op.Failed("orderDetails does not Exist", orderDetailsID);
            }

            try
            {
                _context.OrderDetails.Remove(orderDeteil);
                _context.SaveChanges();
                return op.Succeed("Delete Successfully", orderDetailsID);
            }
            catch (System.Exception ex)
            {
                return op.Failed("Delete Successfully" + ex.Message, orderDetailsID);
            }
        }

        public OperationResult AddOrderDetails(OrderDetails orderDetails)
        {
            var op = new OperationResult("Add new OrderDetail");
            try
            {
                _context.OrderDetails.Add(orderDetails);
                _context.SaveChanges();
                return op.Succeed("Add Successfully", orderDetails.OrderDetailsID);
            }
            catch (System.Exception ex)
            {
                return op.Failed("Add Failed " + ex.Message, orderDetails.OrderDetailsID);
            }
        }

        public OrderDetails GetOrderDetailsByProductId(int prodictId)
        {
            return _context.OrderDetails.FirstOrDefault(o => o.ProductID == prodictId);
        }

        public List<Orders> Search(OrderSearchModel sm, out int RecordCount)
        {
            //return orderBuss.Search(sm, out RecordCount);

            var q = from item in _context.Orders select item;
            
            if ( sm.OrderID != 0)
            {
                q = q.Where(x => x.OrderID == sm.OrderID);
            }
            if (!string.IsNullOrEmpty(sm.Mobile))
            {
                q = q.Where(x => x.Mobile.StartsWith(sm.Mobile));
            }


            RecordCount = q.Count();
            return q.OrderByDescending(x => x.OrderDate).Skip(sm.PageSize * sm.PageIndex).Take(sm.PageSize).ToList();
        }

        public OperationResult UpdateIsFainaly(int orderid, bool Fainaly)
        {
            var op = new OperationResult("Update  IsFainaly Order");
            try
            {
                var o = _context.Orders.FirstOrDefault(x => x.OrderID == orderid);
                if (o == null)
                {
                    return op.Failed("No Exits Order");
                }
                o.IsFainaly= Fainaly;
                _context.SaveChanges();
                return op.Succeed("Update  IsFainaly Order Successfuly ");
            }
            catch (Exception ex)
            {
                return op.Failed("To Failed"+ex.Message);

            }
            

        }



        #endregion
    }
}
