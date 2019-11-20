using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ASP_Test.Startup))]
namespace ASP_Test
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
