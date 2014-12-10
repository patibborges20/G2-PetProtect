using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(G2_PetProtect.Startup))]
namespace G2_PetProtect
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
