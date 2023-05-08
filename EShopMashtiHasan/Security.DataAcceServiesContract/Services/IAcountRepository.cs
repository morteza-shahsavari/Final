using Security.Domain.DTO.User;
using Framework.BaseModel;
using Security.Domain.Models;

namespace DataAccessServiceContract.Services
{
   public interface IAcountRepository
    {
        UserInfo GetUserInf(string UserName);
        User GetFullInfo(string UserName);
        OperationResult RegisterNewUser(User u);
        bool CheckIfUserHasaccess(CheckPermission per);
    }
}
