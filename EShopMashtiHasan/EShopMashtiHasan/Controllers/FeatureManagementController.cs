
using Shopping.DomainModel.DTO.ProductFeature;
using Microsoft.AspNetCore.Mvc;
using Shopping.BusinessServiceContract.Services;
using Shopping.DomainModel.Models;
using EShopMashtiHasan.Helper;

namespace EShopMashtiHasan.Controllers
{
    [ServiceFilter(typeof(CustomAuthenticator))]
    public class FeatureManagementController : Controller
    {
        private readonly IFeatureBuss buss;
        public FeatureManagementController(IFeatureBuss buss)
        {
            this.buss = buss;
        }

        public IActionResult Index(FeatureSearchModel sm)
        {
            return View(sm);
        }

        public IActionResult FeatureSearchBox(FeatureSearchModel sm)
        {
            return ViewComponent("FeatureSearchBox", sm);
        }
        public IActionResult AddNew()
        {
            return ViewComponent("FeatureRegister");
        }

        [HttpPost]
        public JsonResult AddNew(Feature Feat)
        {
            return Json(buss.AddNew(Feat));
        }
        public IActionResult FeatureList(FeatureSearchModel sm)
        {
            return ViewComponent("FeatureList", sm);
        }
        public JsonResult Delete(int id)
        {
            return Json(buss.Delete(id));
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var q = buss.Get(id);
            return View(q);
        }

        [HttpPost]
        public JsonResult Update(Feature feat)
        {

            var result = buss.Update(feat);
            return Json(result);
        }

    }
}
