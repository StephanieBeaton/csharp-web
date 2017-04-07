using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyFullMVC.Startup))]
namespace MyFullMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
