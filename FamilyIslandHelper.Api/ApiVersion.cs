using System.ComponentModel;

namespace FamilyIslandHelper.Api
{
	public enum ApiVersion
	{
		[Description("API before update 10.2024")]
		v1,
		[Description("API after update 10.2024")]
		v2
	}
}
