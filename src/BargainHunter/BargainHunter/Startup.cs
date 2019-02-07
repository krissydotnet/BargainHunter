using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BargainHunter.Startup))]
namespace BargainHunter
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
