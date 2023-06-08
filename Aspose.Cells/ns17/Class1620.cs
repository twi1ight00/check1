using System.Collections;
using System.Runtime.CompilerServices;
using Aspose.Cells;
using ns16;
using ns2;
using ns25;

namespace ns17;

internal class Class1620
{
	private float float_0;

	private bool bool_0 = true;

	private bool bool_1;

	private bool bool_2;

	private Style style_0;

	internal Hashtable hashtable_0;

	private Border border_0;

	private Border border_1;

	public Border border_2;

	public Border border_3;

	private Class1544 class1544_0;

	private int int_0;

	private bool bool_3;

	private TextAlignmentType textAlignmentType_0;

	private TextAlignmentType textAlignmentType_1;

	private Cell cell_0;

	private CellValueType cellValueType_0;

	private string string_0;

	private int int_1;

	private int int_2;

	private int int_3;

	private int int_4;

	private bool bool_4;

	private Struct88 struct88_0;

	private Hyperlink hyperlink_0;

	private string string_1;

	internal string string_2 = "";

	private ArrayList arrayList_0;

	private int int_5;

	internal int int_6 = 1;

	public Border LeftBorder
	{
		set
		{
			border_0 = value;
		}
	}

	public Border RightBorder
	{
		set
		{
			border_1 = value;
		}
	}

	public Cell Cell => cell_0;

	public bool IsMerged => bool_4;

	public Hyperlink Hyperlink => hyperlink_0;

	[SpecialName]
	public bool method_0()
	{
		return bool_0;
	}

	[SpecialName]
	public void method_1(bool bool_5)
	{
		bool_0 = bool_5;
	}

	[SpecialName]
	public float method_2()
	{
		return float_0;
	}

	[SpecialName]
	public void method_3(float float_1)
	{
		float_0 = float_1;
	}

	[SpecialName]
	internal bool method_4()
	{
		return bool_1;
	}

	[SpecialName]
	internal void method_5(bool bool_5)
	{
		bool_1 = bool_5;
	}

	[SpecialName]
	internal void method_6(bool bool_5)
	{
		bool_2 = bool_5;
	}

	[SpecialName]
	public Style method_7()
	{
		return style_0;
	}

	[SpecialName]
	public void method_8(Style style_1)
	{
		style_0 = style_1;
	}

	[SpecialName]
	internal Class1544 method_9()
	{
		return class1544_0;
	}

	[SpecialName]
	internal void method_10(Class1544 class1544_1)
	{
		class1544_0 = class1544_1;
	}

	[SpecialName]
	public int method_11()
	{
		return int_0;
	}

	[SpecialName]
	public void method_12(int int_7)
	{
		int_0 = int_7;
	}

	[SpecialName]
	public bool method_13()
	{
		return bool_3;
	}

	[SpecialName]
	public void method_14(bool bool_5)
	{
		bool_3 = bool_5;
	}

	[SpecialName]
	public TextAlignmentType method_15()
	{
		return textAlignmentType_0;
	}

	[SpecialName]
	public void method_16(TextAlignmentType textAlignmentType_2)
	{
		textAlignmentType_0 = textAlignmentType_2;
	}

	[SpecialName]
	public TextAlignmentType method_17()
	{
		return textAlignmentType_1;
	}

	[SpecialName]
	public void method_18(Cell cell_1)
	{
		cell_0 = cell_1;
	}

	[SpecialName]
	public CellValueType method_19()
	{
		return cellValueType_0;
	}

	[SpecialName]
	public void method_20(CellValueType cellValueType_1)
	{
		cellValueType_0 = cellValueType_1;
	}

	[SpecialName]
	public string method_21()
	{
		return string_0;
	}

	[SpecialName]
	public void method_22(string string_3)
	{
		string_0 = string_3;
	}

	[SpecialName]
	public int method_23()
	{
		return int_1;
	}

	[SpecialName]
	public int method_24()
	{
		return int_2;
	}

	[SpecialName]
	public int method_25()
	{
		return int_3;
	}

	[SpecialName]
	public void method_26(int int_7)
	{
		int_3 = int_7;
	}

	[SpecialName]
	public int method_27()
	{
		return int_4;
	}

	[SpecialName]
	public void method_28(int int_7)
	{
		int_4 = int_7;
	}

	[SpecialName]
	public void method_29(bool bool_5)
	{
		bool_4 = bool_5;
	}

	[SpecialName]
	public Struct88 method_30()
	{
		return struct88_0;
	}

	[SpecialName]
	public void method_31(Struct88 struct88_1)
	{
		struct88_0 = struct88_1;
	}

	[SpecialName]
	public void method_32(Hyperlink hyperlink_1)
	{
		hyperlink_0 = hyperlink_1;
	}

	[SpecialName]
	internal string method_33()
	{
		return string_1;
	}

	[SpecialName]
	internal void method_34(string string_3)
	{
		string_1 = string_3;
	}

	internal Class1620(int int_7, int int_8)
	{
		int_1 = int_7;
		int_2 = int_8;
		int_3 = 1;
		int_4 = 1;
		int_0 = -1;
	}

	internal Class1620()
	{
		int_3 = 1;
		int_4 = 1;
		int_0 = -1;
	}

	[SpecialName]
	internal bool method_35()
	{
		if (Cell != null && Cell.method_20() != Enum199.const_7)
		{
			return true;
		}
		return false;
	}

	[SpecialName]
	internal ArrayList method_36()
	{
		return arrayList_0;
	}

	[SpecialName]
	internal void method_37(ArrayList arrayList_1)
	{
		arrayList_0 = arrayList_1;
	}

	[SpecialName]
	internal int method_38()
	{
		return int_5;
	}

	[SpecialName]
	internal void method_39(int int_7)
	{
		int_5 = int_7;
	}

	internal double method_40(Worksheet worksheet_0, int int_7, int int_8, int int_9)
	{
		_ = worksheet_0.Cells.Rows;
		double num = 0.0;
		int num2 = int_7;
		while (true)
		{
			if (num2 < int_7 + int_9)
			{
				Class1677.smethod_24(num2);
				if (num2 > int_8)
				{
					break;
				}
				num += worksheet_0.Cells.GetRowHeight(num2);
				num2++;
				continue;
			}
			return num;
		}
		return num;
	}

	internal int method_41(Worksheet worksheet_0, int int_7, int int_8, int int_9)
	{
		_ = worksheet_0.Cells.Rows;
		int num = 0;
		int num2 = int_7;
		while (true)
		{
			if (num2 < int_7 + int_9)
			{
				Class1677.smethod_24(num2);
				if (num2 > int_8)
				{
					break;
				}
				num += worksheet_0.Cells.GetRowHeightPixel(num2);
				num2++;
				continue;
			}
			return num;
		}
		return num;
	}

	internal double method_42(Cells cells_0)
	{
		double num = cells_0.GetColumnWidthInch(method_24()) * 72.0;
		int num2 = 1;
		int num3 = method_24() + 1;
		while (true)
		{
			if (num2 < method_27())
			{
				if (num3 > cells_0.method_22(0))
				{
					break;
				}
				if (cells_0.GetColumnWidthInch(num3) == 0.0)
				{
					num2--;
				}
				else
				{
					num += cells_0.GetColumnWidthInch(num3) * 72.0;
				}
				num2++;
				num3++;
				continue;
			}
			return num;
		}
		return num;
	}

	internal int method_43(Cells cells_0)
	{
		int num = method_24();
		if (int_6 < 0)
		{
			num = method_24() - (method_27() - 1);
			if (num < 0)
			{
				num = 0;
			}
		}
		int num2 = 0;
		if (int_6 > 0)
		{
			int num3 = 0;
			for (int i = num; i < method_24() + method_27() + num3 && i <= 16383; i++)
			{
				if (cells_0.GetColumnWidthPixel(i) == 0)
				{
					num3++;
				}
				num2 += cells_0.GetColumnWidthPixel(i);
			}
		}
		else
		{
			for (int j = num; j <= method_24() && j <= 16383; j++)
			{
				num2 += cells_0.GetColumnWidthPixel(j);
			}
		}
		return num2;
	}
}
