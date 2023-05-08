
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Security.BuessinessServiceContract.Services;
using Security.Domain.DTO.ProjectAction;

namespace EShopMashtiHasan.ViewComponents
{
    [ViewComponent(Name = "DropDownAdd")]
    public class DropDownAddViewComponent:ViewComponent
    {
        private readonly IRoleActionBuss buss;
        public DropDownAddViewComponent(IRoleActionBuss buss)
        {
            this.buss = buss;
        }
        private void InflatedrpSearchProjectAction(int controllerid)
        {
                var drpProjectProjectAction = buss.ProjectActionDrps(controllerid);
                drpProjectProjectAction.Insert(0, new ProjectActionDrop { ProjectActionID = -1, ProjectActionName = "...Action..." });
                SelectList drpA = new SelectList(drpProjectProjectAction, "ProjectActionID", "ProjectActionName");
                ViewBag.ProjectAction = drpA;
        }
        public IViewComponentResult Invoke(int id)
        {
            
            InflatedrpSearchProjectAction(id);
            return View();
        }
    }
}
