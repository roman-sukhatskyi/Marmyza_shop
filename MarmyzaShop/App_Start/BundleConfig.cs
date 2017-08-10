using System.Web;
using System.Web.Optimization;

namespace MarmyzaShop
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/plugins/angular/angular.min.js",
                      "~/Scripts/plugins/bootstrap/bootstrap.min.js",
                      "~/Scripts/plugins/countdown/jquery.countdown.min.js",
                      "~/Scripts/plugins/jquery/jquery-2.2.4.min.js",
                      "~/Scripts/plugins/owlcarousel/owl.carousel.min.js",
                      "~/Scripts/plugins/singlepagenav/jquery.singlePageNav.min.js",
                      "~/Scripts/plugins/waitforimages/jquery.waitforimages.min.js",
                      "~/Scripts/plugins/waypoints/jquery.waypoints.min.js",
                      "~/Scripts/files/",

                      "~/js/app.js",
                      "~/js/custom.js",
                      "~/js/hero-slider.js",
                      "~/js/project-slider.js"
                ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/anima.css",
                      "~/Content/owl.carousel.css",
                      "~/Content/css/icons.css",
                      "~/Content/css/style.css",
                      "~/Content/css/sliders.css",
                      "~/Content/css/hero-slider.css",
                      "~/Content/css/project-slider.css",

                      "~/Content/login-window/login-window.css",
                      "~/Content/login-window/font-awesome.min.css",
                      "~/Content/font-awesome-4.7.0/css/font-awesome.min.css"
                ));
        }
    }
}
