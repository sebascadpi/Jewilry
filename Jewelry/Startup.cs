using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Jewelry.Startup))]
namespace Jewelry
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
