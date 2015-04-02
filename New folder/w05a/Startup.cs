using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(w05a.Startup))]
namespace w05a
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
