using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shopping.BusinessServiceContract.Services;
using Shopping.DomainModel.DTO.RelatedProduct;
using Shopping.DomainModel.Models;

namespace EShopMashtiHasan.ViewComponents
{
    [ViewComponent(Name = "RelatedProductSearchBox")]
    public class RelatedProductSearchBoxViewComponent:ViewComponent
    {
        private readonly IProductBuss productBuss;
      
        public RelatedProductSearchBoxViewComponent(IProductBuss productBuss)
        {
            this.productBuss = productBuss;
           
        }


        public IViewComponentResult Invoke(RelatedProductsearchAddModel sm)
        {
            return View(sm);
        }
    }
}
