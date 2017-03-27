using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lodos.Startup))]
namespace Lodos
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
