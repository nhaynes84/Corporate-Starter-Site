using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(XYZCorpTempSite.Startup))]
namespace XYZCorpTempSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
