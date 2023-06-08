using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Text;
using ns12;
using ns2;
using ns59;

namespace Aspose.Cells;

/// <summary>
///       Represents conditional formatting condition.
///       </summary>
/// <example>
///   <code>
///
///       [C#]
///       //Instantiating a Workbook object
///       Workbook workbook = new Workbook();
///       Worksheet sheet = workbook.Worksheets[0];
///
///       //Adds an empty conditional formatting
///       int index = sheet.ConditionalFormattings.Add();
///       FormatConditionCollection fcs = sheet.ConditionalFormattings[index];
///
///       //Sets the conditional format range.
///       CellArea ca = new CellArea();
///       ca.StartRow = 0;
///       ca.EndRow = 0;
///       ca.StartColumn = 0;
///       ca.EndColumn = 0;
///       fcs.AddArea(ca);
///
///       ca = new CellArea();
///       ca.StartRow = 1;
///       ca.EndRow = 1;
///       ca.StartColumn = 1;
///       ca.EndColumn = 1;
///       fcs.AddArea(ca);
///
///       //Adds condition.
///       int conditionIndex = fcs.AddCondition(FormatConditionType.CellValue, OperatorType.Between, "=A2", "100");
///
///       //Adds condition.
///       int conditionIndex2 = fcs.AddCondition(FormatConditionType.CellValue, OperatorType.Between, "50", "100");
///
///       //Sets the background color.
///       FormatCondition fc = fcs[conditionIndex];
///       fc.Style.BackgroundColor = Color.Red;
///
///       //Saving the Excel file
///       workbook.Save("C:\\output.xls");
///
///       [VB.NET]
///
///       'Instantiating a Workbook object
///       Dim workbook As Workbook = New Workbook()
///       Dim sheet As Worksheet = workbook.Worksheets(0)
///
///       ' Adds an empty conditional formatting
///       Dim index As Integer = sheet.ConditionalFormattings.Add()
///       Dim fcs As FormatConditionCollection = sheet.ConditionalFormattings(index)
///
///       'Sets the conditional format range.
///       Dim ca As CellArea = New CellArea()
///       ca.StartRow = 0
///       ca.EndRow = 0
///       ca.StartColumn = 0
///       ca.EndColumn = 0
///       fcs.AddArea(ca)
///       ca = New CellArea()
///       ca.StartRow = 1
///       ca.EndRow = 1
///       ca.StartColumn = 1
///       ca.EndColumn = 1
///       fcs.AddArea(ca)
///
///       'Adds condition.
///       Dim conditionIndex As Integer = fcs.AddCondition(FormatConditionType.CellValue, OperatorType.Between, "=A2", "100")
///
///       'Adds condition.
///       Dim conditionIndex2 As Integer = fcs.AddCondition(FormatConditionType.CellValue, OperatorType.Between, "50", "100")
///
///       'Sets the background color.
///       Dim fc As FormatCondition = fcs(conditionIndex)
///       fc.Style.BackgroundColor = Color.Red
///
///       'Saving the Excel file
///       workbook.Save("C:\output.xls")
///       </code>
/// </example>
public class FormatCondition
{
	internal FormatConditionCollection formatConditionCollection_0;

	internal OperatorType operatorType_0;

	internal FormatConditionType formatConditionType_0;

	private byte[] byte_0;

	private byte[] byte_1;

	private string string_0 = "{" + Guid.NewGuid().ToString() + "}";

	internal string string_1;

	internal string string_2;

	internal Style style_0;

	private bool bool_0;

	private int int_0;

	private int int_1 = -1;

	private IconSet iconSet_0;

	private DataBar dataBar_0;

	private ColorScale colorScale_0;

	private Top10 top10_0;

	private AboveAverage aboveAverage_0;

	private TimePeriodType timePeriodType_0;

	/// <summary>
	///       Gets and sets the value or expression associated with conditional formatting.
	///       </summary>
	/// <remarks>
	///       Please add all areas before setting formula.
	///       </remarks>
	public string Formula1
	{
		get
		{
			if (string_1 == null && byte_0 != null)
			{
				int[] array = formatConditionCollection_0.method_9();
				if (array != null)
				{
					string_1 = method_10(byte_0, -1, array[0], array[1]);
				}
			}
			return string_1;
		}
		set
		{
			switch (value)
			{
			case null:
			case "":
			case "=":
				string_1 = null;
				byte_0 = null;
				return;
			}
			string_1 = value;
			byte_0 = null;
			if (formatConditionCollection_0.arrayList_1.Count != 0)
			{
				byte_0 = method_9(value);
				if (Class1674.smethod_2(formatConditionCollection_0.worksheet_0.method_2(), byte_0, -1, bool_0: false))
				{
					string_1 = null;
				}
			}
		}
	}

	/// <summary>
	///       Gets and sets the value or expression associated with conditional formatting.
	///       </summary>
	/// <remarks>
	///       Please add all areas before setting formula.
	///       </remarks>
	public string Formula2
	{
		get
		{
			if (string_2 == null && byte_1 != null)
			{
				int[] array = formatConditionCollection_0.method_9();
				if (array != null)
				{
					string_2 = method_10(byte_1, -1, array[0], array[1]);
				}
			}
			return string_2;
		}
		set
		{
			switch (value)
			{
			case null:
			case "":
			case "=":
				string_2 = null;
				byte_1 = null;
				return;
			}
			string_2 = value;
			byte_1 = null;
			if (formatConditionCollection_0.arrayList_1.Count != 0)
			{
				byte_1 = method_9(value);
				if (Class1674.smethod_2(formatConditionCollection_0.worksheet_0.method_2(), byte_1, -1, bool_0: false))
				{
					string_2 = null;
				}
			}
		}
	}

	/// <summary>
	///       Gets and sets the conditional format operator type.
	///       </summary>
	/// <see cref="T:Aspose.Cells.OperatorType" />
	public OperatorType Operator
	{
		get
		{
			return operatorType_0;
		}
		set
		{
			operatorType_0 = value;
		}
	}

	/// <summary>
	///       True, no rules with lower priority may be applied over this rule, when this rule evaluates to true.
	///       Only applies for Excel 2007;
	///       </summary>
	public bool StopIfTrue
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	/// <summary>
	///       The priority of this conditional formatting rule. This value is used to determine which
	///       format should be evaluated and rendered. Lower numeric values are higher priority than
	///       higher numeric values, where '1' is the highest priority.
	///       </summary>
	public int Priority
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
		}
	}

	/// <summary>
	///       Gets or setts style of conditional formatted cell ranges.
	///       </summary>
	public Style Style
	{
		get
		{
			if (style_0 == null)
			{
				style_0 = new Style(Worksheets);
				style_0.method_16(0);
			}
			return style_0;
		}
		set
		{
			style_0 = value;
		}
	}

	/// <summary>
	///       Gets and sets whether the conditional format Type.
	///       </summary>
	/// <see cref="T:Aspose.Cells.FormatConditionType" />
	public FormatConditionType Type
	{
		get
		{
			return formatConditionType_0;
		}
		set
		{
			formatConditionType_0 = value;
		}
	}

	/// <summary>
	///       Get the conditional formatting's "IconSet" instance.
	///       The default instance's IconSetType is TrafficLights31.
	///       Valid only for type = IconSet.
	///       </summary>
	/// <returns>
	/// </returns>
	public IconSet IconSet
	{
		get
		{
			if (iconSet_0 == null)
			{
				iconSet_0 = IconSet.smethod_0(this);
			}
			return iconSet_0;
		}
	}

	/// <summary>
	///       Get the conditional formatting's "DataBar" instance.
	///       The default instance's color is blue.
	///       Valid only for type = DataBar.
	///       </summary>
	/// <returns>
	/// </returns>
	public DataBar DataBar
	{
		get
		{
			if (dataBar_0 == null)
			{
				dataBar_0 = DataBar.smethod_0(Worksheets.Workbook, this);
			}
			return dataBar_0;
		}
	}

	/// <summary>
	///       Get the conditional formatting's "ColorScale" instance.
	///       The default instance is a "green-yellow-red" 3ColorScale .
	///       Valid only for type = ColorScale.
	///       </summary>
	/// <returns>
	/// </returns>
	public ColorScale ColorScale
	{
		get
		{
			if (colorScale_0 == null)
			{
				colorScale_0 = ColorScale.smethod_0(Worksheets.Workbook, this);
			}
			return colorScale_0;
		}
	}

	/// <summary>
	///       Get the conditional formatting's "Top10" instance.
	///       The default instance's rule highlights cells whose
	///       values fall in the top 10 bracket.
	///       Valid only for type = Top10.
	///       </summary>
	/// <returns>
	/// </returns>
	public Top10 Top10
	{
		get
		{
			if (top10_0 == null)
			{
				top10_0 = new Top10();
			}
			return top10_0;
		}
	}

	/// <summary>
	///       Get the conditional formatting's "AboveAverage" instance.
	///       The default instance's rule highlights cells that are 
	///       above the average for all values in the range.
	///       Valid only for type = AboveAverage.
	///       </summary>
	/// <returns>
	/// </returns>
	public AboveAverage AboveAverage
	{
		get
		{
			if (aboveAverage_0 == null)
			{
				aboveAverage_0 = new AboveAverage();
			}
			return aboveAverage_0;
		}
	}

	/// <summary>
	///       The text value in a "text contains" conditional formatting rule. 
	///       Valid only for type = containsText, notContainsText, beginsWith and endsWith.
	///       The default value is null.
	///       </summary>
	public string Text
	{
		get
		{
			string text = Formula2;
			if (text != null && text != "" && text.Length > 2 && text[0] == '=' && text[1] == '"')
			{
				text = text.Substring(2, text.Length - 3);
			}
			return text;
		}
		set
		{
			Formula2 = value;
		}
	}

	/// <summary>
	///       The applicable time period in a "date occurring…" conditional formatting rule. 
	///       Valid only for type = timePeriod.
	///       The default value is TimePeriodType.Today.
	///       </summary>
	public TimePeriodType TimePeriod
	{
		get
		{
			return timePeriodType_0;
		}
		set
		{
			timePeriodType_0 = value;
		}
	}

	internal WorksheetCollection Worksheets => formatConditionCollection_0.worksheet_0.method_2();

	[SpecialName]
	internal byte[] method_0()
	{
		return byte_0;
	}

	[SpecialName]
	internal void method_1(byte[] byte_2)
	{
		byte_0 = byte_2;
		string_1 = null;
	}

	[SpecialName]
	internal string method_2()
	{
		return string_0;
	}

	[SpecialName]
	internal void method_3(string string_3)
	{
		string_0 = string_3;
	}

	[SpecialName]
	internal byte[] method_4()
	{
		return byte_1;
	}

	[SpecialName]
	internal void method_5(byte[] byte_2)
	{
		byte_1 = byte_2;
		string_2 = null;
	}

	internal FormatCondition(FormatConditionCollection formatConditionCollection_1)
	{
		formatConditionCollection_0 = formatConditionCollection_1;
		formatConditionType_0 = FormatConditionType.CellValue;
		operatorType_0 = OperatorType.Between;
	}

	internal void Copy(FormatCondition formatCondition_0, CopyOptions copyOptions_0)
	{
		WorksheetCollection worksheetCollection_ = formatCondition_0.formatConditionCollection_0.conditionalFormattingCollection_0.worksheet_0.method_2();
		WorksheetCollection worksheetCollection = formatConditionCollection_0.conditionalFormattingCollection_0.worksheet_0.method_2();
		int[] array = formatCondition_0.formatConditionCollection_0.method_9();
		int int_;
		int num;
		if (array == null)
		{
			int_ = 0;
			num = 0;
		}
		else
		{
			int_ = array[0];
			num = array[1];
		}
		if (formatCondition_0.byte_0 != null)
		{
			byte[] array2 = formatCondition_0.byte_0;
			byte_0 = Class1379.Copy(worksheetCollection_, worksheetCollection, array2, -1, int_, num);
			if (copyOptions_0 != null && !copyOptions_0.bool_0 && copyOptions_0.hashtable_1 != null)
			{
				Class1674.smethod_17(byte_0, -1, byte_0.Length, copyOptions_0.hashtable_1, worksheetCollection);
			}
		}
		else if (formatCondition_0.string_1 != null)
		{
			string_1 = formatCondition_0.string_1;
		}
		if (formatCondition_0.byte_1 != null)
		{
			byte[] array3 = formatCondition_0.byte_1;
			byte_1 = Class1379.Copy(worksheetCollection_, worksheetCollection, array3, -1, int_, num);
			if (copyOptions_0 != null && !copyOptions_0.bool_0 && copyOptions_0.hashtable_1 != null)
			{
				Class1674.smethod_17(byte_1, -1, byte_1.Length, copyOptions_0.hashtable_1, worksheetCollection);
			}
		}
		else if (formatCondition_0.string_2 != null)
		{
			string_2 = formatCondition_0.string_2;
		}
		if (formatCondition_0.style_0 != null)
		{
			style_0 = new Style(formatConditionCollection_0.conditionalFormattingCollection_0.worksheet_0.method_2());
			style_0.Copy(formatCondition_0.Style);
		}
		formatConditionType_0 = formatCondition_0.formatConditionType_0;
		operatorType_0 = formatCondition_0.operatorType_0;
		int_0 = formatCondition_0.int_0;
		bool_0 = formatCondition_0.bool_0;
		if (formatCondition_0.aboveAverage_0 != null)
		{
			aboveAverage_0 = new AboveAverage();
			aboveAverage_0.Copy(formatCondition_0.aboveAverage_0);
		}
		if (formatCondition_0.colorScale_0 != null)
		{
			colorScale_0 = new ColorScale(formatConditionCollection_0.conditionalFormattingCollection_0.worksheet_0.method_2().Workbook, this);
			colorScale_0.Copy(formatCondition_0.colorScale_0, copyOptions_0, int_, num);
		}
		if (formatCondition_0.dataBar_0 != null)
		{
			dataBar_0 = new DataBar(formatConditionCollection_0.conditionalFormattingCollection_0.worksheet_0.method_2().Workbook, this);
			dataBar_0.Copy(formatCondition_0.dataBar_0, copyOptions_0, int_, num);
		}
		if (formatCondition_0.iconSet_0 != null)
		{
			iconSet_0 = new IconSet(this);
			iconSet_0.Copy(formatCondition_0.iconSet_0, copyOptions_0, int_, num);
		}
		timePeriodType_0 = formatCondition_0.timePeriodType_0;
		if (formatCondition_0.top10_0 != null)
		{
			top10_0 = new Top10();
			top10_0.Copy(formatCondition_0.top10_0);
		}
	}

	/// <summary>
	///       Gets the formula of the conditional formatting of the cell.
	///       </summary>
	/// <param name="row">The row index.</param>
	/// <param name="column">The column index.</param>
	/// <returns>The formula.</returns>
	public string GetFormula1(int row, int column)
	{
		bool flag = false;
		for (int i = 0; i < formatConditionCollection_0.arrayList_1.Count; i++)
		{
			CellArea cellArea = (CellArea)formatConditionCollection_0.arrayList_1[i];
			if (row >= cellArea.StartRow && row <= cellArea.EndRow && column >= cellArea.StartColumn && column <= cellArea.EndColumn)
			{
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			return null;
		}
		return method_10(byte_0, -1, row, column);
	}

	/// <summary>
	///       Gets the formula of the conditional formatting of the cell.
	///       </summary>
	/// <param name="row">The row index.</param>
	/// <param name="column">The column index.</param>
	/// <returns>The formula.</returns>
	public string GetFormula2(int row, int column)
	{
		bool flag = false;
		for (int i = 0; i < formatConditionCollection_0.arrayList_1.Count; i++)
		{
			CellArea cellArea = (CellArea)formatConditionCollection_0.arrayList_1[i];
			if (row >= cellArea.StartRow && row <= cellArea.EndRow && column >= cellArea.StartColumn && column <= cellArea.EndColumn)
			{
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			return null;
		}
		return method_10(byte_1, -1, row, column);
	}

	[SpecialName]
	internal int method_6()
	{
		return int_1;
	}

	[SpecialName]
	internal void method_7(int int_2)
	{
		int_1 = int_2;
	}

	internal void Read(byte[] byte_2, int int_2)
	{
		switch (byte_2[0])
		{
		case 1:
			Type = FormatConditionType.CellValue;
			break;
		case 2:
			Type = FormatConditionType.Expression;
			break;
		}
		switch (byte_2[1])
		{
		case 0:
			operatorType_0 = OperatorType.None;
			break;
		case 1:
			operatorType_0 = OperatorType.Between;
			break;
		case 2:
			operatorType_0 = OperatorType.NotBetween;
			break;
		case 3:
			operatorType_0 = OperatorType.Equal;
			break;
		case 4:
			operatorType_0 = OperatorType.NotEqual;
			break;
		case 5:
			operatorType_0 = OperatorType.GreaterThan;
			break;
		case 6:
			operatorType_0 = OperatorType.LessThan;
			break;
		case 7:
			operatorType_0 = OperatorType.GreaterOrEqual;
			break;
		case 8:
			operatorType_0 = OperatorType.LessOrEqual;
			break;
		}
		int num = BitConverter.ToInt16(byte_2, 2);
		int num2 = Class1730.smethod_0(byte_2, 6, Style);
		byte[] destinationArray = new byte[num + 2];
		Array.Copy(BitConverter.GetBytes(num), 0, destinationArray, 0, 2);
		Array.Copy(byte_2, num2, destinationArray, 2, num);
		byte_0 = destinationArray;
		if (operatorType_0 == OperatorType.Between || operatorType_0 == OperatorType.NotBetween)
		{
			num2 += num;
			num = BitConverter.ToInt16(byte_2, 4);
			destinationArray = new byte[num + 2];
			Array.Copy(BitConverter.GetBytes(num), 0, destinationArray, 0, 2);
			Array.Copy(byte_2, num2, destinationArray, 2, num);
			byte_1 = destinationArray;
		}
	}

	internal byte[] method_8(string string_3)
	{
		if (Worksheets.Workbook.method_23())
		{
			if (Class1677.smethod_19(string_3))
			{
				double num = double.Parse(string_3);
				byte[] array = null;
				if (num == (double)(int)num && num >= 0.0 && num <= 65535.0)
				{
					array = new byte[3] { 30, 0, 0 };
					Array.Copy(BitConverter.GetBytes((ushort)num), 0, array, 1, 2);
					return array;
				}
				array = new byte[9] { 31, 0, 0, 0, 0, 0, 0, 0, 0 };
				Array.Copy(BitConverter.GetBytes(num), 0, array, 1, 8);
				return array;
			}
			byte[] bytes = Encoding.Unicode.GetBytes(string_3);
			byte[] array2 = new byte[bytes.Length + 3];
			array2[0] = 23;
			Array.Copy(BitConverter.GetBytes((ushort)string_3.Length), 0, array2, 1, 2);
			Array.Copy(bytes, 0, array2, 3, bytes.Length);
			return array2;
		}
		if (Class1677.smethod_19(string_3))
		{
			double num2 = double.Parse(string_3);
			byte[] array3 = null;
			if (num2 == (double)(int)num2 && num2 >= 0.0 && num2 <= 65535.0)
			{
				array3 = new byte[3] { 30, 0, 0 };
				Array.Copy(BitConverter.GetBytes((ushort)num2), 0, array3, 1, 2);
				return array3;
			}
			array3 = new byte[9] { 31, 0, 0, 0, 0, 0, 0, 0, 0 };
			Array.Copy(BitConverter.GetBytes(num2), 0, array3, 1, 8);
			return array3;
		}
		byte[] array4 = Class1677.smethod_15(string_3);
		byte[] array5 = new byte[array4.Length + 3];
		array5[0] = 23;
		array5[1] = (byte)string_3.Length;
		array5[2] = (byte)((array4.Length != string_3.Length) ? 1u : 0u);
		Array.Copy(array4, 0, array5, 3, array4.Length);
		return array5;
	}

	internal byte[] method_9(string string_3)
	{
		if (string_3 != null && !string_3.Equals(""))
		{
			if (string_3[0] != '=')
			{
				byte[] array = method_8(string_3);
				byte[] array2 = null;
				if (Worksheets.Workbook.method_23())
				{
					array2 = new byte[array.Length + 8];
					Array.Copy(BitConverter.GetBytes(array.Length), 0, array2, 0, 4);
					Array.Copy(array, 0, array2, 4, array.Length);
				}
				else
				{
					array2 = new byte[array.Length + 2];
					Array.Copy(BitConverter.GetBytes(array.Length), 0, array2, 0, 2);
					Array.Copy(array, 0, array2, 2, array.Length);
				}
				return array2;
			}
			int rangeCount = formatConditionCollection_0.RangeCount;
			if (rangeCount < 1)
			{
				throw new CellsException(ExceptionType.ConditionalFormatting, "Cell range address list with all affected ranges can'n be null.");
			}
			int num = 0;
			int num2 = 0;
			int[] array3 = formatConditionCollection_0.method_9();
			num = array3[0];
			num2 = array3[1];
			return Worksheets.Formula.method_3(string_3, num, num2, Enum226.const_0, Enum227.const_1, bool_0: true, bool_1: true);
		}
		throw new CellsException(ExceptionType.ConditionalFormatting, "Formula can not be null.");
	}

	internal string method_10(byte[] byte_2, int int_2, int int_3, int int_4)
	{
		if (byte_2 == null)
		{
			return null;
		}
		bool flag = Class1674.smethod_2(Worksheets, byte_2, int_2, bool_0: true);
		string text = Worksheets.method_4().method_3(int_2, byte_2, int_3, int_4, bool_0: true);
		if (flag)
		{
			text = text.Substring(1);
			if (text.Length > 0 && text[0] == '"')
			{
				text = text.Substring(1, text.Length - 2);
			}
		}
		return text;
	}

	internal void method_11()
	{
		if (string_1 != null && byte_0 == null)
		{
			byte_0 = method_9(string_1);
		}
		if (string_2 != null && byte_1 == null)
		{
			byte_1 = method_9(string_2);
		}
	}

	private string method_12()
	{
		string text = Text;
		if (text == null)
		{
			return "";
		}
		if (text.Length > 0 && text[0] == '=')
		{
			return text.Substring(1);
		}
		return "\"" + method_14(text) + "\"";
	}

	internal string method_13()
	{
		int[] array = formatConditionCollection_0.method_9();
		if (array == null)
		{
			return null;
		}
		int row = array[0];
		int column = array[1];
		string text = CellsHelper.CellIndexToName(row, column);
		StringBuilder stringBuilder = new StringBuilder();
		switch (formatConditionType_0)
		{
		case FormatConditionType.Top10:
		{
			Top10 top = method_22();
			if (top != null && formatConditionCollection_0.arrayList_1.Count == 1)
			{
				string value = method_16(formatConditionCollection_0.arrayList_1);
				if (top.IsPercent)
				{
					stringBuilder.Append("=IF(INT(COUNT(");
					stringBuilder.Append(value);
					stringBuilder.Append(')');
					stringBuilder.Append('*');
					stringBuilder.Append(top.Rank);
					stringBuilder.Append("%)>0,");
					stringBuilder.Append(top.IsBottom ? "SMALL(" : "LARGE(");
					stringBuilder.Append(value);
					stringBuilder.Append(',');
					stringBuilder.Append("INT(COUNT(");
					stringBuilder.Append(value);
					stringBuilder.Append(')');
					stringBuilder.Append('*');
					stringBuilder.Append(top.Rank);
					stringBuilder.Append("%)),");
					stringBuilder.Append(top.IsBottom ? "MIN(" : "MAX(");
					stringBuilder.Append(value);
					stringBuilder.Append("))");
					stringBuilder.Append(top.IsBottom ? ">=" : "<=");
					stringBuilder.Append(text);
				}
				else
				{
					stringBuilder.Append("=");
					stringBuilder.Append(top.IsBottom ? "SMALL((" : "LARGE((");
					stringBuilder.Append(value);
					stringBuilder.Append("),MIN(");
					stringBuilder.Append(top.Rank);
					stringBuilder.Append(",COUNT(");
					stringBuilder.Append(value);
					stringBuilder.Append(")))");
					stringBuilder.Append(top.IsBottom ? ">=" : "<=");
					stringBuilder.Append(text);
				}
			}
			break;
		}
		case FormatConditionType.UniqueValues:
			return method_15('=', text);
		case FormatConditionType.DuplicateValues:
			return method_15('>', text);
		case FormatConditionType.ContainsText:
		{
			string text5 = method_12();
			if (text5 != null)
			{
				stringBuilder.Append("=NOT(ISERROR(SEARCH(");
				stringBuilder.Append(text5);
				stringBuilder.Append(",");
				stringBuilder.Append(text);
				stringBuilder.Append(")))");
			}
			break;
		}
		case FormatConditionType.NotContainsText:
		{
			string text4 = method_12();
			if (text4 != null)
			{
				stringBuilder.Append("=ISERROR(SEARCH(");
				stringBuilder.Append(text4);
				stringBuilder.Append(",");
				stringBuilder.Append(text);
				stringBuilder.Append("))");
			}
			break;
		}
		case FormatConditionType.BeginsWith:
		{
			string text3 = method_12();
			if (text3 != null)
			{
				stringBuilder.Append("=LEFT(");
				stringBuilder.Append(text);
				stringBuilder.Append(",LEN(");
				stringBuilder.Append(text3);
				stringBuilder.Append("))=");
				stringBuilder.Append(text3);
			}
			break;
		}
		case FormatConditionType.EndsWith:
		{
			string text2 = method_12();
			if (text2 != null)
			{
				stringBuilder.Append("=RIGHT(");
				stringBuilder.Append(text);
				stringBuilder.Append(",LEN(");
				stringBuilder.Append(text2);
				stringBuilder.Append("))=");
				stringBuilder.Append(text2);
			}
			break;
		}
		case FormatConditionType.ContainsBlanks:
			stringBuilder.Append("=LEN(TRIM(");
			stringBuilder.Append(text);
			stringBuilder.Append("))=0");
			break;
		case FormatConditionType.NotContainsBlanks:
			stringBuilder.Append("=LEN(TRIM(");
			stringBuilder.Append(text);
			stringBuilder.Append("))>0");
			break;
		case FormatConditionType.ContainsErrors:
			stringBuilder.Append("=ISERROR(");
			stringBuilder.Append(text);
			stringBuilder.Append(")");
			break;
		case FormatConditionType.NotContainsErrors:
			stringBuilder.Append("=NOT(ISERROR(");
			stringBuilder.Append(text);
			stringBuilder.Append("))");
			break;
		case FormatConditionType.TimePeriod:
			switch (TimePeriod)
			{
			case TimePeriodType.Today:
				stringBuilder.Append("=FLOOR(");
				stringBuilder.Append(text);
				stringBuilder.Append(",1)=TODAY()");
				break;
			case TimePeriodType.Yesterday:
				stringBuilder.Append("=FLOOR(");
				stringBuilder.Append(text);
				stringBuilder.Append(",1)=TODAY()-1");
				break;
			case TimePeriodType.Tomorrow:
				stringBuilder.Append("=FLOOR(");
				stringBuilder.Append(text);
				stringBuilder.Append(",1)=TODAY()+1");
				break;
			case TimePeriodType.Last7Days:
				stringBuilder.Append("=AND(TODAY()-FLOOR(");
				stringBuilder.Append(text);
				stringBuilder.Append(",1)<=6,FLOOR(");
				stringBuilder.Append(text);
				stringBuilder.Append(",1)<=TODAY())");
				break;
			case TimePeriodType.ThisMonth:
				stringBuilder.Append("=AND(MONTH(");
				stringBuilder.Append(text);
				stringBuilder.Append(")=MONTH(TODAY()),YEAR(");
				stringBuilder.Append(text);
				stringBuilder.Append(")=YEAR(TODAY()))");
				break;
			case TimePeriodType.LastMonth:
				stringBuilder.Append("=AND(MONTH(");
				stringBuilder.Append(text);
				stringBuilder.Append(")=MONTH(TODAY())-1,OR(YEAR(");
				stringBuilder.Append(text);
				stringBuilder.Append(")=YEAR(TODAY()),AND(MONTH(");
				stringBuilder.Append(text);
				stringBuilder.Append(")=1,YEAR(");
				stringBuilder.Append(text);
				stringBuilder.Append(")=YEAR(TODAY())-1)))");
				break;
			case TimePeriodType.NextMonth:
				stringBuilder.Append("=AND(MONTH(");
				stringBuilder.Append(text);
				stringBuilder.Append(")=MONTH(TODAY())+1,OR(YEAR(");
				stringBuilder.Append(text);
				stringBuilder.Append(")=YEAR(TODAY()),AND(MONTH(");
				stringBuilder.Append(text);
				stringBuilder.Append(")=12,YEAR(");
				stringBuilder.Append(text);
				stringBuilder.Append(")=YEAR(TODAY())+1)))");
				break;
			case TimePeriodType.ThisWeek:
				stringBuilder.Append("=AND(TODAY()-ROUNDDOWN(");
				stringBuilder.Append(text);
				stringBuilder.Append(",0)<=WEEKDAY(TODAY())-1,ROUNDDOWN(");
				stringBuilder.Append(text);
				stringBuilder.Append(",0)-TODAY()<=7-WEEKDAY(TODAY()))");
				break;
			case TimePeriodType.LastWeek:
				stringBuilder.Append("=AND(TODAY()-ROUNDDOWN(");
				stringBuilder.Append(text);
				stringBuilder.Append(",0)>=(WEEKDAY(TODAY())),TODAY()-ROUNDDOWN(");
				stringBuilder.Append(text);
				stringBuilder.Append(",0)<(WEEKDAY(TODAY())+7))");
				break;
			case TimePeriodType.NextWeek:
				stringBuilder.Append("=AND(ROUNDDOWN(");
				stringBuilder.Append(text);
				stringBuilder.Append(",0)-TODAY()>(7-WEEKDAY(TODAY())),ROUNDDOWN(");
				stringBuilder.Append(text);
				stringBuilder.Append(",0)-TODAY()<(15-WEEKDAY(TODAY())))");
				break;
			}
			break;
		}
		if (stringBuilder.Length == 0)
		{
			return null;
		}
		return stringBuilder.ToString();
	}

	private string method_14(string string_3)
	{
		return string_3.Replace("\"", "\"\"");
	}

	private string method_15(char char_0, string string_3)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("=AND(");
		for (int i = 0; i < formatConditionCollection_0.arrayList_1.Count; i++)
		{
			CellArea cellArea_ = (CellArea)formatConditionCollection_0.arrayList_1[i];
			stringBuilder.Append("COUNTIF(");
			method_17(cellArea_, stringBuilder);
			stringBuilder.Append(",");
			stringBuilder.Append(string_3);
			stringBuilder.Append(')');
			if (i != formatConditionCollection_0.arrayList_1.Count - 1)
			{
				stringBuilder.Append('+');
			}
		}
		stringBuilder.Append(char_0);
		stringBuilder.Append("1,NOT(ISBLANK(");
		stringBuilder.Append(string_3);
		stringBuilder.Append(")))");
		return stringBuilder.ToString();
	}

	private string method_16(ArrayList arrayList_0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (arrayList_0.Count > 1)
		{
			stringBuilder.Append('(');
		}
		for (int i = 0; i < arrayList_0.Count; i++)
		{
			CellArea cellArea_ = (CellArea)arrayList_0[i];
			method_17(cellArea_, stringBuilder);
			if (i != arrayList_0.Count - 1)
			{
				stringBuilder.Append(',');
			}
		}
		if (arrayList_0.Count > 1)
		{
			stringBuilder.Append(')');
		}
		return stringBuilder.ToString();
	}

	private void method_17(CellArea cellArea_0, StringBuilder stringBuilder_0)
	{
		stringBuilder_0.Append('$');
		stringBuilder_0.Append(CellsHelper.ColumnIndexToName(cellArea_0.StartColumn));
		stringBuilder_0.Append('$');
		stringBuilder_0.Append(cellArea_0.StartRow + 1);
		stringBuilder_0.Append(':');
		stringBuilder_0.Append('$');
		stringBuilder_0.Append(CellsHelper.ColumnIndexToName(cellArea_0.EndColumn));
		stringBuilder_0.Append('$');
		stringBuilder_0.Append(cellArea_0.EndRow + 1);
	}

	internal void method_18(IconSet iconSet_1)
	{
		iconSet_0 = iconSet_1;
	}

	internal void method_19(DataBar dataBar_1)
	{
		dataBar_0 = dataBar_1;
	}

	internal void method_20(ColorScale colorScale_1)
	{
		colorScale_0 = colorScale_1;
	}

	internal void method_21(Top10 top10_1)
	{
		top10_0 = top10_1;
	}

	internal Top10 method_22()
	{
		return top10_0;
	}

	internal bool method_23()
	{
		bool result = false;
		if (Type == FormatConditionType.IconSet)
		{
			switch (IconSet.Type)
			{
			default:
				result = false;
				break;
			case IconSetType.Stars3:
			case IconSetType.Boxes5:
			case IconSetType.Triangles3:
				result = true;
				break;
			}
		}
		return result;
	}

	internal bool method_24()
	{
		if (Type == FormatConditionType.DataBar)
		{
			return true;
		}
		return false;
	}

	internal void method_25(bool bool_1, int int_2, int int_3)
	{
		method_11();
		if (method_0() != null)
		{
			method_1(Class415.smethod_0(bool_1, method_0(), -1, int_2, int_3, bool_1: true));
		}
		if (method_4() != null)
		{
			method_5(Class415.smethod_0(bool_1, method_4(), -1, int_2, int_3, bool_1: true));
		}
		switch (formatConditionType_0)
		{
		case FormatConditionType.ColorScale:
			if (ColorScale.conditionalFormattingValue_2 != null)
			{
				ColorScale.conditionalFormattingValue_2.method_8(bool_1, int_2, int_3);
			}
			if (ColorScale.conditionalFormattingValue_1 != null)
			{
				ColorScale.conditionalFormattingValue_1.method_8(bool_1, int_2, int_3);
			}
			if (ColorScale.conditionalFormattingValue_0 != null)
			{
				ColorScale.conditionalFormattingValue_0.method_8(bool_1, int_2, int_3);
			}
			break;
		case FormatConditionType.DataBar:
			if (DataBar.conditionalFormattingValue_1 != null)
			{
				DataBar.conditionalFormattingValue_1.method_8(bool_1, int_2, int_3);
			}
			if (DataBar.conditionalFormattingValue_0 != null)
			{
				DataBar.conditionalFormattingValue_0.method_8(bool_1, int_2, int_3);
			}
			break;
		case FormatConditionType.IconSet:
		{
			for (int i = 0; i < IconSet.Cfvos.Count; i++)
			{
				ConditionalFormattingValue conditionalFormattingValue = IconSet.Cfvos[i];
				conditionalFormattingValue.method_8(bool_1, int_2, int_3);
			}
			break;
		}
		}
	}
}
