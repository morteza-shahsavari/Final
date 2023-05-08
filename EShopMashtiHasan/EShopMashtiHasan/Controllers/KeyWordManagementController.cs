
using EShopMashtiHasan.Helper;
using Microsoft.AspNetCore.Mvc;
using Shopping.BusinessServiceContract.Services;
using Shopping.DomainModel.DTO.KeyWord;
using Shopping.DomainModel.Models;

namespace EShopMashtiHasan.Controllers
{
    [ServiceFilter(typeof(CustomAuthenticator))]
    public class KeyWordManagementController : Controller
    {
        private readonly IKeyWordBuss buss;
        public KeyWordManagementController(IKeyWordBuss buss)
        {
            this.buss = buss;
        }

        public IActionResult Index(KeyWordSearchModel sm)
        {
            return View(sm);
        }
        public IActionResult KeyWordSearchBox(KeyWordSearchModel sm)
        {
            return ViewComponent("KeyWordSearchBox", sm);
        }

        public IActionResult AddNew()
        {
            return ViewComponent("KeyWordRegister");
        }
        [HttpPost]
        public JsonResult AddNew(KeyWord KW)
        {
            return Json(buss.AddNew(KW));
        }
        public IActionResult KeyWordList(KeyWordSearchModel sm)
        {
            return ViewComponent("KeyWordList", sm);
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
        public JsonResult Update(KeyWord KW)
        {

            var result = buss.Update(KW);
            return Json(result);
        }
    }
}
