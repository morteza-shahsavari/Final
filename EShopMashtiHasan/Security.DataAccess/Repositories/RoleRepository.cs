
using DataAccessServiceContract.Services;
using Framework.BaseModel;
using Security.Domain.DTO.Role;
using Security.Domain.DTO.User;
using Security.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.DataAccess.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        #region Fields
        private readonly SecurityContext db;
        #endregion

        #region Ctor
        public RoleRepository(SecurityContext db)
        {
            this.db = db;
        }
        #endregion 

        #region Events
        public OperationResult Add(RoleAddModel model)
        {
            OperationResult op = new OperationResult("Add Role");
            try
            {
                var r = new Role
                {
                    RoleName= model.RoleName
                };
                db.Roles.Add(r);
                db.SaveChanges();
               
                return op.Succeed("Add Role Successfully", r.RoleID);
            }
            catch (Exception ex)
            {

                return op.Failed("Add Role ToFail" + ex.Message);
            }
        }

        public OperationResult Remove(int id)
        {
            OperationResult op = new OperationResult("Delete Role");
            try
            {
                var ro = db.Roles.FirstOrDefault(x => x.RoleID == id);
                db.Roles.Remove(ro);
                db.SaveChanges();
                return op.Succeed("Delete Role Successfully", id);
            }
            catch (Exception ex)
            {

                return op.Failed( "Delete Role to Fail" + ex.Message);
            }
        }

        public bool ExitsRoleName(string RoleName)
        {
            return db.Roles.Any(x => x.RoleName == RoleName);
        }

        public bool ExitsRoleName(string RoleName, int RoleID)
        {
            return db.Roles.Any(x => x.RoleName == RoleName && x.RoleID != RoleID);
        }

        public Role Get(int id)
        {
            return db.Roles.FirstOrDefault(x => x.RoleID == id);
        }

        public List<Role> GetAll()
        {
            return db.Roles.ToList();
        }

        public int GetUserCount(int RoleID)
        {
            return db.Users.Count(x=>x.RoleID== RoleID);
        }
         public OperationResult Update(RoleUpdateModel model)
        {
            var op = new OperationResult("Update Role");
            try
            {
                var r = db.Roles.FirstOrDefault(x => x.RoleID == model.RoleID);
                r.RoleName=model.RoleName;
                db.SaveChanges();
                return op.Succeed("Update Role Successfuly");
            }
            catch (Exception ex)
            {
                return op.Failed("Update Role Fail" + ex.Message);
            }
        }

        public List<RoleListItem> Search(RoleSearchModel sm, out int RecordCount)
        {
            var q = from item in db.Roles select item;
            if (!string.IsNullOrEmpty(sm.RoleName))
            {
                q = q.Where(x => x.RoleName.StartsWith(sm.RoleName));
            }
          
            RecordCount = q.Count();
            return q.OrderByDescending(x => x.RoleID).Select(x => new RoleListItem
            {
               RoleName= x.RoleName,
               RoleID= x.RoleID,
               UserCount=x.Users.Any()? x.Users.Count() : 0,
            }).Skip(sm.PageIndex * sm.PageSize).Take(sm.PageSize).ToList();
        }

      
        public List<UserListItem> UserList(int RoleID)
        { 
            var q=db.Users.Where(x=>x.RoleID == RoleID);
            return q.Select(x => new UserListItem
            {
               UserID= x.UserID,
               UserName=x.UserName,
              
               Email=x.Email,
               Mobile=x.Mobile,
               FirstName=x.FirstName,
               LastName=x.LastName,
               RoleName=x.Role.RoleName
            }).ToList();
        }
#endregion
    }
}
