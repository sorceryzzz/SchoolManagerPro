using System.Web;
using System.Web.Mvc;

namespace ZK.SchoolManagerPro.WebPoint
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
