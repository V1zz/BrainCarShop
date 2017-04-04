using System.Web.Optimization;

namespace BrainCarShop
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundle)
        {
            bundle.Add(new Bundle("~/bundles/css"));
        }
    }
}