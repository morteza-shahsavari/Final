using Microsoft.AspNetCore.Mvc;
using Shopping.BusinessServiceContract.Services;

namespace EShopMashtiHasan.ViewComponents
{
    [ViewComponent(Name = "SupplierRegister")]
    public class SupplierRegisterViewComponent:ViewComponent
    {
        private readonly ISupplierBuss buss;
        public SupplierRegisterViewComponent(ISupplierBuss buss)
        {
            this.buss = buss;
        }

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
