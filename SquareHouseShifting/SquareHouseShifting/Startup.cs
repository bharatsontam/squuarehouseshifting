using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SquareHouseShifting.Startup))]
namespace SquareHouseShifting
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
