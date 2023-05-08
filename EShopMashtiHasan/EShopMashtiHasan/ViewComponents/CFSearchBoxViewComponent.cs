using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using Shopping.BusinessServiceContract.Services;

using Shopping.DomainModel.DTO.CategoryFeature;

using Shopping.DomainModel.Models;


namespace EShopMashtiHasan.ViewComponents
{
    [ViewComponent(Name = "CFSearchBox")]
    public class CFSearchBoxViewComponent:ViewComponent
    {
        private readonly ICatBuss buss;
        public CFSearchBoxViewComponent(ICatBuss buss)
        {
            this.buss = buss;
        }
        public IViewComponentResult Invoke(CategoryFeatureSearchAddModel sm)
        {
           
            return View(sm);
        }
    }
}
