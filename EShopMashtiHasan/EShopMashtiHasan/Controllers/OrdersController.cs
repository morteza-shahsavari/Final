using EShopMashtiHasan.Helper;
using EShopMashtiHasan.Helper.Keys;
using EShopMashtiHasan.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using ZarinpalSandbox;
using System;
using Shopping.BusinessServiceContract.Services;
using Shopping.DomainModel.ViewModel.Orders;
using Shopping.DomainModel.Models;
using Security.BuessinessServiceContract.Services;
using Shopping.DomainModel.DTO.OrdersAndOrderDetials;
using Security.Buessiness.Impelements;
using Framework.Utility;

namespace EShopMashtiHasan.Controllers
{

    public class OrdersController : Controller
    {
        #region Fields

        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ISessionHelper _sessionHelper;
        private readonly IProductBuss productBuss;
        private readonly IOrderBuss _orderBuss;
        private readonly IAuthHelper _authHelper;
        private readonly IUserBuss _userBuss;


        #endregion

        #region Ctor
        public OrdersController(IHttpContextAccessor httpContextAccessor, IUserBuss _userBuss, IAuthHelper _authHelper, ISessionHelper sessionHelper, IProductBuss productBuss, IOrderBuss orderBuss)
        {
            this.httpContextAccessor = httpContextAccessor;
            _sessionHelper = sessionHelper;
            this.productBuss = productBuss;
            this._orderBuss = orderBuss;
            this._authHelper = _authHelper;
            this._userBuss = _userBuss;
        }
        #endregion

        #region Events

        public IActionResult Index()

        {
            var basket = new Basket();
            var currentBasket = _sessionHelper.GetCurrentBasket();
            if (currentBasket != null && currentBasket.Orders != null)
            {
                basket.OrderDetails = currentBasket.OrderDetails;
            }

            return View(basket);
        }

        public IActionResult OrdersDetails()
        {
            var basket = _sessionHelper.GetCurrentBasket();
            return View(basket.OrderDetails);
        }

        [HttpPost]
        public JsonResult AddToBasket(int productId)
        {
            var product = productBuss.Get(productId);
            var basket = _sessionHelper.GetCurrentBasket();
            if (product != null)
            {
                if (basket.OrderDetails.Any(x => x.ProductID == productId))
                {
                    var od = basket.OrderDetails.FirstOrDefault(x => x.ProductID == productId);

                    od.Quantity++;
                    od.TotalPrice = product.UnitPrice * od.Quantity;
                    CurrentBasket current = new CurrentBasket(_sessionHelper, basket);
                    basket.OrderDetails.Add(new OrderItemsViewModel
                    {
                        ProductID = productId,
                        Quantity = od.Quantity,
                        TotalPrice = od.TotalPrice ,
                        UnitPrice = od.UnitPrice,
                    });
                    _sessionHelper.AddCurrentBasketToSession(current.MyBasket);
                }
                else
                {
                    basket.OrderDetails.Add(new OrderItemsViewModel
                    {
                        ProductID = productId,
                        Image = product.Picture1 ?? product.Picture2,
                        ProductName = product.ProductName,
                        Quantity = 1,
                        UnitPrice = product.UnitPrice,
                        TotalPrice = product.UnitPrice 
                    });

                    CurrentBasket current = new CurrentBasket(_sessionHelper, basket);
                    _sessionHelper.AddCurrentBasketToSession(current.MyBasket);
                }
            }
            var count = basket.OrderDetails.Count();
            return Json(new { success = true, message = "Add", count = count });
        }

        public IActionResult Payment()
        {
            var basket = _sessionHelper.GetCurrentBasket();
            if (User.Identity.IsAuthenticated)
            {
                var userID = int.Parse(User.FindFirstValue("UserID"));
                var Address = _userBuss.GetUser(userID).Address;
                var userEmail = User.FindFirstValue("Email");
                var userMbile = User.FindFirstValue("Mobile");
               // var userAddress = User.FindFirstValue("Address");
                var order = new Orders
                {
                    OrderDate = System.DateTime.Now,
                    RequiredDate = System.DateTime.Now,
                    Mobile=userMbile,
                    UserID = userID,
                    TotalAmount = basket.OrderDetails.Sum(x => x.TotalPrice),
                    OrderDescription = $"سبد خرید کاربر{userID}",
                    Address = Address
                };

                _orderBuss.AddOrder(order);

                foreach (var od in basket.OrderDetails)
                {
                    var orderDetails = new OrderDetails();
                    orderDetails.OrderID = order.OrderID;
                    orderDetails.UnitPrice = od.UnitPrice;
                    orderDetails.Quantity = od.Quantity;
                    orderDetails.TotalPrice = od.TotalPrice;
                    orderDetails.ProductID = od.ProductID;

                    _orderBuss.AddOrderDetails(orderDetails);
                }

                var payment = new Payment(Convert.ToInt32(order.TotalAmount));
                var res = payment.PaymentRequest($"پرداخت فاکتور شماره{order.OrderID}", "http://localhost:18260/Orders/OnlinePayment/" + order.OrderID, userEmail, userMbile);
                if (res.Result.Status == 100)
                {
                    return Redirect("https://sandbox.zarinpal.com/pg/StartPay/" + res.Result.Authority);
                }
                else
                {
                    return BadRequest();
                }
            }

            var returnUrl = Request.Path.Value.ToString();
            return Redirect("/Account/Login?returnUrl=" + returnUrl);
        }

        public IActionResult OnlinePayment(int id)
        {
            if (HttpContext.Request.Query["Status"] != "" &&
                    HttpContext.Request.Query["Status"].ToString().ToLower() == "ok" &&
                    HttpContext.Request.Query["Authority"] != "")
            {
                string authority = HttpContext.Request.Query["Authority"].ToString();
                var order = _orderBuss.GetById(id);
                var payment = new Payment(Convert.ToInt32(order.TotalAmount));
                var res = payment.Verification(authority).Result;
                if (res.Status == 100)
                {
                    order.IsFainaly = true;
                    _orderBuss.UpdateOrder(order);
                    _sessionHelper.RemoveCurrentBasketFromSession(SessionKeys.CurrentBasketKey);
                    ViewBag.Code = res.RefId;
                    return View();
                }
                else {
                    return NotFound();
                }
            }

            return View();
        }

        #endregion

        #region Track orders
        public IActionResult OrderDetailsUser(int id)
        {
         
                    var q = _orderBuss.GetAllOrderDetailsListByOrderId(id);
                     return View(q);
              
        }

        public IActionResult OrdersUser(int id)
        {
            var user = _authHelper.GetCurrentUserInfo();
            if (User.Identity.IsAuthenticated)
            {
                if (user.UserID == id)
                {
                    var PA = _orderBuss.GetAllByUserId(id);
                    var q =PA.OrderByDescending(x=>x.OrderDate).Select(x => new OrderListItemUser
                    {
                        OrderDescription=x.OrderDescription,
                        OrderDate = PersianDateCalender.ToPersian(x.OrderDate),
                        OrderID=x.OrderID,
                        UserName=user.UserName,
                        RequiredDate = PersianDateCalender.ToPersian(x.RequiredDate),
                        Address=x.Address,
                        TotalAmount=x.TotalAmount,
                        IsFainaly= x.IsFainaly == false ? "پرداخت نشده" : "پرداخت شده",
                    });

                    return View(q);
                }
            }
          
            return RedirectToAction("Login", "Account");
        }




        public IActionResult ViewCardDown()
        {
            return ViewComponent("CartDropdown");
        }
        #endregion

    }
}
