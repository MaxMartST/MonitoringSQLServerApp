using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MonitoringSQLServer.Domain
{
    //public class ValidationFilter : Attribute, IAsyncResultFilter
    //{
    //    public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    //    {
    //        if (!context.ModelState.IsValid)
    //        {
    //            context.Result = new BadRequestObjectResult(context.ModelState);
    //        }

    //        await next();
    //    }
    //}

    public class ValidationFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new BadRequestObjectResult(context.ModelState);
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {

        }
    }

    //public class ValidationFilter : IAsyncActionFilter
    //{
    //    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    //    {
    //        if (!context.ModelState.IsValid)
    //        {
    //            var errorsInModelState = context.ModelState
    //                .Where(x => x.Value.Errors.Count > 0)
    //                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(x => x.ErrorMessage)).ToArray();

    //            var errorResponse = new ErrorResponse();

    //            foreach (var error in errorsInModelState)
    //            {
    //                foreach (var subError in error.Value)
    //                {
    //                    var errorModel = new ErrorModel
    //                    {
    //                        FieldName = error.Key,
    //                        Message = subError
    //                    };

    //                    errorResponse.Errors.Add(errorModel);
    //                }
    //            }

    //            context.Result = new BadRequestObjectResult(errorResponse);
    //            return;
    //        }

    //        await next();

    //        // after controller
    //    }
    //}
}
