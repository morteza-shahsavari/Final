using EShopMashtiHasan.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Core.Infrastructure;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shopping.BusinessServiceContract.Services;
using Shopping.DomainModel.DTO.Category;
using Shopping.DomainModel.Models;

namespace EShopMashtiHasan.Controllers
{
    [ServiceFilter(typeof(CustomAuthenticator))]
    public class CategoryManagementController : Controller
    {
        private readonly ICatBuss buss;

        public CategoryManagementController(ICatBuss buss)
        {
            this.buss = buss;
        }
        public IActionResult Index(CategorySearchModel sm)
        {
            InflateCategoryDropDown();
            return View(sm);
        }

        public IActionResult List(CategorySearchModel sm)
       {
            return ViewComponent("CategoryList", sm);
        }

        private void InflateCategoryDropDown()
        {
            var cats = buss.GetAll();
            cats.Insert(0, new Category { CategoryID = -1, CategoryName = "...ریشه است..." });
            SelectList drpCats = new SelectList(cats, "CategoryID", "CategoryName");
            ViewBag.cats = drpCats;
            
        }

        [HttpGet]
        public IActionResult Add()
        {
            InflateCategoryDropDown();
            return View();
        }
        [HttpPost]
        public JsonResult Add(CategoryAddEditModel cat)
        {
            if (cat.ParentID.Value == -1)
            {
                cat.ParentID = null;
            }
            var result = buss.AddNew(cat);
            return Json(result);
        }
        public JsonResult Delete(int id)
        {
            var result = buss.Delete(id);
            return Json(result);
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var q=buss.Get(id);
            InflateCategoryDropDown();
            return View(q);

        }

        [HttpPost]
        public JsonResult Edit(CategoryAddEditModel cat)
        {
            if (cat.ParentID.Value == -1)
            {
                cat.ParentID = null;
            }
            var result = buss.Update(cat);
            return Json(result);
        }


        public IActionResult CategorySearchBox(CategorySearchModel sm)
        {
            return ViewComponent("CategorySearchBox", sm);
        }
    }
}
