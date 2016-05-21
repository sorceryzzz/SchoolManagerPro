using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZK.SchoolManagerPro.Bll;
using ZK.SchoolManagerPro.Model;

namespace ZK.SchoolManagerPro.WebPoint.Common
{
    public static class UserHelper
    {
        private static StudentBll bll = new StudentBll();
        public static Students GetUserModel()
        {
            Students model = HttpContext.Current.Session["CurrentLoginUser"] as Students;
            if (model == null)
            {
                string cookieAccount = HttpContext.Current.Request.Cookies["ZKAccount"].Value;
                model = bll.GetModelByUserNum(cookieAccount);
            }
            return model;
        }
    }
}