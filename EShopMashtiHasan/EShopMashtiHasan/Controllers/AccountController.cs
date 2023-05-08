using EShopMashtiHasan.Helper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Security.BuessinessServiceContract.Services;
using Security.Domain.DTO.User;
using Security.Domain.Models;
using Security.Framework.Services;
using Shopping.BusinessServiceContract.Services;
using Shopping.DomainModel.Models;
using System.Linq;
using System.Security.Claims;

//using NewsCore.Domain.Commands.User;

namespace EShopMashtiHasan.Controllers
{

    public class AccountController : Controller
    {

        private readonly IAccountApplication _accountbuss;
        private readonly IPasswordHasher passwordHasher;
        private readonly IAuthHelper _authHelper;
        private readonly IOrderBuss _orderBuss;
        private readonly ISessionHelper _sessionHelper;

        public AccountController(IAccountApplication accountApplication, IPasswordHasher passwordHasher, IAuthHelper authHelper, IOrderBuss orderBuss, ISessionHelper sessionHelper)
        {
            this.passwordHasher = passwordHasher;
            _accountbuss = accountApplication;
            this._authHelper = authHelper;
            _orderBuss = orderBuss;
            _sessionHelper = sessionHelper;
        }

        // GET: Account
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            var t = Request.Path.Value;
            return View();
        }
        public ActionResult SignOut()
        {
            _authHelper.Signout();
            return RedirectToAction("Login", "Account");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login l)
        {

            var op = _accountbuss.Login(l);
            if (!op.Success)
            {
                ViewBag.ErrorMessage = op.Message;
                return View(l);
            }
            
            var returnUrl = Request.Query["returnUrl"].ToString();
            if (returnUrl == "/Orders/Payment") 
            {
                return RedirectToAction("OrdersDetails","Orders");
            }

            return RedirectToAction("Index", "Home");
        }



        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User u)
        {
            u.Password = passwordHasher.Hash(u.Password);
            _accountbuss.Register(u);
            return View();
        }
        public ActionResult AccessDenied()
        {
            return View();
        }

        private void AddOrderToDb()
        {
            var basket = _sessionHelper.GetCurrentBasket();
            var userId = int.Parse(User.FindFirstValue("UserID").ToString());
            var order = _orderBuss.GetByUserId(userId);
            if (basket.OrderDetails != null && basket.OrderDetails.Count() > 0 && basket.OrderDetails.Any())
            {
                if (order != null)
                {
                    var ordersDetails = _orderBuss.GetAllOrderDetailsByOrderId(order.OrderID);
                    foreach (var basketOrderDetails in basket.OrderDetails)
                    {
                        if (ordersDetails != null && ordersDetails.Count() > 0 && ordersDetails.Any())
                        {
                            foreach (var od in ordersDetails)
                            {
                                if (od.ProductID == basketOrderDetails.ProductID)
                                {
                                    od.Quantity += 1;
                                    od.TotalPrice = od.Quantity * od.UnitPrice;

                                    _orderBuss.UpdateOrderDetails(od);
                                }
                            }
                        }
                    }
                }
                else
                {
                    order = new Orders
                    {
                        UserID = userId,
                        TotalAmount = basket.OrderDetails.Sum(x => x.Quantity * x.UnitPrice),
                        OrderDate = System.DateTime.Now
                    };
                    _orderBuss.AddOrder(order);

                    foreach (var basketOrderDetails in basket.OrderDetails)
                    {
                        var orderDetails = new OrderDetails
                        {
                            UnitPrice = basketOrderDetails.UnitPrice,
                            OrderID = order.OrderID,
                            ProductID = basketOrderDetails.ProductID,
                            Quantity = basketOrderDetails.Quantity,
                            TotalPrice = basketOrderDetails.TotalPrice
                        };

                        _orderBuss.UpdateOrderDetails(orderDetails);
                    }
                }
            }
        }
    }
}