using Microsoft.AspNetCore.Mvc;
using Security.BuessinessServiceContract.Services;
using Security.Domain.DTO.Role;

namespace EShopMashtiHasan.ViewComponents
{
    [ViewComponent(Name = "RoleList")]
    public class RoleListViewComponent:ViewComponent
    {
        private readonly IRoleBuss buss;
        public RoleListViewComponent(IRoleBuss buss)
        {
            this.buss = buss;
        }
        private void setPager(RoleSearchModel sm)
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
        public IViewComponentResult Invoke(RoleSearchModel sm)
        {

            int rc = 0;
            if (sm == null || sm.PageSize == 0)
            {
              
                sm.PageSize = 10;

            }
            var R = buss.Search(sm, out rc);
            sm.RecordCount = rc;
            setPager(sm);
            return View(R);
        }
    }
}
