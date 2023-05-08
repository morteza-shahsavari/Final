
using Microsoft.AspNetCore.Mvc;
using Security.BuessinessServiceContract.Services;
using Security.Domain.DTO.ProjectArea;

namespace EShopMashtiHasan.ViewComponents
{
    [ViewComponent(Name = "AreaList")]
    public class AreaListViewComponent:ViewComponent
    {
        private readonly IProjectAreaBuss buss;
        public AreaListViewComponent(IProjectAreaBuss buss)
        {
            this.buss = buss;
        }
        private void setPager(ProjectAreaSearchModel sm)
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
        public IViewComponentResult Invoke(ProjectAreaSearchModel sm)
        {
            int rc = 0;
            if (sm == null || sm.PageSize == 0) { sm.PageSize = 10; }
            sm.RecordCount = rc;
            setPager(sm);
            var PA = buss.Search(sm, out rc);
            return View(PA);

        }

    }
}
