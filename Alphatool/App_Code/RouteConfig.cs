using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;

namespace Alphatool
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.EnableFriendlyUrls();
        }
    }
}