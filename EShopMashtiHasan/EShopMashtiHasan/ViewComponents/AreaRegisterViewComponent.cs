
using Microsoft.AspNetCore.Mvc;
using Security.BuessinessServiceContract.Services;

namespace EShopMashtiHasan.ViewComponents
{
    [ViewComponent(Name = "AreaRegister")]
    public class AreaRegisterViewComponent : ViewComponent
    {
        private readonly IProjectAreaBuss buss;
        public AreaRegisterViewComponent(IProjectAreaBuss buss)
        {
            this.buss= buss;    
        }
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
