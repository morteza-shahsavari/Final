using Microsoft.AspNetCore.Mvc;

namespace EShopMashtiHasan.ViewComponents
{
    public class NewProductsViewComponent : ViewComponent
    {
        #region Fields
        #endregion

        #region Ctor

        public NewProductsViewComponent()
        {

        }

        #endregion

        #region Events

        public IViewComponentResult Invoke() 
        {

            return View();
        }

        #endregion

    }
}
