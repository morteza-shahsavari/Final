using System.Collections.Generic;
using System.Linq;
using Framework.BaseModel;
using Security.BuessinessServiceContract.Services;
using Security.DataAcceServiesContract.Repositories;
using Security.Domain.DTO.Role;
using Security.Domain.DTO.User;
using Security.Domain.Models;
using Security.Framework.Services;

namespace Security.Buessiness.Impelements
{
    public class UserBuss : IUserBuss
    {
        private readonly IUserRepository repo;
        private readonly IPasswordHasher passwordHasher;
        public UserBuss(IUserRepository repo, IPasswordHasher passwordHasher)
        {
            this.repo = repo;
            this.passwordHasher = passwordHasher;
        }

        public OperationResult ChangePassWordUser(UserPasswordEditModel model)
        {

            var u = repo.Get(model.UserID);
            if (u == null)
            {
                new OperationResult("Change Password ").Failed("User Invalid");
            }

            //var (verified, needsUpgrade) = passwordHasher.Check(u.Password, model.OldPassword);
            //if (verified)
            //{
                model.Password = passwordHasher.Hash(model.Password);
                return repo.ChangePasswordUser(model);
            //}
            //else
            //{
            //    return new OperationResult("Change Password ").Failed("Old Password Invalid");
            //}


        }




        public OperationResult Delete(int userID)
        {
            return repo.Remove(userID);
        }

        public User GetUser(int userID)
        {
            return repo.Get(userID);
        }

        public OperationResult Register(UserAddModel user)
        {
            if (repo.ExitsUserName(user.UserName))
            {
                return new OperationResult("Register User")
                      .Failed("Username Already Exist");
            }
            if (user.RoleID == null || user.RoleID == -1)
            {
                return new OperationResult("Register User")
                      .Failed("Role Not Null ");
            }

            return repo.Add(user);
        }

        public List<RoleDrop> RoleDrps()
        {
            return repo.RoleDrps().ToList();
        }

        public List<UserListItem> Search(UserSearchModel sm, out int RecordCount)
        {
            if (sm.PageSize == 0)
            {
                sm.PageSize = 20;
            }
            return repo.Search(sm, out RecordCount);
        }

        public OperationResult update(UserUpdateModel user)
        {
            //var q=repo.Get(user.UserID);

            //if (repo.ExitsUserName(q.UserName, q.UserID))
            //{
            //  return new OperationResult("Update User")
            //        .Failed("Username Already Exist");
            //}
            return repo.Update(user);
        }

        public OperationResult UpdateProfile(UserUpdateModel user)
        {
            var q = repo.Get(user.UserID);
            var profile = new UserUpdateModel
            {
                UserID = user.UserID,
                LastName = user.LastName,
                FirstName = user.FirstName,
                Email = user.Email,
                Mobile = user.Mobile,
                RoleID = q.RoleID,
                IsEmailActivated = q.IsEmailActivated,
                Password = q.Password,
                UserName = q.UserName,
                Address=user.Address

            };
            return repo.Update(profile);

        }
    }
}
