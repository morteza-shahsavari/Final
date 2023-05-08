using EShopMashtiHasan.Helper;
using Microsoft.AspNetCore.Mvc;
using Shopping.BusinessServiceContract.Services;
using Shopping.DomainModel.DTO.CategoryFeature;
using Shopping.DomainModel.Models;
using System.Linq;

namespace EShopMashtiHasan.Controllers
{
    [ServiceFilter(typeof(CustomAuthenticator))]
    public class CatFeaController : Controller
    {
       
        private readonly ICatBuss Catbuss;
        private readonly IFeatureBuss feaBuss;
        public CatFeaController( ICatBuss Catbuss, IFeatureBuss feaBuss)
        {
           
            this.Catbuss = Catbuss;
            this.feaBuss = feaBuss;
        }
        public IActionResult Index(CategoryFeatureSearchAddModel sm)
        {
            var q = Catbuss.Get(sm.CategoryID);
            ViewBag.catName = q.CategoryName;
            return View(sm);
        }



        public IActionResult CFSearchBox(CategoryFeatureSearchAddModel sm)
        {
            return ViewComponent("CFSearchBox", sm);
        }

        public IActionResult CFList(CategoryFeatureSearchAddModel sm)
        {
            return ViewComponent("CFList", sm);
        }
        [HttpPost]
        public JsonResult AddNew(CategoryFeature model)
        {
            return Json(Catbuss.AddFeature(model));
        }
        public JsonResult Delete(int id)
        {
            return Json(Catbuss.DeleteFeature(id));
        }


        public JsonResult Get(string search)
      {
           
            var items = feaBuss.SearchFeatureName(search);
          
            var q =new
            {
                results = items.Select(x => new
                {
                    id = x.FeatureID,
                    text = x.FeatureName
                }).ToList()
            };

            return Json(q);
        }



        [HttpPost]

        public JsonResult AddCategoryFeature(int[] feature,int id)
        {

            return Json(Catbuss.AddAllNewFeature(feature, id));
        }
    }
}
