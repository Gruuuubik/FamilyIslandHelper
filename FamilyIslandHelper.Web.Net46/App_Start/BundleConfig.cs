using FamilyIslandHelper.Web.Net46.Core;
using System.Web.Optimization;

namespace FamilyIslandHelper.Web.Net46
{
	public class BundleConfig
	{
		// For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
		public static void RegisterBundles(BundleCollection bundles)
		{
			Guard.ForNull(bundles, nameof(bundles));

			bundles.Add(new StyleBundle("~/Content/css").Include(
					  "~/Content/bootstrap.css",
					  "~/Content/Site.css"));
		}
	}
}
