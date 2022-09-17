using System.Collections.Generic;
using UserAPI.Models;

namespace UserAPI.Services
{
    public interface IUserService
    {
       // List<UserModel> GetAllUsers();
        bool Register(UserModel user);
        //object GetUserByName(string userName);
        UserModel Login(UserInfoModel userInfo);
    }
}
