using System.Runtime.CompilerServices;
using Aspose.Cells.Drawing;

namespace ns52;

internal class Class1698
{
	internal static float float_0 = 1024f;

	internal static float float_1 = 256f;

	private Class1714 class1714_0;

	private PlacementType placementType_0;

	internal PlacementType placementType_1;

	private int int_0;

	private int int_1;

	private int int_2;

	private int int_3;

	private int int_4;

	private int int_5;

	private int int_6;

	private int int_7;

	private bool bool_0;

	public int Length
	{
		get
		{
			int num = 26;
			if (method_2())
			{
				num -= 2;
			}
			return num;
		}
	}

	public int Top
	{
		get
		{
			return int_1;
		}
		set
		{
			int_1 = value;
		}
	}

	public int Left
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
		}
	}

	public int Bottom
	{
		get
		{
			return int_2;
		}
		set
		{
			int_2 = value;
		}
	}

	public int Right
	{
		get
		{
			return int_3;
		}
		set
		{
			int_3 = value;
		}
	}

	internal Class1698(Class1714 class1714_1)
	{
		class1714_0 = class1714_1;
		placementType_0 = PlacementType.MoveAndSize;
	}

	public void Copy(Class1698 class1698_0)
	{
		placementType_0 = class1698_0.placementType_0;
		bool_0 = class1698_0.bool_0;
		int_0 = class1698_0.int_0;
		int_1 = class1698_0.int_1;
		int_3 = class1698_0.int_3;
		int_2 = class1698_0.int_2;
		int_4 = class1698_0.int_4;
		int_5 = class1698_0.int_5;
		int_6 = class1698_0.int_6;
		int_7 = class1698_0.int_7;
	}

	[SpecialName]
	public bool method_0()
	{
		return bool_0;
	}

	[SpecialName]
	public void method_1(bool bool_1)
	{
		bool_0 = true;
	}

	[SpecialName]
	public bool method_2()
	{
		return class1714_0.method_0().method_33();
	}

	[SpecialName]
	public PlacementType method_3()
	{
		return placementType_0;
	}

	[SpecialName]
	public void method_4(PlacementType placementType_2)
	{
		if (placementType_0 != placementType_2)
		{
			placementType_0 = placementType_2;
		}
	}

	[SpecialName]
	public int method_5()
	{
		return int_6;
	}

	[SpecialName]
	public void method_6(int int_8)
	{
		int_6 = int_8;
	}

	[SpecialName]
	public int method_7()
	{
		return int_4;
	}

	[SpecialName]
	public void method_8(int int_8)
	{
		int_4 = int_8;
	}

	[SpecialName]
	public int method_9()
	{
		return int_7;
	}

	[SpecialName]
	public void method_10(int int_8)
	{
		int_7 = int_8;
	}

	[SpecialName]
	public int method_11()
	{
		return int_5;
	}

	[SpecialName]
	public void method_12(int int_8)
	{
		int_5 = int_8;
	}
}
