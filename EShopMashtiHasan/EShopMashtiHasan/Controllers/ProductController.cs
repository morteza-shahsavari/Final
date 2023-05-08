using EShopMashtiHasan.Helper;
using EShopMashtiHasan.Helper.Keys;
using EShopMashtiHasan.ViewModel;
using Microsoft.AspNetCore.Mvc;
using shopping.Buessiness.Impelements;
using Shopping.BusinessServiceContract.Services;
using Shopping.DomainModel.Models;
using Shopping.DomainModel.ViewModel;
using Shopping.DomainModel.ViewModel.Orders;
using System.Linq;

namespace EShopMashtiHasan.Controllers
{
    public class ProductController : Controller
    {
        #region Fields

        private readonly IProductBuss _productBuss;
        private readonly ICatBuss _catBuss;
        private readonly ISectionBuss _sectionBuss;
        private readonly IFeatureBuss _featureBuss;
        private readonly ISupplierBuss _supplierBuss;
        private readonly ISessionHelper _sessionHelper;
       // private readonly IProductBuss productBuss;

        #endregion

        #region Ctor

        public ProductController(IProductBuss productBuss,
            ICatBuss catBuss,
            ISectionBuss sectionBuss, IFeatureBuss featureBuss, ISupplierBuss supplierBuss, ISessionHelper sessionHelper)
        {
            _productBuss = productBuss;
            _catBuss = catBuss;
            _sectionBuss = sectionBuss;
            _featureBuss = featureBuss;
            _supplierBuss = supplierBuss;
            _sessionHelper = sessionHelper;
        }

        #endregion

        #region Actions 

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ProductDetails(int id)
        {
            var productdDetails = new ProductsDtailsViewModel();
            var product = _productBuss.Get(id);
            var productfeatures = _productBuss.GetProductFeatureValueByProductId(product.ProductID);
            productdDetails.CategoryName = _catBuss.Get(product.CategoryID).CategoryName;
            productdDetails.SmallDescription = product.SmallDescription;
            productdDetails.UnitPice = product.UnitPrice;
            productdDetails.Description = product.Description;
            productdDetails.ProductId = id;
            productdDetails.Picture = product.Picture1 ?? product.Picture2;
            productdDetails.SupplierName = _supplierBuss.Get(product.SupplierID).SupplierName;
            foreach (var productfeature in productfeatures)
            {
                var feature = _featureBuss.Get(productfeature.FeatureID);
                var featureViewModel = new FeatureViewModel();
                featureViewModel.Name = feature.FeatureName;
                featureViewModel.Value = productfeature.FeatureValue;
                productdDetails.FeatureViewModels.Add(featureViewModel);

            }
            return View(productdDetails);
        }

        [HttpPost]
        public JsonResult RemoveProductFromSessionById(int productId)
        {
            if (productId == 0)
            {
                return Json(new { error = true, message = "شناسه معتبر نمی باشد" });
            }
           
            var basket = _sessionHelper.GetCurrentBasket();
            var orderdetails = basket.OrderDetails.FirstOrDefault(od => od.ProductID == productId);
           
                basket.OrderDetails.Remove(orderdetails);
                _sessionHelper.AddCurrentBasketToSession(basket);
           
          
            
            return Json(new { error = false, message = "حذف با موفقیت انجام شد" });
        }


        [HttpPost]
        public JsonResult RemoveProductFromSessionByIdMinus(int productId)
        {
            if (productId == 0)
            {
                return Json(new { error = true, message = "شناسه معتبر نمی باشد" });
            }
            var product = _productBuss.Get(productId);
            var basket = _sessionHelper.GetCurrentBasket();
            var orderdetails = basket.OrderDetails.FirstOrDefault(od => od.ProductID == productId);
            if (orderdetails.Quantity == 1)
            {
                basket.OrderDetails.Remove(orderdetails);
                _sessionHelper.AddCurrentBasketToSession(basket);
            }
            if (orderdetails.Quantity > 1)
            {
                var od = basket.OrderDetails.FirstOrDefault(x => x.ProductID == productId);
               // basket.OrderDetails.Remove(orderdetails);
               // _sessionHelper.AddCurrentBasketToSession(basket);
                od.Quantity--;
                od.TotalPrice = product.UnitPrice * od.Quantity;
                // CurrentBasket current = new CurrentBasket(_sessionHelper, basket);
                //basket.OrderDetails.Add(new OrderItemsViewModel
                //{
                //    ProductID = productId,
                //    Quantity = od.Quantity,
                //    TotalPrice = od.TotalPrice,
                //    UnitPrice = od.UnitPrice,
                //    Image = product.Picture1 ?? product.Picture2,
                //    ProductName = product.ProductName
                //});
                // _sessionHelper.AddCurrentBasketToSession(current.MyBasket);


                _sessionHelper.AddCurrentBasketToSession(basket);
              // CurrentBasket current = new CurrentBasket(_sessionHelper, basket);
               // _sessionHelper.AddCurrentBasketToSession(current.MyBasket);
            }

            return Json(new { error = false, message = "حذف با موفقیت انجام شد" });
        }
        #endregion

    }
}