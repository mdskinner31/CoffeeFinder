using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CoffeeFinder.WebMVC.Startup))]
namespace CoffeeFinder.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
