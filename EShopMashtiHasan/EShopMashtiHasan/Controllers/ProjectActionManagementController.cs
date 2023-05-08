
using EShopMashtiHasan.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Security.BuessinessServiceContract.Services;
using Security.Domain.DTO.ProjectAction;
using Security.Domain.DTO.ProjectController;

namespace EShopMashtiHasan.Controllers
{
    [ServiceFilter(typeof(CustomAuthenticator))]
    public class ProjectActionManagementController : Controller
    {
        private readonly IProjectActionBuss buss;
        public ProjectActionManagementController(IProjectActionBuss buss)
        {
            this.buss = buss;
        }

        public IActionResult Index(ProjectActionSearchModel sm)
        {
            return View(sm);
        }
        public IActionResult ActionSearchBox(ProjectActionSearchModel sm)
        {
            return ViewComponent("ActionSearchBox", sm);
        }
        public IActionResult ActionList(ProjectActionSearchModel sm)
        {
            return ViewComponent("ActionList", sm);
        }
        public IActionResult AddNew()
        {
            return ViewComponent("ActionRegister");
        }
        [HttpPost]
        public JsonResult AddNew(ProjectActionAddModel acta)
        {
            return Json(buss.Register(acta));
        }
        public JsonResult Delete(int id)
        {
            return Json(buss.Delete(id));
        }

        private void InflatedrpSearchController()
        {
            var drpProjectcontroller = buss.ProjectControllerDrops();
            drpProjectcontroller.Insert(0, new ProjectControllerDrop { ProjectControllerID = -1, ProjectControllerName = "...کنترلر..." });
            SelectList drpController = new SelectList(drpProjectcontroller, "ProjectControllerID", "ProjectControllerName");
            ViewBag.drpController = drpController;
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var q = buss.GetProjectAction(id);
            ProjectActionUpdateModel PA = new ProjectActionUpdateModel
            {
                ProjectActionID = q.ProjectActionID,
                ProjectActionName= q.ProjectActionName,
                ProjectControllerID=q.ProjectControllerID,
                PersianTitle=q.PersianTitle
            };
            InflatedrpSearchController();
            return View(PA);
        }
        [HttpPost]
        public JsonResult Update(ProjectActionUpdateModel PA)
        {

            var result = buss.update(PA);
            return Json(result);
        }
    }
}
