

using Shopping.BusinessServiceContract.Services;

using Shopping.DomainModel.DTO.Category;

using Microsoft.AspNetCore.Mvc;

using System;
using System.Linq;

namespace EShopMashtiHasan.ViewComponents
{
    [ViewComponent(Name = "CategoryResult")]
    public class CategoryResultViewComponenet : ViewComponent
    {
        #region Fields

        private readonly ICatBuss _catBuss;

        #endregion

        #region Ctor

        public CategoryResultViewComponenet(ICatBuss catBuss)
        {
            _catBuss = catBuss;
        }

        #endregion

        #region Events

        public IViewComponentResult Invoke(string categoryName)
        {
            var category = _catBuss.GetAll().First(x => x.CategoryName == categoryName);
            var categorySearchModel = new CategorySearchModel();
            categorySearchModel.ParentName = category.CategoryName;
            categorySearchModel.ParentID = category.CategoryID;
            categorySearchModel.HaveChildrens = category.Children.Any();
            categorySearchModel.SubCategories = category.Children.Select(x => new CategorySearchModel
            {
                CategoryName = x.CategoryName,
                ParentID = x.ParentID,
                ParentName = x.CategoryName,
                HaveChildrens = x.Children.Any(),
                SubCategories = x.Children.Select(m => new CategorySearchModel
                {
                    CategoryName = m.CategoryName,
                    ParentID = m.ParentID,
                    ParentName = m.CategoryName,
                    HaveChildrens = m.Children.Any(),
                    SubCategories = m.Children.Select(d => new CategorySearchModel
                    {
                        CategoryName = d.CategoryName,
                        ParentID = d.ParentID,
                        ParentName = d.CategoryName,
                    }).ToList()
                }).ToList()
            }).ToList();
            return View(categorySearchModel);
        }

        #endregion
    }
}
