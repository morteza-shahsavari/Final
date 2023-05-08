
using EShopMashtiHasan.Helper;
using Microsoft.AspNetCore.Mvc;
using Security.BuessinessServiceContract.BusinessModel.RoleAction;
using Security.BuessinessServiceContract.Services;
using Security.Domain.DTO.RoleAction;

namespace EShopMashtiHasan.Controllers
{
    [ServiceFilter(typeof(CustomAuthenticator))]
    public class RoleActionManagementController : Controller
    {
        private readonly IRoleActionBuss buss;
        public RoleActionManagementController(IRoleActionBuss buss)
        {
            this.buss = buss;
        }

        public IActionResult Index(RoleActionSearchModel sm)
        {
            return View(sm);
        }
        public IActionResult RoleActionSearchBox(RoleActionSearchModel sm)
        {
            return ViewComponent("RoleActionSearchBox", sm);
        }
        public IActionResult AddNew()
        {
            return ViewComponent("RoleActionRegister");
        }

        [HttpPost]
        public JsonResult AddNew(RoleActionViewModel RA)
        { 
            return Json(buss.Register(RA));
        }
        public IActionResult RoleActionList(RoleActionSearchModel sm)
        {
            return ViewComponent("RoleActionList", sm);
        }

        public IActionResult DropDownAdd(int id)
        {
            return ViewComponent("DropDownAdd", id);
        }

        public JsonResult Delete(int id)
        {
            return Json(buss.Delete(id));
        }

    }
}
