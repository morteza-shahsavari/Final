
using Microsoft.AspNetCore.Mvc;
using Shopping.BusinessServiceContract.Services;
using Shopping.DomainModel.DTO.KeyWord;

namespace EShopMashtiHasan.ViewComponents
{
    [ViewComponent(Name = "KeyWordList")]
    public class KeyWordListViewComponent:ViewComponent
    {
        private readonly IKeyWordBuss buss;
        public KeyWordListViewComponent(IKeyWordBuss buss)
        {
            this.buss = buss;
        }
        private void setPager(KeyWordSearchModel sm)
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
        public IViewComponentResult Invoke(KeyWordSearchModel sm)
        {

            int rc = 0;
            if (sm == null || sm.PageSize == 0)
            {
                // sm = new KeyWordSearchModel {PageSize = 10};
                sm.PageSize = 10;

            }
            var KW = buss.Search(sm, out rc);
            sm.RecordCount = rc;
            setPager(sm);
            return View(KW);
        }
    }
}
