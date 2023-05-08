using EShopMashtiHasan.Helper;
using Microsoft.AspNetCore.Mvc;

using Shopping.BusinessServiceContract.Services;

using Shopping.DomainModel.DTO.ProductKeyWord;
using Shopping.DomainModel.Models;
using System.Linq;

namespace EShopMashtiHasan.Controllers
{
    [ServiceFilter(typeof(CustomAuthenticator))]
    public class ProductKeyWordController : Controller
    {
       
        private readonly IProductBuss probuss;
        private readonly IKeyWordBuss keybuss;
        public ProductKeyWordController( IProductBuss probuss, IKeyWordBuss keybuss)
        {
           
            this.keybuss= keybuss;
            this.probuss = probuss;
        }

        public IActionResult Index(ProductKeyWordSearchAddModel sm)
        {
            var q = probuss.Get(sm.ProductID);
            ViewBag.ProName = q.ProductName;
            return View(sm);
        }
        public IActionResult ProKeySearchBox(ProductKeyWordSearchAddModel sm)
        {
            return ViewComponent("ProKeySearchBox", sm);
        }

        public IActionResult ProKeyList(ProductKeyWordSearchAddModel sm)
        {
            return ViewComponent("ProKeyList", sm);
        }
        [HttpPost]
        public JsonResult AddNew(ProductKeyWord acta)
        {
            return Json(probuss.AddGetKeyWord(acta));
        }
        public JsonResult Delete(int id)
        {
            return Json(probuss.DeleteGetKeyWord(id));
        }


        public JsonResult Get(string search)
        {

            var items = keybuss.SearchKeywordName(search);

            var q = new
            {
                results = items.Select(x => new
                {
                    id = x.KeyWordID,
                    text = x.KeyWordText
                }).ToList()
            };

            return Json(q);
        }



        [HttpPost]

        public JsonResult AddCategoryKeyword(int[] keyword, int id)
        {

            return Json(probuss.AddAllNewKeyword(keyword, id));
        }
    }
}
