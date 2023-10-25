using FamilyIslandHelper.Web.Net46.Core;
using System.Web.Mvc;

namespace FamilyIslandHelper.Web.Net46
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			Guard.ForNull(filters, nameof(filters));

			filters.Add(new HandleErrorAttribute());
		}
	}
}
