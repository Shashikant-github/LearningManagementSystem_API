using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.IO;

namespace UserAPI.UserAPILogFiles
{
    public class LoggingLogic : ActionFilterAttribute
    {
        readonly string textLogFile = "";
        DateTime startTime;
        DateTime endTime;
        TimeSpan totalTime;
        public LoggingLogic(IWebHostEnvironment environment)
        {
            textLogFile = environment.ContentRootPath + $"/LogFiles/Log.txt";
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            startTime = DateTime.Now;

            using (StreamWriter streamWriter = File.AppendText(textLogFile))
            {
                var controllerBase = (ControllerBase)context.Controller;
                var controllerContext = (ControllerContext)controllerBase.ControllerContext;
                var controllerName = controllerContext.ActionDescriptor.ControllerName;
                var controllerActionName = controllerContext.ActionDescriptor.ActionName;
                streamWriter.Write($"Start Time: {startTime}\tControllerName:{controllerName}\tActionName:{controllerActionName}\t");
                streamWriter.Close();
            }

        }
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            endTime = DateTime.Now;
            totalTime = endTime - startTime;
            using (StreamWriter streamWriter = File.AppendText(textLogFile))
            {
                streamWriter.Write($"EndTime:{endTime}\t totalTime={totalTime}");
                streamWriter.WriteLine();
                streamWriter.Close();
            }
        }

    }
}
