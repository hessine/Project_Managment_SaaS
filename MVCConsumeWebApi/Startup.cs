using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCConsumeWebApi.Startup))]
namespace MVCConsumeWebApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
