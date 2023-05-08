
using Shopping.DomainModel.DTO.ProductFeature;
using Microsoft.AspNetCore.Mvc;
using Shopping.BusinessServiceContract.Services;

namespace EShopMashtiHasan.ViewComponents
{
    [ViewComponent(Name = "FeatureList")]
    public class FeatureListViewComponent:ViewComponent
    {
        private readonly IFeatureBuss buss;
        public FeatureListViewComponent(IFeatureBuss buss)
        {
            this.buss = buss;
        }
        private void setPager(FeatureSearchModel sm)
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
        public IViewComponentResult Invoke(FeatureSearchModel sm)
        {

            int rc = 0;
            if (sm == null || sm.PageSize == 0)
            {
                // sm = new CategorySearchModel {PageSize = 10};
                sm.PageSize = 10;

            }
            var F = buss.Search(sm, out rc);
            sm.RecordCount = rc;
            setPager(sm);
            return View(F);
        }
    }
}
