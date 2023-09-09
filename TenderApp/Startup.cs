using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TenderApp.Startup))]
namespace TenderApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
