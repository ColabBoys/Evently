using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Evently.Startup))]
namespace Evently
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
