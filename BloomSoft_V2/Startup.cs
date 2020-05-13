using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BloomSoft_V2.Startup))]
namespace BloomSoft_V2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
