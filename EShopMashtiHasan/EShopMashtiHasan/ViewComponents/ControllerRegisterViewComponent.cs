using Security.BuessinessServiceContract.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Security.Domain.DTO.ProjectArea;

namespace EShopMashtiHasan.ViewComponents
{
    [ViewComponent(Name = "ControllerRegister")]
    public class ControllerRegisterViewComponent:ViewComponent
    {
        private readonly IProjectControllerBuss buss;
        public ControllerRegisterViewComponent(IProjectControllerBuss buss)
        {
            this.buss = buss;
        }
        private void InflatedrpSearchArea()
        {
            var drpProjectArea = buss.ProjectAreaDrps();
            drpProjectArea.Insert(0, new ProjectAreaDrop { ProjectAreaID = -1, AreaName = "...Area..." });
            SelectList drpArea = new SelectList(drpProjectArea, "ProjectAreaID", "AreaName");
            ViewBag.drpArea = drpArea;
        }
        public IViewComponentResult Invoke()
        {
            InflatedrpSearchArea();
            return View();

        }

    }
}
