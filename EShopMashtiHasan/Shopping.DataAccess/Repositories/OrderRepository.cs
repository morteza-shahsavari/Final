using DataAccessServiceContract.Services;
using Framework.BaseModel;
using Microsoft.EntityFrameworkCore;
using Shopping.DomainModel.DTO.OrdersAndOrderDetials;
using Shopping.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shopping.DataAccess.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        #region Fields

        private readonly EshopMashtiHasanContext _context;
      

        #endregion

        #region Ctor

        public OrderRepository(EshopMashtiHasanContext context)
        {
            _context = context;
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
            if(order == null) 
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
                return op.Failed("Delete Successfully"+ex.Message , orderId);
            }
        }

        public List<Orders> GetAll()
        {
            return _context.Orders.ToList();
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
               _context.Orders.Attach(order);
               _context.Entry(order).State = EntityState.Modified;
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

        public List<OrderDetails> GetAllOrderDetails()
        {
            return _context.OrderDetails.ToList();
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

        //public List<Orders> Search(OrderSearchModel sm , out int RecordCount)
        //{
        //    var q = from item in _context.Orders select item;
        //    if (sm.OrderID != null)
        //    {
        //        q = q.Where(x => x.OrderID == sm.OrderID);
        //    }
        //    if (sm.UserID != null)
        //    {
        //        q = q.Where(x => x.UserID == sm.UserID);
                
        //    }


        //    RecordCount = q.Count();
        //    return q.OrderByDescending(x => x.OrderID).Skip(sm.PageSize * sm.PageIndex).Take(sm.PageSize).ToList();

        //}

        #endregion
    }
}
