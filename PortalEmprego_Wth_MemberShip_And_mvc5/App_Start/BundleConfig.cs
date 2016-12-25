using System.Web;
using System.Web.Optimization;

namespace PortalEmprego_Wth_MemberShip_And_mvc5
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/datepicker").Include(
                      "~/Scripts/bootstrap-datepicker.js"));

            // datapicker
            bundles.Add(new StyleBundle("~/Content/bootstrap/datepicker").Include(
                     "~/Content/datepicker.css", "~/Content/datepicker3.css"));

            // bootstrap
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            // moodle bundle
            bundles.Add(new StyleBundle("~/Content/joomla").Include(
                      "~/Content/joomlacss/hathor/template.css",
                      "~/Content/joomlacss/isis/template.css"));

           

        }
    }
}
