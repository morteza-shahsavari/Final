using Shopping.DomainModel.ViewModel.Categories;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using Shopping.BusinessServiceContract.Services;

namespace EShopMashtiHasan.ViewComponents
{
    [ViewComponent(Name = "Menu")]
    public class MenuViewComponent : ViewComponent
    {
        #region Fields

        private readonly ICatBuss _cateBuss;

        #endregion

        #region Ctor

        public MenuViewComponent(ICatBuss cateBuss)
        {
            _cateBuss = cateBuss;
        }

        #endregion

        #region Events

        public IViewComponentResult Invoke(Category_VM category_VM)
        {
            var categories = _cateBuss.GetAll();
            List<Category_VM> categories_Vm = new List<Category_VM>();
            var parentCategories = categories.Where(x => x.ParentID == null);
            foreach (var parent in parentCategories)
            {
                category_VM = new Category_VM();
                category_VM.ParentName = parent.CategoryName;
                category_VM.ParentId = parent.CategoryID;
                category_VM.HaveSubCategory = parent.Children.Any();
                category_VM.IsMobileDevice = Utility.RequestExtensions.IsMobileBrowser(Request);
                category_VM.SubCategories = parent.Children.Select(x => new Category_VM
                {
                    ChildId = x.CategoryID,
                    ChildName = x.CategoryName,
                    HaveSubCategory = x.Children.Any(),

                    SubCategories = x.Children.Select(z => new Category_VM
                    {
                        ChildId = z.CategoryID,
                        ChildName = z.CategoryName,
                        HaveSubCategory = z.Children.Any(),
                    }).ToList(),
                }).ToList();
                categories_Vm.Add(category_VM);
            }

            return View(categories_Vm);
        }

        #endregion

    }
}
