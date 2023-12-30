using System.Diagnostics.CodeAnalysis;

namespace FamilyIslandHelper.Api.Models.Abstract
{
	public abstract class Item
	{
		public abstract string Name { get; }

		[ExcludeFromCodeCoverage]
		public override string ToString() => Name;

		[ExcludeFromCodeCoverage]
		public virtual string ToString(int itemCount) => Name;
	}
}
