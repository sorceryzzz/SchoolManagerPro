using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ZK.SchoolManagerPro.WebPoint.Startup))]
namespace ZK.SchoolManagerPro.WebPoint
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
