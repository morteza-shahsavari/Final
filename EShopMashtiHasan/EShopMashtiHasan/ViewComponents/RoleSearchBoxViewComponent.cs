using Microsoft.AspNetCore.Mvc;
using Security.BuessinessServiceContract.Services;
using Security.Domain.DTO.Role;

namespace EShopMashtiHasan.ViewComponents
{
    [ViewComponent(Name = "RoleSearchBox")]
    public class RoleSearchBoxViewComponent:ViewComponent
    {
        private readonly IRoleBuss buss;
        public RoleSearchBoxViewComponent(IRoleBuss buss)
        {
            this.buss = buss;
        }
        public IViewComponentResult Invoke(RoleSearchModel sm)
        {
            return View(sm);
        }
    }
}
