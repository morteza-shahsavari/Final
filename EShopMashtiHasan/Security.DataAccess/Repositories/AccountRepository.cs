using DataAccessServiceContract.Services;
using Framework.BaseModel;
using Security.Domain.DTO.User;
using Security.Domain.Models;
using System;
using System.Linq;


namespace Security.DataAccess.Repositories
{
    public class AccountRepository : IAcountRepository
    {

        #region Fileds
        private readonly SecurityContext db;
        #endregion
        #region Ctor
        public AccountRepository(SecurityContext db)
        {
            this.db = db;
        }
        #endregion
        #region Events
        public User GetFullInfo(string UserName)
        {
            return db.Users.FirstOrDefault(x => x.UserName == UserName || x.Email == UserName);
        }

        public UserInfo GetUserInf(string UserName)
        {


            var q = from r in db.Roles
                    join u in db.Users
 on r.RoleID equals u.RoleID
                    where u.UserName == UserName || u.Email == UserName
                    select new UserInfo
                    {
                        FullName = u.LastName + u.FirstName
                ,
                        RoleID = u.RoleID
                ,
                        RoleName = r.RoleName
                ,
                        UserName = u.UserName
                ,
                        UserID = u.UserID,
                        Mobile = u.Mobile,
                        Email = u.Email,
                    };
            return q.FirstOrDefault();
        }

        public OperationResult RegisterNewUser(User u)
        {
            OperationResult op = new OperationResult("Register New User");
            try
            {
                if (u.RoleID == 0)
                {
                    u.RoleID = 1;
                }
                db.Users.Add(u);
                db.SaveChanges();
                op.Succeed("User Registered Successfully", u.UserID);
            }
            catch (Exception ex)
            {
                op.Failed("Registeration Failed   " + ex.Message, null);
            }
            return op;
        }

        public bool CheckIfUserHasaccess(CheckPermission per)
        {
            var q = from u in db.Users
                    join r in db.Roles on u.RoleID equals r.RoleID
                    join ra in db.RoleActions on r.RoleID equals ra.RoleID
                    join ac in db.ProjectActions on ra.ProjectActionID equals ac.ProjectActionID
                    join co in db.ProjectControllers on ac.ProjectController equals co

                    select new
                    {
                        co.ProjectControllerName,
                        ac.ProjectActionName
                        ,
                        u.UserName
                        ,
                        ra.HasPermission
                    };
            var result = q.FirstOrDefault(x =>
                x.UserName == per.UserName && x.ProjectActionName == per.ActionName &&
                x.ProjectControllerName == per.Controller);
            if (result == null)
            {
                return false;
            }

            return result.HasPermission;
        }
        #endregion
    }
}
