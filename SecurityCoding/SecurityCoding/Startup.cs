using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SecurityCoding.Startup))]
namespace SecurityCoding
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
