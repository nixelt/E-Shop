namespace E_Shop
{
    using System.Web.Optimization;

    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/bundles/select2").Include(
                "~/Content/select2.min.css",
                "~/Content/select2-bootstrap4.min.css"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/fontawesome-all.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/adminJs").Include(
                "~/Scripts/admin.js"));
            bundles.Add(new StyleBundle("~/bundles/admin").Include(
                "~/Content/admin.css"));

            bundles.Add(new ScriptBundle("~/bundles/main").Include(
                "~/Scripts/main.js"));
            bundles.Add(new ScriptBundle("~/bundles/cart").Include(
                "~/Scripts/ShoppingCart.js"));

            bundles.Add(new ScriptBundle("~/bundles/select2Js").Include(
                "~/Scripts/select2.js"));

            bundles.Add(new ScriptBundle("~/bundles/delivery").Include(
                "~/Scripts/Delivery.js"));
        }
    }
}
