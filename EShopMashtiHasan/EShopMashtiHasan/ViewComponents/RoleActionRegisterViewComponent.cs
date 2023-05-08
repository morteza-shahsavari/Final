
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Security.BuessinessServiceContract.Services;
using Security.Domain.DTO.ProjectAction;
using Security.Domain.DTO.ProjectController;
using Security.Domain.DTO.Role;

namespace EShopMashtiHasan.ViewComponents
{
    [ViewComponent(Name = "RoleActionRegister")]
    public class RoleActionRegisterViewComponent:ViewComponent
    {
        private readonly IRoleActionBuss buss;
        public RoleActionRegisterViewComponent(IRoleActionBuss buss)
        {
            this.buss = buss;
        }
        private void InflatedrpSearchRole()
        {
            var drpProjectRole = buss.RoleDrps();
            drpProjectRole.Insert(0, new RoleDrop { RoleID = -1, RoleName = "...Role..." });
            SelectList drpR = new SelectList(drpProjectRole, "RoleID", "RoleName");
            ViewBag.drpRole = drpR;
        }

        private void InflatedrpSearchdrpController()
        {
            var drpController = buss.ProjectControllerDrops();
            drpController.Insert(0, new ProjectControllerDrop { ProjectControllerID = -1, ProjectControllerName = "...Controller..." });
            SelectList drpC = new SelectList(drpController, "ProjectControllerID", "ProjectControllerName");
            ViewBag.drpController = drpC;
        }
        private void InflatedrpSearchProjectAction()
        {
            var drpProjectProjectAction = buss.ProjectActionDrps(-1);
            drpProjectProjectAction.Insert(0, new ProjectActionDrop { ProjectActionID = -1, ProjectActionName = "...Action..." });
            SelectList drpA = new SelectList(drpProjectProjectAction, "ProjectActionID", "ProjectActionName");
            ViewBag.ProjectAction = drpA;
        }


        public IViewComponentResult Invoke()
        {
            InflatedrpSearchRole();
            InflatedrpSearchProjectAction();
            InflatedrpSearchdrpController();
            return View();

        }
    }
}
