using EShopMashtiHasan.Helper;
using Microsoft.AspNetCore.Mvc;
using Shopping.BusinessServiceContract.Services;

using Shopping.DomainModel.DTO.RelatedProduct;
using Shopping.DomainModel.Models;
using System.Linq;

namespace EShopMashtiHasan.Controllers
{
    [ServiceFilter(typeof(CustomAuthenticator))]
    public class RelatedProductController : Controller
    {
        
        private readonly IProductBuss buss;
        public RelatedProductController( IProductBuss buss)
        {
            this.buss = buss;
           
        }

        public IActionResult Index(RelatedProductsearchAddModel sm)
        {
            var q = buss.Get(sm.ProductID);
            ViewBag.ProName = q.ProductName;
            return View(sm);
        }
        public IActionResult RelatedProductSearchBox(RelatedProductsearchAddModel sm)
        {
            return ViewComponent("RelatedProductSearchBox", sm);
        }

        public IActionResult RelatedProductList(RelatedProductsearchAddModel sm)
        {
            return ViewComponent("RelatedProductList", sm);
        }
        [HttpPost]
        public JsonResult AddNew(RelatedProduct model)
        {
            return Json(buss.AddRelated(model));
        }
        public JsonResult Delete(int id)
        {
            return Json(buss.DeleteRelated(id));
        }


        public JsonResult GetRelated(string search)
        {

            var items = buss.SearchRelatedToName(search);

            var q = new
            {
                results = items.Select(x => new
                {
                    id = x.ProductID,
                    text = x.ProductName,
                }).ToList()
            };

            return Json(q);
        }



        [HttpPost]

        public JsonResult AddRelatedToProduct(int[] RelatedTo, int id)
        {

            return Json(buss.AddAllNewRelatedTo(RelatedTo, id));
        }


    }
}
