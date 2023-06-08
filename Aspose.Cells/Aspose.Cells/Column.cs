using System;
using System.Collections;
using System.Runtime.CompilerServices;
using ns2;

namespace Aspose.Cells;

/// <summary>
///       Represents a single column in a worksheet.
///       </summary>
/// <example>
///   <code>
///
///       [C#]
///
///       //Instantiating a Workbook object
///       Workbook workbook = new Workbook();
///
///       //Obtaining the reference of the first worksheet
///       Worksheet worksheet = workbook.Worksheets[0];
///
///       //Add new Style to Workbook
///       Style style = workbook.Styles[workbook.Styles.Add()];
///
///       //Setting the background color to Blue
///       style.BackgroundColor = Color.Blue;
///
///       //Setting the foreground color to Red
///       style.ForegroundColor= Color.Red;
///
///       //setting Background Pattern
///       style.Pattern = BackgroundType.DiagonalStripe;
///
///       //New Style Flag
///       StyleFlag styleFlag = new StyleFlag();
///
///       //Set All Styles
///       styleFlag.All = true;
///
///       //Get first Column
///       Column column = worksheet.Cells.Columns[0];
///
///       //Apply Style to first Column
///       column.ApplyStyle(style, styleFlag);
///
///       //Saving the Excel file
///       workbook.Save("D:\\book1.xls");
///
///       [VB.NET]
///
///       'Instantiating a Workbook object
///       Dim workbook As New Workbook()
///
///       'Obtaining the reference of the first worksheet
///       Dim worksheet As Worksheet = workbook.Worksheets(0)
///
///       'Add new Style to Workbook
///       Dim style As Style = workbook.Styles(workbook.Styles.Add())
///
///       'Setting the background color to Blue
///       style.BackgroundColor = Color.Blue
///
///       'Setting the foreground color to Red
///       style.ForegroundColor = Color.Red
///
///       'setting Background Pattern
///       style.Pattern = BackgroundType.DiagonalStripe
///
///       'New Style Flag
///       Dim styleFlag As New StyleFlag()
///
///       'Set All Styles
///       styleFlag.All = True
///
///       'Get first Column
///       Dim column As Column = worksheet.Cells.Columns(0)
///
///       'Apply Style to first Column
///       column.ApplyStyle(style, styleFlag)
///
///       'Saving the Excel file
///       workbook.Save("D:\book1.xls")
///       </code>
/// </example>
public class Column
{
	private Worksheet worksheet_0;

	private short short_0;

	internal double double_0;

	private int int_0 = -1;

	private byte byte_0;

	/// <summary>
	///       Gets the index of this column.
	///       </summary>
	public int Index => short_0;

	/// <summary>
	///       Gets and sets the column width in unit of charaters.
	///       </summary>
	public double Width
	{
		get
		{
			return double_0;
		}
		set
		{
			if (value < double.Epsilon)
			{
				method_8(bool_0: true);
			}
			else
			{
				double_0 = value;
				method_8(bool_0: false);
			}
			method_17(bool_0: false);
		}
	}

	/// <summary>
	///       Gets the group level of the column.
	///       </summary>
	public byte GroupLevel => method_3();

	/// <summary>
	///       Indicates whether the column is hidden.
	///       </summary>
	public bool IsHidden
	{
		get
		{
			return method_7();
		}
		set
		{
			method_8(value);
			method_17(bool_0: false);
			if (!value && double_0 == 0.0)
			{
				double_0 = worksheet_0.Cells.Columns.Width;
			}
		}
	}

	/// <summary>
	///       Gets the style of this column.
	///       </summary>
	/// <remarks>
	///       You have to call Column.ApplyStyle() method to save your changing with the row style,
	///       otherwise it will not effect.
	///       </remarks>
	public Style Style
	{
		get
		{
			Style style = new Style(worksheet_0.method_2());
			if (int_0 != -1 && int_0 != 15)
			{
				style.GetStyle(worksheet_0.method_2(), int_0);
			}
			else
			{
				style.GetStyle(worksheet_0.method_2(), 15);
			}
			return style;
		}
	}

	internal Column(int int_1, Worksheet worksheet_1, double double_1)
	{
		short_0 = (short)int_1;
		worksheet_0 = worksheet_1;
		double_0 = double_1;
	}

	internal Column(int int_1, Worksheet worksheet_1, double double_1, Column column_0)
	{
		short_0 = (short)int_1;
		worksheet_0 = worksheet_1;
		double_0 = double_1;
		if (column_0 != null && column_0.Index <= int_1)
		{
			CopyData(column_0);
		}
	}

	internal void method_0(int int_1)
	{
		short_0 = (short)int_1;
	}

	[SpecialName]
	internal int method_1()
	{
		double num = double_0;
		if (num > 1.0)
		{
			int num2 = (int)(num * (double)worksheet_0.method_2().method_72() + 0.5);
			int num3 = (int)((double)(worksheet_0.method_2().method_72() * worksheet_0.method_2().method_71()) / 256.0 + 0.5);
			return num2 + num3;
		}
		return (int)(num * (double)(worksheet_0.method_2().method_72() + (int)((double)(worksheet_0.method_2().method_72() * worksheet_0.method_2().method_71()) / 256.0 + 0.5)) + 0.5);
	}

	[SpecialName]
	internal void method_2(int int_1)
	{
		int num = worksheet_0.method_2().method_72();
		int num2 = worksheet_0.method_2().method_71();
		int num3 = worksheet_0.method_2().method_73();
		if (int_1 < num + num3)
		{
			double num4 = 1.0 * (double)int_1 / (double)(num + num3);
			double_0 = num4;
		}
		else
		{
			double num5 = (double)(int)((double)(int_1 - (int)((double)(num * num2) / 256.0 + 0.5)) * 100.0 / (double)num + 0.5) / 100.0;
			double_0 = num5;
		}
		method_17(bool_0: false);
	}

	[SpecialName]
	internal byte method_3()
	{
		return (byte)(byte_0 & 0xFu);
	}

	[SpecialName]
	internal void method_4(byte byte_1)
	{
		byte_0 &= 240;
		byte_0 |= byte_1;
	}

	[SpecialName]
	internal int method_5()
	{
		return int_0;
	}

	[SpecialName]
	internal void method_6(int int_1)
	{
		int_0 = int_1;
	}

	[SpecialName]
	internal bool method_7()
	{
		return (byte_0 & 0x20) != 0;
	}

	[SpecialName]
	internal void method_8(bool bool_0)
	{
		if (!bool_0)
		{
			byte_0 &= 223;
		}
		else
		{
			byte_0 |= 32;
		}
	}

	internal void CopyData(Column column_0)
	{
		double_0 = column_0.double_0;
		int_0 = column_0.int_0;
		byte_0 = column_0.byte_0;
		if (column_0.worksheet_0.method_2() != worksheet_0.method_2())
		{
			int_0 = worksheet_0.method_2().method_59(column_0.method_13());
		}
	}

	internal void Copy(Column column_0, CopyOptions copyOptions_0)
	{
		short_0 = column_0.short_0;
		double_0 = column_0.double_0;
		if (copyOptions_0 == null || !copyOptions_0.bool_1)
		{
			method_2(column_0.method_1());
		}
		int_0 = column_0.int_0;
		byte_0 = column_0.byte_0;
		if (column_0.short_0 != -1)
		{
			worksheet_0.Workbook.method_3();
			if (!copyOptions_0.bool_0 && worksheet_0.method_2() != column_0.worksheet_0.method_2())
			{
				if (copyOptions_0.hashtable_0[column_0.int_0] != null)
				{
					int_0 = (int)copyOptions_0.hashtable_0[column_0.int_0];
					return;
				}
				int num = column_0.int_0;
				Style style = column_0.method_13();
				if (style == null)
				{
					int_0 = -1;
				}
				else
				{
					int_0 = worksheet_0.method_2().method_59(style);
				}
				copyOptions_0.hashtable_0.Add(num, int_0);
			}
			else
			{
				int_0 = column_0.int_0;
			}
		}
		else
		{
			short_0 = -1;
		}
	}

	internal bool method_9(Column column_0)
	{
		if (int_0 == column_0.int_0 && byte_0 == column_0.byte_0)
		{
			if (Math.Abs(double_0 - column_0.double_0) <= double.Epsilon)
			{
				return true;
			}
			return false;
		}
		return false;
	}

	[SpecialName]
	internal bool method_10()
	{
		if (int_0 != -1)
		{
			return int_0 != 15;
		}
		return false;
	}

	internal bool method_11(Column column_0)
	{
		if (column_0 == null)
		{
			if (int_0 != -1)
			{
				return int_0 == 15;
			}
			return true;
		}
		return method_13().Equals(column_0.method_13());
	}

	internal void method_12(byte[] byte_1)
	{
		ushort num = BitConverter.ToUInt16(byte_1, 4);
		double_0 = Math.Floor((double)(num - worksheet_0.method_2().method_71()) / 2.56 + 0.5) / 100.0;
		if (double_0 < 1.0)
		{
			double_0 = (double)(int)((double)(int)num * 100.0 / (double)(256 + worksheet_0.method_2().method_71()) + 0.5) / 100.0;
		}
		int_0 = BitConverter.ToUInt16(byte_1, 6);
		if (int_0 == 65535)
		{
			int_0 = -1;
		}
		method_4((byte)(byte_1[9] & 7u));
		if (((uint)byte_1[8] & (true ? 1u : 0u)) != 0)
		{
			method_8(bool_0: true);
		}
		if ((byte_1[8] & 4u) != 0)
		{
			method_17(bool_0: true);
		}
		if ((byte_1[9] & 0x10u) != 0)
		{
			method_15(bool_0: true);
		}
	}

	/// <summary>
	///       Applies formattings for a whole column.
	///       </summary>
	/// <param name="style">The style object which will be applied.</param>
	/// <param name="flag">Flags which indicates applied formatting properties.</param>
	public void ApplyStyle(Style style, StyleFlag flag)
	{
		Cells cells = worksheet_0.Cells;
		RowCollection rows = worksheet_0.Cells.Rows;
		rows.method_7();
		if (flag.All)
		{
			SetStyle(style);
			for (int i = 0; i < cells.Rows.Count; i++)
			{
				Row rowByIndex = cells.Rows.GetRowByIndex(i);
				Cell cellOrNull = rowByIndex.GetCellOrNull(short_0);
				if (cellOrNull != null)
				{
					cellOrNull.method_37(int_0);
				}
				else if (rowByIndex.method_27())
				{
					cellOrNull = rowByIndex.GetCell(short_0);
					cellOrNull.method_37(int_0);
				}
			}
			return;
		}
		Hashtable hashtable = new Hashtable();
		int num = 0;
		Style style2 = null;
		for (int j = 0; j < cells.Rows.Count; j++)
		{
			Row rowByIndex2 = cells.Rows.GetRowByIndex(j);
			Cell cell = rowByIndex2.GetCellOrNull(short_0);
			if (cell == null && rowByIndex2.method_27())
			{
				cell = rowByIndex2.GetCell(short_0);
			}
			if (cell != null)
			{
				num = cell.method_35();
				if (hashtable[num] != null)
				{
					cell.method_37((int)hashtable[num]);
					continue;
				}
				Style style3 = cell.method_28();
				Class1677.ApplyStyle(style, style3, flag);
				cell.method_30(style3);
				hashtable.Add(num, cell.method_36());
			}
		}
		num = int_0;
		style2 = Style;
		Class1677.ApplyStyle(style, style2, flag);
		SetStyle(style2);
	}

	internal void SetStyle(Style style_0)
	{
		int_0 = worksheet_0.method_2().method_59(style_0);
	}

	internal Style method_13()
	{
		if (int_0 != -1 && int_0 != 15)
		{
			return worksheet_0.method_2().method_58()[int_0];
		}
		return worksheet_0.method_2().DefaultStyle;
	}

	[SpecialName]
	internal bool method_14()
	{
		return (byte_0 & 0x10) != 0;
	}

	[SpecialName]
	internal void method_15(bool bool_0)
	{
		if (bool_0)
		{
			byte_0 |= 16;
		}
		else
		{
			byte_0 &= 239;
		}
	}

	[SpecialName]
	internal bool method_16()
	{
		return (byte_0 & 0x40) != 0;
	}

	[SpecialName]
	internal void method_17(bool bool_0)
	{
		if (bool_0)
		{
			byte_0 |= 64;
		}
		else
		{
			byte_0 &= 191;
		}
	}

	[SpecialName]
	internal bool method_18()
	{
		if (!method_10() && !IsHidden && GroupLevel == 0)
		{
			return double_0 != worksheet_0.Cells.Columns.Width;
		}
		return true;
	}
}
