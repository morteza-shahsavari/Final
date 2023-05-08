
using EShopMashtiHasan.Helper;
using Microsoft.AspNetCore.Mvc;
using Security.BuessinessServiceContract.Services;
using Security.Domain.DTO.ProjectArea;

namespace EShopMashtiHasan.Controllers
{
    [ServiceFilter(typeof(CustomAuthenticator))]
    public class ProjectAreaManagementController : Controller
    {
        private readonly IProjectAreaBuss buss;
        public ProjectAreaManagementController(IProjectAreaBuss buss)
        {
            this.buss = buss;
        }
        public IActionResult Index(ProjectAreaSearchModel sm)
        {
            return View(sm);
        }
        public IActionResult AreaSearchBox(ProjectAreaSearchModel sm)
        {
            return ViewComponent("AreaSearchBox", sm);
        }
        public IActionResult AreaList(ProjectAreaSearchModel sm)
        {
            return ViewComponent("AreaList", sm);
        }
        public IActionResult AddNew()
        {
            return ViewComponent("AreaRegister");
        }
        [HttpPost]
        public JsonResult AddNew(ProjectAreaAddModel area)
        {
            return Json(buss.Register(area));
        }
        public JsonResult Delete(int id)
        {
            return Json(buss.Delete(id));

        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var q = buss.GetProjectArea(id);
            return View(q);
        }
        [HttpPost]
        public JsonResult Update(ProjectAreaUpdateModel Area)
        {

            var result = buss.update(Area);
            return Json(result);
        }
    }
}
