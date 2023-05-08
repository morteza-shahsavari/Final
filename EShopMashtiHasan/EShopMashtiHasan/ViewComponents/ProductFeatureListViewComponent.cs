using Microsoft.AspNetCore.Mvc;
using Shopping.BusinessServiceContract.Services;
using Shopping.DomainModel.DTO.CategoryFeature;
using Shopping.DomainModel.DTO.ProductFeatureValues;

namespace EShopMashtiHasan.ViewComponents
{
    [ViewComponent(Name = "ProductFeatureList")]
    public class ProductFeatureListViewComponent:ViewComponent
    {
        private readonly IProductBuss buss;
        public ProductFeatureListViewComponent(IProductBuss buss)
        {
            this.buss = buss;
        }
        private void setPager(ProductFeatureSearchAddModel sm)
        {
            if (sm.RecordCount % sm.PageSize == 0)
            {
                sm.pageCount = sm.RecordCount / sm.PageSize;
            }
            else
            {
                sm.pageCount = sm.RecordCount / sm.PageSize + 1;

            }
            ViewBag.sm = sm;

        }
        public IViewComponentResult Invoke(ProductFeatureSearchAddModel sm)
        {
            int rc = 0;

            if (sm == null || sm.PageSize == 0) { sm.PageSize = 10; }


            var PA = buss.searchfeature(sm, out rc);
            sm.RecordCount = rc;
            setPager(sm);
            return View(PA);

        }
    }
}
