
using Shopping.DomainModel.ViewModel.Categories;
using Microsoft.AspNetCore.Mvc;

using System.Linq;
using Shopping.BusinessServiceContract.Services;
using Shopping.DomainModel.DTO.Product;

namespace EShopMashtiHasan.ViewComponents
{
    [ViewComponent(Name = "ProductCategories")]
    public class ProductCategoriesViewComponent : ViewComponent
    {
        #region Fields

        private readonly ICatBuss _catBuss;
        private readonly IProductBuss _productBuss;
        private readonly ISupplierBuss _supplierBuss;

        #endregion

        #region Ctor

        public ProductCategoriesViewComponent(ICatBuss catBuss, IProductBuss productBuss, ISupplierBuss supplierBuss)
        {
            _catBuss = catBuss;
            _productBuss = productBuss;
            _supplierBuss = supplierBuss;
        }

        #endregion

        #region Events

        public IViewComponentResult Invoke()
        {
            var categories = _catBuss.GetAll().Take(5);
            var categoryProductItems = categories.Select(x => new CategoryProductListItem
            {
                CategoryID = x.CategoryID,
                CategoryName = x.CategoryName,
                ChildCount = x.Children.Count(),
                ParentID = x.ParentID ?? 0,
                ParentNames = x.ParentID > 0 ? x.Parent.CategoryName : "",
                ProductCount = x.ProductCount,
                Products = _productBuss.GetAll().Where(w => w.CategoryID == x.CategoryID).Select(p => new ProductListItem
                {
                    CategoryID = x.CategoryID,
                    CategoryName = x.CategoryName,
                    ExpireDateSpecialOffer = p.ExpireDateSpecialOffer,
                    IsNew = p.IsNew,
                    ShowInInstantOffer = p.ShowInInstantOffer,
                    Picture1 = p.Picture1 ?? p.Picture2,
                    ProductID = p.ProductID,
                    ProductName = p.ProductName,
                    ShowInAmazingOffer = p.ShowInAmazingOffer,
                    SupplierName = _supplierBuss.Get(p.SupplierID).SupplierName,
                    UnitPrice = p.UnitPrice
                }).ToList()

            });
            return View(categoryProductItems);
        }

        #endregion
    }
}
