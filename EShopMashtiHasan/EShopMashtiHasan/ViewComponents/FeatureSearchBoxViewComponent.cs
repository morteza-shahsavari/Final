
using Shopping.DomainModel.DTO.ProductFeature;
using Microsoft.AspNetCore.Mvc;
using Shopping.BusinessServiceContract.Services;

namespace EShopMashtiHasan.ViewComponents
{
    [ViewComponent (Name = "FeatureSearchBox")]
    public class FeatureSearchBoxViewComponent:ViewComponent
    {
        private readonly IFeatureBuss buss;
        public FeatureSearchBoxViewComponent(IFeatureBuss buss)
        {
            this.buss = buss;
        }
        public IViewComponentResult Invoke(FeatureSearchModel sm)
        {
            return View(sm);
        }
    }
}
