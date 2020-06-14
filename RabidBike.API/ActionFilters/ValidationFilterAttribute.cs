using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RabidBike.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RabidBike.API.ActionFilters
{
    public class ValidationFilterAttribute : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var param = context.ActionArguments.SingleOrDefault(p => p.Value is BaseEntity<int>);
            if(param.Value == null)
            {
                context.Result = new BadRequestObjectResult("Argument is null");
                return;
            }

            if(!context.ModelState.IsValid)
            {
                context.Result = new BadRequestObjectResult(context.ModelState);
            }
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            throw new NotImplementedException();
        }
    }
}
