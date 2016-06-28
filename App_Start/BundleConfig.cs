using System.Web;
using System.Web.Optimization;

namespace WhatsUp
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.IgnoreList.Clear();

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/scripts/jquery-{version}.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrapjs").Include("~/scripts/bootstrap.min.js"));

            bundles.Add(new StyleBundle("~/Content/bootstrapcss").Include("~/Content/bootstrap.css"));

            bundles.Add(new StyleBundle("~/Content/stylecss").Include("~/Content/style.css"));
        }
    }
}