namespace FamilyIslandHelper.Models
{
	public class Clay : ResourceItem
	{
		public override string Name => "Глина";

		public override int EnergyCost => 5;
	}

	public class Cone : ResourceItem
	{
		public override string Name => "Шишка";

		public override int EnergyCost => 15;
	}

	public class Wood : ResourceItem
	{
		public override string Name => "Дерево";

		public override int EnergyCost => 4;
	}

	public class Stick : ResourceItem
	{
		public override string Name => "Палка";

		public override int EnergyCost => 11;
	}

	public class GoldOre : ResourceItem
	{
		public override string Name => "Золотая руда";

		public override int EnergyCost => 9;
	}

	public class Stone : ResourceItem
	{
		public override string Name => "Камень";

		public override int EnergyCost => 10;
	}

	public class PalmLeaf : ResourceItem
	{
		public override string Name => "Пальмовый листок";

		public override int EnergyCost => 14;
	}

	public class PalmLog : ResourceItem
	{
		public override string Name => "Пальмовое бревно";

		public override int EnergyCost => 12;
	}

	public class Grass : ResourceItem
	{
		public override string Name => "Трава";

		public override int EnergyCost => 2;
	}

	public class Skin : ZeroCostResourceItem
	{
		public override string Name => "Шкура";
	}

	public class Cotton : ZeroCostResourceItem
	{
		public override string Name => "Хлопок";
	}

	public class Claw : ZeroCostResourceItem
	{
		public override string Name => "Коготь";
	}

	public class Ash : ZeroCostResourceItem
	{
		public override string Name => "Пепел";
	}

	public class Poison : ResourceItem
	{
		public override string Name => "Яд";

		//35
		public override int EnergyCost => 0;
	}

	public class Emerald : ZeroCostResourceItem
	{
		public override string Name => "Изумруд";
	}

	public class Corn : ZeroCostResourceItem
	{
		public override string Name => "Кукуруза";
	}

	public class Clover : ResourceItem
	{
		public override string Name => "Клевер";

		public override int EnergyCost => 2;
	}

	public class Shell : ZeroCostResourceItem
	{
		public override string Name => "Ракушка";
	}

	public class CopperOre : ResourceItem
	{
		public override string Name => "Медная руда";

		public override int EnergyCost => 8;
	}

	public class Egg : ZeroCostResourceItem
	{
		public override string Name => "Яйцо";
	}

	public class Milk : ZeroCostResourceItem
	{
		public override string Name => "Молоко";
	}

	public class Salt : ZeroCostResourceItem
	{
		public override string Name => "Соль";
	}

	public class BlueOre : ResourceItem
	{
		public override string Name => "Синяя руда";

		public override int EnergyCost => 24;
	}

	public class Wheat : ZeroCostResourceItem
	{
		public override string Name => "Пшеница";
	}

	public class Amber : ZeroCostResourceItem
	{
		public override string Name => "Янтарь";
	}
}
