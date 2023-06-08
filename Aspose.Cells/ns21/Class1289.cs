using System.Runtime.CompilerServices;
using Aspose.Cells;
using ns2;
using ns7;

namespace ns21;

internal class Class1289
{
	private Class1288 class1288_0;

	private CellsColor cellsColor_0;

	private Class923 class923_0;

	internal int int_0;

	internal int int_1;

	internal int int_2;

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

	internal Class1289(Class1288 class1288_1)
	{
		class1288_0 = class1288_1;
	}

	internal CellsColor GetColor()
	{
		return cellsColor_0;
	}

	internal void SetColor(CellsColor cellsColor_1)
	{
		cellsColor_0 = cellsColor_1;
	}

	[SpecialName]
	internal int method_0()
	{
		object obj = Properties.method_1(Enum230.const_10);
		if (obj != null)
		{
			return (int)obj / 1000;
		}
		return 100;
	}

	[SpecialName]
	internal int method_1()
	{
		object obj = Properties.method_1(Enum230.const_10);
		if (obj != null)
		{
			return (int)obj;
		}
		return 100;
	}

	[SpecialName]
	internal void method_2(int int_3)
	{
		Class1691 @class = Properties.method_2(Enum230.const_10);
		if (@class == null)
		{
			Properties.method_0(Enum230.const_10, int_3);
		}
		else
		{
			@class.object_0 = int_3;
		}
	}

	[SpecialName]
	internal double method_3()
	{
		return (double)int_0 / Class1391.double_0;
	}

	[SpecialName]
	internal void method_4(double double_0)
	{
		int_0 = (int)(double_0 * Class1391.double_0);
	}

	internal void Copy(Class1289 class1289_0)
	{
		if (class1289_0.cellsColor_0 != null)
		{
			cellsColor_0 = new CellsColor(class1288_0.Workbook);
			cellsColor_0.internalColor_0.method_19(class1289_0.cellsColor_0.internalColor_0);
		}
		else
		{
			cellsColor_0 = null;
		}
		int_0 = class1289_0.int_0;
		int_1 = class1289_0.int_1;
		int_2 = class1289_0.int_2;
		if (class1289_0.class923_0 != null)
		{
			class923_0 = new Class923();
			class923_0.Copy(class1289_0.class923_0);
		}
		else
		{
			class923_0 = null;
		}
	}
}
