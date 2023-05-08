
using Microsoft.AspNetCore.Mvc;
using Shopping.BusinessServiceContract.Services;

namespace EShopMashtiHasan.ViewComponents
{
    [ViewComponent (Name = "KeyWordRegister")]
    public class KeyWordRegisterViewComponent:ViewComponent
    {
        private readonly IKeyWordBuss buss;
        public KeyWordRegisterViewComponent(IKeyWordBuss buss)
        {
            this.buss = buss;
        }
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
