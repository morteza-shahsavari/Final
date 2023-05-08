using Microsoft.AspNetCore.Mvc;

using Shopping.BusinessServiceContract.Services;

using Shopping.DomainModel.DTO.ProductKeyWord;

namespace EShopMashtiHasan.ViewComponents
{
    [ViewComponent(Name = "ProKeyList")]
    public class ProKeyListViewComponent:ViewComponent
    {
        private readonly IProductBuss buss;
        public ProKeyListViewComponent(IProductBuss buss)
        {
            this.buss = buss;
        }
        private void setPager(ProductKeyWordSearchAddModel sm)
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

        public IViewComponentResult Invoke(ProductKeyWordSearchAddModel sm)
        {
            int rc = 0;

            if (sm == null || sm.PageSize == 0) { sm.PageSize = 10; }


            var PA = buss.searchGetKeyWord(sm, out rc);
            sm.RecordCount = rc;
            setPager(sm);
            return View(PA);

        }
    }
}
