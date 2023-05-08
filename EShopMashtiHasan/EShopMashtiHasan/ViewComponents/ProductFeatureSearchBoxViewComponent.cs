using Microsoft.AspNetCore.Mvc;
using Shopping.BusinessServiceContract.Services;
using Shopping.DomainModel.DTO.CategoryFeature;
using Shopping.DomainModel.DTO.ProductFeatureValues;

namespace EShopMashtiHasan.ViewComponents
{
    [ViewComponent(Name = "ProductFeatureSearchBox")]
    public class ProductFeatureSearchBoxViewComponent:ViewComponent
    {
        private readonly IProductBuss buss;
        public ProductFeatureSearchBoxViewComponent(IProductBuss buss)
        {
            this.buss = buss;
        }
        public IViewComponentResult Invoke(ProductFeatureSearchAddModel sm)
        {

            return View(sm);
        }
    }
}
