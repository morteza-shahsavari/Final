using Microsoft.AspNetCore.Mvc;
using Shopping.BusinessServiceContract.Services;

using Shopping.DomainModel.DTO.CategoryFeature;


namespace EShopMashtiHasan.ViewComponents
{
    [ViewComponent(Name = "CFList")]
    public class CFListViewComponent:ViewComponent
    {
        private readonly ICatBuss buss;
        public CFListViewComponent(ICatBuss buss)
        {
            this.buss = buss;
        }
        private void setPager(CategoryFeatureSearchAddModel sm)
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
        public IViewComponentResult Invoke(CategoryFeatureSearchAddModel sm)
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


