using System.Collections.Generic;
using UserAPI.Exceptions;
using UserAPI.Models;
using UserAPI.Repository;

namespace UserAPI.Services
{
    public class UserService : IUserService
    {
        readonly IUserRepository userRepository;
        public UserService(IUserRepository _userRepository)
        {
            userRepository = _userRepository;
        }
        public bool Register(UserModel user)
        {
            var userExists = userRepository.Register(user);
            return userExists == 1;

        }
        public UserModel Login(UserInfoModel userInfo)
        {
            UserModel user = userRepository.Login(userInfo);
            if (user != null)
            {
                return user;
            }
            else
            {
                //throw new UserCredentialsInvalidException($"Invalid Credentials!!");
                return null;
            }
        }
    }
}
