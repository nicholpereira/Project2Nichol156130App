using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LayeredApplication.Startup))]
namespace LayeredApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
