
using Microsoft.AspNetCore.Mvc;

using System.Linq;

using Shopping.BusinessServiceContract.Services;
using Shopping.DomainModel.DTO.Product;

namespace EShopMashtiHasan.ViewComponents
{
    [ViewComponent(Name = "LatestProducts")]
    public class LatestProductsViewComponent : ViewComponent
    {
        #region Fields

        private readonly IProductBuss _productBuss;
        private readonly ISupplierBuss _supplierBuss;
        private readonly ICatBuss _catBuss;

        #endregion

        #region Ctor

        public LatestProductsViewComponent(IProductBuss productBuss, ISupplierBuss supplierBuss, ICatBuss catBuss)
        {
            _productBuss = productBuss;
            _supplierBuss = supplierBuss;
            _catBuss = catBuss;
        }

        #endregion

        #region Events

        public IViewComponentResult Invoke() 
        {
            var products = _productBuss.GetAll().OrderByDescending(x=>x.ProductID).Take(8);
            var productListItems = products.Select(x => new ProductListItem
            {
                CategoryID = x.CategoryID,
                CategoryName = _catBuss.Get(x.CategoryID).CategoryName,
                Picture1 = x.Picture1 ?? x.Picture2,
                ProductID = x.ProductID,
                ProductName = x.ProductName,
                SupplierName =_supplierBuss.Get(x.SupplierID).SupplierName,
                UnitPrice = x.UnitPrice,
            }).ToList();

            return View(productListItems);
        }

        #endregion
    }
}
