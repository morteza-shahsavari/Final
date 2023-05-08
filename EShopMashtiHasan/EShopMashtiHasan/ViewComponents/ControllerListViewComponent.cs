using Microsoft.AspNetCore.Mvc;
using Security.BuessinessServiceContract.Services;
using Security.Domain.DTO.ProjectController;

namespace EShopMashtiHasan.ViewComponents
{
    [ViewComponent(Name = "ControllerList")]
    public class ControllerListViewComponent:ViewComponent
    {
        private readonly IProjectControllerBuss buss;
        public ControllerListViewComponent(IProjectControllerBuss buss)
        {
            this.buss = buss;
        }

        private void setPager(ProjectControllerSearchModel sm)
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
        public IViewComponentResult Invoke(ProjectControllerSearchModel sm)
        {
            if (sm.ProjectAreaID == -1)
            {
                sm.ProjectAreaID = null;
            }
            int rc = 0;
            if (sm == null || sm.PageSize == 0) { sm.PageSize = 10; }
           
            var PC = buss.Search(sm, out rc);
            sm.RecordCount = rc;
            setPager(sm);
            return View(PC);
        }
    }
}
