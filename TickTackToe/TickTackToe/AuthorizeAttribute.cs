using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TickTackToe.Controllers;

namespace TickTackToe
{
    public class AuthorizeAttribute : ResultFilterAttribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
                //throw new NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
           string response=null;
           var apiKey = context.HttpContext.Request.Headers["apikey"].ToString();
           Authorization obj = new Authorization();
           response= obj.Authentication(apiKey);
           if (string.IsNullOrEmpty(apiKey))
           {
             throw new UnauthorizedAccessException("Access token not passed!");
           }
           else
           {
             if (response == null)
               throw new UnauthorizedAccessException("Invalid User!");

           }
            
        }

    }
    
}
