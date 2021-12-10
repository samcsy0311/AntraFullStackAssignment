using ApplicationCore.Models;

namespace ApplicationCore.ServiceInterfaces
{
     public interface IAccountService
     {
          public int RegisterUser(UserRegisterRequestModel model);
          public UserLoginResponseModel ValidateUser(LoginRequestModel model);
     }
}
