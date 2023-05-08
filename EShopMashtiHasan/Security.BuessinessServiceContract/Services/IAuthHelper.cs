using Security.Domain.DTO.User;

namespace Security.BuessinessServiceContract.Services
{
    public interface IAuthHelper
    {
        void Signin(UserInfo account);
        void Signout();
        UserInfo GetCurrentUserInfo();
    }
}