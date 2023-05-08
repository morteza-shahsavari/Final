
using Microsoft.AspNetCore.Mvc;
using Security.BuessinessServiceContract.Services;
using Security.Domain.DTO.ProjectAction;

namespace EShopMashtiHasan.ViewComponents
{
    [ViewComponent(Name = "ActionList")]
    public class ActionListViewComponent:ViewComponent
    {
        private readonly IProjectActionBuss buss;
        public ActionListViewComponent(IProjectActionBuss buss)
        {
            this.buss = buss;
        }
        private void setPager(ProjectActionSearchModel sm)
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

        public IViewComponentResult Invoke(ProjectActionSearchModel sm)
        {
            int rc = 0;
            if (sm.ProjectControllerID == -1)
            {
                sm.ProjectControllerID = null;
            }
            if (sm == null || sm.PageSize == 0) { sm.PageSize = 10; }
           
          
            var PA = buss.Search(sm, out rc);
            sm.RecordCount = rc;
            setPager(sm);
            return View(PA);

        }
    }
}
