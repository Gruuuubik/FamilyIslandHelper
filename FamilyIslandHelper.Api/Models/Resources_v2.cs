using FamilyIslandHelper.Api.Models.Abstract;
using System.Diagnostics.CodeAnalysis;

namespace FamilyIslandHelper.Api.Models.Resources_v2
{
	[ExcludeFromCodeCoverage]
	public class Clay : ResourceItem
	{
		public override string Name => "Глина";

		public override int EnergyCost => 5;
	}

	[ExcludeFromCodeCoverage]
	public class Wood : ResourceItem
	{
		public override string Name => "Дерево";

		public override int EnergyCost => 4;
	}

	[ExcludeFromCodeCoverage]
	public class Stick : ResourceItem
	{
		public override string Name => "Палка";

		public override int EnergyCost => 11;
	}

	[ExcludeFromCodeCoverage]
	public class Stone : ResourceItem
	{
		public override string Name => "Камень";

		public override int EnergyCost => 10;
	}

	[ExcludeFromCodeCoverage]
	public class Grass : ResourceItem
	{
		public override string Name => "Трава";

		public override int EnergyCost => 2;
	}

	[ExcludeFromCodeCoverage]
	public class Skin : ZeroCostResourceItem
	{
		public override string Name => "Шкура";
	}

	[ExcludeFromCodeCoverage]
	public class Cotton : ZeroCostResourceItem
	{
		public override string Name => "Хлопок";
	}

	[ExcludeFromCodeCoverage]
	public class Potherb : ZeroCostResourceItem
	{
		public override string Name => "Коренья";
	}

	[ExcludeFromCodeCoverage]
	public class Corn : ZeroCostResourceItem
	{
		public override string Name => "Кукуруза";
	}

	[ExcludeFromCodeCoverage]
	public class Egg : ZeroCostResourceItem
	{
		public override string Name => "Яйцо";
	}

	[ExcludeFromCodeCoverage]
	public class Milk : ZeroCostResourceItem
	{
		public override string Name => "Молоко";
	}

	[ExcludeFromCodeCoverage]
	public class Wheat : ZeroCostResourceItem
	{
		public override string Name => "Пшеница";
	}

	[ExcludeFromCodeCoverage]
	public class Tomato : ZeroCostResourceItem
	{
		public override string Name => "Томат";
	}

	[ExcludeFromCodeCoverage]
	public class Feather : ZeroCostResourceItem
	{
		public override string Name => "Перо";
	}

	[ExcludeFromCodeCoverage]
	public class Iron : ResourceItem
	{
		public override string Name => "Железо";

		//165 energy for 7
		public override int EnergyCost => 24;
	}
}
