using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TickTackToe.DatabaseLayer;
using TickTackToe.Model;

namespace TickTackToe
{
    public class LogAttribute : ResultFilterAttribute, IActionFilter
    {
        LogDetails log = new LogDetails();
        LoggingData obj = new LoggingData(); 
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception == null)
            {
                log.RequestType = context.RouteData.Values["action"].ToString() + " " + context.RouteData.Values["controller"].ToString();
                log.RequestStatus = "Successfull";
                log.ExceptionDetails = "Null";
                obj.AddLog(log);
            }
            else
            {
                log.RequestType = context.RouteData.Values["action"].ToString() + " " + context.RouteData.Values["controller"].ToString();
                log.RequestStatus = "Failure";
                log.ExceptionDetails = context.Exception.Message;
                obj.AddLog(log);
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
           log.RequestType = context.RouteData.Values["action"].ToString() + " " + context.RouteData.Values["controller"].ToString();
           log.RequestStatus = "sending request";
           log.ExceptionDetails = "Null";
           obj.AddLog(log);
        }
    }
}
