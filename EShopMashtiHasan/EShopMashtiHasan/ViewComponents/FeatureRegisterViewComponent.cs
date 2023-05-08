
using Microsoft.AspNetCore.Mvc;
using Shopping.BusinessServiceContract.Services;

namespace EShopMashtiHasan.ViewComponents
{
    [ViewComponent(Name = "FeatureRegister")]
    public class FeatureRegisterViewComponent:ViewComponent
    {
        private readonly IFeatureBuss buss;
        public FeatureRegisterViewComponent(IFeatureBuss buss)
        {
            this.buss = buss;
        }
        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}
