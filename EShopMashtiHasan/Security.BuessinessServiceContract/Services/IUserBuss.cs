using Framework.BaseModel;
using Security.Domain.DTO.Role;
using Security.Domain.DTO.User;
using Security.Domain.Models;
using System.Collections.Generic;

namespace Security.BuessinessServiceContract.Services
{
    public interface IUserBuss
    {
       OperationResult Register(UserAddModel user);
        OperationResult update(UserUpdateModel user);
        OperationResult UpdateProfile(UserUpdateModel user);

        
        OperationResult Delete(int userID);
        List<UserListItem> Search(UserSearchModel sm, out int RecordCount);
        User GetUser(int userID);
        List<RoleDrop> RoleDrps();
        OperationResult ChangePassWordUser(UserPasswordEditModel model);
    }
}
