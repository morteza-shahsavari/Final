using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Shopping.BusinessServiceContract.Services;
using Shopping.DomainModel.DTO.Product;

namespace EShopMashtiHasan.ViewComponents
{
    [ViewComponent(Name = "SuggestedProducts")]
    public class SuggestedProductsViewcomponent : ViewComponent
    {
        #region Fields

        private readonly IProductBuss _productBuss;
        private readonly ICatBuss _catBuss;
        private readonly ISupplierBuss _supplierBuss;

        #endregion

        #region Ctor

        public SuggestedProductsViewcomponent(IProductBuss productBuss, ICatBuss catBuss)
        {
            _productBuss = productBuss;
            _catBuss = catBuss;
        }

        #endregion

        #region Events

        public IViewComponentResult Invoke()
        {
            var products = _productBuss.GetAll().Where(x => x.UnitPrice > 500000 && x.UnitPrice < 5000000).ToList();
            var productListItems = products.Select(x => new ProductListItem
            {
                UnitPrice = x.UnitPrice,
                CategoryID = x.CategoryID,
                CategoryName = _catBuss.Get(x.CategoryID).CategoryName,
                ExpireDateSpecialOffer = x.ExpireDateSpecialOffer,
                Picture1 = x.Picture1 ?? x.Picture2,
                ProductID = x.ProductID,
                ProductName = x.ProductName,
                ShowInAmazingOffer = x.ShowInAmazingOffer,
                ShowInInstantOffer = x.ShowInInstantOffer,
                SupplierName = _supplierBuss.Get(x.SupplierID).SupplierName
            });
            return View(productListItems);
        }

        #endregion
    }
}
