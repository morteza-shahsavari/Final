
using Microsoft.AspNetCore.Mvc;
using Security.BuessinessServiceContract.Services;
using Security.Domain.DTO.ProjectArea;

namespace EShopMashtiHasan.ViewComponents
{
    [ViewComponent(Name = "AreaSearchBox")]
    public class AreaSearchBoxViewComponent:ViewComponent
    {

        private readonly IProjectAreaBuss buss;
        public AreaSearchBoxViewComponent(IProjectAreaBuss buss)
        {
            this.buss = buss;
        }

        public IViewComponentResult Invoke(ProjectAreaSearchModel sm)
        {
            return View(sm);
        }
    }
}
