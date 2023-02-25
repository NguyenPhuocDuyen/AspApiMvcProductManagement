using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;

namespace eStoreClient
{
    public class SessionCheckAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = filterContext.HttpContext.Session;
            if (!session.TryGetValue("IsLoggedIn", out byte[] value))
            {
                filterContext.Result = new RedirectResult("/Login/Login");
            }
            else if (!BitConverter.ToBoolean(value, 0))
            {
                filterContext.Result = new RedirectResult("/Login/Login");
            }
            base.OnActionExecuting(filterContext);
        }
    }

    public class AdminSessionCheckAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = filterContext.HttpContext.Session;
            if (!session.GetString("role").Contains("Admin"))
            {
                filterContext.Result = new RedirectResult("/Home/Index");
            }
            base.OnActionExecuting(filterContext);
        }
    }
}
