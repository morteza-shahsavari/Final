
using Microsoft.AspNetCore.Mvc;
using Shopping.BusinessServiceContract.Services;
using Shopping.DomainModel.DTO.Product;
using System.Linq;

namespace EShopMashtiHasan.ViewComponents
{
    [ViewComponent(Name = "WidgetSuggestion")]
    public class WidgetSuggestionViewComponent : ViewComponent
    {
        #region Fields

        private readonly IProductBuss _productBuss;

        #endregion

        #region Ctor

        public WidgetSuggestionViewComponent(IProductBuss productBuss)
        {
            _productBuss = productBuss;
        }

        #endregion

        #region Events

        public IViewComponentResult Invoke()
        {
            var products = _productBuss.GetAll().Where(x => x.ShowInInstantOffer);
            var productListItems = products.Select(x => new ProductListItem
            {
                ShowInInstantOffer = x.ShowInInstantOffer,
                CategoryID = x.CategoryID,
                Picture1 = x.Picture1 ?? x.Picture2,
                ExpireDateSpecialOffer = x.ExpireDateSpecialOffer,
                IsNew = x.IsNew,
                ProductID = x.ProductID,
                ProductName = x.ProductName,
                ShowInAmazingOffer = x.ShowInAmazingOffer,
                UnitPrice = x.UnitPrice,
            });
            return View(productListItems);
        }

        #endregion
    }
}
