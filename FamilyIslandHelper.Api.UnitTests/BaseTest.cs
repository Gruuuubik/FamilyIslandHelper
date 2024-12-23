namespace FamilyIslandHelper.Api.UnitTests
{
	public abstract class BaseTest
	{
#if LINUX
		protected char pathSeparator = '/';
#else
		protected char pathSeparator = '\\';
#endif
	}
}
