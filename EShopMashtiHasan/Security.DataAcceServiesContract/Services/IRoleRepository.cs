using Framework.Base;
using Security.Domain.DTO.Role;
using Security.Domain.DTO.User;
using Security.Domain.Models;
using System.Collections.Generic;


namespace DataAccessServiceContract.Services
{
    public interface IRoleRepository:IBaseRepositorysearchable<Role,int,RoleSearchModel,RoleListItem,RoleUpdateModel,RoleAddModel>
    {
        bool ExitsRoleName(string RoleName);
        bool ExitsRoleName(string RoleName, int RoleID);
        int GetUserCount(int RoleID);
        List<UserListItem>UserList(int RoleID);
    }
}
