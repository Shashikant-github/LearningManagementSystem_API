using Microsoft.AspNetCore.Mvc;
using UserAPI.AOP;
using UserAPI.Models;
using UserAPI.Services;
using UserAPI.UserAPILogFiles;

namespace UserAPI.Controllers
{
    [Route("/api/v1.0/lms/[controller]")]
    [ApiController]
   // [ExceptionHandler]
    [ServiceFilter(typeof(LoggingLogic))]
    public class CompanyController : ControllerBase
    {
        //readonly IUserRepository userRepository;
        readonly IUserService userService;
        readonly ITokenGeneratorService tokenGeneratorService;
        public CompanyController(IUserService _userService, ITokenGeneratorService _tokenGeneratorService)
        {
            userService = _userService;
            tokenGeneratorService = _tokenGeneratorService;
        }
        [HttpPost]
        [Route("register")]
        public ActionResult Register([FromBody] UserModel user)
        {
            var userAddedResult = userService.Register(user);
            return Created("User Registered", userAddedResult);

        }
        [HttpPost]
        [Route("Login")]
        public ActionResult Login([FromBody] UserInfoModel userInfo)
        {
            UserModel user = userService.Login(userInfo);
            if (user != null)
            {
                var JWTToken = tokenGeneratorService.GenerateToken(user.UserId, user.EmailID, user.IsAdmin);
                return Ok(JWTToken);
            }

            else return Ok();
            //return Ok("header.payload.signature");

        }
    }
}
