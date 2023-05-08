using EShopMashtiHasan.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Security.BuessinessServiceContract.Services;
using Security.Domain.DTO.User;
using Shopping.BusinessServiceContract.Services;
using Shopping.DomainModel.DTO.Product;
using Shopping.DomainModel.ViewModel.Categories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

using System.Security.Claims;

namespace EShopMashtiHasan.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAuthHelper _authHelper;
        private readonly IProductBuss _productBuss;
        private readonly ISupplierBuss _supplierBuss;
        private readonly ICatBuss _catBuss;
        private readonly IAccountApplication _accountApplication;

        private List<kwp> GenerateList(object o)
        {
            return null;
        }
        public HomeController(IAuthHelper _authHelper, IProductBuss productBuss, ISupplierBuss supplierBuss, ICatBuss catBuss, IAccountApplication accountApplication)
        {
            this._authHelper = _authHelper;
            _productBuss = productBuss;
            _supplierBuss = supplierBuss;
            _catBuss = catBuss;
            _accountApplication = accountApplication;
        }

        public IActionResult Index()
        {
            CategoryProductListItem categoryProductListItem = new CategoryProductListItem();
            var products = _productBuss.GetAll();
            var productListItems = products.Select(x => new ProductListItem
            {
                CategoryID = x.CategoryID,
                CategoryName = _catBuss.Get(x.CategoryID).CategoryName,
                Picture1 = x.Picture1 ?? x.Picture2,
                ProductID = x.ProductID,
                ProductName = x.ProductName,
                SupplierName = _supplierBuss.Get(x.SupplierID).SupplierName,
                UnitPrice = x.UnitPrice,
                ExpireDateSpecialOffer = x.ExpireDateSpecialOffer != null ? x.ExpireDateSpecialOffer.Value : DateTime.Now,
                ShowInAmazingOffer = x.ShowInAmazingOffer,
                ShowInInstantOffer = x.ShowInInstantOffer,
            }).ToList();
            categoryProductListItem.Products = productListItems;
            return View(categoryProductListItem);

        }

        public JsonResult CheckRoleType()
        {
            var user = _authHelper.GetCurrentUserInfo();
            var pr = new CheckPermission
            {
                UserName = user.UserName,
                ActionName = "Index",
                Controller = "PanelAdmin"
            };
         
          var isAuthenticated = User.Identity.IsAuthenticated;
            var isAdmin = false;

          if(_accountApplication.CheckIfUserHasaccess(pr))
            {
                isAdmin = true;
            }

             return Json(new { isAuthenticated, isAdmin });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
