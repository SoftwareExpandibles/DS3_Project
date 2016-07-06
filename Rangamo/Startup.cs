using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Rangamo.Startup))]
namespace Rangamo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
