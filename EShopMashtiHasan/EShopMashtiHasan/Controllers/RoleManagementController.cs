
using EShopMashtiHasan.Helper;
using Microsoft.AspNetCore.Mvc;
using Security.BuessinessServiceContract.Services;
using Security.Domain.DTO.Role;

namespace EShopMashtiHasan.Controllers
{
    [ServiceFilter(typeof(CustomAuthenticator))]
    public class RoleManagementController : Controller
    {
        private readonly IRoleBuss buss;
        public RoleManagementController(IRoleBuss buss)
        {
            this.buss = buss;
        }

        public IActionResult Index(RoleSearchModel sm)
        {
            return View(sm);
        }
        public IActionResult RoleSearchBox(RoleSearchModel sm)
        {
            return ViewComponent("RoleSearchBox", sm);
        }

        public IActionResult AddNew()
        {
            return ViewComponent("RoleRegister");
        }

        [HttpPost]
        public JsonResult AddNew(RoleAddModel role)
        {
            return Json(buss.Register(role));
        }

        public IActionResult RoleList(RoleSearchModel sm)
        {
            return ViewComponent("RoleList", sm);
        }
        public JsonResult Delete(int id)
        {
            return Json(buss.Delete(id));
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var q = buss.GetRole(id);
            return View(q);
        }
        [HttpPost]
        public JsonResult Update(RoleUpdateModel role)
        {

            var result = buss.update(role);
            return Json(result);
        }
    }
}
