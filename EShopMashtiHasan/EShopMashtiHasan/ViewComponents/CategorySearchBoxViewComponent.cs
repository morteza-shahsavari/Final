
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shopping.BusinessServiceContract.Services;
using Shopping.DomainModel.DTO.Category;
using Shopping.DomainModel.Models;

namespace EShopMashtiHasan.ViewComponents
{
    [ViewComponent(Name = "CategorySearchBox")]
    public class CategorySearchBoxViewComponent:ViewComponent
    {

        private readonly ICatBuss buss;
        public CategorySearchBoxViewComponent(ICatBuss buss)
        {
            this.buss = buss;
        }

        private void InflateCategoryDropDown()
        {
            var cats = buss.GetAll();
            cats.Insert(0, new Category { CategoryID = -1, CategoryName = "...Please Select..." });
            SelectList drpCats = new SelectList(cats, "CategoryID", "CategoryName");
            ViewBag.cats = drpCats;

        }


        public IViewComponentResult Invoke(CategorySearchModel sm)
        {
            InflateCategoryDropDown();
            return View(sm);
        }

    }
}
