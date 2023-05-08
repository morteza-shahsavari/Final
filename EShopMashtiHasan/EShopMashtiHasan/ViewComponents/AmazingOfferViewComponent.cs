using Microsoft.AspNetCore.Mvc;
using Shopping.BusinessServiceContract.Services;
using System.Linq;

using Shopping.DomainModel.DTO.Product;

namespace EShopMashtiHasan.ViewComponents
{
    [ViewComponent(Name = "AmazingOffer")]
    public class AmazingOfferViewComponent : ViewComponent
    {
        #region Fields

        private readonly IProductBuss _productBuss;
        private readonly ISupplierBuss _supplierBuss;
        private readonly ICatBuss _catBuss;

        #endregion

        #region Ctor

        public AmazingOfferViewComponent(IProductBuss productBuss, ISupplierBuss supplierBuss, ICatBuss catBuss)
        {
            _productBuss = productBuss;
            _supplierBuss = supplierBuss;
            _catBuss = catBuss;
        }

        #endregion

        #region Events

        public IViewComponentResult Invoke()
        {
            var products = _productBuss.GetAll().Where(x => x.ShowInAmazingOffer);
            var productListItem = products.Select(x => new ProductListItem
            {
                CategoryID = x.CategoryID,
                ExpireDateSpecialOffer = x.ExpireDateSpecialOffer != null ? x.ExpireDateSpecialOffer.Value : System.DateTime.Now,
                Picture1 = x.Picture1 ?? x.Picture2,
                ProductID = x.ProductID,
                ProductName = x.ProductName,
                ShowInAmazingOffer = x.ShowInAmazingOffer,
                ShowInInstantOffer = x.ShowInInstantOffer,
                SupplierName = _supplierBuss.Get(x.SupplierID).SupplierName,
                CategoryName = _catBuss.Get(x.CategoryID).CategoryName,
                UnitPrice = x.UnitPrice,
                SmallDescription = x.SmallDescription
            });
            return View(productListItem);
        }

        #endregion
    }
}
