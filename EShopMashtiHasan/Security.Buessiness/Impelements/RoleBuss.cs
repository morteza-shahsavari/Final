
using System.Collections.Generic;

using DataAccessServiceContract.Services;
using Framework.BaseModel;
using Security.BuessinessServiceContract.Services;
using Security.Domain.DTO.Role;
using Security.Domain.Models;

namespace Security.Buessiness.Impelements
{
    public class RoleBuss : IRoleBuss
    {
        private readonly IRoleRepository repo;
        public RoleBuss(IRoleRepository repo)
        {
            this.repo = repo;
        }

        public OperationResult Delete(int roleID)
        {
            return repo.Remove(roleID);
        }

        public Role GetRole(int roleID)
        {
            return repo.Get(roleID);
        }

        public OperationResult Register(RoleAddModel Role)
        {
            if (repo.ExitsRoleName(Role.RoleName))
            {
                return new OperationResult("Register Role")
                      .Failed("Role name Already Exist");
            }
            return repo.Add(Role);
        }

        public List<RoleListItem> Search(RoleSearchModel sm, out int RecordCount)
        {
            if (sm.PageSize == 0)
            {
                sm.PageSize = 20;
            }
            return repo.Search(sm, out RecordCount);
        }

        public OperationResult update(RoleUpdateModel Role)
        {
            if (repo.ExitsRoleName(Role.RoleName, Role.RoleID))
            {
                return new OperationResult("Update Role")
                      .Failed("role Name Already Exist");
            }
            return repo.Update(Role);
        }
    }
}
