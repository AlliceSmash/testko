using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TestKo.Startup))]
namespace TestKo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
