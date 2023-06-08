using System.Runtime.CompilerServices;
using Aspose.Cells;
using Aspose.Cells.Drawing;
using ns2;
using ns7;

namespace ns21;

internal class Class1291
{
	private Class1288 class1288_0;

	internal CellsColor cellsColor_0;

	internal Class923 class923_0;

	internal int int_0;

	internal RectangleAlignmentType rectangleAlignmentType_0;

	internal int int_1;

	internal int int_2;

	internal int int_3;

	internal int int_4;

	internal bool bool_0 = true;

	internal int int_5 = 100000;

	internal int int_6 = 100000;

	internal Class923 Properties
	{
		get
		{
			if (class923_0 == null)
			{
				class923_0 = new Class923();
			}
			return class923_0;
		}
	}

	internal double Direction
	{
		get
		{
			return (double)int_1 / (double)Class1391.int_0;
		}
		set
		{
			int_1 = (int)(value * (double)Class1391.int_0);
		}
	}

	internal double Distance
	{
		get
		{
			return (double)int_2 / Class1391.double_0;
		}
		set
		{
			int_2 = (int)(value * Class1391.double_0);
		}
	}

	internal Class1291(Class1288 class1288_1)
	{
		class1288_0 = class1288_1;
	}

	internal void Copy(Class1291 class1291_0)
	{
		if (class1291_0.cellsColor_0 != null)
		{
			cellsColor_0 = new CellsColor(class1288_0.Workbook);
			cellsColor_0.internalColor_0.method_19(class1291_0.cellsColor_0.internalColor_0);
		}
		else
		{
			cellsColor_0 = null;
		}
		int_0 = class1291_0.int_0;
		int_5 = class1291_0.int_5;
		int_3 = class1291_0.int_3;
		rectangleAlignmentType_0 = class1291_0.rectangleAlignmentType_0;
		int_1 = class1291_0.int_1;
		int_2 = class1291_0.int_2;
		int_6 = class1291_0.int_6;
		int_4 = class1291_0.int_4;
		bool_0 = class1291_0.bool_0;
		if (class1291_0.class923_0 != null)
		{
			class923_0 = new Class923();
			class923_0.Copy(class1291_0.class923_0);
		}
		else
		{
			class923_0 = null;
		}
	}

	internal CellsColor method_0()
	{
		return cellsColor_0;
	}

	internal void method_1(CellsColor cellsColor_1)
	{
		cellsColor_0 = cellsColor_1;
	}

	[SpecialName]
	internal int method_2()
	{
		object obj = Properties.method_1(Enum230.const_10);
		if (obj != null)
		{
			return (int)obj;
		}
		return 100;
	}

	[SpecialName]
	internal void method_3(int int_7)
	{
		Class1691 @class = Properties.method_2(Enum230.const_10);
		if (@class == null)
		{
			Properties.method_0(Enum230.const_10, int_7);
		}
		else
		{
			@class.object_0 = int_7;
		}
	}

	[SpecialName]
	internal double method_4()
	{
		return (double)int_0 / Class1391.double_0;
	}

	[SpecialName]
	internal void method_5(double double_0)
	{
		int_0 = (int)(double_0 * Class1391.double_0);
	}

	[SpecialName]
	internal RectangleAlignmentType method_6()
	{
		return rectangleAlignmentType_0;
	}

	[SpecialName]
	internal void method_7(RectangleAlignmentType rectangleAlignmentType_1)
	{
		rectangleAlignmentType_0 = rectangleAlignmentType_1;
	}

	[SpecialName]
	internal int method_8()
	{
		return int_3;
	}

	[SpecialName]
	internal void method_9(int int_7)
	{
		int_3 = int_7;
	}

	[SpecialName]
	internal int method_10()
	{
		return int_4;
	}

	[SpecialName]
	internal void method_11(int int_7)
	{
		int_4 = int_7;
	}

	[SpecialName]
	internal bool method_12()
	{
		return bool_0;
	}

	[SpecialName]
	internal int method_13()
	{
		return int_5;
	}

	[SpecialName]
	internal void method_14(int int_7)
	{
		int_5 = int_7;
	}

	[SpecialName]
	internal int method_15()
	{
		return int_6;
	}

	[SpecialName]
	internal void method_16(int int_7)
	{
		int_6 = int_7;
	}
}
