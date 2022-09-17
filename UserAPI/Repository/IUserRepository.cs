using System.Collections.Generic;
using UserAPI.Models;

namespace UserAPI.Repository
{
    public interface IUserRepository
    {
        int Register(UserModel user);
        UserModel Login(UserInfoModel userInfo);
    }
}
