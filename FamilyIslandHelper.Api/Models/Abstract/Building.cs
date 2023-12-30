using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace FamilyIslandHelper.Api.Models.Abstract
{
	public abstract class Building
	{
		public abstract string Name { get; }
		public abstract double ProduceRatio { get; }
		public abstract List<ProducibleItem> Items { get; }

		[ExcludeFromCodeCoverage]
		public override string ToString() => Name;
	}
}
