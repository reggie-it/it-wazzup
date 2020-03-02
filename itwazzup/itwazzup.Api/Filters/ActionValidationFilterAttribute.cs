using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace itwazzup.Api.Filters {
    [AttributeUsage (AttributeTargets.Method)]
    public class ActionValidationFilterAttribute : ActionFilterAttribute {
        public override void OnActionExecuting (ActionExecutingContext context) {
            if (!context.ModelState.IsValid) {
                context.Result = new BadRequestObjectResult (context.ModelState);
            }
        }
    }
}