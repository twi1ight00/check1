using System;
using System.Collections;
using System.Runtime.CompilerServices;
using Aspose.Cells.Drawing;

namespace ns8;

internal class Class315
{
	private int int_0;

	private int int_1;

	private double double_0;

	private double double_1;

	private double double_2;

	private double double_3;

	private int int_2;

	private int int_3;

	private Shape shape_0;

	private int int_4;

	internal ArrayList arrayList_0;

	private string string_0;

	public string FileName => string_0;

	internal Class315(Shape shape_1, int int_5, string string_1)
	{
		shape_0 = shape_1;
		int_4 = int_5;
		string_0 = string_1;
		PlacementType placement = shape_1.Placement;
		if (shape_0.MsoDrawingType == MsoDrawingType.Group)
		{
			arrayList_0 = new ArrayList();
		}
		if (!shape_0.method_33())
		{
			switch (placement)
			{
			case PlacementType.FreeFloating:
				double_2 = shape_1.WidthPt;
				double_3 = shape_1.HeightPt;
				shape_1.Placement = PlacementType.MoveAndSize;
				int_0 = shape_1.UpperLeftRow;
				int_1 = shape_1.UpperLeftColumn;
				double_0 = Math.Round((float)shape_1.Top * 72f / (float)shape_1.method_25().method_75(), 2);
				double_1 = Math.Round((float)shape_1.Left * 72f / (float)shape_1.method_25().method_75(), 2);
				int_2 = shape_1.LowerRightRow;
				int_3 = shape_1.LowerRightColumn;
				shape_1.Placement = placement;
				break;
			case PlacementType.Move:
				int_0 = shape_1.UpperLeftRow;
				int_1 = shape_1.UpperLeftColumn;
				double_0 = Math.Round((float)shape_1.Top * 72f / (float)shape_1.method_25().method_75(), 2);
				double_1 = Math.Round((float)shape_1.Left * 72f / (float)shape_1.method_25().method_75(), 2);
				double_2 = shape_1.WidthPt;
				double_3 = shape_1.HeightPt;
				int_2 = shape_1.LowerRightRow;
				int_3 = shape_1.LowerRightColumn;
				break;
			case PlacementType.MoveAndSize:
				int_0 = shape_1.UpperLeftRow;
				int_1 = shape_1.UpperLeftColumn;
				double_0 = Math.Round((float)shape_1.Top * 72f / (float)shape_1.method_25().method_75(), 2);
				double_1 = Math.Round((float)shape_1.Left * 72f / (float)shape_1.method_25().method_75(), 2);
				int_2 = shape_1.LowerRightRow;
				int_3 = shape_1.LowerRightColumn;
				double_2 = shape_1.WidthPt;
				double_3 = shape_1.HeightPt;
				break;
			}
		}
	}

	[SpecialName]
	public int method_0()
	{
		return int_0;
	}

	[SpecialName]
	public int method_1()
	{
		return int_1;
	}

	[SpecialName]
	internal Shape method_2()
	{
		return shape_0;
	}
}
