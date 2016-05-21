using System.Web;
using System.Web.Mvc;
using ZK.SchoolManagerPro.WebPoint.Filters;

namespace ZK.SchoolManagerPro.WebPoint
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
           // filters.Add(new UserFilter());
        }
    }
}
