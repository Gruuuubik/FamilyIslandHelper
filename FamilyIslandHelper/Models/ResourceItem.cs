namespace FamilyIslandHelper.Models
{
	public abstract class ResourceItem : Item
	{
		public abstract int EnergyCost { get; }

		public override string ToString()
		{
			return $"{Name}({EnergyCost} энергии)";
		}
	}

	public abstract class ZeroCostResourceItem : ResourceItem
	{
		public override int EnergyCost => 0;

		public override string ToString() => Name;
	}
}
