using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Tema5.Startup))]
namespace Tema5
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
