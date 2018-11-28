using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Orchestrate.WebMVC.Startup))]
namespace Orchestrate.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
