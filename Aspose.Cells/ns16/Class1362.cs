using Aspose.Cells;
using Aspose.Cells.Drawing;
using ns2;

namespace ns16;

internal class Class1362
{
	internal string string_0;

	internal int int_0;

	internal int int_1;

	internal int int_2;

	internal int int_3;

	internal int int_4;

	internal int int_5;

	internal int int_6;

	internal int int_7;

	internal double double_0;

	internal double double_1;

	internal double double_2;

	internal double double_3;

	internal int int_8;

	internal int int_9;

	internal int int_10;

	internal int int_11;

	internal int int_12;

	internal int int_13;

	internal string string_1;

	internal bool bool_0;

	internal bool bool_1;

	internal string string_2;

	internal string string_3;

	internal string string_4;

	internal string string_5;

	internal string string_6;

	private MsoDrawingType msoDrawingType_0 = MsoDrawingType.CellsDrawing;

	internal Enum186 enum186_0 = Enum186.const_187;

	internal AutoShapeType autoShapeType_0 = AutoShapeType.Unknown;

	internal Shape shape_0;

	internal MsoDrawingType Type
	{
		get
		{
			if (shape_0 == null)
			{
				return msoDrawingType_0;
			}
			return shape_0.MsoDrawingType;
		}
		set
		{
			msoDrawingType_0 = value;
		}
	}

	internal AutoShapeType AutoShapeType
	{
		get
		{
			if (autoShapeType_0 == AutoShapeType.Unknown)
			{
				autoShapeType_0 = Class1618.smethod_232(enum186_0);
			}
			return autoShapeType_0;
		}
		set
		{
			autoShapeType_0 = value;
		}
	}

	internal void method_0()
	{
		if (string_2 == "absoluteAnchor")
		{
			if (shape_0 != null && shape_0 is ChartShape && shape_0.method_26().Type == SheetType.Chart)
			{
				shape_0.Width = int_8;
				shape_0.Height = int_9;
			}
			else
			{
				shape_0.method_17(int_10, int_11, int_8, int_9);
			}
		}
		else if (string_2 == "oneCellAnchor")
		{
			shape_0.method_20(int_2, int_3, int_0, int_1, int_9, int_8);
		}
		else if (string_2 == "freeFloating")
		{
			if (bool_1)
			{
				shape_0.method_17(int_10, int_11, int_12, int_13);
			}
			else
			{
				int num = shape_0.method_25().method_75();
				shape_0.method_17(Class1618.smethod_48(int_10, num), Class1618.smethod_48(int_11, num), Class1618.smethod_48(int_12, num), Class1618.smethod_48(int_13, num));
			}
		}
		else if (string_2 == "relSizeAnchor")
		{
			if (shape_0.method_30())
			{
				shape_0.method_16((int)(double_0 * 4000.0), (int)(double_1 * 4000.0), (int)((double_2 - double_0) * 4000.0), (int)((double_3 - double_1) * 4000.0));
			}
			else
			{
				shape_0.method_17((int)(double_0 * 4000.0), (int)(double_1 * 4000.0), (int)((double_2 - double_0) * 4000.0), (int)((double_3 - double_1) * 4000.0));
			}
		}
		else
		{
			shape_0.method_22(int_2, int_3, int_0, int_1, int_6, int_7, int_4, int_5);
		}
		if (string_0 != null && string_0.Length != 0)
		{
			shape_0.Placement = Class1618.smethod_53(string_0);
		}
	}
}
