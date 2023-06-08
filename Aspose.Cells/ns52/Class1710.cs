using System.Collections;
using Aspose.Cells;
using Aspose.Cells.Drawing;
using Aspose.Cells.Pivot;
using ns2;
using ns27;
using ns59;
using ns7;

namespace ns52;

internal class Class1710
{
	private WorksheetCollection worksheetCollection_0;

	private Worksheet worksheet_0;

	private ShapeCollection shapeCollection_0;

	private Class1725 class1725_0;

	private Class1390 class1390_0;

	private ArrayList arrayList_0;

	internal Class1710(WorksheetCollection worksheetCollection_1, Worksheet worksheet_1, ShapeCollection shapeCollection_1, Class1725 class1725_1)
	{
		worksheetCollection_0 = worksheetCollection_1;
		worksheet_0 = worksheet_1;
		shapeCollection_0 = shapeCollection_1;
		class1725_0 = class1725_1;
		arrayList_0 = new ArrayList();
		if (worksheet_1.Charts.Count != 0)
		{
			class1390_0 = new Class1390(worksheetCollection_1, worksheet_1.SheetIndex, worksheet_1.Charts, class1725_1);
		}
	}

	internal void method_0()
	{
		bool bool_ = true;
		foreach (Shape item in shapeCollection_0)
		{
			item.method_27().method_11();
		}
		foreach (Shape item2 in shapeCollection_0)
		{
			if (!item2.method_33())
			{
				if (item2.IsGroup)
				{
					method_1((GroupShape)item2, bool_);
				}
				else if (item2.method_34())
				{
					method_2(item2, bool_);
				}
				else
				{
					method_3(item2, bool_);
				}
				bool_ = false;
			}
		}
		if (shapeCollection_0.method_4().method_7() == null || shapeCollection_0.method_4().method_7().byte_0 == null)
		{
			return;
		}
		byte[] byte_ = shapeCollection_0.method_4().method_7().byte_0;
		if (byte_.Length <= 8224)
		{
			class1725_0.method_6(236);
			class1725_0.method_6((ushort)byte_.Length);
			class1725_0.method_3(byte_);
			return;
		}
		int num = 0;
		int num2 = 0;
		Class656 @class = new Class656();
		while (true)
		{
			num2 = byte_.Length - num;
			if (num2 <= 8224)
			{
				break;
			}
			@class.method_4(byte_, num, 8224);
			@class.method_12(class1725_0);
			num += 8224;
		}
		@class.method_4(byte_, num, num2);
		@class.method_12(class1725_0);
	}

	internal void method_1(GroupShape groupShape_0, bool bool_0)
	{
		method_3(groupShape_0, bool_0);
		bool_0 = false;
		Shape[] groupedShapes = groupShape_0.GetGroupedShapes();
		Shape[] array = groupedShapes;
		foreach (Shape shape in array)
		{
			if (shape.IsGroup)
			{
				method_1((GroupShape)shape, bool_0);
			}
			else
			{
				method_3(shape, bool_0);
			}
		}
		arrayList_0.RemoveAt(arrayList_0.Count - 1);
	}

	internal void method_2(Shape shape_0, bool bool_0)
	{
		Class656 @class = new Class656();
		int int_ = 0;
		if (bool_0)
		{
			int_ = @class.method_7(shapeCollection_0, shape_0);
		}
		ComboBox comboBox = (ComboBox)shape_0;
		if (comboBox.method_69() is AutoFilter)
		{
			AutoFilter autoFilter = (AutoFilter)comboBox.method_69();
			ushort row = autoFilter.Row;
			int num = autoFilter.method_7().StartColumn;
			Class663 class2 = new Class663();
			int num2 = shape_0.method_23();
			while (num <= autoFilter.method_7().EndColumn)
			{
				int num3 = num + 1;
				Class1133 class3 = worksheet_0.Cells.method_18();
				for (int i = 0; i < class3.Count; i++)
				{
					CellArea cellArea = class3[i];
					if (row >= cellArea.StartRow && row <= cellArea.EndRow && num >= cellArea.StartColumn && num <= cellArea.EndColumn)
					{
						num3 = ((cellArea.EndColumn <= autoFilter.method_7().EndColumn) ? (cellArea.EndColumn + 1) : (autoFilter.method_7().EndColumn + 1));
						break;
					}
				}
				Class1713 class4 = comboBox.method_27().method_9();
				class4.method_3(class4.method_2() + 1);
				@class.method_9(comboBox, int_, row, num, num3);
				@class.method_12(class1725_0);
				class2.method_4(shape_0, num2++);
				class2.method_24(class1725_0);
				int_ = 0;
				if (num == 255)
				{
					break;
				}
				num = num3;
			}
		}
		else if (comboBox.method_69() is ValidationCollection)
		{
			string activeCell = comboBox.method_26().ActiveCell;
			int row2 = 0;
			int column = 0;
			CellsHelper.CellNameToIndex(activeCell, out row2, out column);
			@class.method_10(comboBox, int_, row2, (byte)column);
			@class.method_12(class1725_0);
			Class663 class5 = new Class663();
			class5.method_4(shape_0, shape_0.method_23());
			class5.method_24(class1725_0);
		}
		else
		{
			if (!(comboBox.method_69() is PivotTable))
			{
				return;
			}
			PivotTable pivotTable = (PivotTable)comboBox.method_69();
			ushort num4 = (ushort)pivotTable.int_0;
			byte b = (byte)(pivotTable.int_2 + 1);
			Class663 class6 = new Class663();
			int num5 = shape_0.method_23();
			PivotFieldCollection pageFields = pivotTable.PageFields;
			for (int j = 0; j < pageFields.Count; j++)
			{
				num4 = (ushort)(pivotTable.int_0 - 1 - (pageFields.Count - j));
				Class1713 class7 = comboBox.method_27().method_9();
				class7.method_3(class7.method_2() + 1);
				@class.method_9(comboBox, int_, num4, b, (byte)(b + 1));
				@class.method_12(class1725_0);
				class6.method_4(shape_0, num5++);
				class6.method_24(class1725_0);
				int_ = 0;
				if (b == byte.MaxValue)
				{
					break;
				}
			}
		}
	}

	internal void method_3(Shape shape_0, bool bool_0)
	{
		Class656 @class = new Class656();
		int int_ = 0;
		if (bool_0)
		{
			int_ = @class.method_7(shapeCollection_0, shape_0);
		}
		@class.method_11(shape_0, int_, arrayList_0);
		@class.method_12(class1725_0);
		Class663 class2 = new Class663();
		class2.method_5(shape_0);
		class2.method_24(class1725_0);
		if (shape_0.method_11() || shape_0.MsoDrawingType == MsoDrawingType.Chart)
		{
			method_4(shape_0);
		}
	}

	internal void method_4(Shape shape_0)
	{
		switch (shape_0.MsoDrawingType)
		{
		case MsoDrawingType.CellsDrawing:
			method_5(shape_0, ((CellsDrawing)shape_0).method_63());
			break;
		case MsoDrawingType.Comment:
			method_5(shape_0, ((CommentShape)shape_0).method_69().method_2());
			break;
		case MsoDrawingType.Rectangle:
			method_5(shape_0, ((RectangleShape)shape_0).method_63());
			break;
		case MsoDrawingType.Oval:
			method_5(shape_0, ((Oval)shape_0).method_63());
			break;
		case MsoDrawingType.Arc:
			method_5(shape_0, ((ArcShape)shape_0).method_63());
			break;
		case MsoDrawingType.Chart:
			class1390_0.method_1(((ChartShape)shape_0).method_69());
			break;
		case MsoDrawingType.TextBox:
			method_5(shape_0, ((TextBox)shape_0).method_63());
			break;
		case MsoDrawingType.Button:
			method_5(shape_0, ((Button)shape_0).method_63());
			break;
		case MsoDrawingType.CheckBox:
			method_5(shape_0, ((CheckBox)shape_0).method_63());
			break;
		case MsoDrawingType.RadioButton:
			method_5(shape_0, ((RadioButton)shape_0).method_63());
			break;
		case MsoDrawingType.Label:
			method_5(shape_0, ((Label)shape_0).method_63());
			break;
		case MsoDrawingType.GroupBox:
			method_5(shape_0, ((GroupBox)shape_0).method_63());
			break;
		}
	}

	internal void method_5(Shape shape_0, Class1737 class1737_0)
	{
		Class656 @class = new Class656();
		@class.method_5();
		@class.method_12(class1725_0);
		Class715 class2 = new Class715();
		int num = 0;
		if (class1737_0.Text != null && class1737_0.Text != "")
		{
			num = (ushort)class1737_0.Text.Length;
		}
		int int_ = class1737_0.method_8();
		ArrayList arrayList = class2.method_4(shape_0, class1737_0, int_, (ushort)num);
		class2.vmethod_0(class1725_0);
		if (num != 0)
		{
			Class619 class3 = new Class619();
			class3.method_4(class1737_0.Text, class1725_0);
			class3.vmethod_0(class1725_0);
			class3.method_5(arrayList);
			class3.vmethod_0(class1725_0);
		}
	}
}
