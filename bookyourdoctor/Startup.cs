using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(bookyourdoctor.Startup))]
namespace bookyourdoctor
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
