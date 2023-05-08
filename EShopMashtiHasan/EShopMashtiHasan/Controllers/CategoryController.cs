
using Microsoft.AspNetCore.Mvc;
using Shopping.BusinessServiceContract.Services;
using Shopping.DomainModel.DTO.Category;
using Shopping.DomainModel.ViewModel.Categories;
using System.Linq;


namespace EShopMashtiHasan.Controllers
{
    public class CategoryController : Controller
    {
        #region Fields

        private readonly ICatBuss _catBuss;
        private readonly IProductBuss _productBuss;
        #endregion

        #region Ctor

        public CategoryController(ICatBuss catBuss, IProductBuss productBuss)
        {
            _catBuss = catBuss;
            _productBuss = productBuss;
        }

        #endregion

        #region Events 

        public IActionResult Index(CategorySearch_VM categorySearch_VM)
        {
            //if (categorySearch_VM.PageIndex == 0)
            //{
            //    categorySearch_VM.PageIndex = categorySearch_VM.PageIndex = 1;
            //}

            var categorySerch = new CategorySearchModel { CategoryName = categorySearch_VM.CategoryName, PageSize = 12, PageIndex = categorySearch_VM.PageIndex ,OrderBy = categorySearch_VM.OrderBy};
            int rc = 0;
            var result = _catBuss.Search(categorySerch, out rc);

            if (result != null)
            {

                categorySearch_VM.RecordCount = _productBuss.GetAll().Where(x => x.CategoryID == result.MainResults.FirstOrDefault().CategoryID).Count();
                categorySearch_VM.CategoryName = result.MainResults.First().CategoryName;
                categorySerch.RecordCount = categorySearch_VM.RecordCount;
                categorySearch_VM.pageCount = setPager(categorySerch);
                var categoryProducts = result.MainResults.Select(x => x.Products);
                categorySearch_VM.CategoryProductListItems = result.MainResults.Select(x => new CategoryProductListItem
                {
                    CategoryID = x.CategoryID,
                    CategoryName = x.CategoryName,
                    ParentID = x.ParentID,
                    ParentNames = x.ParentNames,
                   ChildCount=x.ChildCount,
                    ProductCount=x.ProductCount,
                    Products=x.Products
                }).ToList();
                
            }
            
            return View(categorySearch_VM);
        }
        
        private int setPager(CategorySearchModel categorySearchModel)
        {
            if (categorySearchModel.RecordCount % categorySearchModel.PageSize == 0)
            {
                categorySearchModel.pageCount = categorySearchModel.RecordCount / categorySearchModel.PageSize;
            }
            else
            {
                categorySearchModel.pageCount = categorySearchModel.RecordCount / categorySearchModel.PageSize + 1;
            }

            return categorySearchModel.pageCount;
        }

        public PartialViewResult CategoryProductList(CategorySearch_VM categorySearch_VM) 
        {
            if (categorySearch_VM.PageIndex == 0)
            {
                categorySearch_VM.PageIndex = categorySearch_VM.PageIndex = 1;
            }
            var categorySerch = new CategorySearchModel { CategoryName = categorySearch_VM.CategoryName, PageSize = 12, PageIndex = categorySearch_VM.PageIndex, OrderBy = categorySearch_VM.OrderBy };
            int rc = 0;
            var result = _catBuss.Search(categorySerch, out rc);

            if (result != null)
            {
                categorySearch_VM.RecordCount = _productBuss.GetAll().Where(x => x.CategoryID == result.MainResults.First().CategoryID).Count();
                categorySearch_VM.CategoryName = result.MainResults.First().CategoryName;
                categorySerch.RecordCount = categorySearch_VM.RecordCount;
                categorySearch_VM.pageCount = setPager(categorySerch);
                var categoryProducts = result.MainResults.Select(x => x.Products);
                categorySearch_VM.CategoryProductListItems = result.MainResults.Select(x => new CategoryProductListItem
                {
                    CategoryID = x.CategoryID,
                    CategoryName = x.CategoryName,
                    ParentID = x.ParentID,
                    ParentNames = x.ParentNames,
                    Products = x.Products,
                }).ToList();

            }
            return PartialView(categorySearch_VM.CategoryProductListItems);
        }
      
        #endregion
    }
}