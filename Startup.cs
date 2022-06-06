using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GAMECRUD.Startup))]
namespace GAMECRUD
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
