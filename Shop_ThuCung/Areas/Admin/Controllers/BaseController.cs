using Shop_ThuCung.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Shop_ThuCung.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        // GET: Admin/Base
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var sess = (AdminLogin)Session[CommonConstants.ADMIN_SESSION];
            if (sess == null)
            {
                filterContext.Result= new RedirectToRouteResult(new RouteValueDictionary(new {controller="Login",action="Index",Area="Admin"}));
            }    
            base.OnActionExecuting(filterContext);
        }
    }
}