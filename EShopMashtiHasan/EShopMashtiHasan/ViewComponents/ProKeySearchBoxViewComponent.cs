using Microsoft.AspNetCore.Mvc;
using Shopping.BusinessServiceContract.Services;
using Shopping.DomainModel.DTO.ProductKeyWord;


namespace EShopMashtiHasan.ViewComponents
{
    [ViewComponent(Name = "ProKeySearchBox")]
    public class ProKeySearchBoxViewComponent:ViewComponent
    {
        private readonly IProductBuss probuss;
        
        public ProKeySearchBoxViewComponent(IProductBuss probuss)
        {
            this.probuss = probuss;
        }

        public IViewComponentResult Invoke(ProductKeyWordSearchAddModel sm)
        {
            return View(sm);
        }
    }
}
