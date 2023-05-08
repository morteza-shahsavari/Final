using Microsoft.AspNetCore.Mvc;
using Security.BuessinessServiceContract.Services;
using Security.Domain.DTO.User;

namespace EShopMashtiHasan.ViewComponents
{
    [ViewComponent(Name = "UserList")]
    public class UserListViewComponent:ViewComponent
    {
        private readonly IUserBuss buss;
        public UserListViewComponent(IUserBuss buss)
        {
            this.buss = buss;
        }
        private void setPager(UserSearchModel sm)
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
        public IViewComponentResult Invoke(UserSearchModel sm)
        {
            int rc = 0;
            if (sm.RoleID == -1)
            {
                sm.RoleID = null;
            }
            if (sm == null || sm.PageSize == 0) { sm.PageSize = 10; }
            
            var u = buss.Search(sm, out rc);
            sm.RecordCount = rc;
            setPager(sm);
            return View(u);

        }
    }
}
