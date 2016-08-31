using System.Web;
using System.Web.Mvc;

namespace AlbumsAndArtist_WEB_Week4
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
