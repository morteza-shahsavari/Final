using Microsoft.AspNetCore.Mvc;
using Security.BuessinessServiceContract.Services;
namespace EShopMashtiHasan.Controllers
{
    public class BaseController : Controller
    {
        private readonly IAuthHelper _authHelper;
        public BaseController(IAuthHelper authHelper)
        {
            this._authHelper = authHelper;
            TempData["cu"] = _authHelper.GetCurrentUserInfo();

        }
       
    }
}
