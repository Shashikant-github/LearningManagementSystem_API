using System.Linq;
using UserAPI.Context;
using UserAPI.Models;

namespace UserAPI.Repository
{
    public class UserRepository : IUserRepository
    {
 
        readonly UserDbContext userDbContext;
        public UserRepository(UserDbContext _userDbContext)
        {
            userDbContext = _userDbContext;

        }
        public int Register(UserModel user)
        {
            var isUserExists = userDbContext.Users.Where(u => u.EmailID.ToLower() == user.EmailID.ToLower()).FirstOrDefault();
            if (isUserExists == null)
            {
                user.UserName = user.UserName.ToUpper();
                user.EmailID = user.EmailID.ToLower();
                user.Password = user.Password.ToUpper();
                user.IsAdmin = false;

                userDbContext.Users.Add(user);
                return userDbContext.SaveChanges();
            }
            else return 0;
        }
        public UserModel Login(UserInfoModel userInfo)
        {
            return userDbContext.Users.Where(u => u.EmailID == userInfo.UserIEmailID.ToLower() && u.Password.ToLower() == userInfo.UserIPassword.ToLower()).FirstOrDefault();
        }
    }
}
