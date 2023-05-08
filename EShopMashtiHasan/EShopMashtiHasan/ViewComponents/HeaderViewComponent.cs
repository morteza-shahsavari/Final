

using Microsoft.AspNetCore.Mvc;
using Shopping.DomainModel.ViewModel.Categories;

namespace EShopMashtiHasan.ViewComponents
{
    [ViewComponent(Name = "Header")]
    public class HeaderViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(CategorySearch_VM categorySearch_VM) 
        {
            categorySearch_VM.IsMobileDevice = false;
            categorySearch_VM.IsMobileDevice = Utility.RequestExtensions.IsMobileBrowser(Request);
            return View(categorySearch_VM);
        }
    }
}
