using EShopMashtiHasan.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Security.BuessinessServiceContract.Services;
using Security.Domain.DTO.Role;
using Security.Domain.DTO.User;
using Security.Framework.Services;

namespace EShopMashtiHasan.Controllers
{
    public class UserManagementController : Controller
    {
        private readonly IUserBuss buss;
        private readonly IPasswordHasher PasswordHasher;
        public UserManagementController(IUserBuss buss, IPasswordHasher PasswordHasher)
        {
            this.buss = buss;
            this.PasswordHasher = PasswordHasher;
        }
        private void InflatedrpSearchRole()
        {
            var drpRole = buss.RoleDrps();
            drpRole.Insert(0, new RoleDrop { RoleID = -1, RoleName = "...Role..." });
            SelectList drpRol = new SelectList(drpRole, "RoleID", "RoleName");
            ViewBag.drpRole = drpRol;
        }
        [ServiceFilter(typeof(CustomAuthenticator))]

        public IActionResult Index(UserSearchModel sm)
        {
            return View(sm);
        }
        [ServiceFilter(typeof(CustomAuthenticator))]
        public IActionResult UserSearchBox(UserSearchModel sm)
        {
            return ViewComponent("UserSearchBox", sm);
        }
        [ServiceFilter(typeof(CustomAuthenticator))]
        public IActionResult AddNew()
        {
            return ViewComponent("UserRegister");
        }
        [ServiceFilter(typeof(CustomAuthenticator))]
        [HttpPost]
        public JsonResult AddNew(UserAddModel user)
        {
            user.Password = PasswordHasher.Hash(user.Password);
            return Json(buss.Register(user));
        }
        [ServiceFilter(typeof(CustomAuthenticator))]
        public IActionResult UserList(UserSearchModel sm)
        {
            return ViewComponent("UserList", sm);
        }
        [ServiceFilter(typeof(CustomAuthenticator))]
        public JsonResult Delete(int id)
        {
            return Json(buss.Delete(id));
        }
        [HttpGet]
        [ServiceFilter(typeof(CustomAuthenticator))]
        public IActionResult Update(int id)
        {
            var q = buss.GetUser(id);
          var UserUpdate =new UserUpdateModel
            {
                UserID = q.UserID,
                LastName = q.LastName,
                FirstName = q.FirstName,
                Email = q.Email,
                Mobile = q.Mobile,
                RoleID=q.RoleID
            };
            InflatedrpSearchRole();
            return View(UserUpdate);
        }
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticator))]
        public JsonResult Update(UserUpdateModel user)
        {

            var result = buss.update(user);
            return Json(result);
        }
        [ServiceFilter(typeof(CustomAuthenticator))]
        public IActionResult ChangePassword(int id)
        {
            //var q = buss.GetUser(id);
            
            ViewBag.Id = id;
            return View();
        }
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticator))]
        public JsonResult ChangePassword(UserPasswordEditModel pass)
        {

            var result=buss.ChangePassWordUser(pass);
            return Json(result);
        }

        public IActionResult Profile(int id)
        {
            var q = buss.GetUser(id);
            var UserUpdate = new UserUpdateModel
            {
                UserID = q.UserID,
                LastName = q.LastName,
                FirstName = q.FirstName,
                Email = q.Email,
                Mobile = q.Mobile,
                Address= q.Address,
            };

            return View(UserUpdate);
        }

        public JsonResult UpdateProfile(UserUpdateModel user)
        {
            var result = buss.UpdateProfile(user);
            return Json(result);
        }

    }
}
