using System;
using System.Collections;
using System.Xml;
using Aspose.Cells;
using Aspose.Cells.Charts;
using Aspose.Cells.Drawing;
using ns2;
using ns22;
using ns26;

namespace ns15;

internal class Class1524
{
	private Class1499 class1499_0;

	private Worksheet worksheet_0;

	private Cells cells_0;

	private RowCollection rowCollection_0;

	private XmlTextWriter xmlTextWriter_0;

	private int int_0;

	private int int_1;

	private int int_2;

	private int int_3;

	private int int_4;

	private int int_5;

	private int int_6;

	private int int_7;

	private int int_8;

	private int int_9;

	private int int_10;

	internal Class1524(Class1499 class1499_1)
	{
		class1499_0 = class1499_1;
		worksheet_0 = class1499_1.worksheet_0;
		cells_0 = worksheet_0.Cells;
		rowCollection_0 = worksheet_0.Cells.Rows;
		int_6 = 0;
		int_5 = 0;
		PageSetup pageSetup = class1499_1.worksheet_0.PageSetup;
		Class1516.smethod_5(pageSetup, out int_1, out int_3);
		Class1516.smethod_4(pageSetup, out int_2, out int_4);
		method_0();
	}

	private void method_0()
	{
		int_9 = cells_0.method_20(0);
		int_10 = cells_0.method_22(0);
		for (int i = 0; i < cells_0.method_18().Count; i++)
		{
			CellArea cellArea = cells_0.method_18()[i];
			if (cellArea.EndColumn > int_10)
			{
				int_10 = cellArea.EndColumn;
			}
			if (cellArea.EndRow > int_9)
			{
				int_9 = cellArea.EndRow;
			}
		}
		for (int j = 0; j < worksheet_0.Hyperlinks.Count; j++)
		{
			Hyperlink hyperlink = worksheet_0.Hyperlinks[j];
			if (hyperlink.Area.StartColumn > int_10)
			{
				int_10 = hyperlink.Area.StartColumn;
			}
			if (hyperlink.Area.StartRow > int_9)
			{
				int_9 = hyperlink.Area.StartRow;
			}
		}
		if (worksheet_0.method_36() != null && worksheet_0.Shapes.Count > 0)
		{
			for (int k = 0; k < worksheet_0.Shapes.Count; k++)
			{
				Shape shape = worksheet_0.Shapes[k];
				if (shape.UpperLeftColumn > int_10)
				{
					int_10 = shape.UpperLeftColumn;
				}
				if (shape.UpperLeftRow > int_9)
				{
					int_9 = shape.UpperLeftRow;
				}
			}
		}
		int_8 = int_10;
		if (cells_0.Columns.Count > 0)
		{
			Column columnByIndex = cells_0.Columns.GetColumnByIndex(cells_0.Columns.Count - 1);
			if (columnByIndex.Index > int_8)
			{
				int_8 = columnByIndex.Index;
			}
		}
		int_7 = int_9;
		if (rowCollection_0.Count > 0)
		{
			Row rowByIndex = rowCollection_0.GetRowByIndex(rowCollection_0.Count - 1);
			if (rowByIndex.int_0 > int_7)
			{
				int_7 = rowByIndex.int_0;
			}
		}
	}

	internal void Write(XmlTextWriter xmlTextWriter_1)
	{
		xmlTextWriter_0 = xmlTextWriter_1;
		xmlTextWriter_1.WriteStartElement("table:table");
		xmlTextWriter_1.WriteAttributeString("table", "name", null, class1499_0.string_0);
		xmlTextWriter_1.WriteAttributeString("table", "style-name", null, "ta" + (class1499_0.worksheet_0.Index + 1));
		xmlTextWriter_1.WriteAttributeString("table", "print", null, class1499_0.string_1);
		string printArea = class1499_0.worksheet_0.PageSetup.PrintArea;
		if (printArea != null && printArea != "")
		{
			xmlTextWriter_1.WriteAttributeString("table", "print-ranges", null, Class1516.smethod_6(printArea, class1499_0.string_0));
		}
		xmlTextWriter_1.WriteStartElement("office:forms");
		xmlTextWriter_1.WriteAttributeString("form", "automatic-focus", null, "false");
		xmlTextWriter_1.WriteAttributeString("form", "apply-design-mode", null, "false");
		xmlTextWriter_1.WriteEndElement();
		method_2();
		method_8();
		xmlTextWriter_1.WriteEndElement();
	}

	private void method_1()
	{
		if (int_0 != 0)
		{
			for (int i = 0; i < int_0; i++)
			{
				xmlTextWriter_0.WriteEndElement();
			}
		}
		int_0 = 0;
	}

	private void method_2()
	{
		class1499_0.cells_0.method_22(0);
		ColumnCollection columns = class1499_0.cells_0.Columns;
		int num = -1;
		int num2;
		for (num2 = 0; num2 < columns.Count; num2++)
		{
			Column columnByIndex = columns.GetColumnByIndex(num2);
			if (columnByIndex.Index - num > 1)
			{
				method_1();
				method_3(num + 1, columnByIndex.Index - 1);
			}
			columnByIndex.method_5();
			int i;
			for (i = num2 + 1; i < columns.Count; i++)
			{
				Column columnByIndex2 = columns.GetColumnByIndex(i);
				if (columnByIndex2.Index - columnByIndex.Index != i - num2 || !columnByIndex.method_9(columnByIndex2))
				{
					break;
				}
			}
			method_12(num2, columnByIndex, i - num2);
			num = columnByIndex.Index + i - num2 - 1;
			num2 = i - 1;
		}
		method_1();
		if (columns.Count == 0)
		{
			method_3(0, 255);
		}
		else if (num < 255)
		{
			method_3(num + 1, 255);
		}
	}

	[Attribute0(true)]
	internal void method_3(int int_11, int int_12)
	{
		if (int_2 != -1)
		{
			int[] array = Class1516.Intersect(int_11, int_12, int_2, int_4);
			if (array != null)
			{
				if (array[0] != int_11)
				{
					method_4(array[0] - int_11);
				}
				xmlTextWriter_0.WriteStartElement("table:table-header-columns");
				method_4(array[1] - array[0] + 1);
				xmlTextWriter_0.WriteEndElement();
				if (array[1] != int_12)
				{
					method_4(int_12 - array[1]);
				}
				return;
			}
		}
		method_4(int_12 - int_11 + 1);
	}

	[Attribute0(true)]
	private void method_4(int int_11)
	{
		xmlTextWriter_0.WriteStartElement("table:table-column");
		xmlTextWriter_0.WriteAttributeString("table", "style-name", null, class1499_0.class1497_0.Name);
		xmlTextWriter_0.WriteAttributeString("table", "default-cell-style-name", null, "ce15");
		if (int_11 != 1)
		{
			xmlTextWriter_0.WriteAttributeString("table", "number-columns-repeated", null, Class1516.smethod_13(int_11));
		}
		xmlTextWriter_0.WriteEndElement();
	}

	private Class1492 method_5(Class1505 class1505_0, int int_11, int int_12)
	{
		Cell cell = null;
		if (int_6 < cells_0.Count)
		{
			cell = cells_0.GetCellByIndex(int_6);
			if (cell.Column == int_12 && cell.Row == int_11)
			{
				int_6++;
			}
			else
			{
				cell = null;
			}
		}
		ArrayList arrayList = class1499_0.method_16(int_11, int_12);
		if (arrayList != null)
		{
			Class1492 @class = new Class1492();
			@class.int_0 = int_11;
			@class.int_1 = int_12;
			@class.arrayList_0 = arrayList;
			return @class;
		}
		return null;
	}

	private bool method_6(Class1492 class1492_0, Row row_0, int int_11, int int_12)
	{
		Cell cell = null;
		if (int_6 < cells_0.Count)
		{
			cell = cells_0.GetCellByIndex(int_6);
			if (cell.Column != int_12 || cell.Row != int_11)
			{
				cell = null;
			}
		}
		if (cell != null && !cell.IsBlank)
		{
			return false;
		}
		int num = cell?.method_36() ?? (-1);
		if (num == -1)
		{
			if (row_0 != null && row_0.method_27())
			{
				num = row_0.method_10();
			}
			else
			{
				int num2 = cells_0.Columns.method_7(int_12);
				if (num2 != -1)
				{
					Column columnByIndex = cells_0.Columns.GetColumnByIndex(num2);
					num = columnByIndex.method_5();
				}
			}
		}
		if (class1492_0.int_3 != num)
		{
			return false;
		}
		Class1505 @class = class1499_0.method_17(int_11, int_12);
		if (@class != null)
		{
			return false;
		}
		ArrayList arrayList = class1499_0.method_16(int_11, int_12);
		if (arrayList != null)
		{
			return false;
		}
		Hyperlink hyperlink = method_30(int_11, int_12);
		if (hyperlink != null)
		{
			return false;
		}
		Comment comment = class1499_0.method_15(int_11, int_12);
		if (comment != null)
		{
			return false;
		}
		if (cell != null)
		{
			int_6++;
		}
		return true;
	}

	private Class1492 method_7(Row row_0, int int_11, int int_12)
	{
		Cell cell = null;
		if (int_6 < cells_0.Count)
		{
			cell = cells_0.GetCellByIndex(int_6);
			if (cell.Column == int_12 && cell.Row == int_11)
			{
				int_6++;
			}
			else
			{
				cell = null;
			}
		}
		Class1505 @class = class1499_0.method_17(int_11, int_12);
		ArrayList arrayList = class1499_0.method_16(int_11, int_12);
		Hyperlink hyperlink = null;
		Comment comment = null;
		if (@class == null || (@class.int_2 == int_12 && @class.int_0 == int_11))
		{
			hyperlink = method_30(int_11, int_12);
			comment = class1499_0.method_15(int_11, int_12);
		}
		if (cell == null && @class == null && arrayList == null && hyperlink == null && comment == null)
		{
			return null;
		}
		Class1492 class2 = new Class1492();
		class2.int_0 = int_11;
		class2.int_1 = int_12;
		class2.arrayList_0 = arrayList;
		class2.cell_0 = cell;
		class2.class1505_0 = @class;
		class2.hyperlink_0 = hyperlink;
		class2.comment_0 = comment;
		if (@class != null)
		{
			for (int_12++; int_12 <= @class.int_3; int_12++)
			{
				Class1492 class3 = method_5(@class, int_11, int_12);
				if (class3 != null)
				{
					if (class2.class1492_0 == null)
					{
						class2.class1492_0 = new Class1492[@class.int_3 - @class.int_2];
					}
					class2.class1492_0[int_12 - @class.int_2 - 1] = class3;
				}
			}
		}
		class2.int_3 = cell?.method_36() ?? (-1);
		if (class2.int_3 == -1)
		{
			if (row_0 != null && row_0.method_27())
			{
				class2.int_3 = row_0.method_10();
			}
			else
			{
				int num = cells_0.Columns.method_7(int_12);
				if (num != -1)
				{
					Column columnByIndex = cells_0.Columns.GetColumnByIndex(num);
					class2.int_3 = columnByIndex.method_5();
				}
			}
		}
		return class2;
	}

	private void method_8()
	{
		int int_ = -1;
		Workbook workbook = cells_0.method_19().Workbook;
		for (int i = 0; i <= int_7; i++)
		{
			workbook.method_30();
			bool flag = false;
			bool flag2 = int_1 != -1 && i >= int_1 && i <= int_3;
			Row row = null;
			if (int_5 < rowCollection_0.Count)
			{
				row = rowCollection_0.GetRowByIndex(int_5);
				if (row.int_0 == i)
				{
					int_5++;
				}
				else
				{
					row = null;
				}
			}
			if (flag2)
			{
				StartRow(int_, i, row, flag2);
				flag = true;
				int_ = i;
			}
			else if (row != null && row.int_0 == i)
			{
				if (i > int_9 && row.GroupLevel == 0)
				{
					continue;
				}
				StartRow(int_, i, row, flag2);
				flag = true;
				int_ = i;
			}
			else
			{
				row = null;
			}
			Class1492 @class = null;
			if (i <= int_9)
			{
				for (int j = 0; j <= int_10; j++)
				{
					Class1492 class2 = method_7(row, i, j);
					if (class2 == null)
					{
						continue;
					}
					if (!flag)
					{
						StartRow(int_, i, row, flag2);
						flag = true;
						int_ = i;
					}
					int num = @class?.EndColumn ?? (-1);
					if (j != num + 1)
					{
						method_15(row?.method_10() ?? 15, j - num - 1);
					}
					if (class2.method_1())
					{
						for (int k = j + 1; k <= int_10 && method_6(class2, row, i, k); k++)
						{
							class2.int_2++;
						}
					}
					method_9(row, class2, i, j);
					j = class2.EndColumn;
					@class = class2;
				}
			}
			if (!flag)
			{
				continue;
			}
			if (@class != null && 255 > @class.EndColumn)
			{
				if (row != null && row.method_10() != 15)
				{
					method_15(row.method_10(), (@class == null) ? 256 : (255 - @class.EndColumn));
				}
				else if (class1499_0.bool_0)
				{
					method_15(15, (@class == null) ? 256 : (255 - @class.EndColumn));
				}
			}
			if (flag2)
			{
				xmlTextWriter_0.WriteEndElement();
			}
			xmlTextWriter_0.WriteEndElement();
		}
		method_1();
		if (class1499_0.bool_0 && int_7 != 65535)
		{
			method_27(65535 - int_7);
		}
	}

	[Attribute0(true)]
	private bool StartRow(int int_11, int int_12, Row row_0, bool bool_0)
	{
		if (int_12 != int_11 + 1)
		{
			method_1();
			method_27(int_12 - int_11 - 1);
		}
		if (row_0 == null)
		{
			method_1();
			if (bool_0)
			{
				xmlTextWriter_0.WriteStartElement("table:table-header-rows");
			}
			xmlTextWriter_0.WriteStartElement("table:table-row");
			if (class1499_0.class1503_0 != null && class1499_0.class1503_0.Name != null)
			{
				xmlTextWriter_0.WriteAttributeString("table", "style-name", null, class1499_0.class1503_0.Name);
			}
			return bool_0;
		}
		method_28(int_5, row_0);
		if (bool_0)
		{
			xmlTextWriter_0.WriteStartElement("table:table-header-rows");
		}
		xmlTextWriter_0.WriteStartElement("table:table-row");
		xmlTextWriter_0.WriteAttributeString("table", "style-name", null, class1499_0.method_1(int_12));
		if (row_0.IsHidden)
		{
			xmlTextWriter_0.WriteAttributeString("table", "visibility", null, "collapse");
		}
		return bool_0;
	}

	private void method_9(Row row_0, Class1492 class1492_0, int int_11, int int_12)
	{
		if (class1492_0.method_0())
		{
			method_11(class1492_0);
			return;
		}
		Cell cell_ = class1492_0.cell_0;
		xmlTextWriter_0.WriteStartElement("table:table-cell");
		if (class1492_0.int_2 > 1)
		{
			xmlTextWriter_0.WriteAttributeString("table", "number-columns-repeated", null, Class1516.smethod_13(class1492_0.int_2));
		}
		if (cell_ != null)
		{
			CellValueType cellValueType = cell_.Type;
			if (cellValueType == CellValueType.IsDateTime && cell_.DoubleValue < 0.0)
			{
				cellValueType = CellValueType.IsNumeric;
			}
			if (class1492_0.int_2 != 1)
			{
				xmlTextWriter_0.WriteAttributeString("table", "style-name", null, "ce" + cell_.method_35());
			}
			else if (cell_.method_36() != -1 && cell_.method_36() != 15)
			{
				xmlTextWriter_0.WriteAttributeString("table", "style-name", null, "ce" + cell_.method_35());
			}
			else if (cell_.method_36() == 15)
			{
				if (row_0 != null && row_0.method_27())
				{
					xmlTextWriter_0.WriteAttributeString("table", "style-name", null, "ce15");
				}
				else
				{
					int num = cells_0.Columns.method_7(int_12);
					if (num != -1)
					{
						int num2 = cells_0.Columns.GetColumnByIndex(num).method_5();
						if (num2 != -1 && num2 != 15)
						{
							xmlTextWriter_0.WriteAttributeString("table", "style-name", null, "ce15");
						}
					}
				}
			}
			if (cell_.IsFormula)
			{
				if (cell_.IsInArray)
				{
					if (cell_.IsArrayHeader)
					{
						xmlTextWriter_0.WriteAttributeString("table", "formula", null, "oooc:" + class1499_0.class1498_0.method_0(cell_));
						Class1348 @class = cell_.method_50();
						int num3 = @class.CellArea.EndColumn - @class.CellArea.StartColumn + 1;
						int num4 = @class.CellArea.EndRow - @class.CellArea.StartRow + 1;
						xmlTextWriter_0.WriteAttributeString("table", "number-matrix-columns-spanned", null, Class1516.smethod_13(num3));
						xmlTextWriter_0.WriteAttributeString("table", "number-matrix-rows-spanned", null, Class1516.smethod_13(num4));
					}
				}
				else
				{
					xmlTextWriter_0.WriteAttributeString("table", "formula", null, "oooc:" + class1499_0.class1498_0.method_0(cell_));
				}
			}
			if (class1492_0.class1505_0 != null)
			{
				xmlTextWriter_0.WriteAttributeString("table", "number-columns-spanned", null, Class1516.smethod_13(class1492_0.class1505_0.int_3 - class1492_0.class1505_0.int_2 + 1));
				xmlTextWriter_0.WriteAttributeString("table", "number-rows-spanned", null, Class1516.smethod_13(class1492_0.class1505_0.int_1 - class1492_0.class1505_0.int_0 + 1));
			}
			Hyperlink hyperlink_ = class1492_0.hyperlink_0;
			if (cell_.Type != CellValueType.IsNull)
			{
				bool flag = true;
				Enum214 @enum = class1499_0.class1498_0.enum214_0[cell_.method_35()];
				switch (cellValueType)
				{
				case CellValueType.IsBool:
					xmlTextWriter_0.WriteAttributeString("office", "value-type", null, "boolean");
					xmlTextWriter_0.WriteAttributeString("office", "boolean-value", null, cell_.BoolValue ? "true" : "false");
					break;
				case CellValueType.IsDateTime:
					switch (@enum)
					{
					default:
						xmlTextWriter_0.WriteAttributeString("office", "value-type", null, "date");
						xmlTextWriter_0.WriteAttributeString("office", "date-value", null, cell_.DateTimeValue.ToString("yyyy-MM-dd'T'HH:mm:ss"));
						break;
					case Enum214.const_1:
						xmlTextWriter_0.WriteAttributeString("office", "value-type", null, "float");
						xmlTextWriter_0.WriteAttributeString("office", "value", null, Class1516.smethod_15(cell_.DoubleValue));
						break;
					case Enum214.const_2:
						xmlTextWriter_0.WriteAttributeString("office", "value-type", null, "date");
						xmlTextWriter_0.WriteAttributeString("office", "date-value", null, cell_.DateTimeValue.ToString("yyyy-MM-dd'T'HH:mm:ss"));
						break;
					case Enum214.const_3:
						xmlTextWriter_0.WriteAttributeString("office", "value-type", null, "time");
						xmlTextWriter_0.WriteAttributeString("office", "time-value", null, Class1516.smethod_21(cell_.DoubleValue));
						break;
					}
					break;
				default:
					xmlTextWriter_0.WriteAttributeString("office", "value-type", null, "string");
					xmlTextWriter_0.WriteAttributeString("office", "value", null, cell_.Value.ToString());
					break;
				case CellValueType.IsNumeric:
					switch (@enum)
					{
					default:
						xmlTextWriter_0.WriteAttributeString("office", "value-type", null, "float");
						xmlTextWriter_0.WriteAttributeString("office", "value", null, Class1516.smethod_15(cell_.DoubleValue));
						break;
					case Enum214.const_6:
						xmlTextWriter_0.WriteAttributeString("office", "value-type", null, "percentage");
						xmlTextWriter_0.WriteAttributeString("office", "value", null, Class1516.smethod_15(cell_.DoubleValue));
						break;
					case Enum214.const_0:
						xmlTextWriter_0.WriteAttributeString("office", "value-type", null, "currency");
						xmlTextWriter_0.WriteAttributeString("office", "value", null, Class1516.smethod_15(cell_.DoubleValue));
						break;
					}
					break;
				case CellValueType.IsString:
					xmlTextWriter_0.WriteAttributeString("office", "value-type", null, "string");
					if (!cell_.IsRichText())
					{
						if (hyperlink_ != null)
						{
							xmlTextWriter_0.WriteAttributeString("office", "value", null, cell_.Value.ToString());
						}
					}
					else
					{
						method_14(cell_);
						flag = false;
					}
					break;
				}
				if (flag)
				{
					Formatting formatting = xmlTextWriter_0.Formatting;
					xmlTextWriter_0.Formatting = Formatting.None;
					xmlTextWriter_0.WriteStartElement("text:p");
					if (hyperlink_ == null)
					{
						xmlTextWriter_0.WriteString(cell_.StringValue);
					}
					else
					{
						xmlTextWriter_0.WriteStartElement("text:a");
						int num5 = hyperlink_.method_5(class1499_0.worksheet_0.method_2());
						string text = hyperlink_.Address;
						if (num5 == 2)
						{
							text = "#" + text.Replace('!', '.');
						}
						xmlTextWriter_0.WriteAttributeString("xlink", "href", null, text);
						xmlTextWriter_0.WriteString(cell_.StringValue);
						xmlTextWriter_0.WriteEndElement();
					}
					xmlTextWriter_0.WriteEndElement();
					xmlTextWriter_0.Formatting = formatting;
				}
			}
		}
		else
		{
			if (class1492_0.class1505_0 != null)
			{
				xmlTextWriter_0.WriteAttributeString("table", "number-columns-spanned", null, Class1516.smethod_13(class1492_0.class1505_0.int_3 - class1492_0.class1505_0.int_2 + 1));
				xmlTextWriter_0.WriteAttributeString("table", "number-rows-spanned", null, Class1516.smethod_13(class1492_0.class1505_0.int_1 - class1492_0.class1505_0.int_0 + 1));
			}
			int num6 = cells_0.method_41(null, int_11, int_12);
			if (num6 != -1 && num6 != 15)
			{
				xmlTextWriter_0.WriteAttributeString("table", "style-name", null, "ce" + num6);
			}
		}
		if (class1492_0.comment_0 != null)
		{
			method_29(class1492_0.comment_0);
		}
		method_18(class1492_0);
		xmlTextWriter_0.WriteEndElement();
		method_10(class1492_0);
	}

	private void method_10(Class1492 class1492_0)
	{
		if (class1492_0.class1505_0 == null || class1492_0.class1505_0.int_2 == class1492_0.class1505_0.int_3)
		{
			return;
		}
		if (class1492_0.class1492_0 == null)
		{
			method_17(class1492_0.class1505_0.int_3 - class1492_0.class1505_0.int_2);
			return;
		}
		int num = class1492_0.int_1;
		for (int i = 0; i < class1492_0.class1492_0.Length; i++)
		{
			if (class1492_0.class1492_0[i] != null)
			{
				if (class1492_0.class1492_0[i].int_1 != num + 1)
				{
					method_17(class1492_0.class1492_0[i].int_1 - num - 1);
					num = class1492_0.class1492_0[i].int_1;
				}
				method_16(class1492_0.class1492_0[i]);
			}
		}
		if (num != class1492_0.class1505_0.int_3)
		{
			method_17(class1492_0.class1505_0.int_3 - num - 1);
		}
	}

	private void method_11(Class1492 class1492_0)
	{
		int num = class1492_0.int_1 - 1;
		if (class1492_0.arrayList_0 != null && class1492_0.arrayList_0.Count > 0)
		{
			method_16(class1492_0);
			num++;
		}
		if (class1492_0.class1492_0 == null)
		{
			int num2 = class1492_0.class1505_0.int_3 - class1492_0.class1505_0.int_2;
			if (num == class1492_0.int_1 - 1)
			{
				num2++;
			}
			method_17(num2);
			return;
		}
		for (int i = 0; i < class1492_0.class1492_0.Length; i++)
		{
			if (class1492_0.class1492_0[i] != null)
			{
				if (class1492_0.class1492_0[i].int_1 != num + 1)
				{
					method_17(class1492_0.class1492_0[i].int_1 - num - 1);
				}
				method_16(class1492_0.class1492_0[i]);
				num = class1492_0.class1492_0[i].int_1;
			}
		}
		if (num != class1492_0.class1505_0.int_3)
		{
			method_17(class1492_0.class1505_0.int_3 - num - 1);
		}
	}

	[Attribute0(true)]
	internal void method_12(int int_11, Column column_0, int int_12)
	{
		if (column_0.method_3() == 0)
		{
			for (int i = 0; i < int_0; i++)
			{
				xmlTextWriter_0.WriteEndElement();
			}
			int_0 = 0;
		}
		else if (int_11 != 0)
		{
			Column columnByIndex = class1499_0.worksheet_0.Cells.Columns.GetColumnByIndex(int_11 - 1);
			if (columnByIndex.Index + 1 == column_0.Index)
			{
				if (columnByIndex.method_3() > column_0.method_3())
				{
					xmlTextWriter_0.WriteEndElement();
					int_0--;
				}
				else if (columnByIndex.method_3() < column_0.method_3())
				{
					for (int j = columnByIndex.method_3(); j < column_0.method_3(); j++)
					{
						xmlTextWriter_0.WriteStartElement("table:table-column-group");
						int_0++;
					}
				}
			}
			else
			{
				method_1();
				for (int k = 0; k < column_0.method_3(); k++)
				{
					xmlTextWriter_0.WriteStartElement("table:table-column-group");
					int_0++;
				}
			}
		}
		else
		{
			for (int l = 0; l < column_0.method_3(); l++)
			{
				xmlTextWriter_0.WriteStartElement("table:table-column-group");
				int_0++;
			}
		}
		if (int_2 != -1)
		{
			int index = column_0.Index;
			int[] array = Class1516.Intersect(index, index + int_12 - 1, int_2, int_4);
			if (array != null)
			{
				if (array[0] != index)
				{
					method_13(column_0, array[0] - index);
				}
				xmlTextWriter_0.WriteStartElement("table:table-header-columns");
				method_13(column_0, array[1] - array[0] + 1);
				xmlTextWriter_0.WriteEndElement();
				if (array[1] != index + int_12 - 1)
				{
					method_13(column_0, index + int_12 - array[1]);
				}
				return;
			}
		}
		method_13(column_0, int_12);
	}

	[Attribute0(true)]
	private void method_13(Column column_0, int int_11)
	{
		xmlTextWriter_0.WriteStartElement("table:table-column");
		string value = class1499_0.method_2(column_0.Index);
		xmlTextWriter_0.WriteAttributeString("table", "style-name", null, value);
		if (int_11 != 1)
		{
			xmlTextWriter_0.WriteAttributeString("table", "number-columns-repeated", null, Class1516.smethod_13(int_11));
		}
		int num = column_0.method_5();
		xmlTextWriter_0.WriteAttributeString("table", "default-cell-style-name", null, "ce" + Class1516.smethod_13(num));
		if (column_0.IsHidden)
		{
			xmlTextWriter_0.WriteAttributeString("table", "visibility", null, "collapse");
		}
		xmlTextWriter_0.WriteEndElement();
	}

	private void method_14(Cell cell_0)
	{
		Class1720 @class = (Class1720)cell_0.method_57();
		string string_ = @class.string_0;
		byte[] array = @class.method_2();
		Formatting formatting = xmlTextWriter_0.Formatting;
		xmlTextWriter_0.Formatting = Formatting.None;
		xmlTextWriter_0.WriteStartElement("text:p");
		for (int i = 0; i < array.Length; i += 4)
		{
			int num = BitConverter.ToUInt16(array, i);
			int num2 = BitConverter.ToUInt16(array, i + 2);
			if (i == 0 && num > 0)
			{
				xmlTextWriter_0.WriteString(string_.Substring(0, num));
			}
			if (num >= string_.Length)
			{
				break;
			}
			string text = null;
			if (i + 4 >= array.Length)
			{
				text = string_.Substring(num);
			}
			else
			{
				int num3 = BitConverter.ToUInt16(array, i + 4);
				if (num3 >= string_.Length)
				{
					text = string_.Substring(num);
					i = array.Length;
				}
				else
				{
					text = string_.Substring(num, num3 - num);
				}
			}
			xmlTextWriter_0.WriteStartElement("text:span");
			xmlTextWriter_0.WriteAttributeString("text", "style-name", null, "T" + num2);
			xmlTextWriter_0.WriteString(text);
			xmlTextWriter_0.WriteEndElement();
		}
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.Formatting = formatting;
	}

	[Attribute0(true)]
	private void method_15(int int_11, int int_12)
	{
		xmlTextWriter_0.WriteStartElement("table:table-cell");
		if (int_12 != 1)
		{
			xmlTextWriter_0.WriteAttributeString("table", "number-columns-repeated", null, Class1516.smethod_13(int_12));
		}
		if (int_11 != 15)
		{
			xmlTextWriter_0.WriteAttributeString("table", "style-name", null, "ce" + Class1516.smethod_13(int_11));
		}
		xmlTextWriter_0.WriteEndElement();
	}

	private void method_16(Class1492 class1492_0)
	{
		xmlTextWriter_0.WriteStartElement("table:covered-table-cell");
		method_18(class1492_0);
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_17(int int_11)
	{
		xmlTextWriter_0.WriteStartElement("table:covered-table-cell");
		if (int_11 != 1)
		{
			xmlTextWriter_0.WriteAttributeString("table", "number-columns-repeated", null, Class1516.smethod_13(int_11));
		}
		xmlTextWriter_0.WriteEndElement();
	}

	private void method_18(Class1492 class1492_0)
	{
		if (class1492_0.arrayList_0 == null || class1492_0.arrayList_0.Count == 0 || class1492_0.arrayList_0 == null || class1492_0.arrayList_0.Count <= 0)
		{
			return;
		}
		foreach (Class1493 item in class1492_0.arrayList_0)
		{
			Shape shape_ = item.shape_0;
			switch (shape_.MsoDrawingType)
			{
			case MsoDrawingType.Chart:
				method_19((ChartShape)shape_, "frame");
				break;
			default:
				method_22(item, Class1515.smethod_6(item.shape_0.AutoShapeType));
				break;
			case MsoDrawingType.TextBox:
			case MsoDrawingType.Picture:
			case MsoDrawingType.OleObject:
				method_22(item, "frame");
				break;
			}
		}
	}

	private void method_19(ChartShape chartShape_0, string string_0)
	{
		xmlTextWriter_0.WriteStartElement("draw:" + string_0);
		int num = worksheet_0.Index + chartShape_0.Index;
		int num2 = num + 1;
		xmlTextWriter_0.WriteAttributeString("table", "end-cell-address", null, chartShape_0.method_26().Name + "." + CellsHelper.CellIndexToName(chartShape_0.LowerRightRow, chartShape_0.LowerRightColumn));
		double leftCM = chartShape_0.LeftCM;
		double topCM = chartShape_0.TopCM;
		_ = chartShape_0.Right;
		_ = chartShape_0.Bottom;
		xmlTextWriter_0.WriteAttributeString("svg", "x", null, Class1516.smethod_49(leftCM) + "cm");
		xmlTextWriter_0.WriteAttributeString("svg", "y", null, Class1516.smethod_49(topCM) + "cm");
		xmlTextWriter_0.WriteAttributeString("svg", "width", null, Class1516.smethod_49(chartShape_0.WidthCM) + "cm");
		xmlTextWriter_0.WriteAttributeString("svg", "height", null, Class1516.smethod_49(chartShape_0.HeightCM) + "cm");
		xmlTextWriter_0.WriteAttributeString("draw", "z-index", null, Class1516.smethod_13(chartShape_0.ZOrderPosition));
		xmlTextWriter_0.WriteAttributeString("draw", "name", null, chartShape_0.Name);
		xmlTextWriter_0.WriteAttributeString("draw", "style-name", null, "gr" + Class1516.smethod_13(num2));
		if (string_0 == "frame")
		{
			method_20(chartShape_0);
			method_21(chartShape_0);
		}
		xmlTextWriter_0.WriteEndElement();
	}

	private void method_20(ChartShape chartShape_0)
	{
		xmlTextWriter_0.WriteStartElement("draw:object");
		xmlTextWriter_0.WriteAttributeString("draw", "notify-on-update-of-ranges", null, method_25(chartShape_0.Chart.NSeries));
		xmlTextWriter_0.WriteAttributeString("xlink", "href", null, "./Object " + Class1516.smethod_50(chartShape_0));
		xmlTextWriter_0.WriteAttributeString("xlink", "type", null, "simple");
		xmlTextWriter_0.WriteAttributeString("xlink", "show", null, "embed");
		xmlTextWriter_0.WriteAttributeString("xlink", "actuate", null, "onLoad");
		xmlTextWriter_0.WriteEndElement();
	}

	private void method_21(ChartShape chartShape_0)
	{
		xmlTextWriter_0.WriteStartElement("draw:image");
		xmlTextWriter_0.WriteAttributeString("xlink", "href", null, "./ObjectReplacements/Object " + Class1516.smethod_50(chartShape_0));
		xmlTextWriter_0.WriteAttributeString("xlink", "show", null, "embed");
		xmlTextWriter_0.WriteAttributeString("xlink", "actuate", null, "onLoad");
		xmlTextWriter_0.WriteEndElement();
	}

	private void method_22(Class1493 class1493_0, string string_0)
	{
		Shape shape_ = class1493_0.shape_0;
		xmlTextWriter_0.WriteStartElement("draw:" + string_0);
		int num = worksheet_0.Index + shape_.Index;
		int num2 = num + 1;
		xmlTextWriter_0.WriteAttributeString("draw", "style-name", null, "S" + Class1516.smethod_13(num2));
		xmlTextWriter_0.WriteAttributeString("draw", "id", null, "id" + Class1516.smethod_13(num));
		xmlTextWriter_0.WriteAttributeString("draw", "z-index", null, Class1516.smethod_13(shape_.ZOrderPosition));
		if (shape_.MsoDrawingType == MsoDrawingType.TextBox)
		{
			xmlTextWriter_0.WriteAttributeString("xmlns", "presentation", null, "urn:oasis:names:tc:opendocument:xmlns:presentation:1.0");
		}
		xmlTextWriter_0.WriteAttributeString("draw", "name", null, shape_.Name);
		xmlTextWriter_0.WriteAttributeString("svg", "x", null, Class1516.smethod_42(class1493_0.shape_0.method_25().method_75(), (int)class1493_0.double_0));
		xmlTextWriter_0.WriteAttributeString("svg", "y", null, Class1516.smethod_42(class1493_0.shape_0.method_25().method_75(), (int)class1493_0.double_1));
		xmlTextWriter_0.WriteAttributeString("svg", "width", null, Class1516.smethod_42(class1493_0.shape_0.method_25().method_75(), (int)class1493_0.double_3));
		xmlTextWriter_0.WriteAttributeString("svg", "height", null, Class1516.smethod_42(class1493_0.shape_0.method_25().method_75(), (int)class1493_0.double_2));
		if (string_0 == "frame")
		{
			switch (shape_.MsoDrawingType)
			{
			case MsoDrawingType.OleObject:
				method_24(shape_);
				method_26(shape_, bool_0: false);
				break;
			case MsoDrawingType.TextBox:
				method_23(shape_);
				break;
			case MsoDrawingType.Picture:
				method_26(shape_, bool_0: true);
				break;
			}
		}
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_23(Shape shape_0)
	{
		xmlTextWriter_0.WriteStartElement("draw:text-box");
		Class1737 @class = shape_0.method_63();
		Class1510.smethod_0(xmlTextWriter_0, @class, "T" + Class1516.smethod_13(@class.method_8()));
		xmlTextWriter_0.WriteEndElement();
	}

	private void method_24(Shape shape_0)
	{
		xmlTextWriter_0.WriteStartElement("draw:object-ole");
		OleObject oleObject = (OleObject)shape_0;
		xmlTextWriter_0.WriteAttributeString("draw", "class-id", null, oleObject.method_99().ToString());
		string value = "MSO_OLE_OBJ" + Class1025.smethod_7(oleObject.method_97());
		xmlTextWriter_0.WriteAttributeString("xlink", "href", null, value);
		xmlTextWriter_0.WriteAttributeString("xlink", "show", null, "embed");
		xmlTextWriter_0.WriteAttributeString("xlink", "actuate", null, "onLoad");
		xmlTextWriter_0.WriteEndElement();
	}

	private string method_25(SeriesCollection seriesCollection_0)
	{
		string text = "";
		string text2 = "";
		for (int i = 0; i < seriesCollection_0.Count; i++)
		{
			if (seriesCollection_0[i].Values.IndexOf("$") < 0)
			{
				_ = text2 + seriesCollection_0[i].Values.Replace("{", "").Replace("}", "");
				text += seriesCollection_0[i].Values;
				text2 = ",";
				continue;
			}
			string text3 = seriesCollection_0[i].Values.Substring(1).Replace("$", "");
			string[] array = text3.Split('!');
			string text4 = array[0];
			string[] array2 = array[1].Split(':');
			if (array2.Length == 1)
			{
				string text5 = text;
				text = text5 + text4 + "." + array2[0] + ":" + text4 + "." + array2[0] + " ";
			}
			else
			{
				string text6 = text;
				text = text6 + text4 + "." + array2[0] + ":" + text4 + "." + array2[1] + " ";
			}
		}
		return text;
	}

	private void method_26(Shape shape_0, bool bool_0)
	{
		xmlTextWriter_0.WriteStartElement("draw:image");
		if (bool_0)
		{
			Picture picture = (Picture)shape_0;
			xmlTextWriter_0.WriteAttributeString("xlink", "href", null, "Pictures/" + picture.method_70() + "." + picture.ImageFormat);
		}
		else
		{
			OleObject oleObject = (OleObject)shape_0;
			xmlTextWriter_0.WriteAttributeString("xlink", "href", null, "ObjectReplacements/Object " + oleObject.method_75());
		}
		xmlTextWriter_0.WriteAttributeString("xlink", "show", null, "embed");
		xmlTextWriter_0.WriteAttributeString("xlink", "actuate", null, "onLoad");
		Class1737 @class = shape_0.method_63();
		Class1510.smethod_0(xmlTextWriter_0, @class, "T" + Class1516.smethod_13(@class.method_8()));
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_27(int int_11)
	{
		xmlTextWriter_0.WriteStartElement("table:table-row");
		xmlTextWriter_0.WriteAttributeString("table", "number-rows-repeated", null, Class1516.smethod_13(int_11));
		xmlTextWriter_0.WriteAttributeString("table", "style-name", null, class1499_0.class1503_0.Name);
		if (class1499_0.bool_0)
		{
			method_15(15, 256);
		}
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_28(int int_11, Row row_0)
	{
		if (row_0.method_24() == 0)
		{
			method_1();
		}
		else if (int_11 > 1)
		{
			Row rowByIndex = class1499_0.worksheet_0.Cells.Rows.GetRowByIndex(int_11 - 2);
			if (rowByIndex.int_0 + 1 == row_0.int_0)
			{
				if (rowByIndex.method_24() > row_0.method_24())
				{
					xmlTextWriter_0.WriteEndElement();
					int_0--;
				}
				else if (rowByIndex.method_24() < row_0.method_24())
				{
					for (int i = rowByIndex.method_24(); i < row_0.method_24(); i++)
					{
						xmlTextWriter_0.WriteStartElement("table:table-row-group");
						int_0++;
					}
				}
			}
			else
			{
				method_1();
				for (int j = 0; j < row_0.method_24(); j++)
				{
					xmlTextWriter_0.WriteStartElement("table:table-row-group");
					int_0++;
				}
			}
		}
		else
		{
			for (int k = 0; k < row_0.method_24(); k++)
			{
				xmlTextWriter_0.WriteStartElement("table:table-row-group");
				int_0++;
			}
		}
	}

	[Attribute0(true)]
	private void method_29(Comment comment_0)
	{
		string text = "";
		xmlTextWriter_0.WriteStartElement("office:annotation");
		CommentShape commentShape = comment_0.CommentShape;
		PlacementType placement = commentShape.Placement;
		commentShape.Placement = PlacementType.FreeFloating;
		xmlTextWriter_0.WriteAttributeString("office", "display", null, comment_0.IsVisible ? "true" : "false");
		xmlTextWriter_0.WriteAttributeString("draw", "text-style-name", null, text);
		xmlTextWriter_0.WriteAttributeString("svg", "width", null, Class1516.smethod_42(commentShape.method_25().method_75(), commentShape.method_27().method_7().Right));
		xmlTextWriter_0.WriteAttributeString("svg", "height", null, Class1516.smethod_42(commentShape.method_25().method_75(), commentShape.method_27().method_7().Bottom));
		xmlTextWriter_0.WriteAttributeString("svg", "x", null, Class1516.smethod_42(commentShape.method_25().method_75(), commentShape.method_27().method_7().Left));
		xmlTextWriter_0.WriteAttributeString("svg", "y", null, Class1516.smethod_42(commentShape.method_25().method_75(), commentShape.method_27().method_7().Top));
		Class1510.smethod_0(xmlTextWriter_0, comment_0.method_2(), text);
		commentShape.Placement = placement;
		xmlTextWriter_0.WriteEndElement();
	}

	private Hyperlink method_30(int int_11, int int_12)
	{
		HyperlinkCollection hyperlinks = class1499_0.worksheet_0.Hyperlinks;
		int num = 0;
		Hyperlink hyperlink;
		while (true)
		{
			if (num < hyperlinks.Count)
			{
				hyperlink = hyperlinks[num];
				if (hyperlink.Area.StartRow <= int_11 && hyperlink.Area.EndRow >= int_11 && hyperlink.Area.StartColumn <= int_12 && hyperlink.Area.EndColumn >= int_12)
				{
					break;
				}
				num++;
				continue;
			}
			return null;
		}
		return hyperlink;
	}
}
