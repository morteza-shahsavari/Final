
using System.Collections.Generic;
using System.Linq;
using DataAccessServiceContract.Services;
using Framework.BaseModel;
using Security.BuessinessServiceContract.BusinessModel.RoleAction;
using Security.BuessinessServiceContract.Services;
using Security.Domain.DTO.ProjectAction;
using Security.Domain.DTO.ProjectController;
using Security.Domain.DTO.Role;
using Security.Domain.DTO.RoleAction;
using Security.Domain.Models;

namespace Security.Buessiness.Impelements
{
    public class RoleActionBuss : IRoleActionBuss
    {
        private readonly IRoleActionRepository repo;
        public RoleActionBuss(IRoleActionRepository repo)
        {
            this.repo = repo;
        }

        public OperationResult Delete(int RoleActionID)
        {
            return repo.Remove(RoleActionID);
        }

        public RoleAction GetRoleAction(int RoleActionID)
        {
            return repo.Get(RoleActionID);
        }

        public List<ProjectActionDrop> ProjectActionDrps(int? id)
        {
            return repo.ProjectActionDrps(id).ToList();
        }
        public List<ProjectControllerDrop> ProjectControllerDrops()
        {
            return repo.ProjectControllerDrops().ToList();
        }

        public OperationResult Register(RoleActionViewModel RoleAction)
        {
            if (RoleAction.RoleID == null || RoleAction.RoleID == -1)
            {
                return new OperationResult("Register Role")
                      .Failed("Role Not Null ");
            }
            if (RoleAction.ProjectActionID == null || RoleAction.ProjectActionID == -1)
            {
                return new OperationResult("Register ProjectAction")
                      .Failed("ProjectAction Not Null ");
            }
            if (repo.ExitsRoleAction(RoleAction.RoleID,RoleAction.RoleID))
            {
                return new OperationResult("Register Role")
                     .Failed("Exits RoleAction ");
            }
            RoleActionAddModel q = new RoleActionAddModel
            {
                RoleID = RoleAction.RoleID,
                ProjectActionID = RoleAction.ProjectActionID,
                HasPermission = RoleAction.HasPermission
            };
            return repo.Add(q);
        }

        public List<RoleDrop> RoleDrps()
        {
            return repo.RoleDrps().ToList();
        }

        public List<RoleActionListItem> Search(RoleActionSearchModel sm, out int RecordCount)
        {
            if (sm.PageSize == 0)
            {
                sm.PageSize = 20;
            }
            return repo.Search(sm, out RecordCount);
        }

        public OperationResult update(RoleActionUpdateModel RoleAction)
        {
            return repo.Update(RoleAction);
        }
    }
}
