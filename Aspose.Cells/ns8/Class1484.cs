using System.Collections;
using System.Runtime.CompilerServices;
using Aspose.Cells;

namespace ns8;

internal class Class1484
{
	internal Cell cell_0;

	internal int int_0;

	internal int int_1 = 1;

	internal int int_2 = 1;

	internal bool bool_0 = true;

	internal int int_3 = -1;

	internal Style style_0;

	internal Hyperlink hyperlink_0;

	internal bool bool_1;

	internal bool bool_2;

	internal bool bool_3;

	internal int int_4 = -1;

	internal ArrayList arrayList_0;

	internal Border border_0;

	internal Border border_1;

	private Class1480 class1480_0;

	private Class1482 class1482_0;

	private int int_5 = -1;

	private double double_0 = -1.0;

	internal string string_0;

	internal Class1484(Class1480 class1480_1)
	{
		class1480_0 = class1480_1;
		class1482_0 = class1480_1.method_4();
	}

	[SpecialName]
	internal bool method_0()
	{
		if (int_0 != 0 && arrayList_0 == null && int_2 <= 1)
		{
			return false;
		}
		return true;
	}

	internal bool method_1()
	{
		if (style_0 == null)
		{
			return true;
		}
		string text = style_0.method_46();
		if (style_0.method_44() <= 0 && (text == null || text.Length == 0))
		{
			return true;
		}
		return false;
	}

	internal bool method_2()
	{
		if (hyperlink_0 == null && string_0 == null)
		{
			return false;
		}
		return true;
	}

	internal double method_3()
	{
		if (double_0 < 0.0)
		{
			double_0 = 0.0;
			int num = class1480_0.method_3() + int_2;
			for (int i = class1480_0.method_3(); i < num; i++)
			{
				double_0 += class1482_0.method_0().Cells.GetRowHeight(i);
			}
		}
		return double_0;
	}

	internal int method_4()
	{
		if (int_5 < 0)
		{
			int_5 = class1482_0.method_23(int_0, int_0 + int_1);
		}
		return int_5;
	}
}
