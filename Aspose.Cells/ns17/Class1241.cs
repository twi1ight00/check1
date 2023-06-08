using System;
using System.Collections;
using System.Drawing;
using Aspose.Cells;
using Aspose.Cells.Drawing;
using Aspose.Cells.Rendering;
using ns2;
using ns25;

namespace ns17;

internal class Class1241
{
	private Workbook workbook_0;

	private WorksheetCollection worksheetCollection_0;

	private Worksheet worksheet_0;

	private Cells cells_0;

	private int int_0;

	private double double_0;

	private Hashtable hashtable_0;

	private double[] double_1;

	internal int int_1 = -1;

	internal int int_2 = -1;

	internal int int_3 = -1;

	internal int int_4 = -1;

	private double double_2;

	private double double_3;

	private double double_4;

	private double double_5;

	private double double_6;

	private double double_7;

	private Style style_0;

	private ArrayList arrayList_0;

	private int int_5 = -1;

	private int int_6;

	private int int_7 = -1;

	private int int_8;

	private ArrayList arrayList_1;

	private int int_9;

	private SizeF sizeF_0;

	private double double_8 = -1.1;

	private double double_9 = -1.1;

	private double double_10;

	private double double_11;

	public ArrayList arrayList_2;

	internal ArrayList arrayList_3;

	private Hashtable hashtable_1 = new Hashtable();

	internal ImageOrPrintOptions imageOrPrintOptions_0;

	private bool bool_0;

	private ArrayList arrayList_4;

	internal Class1241(Workbook workbook_1)
	{
		workbook_0 = workbook_1;
		worksheetCollection_0 = workbook_1.Worksheets;
		double_1 = new double[2] { 1.0, 1.0 };
		double_0 = workbook_1.Worksheets.method_75();
		hashtable_0 = new Hashtable();
		style_0 = workbook_1.Worksheets.DefaultStyle;
		for (int i = 0; i < worksheetCollection_0.Count; i++)
		{
			worksheetCollection_0[i].ConditionalFormattings.method_7();
		}
		sizeF_0 = new SizeF(0f, 0f);
		int_9 = -(workbook_1.Worksheets.method_73() + workbook_1.Worksheets.method_72() + 2);
		arrayList_2 = new ArrayList();
		arrayList_3 = new ArrayList();
	}

	private void method_0(Worksheet worksheet_1)
	{
		ShapeCollection shapeCollection = worksheet_1.method_36();
		ArrayList arrayList = new ArrayList();
		new ArrayList();
		if (shapeCollection != null)
		{
			for (int i = 0; i < shapeCollection.Count; i++)
			{
				Shape shape = shapeCollection[i];
				if (!shape.method_33() && shape.MsoDrawingType != MsoDrawingType.Comment)
				{
					Class1626 @class = new Class1626(shape, i, null);
					if (@class.MsoDrawingType == MsoDrawingType.Picture)
					{
						bool_0 = true;
					}
					if (@class.MsoDrawingType == MsoDrawingType.Group)
					{
						method_1(@class, (GroupShape)shape, 0.0, 0.0, @class.Width, @class.Height);
						arrayList.Add(@class);
					}
					if (!shape.method_33())
					{
						arrayList.Add(@class);
					}
				}
			}
		}
		hashtable_1[worksheet_1] = arrayList;
	}

	private void method_1(Class1626 class1626_0, GroupShape groupShape_0, double double_12, double double_13, double double_14, double double_15)
	{
		for (int i = 0; i < groupShape_0.method_73().Count; i++)
		{
			Shape shape = (Shape)groupShape_0.method_73()[i];
			Class1626 @class = new Class1626(shape, i, null);
			if (@class != null)
			{
				@class.Left = double_12 + (double)shape.method_27().method_7().Left * double_14 / 4000.0;
				@class.Top = double_13 + (double)shape.method_27().method_7().Top * double_15 / 4000.0;
				@class.Width = (double)shape.method_27().method_7().Right * double_14 / 4000.0;
				@class.Height = (double)shape.method_27().method_7().Bottom * double_15 / 4000.0;
				class1626_0.arrayList_0.Add(@class);
				if (shape.MsoDrawingType == MsoDrawingType.Group)
				{
					method_1(@class, (GroupShape)shape, @class.Left, @class.Top, @class.Width, @class.Height);
				}
			}
		}
	}

	private void method_2(Worksheet worksheet_1)
	{
		int_3 = Class1625.smethod_17(worksheet_1, arrayList_0);
		int_2 = method_6(bool_1: true, 0, 0, 65535, 255);
		method_8();
		if (int_2 < 0 || int_4 < 0)
		{
			return;
		}
		if (worksheet_0.PageSetup.method_29())
		{
			int_1 = Class1625.smethod_16(worksheet_0, arrayList_0);
		}
		else
		{
			int_1 = 0;
		}
		int num = 0;
		for (num = int_1; num <= int_2 && worksheet_0.Cells.GetRowHeight(num) == 0.0; num++)
		{
			int_1 = num + 1;
		}
		num = int_2;
		while (num >= int_1 && worksheet_0.Cells.GetRowHeight(num) == 0.0)
		{
			int_2 = num - 1;
			num--;
		}
		if (int_4 == -1)
		{
			return;
		}
		for (num = int_3; num <= int_4; num++)
		{
			if (num >= 0)
			{
				if (worksheet_0.Cells.GetColumnWidth(num) != 0.0)
				{
					break;
				}
				int_3 = num + 1;
			}
		}
		for (num = int_4; num >= int_3; num--)
		{
			if (num >= 0)
			{
				if (worksheet_0.Cells.GetColumnWidth(num) != 0.0)
				{
					break;
				}
				int_4 = num - 1;
			}
		}
	}

	private void method_3(Worksheet worksheet_1)
	{
		worksheet_0 = worksheet_1;
		arrayList_4 = null;
		cells_0 = worksheet_0.Cells;
		int_5 = -1;
		int_6 = -1;
		PageSetup pageSetup = worksheet_0.PageSetup;
		if (worksheet_0.Type == SheetType.Chart)
		{
			pageSetup = worksheet_0.Charts[0].PageSetup;
		}
		Class1625.smethod_10(pageSetup, out double_2, out double_3);
	}

	private void method_4(Worksheet worksheet_1)
	{
		worksheet_0 = worksheet_1;
		arrayList_4 = null;
		cells_0 = worksheet_1.Cells;
		int_5 = -1;
		int_6 = -1;
		PageSetup pageSetup = worksheet_1.PageSetup;
		Class1625.smethod_10(pageSetup, out double_2, out double_3);
		if (worksheet_1.conditionalFormattingCollection_0 != null)
		{
			for (int i = 0; i < cells_0.Rows.Count; i++)
			{
				Row rowByIndex = cells_0.Rows.GetRowByIndex(i);
				for (int j = 0; j < rowByIndex.method_0(); j++)
				{
					Cell cellByIndex = rowByIndex.GetCellByIndex(j);
					if (cellByIndex.IsFormula)
					{
						cellByIndex.method_61(2);
					}
				}
			}
		}
		method_0(worksheet_1);
		Class1133 @class = worksheet_1.Cells.method_18();
		arrayList_0 = new ArrayList(@class.Count);
		for (int k = 0; k < @class.Count; k++)
		{
			arrayList_0.Add(new Struct88(@class[k]));
		}
		arrayList_0.Sort();
		Class1625.GetPageSize(worksheet_1, out double_4, out double_5, double_2, double_3);
		double_6 = pageSetup.HeaderMargin;
		double_7 = pageSetup.FooterMargin;
		double_8 = pageSetup.LeftMargin;
		double_10 = pageSetup.RightMargin;
		double_9 = pageSetup.TopMargin;
		double_11 = pageSetup.BottomMargin;
		int_1 = -1;
		int_2 = -1;
		int_3 = -1;
		int_4 = -1;
		string printArea = pageSetup.PrintArea;
		method_2(worksheet_1);
		if (imageOrPrintOptions_0 != null && !imageOrPrintOptions_0.method_0())
		{
			CellArea cellArea = default(CellArea);
			cellArea.StartRow = cells_0.MinRow;
			cellArea.StartColumn = cells_0.MinColumn;
			cellArea.EndRow = cells_0.method_20(0);
			cellArea.EndColumn = cells_0.method_22(0);
			arrayList_4 = new ArrayList();
			arrayList_4.Add(cellArea);
			double num = 0.0;
			for (int l = cellArea.StartColumn; l <= cellArea.EndColumn; l++)
			{
				num += cells_0.GetColumnWidthInch(l);
			}
			double_4 = num * 72.0;
			num += double_8 + double_10;
			double_2 = num;
			num = 0.0;
			for (int m = cellArea.StartRow; m <= cellArea.EndRow; m++)
			{
				num += cells_0.GetRowHeightInch(m);
			}
			double_5 = num * 72.0;
			num += double_9 + double_11;
			double_3 = num;
		}
		else if (printArea != null && printArea != "")
		{
			arrayList_4 = Class1625.smethod_12(printArea, worksheet_1);
		}
	}

	private static bool smethod_0(Cell cell_0, Style style_1)
	{
		if (cell_0 == null)
		{
			return false;
		}
		if (cell_0.Type != CellValueType.IsNull)
		{
			return true;
		}
		Style style = cell_0.method_32();
		if (style != null && Class1625.smethod_11(style, style_1))
		{
			return true;
		}
		return false;
	}

	private bool method_5(Worksheet worksheet_1, Struct88 struct88_0, Style style_1)
	{
		for (int i = struct88_0.int_0; i <= struct88_0.int_2; i++)
		{
			if (worksheet_1.Cells.GetRowHeight(i) == 0.0)
			{
				continue;
			}
			for (int j = struct88_0.int_1; j <= struct88_0.int_3; j++)
			{
				if (worksheet_1.Cells.GetColumnWidth(j) != 0.0 && smethod_0(worksheet_1.Cells.CheckCell(i, j), style_1))
				{
					return true;
				}
			}
		}
		return false;
	}

	private int method_6(bool bool_1, int int_10, int int_11, int int_12, int int_13)
	{
		int num = -1;
		Cells cells = worksheet_0.Cells;
		RowCollection rows = cells.Rows;
		for (int num2 = rows.Count - 1; num2 >= 0; num2--)
		{
			Row rowByIndex = rows.GetRowByIndex(num2);
			if (rowByIndex.int_0 < int_10)
			{
				break;
			}
			if (rowByIndex.int_0 <= int_12 && worksheet_0.Cells.GetRowHeight(rowByIndex.int_0) != 0.0)
			{
				for (int i = 0; i < rowByIndex.method_0(); i++)
				{
					Cell cellByIndex = rowByIndex.GetCellByIndex(i);
					if (cellByIndex.Column < int_11)
					{
						continue;
					}
					if (cellByIndex.Column > int_13)
					{
						break;
					}
					if (cells.GetColumnWidth(cellByIndex.Column) != 0.0)
					{
						if (cellByIndex.Type != CellValueType.IsNull)
						{
							num = cellByIndex.Row;
							break;
						}
						Style style = cellByIndex.method_32();
						if (style != null && Class1625.smethod_11(style, style_0))
						{
							num = cellByIndex.Row;
							break;
						}
					}
				}
				if (num != -1)
				{
					break;
				}
			}
		}
		if (!bool_1 && num == int_12)
		{
			return num;
		}
		if (arrayList_0 != null && arrayList_0.Count > 0)
		{
			if (bool_1)
			{
				int num3 = arrayList_0.Count - 1;
				while (num3 >= 0)
				{
					Struct88 struct88_ = (Struct88)arrayList_0[num3];
					if (!method_5(worksheet_0, struct88_, style_0) || num >= struct88_.int_2)
					{
						num3--;
						continue;
					}
					num = struct88_.int_2;
					break;
				}
			}
			else
			{
				for (int num4 = arrayList_0.Count - 1; num4 >= 0; num4--)
				{
					Struct88 @struct = (Struct88)arrayList_0[num4];
					if (@struct.int_0 <= int_12 && @struct.int_2 >= int_10 && @struct.int_1 <= int_13 && @struct.int_3 >= int_11 && @struct.int_2 > num)
					{
						num = @struct.int_2;
					}
				}
			}
		}
		arrayList_1 = (ArrayList)hashtable_1[worksheet_0];
		if (arrayList_1 != null && arrayList_1.Count > 0)
		{
			int num5 = 0;
			for (int j = 0; j < arrayList_1.Count; j++)
			{
				Class1626 @class = (Class1626)arrayList_1[j];
				if (@class.method_4().IsHidden || !@class.method_4().IsPrintable || @class.method_4().method_33())
				{
					continue;
				}
				num5 = @class.method_1();
				if (num5 <= num)
				{
					continue;
				}
				if (bool_1)
				{
					num = num5;
				}
				else if (@class.method_0() <= int_12 && @class.method_1() >= int_10 && @class.method_2() <= int_13 && @class.method_3() >= int_11)
				{
					if (num5 >= int_12)
					{
						return int_12;
					}
					num = num5;
				}
			}
		}
		return num;
	}

	private bool method_7(int int_10, int int_11, int int_12, int int_13)
	{
		Cells cells = worksheet_0.Cells;
		if (arrayList_0.Count > 0)
		{
			int num = arrayList_0.Count - 1;
			while (num >= 0)
			{
				Struct88 @struct = (Struct88)arrayList_0[num];
				if (@struct.int_0 > int_12 || @struct.int_2 < int_10 || @struct.int_1 > int_13 || @struct.int_3 < int_11)
				{
					num--;
					continue;
				}
				return true;
			}
		}
		if (arrayList_1 != null && arrayList_1.Count > 0)
		{
			for (int i = 0; i < arrayList_1.Count; i++)
			{
				Class1626 @class = (Class1626)arrayList_1[i];
				if (@class.method_0() <= int_12 && @class.method_1() >= int_10 && @class.method_2() <= int_13 && @class.method_3() >= int_11)
				{
					return true;
				}
			}
		}
		Cell cell = null;
		Cell cell2 = null;
		for (int num2 = cells.Count - 1; num2 >= 0; num2--)
		{
			Cell cellByIndex = cells.GetCellByIndex(num2);
			if (cellByIndex.Row < int_10)
			{
				break;
			}
			if (cellByIndex.Row <= int_12)
			{
				Style style = null;
				if (cellByIndex.Column > int_13)
				{
					if (cellByIndex.Type != CellValueType.IsNull)
					{
						cell = cellByIndex;
					}
				}
				else if (cellByIndex.Column < int_11)
				{
					if (cellByIndex.Type != CellValueType.IsNull)
					{
						cell2 = cellByIndex;
					}
				}
				else if (cellByIndex.Column >= int_11 && cellByIndex.Column <= int_13)
				{
					if (cellByIndex.Type != CellValueType.IsNull)
					{
						return true;
					}
					Style style2 = cellByIndex.method_32();
					if (style2 != null && Class1625.smethod_11(style2, style_0))
					{
						return true;
					}
				}
				if (cell2 != null && cell2.Type == CellValueType.IsString && cell2.method_32().HorizontalAlignment != TextAlignmentType.Right)
				{
					style = cell2.method_32();
					if (!style.IsTextWrapped)
					{
						double num3 = Class1625.smethod_18(cell2.method_25(0, bool_0: false), style.Font, 1.0, style.RotationAngle);
						int num4 = 0;
						for (int j = cell2.Column; j < int_11; j++)
						{
							num4 += cells_0.GetColumnWidthPixel(j);
						}
						if (!((double)num4 >= num3 + 2.0))
						{
							return true;
						}
					}
				}
				if (cell != null && cell.Type == CellValueType.IsString && cell.GetStyle().HorizontalAlignment == TextAlignmentType.Right)
				{
					style = cell.method_32();
					if (cellByIndex.Type == CellValueType.IsString && !style.IsTextWrapped)
					{
						double num5 = Class1625.smethod_18(cell.method_25(0, bool_0: false), style.Font, 1.0, style.RotationAngle);
						int num6 = 0;
						for (int num7 = cell.Column; num7 > int_13; num7--)
						{
							num6 += cells_0.GetColumnWidthPixel(num7);
						}
						if (!((double)num6 >= num5 + 2.0))
						{
							return true;
						}
					}
				}
				cell = null;
				cell2 = null;
			}
		}
		return false;
	}

	private void method_8()
	{
		int_4 = -1;
		int num = -1;
		for (int num2 = cells_0.Count - 1; num2 >= 0; num2--)
		{
			Cell cellByIndex = cells_0.GetCellByIndex(num2);
			if (num != cellByIndex.Row && cells_0.GetColumnWidthPixel(cellByIndex.Column) != 0 && cells_0.GetRowHeight(cellByIndex.Row) != 0.0)
			{
				Style style = cellByIndex.method_32();
				if (cellByIndex.Type == CellValueType.IsNull)
				{
					if (style != null && Class1625.smethod_11(style, style_0))
					{
						num = cellByIndex.Row;
						if (int_4 < cellByIndex.Column)
						{
							int_4 = cellByIndex.Column;
						}
					}
				}
				else
				{
					num = cellByIndex.Row;
					int num3 = cellByIndex.Column;
					if (cellByIndex.Type == CellValueType.IsString && !style.IsTextWrapped && !style.ShrinkToFit && (style.HorizontalAlignment == TextAlignmentType.Left || style.HorizontalAlignment == TextAlignmentType.General))
					{
						string string_ = cellByIndex.method_25(0, bool_0: false);
						Aspose.Cells.Font font_ = style_0.Font;
						if (style != null && style.method_40() != null)
						{
							font_ = style.method_40();
						}
						int num4 = Class1625.smethod_18(string_, font_, 1.0, style.RotationAngle);
						num3 = Class1625.smethod_15(cells_0, cellByIndex.Column, num4, bool_0: false);
					}
					if (int_4 < num3)
					{
						int_4 = num3;
					}
				}
			}
		}
		for (int i = 0; i < arrayList_0.Count; i++)
		{
			Struct88 struct88_ = (Struct88)arrayList_0[i];
			if (int_4 < struct88_.int_3 && struct88_.int_3 != 16383 && method_5(worksheet_0, struct88_, style_0))
			{
				int_4 = struct88_.int_3;
			}
		}
		ArrayList arrayList = (ArrayList)hashtable_1[worksheet_0];
		if (arrayList == null || arrayList.Count <= 0)
		{
			return;
		}
		int num5 = 0;
		for (int j = 0; j < arrayList.Count; j++)
		{
			Shape shape = ((Class1626)arrayList[j]).method_4();
			if (!shape.IsHidden && shape.IsPrintable && !shape.method_33())
			{
				num5 = shape.LowerRightColumn;
				if (num5 > int_4)
				{
					int_4 = num5;
				}
			}
		}
	}

	public void method_9(Worksheet worksheet_1, ImageOrPrintOptions imageOrPrintOptions_1)
	{
		imageOrPrintOptions_0 = imageOrPrintOptions_1;
		style_0 = workbook_0.DefaultStyle;
		method_13(worksheet_1.SheetIndex);
	}

	private Rectangle method_10(CellArea cellArea_0, bool bool_1)
	{
		int num;
		int num2;
		int num3;
		int num4;
		if (bool_1)
		{
			num = ((cellArea_0.StartRow == -1) ? int_1 : cellArea_0.StartRow);
			num2 = ((cellArea_0.StartColumn == -1) ? int_3 : cellArea_0.StartColumn);
			num3 = ((cellArea_0.EndRow == -1) ? int_2 : cellArea_0.EndRow);
			num4 = ((cellArea_0.EndColumn == -1) ? int_4 : cellArea_0.EndColumn);
		}
		else
		{
			num = int_1;
			num3 = int_2;
			num2 = int_3;
			num4 = int_4;
		}
		Class1625.smethod_25(worksheet_0, arrayList_0, ref int_5, ref int_6);
		Class1625.smethod_24(worksheet_0, arrayList_0, ref int_7, ref int_8);
		Rectangle result = new Rectangle(num2, num, num4 - num2 + 1, num3 - num + 1);
		if (worksheet_0.PageSetup.PrintHeadings)
		{
			SizeF sizeF = Class1625.smethod_27(num3, workbook_0.DefaultStyle.Font, new double[2] { 1.0, 1.0 });
			double_4 -= sizeF.Width;
			double_5 -= sizeF.Height;
		}
		if (!imageOrPrintOptions_0.OnlyArea)
		{
			double_1 = Class1625.smethod_7(worksheet_0, double_4, double_5, num2, num4, num, num3, int_5, int_6, int_7, int_8);
		}
		return result;
	}

	private bool method_11(Struct88 struct88_0)
	{
		if (imageOrPrintOptions_0 != null && imageOrPrintOptions_0.PrintingPage != 0)
		{
			if (imageOrPrintOptions_0.PrintingPage == PrintingPageType.IgnoreBlank)
			{
				for (int i = struct88_0.int_0; i <= struct88_0.int_2; i++)
				{
					if (cells_0.GetRowHeightPixel(i) <= 0)
					{
						continue;
					}
					for (int j = struct88_0.int_1; j <= struct88_0.int_3; j++)
					{
						if (cells_0.GetColumnWidthPixel(j) <= 0)
						{
							continue;
						}
						Cell cell = cells_0.CheckCell(i, j);
						if (cell != null)
						{
							if (cell.StringValue != null && cell.StringValue.Length > 0)
							{
								return true;
							}
							Style style = cell.GetStyle();
							if (style != null)
							{
								return true;
							}
						}
					}
				}
			}
			else if (imageOrPrintOptions_0.PrintingPage == PrintingPageType.IgnoreStyle)
			{
				for (int k = struct88_0.int_0; k <= struct88_0.int_2; k++)
				{
					if (cells_0.GetRowHeightPixel(k) <= 0)
					{
						continue;
					}
					for (int l = struct88_0.int_1; l <= struct88_0.int_3; l++)
					{
						Cell cell2 = cells_0.CheckCell(k, l);
						if (cell2 != null && cell2.StringValue != null && cell2.StringValue.Length > 0)
						{
							return true;
						}
					}
				}
			}
			ShapeCollection shapeCollection = worksheet_0.method_36();
			if (shapeCollection != null && shapeCollection.Count > 0)
			{
				foreach (Shape item in shapeCollection)
				{
					if (!item.IsHidden && item.IsPrintable && !item.method_33())
					{
						Rectangle rectangle = new Rectangle(item.UpperLeftColumn, item.UpperLeftRow, item.LowerRightColumn - item.UpperLeftColumn, item.LowerRightRow - item.UpperLeftRow);
						Rectangle rect = new Rectangle(struct88_0.int_1, struct88_0.int_0, struct88_0.int_3 - struct88_0.int_1, struct88_0.int_2 - struct88_0.int_0);
						if (rectangle.IntersectsWith(rect))
						{
							return true;
						}
					}
				}
			}
			return false;
		}
		return true;
	}

	private void method_12(CellArea cellArea_0, bool bool_1)
	{
		Rectangle rectangle_ = method_10(cellArea_0, bool_1);
		PageSetup pageSetup = worksheet_0.PageSetup;
		ArrayList arrayList = new ArrayList();
		ArrayList arrayList2 = new ArrayList();
		ArrayList arrayList3 = new ArrayList();
		ArrayList arrayList4 = new ArrayList();
		method_20(double_5, arrayList, rectangle_);
		method_23(double_4, arrayList3, rectangle_);
		method_22(arrayList, arrayList2);
		method_24(arrayList3, arrayList4);
		RectangleF rectangleF = default(RectangleF);
		if (imageOrPrintOptions_0 != null && !imageOrPrintOptions_0.method_0())
		{
			rectangleF = new RectangleF(0f, 0f, (float)arrayList4[arrayList4.Count - 1], (float)arrayList2[arrayList2.Count - 1]);
			if (method_11(new Struct88(cellArea_0)))
			{
				method_17(new Struct88(cellArea_0), rectangleF);
			}
			return;
		}
		Struct88 struct88_ = default(Struct88);
		if (arrayList.Count > 0 && arrayList3.Count > 0)
		{
			if (pageSetup.Order == PrintOrderType.OverThenDown)
			{
				for (int i = 1; i < arrayList.Count; i++)
				{
					struct88_.int_2 = (int)arrayList[i] - 1;
					struct88_.int_0 = (int)arrayList[i - 1];
					for (int j = 1; j < arrayList3.Count; j++)
					{
						struct88_.int_3 = (int)arrayList3[j] - 1;
						struct88_.int_1 = (int)arrayList3[j - 1];
						if (i != arrayList.Count - 1 || bool_1 || method_7(struct88_.int_0, struct88_.int_1, struct88_.int_2, struct88_.int_3))
						{
							rectangleF = new RectangleF((float)arrayList4[j - 1], (float)arrayList2[i - 1], (float)arrayList4[j] - (float)arrayList4[j - 1], (float)arrayList2[i] - (float)arrayList2[i - 1]);
							if (bool_1 || method_11(struct88_))
							{
								method_17(struct88_, rectangleF);
							}
						}
					}
				}
				return;
			}
			for (int k = 1; k < arrayList3.Count; k++)
			{
				struct88_.int_3 = (int)arrayList3[k] - 1;
				struct88_.int_1 = (int)arrayList3[k - 1];
				if (struct88_.int_1 > struct88_.int_3)
				{
					continue;
				}
				for (int l = 1; l < arrayList.Count; l++)
				{
					struct88_.int_2 = (int)arrayList[l] - 1;
					struct88_.int_0 = (int)arrayList[l - 1];
					if (k != arrayList3.Count - 1 || bool_1 || method_7(struct88_.int_0, struct88_.int_1, struct88_.int_2, struct88_.int_3))
					{
						rectangleF = new RectangleF((float)arrayList4[k - 1], (float)arrayList2[l - 1], (float)arrayList4[k] - (float)arrayList4[k - 1], (float)arrayList2[l] - (float)arrayList2[l - 1]);
						if (bool_1 || method_11(struct88_))
						{
							method_17(struct88_, rectangleF);
						}
					}
				}
			}
		}
		else
		{
			method_17(struct88_, default(RectangleF));
		}
	}

	private void method_13(int int_10)
	{
		Worksheet worksheet = workbook_0.Worksheets[int_10];
		if (!worksheet.IsVisible)
		{
			return;
		}
		int_0 = int_10;
		if (worksheet.Type == SheetType.Chart)
		{
			method_14(worksheet);
			return;
		}
		method_4(worksheet);
		if (int_4 < 0 || int_3 < 0 || int_1 < 0 || int_2 < 0)
		{
			return;
		}
		if (arrayList_4 != null && arrayList_4.Count != 0)
		{
			for (int i = 0; i < arrayList_4.Count; i++)
			{
				CellArea cellArea_ = (CellArea)arrayList_4[i];
				if ((cellArea_.StartRow == 0 && cellArea_.EndRow == 65535) || (cellArea_.StartRow == -1 && cellArea_.EndRow == -1) || (cellArea_.StartRow == 0 && cellArea_.EndRow == 1048575))
				{
					cellArea_.EndRow = int_2;
					cellArea_.StartColumn = int_1;
					int_3 = ((cellArea_.StartColumn == -1) ? int_3 : cellArea_.StartColumn);
					int_4 = ((cellArea_.EndColumn == -1) ? int_4 : cellArea_.EndColumn);
				}
				else if (cellArea_.StartColumn == -1 && cellArea_.EndColumn == -1)
				{
					cellArea_.StartColumn = int_3;
					cellArea_.EndColumn = int_4;
				}
				else
				{
					int_1 = cellArea_.StartRow;
					int_2 = cellArea_.EndRow;
					int_3 = cellArea_.StartColumn;
					int_4 = cellArea_.EndColumn;
				}
				method_12(cellArea_, bool_1: true);
			}
		}
		else
		{
			method_12(default(CellArea), bool_1: false);
		}
	}

	private void method_14(Worksheet worksheet_1)
	{
		method_3(worksheet_1);
		Class1623 @class = new Class1623();
		Struct88 struct88_ = default(Struct88);
		@class.int_0 = int_0;
		@class.struct88_0 = struct88_;
		@class.double_0 = double_1;
		@class.int_1 = 0;
		@class.int_2 = 0;
		@class.int_3 = 0;
		@class.int_4 = 0;
		@class.double_1 = double_2;
		@class.double_2 = double_3;
		@class.double_3 = double_4;
		@class.double_4 = double_5;
		@class.double_5 = double_6;
		@class.double_6 = double_7;
		@class.arrayList_0 = arrayList_0;
		@class.int_5 = int_5;
		@class.int_6 = int_6;
		@class.int_7 = int_7;
		@class.int_8 = int_8;
		@class.arrayList_1 = (ArrayList)hashtable_1[worksheet_0];
		double[] array = new double[2];
		double[] array2 = array;
		method_15(struct88_.int_1, struct88_.int_3, @class.double_1, array2);
		@class.double_7 = array2[0];
		@class.double_9 = array2[1];
		method_16(struct88_.int_0, struct88_.int_2, @class.double_2, array2);
		@class.double_8 = array2[0];
		@class.double_10 = array2[1];
		@class.rectangleF_0 = new RectangleF(0f, 0f, (float)double_2 * 72f, (float)double_3 * 72f);
		arrayList_2.Add(@class);
	}

	private void method_15(int int_10, int int_11, double double_12, double[] double_13)
	{
		double num = 0.0;
		double num2 = 0.0;
		PageSetup pageSetup = worksheet_0.PageSetup;
		double num3 = 0.0;
		double_12 *= 2.54;
		bool flag = false;
		for (int i = int_10; i <= int_11; i++)
		{
			if (i >= int_7 && i <= int_8)
			{
				flag = true;
			}
			num3 += cells_0.GetColumnWidthInch(i) * 72.0;
		}
		if (!flag && int_7 >= 0 && int_8 >= 0)
		{
			for (int j = int_7; j <= int_8; j++)
			{
				num3 += cells_0.GetColumnWidthInch(j) * 72.0;
			}
		}
		num3 = num3 * double_1[0] / 72.0 * 2.54;
		if (pageSetup.CenterHorizontally)
		{
			num = (double_12 - num3) / 2.0;
			num = Math.Round(num, 2);
		}
		else
		{
			num = pageSetup.LeftMargin;
		}
		num2 = 0.0;
		if (pageSetup.CenterHorizontally)
		{
			num2 = (double_12 - num3) / 2.0;
			num2 = Math.Round(num2, 2);
		}
		else
		{
			num2 = pageSetup.RightMargin;
		}
		if (num < 0.0)
		{
			num = 0.0;
		}
		if (num2 < 0.0)
		{
			num2 = 0.0;
		}
		double_13[0] = num;
		double_13[1] = num2;
	}

	private void method_16(int int_10, int int_11, double double_12, double[] double_13)
	{
		double num = 0.0;
		double num2 = 0.0;
		PageSetup pageSetup = worksheet_0.PageSetup;
		double num3 = 0.0;
		double_12 *= 2.54;
		bool flag = false;
		for (int i = int_10; i <= int_11; i++)
		{
			if (i >= int_5 && i <= int_6)
			{
				flag = true;
			}
			num3 += worksheet_0.Cells.GetRowHeightInch(i);
		}
		if (!flag && int_5 >= 0 && int_6 >= 0)
		{
			for (int j = int_5; j <= int_6; j++)
			{
				num3 += worksheet_0.Cells.GetRowHeightInch(j);
			}
		}
		num3 = num3 * double_1[1] * 2.54;
		if (pageSetup.CenterVertically)
		{
			num = (double_12 - num3) / 2.0;
			if (num > 0.0)
			{
				num = Math.Round(num, 2);
			}
		}
		else
		{
			num = pageSetup.TopMargin;
		}
		num2 = 0.0;
		if (pageSetup.CenterVertically)
		{
			if (num > 0.0)
			{
				num2 = num;
			}
		}
		else
		{
			num2 = pageSetup.BottomMargin;
		}
		if (num < 0.0)
		{
			num = 0.0;
		}
		if (num2 < 0.0)
		{
			num2 = 0.0;
		}
		double_13[0] = num;
		double_13[1] = num2;
	}

	private void method_17(Struct88 struct88_0, RectangleF rectangleF_0)
	{
		Class1623 @class = new Class1623();
		@class.int_0 = int_0;
		@class.struct88_0 = new Struct88(struct88_0.int_0, struct88_0.int_1, struct88_0.int_2, struct88_0.int_3);
		@class.double_0 = new double[2]
		{
			double_1[0],
			double_1[1]
		};
		@class.int_1 = int_1;
		@class.int_2 = int_2;
		@class.int_3 = int_3;
		@class.int_4 = int_4;
		if (imageOrPrintOptions_0 != null && imageOrPrintOptions_0.OnePagePerSheet)
		{
			@class.double_1 = (double)(rectangleF_0.Width / 72f) + (double_8 + double_10) / 2.5399999618530273;
			@class.double_2 = (double)(rectangleF_0.Height / 72f) + (double_9 + double_11) / 2.5399999618530273;
			@class.double_3 = rectangleF_0.Width;
			@class.double_4 = rectangleF_0.Height;
		}
		else
		{
			@class.double_1 = double_2;
			@class.double_2 = double_3;
			@class.double_3 = double_4;
			@class.double_4 = double_5;
		}
		@class.double_5 = double_6;
		@class.double_6 = double_7;
		@class.arrayList_0 = arrayList_0;
		@class.int_5 = int_5;
		@class.int_6 = int_6;
		@class.int_7 = int_7;
		@class.int_8 = int_8;
		@class.arrayList_1 = (ArrayList)hashtable_1[worksheet_0];
		double[] array = new double[2];
		double[] array2 = array;
		if (!imageOrPrintOptions_0.OnlyArea)
		{
			method_15(struct88_0.int_1, struct88_0.int_3, @class.double_1, array2);
			@class.double_7 = array2[0];
			@class.double_9 = array2[1];
			method_16(struct88_0.int_0, struct88_0.int_2, @class.double_2, array2);
			@class.double_8 = array2[0];
			@class.double_10 = array2[1];
		}
		@class.rectangleF_0 = rectangleF_0;
		arrayList_2.Add(@class);
		workbook_0.method_30();
	}

	private bool method_18(int int_10, int int_11, int int_12)
	{
		if (int_11 <= int_10 && int_12 >= int_10)
		{
			return true;
		}
		return false;
	}

	private ArrayList method_19(int int_10, int int_11, PageSetup pageSetup_0, double double_12)
	{
		ArrayList arrayList = new ArrayList();
		double num = 0.0;
		if (int_5 != -1)
		{
			for (int i = int_5; i <= int_6; i++)
			{
				num += cells_0.GetRowHeightInch(i) * 72.0;
			}
			num *= double_1[1];
		}
		double num2 = 0.0;
		double num3 = double_5 - num;
		for (int j = int_10; j < int_11; j++)
		{
			if (!method_18(j, int_5, int_6))
			{
				num2 += cells_0.GetRowHeightInch(j) * 72.0 * double_1[1];
				if (num2 >= num3)
				{
					arrayList.Add(j);
					num2 = cells_0.GetRowHeightInch(j) * 72.0 * double_1[1];
				}
			}
		}
		return arrayList;
	}

	private void method_20(double double_12, ArrayList arrayList_5, Rectangle rectangle_0)
	{
		PageSetup pageSetup = worksheet_0.PageSetup;
		arrayList_5.Add(rectangle_0.Y);
		arrayList_5.Add(rectangle_0.Y + rectangle_0.Height);
		double num = 0.0;
		if (imageOrPrintOptions_0 != null && imageOrPrintOptions_0.OnePagePerSheet)
		{
			return;
		}
		if (int_5 != -1)
		{
			for (int i = int_5; i <= int_6; i++)
			{
				num += cells_0.GetRowHeightInch(i) * 72.0;
			}
			num *= double_1[1];
		}
		if (!pageSetup.IsPercentScale && pageSetup.FitToPagesTall != 0)
		{
			if (pageSetup.IsPercentScale || pageSetup.FitToPagesTall == 0)
			{
				return;
			}
			double num2 = 0.0;
			for (int j = rectangle_0.Y; j < rectangle_0.Y + rectangle_0.Height; j++)
			{
				num2 += cells_0.GetRowHeightInch(j) * 72.0;
				double num3 = double_12;
				if (int_5 >= 0 && !method_18(int_5, method_21(arrayList_5, j), j))
				{
					num3 -= num;
				}
				if (num2 * double_1[1] - 0.0010000000474974513 > num3)
				{
					if (!arrayList_5.Contains(j))
					{
						arrayList_5.Add(j);
					}
					num2 = cells_0.GetRowHeightInch(j) * 72.0;
				}
			}
			arrayList_5.Sort();
			return;
		}
		for (int k = 0; k < worksheet_0.HorizontalPageBreaks.Count; k++)
		{
			HorizontalPageBreak horizontalPageBreak = worksheet_0.HorizontalPageBreaks[k];
			Rectangle rect = new Rectangle(horizontalPageBreak.StartColumn, horizontalPageBreak.Row, horizontalPageBreak.EndColumn - horizontalPageBreak.StartColumn, 0);
			if (rectangle_0.IntersectsWith(rect) && !arrayList_5.Contains(horizontalPageBreak.Row))
			{
				arrayList_5.Add(horizontalPageBreak.Row);
			}
		}
		arrayList_5.Sort();
		ArrayList arrayList = new ArrayList();
		for (int l = 0; l < arrayList_5.Count - 1; l++)
		{
			int int_ = (int)arrayList_5[l];
			int int_2 = (int)arrayList_5[l + 1];
			arrayList.AddRange(method_19(int_, int_2, pageSetup, double_12));
		}
		foreach (int item in arrayList)
		{
			if (!arrayList_5.Contains(item))
			{
				arrayList_5.Add(item);
			}
		}
		arrayList_5.Sort();
	}

	private int method_21(ArrayList arrayList_5, int int_10)
	{
		if (arrayList_5.Count == 2)
		{
			return (int)arrayList_5[0];
		}
		return (int)arrayList_5[arrayList_5.Count - 1];
	}

	private void method_22(ArrayList arrayList_5, ArrayList arrayList_6)
	{
		_ = worksheet_0.PageSetup;
		float num = 0f;
		int i = (int)arrayList_5[0];
		for (int j = 0; j < (int)arrayList_5[0]; j++)
		{
			num += (float)worksheet_0.Cells.GetRowHeightInch(j) * (float)double_1[0] * 72f;
		}
		arrayList_6.Add(num);
		for (int k = 1; k < arrayList_5.Count; k++)
		{
			for (int num2 = (int)arrayList_5[k]; i < num2; i++)
			{
				num += (float)worksheet_0.Cells.GetRowHeightInch(i) * (float)double_1[1] * 72f;
			}
			arrayList_6.Add(num);
		}
	}

	private void method_23(double double_12, ArrayList arrayList_5, Rectangle rectangle_0)
	{
		arrayList_5.Add(rectangle_0.X);
		arrayList_5.Add(rectangle_0.X + rectangle_0.Width);
		PageSetup pageSetup = worksheet_0.PageSetup;
		Cells cells = worksheet_0.Cells;
		double num = 0.0;
		double num2 = 0.0;
		if (imageOrPrintOptions_0 == null || !imageOrPrintOptions_0.OnePagePerSheet)
		{
			if (int_7 != -1)
			{
				for (int i = int_7; i <= int_8; i++)
				{
					num2 += cells_0.GetColumnWidthInch(i) * 72.0;
				}
				num2 *= double_1[0];
			}
			if (pageSetup.IsPercentScale || pageSetup.FitToPagesWide == 0)
			{
				int j = rectangle_0.X;
				int num3 = 0;
				for (; j < rectangle_0.X + rectangle_0.Width && j <= int_4; j++)
				{
					if (num3 < worksheet_0.VerticalPageBreaks.Count && worksheet_0.VerticalPageBreaks[num3].Column == j && pageSetup.IsPercentScale)
					{
						arrayList_5.Add(j);
						num = num2;
						num3++;
						continue;
					}
					double num4 = cells.GetColumnWidthInch(j) * 72.0 * double_1[0];
					num += num4;
					if (num - 0.009999999776482582 > double_12 && j > 0)
					{
						if (j < rectangle_0.X + rectangle_0.Width)
						{
							arrayList_5.Add(j);
						}
						num = num4;
						if (int_7 != -1 && int_7 < j)
						{
							num += num2;
						}
					}
				}
			}
			int num5 = pageSetup.FitToPagesWide;
			if (!pageSetup.IsPercentScale && num5 != 0)
			{
				double[] array = (double[])double_1.Clone();
				ArrayList arrayList;
				while (true)
				{
					arrayList = (ArrayList)arrayList_5.Clone();
					double num6 = 0.0;
					for (int k = rectangle_0.X; k < rectangle_0.X + rectangle_0.Width; k++)
					{
						num6 += cells_0.GetColumnWidthInch(k) * 72.0;
						double num7 = double_12;
						if (int_7 >= 0 && !method_18(int_7, method_21(arrayList, k), k))
						{
							if (!(num7 >= num2))
							{
								num6 = 0.0;
								for (int l = int_7; l <= int_8; l++)
								{
									num6 += cells_0.GetColumnWidthInch(l) * 72.0;
								}
								for (int m = rectangle_0.X; m < rectangle_0.X + rectangle_0.Width; m++)
								{
									num6 += cells_0.GetColumnWidthInch(m) * 72.0;
								}
								double_1[0] = double_12 / num6;
								double_1[1] = double_1[0];
								return;
							}
							num7 -= num2;
						}
						if (num6 * array[0] > num7)
						{
							if (!arrayList.Contains(k))
							{
								arrayList.Add(k);
							}
							num6 = cells_0.GetColumnWidthInch(k) * 72.0;
						}
					}
					if (arrayList.Count - 1 > num5)
					{
						array[0] *= 0.95;
						array[1] *= 0.95;
						continue;
					}
					if (!(array[0] < 0.1) || (imageOrPrintOptions_0 != null && imageOrPrintOptions_0.OnePagePerSheet))
					{
						break;
					}
					array = (double[])double_1.Clone();
					num5++;
				}
				double_1 = array;
				arrayList_5.Clear();
				arrayList_5.AddRange(arrayList);
				arrayList_5.Sort();
				return;
			}
		}
		arrayList_5.Sort();
	}

	private void method_24(ArrayList arrayList_5, ArrayList arrayList_6)
	{
		_ = worksheet_0.PageSetup;
		float num = 0f;
		for (int i = 0; i < (int)arrayList_5[0]; i++)
		{
			num += (float)worksheet_0.Cells.GetColumnWidthInch(i) * (float)double_1[0] * 72f;
		}
		arrayList_6.Add(num);
		int j = (int)arrayList_5[0];
		for (int k = 1; k < arrayList_5.Count; k++)
		{
			for (int num2 = (int)arrayList_5[k]; j < num2; j++)
			{
				num += (float)worksheet_0.Cells.GetColumnWidthInch(j) * (float)double_1[0] * 72f;
			}
			arrayList_6.Add(num);
		}
	}
}
