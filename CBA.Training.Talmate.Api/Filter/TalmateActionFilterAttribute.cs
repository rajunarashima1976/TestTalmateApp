using CBA.Training.Talmate.Services.LoggerService;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CBA.Training.Talmate.Api.Filter
{
    public class TalmateActionFilterAttribute : ActionFilterAttribute
    {
        private readonly ILoggerService _logger;
        public TalmateActionFilterAttribute(ILoggerService logger)
        {
            _logger = logger;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string controllerName = (string)context.RouteData.Values["Controller"];
            var actionName = (string)context.RouteData.Values["action"];
            var message = "Controller : " + controllerName + ", Action : " + actionName + ",  This is before action method  get executed (OnActionExecuting)";
            _logger.WriteActionExecutionToFile(message.ToString());

            base.OnActionExecuting(context); 
            
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            string controllerName = (string)context.RouteData.Values["Controller"];
            var actionName = (string)context.RouteData.Values["action"];
            var message = "Controller : " + controllerName + ", Action : " + actionName + ",  This is after action method get executed (OnActionExecuted)";
            _logger.WriteActionExecutionToFile(message.ToString());

            base.OnActionExecuted(context);
        }
    }
}
