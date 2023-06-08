using Aspose.Cells;
using ns7;

namespace ns21;

internal class Class1292
{
	private Class1288 class1288_0;

	private CellsColor cellsColor_0;

	private Class923 class923_0;

	internal string string_0;

	internal int int_0;

	internal int int_1;

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

	internal Class1292(Class1288 class1288_1)
	{
		class1288_0 = class1288_1;
	}

	internal CellsColor method_0()
	{
		return cellsColor_0;
	}

	internal void method_1(CellsColor cellsColor_1)
	{
		cellsColor_0 = cellsColor_1;
	}

	internal void Copy(Class1292 class1292_0)
	{
		if (class1292_0.cellsColor_0 != null)
		{
			cellsColor_0 = new CellsColor(class1288_0.Workbook);
			cellsColor_0.internalColor_0.method_19(class1292_0.cellsColor_0.internalColor_0);
		}
		int_0 = class1292_0.int_0;
		int_1 = class1292_0.int_1;
		string_0 = class1292_0.string_0;
		if (class1292_0.class923_0 != null)
		{
			class923_0 = new Class923();
			class923_0.Copy(class1292_0.class923_0);
		}
		else
		{
			class923_0 = null;
		}
	}
}
