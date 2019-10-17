using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(strataGEM.Startup))]
namespace strataGEM
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
