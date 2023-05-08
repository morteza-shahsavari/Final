

using EShopMashtiHasan.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Security.BuessinessServiceContract.Services;
using Security.Domain.DTO.ProjectArea;
using Security.Domain.DTO.ProjectController;

namespace EShopMashtiHasan.Controllers
{
    [ServiceFilter(typeof(CustomAuthenticator))]
    public class ProjectControllerManagementController : Controller
    {
        private readonly IProjectControllerBuss buss;
        public ProjectControllerManagementController(IProjectControllerBuss buss)
        {
            this.buss = buss;
        }
        public IActionResult Index(ProjectControllerSearchModel sm)
        {
            return View(sm);
        }

        public IActionResult ControllerSearchBox(ProjectControllerSearchModel sm)
        {
            return ViewComponent("ControllerSearchBox", sm);
        }
        public IActionResult ControllerList(ProjectControllerSearchModel sm)
        {
            return ViewComponent("ControllerList", sm);
        }
        public IActionResult AddNew()
        {
            return ViewComponent("ControllerRegister");
        }
        [HttpPost]
        public JsonResult AddNew(ProjectControllerAddModel PC)
        {
            return Json(buss.Register(PC));
        }
        public JsonResult Delete(int id)
        {
            return Json(buss.Delete(id));
        }
        private void InflatedrpSearchArea()
        {
            var drpProjectArea = buss.ProjectAreaDrps();
            drpProjectArea.Insert(0, new ProjectAreaDrop { ProjectAreaID = -1, AreaName = "...Area..." });
            SelectList drpArea = new SelectList(drpProjectArea, "ProjectAreaID", "AreaName");
            ViewBag.drpArea = drpArea;
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var q = buss.GetProjectController(id);
            InflatedrpSearchArea();
            ProjectControllerUpdateModel PA = new ProjectControllerUpdateModel
            {
                ProjectAreaID = q.ProjectAreaID,
                ProjectControllerName = q.ProjectControllerName,
                ProjectControllerID = q.ProjectControllerID,
                PersianTitle = q.PersianTitle
            };
            return View(PA);
        }
        [HttpPost]
        public JsonResult Update(ProjectControllerUpdateModel cont)
        {

            var result = buss.update(cont);
            return Json(result);
        }
    }
}
