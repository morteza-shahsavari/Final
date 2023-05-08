
using Shopping.DomainModel.DTO.Supplier;
using Microsoft.AspNetCore.Mvc;
using Shopping.BusinessServiceContract.Services;
using EShopMashtiHasan.Helper;

namespace EShopMashtiHasan.Controllers
{
    [ServiceFilter(typeof(CustomAuthenticator))]
    public class SupplierManagmentController : Controller
    {
        private readonly ISupplierBuss buss;
        public SupplierManagmentController(ISupplierBuss buss)
        {
            this.buss = buss;
        }

        public IActionResult Index(SupplierSearchModel sm)
        {
            return View(sm);
        }
        public IActionResult SupplierSearchBox(SupplierSearchModel sm)
        {
            return ViewComponent("SupplierSearchBox", sm);
        }

        public IActionResult AddNew()
        {
            return ViewComponent("SupplierRegister");
        }
        [HttpPost]
        public JsonResult AddNew(SupplierAddEditModel sup)
        {
            return Json(buss.AddNew(sup));
        }

        public IActionResult  SupplierList(SupplierSearchModel sm)
        {
            return ViewComponent("SupplierList", sm);
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
        public JsonResult Update(SupplierAddEditModel sup)
        {
           
            var result = buss.Update(sup);
            return Json(result);
        }
    }
}
