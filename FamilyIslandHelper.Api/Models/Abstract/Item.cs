namespace FamilyIslandHelper.Api.Models.Abstract
{
	public abstract class Item
	{
		public abstract string Name { get; }

		public override string ToString() => Name;

		public virtual string ToString(int itemCount) => Name;
	}
}
