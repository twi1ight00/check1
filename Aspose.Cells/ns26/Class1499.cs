using System.Collections;
using Aspose.Cells;
using Aspose.Cells.Drawing;

namespace ns26;

internal class Class1499
{
	internal Class1503 class1503_0;

	internal Class1497 class1497_0;

	internal Class1503 class1503_1;

	internal Class1497 class1497_1;

	internal ArrayList arrayList_0;

	internal ArrayList arrayList_1;

	internal Hashtable hashtable_0;

	internal Hashtable hashtable_1;

	internal Worksheet worksheet_0;

	internal Cells cells_0;

	internal Class1498 class1498_0;

	internal string string_0;

	internal string string_1;

	internal ArrayList arrayList_2;

	internal bool bool_0;

	internal bool bool_1;

	internal ArrayList[] arrayList_3;

	internal ArrayList[] arrayList_4;

	internal ArrayList[] arrayList_5;

	internal ArrayList[] arrayList_6;

	internal ArrayList arrayList_7;

	internal Class1499(Class1498 class1498_1, Worksheet worksheet_1)
	{
		class1498_0 = class1498_1;
		worksheet_0 = worksheet_1;
		string_0 = method_0(worksheet_1.Name);
		cells_0 = worksheet_1.Cells;
		hashtable_0 = new Hashtable();
		hashtable_1 = new Hashtable();
		class1503_0 = new Class1503(cells_0, class1498_1.arrayList_2.Count + 1);
		class1498_1.arrayList_2.Add(class1503_0);
		class1503_0.Name = "ro" + class1498_0.arrayList_2.Count;
		class1497_0 = new Class1497(cells_0, class1498_1.arrayList_1.Count + 1);
		class1498_1.arrayList_1.Add(class1497_0);
		class1497_0.Name = "co" + class1498_1.arrayList_1.Count;
		string_1 = "false";
		worksheet_1.method_7(string_0);
	}

	private string method_0(string string_2)
	{
		char[] array = string_2.ToCharArray();
		for (int i = 0; i < array.Length; i++)
		{
			switch (i)
			{
			case 33:
			case 34:
			case 35:
			case 36:
			case 37:
			case 38:
			case 39:
			case 40:
			case 41:
			case 42:
			case 43:
			case 44:
			case 45:
			case 46:
			case 47:
			case 58:
			case 59:
			case 60:
			case 61:
			case 62:
			case 63:
			case 64:
			case 91:
			case 92:
			case 93:
			case 94:
			case 96:
			case 123:
			case 124:
			case 125:
			case 126:
				array[i] = '_';
				break;
			}
		}
		return new string(array);
	}

	internal string method_1(int int_0)
	{
		object obj = hashtable_1[int_0];
		if (obj != null)
		{
			return (string)obj;
		}
		return class1503_0.Name;
	}

	internal string method_2(int int_0)
	{
		object obj = hashtable_0[int_0];
		if (obj != null)
		{
			return (string)obj;
		}
		return class1497_0.Name;
	}

	internal void method_3(Class1498 class1498_1)
	{
		method_5(cells_0.Rows);
		method_6(cells_0.Columns);
		method_7();
		method_9();
		method_8();
		method_4(class1498_1);
	}

	internal void method_4(Class1498 class1498_1)
	{
		if (worksheet_0.HorizontalPageBreaks != null && worksheet_0.HorizontalPageBreaks.Count > 0)
		{
			class1503_1 = new Class1503(cells_0, class1498_1.arrayList_2.Count + 1);
			class1503_1.method_3(Enum212.const_2);
			class1498_1.arrayList_2.Add(class1503_1);
			int count = worksheet_0.HorizontalPageBreaks.Count;
			arrayList_0 = new ArrayList();
			for (int i = 0; i < count; i++)
			{
				HorizontalPageBreak horizontalPageBreak = worksheet_0.HorizontalPageBreaks[i];
				if (horizontalPageBreak != null)
				{
					arrayList_0.Add(horizontalPageBreak.Row);
				}
			}
		}
		if (worksheet_0.VerticalPageBreaks == null || worksheet_0.VerticalPageBreaks.Count <= 0)
		{
			return;
		}
		class1497_1 = new Class1497(cells_0, class1498_1.arrayList_1.Count + 1);
		class1497_1.method_1(Enum212.const_2);
		class1498_1.arrayList_1.Add(class1497_1);
		int count2 = worksheet_0.VerticalPageBreaks.Count;
		arrayList_1 = new ArrayList();
		for (int j = 0; j < count2; j++)
		{
			VerticalPageBreak verticalPageBreak = worksheet_0.VerticalPageBreaks[j];
			if (verticalPageBreak != null)
			{
				arrayList_1.Add(verticalPageBreak.Column);
			}
		}
	}

	internal void method_5(RowCollection rowCollection_0)
	{
		foreach (Row item in rowCollection_0)
		{
			double double_ = item.InnerHeight / 72.0;
			if (class1503_0.Equals(item, double_))
			{
				continue;
			}
			bool flag = false;
			for (int i = 0; i < class1498_0.arrayList_2.Count; i++)
			{
				Class1503 @class = (Class1503)class1498_0.arrayList_2[i];
				if (@class.Equals(item, double_))
				{
					hashtable_1.Add(item.int_0, @class.Name);
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				Class1503 class2 = new Class1503(item, double_);
				class1498_0.arrayList_2.Add(class2);
				class2.Name = "ro" + class1498_0.arrayList_2.Count;
				hashtable_1.Add(item.int_0, class2.Name);
			}
		}
	}

	internal void method_6(ColumnCollection columnCollection_0)
	{
		foreach (Column item in columnCollection_0)
		{
			if (!bool_0 && item.method_10())
			{
				bool_0 = true;
			}
			if (class1497_0.Equals(item, cells_0.GetColumnWidthInch(item.Index)))
			{
				continue;
			}
			bool flag = false;
			for (int i = 0; i < class1498_0.arrayList_1.Count; i++)
			{
				Class1497 @class = (Class1497)class1498_0.arrayList_1[i];
				if (@class.Equals(item, cells_0.GetColumnWidthInch(item.Index)))
				{
					hashtable_0.Add(item.Index, @class.Name);
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				Class1497 class2 = new Class1497(item, cells_0.GetColumnWidthInch(item.Index));
				class1498_0.arrayList_1.Add(class2);
				class2.Name = "co" + class1498_0.arrayList_1.Count;
				hashtable_0.Add(item.Index, class2.Name);
			}
		}
	}

	private void method_7()
	{
		ArrayList mergedCells = cells_0.MergedCells;
		arrayList_2 = new ArrayList(mergedCells.Count);
		WorksheetCollection worksheets = class1498_0.workbook_0.Worksheets;
		for (int i = 0; i < mergedCells.Count; i++)
		{
			CellArea cellArea_ = (CellArea)mergedCells[i];
			Class1505 @class = new Class1505(cellArea_);
			arrayList_2.Add(@class);
			int num = cells_0.method_40(cellArea_.StartRow, cellArea_.StartColumn);
			if (num == -1)
			{
				num = 15;
			}
			int num2 = num;
			if (cellArea_.StartRow != cellArea_.EndRow || cellArea_.StartColumn != cellArea_.EndColumn)
			{
				num2 = cells_0.method_40(cellArea_.EndRow, cellArea_.EndColumn);
				if (num2 == -1)
				{
					num2 = 15;
				}
			}
			if (num == num2)
			{
				@class.int_4 = num2;
				continue;
			}
			Style style = class1498_0.workbook_0.Worksheets.method_45(num);
			Style style2 = class1498_0.workbook_0.Worksheets.method_45(num2);
			if (style.method_9())
			{
				if (style2.method_9())
				{
					Style style3 = new Style(worksheets);
					style3.Copy(style);
					style3.Borders[BorderType.RightBorder].Copy(style2.Borders[BorderType.RightBorder]);
					style3.Borders[BorderType.BottomBorder].Copy(style2.Borders[BorderType.BottomBorder]);
					@class.int_4 = worksheets.method_59(style3);
				}
				else
				{
					@class.int_4 = num;
				}
			}
			else if (style2.method_9())
			{
				@class.int_4 = num2;
			}
		}
	}

	private void method_8()
	{
		if (worksheet_0.method_36() == null || worksheet_0.Shapes.Count == 0)
		{
			return;
		}
		arrayList_7 = new ArrayList();
		for (int i = 0; i < worksheet_0.Shapes.Count; i++)
		{
			Shape shape = worksheet_0.Shapes[i];
			MsoDrawingType msoDrawingType = shape.MsoDrawingType;
			if (msoDrawingType != MsoDrawingType.Comment)
			{
				arrayList_7.Add(new Class1493(shape));
			}
		}
	}

	internal void method_9()
	{
		PageSetup pageSetup = worksheet_0.PageSetup;
		string header = pageSetup.GetHeader(0);
		method_11(header, 0, "&L");
		header = pageSetup.GetHeader(1);
		method_11(header, 1, "&C");
		header = pageSetup.GetHeader(2);
		method_11(header, 2, "&R");
		header = pageSetup.GetFooter(0);
		method_12(header, 0, "&L");
		header = pageSetup.GetFooter(1);
		method_12(header, 1, "&C");
		header = pageSetup.GetFooter(2);
		method_12(header, 2, "&R");
		if (arrayList_5 != null || arrayList_6 != null)
		{
			ArrayList arrayList = class1498_0.arrayList_6;
			if (arrayList.Count == 0)
			{
				Font font = new Font(worksheet_0.method_2(), null, bool_0: false);
				font.Copy(worksheet_0.method_2().DefaultFont);
				font.method_22(1);
				arrayList.Add(font);
			}
			if (arrayList_5 != null)
			{
				method_10(arrayList, arrayList_5);
			}
			if (arrayList_6 != null)
			{
				method_10(arrayList, arrayList_6);
			}
		}
		bool_1 = pageSetup.IsHFDiffOddEven;
		if (!bool_1)
		{
			return;
		}
		header = pageSetup.GetEvenHeader(0);
		method_13(header, 0, "&L");
		header = pageSetup.GetEvenHeader(1);
		method_13(header, 1, "&C");
		header = pageSetup.GetEvenHeader(2);
		method_13(header, 2, "&R");
		header = pageSetup.GetEvenFooter(0);
		method_14(header, 0, "&L");
		header = pageSetup.GetEvenFooter(1);
		method_14(header, 1, "&C");
		header = pageSetup.GetEvenFooter(2);
		method_14(header, 2, "&R");
		if (arrayList_3 != null || arrayList_4 != null)
		{
			ArrayList arrayList2 = class1498_0.arrayList_6;
			if (arrayList2.Count == 0)
			{
				Font font2 = new Font(worksheet_0.method_2(), null, bool_0: false);
				font2.Copy(worksheet_0.method_2().DefaultFont);
				font2.method_22(1);
				arrayList2.Add(font2);
			}
			if (arrayList_3 != null)
			{
				method_10(arrayList2, arrayList_3);
			}
			if (arrayList_4 != null)
			{
				method_10(arrayList2, arrayList_4);
			}
		}
	}

	private void method_10(ArrayList arrayList_8, ArrayList[] arrayList_9)
	{
		foreach (ArrayList arrayList in arrayList_9)
		{
			if (arrayList == null)
			{
				continue;
			}
			for (int j = 0; j < arrayList.Count; j++)
			{
				HeaderFooterCommand headerFooterCommand = (HeaderFooterCommand)arrayList[j];
				if (headerFooterCommand.Font == null)
				{
					continue;
				}
				bool flag = false;
				for (int k = 0; k < arrayList_8.Count; k++)
				{
					Font font = (Font)arrayList_8[k];
					if (font.Equals(headerFooterCommand.Font))
					{
						headerFooterCommand.Font.method_22(k + 1);
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					arrayList_8.Add(headerFooterCommand.Font);
					headerFooterCommand.Font.method_22(arrayList_8.Count);
				}
			}
		}
	}

	private void method_11(string string_2, int int_0, string string_3)
	{
		if (string_2 == null || !(string_2 != ""))
		{
			return;
		}
		if (string_2.StartsWith(string_3))
		{
			string_2 = string_2.Substring(2);
		}
		ArrayList arrayList = HeaderFooterCommand.smethod_0(worksheet_0.Workbook, string_2);
		if (arrayList != null && arrayList.Count != 0)
		{
			if (arrayList_5 == null)
			{
				arrayList_5 = new ArrayList[3];
			}
			arrayList_5[int_0] = arrayList;
		}
	}

	private void method_12(string string_2, int int_0, string string_3)
	{
		if (string_2 == null || !(string_2 != ""))
		{
			return;
		}
		if (string_2.StartsWith(string_3))
		{
			string_2 = string_2.Substring(2);
		}
		ArrayList arrayList = HeaderFooterCommand.smethod_0(worksheet_0.Workbook, string_2);
		if (arrayList != null && arrayList.Count != 0)
		{
			if (arrayList_6 == null)
			{
				arrayList_6 = new ArrayList[3];
			}
			arrayList_6[int_0] = arrayList;
		}
	}

	private void method_13(string string_2, int int_0, string string_3)
	{
		if (string_2 == null || !(string_2 != ""))
		{
			return;
		}
		if (string_2.StartsWith(string_3))
		{
			string_2 = string_2.Substring(2);
		}
		ArrayList arrayList = HeaderFooterCommand.smethod_0(worksheet_0.Workbook, string_2);
		if (arrayList != null && arrayList.Count != 0)
		{
			if (arrayList_3 == null)
			{
				arrayList_3 = new ArrayList[3];
			}
			arrayList_3[int_0] = arrayList;
		}
	}

	private void method_14(string string_2, int int_0, string string_3)
	{
		if (string_2 == null || !(string_2 != ""))
		{
			return;
		}
		if (string_2.StartsWith(string_3))
		{
			string_2 = string_2.Substring(2);
		}
		ArrayList arrayList = HeaderFooterCommand.smethod_0(worksheet_0.Workbook, string_2);
		if (arrayList != null && arrayList.Count != 0)
		{
			if (arrayList_4 == null)
			{
				arrayList_4 = new ArrayList[3];
			}
			arrayList_4[int_0] = arrayList;
		}
	}

	internal Comment method_15(int int_0, int int_1)
	{
		if (worksheet_0.method_36() != null && worksheet_0.Shapes.Count != 0)
		{
			int num = 0;
			Comment comment;
			while (true)
			{
				if (num < worksheet_0.Comments.Count)
				{
					comment = worksheet_0.Comments[num];
					if (comment.Row == int_0 && comment.Column == int_1)
					{
						break;
					}
					num++;
					continue;
				}
				return null;
			}
			return comment;
		}
		return null;
	}

	internal ArrayList method_16(int int_0, int int_1)
	{
		if (arrayList_7 != null && arrayList_7.Count != 0)
		{
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < arrayList_7.Count; i++)
			{
				Class1493 @class = (Class1493)arrayList_7[i];
				if (@class.int_0 == int_0 && @class.int_1 == int_1)
				{
					arrayList.Add(@class);
					arrayList_7.RemoveAt(i--);
				}
			}
			if (arrayList.Count == 0)
			{
				return null;
			}
			return arrayList;
		}
		return null;
	}

	internal Class1505 method_17(int int_0, int int_1)
	{
		int num = 0;
		Class1505 @class;
		while (true)
		{
			if (num < arrayList_2.Count)
			{
				@class = (Class1505)arrayList_2[num];
				if (@class.int_1 < int_0)
				{
					arrayList_2.RemoveAt(num--);
				}
				else if (int_0 >= @class.int_0 && int_0 <= @class.int_1 && int_1 >= @class.int_2 && int_1 <= @class.int_3)
				{
					break;
				}
				num++;
				continue;
			}
			return null;
		}
		return @class;
	}
}
