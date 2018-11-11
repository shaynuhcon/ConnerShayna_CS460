using System.Web.Mvc;
using System.Web.Routing;

namespace HW7
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Custom route for Translate/Translator/{lastWord} method 
            routes.MapRoute(
                name: "Translate",
                url: "Translate/{lastWord}",
                defaults: new { controller = "Translate", action = "Translate" }
            );

            //routes.MapRoute(
            //    name: "Clear",
            //    url: "Translate/",
            //    defaults: new { controller = "Translate", action = "Translator" }
            //);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Translate", action = "Translator", id = UrlParameter.Optional }
            );
        }
    }
}
