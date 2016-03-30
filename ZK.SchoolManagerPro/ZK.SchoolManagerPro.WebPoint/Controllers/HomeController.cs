using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZK.SchoolManagerPro.Bll;
using ZK.SchoolManagerPro.Model;

namespace ZK.SchoolManagerPro.WebPoint.Controllers
{
    public class HomeController : Controller
    {

        UserBll urBll = new UserBll();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ContentResult AddUser(User userModel)
        {
            return Content(urBll.AddUser(userModel).ToString());
        }

    }
}