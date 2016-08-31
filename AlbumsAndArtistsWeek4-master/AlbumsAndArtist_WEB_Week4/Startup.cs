using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AlbumsAndArtist_WEB_Week4.Startup))]
namespace AlbumsAndArtist_WEB_Week4
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
