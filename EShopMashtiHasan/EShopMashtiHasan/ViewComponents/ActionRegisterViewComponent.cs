﻿
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Security.BuessinessServiceContract.Services;
using Security.Domain.DTO.ProjectController;

namespace EShopMashtiHasan.ViewComponents
{
    [ViewComponent(Name = "ActionRegister")]
    public class ActionRegisterViewComponent:ViewComponent
    {
        private readonly IProjectActionBuss buss;
        public ActionRegisterViewComponent(IProjectActionBuss buss)
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
        public IViewComponentResult Invoke()
        {
            InflatedrpSearchController();
            return View();

        }
    }
}
