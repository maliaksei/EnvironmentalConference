using System.Web;
using System.Web.Optimization;

namespace WebSite
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                         "~/Scripts/jquery-ui.js",
                        "~/Scripts/jquery.inputmask.js"));

            bundles.Add(new ScriptBundle("~/bundles/fileUpload").Include(
                        "~/Scripts/jquery.uploadfile.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/ckeditor").Include(
                        "~/ckeditor/ckeditor.js"));

            bundles.Add(new ScriptBundle("~/bundles/select").Include(
                       "~/Scripts/SelectPicker/bootstrap-select.js"
                       ));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/datetimepicker").Include(
                      "~/Scripts/bootstrap-datetimepicker.js",
                      "~/Scripts/locales/bootstrap-datetimepicker.ru.js"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/jqgrid").Include(
                "~/Scripts/trirand/i18n/grid.locale-ru.js",
                "~/Scripts/trirand/jquery.jqGrid.min.js",
                "~/Scripts/trirand/jquery.jqDatePicker.min.js"
                ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/bootstrap-datetimepicker.css",
                      "~/Content/css/ui.jqgrid.css",
                      "~/Content/css/jquery-ui.css",
                      "~/Content/css/jqGrid.bootstrap.css",
                      "~/Content/SelectPicker/bootstrap-select.css"));
        }
    }
}
