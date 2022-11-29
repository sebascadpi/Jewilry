using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Jewilry.Startup))]
namespace Jewilry
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
