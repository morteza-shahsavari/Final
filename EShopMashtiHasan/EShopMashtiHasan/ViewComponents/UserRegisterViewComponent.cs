
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Security.BuessinessServiceContract.Services;
using Security.Domain.DTO.Role;

namespace EShopMashtiHasan.ViewComponents
{
    [ViewComponent(Name = "UserRegister")]
    public class UserRegisterViewComponent:ViewComponent
    {
        private readonly IUserBuss buss;
        public UserRegisterViewComponent(IUserBuss buss)
        {
            this.buss = buss;
        }
        private void InflatedrpSearchRole()
        {
            var drpRole = buss.RoleDrps();
            drpRole.Insert(0, new RoleDrop { RoleID = -1, RoleName = "...please Select Role..." });
            SelectList drpRol = new SelectList(drpRole, "RoleID", "RoleName");
            ViewBag.drpRole = drpRol;
        }
        public IViewComponentResult Invoke()
        {
            InflatedrpSearchRole();
            return View();
        }
    }
}
