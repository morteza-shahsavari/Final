using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shopping.BusinessServiceContract.Services;
using Shopping.DomainModel.DTO.Product;
using Shopping.DomainModel.DTO.ProductFeature;
using Shopping.DomainModel.Models;

namespace EShopMashtiHasan.ViewComponents
{
    [ViewComponent(Name = "ProductSearchBox")]
    public class ProductSearchBoxViewComponent:ViewComponent
    {
        private readonly IProductBuss buss;
        private readonly ICatBuss catbuss;
        private readonly ISupplierBuss supbuss;
        public ProductSearchBoxViewComponent(IProductBuss buss, ICatBuss catbuss, ISupplierBuss supbuss)
        {
            this.buss = buss;
            this.catbuss = catbuss;
            this.supbuss = supbuss;

        }


        private void InflatedrpSearchCategory()
        {
            var drpCat = catbuss.GetAll();
            drpCat.Insert(0, new Category { CategoryID = -1, CategoryName = "...دسته بندی..." });
            SelectList drCat = new SelectList(drpCat, "CategoryID", "CategoryName");
            ViewBag.DrpCategory = drCat;
        }

        public IViewComponentResult Invoke(ProductSearchModel sm)
        {
            InflatedrpSearchCategory();
            return View(sm);
        }
    }
}
