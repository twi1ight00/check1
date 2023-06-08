using Aspose.Cells;
using Aspose.Cells.Charts;
using Aspose.Cells.Drawing;

namespace ns16;

internal class Class1359
{
	internal Shape shape_0;

	internal Enum197 enum197_0;

	internal int int_0;

	internal string string_0;

	internal bool bool_0;

	internal string string_1;

	internal Chart chart_0;

	internal Class1541 class1541_0;

	internal Class1540 class1540_0;

	internal Class1358 class1358_0;

	internal bool bool_1;

	internal Class1359(Class1358 class1358_1, Shape shape_1)
	{
		class1358_0 = class1358_1;
		class1540_0 = class1358_1.class1540_0;
		shape_0 = shape_1;
		if (class1358_1.chart_0 != null)
		{
			chart_0 = class1358_1.chart_0;
			enum197_0 = Enum197.const_2;
		}
		else
		{
			class1541_0 = class1358_1.class1541_0;
			switch (class1358_1.class1541_0.worksheet_0.Type)
			{
			case SheetType.Worksheet:
				enum197_0 = Enum197.const_0;
				if (shape_1.class1556_0 != null && shape_1.class1556_0.string_2 == "oneCellAnchor")
				{
					enum197_0 = Enum197.const_3;
				}
				break;
			case SheetType.Chart:
				enum197_0 = Enum197.const_1;
				break;
			}
		}
		if (shape_1.MsoDrawingType == MsoDrawingType.Picture)
		{
			Picture picture = (Picture)shape_1;
			if (picture.method_74())
			{
				string_0 = (string)class1358_1.hashtable_0[picture.SourceFullName];
				bool_0 = true;
			}
			else
			{
				int num = ((Picture)shape_1).method_70();
				string_0 = (string)class1358_1.hashtable_0[num];
			}
		}
		else if (shape_1.MsoDrawingType == MsoDrawingType.Chart)
		{
			for (int i = 0; i < class1358_1.arrayList_1.Count; i++)
			{
				Class1533 @class = (Class1533)class1358_1.arrayList_1[i];
				if (@class.chart_0.ChartObject == shape_1)
				{
					string_0 = @class.string_0;
				}
			}
		}
		if (shape_1.Hyperlink != null)
		{
			string_1 = (string)class1358_1.hashtable_1[shape_1.Hyperlink];
		}
		int_0 = class1358_1.method_0(shape_1);
	}
}
