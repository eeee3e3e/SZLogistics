using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SZLogistics.Startup))]
namespace SZLogistics
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
