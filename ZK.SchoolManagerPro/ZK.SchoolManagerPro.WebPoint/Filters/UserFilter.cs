using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZK.SchoolManagerPro.Bll;
using ZK.SchoolManagerPro.Model;

namespace ZK.SchoolManagerPro.WebPoint.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class UserFilter : AuthorizeAttribute
    {
        StudentBll bll = new StudentBll();
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            Students model = filterContext.HttpContext.Session["CurrentLoginUser"] as Students;
            var Url = new UrlHelper(filterContext.RequestContext);
            var url = Url.Action("Login", "Students");
            if (model == null)
            {
                if (filterContext.HttpContext.Request.Cookies["ZKAccount"] == null)
                {
                    filterContext.Result = new RedirectResult(url);
                }
                else
                {
                    string cookieAccount = filterContext.HttpContext.Request.Cookies["ZKAccount"].Value;
                    Students student = bll.GetModelByUserNum(cookieAccount);
                    if (student != null)
                    {
                        filterContext.HttpContext.Session["CurrentLoginUser"] = student;
                    }
                    else
                    {
                        filterContext.Result = new RedirectResult(url);
                    }
                }
            }
        }
    }
}