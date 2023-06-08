using System;
using System.Globalization;
using ns34;
using ns43;
using ns56;

namespace Aspose.Slides.Charts;

public class ChartDataCell : IChartDataCell
{
	internal string string_0;

	internal ChartDataWorksheet chartDataWorksheet_0;

	internal Enum262 enum262_0;

	internal object object_0;

	internal bool bool_0;

	private int int_0;

	private int int_1;

	private bool bool_1;

	internal Class736 class736_0 = new Class736();

	internal string string_1 = "";

	private static readonly char[] char_0 = new char[10] { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };

	internal Enum262 Type => enum262_0;

	public IChartDataWorksheet ChartDataWorksheet => chartDataWorksheet_0;

	internal string Name
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
			method_5();
		}
	}

	public object Value
	{
		get
		{
			return object_0;
		}
		set
		{
			method_3(value);
		}
	}

	public int Row => int_1;

	public int Column => int_0;

	internal int IntValue
	{
		get
		{
			if (object_0 is int)
			{
				return (int)object_0;
			}
			return 0;
		}
	}

	internal string StringValue => Convert.ToString(object_0, CultureInfo.InvariantCulture);

	public bool IsHidden
	{
		get
		{
			return bool_1;
		}
		internal set
		{
			bool_1 = value;
			method_4();
		}
	}

	public string CustomNumberFormat
	{
		get
		{
			return string_1;
		}
		set
		{
			string_1 = value;
		}
	}

	public byte PresetNumberFormat
	{
		get
		{
			if (class736_0.NumFmtId < 164)
			{
				return (byte)class736_0.NumFmtId;
			}
			return 0;
		}
		set
		{
			class736_0.NumFmtId = value;
		}
	}

	internal ChartDataCell(ChartDataWorksheet parent, Class811 elemCell)
	{
		chartDataWorksheet_0 = parent;
		enum262_0 = elemCell.CellType;
		class736_0 = method_9(parent.ParentWorkbook.class737_0[(int)elemCell.CellStyle]);
		if (class736_0.NumFmtId >= 164 && class736_0.ApplyNumberFormat != 0)
		{
			Class804 @class = method_8(class736_0.NumFmtId);
			if (@class != null)
			{
				string_1 = @class.FormatCode;
			}
		}
		if (enum262_0 == Enum262.const_3)
		{
			object_0 = chartDataWorksheet_0.ParentWorkbook.class808_0[Convert.ToInt32(elemCell.CellValue)];
		}
		else if (elemCell.CellValue == null)
		{
			object_0 = elemCell.CellValue;
		}
		else
		{
			string s = (string)elemCell.CellValue;
			if (double.TryParse(s, NumberStyles.Any, CultureInfo.InvariantCulture, out var result))
			{
				object_0 = result;
			}
			else
			{
				object_0 = elemCell.CellValue;
			}
		}
		string_0 = elemCell.CellName;
		method_5();
		bool_0 = true;
	}

	internal ChartDataCell(ChartDataWorksheet parent)
	{
		chartDataWorksheet_0 = parent;
		bool_0 = false;
	}

	internal ChartDataCell(ChartDataWorksheet parent, string name)
	{
		chartDataWorksheet_0 = parent;
		string_0 = name;
		enum262_0 = Enum262.const_1;
		bool_0 = false;
		method_5();
		if (parent.SheetPartXLSXUnsupportedProps.ColsList == null)
		{
			return;
		}
		Class1423[] colsList = parent.SheetPartXLSXUnsupportedProps.ColsList;
		foreach (Class1423 @class in colsList)
		{
			Class1415[] colList = @class.ColList;
			foreach (Class1415 class2 in colList)
			{
				if (Column + 1 >= class2.Min && Column + 1 <= class2.Max && class2.Hidden)
				{
					IsHidden = true;
				}
			}
		}
	}

	internal void method_0(double val)
	{
		object_0 = val;
		enum262_0 = Enum262.const_1;
		method_4();
	}

	internal void method_1(int val)
	{
		object_0 = val;
		enum262_0 = Enum262.const_1;
		method_4();
	}

	internal void method_2(string val)
	{
		object_0 = val;
		enum262_0 = Enum262.const_3;
		method_4();
	}

	internal void method_3(object val)
	{
		object_0 = val;
		if (val is string)
		{
			enum262_0 = Enum262.const_3;
		}
		else
		{
			enum262_0 = Enum262.const_1;
		}
		method_4();
	}

	private void method_4()
	{
		if (chartDataWorksheet_0 != null && !bool_0)
		{
			chartDataWorksheet_0.Cells.Add(this);
			bool_0 = true;
		}
	}

	internal void method_5()
	{
		int num = string_0.IndexOfAny(char_0);
		string text = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
		string text2 = string_0.Substring(0, num);
		string value = string_0.Substring(num);
		int_1 = method_10(value) - 1;
		int_0 = 0;
		for (int i = 0; i < text2.Length; i++)
		{
			int_0 = (int)((double)int_0 + Math.Pow(text.Length, text2.Length - i - 1) * (double)(text.IndexOf(text2[i]) + 1));
		}
		int_0--;
	}

	internal void method_7(Class815 target)
	{
		Class811 @class = (Class811)target.method_0(Class811.string_1, target.NamespaceURI);
		@class.Prefix = "";
		@class.CellName = string_0;
		@class.CellType = enum262_0;
		if (string_1.Trim() != "")
		{
			Class804 class2 = smethod_1(string_1, chartDataWorksheet_0.ParentWorkbook);
			class736_0.NumFmtId = class2.NumFormatID;
		}
		@class.CellStyle = (uint)smethod_0(this);
		if (enum262_0 == Enum262.const_3)
		{
			Class808 class808_ = chartDataWorksheet_0.ParentWorkbook.class808_0;
			int num = -1;
			for (int i = 0; i < class808_.Count; i++)
			{
				if (class808_[i] == (string)object_0)
				{
					num = i;
					break;
				}
			}
			if (num == -1)
			{
				num = class808_.Add((string)object_0);
				class808_.uint_1++;
			}
			@class.CellValue = num;
			class808_.uint_0++;
		}
		else
		{
			@class.CellValue = object_0;
		}
	}

	internal static int smethod_0(ChartDataCell cell)
	{
		Class737 class737_ = cell.chartDataWorksheet_0.ParentWorkbook.class737_0;
		int num = 0;
		while (true)
		{
			if (num < class737_.Count)
			{
				if (cell.class736_0.XfId == class737_[num].XfId && cell.class736_0.QuotePrefix == class737_[num].QuotePrefix && cell.class736_0.PivotButton == class737_[num].PivotButton && cell.class736_0.NumFmtId == class737_[num].NumFmtId && cell.class736_0.FontId == class737_[num].FontId && cell.class736_0.FillId == class737_[num].FillId && cell.class736_0.BorderId == class737_[num].BorderId && cell.class736_0.ApplyProtection == class737_[num].ApplyProtection && cell.class736_0.ApplyNumberFormat == class737_[num].ApplyNumberFormat && cell.class736_0.ApplyFont == class737_[num].ApplyFont && cell.class736_0.ApplyFill == class737_[num].ApplyFill && cell.class736_0.ApplyBorder == class737_[num].ApplyBorder && cell.class736_0.ApplyAlignment == class737_[num].ApplyAlignment)
				{
					break;
				}
				num++;
				continue;
			}
			return class737_.Add(cell.class736_0);
		}
		return num;
	}

	internal Class804 method_8(uint id)
	{
		foreach (Class804 item in chartDataWorksheet_0.ParentWorkbook.class805_0)
		{
			if (item.NumFormatID == id)
			{
				return item;
			}
		}
		return null;
	}

	internal static Class804 smethod_1(string formatCode, ChartDataWorkbook workbook)
	{
		uint num = 164u;
		foreach (Class804 item in workbook.class805_0)
		{
			if (!(item.FormatCode == formatCode))
			{
				if (item.NumFormatID >= num)
				{
					num = item.NumFormatID + 1;
				}
				continue;
			}
			return item;
		}
		Class804 class2 = new Class804();
		class2.NumFormatID = num;
		class2.FormatCode = formatCode;
		workbook.class805_0.Add(class2);
		return class2;
	}

	internal Class736 method_9(Class736 cellFormat)
	{
		Class736 @class = new Class736();
		@class.XfId = cellFormat.XfId;
		@class.QuotePrefix = cellFormat.QuotePrefix;
		@class.PivotButton = cellFormat.PivotButton;
		@class.NumFmtId = cellFormat.NumFmtId;
		@class.FontId = cellFormat.FontId;
		@class.FillId = cellFormat.FillId;
		@class.BorderId = cellFormat.BorderId;
		@class.ApplyProtection = cellFormat.ApplyProtection;
		@class.ApplyNumberFormat = cellFormat.ApplyNumberFormat;
		@class.ApplyFont = cellFormat.ApplyFont;
		@class.ApplyFill = cellFormat.ApplyFill;
		@class.ApplyBorder = cellFormat.ApplyBorder;
		@class.ApplyAlignment = cellFormat.ApplyAlignment;
		return @class;
	}

	private int method_10(string value)
	{
		int num = 0;
		if (value.Length > 0)
		{
			bool flag;
			for (int i = ((flag = value[0] == '-') ? 1 : 0); i < value.Length; i++)
			{
				char c = value[i];
				if (char.IsDigit(c))
				{
					num = 10 * num + (c - 48);
					continue;
				}
				return 0;
			}
			if (flag)
			{
				num *= -1;
			}
		}
		return num;
	}
}
