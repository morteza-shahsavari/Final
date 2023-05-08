using Microsoft.AspNetCore.Mvc;
using Security.BuessinessServiceContract.Services;
using Security.Domain.DTO.RoleAction;

namespace EShopMashtiHasan.ViewComponents
{
    [ViewComponent(Name = "RoleActionList")]
    public class RoleActionListViewComponent:ViewComponent
    {

        private readonly IRoleActionBuss buss;
        public RoleActionListViewComponent(IRoleActionBuss buss)
        {
            this.buss = buss;
        }

        private void setPager(RoleActionSearchModel sm)
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

        public IViewComponentResult Invoke(RoleActionSearchModel sm)
        {
            int rc = 0;
            if (sm.RoleID == -1)
            {
                sm.RoleID = null;
            }
            if (sm.ProjectActionID == -1)
            {
                sm.ProjectActionID = null;
            }
            if (sm.ProjectContorollerID == -1)
            {
                sm.ProjectContorollerID = null;
            }
            if (sm == null || sm.PageSize == 0) { sm.PageSize = 10; }
            
            var RA = buss.Search(sm, out rc);
            sm.RecordCount = rc;
            setPager(sm);
            return View(RA);

        }
    }
}
