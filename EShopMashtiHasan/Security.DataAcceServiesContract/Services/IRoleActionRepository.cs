using Framework.Base;
using Security.Domain.DTO.ProjectAction;
using Security.Domain.DTO.ProjectController;
using Security.Domain.DTO.Role;
using Security.Domain.DTO.RoleAction;
using Security.Domain.Models;
using System.Collections.Generic;


namespace DataAccessServiceContract.Services
{
    public interface IRoleActionRepository:IBaseRepositorysearchable<RoleAction,int,RoleActionSearchModel,RoleActionListItem,RoleActionUpdateModel,RoleActionAddModel>
    {

        public List<RoleDrop> RoleDrps();
        public List<ProjectActionDrop> ProjectActionDrps(int? ID);
        public List<ProjectControllerDrop> ProjectControllerDrops();
      
        bool ExitsRoleAction(int RoleID, int ActionID);

    }
}
