namespace FamilyIslandHelper.Models.Abstract
{
	public abstract class Item
	{
		public abstract string Name { get; }

		public override string ToString() => Name;
	}
}
