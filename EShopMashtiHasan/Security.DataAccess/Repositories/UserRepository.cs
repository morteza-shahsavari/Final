using Framework.BaseModel;
using Security.DataAcceServiesContract.Repositories;
using Security.Domain.DTO.Role;
using Security.Domain.DTO.User;
using Security.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Security.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        #region Fields
        private readonly SecurityContext db;
        #endregion

        #region Ctor
        public UserRepository(SecurityContext db)
        {
            this.db = db;
        }
        #endregion

        #region Events
        public OperationResult Add(UserAddModel model)
        {
            OperationResult op = new OperationResult("Add user");
            try
            {

                var u = new User
                {
                    RoleID= model.RoleID,
                    UserName= model.UserName,
                    Password= model.Password,
                    LastName= model.LastName,
                    FirstName= model.FirstName,
                    Email= model.Email,
                    IsEmailActivated= model.IsEmailActivated,
                    Mobile  = model.Mobile
                    ,Address= model.Address
                };
                db.Users.Add(u);
                db.SaveChanges();
               
                return op.Succeed( "Add user Successfully", u.RoleID);
            }
            catch (Exception ex)
            {

                return op.Failed("Add user ToFail" + ex.Message);
            }
        }

        public OperationResult Remove(int id)
        {
            OperationResult op = new OperationResult("Delete User");
            try
            {
                var user = db.Users.FirstOrDefault(x => x.UserID == id);
                db.Users.Remove(user);
                db.SaveChanges();
                return op.Succeed( "Delete User Successfully",id);
            }
            catch (Exception ex)
            {

                return op.Failed("Delete User to Fail" + ex.Message);
            }
        }

        public bool ExitsUserName(string UserName)
        {
            return db.Users.Any(x => x.UserName == UserName);
        }

        public bool ExitsUserName(string UserName, int UserID)
        {
            return db.Users.Any(x => x.UserName == UserName && x.UserID != UserID);
        }

        public User Get(int id)
        {
           return db.Users.FirstOrDefault(x=>x.UserID==id);
        }

        public List<User> GetAll()
        {
            return db.Users.ToList();
        }

        public List<RoleDrop> RoleDrps()
        {
            var q = from item in db.Roles select item;
            return q.Select(x => new RoleDrop
            {
                RoleID = x.RoleID,
                RoleName = x.RoleName
            }).ToList();
        }

        public List<UserListItem> Search(UserSearchModel sm, out int RecordCount)
        {
            var q = from item in db.Users select item;
            if (!string.IsNullOrEmpty(sm.UserName))
            {
                q = q.Where(x => x.UserName.StartsWith(sm.UserName));
            }
            if (!string.IsNullOrEmpty(sm.LastName))
            {
                q = q.Where(x => x.LastName.StartsWith(sm.LastName));
            }
            if (!string.IsNullOrEmpty(sm.FirstName))
            {
                q = q.Where(x => x.FirstName.StartsWith(sm.FirstName));
            }
            if (!string.IsNullOrEmpty(sm.Mobile))
            {
                q = q.Where(x => x.Mobile.StartsWith(sm.Mobile));
            }
            if (sm.RoleID != null)
            {
                q = q.Where(x => x.RoleID == sm.RoleID);
            }

            RecordCount = q.Count();
            return q.OrderByDescending(x => x.UserID).Select(x => new UserListItem
            {
                UserID = x.UserID,
                UserName = x.UserName,
              
                Email = x.Email,
                Mobile = x.Mobile,
                FirstName = x.FirstName,
                LastName = x.LastName,
                RoleName = x.Role.RoleName
            }).Skip(sm.PageIndex * sm.PageSize).Take(sm.PageSize).ToList();
        }

        public OperationResult Update(UserUpdateModel model)
        {
            var op = new OperationResult("Update User");
            try
            {
                var r = db.Users.FirstOrDefault(x => x.UserID == model.UserID);
                r.LastName=model.LastName;
                r.FirstName=model.FirstName;
                r.Email=model.Email;
                r.Mobile=model.Mobile;
                r.RoleID= model.RoleID;
                r.Address=model.Address;
                db.SaveChanges();
                return op.Succeed("Update User Successfully");
            }
            catch (Exception ex)
            {
                return op.Failed("Update User Fail" + ex.Message);
            }
        }

        public OperationResult ChangePasswordUser(UserPasswordEditModel model)
        {
            var op = new OperationResult("Update Change Password User");
            try
            {
               var pass= db.Users.FirstOrDefault(x => x.UserID == model.UserID);
                pass.Password=model.Password;
                db.SaveChanges();
                return op.Succeed("Update Change PassWord User Successfully");
            }
            catch (Exception ex)
            {
                return op.Failed("Update Change PassWord User Fail" + ex.Message);
            }
           
        }
        #endregion
    }
}
