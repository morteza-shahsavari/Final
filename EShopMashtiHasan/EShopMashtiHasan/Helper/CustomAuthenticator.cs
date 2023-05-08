
using Microsoft.AspNetCore.Mvc.Filters;
using Security.BuessinessServiceContract.Services;
using Security.Domain.DTO.User;
using Shopping.BusinessServiceContract.Services;

namespace EShopMashtiHasan.Helper
{
    public class CustomAuthenticator : ActionFilterAttribute
    {
        private readonly IAuthHelper _authHelper;
        private readonly IAccountApplication _acountApp;
     

        public CustomAuthenticator(IAuthHelper authHelper, IAccountApplication _acountApp, ISessionHelper sessionHelper, IOrderBuss orderBuss)
        {
            _authHelper = authHelper;
            this._acountApp = _acountApp;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //Chek if cookie exist and user is Logged in or not
            if (!context.HttpContext.User.Identity.IsAuthenticated)
            {
                context.HttpContext.Response.Redirect("/Account/Login");
            }
            //be dast avardan username az cookie e karbari ke login
            //karde ast
            var username = context.HttpContext.User.Identity.Name;

            //in filter balaie kodam controller dar hal e ejra ast
            var ControllerName = context.RouteData.Values["Controller"].ToString();
            //in filter balaie kodam Action dar hal e ejra ast
            var ActionName = context.RouteData.Values["Action"].ToString();

            var userInfo = _authHelper.GetCurrentUserInfo();

            //Checking SecurityInfo
            if (string.IsNullOrEmpty(userInfo.UserName))
            {
                context.HttpContext.Response.Redirect("/Account/Login");
            }

            CheckPermission permission = new CheckPermission
            {
                UserName = username
                ,
                Controller = ControllerName
                ,
                ActionName = ActionName
            };
            //agar karbar dastresi nadasht partabesh mikonim safhe login
            //in tabe dar amal az join estefadeh mimkonad
            if (!_acountApp.CheckIfUserHasaccess(permission))
            {
                context.HttpContext.Response.Redirect("/Account/Login");
            }

            base.OnActionExecuting(context);
        }
    }
}