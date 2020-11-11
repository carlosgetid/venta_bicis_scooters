using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Venta_Bicis_Scooters_2.Startup))]
namespace Venta_Bicis_Scooters_2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
