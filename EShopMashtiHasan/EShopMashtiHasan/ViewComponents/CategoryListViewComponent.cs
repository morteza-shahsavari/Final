

using Microsoft.AspNetCore.Mvc;
using Shopping.BusinessServiceContract.Services;
using Shopping.DomainModel.DTO.Category;

namespace EShopMashtiHasan.ViewComponents
{
    [ViewComponent(Name = "CategoryList")]
    public class CategoryListViewComponent:ViewComponent
    {
        private readonly ICatBuss buss;

        public CategoryListViewComponent(ICatBuss buss)
        {
            this.buss = buss;
        }

        private void setPager(CategorySearchModel sm)
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
        public IViewComponentResult Invoke(CategorySearchModel sm)
        {
            if (sm.ParentID == -1)
            {
                sm.ParentID = null;
            }
            int rc = 0;
            if (sm==null || sm.PageSize==0)
            {
                // sm = new CategorySearchModel {PageSize = 10};
                sm.PageSize = 10;

            }
            var cats = buss.Search(sm, out rc);
            sm.RecordCount = rc;
            setPager(sm);
            return View(cats.MainResults);
        }
    }
}
