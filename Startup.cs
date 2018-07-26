using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BasketballMVC.Startup))]
namespace BasketballMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
