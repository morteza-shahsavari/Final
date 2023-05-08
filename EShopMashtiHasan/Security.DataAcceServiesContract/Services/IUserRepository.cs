using Framework.Base;
using Framework.BaseModel;
using Security.Domain.DTO.Role;
using Security.Domain.DTO.User;
using Security.Domain.Models;
using System.Collections.Generic;


namespace Security.DataAcceServiesContract.Repositories
{
    public interface IUserRepository:IBaseRepositorysearchable<User,int,UserSearchModel,UserListItem,UserUpdateModel,UserAddModel>
    {
        bool ExitsUserName(string UserName);
        bool ExitsUserName(string UserName, int UserID);
        public List<RoleDrop> RoleDrps();
        public OperationResult ChangePasswordUser(UserPasswordEditModel model);
    }
}
