using System.Diagnostics.CodeAnalysis;

namespace FamilyIslandHelper.Api.Models.Abstract
{
	public abstract class ResourceItem : Item
	{
		public abstract int EnergyCost { get; }

		[ExcludeFromCodeCoverage]
		public override string ToString()
		{
			return ToString(1);
		}

		public override string ToString(int itemCount)
		{
			return $"{Name}({EnergyCost * itemCount} энергии)";
		}
	}

	public abstract class ZeroCostResourceItem : ResourceItem
	{
		public override int EnergyCost => 0;

		[ExcludeFromCodeCoverage]
		public override string ToString() => Name;

		public override string ToString(int itemCount)
		{
			return Name;
		}
	}
}
