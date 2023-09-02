using System.Collections.Generic;

namespace FamilyIslandHelper.Api.Models.Abstract
{
	public abstract class Building
	{
		public abstract string Name { get; }
		public abstract double ProduceRatio { get; }
		public abstract List<ProducibleItem> Items { get; }

		public override string ToString() => Name;
	}
}
