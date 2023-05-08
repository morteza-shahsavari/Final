using EShopMashtiHasan.Helper;
using Microsoft.AspNetCore.Mvc;


namespace EShopMashtiHasan.Controllers
{
    public class PanelAdminController : Controller
    {
        [ServiceFilter(typeof(CustomAuthenticator))]
        public IActionResult Index()
        {
            return View();
        }
    
    }
    
}
