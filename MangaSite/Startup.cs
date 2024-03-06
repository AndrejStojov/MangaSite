using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MangaSite.Startup))]
namespace MangaSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
