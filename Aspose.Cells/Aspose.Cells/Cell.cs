using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using ns1;
using ns12;
using ns14;
using ns16;
using ns2;
using ns22;
using ns25;
using ns29;

namespace Aspose.Cells;

/// <summary>
///        Encapsulates the object that represents a single Workbook cell.
///        </summary>
/// <example>
///   <code>
///       	[C#]
///
///       	Workbook excel = new Workbook();
///       	Cells cells = excel.Worksheets[0].Cells;
///
///       	//Put a string into a cell
///       	Cell cell = cells[0, 0];
///       	cell.PutValue("Hello");
///
///       	string first = cell.StringValue;
///
///       	//Put an integer into a cell
///       	cell = cells["B1"];
///       	cell.PutValue(12);
///
///       	int second = cell.IntValue;
///
///       	//Put a double into a cell
///       	cell = cells[0, 2];
///       	cell.PutValue(-1.234);
///
///       	double third = cell.DoubleValue;
///
///       	//Put a formula into a cell
///       	cell = cells["D1"];
///       	cell.Formula = "=B1 + C1";
///
///       	//Put a combined formula: "sum(average(b1,c1), b1)" to cell at b2
///       	cell = cells["b2"];
///       	cell.Formula = "=sum(average(b1,c1), b1)";
///
///       	//Set style of a cell
///       	Style style = cell.GetStyle();
///       	//Set background color
///       	style.BackgroundColor = Color.Yellow;
///       	//Set format of a cell
///       	style.Font.Name = "Courier New";
///       	style.VerticalAlignment = TextAlignmentType.Top;
///        cell.SetStyle(style);
///
///
///
///        [Visual Basic]
///
///       	Dim excel as Workbook = new Workbook()
///       	Dim cells as Cells = exce.Worksheets(0).Cells
///
///       	'Put a string into a cell
///       	Dim cell as Cell = cells(0, 0)
///       	cell.PutValue("Hello")
///
///       	Dim first as String = cell.StringValue
///
///       	//Put an integer into a cell
///       	cell = cells("B1")
///       	cell.PutValue(12)
///
///       	Dim second as Integer = cell.IntValue
///
///       	//Put a double into a cell
///       	cell = cells(0, 2)
///       	cell.PutValue(-1.234)
///
///       	Dim third as Double = cell.DoubleValue
///
///       	//Put a formula into a cell
///       	cell = cells("D1")
///       	cell.Formula = "=B1 + C1"
///
///       	//Put a combined formula: "sum(average(b1,c1), b1)" to cell at b2
///       	cell = cells("b2")
///       	cell.Formula = "=sum(average(b1,c1), b1)"
///
///       	//Set style of a cell
///       	Dim style as Style = cell.GetStyle()
///
///       	//Set background color
///       	style.BackgroundColor = Color.Yellow
///       	//Set font of a cell
///       	style.Font.Name = "Courier New"
///       	style.VerticalAlignment = TextAlignmentType.Top
///       	cell.SetStyle(style)
///       </code>
/// </example>
public class Cell
{
	private int int_0;

	private short short_0;

	private Cells cells_0;

	internal int int_1 = -1;

	internal object object_0;

	internal ArrayList arrayList_0;

	/// <summary>
	///       Gets the parent worksheet.
	///       </summary>
	public Worksheet Worksheet => cells_0.method_3();

	/// <summary>
	///       Gets the DateTime value contained in the cell.
	///       </summary>
	public DateTime DateTimeValue
	{
		get
		{
			if (object_0 == null)
			{
				throw new CellsException(ExceptionType.InvalidOperator, "Cell contains no data in Cell " + Name);
			}
			object obj = object_0;
			if (obj is Class1655)
			{
				obj = ((Class1655)object_0).object_0;
				if (obj == null)
				{
					throw new CellsException(ExceptionType.InvalidOperator, "Cell contains no data in Cell " + Name);
				}
			}
			return System.Type.GetTypeCode(obj.GetType()) switch
			{
				TypeCode.Double => CellsHelper.GetDateTimeFromDouble((double)obj, cells_0.method_19().Workbook.Settings.Date1904), 
				TypeCode.DateTime => (DateTime)obj, 
				TypeCode.Int32 => CellsHelper.GetDateTimeFromDouble((int)obj, cells_0.method_19().Workbook.Settings.Date1904), 
				_ => throw new CellsException(ExceptionType.InvalidOperator, "Not a DateTime value in Cell " + Name), 
			};
		}
	}

	/// <summary>
	///       Gets row number (zero based) of the cell.
	///       </summary>
	/// <value>Cell row number</value>
	public int Row => int_0;

	/// <summary>
	///       Gets column number (zero based) of the cell.
	///       </summary>
	public int Column => short_0;

	/// <summary>
	///       Represents if the specified cell contains formula.
	///       </summary>
	public bool IsFormula
	{
		get
		{
			if (object_0 != null)
			{
				return object_0 is Class1655;
			}
			return false;
		}
	}

	/// <summary>
	///       Represents cell value type.
	///       </summary>
	public CellValueType Type
	{
		get
		{
			if (object_0 == null)
			{
				return CellValueType.IsNull;
			}
			object obj = object_0;
			if (obj is Class1655)
			{
				obj = ((Class1655)object_0).object_0;
				if (obj == null)
				{
					return CellValueType.IsNull;
				}
			}
			switch (System.Type.GetTypeCode(obj.GetType()))
			{
			case TypeCode.DateTime:
				return CellValueType.IsDateTime;
			default:
				if (obj is Class1719)
				{
					return CellValueType.IsString;
				}
				return CellValueType.IsUnknown;
			case TypeCode.String:
				if (Class1673.smethod_7((string)obj))
				{
					return CellValueType.IsError;
				}
				return CellValueType.IsString;
			case TypeCode.Int32:
			case TypeCode.Double:
				if (method_32().IsDateTime)
				{
					return CellValueType.IsDateTime;
				}
				return CellValueType.IsNumeric;
			case TypeCode.Boolean:
				return CellValueType.IsBool;
			}
		}
	}

	/// <summary>
	///       Gets the name of the cell. 
	///       </summary>
	/// <remarks>
	///       A cell name includes its column letter and row number. For example, the name of a cell in row 0 and column 0 is A1.
	///       </remarks>
	public string Name => CellsHelper.CellIndexToName(int_0, short_0);

	/// <summary>
	///       Checks if a formula can properly evaluate a result.
	///       </summary>
	/// <remarks>Only applies to formula cell.</remarks>
	public bool IsErrorValue
	{
		get
		{
			if (!IsFormula)
			{
				return false;
			}
			Class1655 @class = (Class1655)object_0;
			object obj = @class.object_0;
			if (obj != null && obj is string)
			{
				return Class1673.smethod_7((string)obj);
			}
			return false;
		}
	}

	/// <summary>
	///       Gets the string value contained in the cell.
	///       </summary>
	public string StringValue
	{
		get
		{
			if (object_0 == null)
			{
				return "";
			}
			object obj = method_26();
			if (obj == null)
			{
				return "";
			}
			if (obj is string)
			{
				return (string)obj;
			}
			Style style = method_32();
			TypeCode typeCode = System.Type.GetTypeCode(obj.GetType());
			Interface3 @interface = null;
			@interface = ((style.Custom == null || style.Custom == "") ? Worksheet.Workbook.Settings.method_3().method_10(style.Number) : Worksheet.Workbook.Settings.method_3().method_11(style.Custom, bool_1: true));
			Class518 @class = @interface.Format(Worksheet.Workbook.Settings.method_3().method_9(), typeCode, obj);
			if (@class.method_4())
			{
				return "#";
			}
			int num = @class.method_9();
			if (num > 0)
			{
				int num2 = num - 1;
				while (num2 > -1)
				{
					if (!@class.method_10(num2))
					{
						num2--;
						continue;
					}
					char[] value = @class.Value;
					if (value == null)
					{
						return @class.method_13(num2).ToString();
					}
					char[] array = new char[value.Length + 1];
					int num3 = @class.method_11(num2);
					Array.Copy(value, array, num3);
					array[num3] = @class.method_13(num2);
					Array.Copy(value, num3, array, num3 + 1, value.Length - num3);
					return new string(array);
				}
			}
			return @class.StringValue;
		}
	}

	public string DisplayStringValue
	{
		get
		{
			object obj = method_26();
			if (obj == null)
			{
				return "";
			}
			Worksheet.Workbook.Settings.method_3();
			Class515 @class = new Class515();
			Class425 class2 = new Class425(this);
			@class.method_1(class2);
			Class518 class3 = method_22().Format(@class, obj);
			if (class3.method_4())
			{
				int num = class2.vmethod_6(null, '#');
				if (num < 1)
				{
					return "";
				}
				return new string('#', num);
			}
			int num2 = class3.method_9() - 1;
			int num3;
			while (true)
			{
				if (num2 > -1)
				{
					if (class3.method_10(num2))
					{
						num3 = class2.vmethod_6(class3.StringValue, class3.method_13(num2));
						if (num3 > 0)
						{
							break;
						}
					}
					num2--;
					continue;
				}
				return class3.method_6(0, bool_1: true);
			}
			return class3.method_6(num3, bool_1: true);
		}
	}

	/// <summary>
	///       Gets the integer value contained in the cell.
	///       </summary>
	public int IntValue
	{
		get
		{
			double doubleValue = DoubleValue;
			if (!(doubleValue <= 2147483647.0) || doubleValue < -2147483648.0)
			{
				throw new CellsException(ExceptionType.InvalidOperator, "Cell value type is double , but the value is out of integer range.");
			}
			return (int)doubleValue;
		}
	}

	/// <summary>
	///       Gets the double value contained in the cell.
	///       </summary>
	public double DoubleValue
	{
		get
		{
			if (object_0 == null)
			{
				throw new CellsException(ExceptionType.InvalidOperator, "Cell contains no data in Cell " + Name);
			}
			object obj = object_0;
			if (obj is Class1655)
			{
				obj = ((Class1655)obj).object_0;
				if (obj == null)
				{
					throw new CellsException(ExceptionType.InvalidOperator, "Cell contains no data in Cell " + Name);
				}
			}
			return System.Type.GetTypeCode(obj.GetType()) switch
			{
				TypeCode.Double => (double)obj, 
				TypeCode.DateTime => CellsHelper.GetDoubleFromDateTime((DateTime)obj, cells_0.method_19().Workbook.Settings.Date1904), 
				TypeCode.Int32 => (int)obj, 
				_ => throw new CellsException(ExceptionType.InvalidOperator, "Not a numeric value in Cell " + Name), 
			};
		}
	}

	/// <summary>
	///       Gets the float value contained in the cell.
	///       </summary>
	public float FloatValue
	{
		get
		{
			double doubleValue = DoubleValue;
			if (!(doubleValue < 3.4028234663852886E+38) || doubleValue <= -3.4028234663852886E+38)
			{
				throw new CellsException(ExceptionType.InvalidOperator, "Cell value type is double ,but the value is out of float range.");
			}
			return (float)doubleValue;
		}
	}

	/// <summary>
	///       Gets the boolean value contained in the cell.
	///       </summary>
	public bool BoolValue
	{
		get
		{
			if (object_0 == null)
			{
				throw new CellsException(ExceptionType.InvalidOperator, "Cell contains no datain in Cell" + Name);
			}
			object obj = object_0;
			if (obj is Class1655)
			{
				obj = ((Class1655)object_0).object_0;
			}
			if (obj == null || !(obj is bool))
			{
				throw new CellsException(ExceptionType.InvalidOperator, "Cell value type is not booleanin Cell" + Name);
			}
			return (bool)obj;
		}
	}

	public int SharedStyleIndex => method_35();

	/// <summary>
	///        Gets or sets a formula of the <see cref="T:Aspose.Cells.Cell" />.
	///        </summary>
	/// <remarks>A formula string always begins with an equal sign (=). 
	///       And please always use comma(,) as parameters delimeter, such as "=SUM(A1, E1, H2)".<p></p>
	///       User can set any formula in Workbook designer file. Aspose.Cells will keep all the formulas.
	///       If user use this property to set a formula to a cell, major part of Workbook built-in functions
	///       is supported. And more is coming. If you have any special need for Workbook built-in functions, 
	///       please let us know.		
	///       </remarks>
	/// <example>
	///   <code>
	///       [C#]
	///
	///       Workbook excel = new Workbook();
	///       Cells cells = excel.Worksheets[0];
	///       cells["B6"].Formula = "=SUM(B2:B5, E1) + sheet2!A1";
	///
	///       [Visual Basic]
	///
	///       Dim excel As Workbook =  New Workbook() 
	///       Dim cells As Cells =  excel.Worksheets(0) 
	///       cells("B6").Formula = "=SUM(B2:B5, E1) + sheet2!A1"
	///       </code>
	/// </example>
	public string Formula
	{
		get
		{
			if (!IsFormula)
			{
				return null;
			}
			cells_0.method_19().Workbook.method_5();
			Class1655 @class = (Class1655)object_0;
			if (@class.string_0 == null || @class.string_0 == "")
			{
				@class.string_0 = cells_0.method_19().method_4().method_2(this);
			}
			return @class.string_0;
		}
		set
		{
			method_6();
			if (value != null && value != "")
			{
				cells_0.method_19().Formula.method_4(this, value.Trim(), 0, bool_0: true);
			}
			if (cells_0.method_19().Workbook.bool_0)
			{
				cells_0.method_19().Workbook.class1380_0.method_2(this);
			}
		}
	}

	/// <summary>
	///       Gets or sets a R1C1 formula of the <see cref="T:Aspose.Cells.Cell" />.
	///       </summary>
	public string R1C1Formula
	{
		get
		{
			if (!IsFormula)
			{
				return null;
			}
			cells_0.method_19().Workbook.method_5();
			return Class1619.smethod_2(this);
		}
		set
		{
			string formula = Class1619.smethod_10(value, int_0, short_0);
			Formula = formula;
		}
	}

	/// <summary>
	///       Indicates wether this cell contains an external link.
	///       Only applies when the cell is a formula cell.
	///       </summary>
	public bool ContainsExternalLink
	{
		get
		{
			if (IsFormula)
			{
				cells_0.method_19().Workbook.method_5();
				byte[] array = method_41();
				if (!cells_0.method_19().Formula.method_13(1, array))
				{
					return Class1674.smethod_12(array, -1, -1, cells_0.method_19());
				}
				int row = 0;
				int column = 0;
				cells_0.method_19().Formula.method_14(array, out row, out column);
				Cell cell = cells_0.CheckCell(row, column);
				if (cell != null)
				{
					Class1348 @class = cell.method_50();
					byte[] formula = @class.Formula;
					return Class1674.smethod_12(formula, -1, -1, cells_0.method_19());
				}
			}
			return false;
		}
	}

	/// <summary>
	///       Inidicates the cell's formula is and array formula 
	///       and it is the first cell of the array.
	///       </summary>
	public bool IsArrayHeader
	{
		get
		{
			if (IsFormula)
			{
				return ((Class1655)object_0).IsArrayHeader;
			}
			return false;
		}
	}

	/// <summary>
	///       Indicates whether the cell formula is an array formula.
	///       </summary>
	public bool IsInArray
	{
		get
		{
			if (IsFormula)
			{
				return ((Class1655)object_0).IsInArray;
			}
			return false;
		}
	}

	public bool IsInTable
	{
		get
		{
			if (IsFormula)
			{
				return ((Class1655)object_0).method_10(cells_0);
			}
			return false;
		}
	}

	/// <summary>
	///       Gets the value contained in this cell.
	///       </summary>
	/// <remarks>Possible type:
	///       <p>null,</p><p>Boolean,</p><p>DateTime,</p><p>Double,</p><p>Integer</p><p>String.</p></remarks>
	public object Value
	{
		get
		{
			if (object_0 == null)
			{
				return null;
			}
			if (object_0 is Class1719)
			{
				return ((Class1719)object_0).string_0;
			}
			object obj = object_0;
			if (obj is Class1655)
			{
				obj = ((Class1655)object_0).object_0;
				if (obj == null)
				{
					return null;
				}
			}
			switch (System.Type.GetTypeCode(obj.GetType()))
			{
			case TypeCode.Double:
				if (method_32().IsDateTime)
				{
					double num = (double)obj;
					if (num >= 0.0)
					{
						return CellsHelper.GetDateTimeFromDouble((double)obj, cells_0.method_19().Workbook.Settings.Date1904);
					}
				}
				return obj;
			default:
				return obj;
			case TypeCode.DateTime:
				return obj;
			case TypeCode.Int32:
				if (method_32().IsDateTime)
				{
					return CellsHelper.GetDateTimeFromDouble((int)obj, cells_0.method_19().Workbook.Settings.Date1904);
				}
				return obj;
			}
		}
		set
		{
			PutValue(value);
		}
	}

	/// <summary>
	///       Indicates if the cell's style is set. If return false, it means this cell has a default cell format.
	///       </summary>
	public bool IsStyleSet => method_34();

	/// <summary>
	///       Checks if a cell is part of a merged range or not. 
	///       </summary>
	public bool IsMerged => cells_0.method_18().method_1(int_0, short_0);

	/// <summary>
	///       Gets and sets the html string which contains data and some formattings in this cell.
	///       </summary>
	public string HtmlString
	{
		get
		{
			return Class1385.smethod_1(this);
		}
		set
		{
			Class1385.smethod_6(this, value);
		}
	}

	internal bool IsBlank
	{
		get
		{
			if (object_0 == null)
			{
				return true;
			}
			if (method_20() == Enum199.const_6)
			{
				return StringValue == "";
			}
			return false;
		}
	}

	internal Comment Comment
	{
		get
		{
			CommentCollection comments = cells_0.method_3().Comments;
			int num = 0;
			Comment comment;
			while (true)
			{
				if (num < comments.Count)
				{
					comment = comments[num];
					if (comment.Row == int_0 && comment.Column == short_0)
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
	}

	public IEnumerator GetLeafs()
	{
		if (arrayList_0 == null)
		{
			return null;
		}
		return arrayList_0.GetEnumerator();
	}

	internal void method_0(Cell cell_0)
	{
		if (cell_0 != null && cells_0.method_19().Workbook.Settings.CreateCalcChain && cell_0 != this)
		{
			if (arrayList_0 == null)
			{
				arrayList_0 = new ArrayList();
			}
			if (!arrayList_0.Contains(cell_0))
			{
				arrayList_0.Add(cell_0);
			}
		}
	}

	internal void method_1(Cell cell_0)
	{
		if (arrayList_0 != null)
		{
			arrayList_0.Remove(cell_0);
		}
	}

	internal void method_2()
	{
		if (arrayList_0 != null)
		{
			arrayList_0.Clear();
		}
	}

	[SpecialName]
	internal ArrayList method_3()
	{
		return cells_0.method_19().Workbook.class1382_0.method_1(cells_0.method_3(), int_0, short_0);
	}

	public void Calculate(bool ignoreError, ICustomFunction customFunction)
	{
		if (!IsFormula)
		{
			return;
		}
		try
		{
			Class1658 @class = new Class1658(cells_0.method_19().Workbook);
			@class.method_5(ignoreError, customFunction);
			@class.method_0(Enum47.const_1);
			object object_ = @class.method_3(this);
			method_66(object_, 2);
		}
		catch (Exception exception_)
		{
			if (!ignoreError)
			{
				throw new CellsException(ExceptionType.Formula, Class1183.smethod_0(exception_) + "\nError in calculating cell " + Name + " in Worksheet " + cells_0.method_3().Name);
			}
		}
	}

	[SpecialName]
	internal Cells method_4()
	{
		return cells_0;
	}

	/// <summary>
	///       Sets formula data
	///       </summary>
	/// <param name="buffer">Data buffer</param>
	/// <param name="biffVersion">
	/// </param>
	internal void SetFormula(byte[] byte_0, FileFormatType fileFormatType_0)
	{
		byte[] array = new byte[byte_0.Length - 20];
		Array.Copy(byte_0, 20, array, 0, array.Length);
		if (byte_0[12] == byte.MaxValue && byte_0[13] == byte.MaxValue)
		{
			switch (byte_0[6])
			{
			default:
			{
				double num = BitConverter.ToDouble(byte_0, 6);
				object_0 = ((num == 0.0) ? Class1391.object_2 : ((object)num));
				break;
			}
			case 1:
				object_0 = ((byte_0[8] == 0) ? Class1391.object_1 : Class1391.object_0);
				break;
			case 2:
				object_0 = Class1673.smethod_6(byte_0[8]);
				break;
			case 3:
				object_0 = null;
				break;
			case 0:
				break;
			}
		}
		else
		{
			double num2 = BitConverter.ToDouble(byte_0, 6);
			object_0 = ((num2 == 0.0) ? Class1391.object_2 : ((object)num2));
		}
		object_0 = new Class1655(null, array, object_0);
		if (array[0] == 5 && array[1] == 0 && array[2] == 1)
		{
			int row = 0;
			int column = 0;
			cells_0.method_19().Formula.method_14(array, out row, out column);
			Cell cell = cells_0.CheckCell(row, column);
			if (cell != null && cell.IsFormula && cell.method_50() != null && cell.method_50().method_1())
			{
				((Class1655)object_0).method_8(bool_0: true);
			}
		}
	}

	internal Cell(int int_2, short short_1, Cells cells_1)
	{
		int_0 = int_2;
		short_0 = short_1;
		cells_0 = cells_1;
		if (short_1 > cells_1.MaxColumn)
		{
			cells_1.method_21(short_1);
		}
	}

	internal Cell(Cells cells_1)
	{
		cells_0 = cells_1;
	}

	internal virtual void vmethod_0(int int_2)
	{
		object_0 = null;
		int_1 = -1;
		short_0 = (short)int_2;
	}

	/// <summary>
	///       Puts an boolean value into the cell.
	///       </summary>
	/// <param name="boolValue">
	/// </param>
	public void PutValue(bool boolValue)
	{
		method_6();
		object_0 = (boolValue ? Class1391.object_0 : Class1391.object_1);
	}

	/// <summary>
	///       Puts an integer value into the cell.
	///       </summary>
	/// <param name="intValue">Input value</param>
	public void PutValue(int intValue)
	{
		method_6();
		object_0 = ((intValue == 0) ? Class1391.object_2 : ((object)intValue));
	}

	/// <summary>
	///       Puts a double value into the cell.
	///       </summary>
	/// <param name="doubleValue">Input value</param>
	public void PutValue(double doubleValue)
	{
		method_6();
		if (!double.IsNaN(doubleValue) && !double.IsInfinity(doubleValue))
		{
			object_0 = ((doubleValue == 0.0) ? Class1391.object_3 : ((object)doubleValue));
		}
		else
		{
			object_0 = "#N/A";
		}
	}

	internal void method_5(double double_0)
	{
		object_0 = ((double_0 == 0.0) ? Class1391.object_3 : ((object)double_0));
	}

	internal void method_6()
	{
		if (!cells_0.method_19().Workbook.bool_0)
		{
			if (object_0 != null)
			{
				switch (method_20())
				{
				case Enum199.const_4:
					method_72();
					break;
				case Enum199.const_6:
					cells_0.method_19().class1301_0.method_10(object_0, this);
					break;
				}
				object_0 = null;
			}
			return;
		}
		if (IsFormula)
		{
			method_72();
			cells_0.method_19().Workbook.class1380_0.method_2(this);
			method_61(0);
			if (cells_0.method_19().Workbook.class1382_0 != null)
			{
				cells_0.method_19().Workbook.class1382_0.RemoveRange(this);
			}
			Class1655 @class = (Class1655)object_0;
			byte[] byte_ = @class.byte_0;
			Class1674.smethod_7(byte_, -1, -1, this);
			cells_0.method_19().Workbook.class1382_0.RemoveRange(this);
			object_0 = null;
			return;
		}
		if (Type == CellValueType.IsString)
		{
			cells_0.method_19().class1301_0.method_10(object_0, this);
		}
		object_0 = null;
		if (cells_0.method_19().Workbook.class1382_0 != null)
		{
			cells_0.method_19().Workbook.class1382_0.RemoveRange(this);
		}
		IEnumerator leafs = GetLeafs();
		if (leafs != null)
		{
			while (leafs.MoveNext())
			{
				Cell cell = (Cell)leafs.Current;
				cells_0.method_19().Workbook.class1380_0.method_2(cell);
				cell.method_61(0);
			}
		}
		if (method_3().Count <= 0)
		{
			return;
		}
		foreach (Cell item in method_3())
		{
			cells_0.method_19().Workbook.class1380_0.method_2(item);
			item.method_61(0);
		}
	}

	public void PutValue(string stringValue, bool isConverted, bool setStyle)
	{
		method_6();
		if (stringValue != null && !(stringValue == "") && isConverted)
		{
			Class530 @class = Class1345.smethod_0(stringValue, cells_0.method_19().Workbook.Settings);
			if (@class == null)
			{
				PutValue(stringValue);
				return;
			}
			PutValue(@class.Value);
			if (setStyle)
			{
				Style style = GetStyle();
				style.Custom = @class.method_3();
				SetStyle(style);
			}
		}
		else
		{
			PutValue(stringValue);
		}
	}

	/// <summary>
	///       Puts a string value into the cell and converts the value to other data type if appropriate.
	///       </summary>
	/// <param name="stringValue">Input value</param>
	/// <param name="isConverted">True: converted to other data type if appropriate.</param>
	public void PutValue(string stringValue, bool isConverted)
	{
		PutValue(stringValue, isConverted, setStyle: false);
	}

	/// <summary>
	///       Puts a string value into the cell.
	///       </summary>
	/// <param name="stringValue">Input value</param>
	public virtual void PutValue(string stringValue)
	{
		method_6();
		if (stringValue != null)
		{
			if (stringValue.Length > 0 && stringValue[0] == '\'')
			{
				Style style = GetStyle();
				style.method_48(bool_0: true);
				stringValue = stringValue.Substring(1);
				method_30(style);
			}
			method_7(stringValue);
		}
	}

	internal void method_7(string string_0)
	{
		if (Class1673.smethod_8(string_0))
		{
			object_0 = string_0;
			return;
		}
		if (Worksheet.Workbook.Settings.CheckExcelRestriction && string_0.Length > 32767)
		{
			throw new CellsException(ExceptionType.Limitation, "You want to put a string longer than 32K to Cell " + Name + ". MS Excel only allows to put a string shorter than 32K to a Cell.");
		}
		cells_0.method_19().class1301_0.method_8(string_0, this);
	}

	/// <summary>
	///       Puts a DateTime value into the cell.
	///       </summary>
	/// <param name="dateTime">Input value</param>
	public void PutValue(DateTime dateTime)
	{
		method_6();
		double doubleFromDateTime = CellsHelper.GetDoubleFromDateTime(dateTime, cells_0.method_19().Workbook.Settings.Date1904);
		if (doubleFromDateTime < 0.0)
		{
			Style style = method_32();
			string text = null;
			text = ((!style.IsDateTime) ? dateTime.ToString() : smethod_0(style, dateTime));
			PutValue(text);
		}
		else
		{
			PutValue(doubleFromDateTime);
		}
	}

	private static string smethod_0(Style style_0, object object_1)
	{
		WorkbookSettings settings = style_0.method_5().Workbook.Settings;
		bool bool_ = settings.bool_3;
		return Class1386.smethod_16(style_0.Number, style_0.Custom, object_1, settings.Date1904, settings.Region, settings.CultureInfo, bool_);
	}

	/// <summary>
	///       Puts an object value into the cell.
	///       </summary>
	/// <param name="objectValue">input value</param>
	public void PutValue(object objectValue)
	{
		method_6();
		if (objectValue == null)
		{
			return;
		}
		Type type = objectValue.GetType();
		switch (System.Type.GetTypeCode(type))
		{
		case TypeCode.Empty:
		case TypeCode.DBNull:
			method_6();
			break;
		case TypeCode.Boolean:
			PutValue(Class1179.smethod_0(objectValue));
			break;
		case TypeCode.Char:
			PutValue(((char)objectValue).ToString());
			break;
		case TypeCode.SByte:
			PutValue((sbyte)objectValue);
			break;
		case TypeCode.Byte:
			PutValue((byte)objectValue);
			break;
		case TypeCode.Int16:
			PutValue((short)objectValue);
			break;
		case TypeCode.UInt16:
			PutValue((ushort)objectValue);
			break;
		case TypeCode.Int32:
			PutValue(Class1179.ToInt(objectValue));
			break;
		case TypeCode.UInt32:
			if ((long)(uint)objectValue > 536870911L)
			{
				PutValue((uint)objectValue);
			}
			else
			{
				PutValue(Class1179.smethod_2((uint)objectValue));
			}
			break;
		case TypeCode.Int64:
		{
			long num = (long)objectValue;
			if (num <= 536870911 && num >= -536870911)
			{
				PutValue((int)num);
			}
			else
			{
				PutValue(num);
			}
			break;
		}
		case TypeCode.UInt64:
			if ((long)(ulong)objectValue > 536870911L)
			{
				PutValue((ulong)objectValue);
			}
			else
			{
				PutValue(Class1179.smethod_3((ulong)objectValue));
			}
			break;
		case TypeCode.Single:
			PutValue((float)objectValue);
			break;
		case TypeCode.Double:
			PutValue(Class1179.ToDouble(objectValue));
			break;
		case TypeCode.Decimal:
			PutValue(Class1179.ToDouble((decimal)objectValue));
			break;
		case TypeCode.DateTime:
			PutValue((DateTime)objectValue);
			break;
		default:
			PutValue(objectValue.ToString());
			break;
		case TypeCode.String:
			PutValue((string)objectValue);
			break;
		}
	}

	internal void method_8(ushort ushort_0)
	{
		int_0 = ushort_0;
	}

	internal void method_9(Cell cell_0)
	{
		method_54(cell_0);
		if (cell_0.IsFormula)
		{
			if (cell_0.method_46())
			{
				Formula = cell_0.Formula;
			}
			if (cell_0.short_0 != short_0)
			{
				Class1655 @class = (Class1655)object_0;
				@class.string_0 = null;
				Class1674.smethod_8(cells_0.method_19(), 0, 0, 0, short_0, short_0 - cell_0.short_0, cell_0.short_0, @class.byte_0, -1, -1);
			}
		}
	}

	internal void method_10(Cell cell_0)
	{
		method_54(cell_0);
		if (cell_0.IsFormula)
		{
			if (cell_0.method_46())
			{
				Formula = cell_0.Formula;
			}
			if (cell_0.int_0 != int_0)
			{
				Class1655 @class = (Class1655)object_0;
				@class.string_0 = null;
				Class1674.smethod_8(cells_0.method_19(), int_0, int_0 - cell_0.int_0, cell_0.int_0, 0, 0, 0, @class.byte_0, -1, -1);
			}
		}
	}

	internal void InsertColumns(int int_2, int int_3, Worksheet worksheet_0, bool bool_0)
	{
		int int_4 = short_0;
		if (bool_0 && short_0 >= int_2)
		{
			short_0 = (short)(short_0 + int_3);
		}
		int int_5 = short_0;
		if (IsFormula)
		{
			Class1655 @class = (Class1655)object_0;
			@class.string_0 = null;
			if (@class.method_0() != null)
			{
				@class.method_0().InsertColumns(worksheet_0, bool_0, int_4, int_5, int_3, int_2);
			}
			Class1674.InsertColumns(worksheet_0, bool_0, int_2, int_3, int_4, int_5, -1, -1, @class.byte_0);
		}
	}

	internal void InsertRows(int int_2, int int_3, Worksheet worksheet_0, bool bool_0)
	{
		int int_4 = int_0;
		if (bool_0 && int_0 >= int_2)
		{
			int_0 += int_3;
		}
		int int_5 = int_0;
		if (IsFormula)
		{
			Class1655 @class = (Class1655)object_0;
			@class.string_0 = null;
			if (@class.method_0() != null)
			{
				@class.method_0().InsertRows(worksheet_0, bool_0, int_4, int_5, int_3, int_2);
			}
			Class1674.InsertRows(worksheet_0, bool_0, int_2, int_3, int_4, int_5, -1, -1, @class.byte_0);
		}
	}

	internal void method_11(CellArea cellArea_0, int int_2, Worksheet worksheet_0, bool bool_0)
	{
		int int_3 = int_0;
		int int_4 = short_0;
		if (short_0 >= cellArea_0.StartColumn && short_0 <= cellArea_0.EndColumn && int_0 >= cellArea_0.StartRow)
		{
			int_0 += int_2;
		}
		method_15(ShiftType.Down, cellArea_0, int_2, worksheet_0, bool_0, int_3, int_4);
	}

	internal int method_12(CellArea cellArea_0, int int_2, Worksheet worksheet_0, bool bool_0)
	{
		int result = 0;
		int int_3 = int_0;
		int int_4 = short_0;
		if (short_0 >= cellArea_0.StartColumn && short_0 <= cellArea_0.EndColumn && int_0 >= cellArea_0.StartRow)
		{
			if (int_0 > cellArea_0.EndRow)
			{
				int_0 -= int_2;
				result = 1;
			}
			else if (int_0 >= cellArea_0.StartRow)
			{
				return 2;
			}
		}
		method_15(ShiftType.Up, cellArea_0, int_2, worksheet_0, bool_0, int_3, int_4);
		return result;
	}

	internal void method_13(CellArea cellArea_0, int int_2, Worksheet worksheet_0, bool bool_0)
	{
		if (int_0 >= cellArea_0.StartRow && int_0 <= cellArea_0.EndRow && short_0 >= cellArea_0.StartColumn)
		{
			short_0 = (short)(short_0 + int_2);
		}
		method_15(ShiftType.Right, cellArea_0, int_2, worksheet_0, bool_0, int_0, short_0);
	}

	internal bool method_14(CellArea cellArea_0, int int_2, Worksheet worksheet_0, bool bool_0)
	{
		if (int_0 >= cellArea_0.StartRow && int_0 <= cellArea_0.EndRow)
		{
			if (short_0 > cellArea_0.EndColumn)
			{
				short_0 = (short)(short_0 - int_2);
			}
			else if (short_0 >= cellArea_0.StartColumn)
			{
				return true;
			}
		}
		method_15(ShiftType.Left, cellArea_0, int_2, worksheet_0, bool_0, int_0, short_0);
		return false;
	}

	internal void method_15(ShiftType shiftType_0, CellArea cellArea_0, int int_2, Worksheet worksheet_0, bool bool_0, int int_3, int int_4)
	{
		switch (shiftType_0)
		{
		case ShiftType.Down:
			if (IsFormula)
			{
				Class1655 class3 = (Class1655)object_0;
				Class1674.smethod_20(cellArea_0, int_2, worksheet_0, bool_0, class3.byte_0, -1, -1);
				class3.string_0 = null;
				if (class3.method_0() != null)
				{
					class3.method_0().method_5(worksheet_0, bool_0, cellArea_0, int_2, ShiftType.Down, int_3, int_4, int_0, short_0);
				}
			}
			break;
		case ShiftType.Left:
			if (IsFormula)
			{
				Class1655 class2 = (Class1655)object_0;
				Class1674.smethod_23(cellArea_0, int_2, worksheet_0, bool_0, class2.byte_0, -1, -1);
				class2.string_0 = null;
			}
			break;
		case ShiftType.Right:
			if (IsFormula)
			{
				Class1655 class4 = (Class1655)object_0;
				Class1674.smethod_22(cellArea_0, int_2, worksheet_0, bool_0, class4.byte_0, -1, -1, 0, 0, 0, 0);
				class4.string_0 = null;
				if (class4.method_0() != null)
				{
					Class1674.smethod_22(cellArea_0, int_2, worksheet_0, bool_0, class4.method_0().Formula, -1, -1, 0, 0, 0, 0);
				}
			}
			break;
		case ShiftType.Up:
			if (IsFormula)
			{
				Class1655 @class = (Class1655)object_0;
				Class1674.smethod_21(cellArea_0, int_2, worksheet_0, bool_0, @class.byte_0, -1, -1);
				@class.string_0 = null;
				if (@class.method_0() != null)
				{
					@class.method_0().method_5(worksheet_0, bool_0, cellArea_0, int_2, ShiftType.Up, int_3, int_4, int_0, short_0);
				}
			}
			break;
		case ShiftType.None:
			break;
		}
	}

	internal bool method_16(Cell cell_0)
	{
		if (cell_0 != null)
		{
			return cell_0.method_16(null);
		}
		if (object_0 != null && object_0 is Class1655)
		{
			Class1655 @class = (Class1655)object_0;
			if (@class.method_0() != null)
			{
				return Class1674.smethod_3(cells_0.method_19(), @class.method_0().Formula, -1);
			}
			if (@class.byte_0 != null)
			{
				return Class1674.smethod_3(cells_0.method_19(), @class.byte_0, -1);
			}
		}
		return false;
	}

	[SpecialName]
	internal Class1655 method_17()
	{
		if (object_0 != null && object_0 is Class1655)
		{
			return (Class1655)object_0;
		}
		return null;
	}

	internal CellValueType method_18()
	{
		if (object_0 == null)
		{
			return CellValueType.IsNull;
		}
		object obj = object_0;
		if (obj is Class1655)
		{
			obj = ((Class1655)object_0).object_0;
			if (obj == null)
			{
				return CellValueType.IsNull;
			}
		}
		switch (System.Type.GetTypeCode(obj.GetType()))
		{
		case TypeCode.DateTime:
			return CellValueType.IsDateTime;
		default:
			if (obj is Class1719)
			{
				return CellValueType.IsString;
			}
			return CellValueType.IsUnknown;
		case TypeCode.String:
			if (Class1673.smethod_7((string)obj))
			{
				return CellValueType.IsError;
			}
			return CellValueType.IsString;
		case TypeCode.Int32:
		case TypeCode.Double:
			return CellValueType.IsNumeric;
		case TypeCode.Boolean:
			return CellValueType.IsBool;
		}
	}

	internal Enum198 method_19(out double cellValue)
	{
		cellValue = 0.0;
		if (object_0 == null)
		{
			return Enum198.const_6;
		}
		switch (System.Type.GetTypeCode(object_0.GetType()))
		{
		case TypeCode.Double:
			cellValue = (double)object_0;
			if (Class1132.smethod_1(cellValue))
			{
				return Enum198.const_2;
			}
			return Enum198.const_3;
		case TypeCode.DateTime:
			cellValue = CellsHelper.GetDoubleFromDateTime((DateTime)object_0, cells_0.method_19().Workbook.Settings.Date1904);
			if (Class1132.smethod_1(cellValue))
			{
				return Enum198.const_2;
			}
			return Enum198.const_3;
		default:
			if (object_0 is Class1719)
			{
				cellValue = ((Class1719)object_0).int_1;
				return Enum198.const_5;
			}
			if (object_0 is Class1655)
			{
				return Enum198.const_4;
			}
			return Enum198.const_6;
		case TypeCode.String:
		{
			string key;
			if ((key = (string)object_0) != null)
			{
				if (Class1742.dictionary_31 == null)
				{
					Class1742.dictionary_31 = new Dictionary<string, int>(7)
					{
						{ "#DIV/0!", 0 },
						{ "#N/A", 1 },
						{ "#NAME?", 2 },
						{ "#NULL!", 3 },
						{ "#NUM!", 4 },
						{ "#REF!", 5 },
						{ "#VALUE!", 6 }
					};
				}
				if (Class1742.dictionary_31.TryGetValue(key, out var value))
				{
					switch (value)
					{
					case 0:
						cellValue = 7.0;
						return Enum198.const_1;
					case 1:
						cellValue = 42.0;
						return Enum198.const_1;
					case 2:
						cellValue = 29.0;
						return Enum198.const_1;
					case 3:
						cellValue = 0.0;
						return Enum198.const_1;
					case 4:
						cellValue = 36.0;
						return Enum198.const_1;
					case 5:
						cellValue = 23.0;
						return Enum198.const_1;
					case 6:
						cellValue = 15.0;
						return Enum198.const_1;
					}
				}
			}
			cellValue = -1.0;
			return Enum198.const_5;
		}
		case TypeCode.Int32:
		{
			int num = (int)object_0;
			cellValue = num;
			if (Class1132.smethod_0(num))
			{
				return Enum198.const_2;
			}
			return Enum198.const_3;
		}
		case TypeCode.Boolean:
			cellValue = (((bool)object_0) ? 1 : 0);
			return Enum198.const_0;
		}
	}

	[SpecialName]
	internal Enum199 method_20()
	{
		if (object_0 == null)
		{
			return Enum199.const_7;
		}
		switch (System.Type.GetTypeCode(object_0.GetType()))
		{
		case TypeCode.Double:
			if (method_32().IsDateTime)
			{
				return Enum199.const_8;
			}
			return Enum199.const_3;
		case TypeCode.DateTime:
			return Enum199.const_8;
		default:
			if (object_0 is Class1719)
			{
				return Enum199.const_6;
			}
			if (object_0 is Class1655)
			{
				return Enum199.const_4;
			}
			return Enum199.const_7;
		case TypeCode.String:
			if (Class1673.smethod_7((string)object_0))
			{
				return Enum199.const_1;
			}
			return Enum199.const_6;
		case TypeCode.Int32:
			if (method_32().IsDateTime)
			{
				return Enum199.const_8;
			}
			return Enum199.const_2;
		case TypeCode.Boolean:
			return Enum199.const_0;
		}
	}

	[SpecialName]
	internal int method_21()
	{
		if (object_0 is Class1719)
		{
			return ((Class1719)object_0).int_1;
		}
		return -1;
	}

	internal Interface3 method_22()
	{
		Style style = method_32();
		if (style.Custom != null && !(style.Custom == ""))
		{
			return Worksheet.Workbook.Settings.method_3().method_11(style.Custom, bool_1: true);
		}
		return Worksheet.Workbook.Settings.method_3().method_10(style.Number);
	}

	internal Class518 Format(Class515 class515_0)
	{
		object obj = method_26();
		if (obj == null)
		{
			return new Class518();
		}
		Interface3 @interface = method_22();
		return @interface.Format(class515_0, obj);
	}

	private double method_23(double double_0)
	{
		Style style = method_32();
		if (style.Custom != null && !(style.Custom == ""))
		{
			return method_24(Worksheet.Workbook.Settings.method_3().method_11(style.Custom, bool_1: true), double_0);
		}
		if (style.Number == 0)
		{
			return double_0;
		}
		return method_24(Worksheet.Workbook.Settings.method_3().method_10(style.Number), double_0);
	}

	private double method_24(Interface3 interface3_0, double double_0)
	{
		switch (interface3_0.imethod_0())
		{
		default:
			return double_0;
		case Enum136.const_2:
		case Enum136.const_4:
		case Enum136.const_5:
			return ((Class488)interface3_0).method_2(double_0);
		case Enum136.const_6:
			return ((Class506)interface3_0).method_2(double_0);
		}
	}

	internal string method_25(int int_2, bool bool_0)
	{
		object obj = method_26();
		if (obj == null)
		{
			return "";
		}
		Class516 @class = Worksheet.Workbook.Settings.method_3();
		Class518 class2 = method_22().Format(@class.method_9(), obj);
		if (class2.method_4())
		{
			if (int_2 <= 1)
			{
				return "#";
			}
		}
		else if (int_2 < 0)
		{
			return class2.StringValue;
		}
		return class2.method_6(int_2, bool_0);
	}

	[SpecialName]
	internal object method_26()
	{
		object obj = object_0;
		if (obj is Class1655)
		{
			obj = ((Class1655)obj).object_0;
		}
		if (obj is Class1719)
		{
			return ((Class1719)obj).string_0;
		}
		return obj;
	}

	internal void method_27()
	{
		if (method_20() != Enum199.const_7)
		{
			PutValue(StringValue);
		}
	}

	/// <summary>
	///       Gets the display style of the cell.
	///       If the cell is conditional formated, the display style is not same as the cell.GetStyle().
	///       </summary>
	public Style GetDisplayStyle()
	{
		Style style = method_28();
		if (Worksheet.ListObjects != null && Worksheet.ListObjects.Count > 0)
		{
			Workbook workbook = Worksheet.Workbook;
			try
			{
				Style cellStyle = Worksheet.ListObjects.GetCellStyle(int_0, short_0);
				if (cellStyle != null)
				{
					Style style2 = new Style(workbook.Worksheets);
					style2.Copy(style);
					style = style2;
					Class1627.smethod_4(style, cellStyle, workbook.Worksheets.DefaultStyle);
				}
			}
			catch
			{
			}
		}
		Class314 @class = Class1627.smethod_0(cells_0.method_3(), this, style, bool_0: false);
		return @class.style_1;
	}

	/// <summary>
	///       Gets the conditional formated style when the cell value fits the condition.
	///       </summary>
	/// <returns>Returns <see cref="T:Aspose.Cells.Style" /> object.</returns>
	public Style GetConditionalStyle()
	{
		Style style_ = method_28();
		Class314 @class = Class1627.smethod_0(cells_0.method_3(), this, style_, bool_0: false);
		return @class.style_0;
	}

	/// <summary>
	///       Gets format conditions which applies to this cell.
	///       </summary>
	/// <returns>Returns <see cref="T:Aspose.Cells.FormatConditionCollection" /> object</returns>
	public FormatConditionCollection GetFormatConditions()
	{
		return Class1627.GetFormatConditions(cells_0.method_3(), this);
	}

	/// <summary>
	///       Gets the conditional format which is applied for this cell.
	///       </summary>
	/// <returns>
	///   <see cref="T:Aspose.Cells.FormatConditionCollection" /> object.Null if there is no conditional format for this cell.</returns>
	public FormatConditionCollection GetFormatCondtions()
	{
		ConditionalFormattingCollection conditionalFormattingCollection_ = cells_0.method_3().conditionalFormattingCollection_0;
		if (conditionalFormattingCollection_ == null)
		{
			return null;
		}
		for (int i = 0; i < conditionalFormattingCollection_.Count; i++)
		{
			FormatConditionCollection formatConditionCollection = conditionalFormattingCollection_[i];
			ArrayList arrayList_ = formatConditionCollection.arrayList_1;
			for (int j = 0; j < arrayList_.Count; j++)
			{
				CellArea cellArea = (CellArea)arrayList_[j];
				if (cellArea.StartRow <= int_0 && cellArea.EndRow >= int_0 && cellArea.StartColumn <= short_0 && cellArea.EndColumn >= short_0)
				{
					return formatConditionCollection;
				}
			}
		}
		return null;
	}

	internal Style method_28()
	{
		Style style = new Style(cells_0.method_19());
		style.GetStyle(cells_0.method_19(), method_35());
		return style;
	}

	internal Style GetStyle(int int_2, int int_3, int int_4, int int_5)
	{
		Style style = new Style(cells_0.method_19());
		style.GetStyle(cells_0.method_19(), method_35());
		return method_29(style, int_2, int_3, int_4, int_5, bool_0: false);
	}

	private Style method_29(Style style_0, int int_2, int int_3, int int_4, int int_5, bool bool_0)
	{
		if (int_0 != int_2 && int_0 != 0 && (style_0.method_4() == null || style_0.Borders[BorderType.TopBorder].LineStyle == CellBorderType.None))
		{
			Row row = cells_0.Rows.GetRow(int_0 - 1, bool_0: true, bool_1: false);
			if (row != null && !row.IsHidden)
			{
				Cell cellOrNull = row.GetCellOrNull(short_0);
				if (cellOrNull != null)
				{
					Style style = cellOrNull.method_32();
					if (style.method_4() != null && style.Borders[BorderType.BottomBorder].LineStyle != 0)
					{
						if (bool_0)
						{
							style_0 = new Style(style_0.method_5());
							bool_0 = false;
						}
						style_0.Borders[BorderType.TopBorder].LineStyle = style.Borders[BorderType.BottomBorder].LineStyle;
						style_0.Borders[BorderType.TopBorder].InternalColor.method_19(style.Borders[BorderType.BottomBorder].InternalColor);
					}
				}
			}
		}
		if (int_0 != int_4 && int_0 != 1048575 && (style_0.method_4() == null || style_0.Borders[BorderType.BottomBorder].LineStyle == CellBorderType.None))
		{
			Row row2 = cells_0.Rows.GetRow(int_0 + 1, bool_0: true, bool_1: false);
			if (row2 != null && !row2.IsHidden)
			{
				Cell cellOrNull2 = row2.GetCellOrNull(short_0);
				if (cellOrNull2 != null)
				{
					Style style2 = cellOrNull2.method_32();
					if (style2.method_4() != null && style2.Borders[BorderType.TopBorder].LineStyle != 0)
					{
						if (bool_0)
						{
							style_0 = new Style(style_0.method_5());
							bool_0 = false;
						}
						style_0.Borders[BorderType.BottomBorder].LineStyle = style2.Borders[BorderType.TopBorder].LineStyle;
						style_0.Borders[BorderType.BottomBorder].InternalColor.method_19(style2.Borders[BorderType.TopBorder].InternalColor);
					}
				}
			}
		}
		Row row3 = null;
		int num = -1;
		if (short_0 != int_3 && short_0 != 0 && (style_0.method_4() == null || style_0.Borders[BorderType.LeftBorder].LineStyle == CellBorderType.None))
		{
			row3 = cells_0.Rows.GetRow(int_0, bool_0: true, bool_1: false);
			if (row3 != null)
			{
				num = row3.method_7(short_0, 0, row3.method_0() - 1);
				if (num > 0)
				{
					Cell cellByIndex = row3.GetCellByIndex(num - 1);
					if (cellByIndex.short_0 == short_0 - 1)
					{
						Style style3 = cellByIndex.method_32();
						if (style3.method_4() != null && style3.Borders[BorderType.RightBorder].LineStyle != 0)
						{
							if (bool_0)
							{
								style_0 = new Style(style_0.method_5());
								bool_0 = false;
							}
							style_0.Borders[BorderType.LeftBorder].LineStyle = style3.Borders[BorderType.RightBorder].LineStyle;
							style_0.Borders[BorderType.LeftBorder].InternalColor.method_19(style3.Borders[BorderType.RightBorder].InternalColor);
						}
					}
				}
			}
			else
			{
				num = 0;
			}
		}
		if (short_0 != int_5 && short_0 != 16383 && (style_0.method_4() == null || style_0.Borders[BorderType.RightBorder].LineStyle == CellBorderType.None))
		{
			Cell cell = null;
			if (row3 == null)
			{
				if (num < 0)
				{
					row3 = cells_0.Rows.GetRow(int_0, bool_0: true, bool_1: false);
					if (row3 != null)
					{
						num = row3.method_7(short_0 + 1, 0, row3.method_0() - 1);
						if (num >= 0)
						{
							cell = row3.GetCellByIndex(num);
						}
					}
				}
			}
			else if (num < 0)
			{
				num = row3.method_7(short_0 + 1, 0, row3.method_0() - 1);
				if (num >= 0)
				{
					cell = row3.GetCellByIndex(num);
				}
			}
			else
			{
				num++;
				if (num < row3.method_0())
				{
					cell = row3.GetCellByIndex(num);
					if (cell.short_0 != short_0 + 1)
					{
						cell = null;
					}
				}
			}
			if (cell != null)
			{
				Style style4 = cell.method_32();
				if (style4.method_4() != null && style4.Borders[BorderType.LeftBorder].LineStyle != 0)
				{
					if (bool_0)
					{
						style_0 = new Style(style_0.method_5());
						bool_0 = false;
					}
					style_0.Borders[BorderType.RightBorder].LineStyle = style4.Borders[BorderType.LeftBorder].LineStyle;
					style_0.Borders[BorderType.RightBorder].InternalColor.method_19(style4.Borders[BorderType.LeftBorder].InternalColor);
				}
			}
		}
		return style_0;
	}

	/// <summary>
	///        Gets the cell style.
	///        </summary>
	/// <returns>Style object.</returns>
	/// <remarks>To change the style of the cell, please call Cell.SetStyle() method after changing the style.
	///       </remarks>
	public virtual Style GetStyle()
	{
		Style style = new Style(cells_0.method_19());
		style.GetStyle(cells_0.method_19(), method_35());
		return method_31(style, bool_0: false);
	}

	public Style GetStyle(bool checkBorders)
	{
		Style style = new Style(cells_0.method_19());
		style.GetStyle(cells_0.method_19(), method_35());
		if (checkBorders)
		{
			style = method_31(style, bool_0: false);
		}
		return style;
	}

	/// <summary>
	///       Sets the cell style.
	///       </summary>
	/// <param name="style">The cell style.</param>
	/// <remarks>
	///       If the border settings are changed, the border of adjact cells will be updated too.
	///       </remarks>
	public virtual void SetStyle(Style style)
	{
		if (style == null)
		{
			int_1 = -1;
			return;
		}
		Style style2 = method_28();
		WorksheetCollection worksheetCollection = cells_0.method_19();
		if (style.method_5() == null)
		{
			style.method_6(worksheetCollection);
		}
		int_1 = worksheetCollection.method_58().method_3(style);
		if (!worksheetCollection.Workbook.Settings.UpdateAdjacentCellsBorder || !style.IsModified(StyleModifyFlag.Borders))
		{
			return;
		}
		Cell cell = null;
		Style style3 = null;
		Border border = null;
		if (short_0 > 0 && style.IsModified(StyleModifyFlag.LeftBorder) && !style.Borders[BorderType.LeftBorder].method_4(style2.Borders[BorderType.LeftBorder]))
		{
			cell = cells_0.CheckCell(int_0, short_0 - 1);
			if (cell != null && cell.method_34())
			{
				style3 = cell.method_28();
				border = style.Borders[BorderType.LeftBorder];
				style3.Borders[BorderType.RightBorder].LineStyle = border.LineStyle;
				if (border.LineStyle != 0)
				{
					style3.Borders[BorderType.RightBorder].InternalColor.method_19(border.InternalColor);
				}
				cell.method_30(style3);
			}
		}
		if (int_0 > 0 && style.IsModified(StyleModifyFlag.TopBorder) && !style.Borders[BorderType.TopBorder].method_4(style2.Borders[BorderType.TopBorder]))
		{
			cell = cells_0.CheckCell(int_0 - 1, short_0);
			if (cell != null && cell.method_34())
			{
				style3 = cell.method_28();
				border = style.Borders[BorderType.TopBorder];
				style3.Borders[BorderType.BottomBorder].LineStyle = border.LineStyle;
				if (border.LineStyle != 0)
				{
					style3.Borders[BorderType.BottomBorder].InternalColor.method_19(border.InternalColor);
				}
				cell.method_30(style3);
			}
		}
		if (short_0 < 16383 && style.IsModified(StyleModifyFlag.RightBorder) && !style.Borders[BorderType.RightBorder].method_4(style2.Borders[BorderType.RightBorder]))
		{
			cell = cells_0.CheckCell(int_0, short_0 + 1);
			if (cell != null && cell.method_34())
			{
				style3 = cell.method_28();
				border = style.Borders[BorderType.RightBorder];
				style3.Borders[BorderType.LeftBorder].LineStyle = border.LineStyle;
				if (border.LineStyle != 0)
				{
					style3.Borders[BorderType.LeftBorder].InternalColor.method_19(border.InternalColor);
				}
				cell.method_30(style3);
			}
		}
		if (int_0 >= 1048575 || !style.IsModified(StyleModifyFlag.BottomBorder) || style.Borders[BorderType.BottomBorder].method_4(style2.Borders[BorderType.BottomBorder]))
		{
			return;
		}
		cell = cells_0.CheckCell(int_0 + 1, short_0);
		if (cell != null && cell.method_34())
		{
			style3 = cell.method_28();
			border = style.Borders[BorderType.BottomBorder];
			style3.Borders[BorderType.TopBorder].LineStyle = border.LineStyle;
			if (border.LineStyle != 0)
			{
				style3.Borders[BorderType.TopBorder].InternalColor.method_19(border.InternalColor);
			}
			cell.method_30(style3);
		}
	}

	internal void method_30(Style style_0)
	{
		if (style_0 == null)
		{
			int_1 = -1;
			return;
		}
		if (style_0.method_5() == null)
		{
			style_0.method_6(cells_0.method_19());
		}
		int_1 = cells_0.method_19().method_58().method_3(style_0);
	}

	/// <summary>
	///       Apply the cell style.
	///       </summary>
	/// <param name="style">The cell style.</param>
	/// <param name="explicitFlag">True, only overwriting formatting which is explicitly set.
	///       </param>
	public virtual void SetStyle(Style style, bool explicitFlag)
	{
		if (!explicitFlag)
		{
			SetStyle(style);
		}
		else
		{
			if (style == null)
			{
				return;
			}
			WorksheetCollection worksheetCollection = cells_0.method_19();
			if (style.method_5() == null)
			{
				style.method_6(worksheetCollection);
			}
			Style style2 = new Style(worksheetCollection);
			style2.GetStyle(worksheetCollection, method_35());
			if (style.method_21())
			{
				if (style.IsModified(StyleModifyFlag.HorizontalAlignment))
				{
					style2.HorizontalAlignment = style.HorizontalAlignment;
				}
				if (style.IsModified(StyleModifyFlag.VerticalAlignment))
				{
					style2.VerticalAlignment = style.VerticalAlignment;
				}
				if (style.IsModified(StyleModifyFlag.Indent))
				{
					style2.IndentLevel = style.IndentLevel;
				}
				if (style.IsModified(StyleModifyFlag.WrapText))
				{
					style2.IsTextWrapped = style.IsTextWrapped;
				}
				if (style.IsModified(StyleModifyFlag.ShrinkToFit))
				{
					style2.ShrinkToFit = style.ShrinkToFit;
				}
				if (style.IsModified(StyleModifyFlag.Rotation))
				{
					style2.RotationAngle = style.RotationAngle;
				}
				if (style.IsModified(StyleModifyFlag.TextDirection))
				{
					style2.TextDirection = style.TextDirection;
				}
			}
			if (style.method_19())
			{
				if (style.IsModified(StyleModifyFlag.FontName))
				{
					style2.Font.Name = style.Font.Name;
				}
				if (style.IsModified(StyleModifyFlag.FontColor))
				{
					style2.method_36(StyleModifyFlag.FontColor);
					style2.Font.InternalColor.method_19(style.Font.InternalColor);
				}
				if (style.IsModified(StyleModifyFlag.FontCharset))
				{
					style2.Font.method_3(style.Font.method_2());
				}
				if (style.IsModified(StyleModifyFlag.FontFamily))
				{
					style2.Font.method_12(style.Font.method_11());
				}
				if (style.IsModified(StyleModifyFlag.FontItalic))
				{
					style2.Font.IsItalic = style.Font.IsItalic;
				}
				if (style.IsModified(StyleModifyFlag.FontScript))
				{
					style2.Font.IsSubscript = style.Font.IsSubscript;
					style2.Font.IsSuperscript = style.Font.IsSuperscript;
				}
				if (style.IsModified(StyleModifyFlag.FontSize))
				{
					style2.Font.DoubleSize = style.Font.DoubleSize;
				}
				if (style.IsModified(StyleModifyFlag.FontStrike))
				{
					style2.Font.IsStrikeout = style.Font.IsStrikeout;
				}
				if (style.IsModified(StyleModifyFlag.FontUnderline))
				{
					style2.Font.Underline = style.Font.Underline;
				}
				if (style.IsModified(StyleModifyFlag.FontWeight))
				{
					style2.Font.Weight = style.Font.Weight;
				}
			}
			if (style.method_23())
			{
				bool updateAdjacentCellsBorder = worksheetCollection.Workbook.Settings.UpdateAdjacentCellsBorder;
				if (style.IsModified(StyleModifyFlag.TopBorder) && !style.Borders[BorderType.TopBorder].method_4(style2.Borders[BorderType.TopBorder]))
				{
					style2.Borders[BorderType.TopBorder].LineStyle = style.Borders[BorderType.TopBorder].LineStyle;
					style2.Borders[BorderType.TopBorder].InternalColor.method_19(style.Borders[BorderType.TopBorder].InternalColor);
					if (int_0 > 0 && updateAdjacentCellsBorder)
					{
						Cell cell = cells_0.CheckCell(int_0 - 1, short_0);
						if (cell != null && cell.method_34())
						{
							Style style3 = cell.method_28();
							Border border = style.Borders[BorderType.TopBorder];
							style3.Borders[BorderType.BottomBorder].LineStyle = border.LineStyle;
							if (border.LineStyle != 0)
							{
								style3.Borders[BorderType.BottomBorder].InternalColor.method_19(border.InternalColor);
							}
							cell.method_30(style3);
						}
					}
				}
				if (style.IsModified(StyleModifyFlag.BottomBorder) && !style.Borders[BorderType.BottomBorder].method_4(style2.Borders[BorderType.BottomBorder]))
				{
					style2.Borders[BorderType.BottomBorder].LineStyle = style.Borders[BorderType.BottomBorder].LineStyle;
					style2.Borders[BorderType.BottomBorder].InternalColor.method_19(style.Borders[BorderType.BottomBorder].InternalColor);
					if (int_0 < 1048575 && updateAdjacentCellsBorder)
					{
						Cell cell2 = cells_0.CheckCell(int_0 + 1, short_0);
						if (cell2 != null && cell2.method_34())
						{
							Style style4 = cell2.method_28();
							Border border2 = style.Borders[BorderType.BottomBorder];
							style4.Borders[BorderType.TopBorder].LineStyle = border2.LineStyle;
							if (border2.LineStyle != 0)
							{
								style4.Borders[BorderType.TopBorder].InternalColor.method_19(border2.InternalColor);
							}
							cell2.method_30(style4);
						}
					}
				}
				if (style.IsModified(StyleModifyFlag.LeftBorder) && !style.Borders[BorderType.LeftBorder].method_4(style2.Borders[BorderType.LeftBorder]))
				{
					style2.Borders[BorderType.LeftBorder].LineStyle = style.Borders[BorderType.LeftBorder].LineStyle;
					style2.Borders[BorderType.LeftBorder].InternalColor.method_19(style.Borders[BorderType.LeftBorder].InternalColor);
					if (short_0 > 0 && updateAdjacentCellsBorder)
					{
						Cell cell3 = cells_0.CheckCell(int_0, short_0 - 1);
						if (cell3 != null && cell3.method_34())
						{
							Style style5 = cell3.method_28();
							Border border3 = style.Borders[BorderType.LeftBorder];
							style5.Borders[BorderType.RightBorder].LineStyle = border3.LineStyle;
							if (border3.LineStyle != 0)
							{
								style5.Borders[BorderType.RightBorder].InternalColor.method_19(border3.InternalColor);
							}
							cell3.method_30(style5);
						}
					}
				}
				if (style.IsModified(StyleModifyFlag.RightBorder) && !style.Borders[BorderType.RightBorder].method_4(style2.Borders[BorderType.RightBorder]))
				{
					style2.Borders[BorderType.RightBorder].LineStyle = style.Borders[BorderType.RightBorder].LineStyle;
					style2.Borders[BorderType.RightBorder].InternalColor.method_19(style.Borders[BorderType.RightBorder].InternalColor);
					if (short_0 < 16383 && updateAdjacentCellsBorder)
					{
						Cell cell4 = cells_0.CheckCell(int_0, short_0 + 1);
						if (cell4 != null && cell4.method_34())
						{
							Style style6 = cell4.method_28();
							Border border4 = style.Borders[BorderType.RightBorder];
							style6.Borders[BorderType.LeftBorder].LineStyle = border4.LineStyle;
							if (border4.LineStyle != 0)
							{
								style6.Borders[BorderType.LeftBorder].InternalColor.method_19(border4.InternalColor);
							}
							cell4.method_30(style6);
						}
					}
				}
				if (style.IsModified(StyleModifyFlag.DiagonalUpBorder))
				{
					style2.Borders[BorderType.DiagonalUp].LineStyle = style.Borders[BorderType.DiagonalUp].LineStyle;
					style2.Borders[BorderType.DiagonalUp].InternalColor.method_19(style.Borders[BorderType.DiagonalUp].InternalColor);
				}
				if (style.IsModified(StyleModifyFlag.DiagonalDownBorder))
				{
					style2.Borders[BorderType.DiagonalDown].LineStyle = style.Borders[BorderType.DiagonalDown].LineStyle;
					style2.Borders[BorderType.DiagonalDown].InternalColor.method_19(style.Borders[BorderType.DiagonalDown].InternalColor);
				}
			}
			if (style.method_17() && style.IsModified(StyleModifyFlag.NumberFormat))
			{
				style2.method_42(style.method_44(), style.method_46());
				style2.method_55(style2.IsDateTime);
			}
			if (style.method_25())
			{
				style2.method_26(bool_0: true);
				if (style.IsModified(StyleModifyFlag.Pattern))
				{
					style2.Pattern = style.Pattern;
				}
				if (style.IsModified(StyleModifyFlag.ForegroundColor))
				{
					style2.ForeInternalColor.method_19(style.ForeInternalColor);
					style2.method_36(StyleModifyFlag.ForegroundColor);
				}
				if (style.IsModified(StyleModifyFlag.BackgroundColor))
				{
					style2.BackgroundInternalColor.method_19(style.BackgroundInternalColor);
					style2.method_36(StyleModifyFlag.BackgroundColor);
				}
			}
			if (style.method_27())
			{
				if (style.IsModified(StyleModifyFlag.Locked))
				{
					style2.IsLocked = style.IsLocked;
				}
				if (style.IsModified(StyleModifyFlag.HideFormula))
				{
					style2.IsFormulaHidden = style.IsFormulaHidden;
				}
			}
			int_1 = cells_0.method_19().method_58().method_3(style2);
		}
	}

	/// <summary>
	///       Apply the cell style.
	///       </summary>
	/// <param name="style">The cell style.</param>
	/// <param name="flag">The style flag.</param>
	public virtual void SetStyle(Style style, StyleFlag flag)
	{
		if (style == null)
		{
			int_1 = -1;
			return;
		}
		if (style.method_5() == null)
		{
			style.method_6(cells_0.method_19());
		}
		Style style2 = GetStyle();
		Class1677.ApplyStyle(style, style2, flag);
		int_1 = cells_0.method_19().method_58().method_3(style2);
	}

	private Style method_31(Style style_0, bool bool_0)
	{
		if (int_0 != 0 && (style_0.method_4() == null || style_0.Borders[BorderType.TopBorder].LineStyle == CellBorderType.None))
		{
			Row row = cells_0.Rows.GetRow(int_0 - 1, bool_0: true, bool_1: false);
			if (row != null && !row.IsHidden)
			{
				Cell cellOrNull = row.GetCellOrNull(short_0);
				if (cellOrNull != null)
				{
					Style style = cellOrNull.method_32();
					if (style.method_4() != null && style.Borders[BorderType.BottomBorder].LineStyle != 0)
					{
						if (bool_0)
						{
							style_0 = new Style(style_0.method_5());
							bool_0 = false;
						}
						style_0.Borders[BorderType.TopBorder].LineStyle = style.Borders[BorderType.BottomBorder].LineStyle;
						style_0.Borders[BorderType.TopBorder].InternalColor.method_19(style.Borders[BorderType.BottomBorder].InternalColor);
					}
				}
			}
		}
		if (int_0 != 1048575 && (style_0.method_4() == null || style_0.Borders[BorderType.BottomBorder].LineStyle == CellBorderType.None))
		{
			Row row2 = cells_0.Rows.GetRow(int_0 + 1, bool_0: true, bool_1: false);
			if (row2 != null && !row2.IsHidden)
			{
				Cell cellOrNull2 = row2.GetCellOrNull(short_0);
				if (cellOrNull2 != null)
				{
					Style style2 = cellOrNull2.method_32();
					if (style2.method_4() != null && style2.Borders[BorderType.TopBorder].LineStyle != 0)
					{
						if (bool_0)
						{
							style_0 = new Style(style_0.method_5());
							bool_0 = false;
						}
						style_0.Borders[BorderType.BottomBorder].LineStyle = style2.Borders[BorderType.TopBorder].LineStyle;
						style_0.Borders[BorderType.BottomBorder].InternalColor.method_19(style2.Borders[BorderType.TopBorder].InternalColor);
					}
				}
			}
		}
		Row row3 = null;
		int num = -1;
		if (short_0 != 0 && (style_0.method_4() == null || style_0.Borders[BorderType.LeftBorder].LineStyle == CellBorderType.None))
		{
			row3 = cells_0.Rows.GetRow(int_0, bool_0: true, bool_1: false);
			if (row3 != null)
			{
				num = row3.method_7(short_0, 0, row3.method_0() - 1);
				if (num > 0)
				{
					Cell cellByIndex = row3.GetCellByIndex(num - 1);
					if (cellByIndex.short_0 == short_0 - 1)
					{
						Style style3 = cellByIndex.method_32();
						if (style3.method_4() != null && style3.Borders[BorderType.RightBorder].LineStyle != 0)
						{
							if (bool_0)
							{
								style_0 = new Style(style_0.method_5());
								bool_0 = false;
							}
							style_0.Borders[BorderType.LeftBorder].LineStyle = style3.Borders[BorderType.RightBorder].LineStyle;
							style_0.Borders[BorderType.LeftBorder].InternalColor.method_19(style3.Borders[BorderType.RightBorder].InternalColor);
						}
					}
				}
			}
			else
			{
				num = 0;
			}
		}
		if (short_0 != 16383 && (style_0.method_4() == null || style_0.Borders[BorderType.RightBorder].LineStyle == CellBorderType.None))
		{
			Cell cell = null;
			if (row3 == null)
			{
				if (num < 0)
				{
					row3 = cells_0.Rows.GetRow(int_0, bool_0: true, bool_1: false);
					if (row3 != null)
					{
						num = row3.method_7(short_0 + 1, 0, row3.method_0() - 1);
						if (num >= 0)
						{
							cell = row3.GetCellByIndex(num);
						}
					}
				}
			}
			else if (num < 0)
			{
				num = row3.method_7(short_0 + 1, 0, row3.method_0() - 1);
				if (num >= 0)
				{
					cell = row3.GetCellByIndex(num);
				}
			}
			else
			{
				num++;
				if (num < row3.method_0())
				{
					cell = row3.GetCellByIndex(num);
					if (cell.short_0 != short_0 + 1)
					{
						cell = null;
					}
				}
			}
			if (cell != null)
			{
				Style style4 = cell.method_32();
				if (style4.method_4() != null && style4.Borders[BorderType.LeftBorder].LineStyle != 0)
				{
					if (bool_0)
					{
						style_0 = new Style(style_0.method_5());
						bool_0 = false;
					}
					style_0.Borders[BorderType.RightBorder].LineStyle = style4.Borders[BorderType.LeftBorder].LineStyle;
					style_0.Borders[BorderType.RightBorder].InternalColor.method_19(style4.Borders[BorderType.LeftBorder].InternalColor);
				}
			}
		}
		return style_0;
	}

	internal Style method_32()
	{
		return method_33(cells_0.method_19().DefaultStyle);
	}

	internal Style method_33(Style style_0)
	{
		if (int_1 == 15)
		{
			return style_0;
		}
		int num = method_35();
		if (num != 15 && num >= 0 && num < cells_0.method_19().method_58().Count)
		{
			return cells_0.method_19().method_58()[num];
		}
		return style_0;
	}

	[SpecialName]
	internal bool method_34()
	{
		if (int_1 != -1)
		{
			return int_1 != 15;
		}
		return false;
	}

	[SpecialName]
	internal int method_35()
	{
		if (int_1 != -1)
		{
			return int_1;
		}
		int num = cells_0.method_41(this, int_0, short_0);
		if (num == -1)
		{
			return 15;
		}
		return num;
	}

	[SpecialName]
	internal int method_36()
	{
		return int_1;
	}

	[SpecialName]
	internal void method_37(int int_2)
	{
		if (int_2 < cells_0.method_19().method_58().Count)
		{
			int_1 = int_2;
		}
	}

	/// <summary>
	///       Set the formula and the value of the formula.
	///       </summary>
	/// <param name="formula">The formula.</param>
	/// <param name="value">The value of the formula.</param>
	public void SetFormula(string formula, object value)
	{
		method_6();
		if (formula != null && formula != "")
		{
			cells_0.method_19().Formula.method_4(this, formula.Trim(), 0, bool_0: true);
			if (method_17() != null)
			{
				method_17().object_0 = value;
			}
		}
		if (cells_0.method_19().Workbook.bool_0)
		{
			cells_0.method_19().Workbook.class1380_0.method_2(this);
		}
	}

	[SpecialName]
	internal string method_38()
	{
		if (!IsFormula)
		{
			return null;
		}
		Class1655 @class = (Class1655)object_0;
		if (@class.byte_0 == null)
		{
			return @class.string_0;
		}
		return cells_0.method_19().method_4().method_2(this);
	}

	[SpecialName]
	internal void method_39(string string_0)
	{
		if (cells_0.method_19().Workbook.Settings.ParsingFormulaOnOpen)
		{
			cells_0.method_19().Formula.method_4(this, string_0.Trim(), 0, bool_0: false);
			return;
		}
		Class1655 @class = new Class1655();
		@class.string_0 = "=" + string_0;
		object_0 = @class;
	}

	internal void method_40(string string_0)
	{
		if (string_0 != null && string_0 != "")
		{
			cells_0.method_19().Formula.method_4(this, string_0.Trim(), 0, bool_0: true);
		}
	}

	/// <summary>
	///       Gets all cells or ranges which this cell's formula depends on.
	///       </summary>
	/// <returns>
	///       Returns all cells or ranges.
	///       </returns>
	/// <remarks>Returns null if this is not a formula cell.</remarks>
	/// <example>
	///   <code>
	///
	///       [C#]
	///
	///       Workbook workbook = new Workbook();
	///       Cells cells = workbook.Worksheets[0].Cells;
	///       cells["A1"].Formula = "= B1 + SUM(B1:B10) + [Book1.xls]Sheet1!A1";
	///        ReferredAreas areas = cells["A1"].GetPrecedents();
	///       for (int i = 0; i &lt; areas.Count; i++)
	///       {
	///           ReferredArea area = areas[i];
	///            StringBuilder stringBuilder = new StringBuilder();
	///            if (area.IsExternalLink)
	///            {
	///                stringBuilder.Append("[");
	///                 stringBuilder.Append(area.ExternalFileName);
	///                 stringBuilder.Append("]");
	///             }
	///             stringBuilder.Append(area.SheetName);
	///             stringBuilder.Append("!");
	///             stringBuilder.Append(CellsHelper.CellIndexToName(area.StartRow, area.StartColumn));
	///             if (area.IsArea)
	///              {
	///                  stringBuilder.Append(":");
	///                  stringBuilder.Append(CellsHelper.CellIndexToName(area.EndRow, area.EndColumn));
	///              }
	///              Console.WriteLine(stringBuilder.ToString());
	///           }
	///        workbook.Save(@"C:\Book2.xls");
	///
	///       [Visual Basic]
	///
	///       Dim workbook As Workbook = New Workbook()
	///       Dim cells As Cells = workbook.Worksheets(0).Cells
	///       cells("A1").Formula = "= B1 + SUM(B1:B10) + [Book1.xls]Sheet1!A1"
	///        Dim areas As ReferredAreas = cells("A1").GetPrecedents()
	///       For i As Integer = 0 To areas.Count - 1
	///           Dim area As ReferredArea = areas(i)
	///           Dim stringBuilder As StringBuilder = New StringBuilder()
	///           If (area.IsExternalLink) Then
	///               stringBuilder.Append("[")
	///               stringBuilder.Append(area.ExternalFileName)
	///              stringBuilder.Append("]")
	///           End If
	///           stringBuilder.Append(area.SheetName)
	///           stringBuilder.Append("!")
	///           stringBuilder.Append(CellsHelper.CellIndexToName(area.StartRow, area.StartColumn))
	///           If (area.IsArea) Then
	///               stringBuilder.Append(":")
	///               stringBuilder.Append(CellsHelper.CellIndexToName(area.EndRow, area.EndColumn))
	///            End If
	///           Console.WriteLine(stringBuilder.ToString())
	///        Next
	///        workbook.Save("C:\Book2.xls")
	///       </code>
	/// </example>
	public ReferredAreaCollection GetPrecedents()
	{
		if (!IsFormula)
		{
			return null;
		}
		cells_0.method_19().Workbook.method_5();
		byte[] byte_ = method_41();
		ReferredAreaCollection referredAreaCollection = new ReferredAreaCollection();
		Class1674.GetPrecedents(byte_, -1, -1, int_0, short_0, cells_0.method_19(), cells_0, referredAreaCollection, bool_0: false, null, cells_0.method_3().Name);
		return referredAreaCollection;
	}

	public Cell[] GetDependents(bool isAll)
	{
		return cells_0.GetDependents(isAll, int_0, short_0);
	}

	[SpecialName]
	internal byte[] method_41()
	{
		if (IsFormula)
		{
			return ((Class1655)object_0).byte_0;
		}
		return null;
	}

	[SpecialName]
	internal void method_42(byte[] byte_0)
	{
		if (!IsFormula)
		{
			object_0 = new Class1655();
		}
		Class1655 @class = (Class1655)object_0;
		@class.string_0 = null;
		@class.byte_0 = byte_0;
	}

	internal void method_43(byte[] byte_0)
	{
		if (byte_0 != null)
		{
			if (byte_0[0] == 5 && (byte_0[4] == 1 || byte_0[4] == 2))
			{
				byte[] array = new byte[15]
				{
					7,
					0,
					0,
					0,
					byte_0[4],
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0,
					0
				};
				Array.Copy(byte_0, 5, array, 5, 4);
				Array.Copy(byte_0, 13, array, 9, 2);
				method_42(array);
			}
			else
			{
				method_42(byte_0);
			}
		}
	}

	public int GetWidthOfValue()
	{
		Style style = method_28();
		return Class1679.smethod_5(StringValue, style.method_40());
	}

	internal byte[] method_44()
	{
		byte[] array = method_41();
		if (array == null)
		{
			return null;
		}
		if (cells_0.method_19().Formula.method_13(1, array))
		{
			byte[] array2 = new byte[17]
			{
				5, 0, 0, 0, 1, 0, 0, 0, 0, 0,
				0, 0, 0, 0, 0, 0, 0
			};
			Array.Copy(array, 5, array2, 5, 4);
			array2[9] = 4;
			Array.Copy(array, 9, array2, 13, 2);
			return array2;
		}
		return array;
	}

	/// <summary>
	///       Gets the array range if the cell's formula is an array formula.
	///       </summary>
	/// <returns>
	///       The array range.
	///       </returns>
	/// <remarks>Only applies when the cell's formula is an array formula</remarks>
	public CellArea GetArrayRange()
	{
		if (!IsInArray)
		{
			return default(CellArea);
		}
		Class1655 @class = (Class1655)object_0;
		if (@class.method_0() != null)
		{
			return @class.method_0().CellArea;
		}
		byte[] byte_ = @class.byte_0;
		cells_0.method_19().Formula.method_14(byte_, out var row, out var column);
		Cell cell = cells_0.GetCell(row, column, bool_2: false);
		@class = (Class1655)cell.object_0;
		return @class.method_0().CellArea;
	}

	[SpecialName]
	internal bool method_45()
	{
		if (IsFormula)
		{
			return ((Class1655)object_0).method_9();
		}
		return false;
	}

	[SpecialName]
	internal bool method_46()
	{
		if (IsFormula)
		{
			return ((Class1655)object_0).method_11(cells_0);
		}
		return false;
	}

	internal Cell method_47()
	{
		cells_0.method_19().Formula.method_14(method_41(), out var row, out var column);
		return cells_0.GetCell(row, column, bool_2: false);
	}

	internal void method_48()
	{
		if (!IsFormula)
		{
			return;
		}
		Class1655 @class = (Class1655)object_0;
		byte[] byte_ = @class.byte_0;
		if (!cells_0.method_19().Formula.method_13(1, byte_))
		{
			return;
		}
		int row = 0;
		int column = 0;
		cells_0.method_19().Formula.method_14(byte_, out row, out column);
		Cell cell = cells_0.CheckCell(row, column);
		if (cell != null && cell.IsFormula)
		{
			@class = (Class1655)cell.object_0;
			if (@class.method_0() != null && !@class.method_0().method_1())
			{
				cell.method_72();
			}
		}
	}

	/// <summary>
	///       Sets an array formula to a range of cells.
	///       </summary>
	/// <param name="arrayFormula">Array formula.</param>
	/// <param name="rowNumber">Number of rows to populate result of the array formula.</param>
	/// <param name="columnNumber">Number of columns to populate result of the array formula.</param>
	public void SetArrayFormula(string arrayFormula, int rowNumber, int columnNumber)
	{
		if (rowNumber > 0 && columnNumber > 0)
		{
			Class1677.CheckCell(int_0 + rowNumber - 1, short_0 + columnNumber - 1);
			method_6();
			string text = arrayFormula.Trim();
			cells_0.method_19().Formula.method_6(this, text, rowNumber, columnNumber);
			byte[] byte_ = ((Class1655)object_0).byte_0;
			((Class1655)object_0).method_8(bool_0: true);
			for (int i = int_0; i < int_0 + rowNumber; i++)
			{
				for (int j = short_0; j < short_0 + columnNumber; j++)
				{
					if (i != int_0 || j != short_0)
					{
						Cell cell = cells_0.GetCell(i, j, bool_2: false);
						cell.method_6();
						byte[] array = new byte[byte_.Length];
						Array.Copy(byte_, array, byte_.Length);
						cell.object_0 = new Class1655(text, array, null);
						((Class1655)cell.object_0).method_8(bool_0: true);
						if (cell.cells_0.method_19().Workbook.bool_0)
						{
							cell.cells_0.method_19().Workbook.class1380_0.method_2(cell);
						}
					}
				}
			}
			return;
		}
		throw new ArgumentOutOfRangeException();
	}

	internal void method_49(int int_2, int int_3, bool bool_0, bool bool_1, string string_0, string string_1, bool bool_2, bool bool_3)
	{
		method_6();
		byte[] array = cells_0.method_19().Formula.method_0().method_2(2, int_0, short_0);
		Class1655 @class = (Class1655)(object_0 = new Class1655(null, array, null));
		Class1119 class2 = new Class1119();
		CellArea cellArea_ = default(CellArea);
		cellArea_.StartRow = int_0;
		cellArea_.EndRow = int_0 + int_2 - 1;
		cellArea_.StartColumn = short_0;
		cellArea_.EndColumn = short_0 + int_3 - 1;
		class2.cellArea_0 = cellArea_;
		@class.method_3(class2);
		class2.method_4(bool_2);
		class2.method_6(bool_3);
		if (bool_0)
		{
			class2.method_8(bool_0: true);
			class2.method_13(string_0);
			class2.method_15(string_1);
		}
		else if (class2.method_11())
		{
			class2.method_8(bool_0: false);
			class2.method_10(bool_0: false);
			class2.method_15(string_0);
		}
		else
		{
			class2.method_8(bool_0: false);
			class2.method_10(bool_0: true);
			class2.method_15(string_0);
		}
		for (int i = int_0; i < int_0 + int_2; i++)
		{
			for (int j = short_0; j < short_0 + int_3; j++)
			{
				if (i != int_0 || j != short_0)
				{
					Cell cell = cells_0.GetCell(i, j, bool_2: false);
					cell.method_6();
					byte[] array2 = new byte[array.Length];
					Array.Copy(array, array2, array.Length);
					cell.object_0 = new Class1655(null, array2, null);
					if (cell.cells_0.method_19().Workbook.bool_0)
					{
						cell.cells_0.method_19().Workbook.class1380_0.method_2(cell);
					}
				}
			}
		}
	}

	public void RemoveArrayFormula(bool leaveNormalFormula)
	{
		if (!IsInArray)
		{
			return;
		}
		Class1348 @class = null;
		Class1655 class2 = (Class1655)object_0;
		if (class2.method_0() != null)
		{
			@class = class2.method_0();
		}
		else
		{
			byte[] byte_ = class2.byte_0;
			cells_0.method_19().Formula.method_14(byte_, out var row, out var column);
			Cell cell = cells_0.GetCell(row, column, bool_2: false);
			class2 = (Class1655)cell.object_0;
			@class = class2.method_0();
		}
		if (@class == null)
		{
			return;
		}
		CellArea cellArea = @class.CellArea;
		for (int i = cellArea.StartRow; i <= cellArea.EndRow; i++)
		{
			Row row2 = cells_0.Rows.GetRow(i, bool_0: true, bool_1: true);
			if (row2 == null)
			{
				continue;
			}
			for (int j = cellArea.StartColumn; j <= cellArea.EndColumn; j++)
			{
				Cell cell2 = row2.GetCell(j, bool_1: true, bool_2: true);
				if (cell2 != null && cell2.IsFormula)
				{
					if (!leaveNormalFormula)
					{
						cell2.PutValue(cell2.Value);
						continue;
					}
					class2 = (Class1655)cell2.object_0;
					class2.method_1(null);
					class2.method_8(bool_0: false);
					class2.byte_0 = @class.Formula;
				}
			}
		}
	}

	/// <summary>
	///        Sets an Add-In formula to the cell.
	///        </summary>
	/// <param name="addInFileName">Add-In file name.</param>
	/// <param name="addInFunction">Add-In function name.</param>
	/// <example>
	///   <code>
	///        [C#]
	///        cells["h11"].SetAddInFormula("HRVSTTRK.xla", "=pct_overcut(F3:G3)");
	///        cells["h12"].SetAddInFormula("HRVSTTRK.xla", "=pct_overcut()"); 
	///
	///        [Visual Basic]
	///        cells("h11").SetAddInFormula("HRVSTTRK.xla", "=pct_overcut(F3:G3)")
	///        cells("h12").SetAddInFormula("HRVSTTRK.xla", "=pct_overcut()")
	///        </code>
	/// </example>
	/// <remarks>
	///        Add-In file should be placed in the directory or sub-directory of Workbook Add-In library.
	///        For example, file name can be "Eurotool.xla" or "solver\solver.xla". 
	///        </remarks>
	public void SetAddInFormula(string addInFileName, string addInFunction)
	{
		method_6();
		if (addInFileName != null && addInFileName != "")
		{
			addInFileName = Class1718.smethod_0(addInFileName, Enum188.const_8);
		}
		addInFunction = addInFunction.Trim().ToUpper();
		Class1379 formula = cells_0.method_19().Formula;
		string functionName;
		byte[] array = formula.method_1(addInFunction, out functionName, this);
		int num = -1;
		int num2 = -1;
		int num3 = -1;
		Class1303 @class = cells_0.method_19().method_39();
		bool flag = false;
		bool flag2 = false;
		Class1718 class2 = null;
		for (int i = 0; i < @class.Count; i++)
		{
			class2 = @class[i];
			if (addInFileName != null && !(addInFileName == ""))
			{
				if (class2.method_16() == addInFileName)
				{
					num = i;
					flag = true;
				}
			}
			else if (class2.method_14())
			{
				num = i;
				flag = true;
			}
			if (flag)
			{
				break;
			}
		}
		if (!flag)
		{
			class2 = new Class1718();
			if (addInFileName != null && !(addInFileName == ""))
			{
				class2.Type = Enum194.const_0;
				class2.method_17(addInFileName);
				class2.method_5(new string[1] { "Sheet1" });
			}
			else
			{
				class2.Type = Enum194.const_2;
			}
			Class1653 class3 = new Class1653(class2);
			class3.method_21(functionName, cells_0.method_19().Workbook.method_24());
			class2.method_0().Add(class3);
			num3 = 1;
			cells_0.method_19().method_39().Add(class2);
			num2 = cells_0.method_19().method_32().method_3((ushort)(cells_0.method_19().method_39().Count - 1), 65534, 65534);
		}
		else
		{
			num2 = cells_0.method_19().method_32().method_10(num, 65534, 65534);
			flag = true;
			for (int j = 0; j < class2.method_0().Count; j++)
			{
				Class1653 class4 = (Class1653)class2.method_0()[j];
				if (class4.Name.ToUpper() == functionName.ToUpper())
				{
					num3 = j + 1;
					flag2 = true;
					break;
				}
			}
			if (!flag2)
			{
				Class1653 class5 = new Class1653(class2);
				class5.method_21(functionName, cells_0.method_19().Workbook.method_24());
				class2.method_0().Add(class5);
				num3 = class2.method_0().Count;
			}
		}
		Array.Copy(BitConverter.GetBytes((ushort)num2), 0, array, 1, 2);
		Array.Copy(BitConverter.GetBytes((ushort)num3), 0, array, 3, 2);
		if (cells_0.method_19().Workbook.method_24())
		{
			byte[] array2 = new byte[8 + array.Length];
			Array.Copy(BitConverter.GetBytes(array.Length), 0, array2, 0, 4);
			Array.Copy(array, 0, array2, 4, array.Length);
			object_0 = new Class1655(null, array2, null);
		}
		else
		{
			byte[] array3 = new byte[2 + array.Length];
			Array.Copy(BitConverter.GetBytes((short)array.Length), 0, array3, 0, 2);
			Array.Copy(array, 0, array3, 2, array.Length);
			object_0 = new Class1655(null, array3, null);
		}
	}

	internal void Copy(Cell cell_0, PasteType pasteType_0)
	{
		if (cell_0 == null)
		{
			switch (pasteType_0)
			{
			case PasteType.AllExceptBorders:
				method_6();
				int_1 = -1;
				break;
			case PasteType.Formats:
				int_1 = -1;
				break;
			case PasteType.All:
			case PasteType.Formulas:
			case PasteType.Values:
				method_6();
				int_1 = -1;
				break;
			case PasteType.FormulasAndNumberFormats:
			case PasteType.ValuesAndNumberFormats:
				method_6();
				int_1 = -1;
				break;
			case PasteType.ColumnWidths:
			case PasteType.Comments:
			case PasteType.Validation:
				break;
			}
			return;
		}
		bool flag = false;
		switch (pasteType_0)
		{
		case PasteType.All:
			Copy(cell_0);
			break;
		case PasteType.AllExceptBorders:
		{
			CopyData(cell_0);
			Style style3 = GetStyle();
			StyleFlag styleFlag3 = new StyleFlag();
			styleFlag3.NumberFormat = true;
			styleFlag3.Font = true;
			styleFlag3.CellShading = true;
			styleFlag3.Locked = true;
			styleFlag3.HideFormula = true;
			styleFlag3.HorizontalAlignment = true;
			styleFlag3.VerticalAlignment = true;
			styleFlag3.Indent = true;
			styleFlag3.Rotation = true;
			styleFlag3.ShrinkToFit = true;
			styleFlag3.TextDirection = true;
			styleFlag3.WrapText = true;
			Class1677.ApplyStyle(cell_0.GetStyle(), style3, styleFlag3);
			method_30(style3);
			break;
		}
		case PasteType.Formats:
			if (cell_0.cells_0.method_19() != cells_0.method_19())
			{
				method_30(cell_0.method_32());
			}
			else
			{
				int_1 = cell_0.method_35();
			}
			break;
		case PasteType.Formulas:
			CopyData(cell_0);
			flag = cell_0.IsFormula;
			break;
		case PasteType.FormulasAndNumberFormats:
		{
			CopyData(cell_0);
			StyleFlag styleFlag2 = new StyleFlag();
			styleFlag2.NumberFormat = true;
			Style style2 = GetStyle();
			Class1677.ApplyStyle(cell_0.GetStyle(), style2, styleFlag2);
			method_30(style2);
			flag = cell_0.IsFormula;
			break;
		}
		case PasteType.Values:
			PutValue(cell_0.Value);
			break;
		case PasteType.ValuesAndNumberFormats:
		{
			StyleFlag styleFlag = new StyleFlag();
			styleFlag.NumberFormat = true;
			Style style = GetStyle();
			Class1677.ApplyStyle(cell_0.GetStyle(), style, styleFlag);
			method_30(style);
			break;
		}
		}
		if (flag && IsFormula && (cell_0.int_0 != int_0 || cell_0.short_0 != short_0))
		{
			Class1655 @class = (Class1655)object_0;
			Class1674.smethod_8(cells_0.method_19(), int_0, int_0 - cell_0.int_0, cell_0.int_0, short_0, short_0 - cell_0.short_0, cell_0.short_0, @class.byte_0, -1, -1);
			if (@class.method_0() != null)
			{
				@class.method_0().method_6(cells_0.method_3(), cells_0 == cell_0.cells_0, cell_0.method_50().CellArea, int_0, short_0);
			}
		}
	}

	/// <summary>
	///       Copies data from a source cell.
	///       </summary>
	/// <param name="cell">Source <see cref="T:Aspose.Cells.Cell" /> object.</param>
	public void Copy(Cell cell)
	{
		if (this == cell)
		{
			return;
		}
		cells_0.method_19().Workbook.method_5();
		method_6();
		if (cell.method_46())
		{
			cell.method_48();
		}
		method_54(cell);
		if (!IsFormula)
		{
			return;
		}
		if (cells_0.method_19().Workbook.bool_0)
		{
			cells_0.method_19().Workbook.class1380_0.method_2(this);
		}
		if (cell.int_0 != int_0 || cell.short_0 != short_0)
		{
			Class1655 @class = (Class1655)object_0;
			Class1674.smethod_8(cells_0.method_19(), int_0, int_0 - cell.int_0, cell.int_0, short_0, short_0 - cell.short_0, cell.short_0, @class.byte_0, -1, -1);
			if (@class.method_0() != null)
			{
				@class.method_0().method_6(cells_0.method_3(), cells_0 == cell.cells_0, cell.method_50().CellArea, int_0, short_0);
			}
		}
	}

	[SpecialName]
	internal Class1348 method_50()
	{
		if (IsFormula)
		{
			return ((Class1655)object_0).method_0();
		}
		return null;
	}

	[SpecialName]
	internal void method_51(Class1348 class1348_0)
	{
		if (IsFormula)
		{
			((Class1655)object_0).method_1(class1348_0);
		}
	}

	[SpecialName]
	internal Class1119 method_52()
	{
		if (IsFormula)
		{
			return ((Class1655)object_0).method_2();
		}
		return null;
	}

	[SpecialName]
	internal void method_53(Class1119 class1119_0)
	{
		if (IsFormula)
		{
			((Class1655)object_0).method_3(class1119_0);
		}
	}

	internal void CopyData(Cell cell_0)
	{
		method_6();
		if (cell_0.method_20() == Enum199.const_6)
		{
			if (cell_0.IsRichText())
			{
				method_55(cell_0, null);
			}
			else
			{
				PutValue(cell_0.StringValue);
			}
		}
		else if (cell_0.IsFormula)
		{
			if (cells_0.method_19().Workbook.bool_0)
			{
				cells_0.method_19().Workbook.class1380_0.method_2(this);
			}
			object_0 = new Class1655();
			((Class1655)object_0).Copy(cell_0, (Class1655)cell_0.object_0, this, null);
		}
		else
		{
			object_0 = cell_0.object_0;
		}
	}

	internal void method_54(Cell cell_0)
	{
		method_6();
		if (cell_0.method_20() == Enum199.const_6)
		{
			if (cell_0.IsRichText())
			{
				method_55(cell_0, null);
			}
			else
			{
				PutValue(cell_0.StringValue);
			}
		}
		else if (cell_0.IsFormula)
		{
			if (cells_0.method_19().Workbook.bool_0)
			{
				cells_0.method_19().Workbook.class1380_0.method_2(this);
			}
			object_0 = new Class1655();
			if (!((Class1655)object_0).Copy(cell_0, (Class1655)cell_0.object_0, this, null))
			{
				if (cell_0.Type == CellValueType.IsString)
				{
					PutValue(cell_0.StringValue);
				}
				else
				{
					object_0 = cell_0.object_0;
				}
			}
		}
		else
		{
			object_0 = cell_0.object_0;
		}
		if (cell_0.cells_0.method_19() != cells_0.method_19())
		{
			method_30(cell_0.method_32());
		}
		else
		{
			int_1 = cell_0.method_35();
		}
	}

	internal void method_55(Cell cell_0, CopyOptions copyOptions_0)
	{
		Class1720 @class = (Class1720)cell_0.object_0;
		if (cells_0.method_19() == cell_0.cells_0.method_19() && @class.method_6())
		{
			@class.int_0++;
			object_0 = @class;
			return;
		}
		Class1720 class2 = new Class1720(@class.string_0, null);
		class2.Copy(cell_0, @class, this);
		cells_0.method_2().method_11(class2);
		object_0 = class2;
	}

	internal void method_56(Cell cell_0, CopyOptions copyOptions_0)
	{
		method_6();
		if (cell_0.method_20() == Enum199.const_6)
		{
			if (cell_0.IsRichText())
			{
				method_55(cell_0, copyOptions_0);
			}
			else
			{
				PutValue(cell_0.StringValue);
			}
		}
		else if (cell_0.IsFormula)
		{
			object_0 = new Class1655();
			if (!copyOptions_0.bool_0 && cell_0.cells_0.method_19() != cells_0.method_19())
			{
				if (copyOptions_0.CopyInvalidFormulasAsValues)
				{
					if (((Class1655)cell_0.object_0).method_12(cell_0.cells_0, cell_0.cells_0.method_19(), copyOptions_0.hashtable_2, copyOptions_0.hashtable_3))
					{
						PutValue(cell_0.Value);
					}
					else if (!((Class1655)object_0).Copy(cell_0, (Class1655)cell_0.object_0, this, copyOptions_0))
					{
						PutValue(cell_0.object_0);
					}
				}
				else if (!((Class1655)object_0).Copy(cell_0, (Class1655)cell_0.object_0, this, copyOptions_0))
				{
					PutValue(cell_0.object_0);
				}
			}
			else
			{
				((Class1655)object_0).Copy((Class1655)cell_0.object_0, cell_0.cells_0.method_19(), cells_0.method_19(), copyOptions_0);
			}
		}
		else
		{
			object_0 = cell_0.object_0;
		}
		if (!copyOptions_0.bool_0 && cell_0.cells_0.method_19() != cells_0.method_19())
		{
			if (copyOptions_0.hashtable_0[cell_0.int_1] != null)
			{
				int_1 = (int)copyOptions_0.hashtable_0[cell_0.int_1];
				return;
			}
			int num = cell_0.int_1;
			Style style = cell_0.method_32();
			if (style == null)
			{
				int_1 = -1;
			}
			else if (style.method_12() != -1 && style.method_12() != 0)
			{
				if (copyOptions_0.hashtable_0[style.method_12()] == null)
				{
					Style style_ = cell_0.cells_0.method_19().method_45(style.method_12());
					copyOptions_0.hashtable_0.Add(style.method_12(), cells_0.method_19().method_58().method_6(style_));
				}
				int num2 = (int)copyOptions_0.hashtable_0[style.method_12()];
				int_1 = cells_0.method_19().method_58().method_1(style, num2);
			}
			else
			{
				int_1 = cells_0.method_19().method_59(style);
			}
			copyOptions_0.hashtable_0.Add(num, int_1);
		}
		else
		{
			int_1 = cell_0.int_1;
		}
	}

	internal object method_57()
	{
		if (IsFormula)
		{
			return ((Class1655)object_0).object_0;
		}
		return object_0;
	}

	internal Class1720 method_58()
	{
		return (Class1720)object_0;
	}

	internal object method_59()
	{
		if (object_0 == null)
		{
			return null;
		}
		object obj = object_0;
		if (obj is Class1655)
		{
			obj = ((Class1655)obj).object_0;
			if (obj == null)
			{
				return null;
			}
		}
		switch (System.Type.GetTypeCode(obj.GetType()))
		{
		case TypeCode.DateTime:
			return CellsHelper.GetDoubleFromDateTime((DateTime)obj, cells_0.method_19().Workbook.Settings.Date1904);
		default:
			if (obj is Class1719)
			{
				return ((Class1719)obj).string_0;
			}
			return obj;
		case TypeCode.String:
		{
			bool isError = false;
			ErrorType errorType = Class1673.smethod_3((string)obj, out isError);
			if (isError)
			{
				return errorType;
			}
			return obj;
		}
		case TypeCode.Int32:
			return (double)(int)obj;
		}
	}

	[SpecialName]
	internal byte method_60()
	{
		return method_17().method_4();
	}

	[SpecialName]
	internal void method_61(byte byte_0)
	{
		if (IsFormula)
		{
			method_17().method_5(byte_0);
		}
	}

	[SpecialName]
	internal bool method_62()
	{
		return method_17().method_6();
	}

	[SpecialName]
	internal void method_63(bool bool_0)
	{
		method_17().method_7(bool_0);
	}

	internal void SetFormula(Class1655 class1655_0)
	{
		object_0 = class1655_0;
	}

	internal void method_64(object object_1)
	{
		object_0 = object_1;
	}

	internal void method_65(object object_1)
	{
		if (object_0 != null && object_0 is Class1655)
		{
			((Class1655)object_0).object_0 = object_1;
		}
		else
		{
			object_0 = object_1;
		}
	}

	internal void method_66(object object_1, byte byte_0)
	{
		method_61(byte_0);
		Class1655 @class = (Class1655)object_0;
		if (object_1 == null)
		{
			@class.object_0 = Class1391.object_3;
		}
		else if (object_1 is ErrorType)
		{
			@class.object_0 = Class1673.smethod_4((ErrorType)object_1);
		}
		else if (object_1 is Array)
		{
			if (IsInArray)
			{
				Class1379.smethod_0(object_1, this);
				return;
			}
			object[][] array = (object[][])object_1;
			if (array[0][0] == null)
			{
				@class.object_0 = Class1391.object_3;
			}
			else if (array[0][0] is ErrorType)
			{
				@class.object_0 = Class1673.smethod_4((ErrorType)array[0][0]);
			}
			else
			{
				@class.object_0 = array[0][0];
			}
		}
		else
		{
			WorkbookSettings settings = cells_0.method_19().Workbook.Settings;
			if (settings.PrecisionAsDisplayed && object_1 is double)
			{
				object_1 = method_23((double)object_1);
			}
			@class.object_0 = object_1;
		}
	}

	internal void method_67(string string_0, ArrayList arrayList_1)
	{
		if (arrayList_1.Count != 0 && arrayList_1.Count != 1)
		{
			Class1720 @class = new Class1720(string_0, null);
			@class.method_5(arrayList_1);
			cells_0.method_2().method_11(@class);
			object_0 = @class;
			return;
		}
		PutValue(string_0);
		if (arrayList_1.Count == 1)
		{
			FontSetting fontSetting = (FontSetting)arrayList_1[0];
			Style style = GetStyle();
			style.Font.Copy(fontSetting.Font);
			method_30(style);
		}
	}

	/// <summary>
	///       Returns a Characters object that represents a range of characters within the cell text.
	///       </summary>
	/// <param name="startIndex">The index of the start of the character.</param>
	/// <param name="length">The number of characters.</param>
	/// <returns>Characters object.</returns>
	/// <remarks>This method only works on cell with string value.</remarks>
	/// <example>
	///   <code>
	///       [C#]
	///       excel.Worksheets[0].Cells["A1"].PutValue("Helloworld");
	///       excel.Worksheets[0].Cells["A1"].Characters(5, 5).Font.IsBold = true;
	///       excel.Worksheets[0].Cells["A1"].Characters(5, 5).Font.Color = Color.Blue;
	///
	///       [Visual Basic]
	///       excel.Worksheets(0).Cells("A1").PutValue("Helloworld")
	///       excel.Worksheets(0).Cells("A1").Characters(5, 5).Font.IsBold = True
	///       excel.Worksheets(0).Cells("A1").Characters(5, 5).Font.Color = Color.Blue
	///       </code>
	/// </example>
	public FontSetting Characters(int startIndex, int length)
	{
		if (method_20() != Enum199.const_6)
		{
			throw new CellsException(ExceptionType.InvalidOperator, "This method only works on cell with string value.");
		}
		Class1720 @class = null;
		if (object_0 is Class1720)
		{
			@class = (Class1720)object_0;
			if (@class.method_6())
			{
				if (@class.int_0 > 1)
				{
					Class1720 class2 = new Class1720(@class.string_0, null, 1);
					class2.method_7(@class, this);
					@class.int_0--;
					object_0 = class2;
					@class = class2;
					cells_0.method_2().method_11(@class);
				}
				else
				{
					@class.method_9(this);
				}
			}
		}
		else if (object_0 is Class1719)
		{
			cells_0.method_2().method_10(object_0, this);
			@class = new Class1720(((Class1719)object_0).string_0, null, 1);
			@class.method_5(new ArrayList());
			object_0 = @class;
			cells_0.method_2().method_11(@class);
		}
		ArrayList arrayList = @class.method_4();
		int num = 0;
		FontSetting fontSetting;
		while (true)
		{
			if (num < arrayList.Count)
			{
				fontSetting = (FontSetting)arrayList[num];
				if (fontSetting.Length == length && fontSetting.StartIndex == startIndex)
				{
					break;
				}
				num++;
				continue;
			}
			fontSetting = new FontSetting(startIndex, length, cells_0.method_19(), bool_1: false);
			fontSetting.Font.Copy(method_32().Font);
			fontSetting.Font.method_25();
			arrayList.Add(fontSetting);
			return fontSetting;
		}
		return fontSetting;
	}

	internal void method_68()
	{
		if (object_0 != null && object_0 is Class1720)
		{
			Class1720 @class = (Class1720)object_0;
			if (!@class.method_6())
			{
				Class1301 class2 = cells_0.method_2();
				int num = class2.method_13(@class, method_32().Font.method_21(), cells_0.method_19());
				object_0 = class2.class1719_0[num];
			}
		}
	}

	/// <summary>
	///       Indicates whether the cell string value is a rich text.
	///       </summary>
	public bool IsRichText()
	{
		if (object_0 != null)
		{
			return object_0 is Class1720;
		}
		return false;
	}

	/// <summary>
	///       Returns all Characters objects 
	///       that represents a range of characters within the cell text.
	///       </summary>
	/// <returns>All Characters objects </returns>
	public FontSetting[] GetCharacters()
	{
		if (IsRichText())
		{
			Class1720 @class = (Class1720)object_0;
			ArrayList characters = @class.GetCharacters(cells_0.method_19(), this);
			FontSetting[] array = new FontSetting[characters.Count];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = (FontSetting)characters[i];
			}
			return array;
		}
		return null;
	}

	internal ArrayList method_69()
	{
		ArrayList arrayList = new ArrayList();
		Style style = GetStyle();
		if (!IsRichText())
		{
			Class1544 @class = new Class1544();
			@class.string_0 = StringValue;
			@class.font_0 = style.method_40();
			arrayList.Add(@class);
		}
		else
		{
			Class1720 class2 = (Class1720)object_0;
			ArrayList characters = class2.GetCharacters(cells_0.method_19(), this);
			for (int i = 0; i < characters.Count; i++)
			{
				FontSetting fontSetting = (FontSetting)characters[i];
				Class1544 class3 = new Class1544();
				class3.string_0 = class2.string_0.Substring(fontSetting.StartIndex, fontSetting.Length);
				class3.font_0 = ((fontSetting.method_2() == null) ? style.Font : fontSetting.Font);
				arrayList.Add(class3);
			}
		}
		return arrayList;
	}

	internal ArrayList method_70()
	{
		ArrayList arrayList = new ArrayList();
		Style style = method_32();
		if (!IsRichText())
		{
			Class1544 @class = new Class1544();
			@class.string_0 = DisplayStringValue;
			Font font = style.method_40();
			if (font != null)
			{
				@class.font_0 = new Font(cells_0.method_19(), null, bool_0: false);
				@class.font_0.Copy(font);
			}
			arrayList.Add(@class);
		}
		else
		{
			Class1720 class2 = (Class1720)object_0;
			ArrayList characters = class2.GetCharacters(cells_0.method_19(), this);
			Font font2 = style.method_40();
			for (int i = 0; i < characters.Count; i++)
			{
				FontSetting fontSetting = (FontSetting)characters[i];
				Class1544 class3 = new Class1544();
				class3.string_0 = class2.string_0.Substring(fontSetting.StartIndex, fontSetting.Length);
				Font font3 = fontSetting.method_2();
				if (font3 == null)
				{
					font3 = font2;
				}
				if (font3 != null)
				{
					class3.font_0 = new Font(cells_0.method_19(), null, bool_0: false);
					class3.font_0.Copy(font3);
				}
				arrayList.Add(class3);
			}
		}
		return arrayList;
	}

	internal void method_71(Hashtable hashtable_0)
	{
		Class1655 @class = (Class1655)object_0;
		Class1674.smethod_17(@class.byte_0, -1, -1, hashtable_0, cells_0.method_19());
		if (@class.method_0() != null)
		{
			Class1674.smethod_17(@class.method_0().Formula, -1, -1, hashtable_0, cells_0.method_19());
		}
	}

	/// <summary>
	///       Returns a <see cref="T:Aspose.Cells.Range" /> object which represents a merged range.
	///       </summary>
	/// <returns>
	///   <see cref="T:Aspose.Cells.Range" /> object. Null if this cell is not merged.</returns>
	public Range GetMergedRange()
	{
		return cells_0.method_18().GetMergedRange(cells_0, int_0, short_0);
	}

	internal void method_72()
	{
		if (!method_45())
		{
			return;
		}
		Class1655 @class = (Class1655)object_0;
		byte[] array = new byte[@class.method_0().Formula.Length];
		Array.Copy(@class.method_0().Formula, array, array.Length);
		CellArea cellArea = @class.method_0().CellArea;
		int startRow = cellArea.StartRow;
		int endRow = cellArea.EndRow;
		int startColumn = cellArea.StartColumn;
		int endColumn = cellArea.EndColumn;
		@class.method_1(null);
		for (int i = startRow; i <= endRow; i++)
		{
			for (int j = startColumn; j <= endColumn; j++)
			{
				Cell cell = cells_0.CheckCell(i, j);
				if (cell == null || !cell.IsFormula)
				{
					continue;
				}
				@class = (Class1655)cell.object_0;
				if (cells_0.method_19().Formula.method_13(1, @class.byte_0))
				{
					int row = 0;
					int column = 0;
					cells_0.method_19().Formula.method_14(@class.byte_0, out row, out column);
					if (row == int_0 && column == short_0)
					{
						byte[] array2 = new byte[array.Length];
						Array.Copy(array, array2, array.Length);
						Class1674.smethod_18(array2, -1, -1, cell.int_0, cell.short_0, cells_0.method_19());
						@class.byte_0 = array2;
					}
				}
			}
		}
	}

	/// <summary>
	///       Sets a formula to a range of cells.
	///       </summary>
	/// <param name="sharedFormula">Shared formula.</param>
	/// <param name="rowNumber">Number of rows to populate the formula.</param>
	/// <param name="columnNumber">Number of columns to populate the formula.</param>
	public void SetSharedFormula(string sharedFormula, int rowNumber, int columnNumber)
	{
		if (rowNumber > 0 && columnNumber > 0)
		{
			method_6();
			string string_ = sharedFormula.Trim();
			cells_0.method_19().Formula.method_8(this, string_, rowNumber, columnNumber);
			if (cells_0.method_19().Workbook.bool_0)
			{
				cells_0.method_19().Workbook.class1380_0.method_2(this);
			}
			byte[] array = method_41();
			for (int i = int_0; i < int_0 + rowNumber; i++)
			{
				for (int j = short_0; j < short_0 + columnNumber; j++)
				{
					if (i != int_0 || j != short_0)
					{
						Cell cell = cells_0.GetCell(i, j, bool_2: false);
						cell.method_6();
						byte[] array2 = new byte[array.Length];
						Array.Copy(array, array2, array.Length);
						cell.object_0 = new Class1655(null, array2, null);
						if (cell.cells_0.method_19().Workbook.bool_0)
						{
							cell.cells_0.method_19().Workbook.class1380_0.method_2(cell);
						}
					}
				}
			}
			return;
		}
		throw new ArgumentOutOfRangeException();
	}

	internal byte[] method_73(string string_0, CellArea cellArea_0)
	{
		int num = cellArea_0.EndRow - cellArea_0.StartRow + 1;
		int num2 = cellArea_0.EndColumn - cellArea_0.StartColumn + 1;
		if (num <= 0 || num2 <= 0)
		{
			throw new ArgumentOutOfRangeException();
		}
		method_6();
		cells_0.method_19().Formula.method_8(this, string_0.Trim(), num, num2);
		Class1655 @class = (Class1655)object_0;
		@class.method_0().method_0(cellArea_0);
		return @class.byte_0;
	}

	internal void method_74(byte[] byte_0)
	{
		byte[] array = new byte[byte_0.Length];
		Array.Copy(byte_0, array, byte_0.Length);
		object_0 = new Class1655(null, array, null);
	}

	internal void method_75()
	{
		if (object_0 != null && object_0 is Class1655)
		{
			Class1655 @class = (Class1655)object_0;
			@class.string_0 = null;
		}
	}

	/// <summary>
	///       Returns a string represents the current Cell object.
	///       </summary>
	/// <returns>
	/// </returns>
	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Aspose.Cells.Cell [ ");
		stringBuilder.Append(Name);
		stringBuilder.Append("; ValueType : ");
		stringBuilder.Append(Class1130.smethod_6(Type));
		if (Type != CellValueType.IsNull)
		{
			stringBuilder.Append("; Value : " + StringValue);
		}
		if (IsFormula)
		{
			stringBuilder.Append("; Formula:" + Formula);
		}
		stringBuilder.Append(" ]");
		return stringBuilder.ToString();
	}
}
