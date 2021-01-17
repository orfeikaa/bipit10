using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Бипит10.Startup))]
namespace Бипит10
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
