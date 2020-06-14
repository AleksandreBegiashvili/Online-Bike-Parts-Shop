using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RabidBike.Data.Context;
using RabidBike.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RabidBike.API.ActionFilters
{
    public class ValidateEntityExistsAttribute<T> : IActionFilter where T : BaseEntity<int>
    {
        private readonly RabidBikeContext _context;

        public ValidateEntityExistsAttribute(RabidBikeContext context)
        {
            _context = context;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            int id;
            if (context.ActionArguments.ContainsKey("id"))
            {
                id = (int)context.ActionArguments["id"];
            }
            else
            {
                context.Result = new BadRequestObjectResult("Bad id parameter");
                return;
            }

            var entity = _context.Set<T>().SingleOrDefault(x => x.Id == id);

            if (entity == null)
            {
                context.Result = new NotFoundResult();
            }
            else
            {
                context.HttpContext.Items.Add("entity", entity);
            }
            
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            throw new NotImplementedException();
        }
    }
}
