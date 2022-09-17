using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using UserAPI.Exceptions;

namespace UserAPI.AOP
{
    public class ExceptionHandlerAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception.GetType() == typeof(UserAlreadyExistException))
            {
                context.Result = new OkObjectResult(context.Exception.Message);
            }
            else if (context.Exception.GetType() == typeof(UserCredentialsInvalidException))
            {
                context.Result = new OkObjectResult(context.Exception.Message);
            }
            else if (context.Exception.GetType() == typeof(UserNotFoundException))
            {
                context.Result = new OkObjectResult(context.Exception.Message);
            }
            else
            {
                context.Result = new StatusCodeResult(500);
            }
        }
    }
}
