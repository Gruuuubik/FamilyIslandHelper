using FamilyIslandHelper.Api.Models.Abstract;
using System.Diagnostics.CodeAnalysis;

namespace FamilyIslandHelper.Api.Models
{
	[ExcludeFromCodeCoverage]
	public class Clay : ResourceItem
	{
		public override string Name => "Глина";

		public override int EnergyCost => 5;
	}

	[ExcludeFromCodeCoverage]
	public class Cone : ResourceItem
	{
		public override string Name => "Шишка";

		public override int EnergyCost => 15;
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
	public class GoldOre : ResourceItem
	{
		public override string Name => "Золотая руда";

		public override int EnergyCost => 9;
	}

	[ExcludeFromCodeCoverage]
	public class Stone : ResourceItem
	{
		public override string Name => "Камень";

		public override int EnergyCost => 10;
	}

	[ExcludeFromCodeCoverage]
	public class PalmLeaf : ResourceItem
	{
		public override string Name => "Пальмовый листок";

		public override int EnergyCost => 14;
	}

	[ExcludeFromCodeCoverage]
	public class PalmLog : ResourceItem
	{
		public override string Name => "Пальмовое бревно";

		public override int EnergyCost => 12;
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
	public class Claw : ZeroCostResourceItem
	{
		public override string Name => "Коготь";
	}

	[ExcludeFromCodeCoverage]
	public class Ash : ZeroCostResourceItem
	{
		public override string Name => "Пепел";
	}

	[ExcludeFromCodeCoverage]
	public class Poison : ResourceItem
	{
		public override string Name => "Яд";

		//35
		public override int EnergyCost => 0;
	}

	[ExcludeFromCodeCoverage]
	public class Emerald : ZeroCostResourceItem
	{
		public override string Name => "Изумруд";
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
	public class Clover : ResourceItem
	{
		public override string Name => "Клевер";

		public override int EnergyCost => 2;
	}

	[ExcludeFromCodeCoverage]
	public class Shell : ZeroCostResourceItem
	{
		public override string Name => "Ракушка";
	}

	[ExcludeFromCodeCoverage]
	public class CopperOre : ResourceItem
	{
		public override string Name => "Медная руда";

		public override int EnergyCost => 8;
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
	public class Salt : ZeroCostResourceItem
	{
		public override string Name => "Соль";
	}

	[ExcludeFromCodeCoverage]
	public class BlueOre : ResourceItem
	{
		public override string Name => "Синяя руда";

		public override int EnergyCost => 24;
	}

	[ExcludeFromCodeCoverage]
	public class Wheat : ZeroCostResourceItem
	{
		public override string Name => "Пшеница";
	}

	[ExcludeFromCodeCoverage]
	public class Amber : ZeroCostResourceItem
	{
		public override string Name => "Янтарь";
	}

	[ExcludeFromCodeCoverage]
	public class Sunflower : ZeroCostResourceItem
	{
		public override string Name => "Подсолнечник";
	}

	[ExcludeFromCodeCoverage]
	public class Limestone : ResourceItem
	{
		public override string Name => "Известняк";

		public override int EnergyCost => 8;
	}

	[ExcludeFromCodeCoverage]
	public class Pepper : ZeroCostResourceItem
	{
		public override string Name => "Перец";
	}

	[ExcludeFromCodeCoverage]
	public class Feather : ZeroCostResourceItem
	{
		public override string Name => "Перо";
	}

	[ExcludeFromCodeCoverage]
	public class Heather : ZeroCostResourceItem
	{
		public override string Name => "Вереск";
	}

	[ExcludeFromCodeCoverage]
	public class Carrot : ZeroCostResourceItem
	{
		public override string Name => "Морковь";
	}

	[ExcludeFromCodeCoverage]
	public class Candle : ZeroCostResourceItem
	{
		public override string Name => "Свеча";
	}

	[ExcludeFromCodeCoverage]
	public class Iron : ResourceItem
	{
		public override string Name => "Железо";

		//165 energy for 7
		public override int EnergyCost => 24;
	}

	[ExcludeFromCodeCoverage]
	public class Lazurite : ZeroCostResourceItem
	{
		public override string Name => "Лазурит";
	}

	[ExcludeFromCodeCoverage]
	public class Silverine : ZeroCostResourceItem
	{
		public override string Name => "Сильверин";
	}

	[ExcludeFromCodeCoverage]
	public class Sapphire : ZeroCostResourceItem
	{
		public override string Name => "Сапфир";
	}

	[ExcludeFromCodeCoverage]
	public class Gem : ZeroCostResourceItem
	{
		public override string Name => "Самоцвет";
	}

	[ExcludeFromCodeCoverage]
	public class Amethyst : ZeroCostResourceItem
	{
		public override string Name => "Аметист";
	}

	[ExcludeFromCodeCoverage]
	public class Pearl : ZeroCostResourceItem
	{
		public override string Name => "Жемчужина";
	}
}
