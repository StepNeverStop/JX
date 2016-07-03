using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JX.Startup))]
namespace JX
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
