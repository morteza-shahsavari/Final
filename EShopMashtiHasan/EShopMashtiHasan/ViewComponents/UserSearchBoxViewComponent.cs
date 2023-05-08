﻿
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Security.BuessinessServiceContract.Services;
using Security.Domain.DTO.Role;
using Security.Domain.DTO.User;

namespace EShopMashtiHasan.ViewComponents
{
    [ViewComponent(Name = "UserSearchBox")]
    public class UserSearchBoxViewComponent:ViewComponent
    {
        private readonly IUserBuss buss;
        public UserSearchBoxViewComponent(IUserBuss buss)
        {
            this.buss = buss;
        }
        private void InflatedrpSearchRole()
        {
            var drpRole = buss.RoleDrps();
            drpRole.Insert(0, new RoleDrop { RoleID = -1, RoleName = "...Please Select Role..." });
            SelectList drpRol = new SelectList(drpRole, "RoleID", "RoleName");
            ViewBag.drpRole = drpRol;
        }
        public IViewComponentResult Invoke(UserSearchModel sm)
        {
            InflatedrpSearchRole();
            return View(sm);
        }
    }
}
