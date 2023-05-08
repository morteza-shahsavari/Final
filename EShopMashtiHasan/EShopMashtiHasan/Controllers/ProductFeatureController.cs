using EShopMashtiHasan.Helper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Shopping.BusinessServiceContract.Services;
using Shopping.DomainModel.DTO.ProductFeatureValues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text.Json;
using System.Text.Json.Serialization;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace EShopMashtiHasan.Controllers
{
    [ServiceFilter(typeof(CustomAuthenticator))]
    public class ProductFeatureController : Controller
    {
        private readonly IProductBuss buss;
        private readonly IFeatureBuss feaBuss;
        public ProductFeatureController(IProductBuss buss, IFeatureBuss feaBuss)
        {
            this.buss = buss;
            this.feaBuss = feaBuss;
        }

        public IActionResult Index(ProductFeatureSearchAddModel sm)
        {
            var q = buss.Get(sm.ProductID);
            ViewBag.productName = q.ProductName;
            return View(sm);
        }
        public IActionResult ProductFeatureSearchBox(ProductFeatureSearchAddModel sm)
        {
            return ViewComponent("ProductFeatureSearchBox", sm);
        }
        public IActionResult ProductFeatureList(ProductFeatureSearchAddModel sm)
        {
            return ViewComponent("ProductFeatureList", sm);
        }
        [HttpPost]
        public JsonResult AddNew(ProductFeatureSearchAddModel model)
        {
            return Json(buss.AddFeature(model));
        }
        [HttpPost]

        public JsonResult Update(int id,string values)
        {
            return Json(buss.UpdateFeature(id,values));
        }


        [HttpPost]

        public JsonResult UpdateَAllProductFeature(string data)
        {
            
                List<productFeatureUpdate> obj = JsonConvert.DeserializeObject<List<productFeatureUpdate>>(data);
                

                return Json(buss.UpdateَAllProductFeature(obj));


        }

        public JsonResult Delete(int id)
        {
            return Json(buss.DeleteFeature(id));
        }

        public JsonResult Get(string search)
        {

            var items = feaBuss.SearchFeatureName(search);

            var q = new
            {
                results = items.Select(x => new
                {
                    id = x.FeatureID,
                    text = x.FeatureName
                }).ToList()
            };

            return Json(q);
        }


    }
}
