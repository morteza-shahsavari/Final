
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Security.BuessinessServiceContract.Services;
using Security.Domain.DTO.ProjectAction;
using Security.Domain.DTO.ProjectController;

namespace EShopMashtiHasan.ViewComponents
{
    [ViewComponent(Name = "ActionSearchBox")]
    public class ActionSearchBoxViewComponent:ViewComponent
    {
        private readonly IProjectActionBuss buss;
        public ActionSearchBoxViewComponent(IProjectActionBuss buss)
        {
            this.buss = buss;
        }

        private void InflatedrpSearchController()
        {
            var drpProjectcontroller = buss.ProjectControllerDrops();
            drpProjectcontroller.Insert(0, new ProjectControllerDrop { ProjectControllerID = -1, ProjectControllerName = "...کنترلر..." });
            SelectList drpController = new SelectList(drpProjectcontroller, "ProjectControllerID", "ProjectControllerName");
            ViewBag.drpController = drpController;
        }
        public IViewComponentResult Invoke(ProjectActionSearchModel sm)
        {
            InflatedrpSearchController();
            return View(sm);
        }
    }
}
