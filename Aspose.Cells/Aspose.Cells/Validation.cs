using System;
using System.Collections;
using System.Globalization;
using System.Runtime.CompilerServices;
using ns2;
using ns29;
using ns60;
using ns61;

namespace Aspose.Cells;

/// <summary>
///        Represents data validation.settings.
///        </summary>
/// <example>
///   <code>
///        [C#]
///        Workbook workbook = new Workbook();
///       	ValidationCollection validations = workbook.Worksheets[0].Validations;
///       	Validation validation = validations[validations.Add()];
///       	validation.Type = Aspose.Cells.ValidationType.WholeNumber;
///       	validation.Operator = OperatorType.Between;
///       	validation.Formula1 = "3";
///       	validation.Formula2 = "1234";
///
///       	CellArea area;
///       	area.StartRow = 0;
///       	area.EndRow = 1;
///       	area.StartColumn = 0;
///       	area.EndColumn = 1;
///
///       	validation.AreaList.Add(area);
///
///       	[Visual Basic]
///       	Dim workbook as Workbook = new Workbook()
///       	Dim validations as ValidationCollection  = workbook.Worksheets(0).Validations
///       	Dim validation as Validation = validations(validations.Add())
///       	validation.Type = ValidationType.WholeNumber
///       	validation.Operator = OperatorType.Between
///       	validation.Formula1 = "3"
///       	validation.Formula2 = "1234"
///
///       	Dim area as CellArea
///       	area.StartRow = 0
///       	area.EndRow = 1
///       	area.StartColumn = 0
///       	area.EndColumn = 1
///
///       	validation.AreaList.Add(area)
///
///        </code>
/// </example>
public class Validation
{
	private ValidationCollection validationCollection_0;

	private bool bool_0 = true;

	private OperatorType operatorType_0 = OperatorType.None;

	private ValidationAlertType validationAlertType_0 = ValidationAlertType.Stop;

	private ValidationType validationType_0;

	private string string_0;

	private string string_1;

	private string string_2;

	private string string_3;

	private bool bool_1 = true;

	private bool bool_2 = true;

	private bool bool_3 = true;

	private string string_4;

	private string string_5;

	private bool bool_4 = true;

	internal ArrayList arrayList_0;

	private Enum228 enum228_0;

	internal byte[] byte_0;

	internal byte[] byte_1;

	/// <summary>
	///       Represents the operator for the data validation.
	///       </summary>
	public OperatorType Operator
	{
		get
		{
			return operatorType_0;
		}
		set
		{
			operatorType_0 = value;
			if (operatorType_0 != OperatorType.None)
			{
				bool_0 = false;
			}
		}
	}

	/// <summary>
	///       Represents the validation alert style.
	///       </summary>
	public ValidationAlertType AlertStyle
	{
		get
		{
			return validationAlertType_0;
		}
		set
		{
			validationAlertType_0 = value;
			if (validationAlertType_0 != ValidationAlertType.Stop)
			{
				bool_0 = false;
			}
		}
	}

	/// <summary>
	///       Represents the data validation type.
	///       </summary>
	public ValidationType Type
	{
		get
		{
			return validationType_0;
		}
		set
		{
			validationType_0 = value;
			if (validationType_0 != 0)
			{
				bool_0 = false;
			}
		}
	}

	/// <summary>
	///       Represents the data validation input message.
	///       </summary>
	public string InputMessage
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
			if (string_0 != null && string_0 != "")
			{
				bool_0 = false;
			}
		}
	}

	/// <summary>
	///       Represents the title of the data-validation input dialog box.
	///       </summary>
	public string InputTitle
	{
		get
		{
			return string_1;
		}
		set
		{
			string_1 = value;
			if (string_1 != null && string_1 != "")
			{
				bool_0 = false;
			}
		}
	}

	/// <summary>
	///       Represents the data validation error message.
	///       </summary>
	public string ErrorMessage
	{
		get
		{
			return string_2;
		}
		set
		{
			string_2 = value;
			if (string_2 != null && string_2 != "")
			{
				bool_0 = false;
			}
		}
	}

	/// <summary>
	///       Represents the title of the data-validation error dialog box. 
	///       </summary>
	public string ErrorTitle
	{
		get
		{
			return string_3;
		}
		set
		{
			string_3 = value;
			if (string_3 != null && string_3 != "")
			{
				bool_0 = false;
			}
		}
	}

	/// <summary>
	///       Indicates whether the data validation input message will be displayed whenever the user selects a cell in the data validation range.
	///       </summary>
	public bool ShowInput
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
			if (!value)
			{
				bool_0 = false;
			}
		}
	}

	/// <summary>
	///       Indicates whether the data validation error message will be displayed whenever the user enters invalid data. 
	///       </summary>
	public bool ShowError
	{
		get
		{
			return bool_2;
		}
		set
		{
			bool_2 = value;
			if (!value)
			{
				bool_0 = false;
			}
		}
	}

	/// <summary>
	///       Indicates whether blank values are permitted by the range data validation.
	///       </summary>
	public bool IgnoreBlank
	{
		get
		{
			return bool_3;
		}
		set
		{
			bool_3 = value;
			if (!value)
			{
				bool_0 = false;
			}
		}
	}

	/// <summary>
	///       Represents the value or expression associated with the data validation.
	///       </summary>
	public string Formula1
	{
		get
		{
			return string_4;
		}
		set
		{
			byte_0 = null;
			string_4 = value;
			if (value != null && value != "")
			{
				bool_0 = false;
			}
		}
	}

	public object Value1
	{
		get
		{
			byte[] array = method_7();
			if (array != null)
			{
				object obj = smethod_1(validationCollection_0.Worksheet.method_2(), array, 0, Type);
				if (obj != null)
				{
					return obj;
				}
			}
			return Formula1;
		}
		set
		{
			byte_0 = method_1(value);
			if (byte_0 == null)
			{
				Formula1 = value.ToString();
			}
			else
			{
				string_4 = value.ToString();
			}
		}
	}

	public object Value2
	{
		get
		{
			byte[] array = method_9();
			if (array != null)
			{
				object obj = smethod_1(validationCollection_0.Worksheet.method_2(), array, 0, Type);
				if (obj != null)
				{
					return obj;
				}
			}
			return Formula2;
		}
		set
		{
			byte_1 = method_1(value);
			if (byte_1 == null)
			{
				Formula2 = value.ToString();
			}
			else
			{
				string_5 = value.ToString();
			}
		}
	}

	/// <summary>
	///       Represents the value or expression associated with the second part of the data validation. 
	///       </summary>
	public string Formula2
	{
		get
		{
			return string_5;
		}
		set
		{
			byte_1 = null;
			string_5 = value;
			if (value != null && value != "")
			{
				bool_0 = false;
			}
		}
	}

	/// <summary>
	///       Indicates whether data validation displays a drop-down list that contains acceptable values.
	///       </summary>
	public bool InCellDropDown
	{
		get
		{
			return bool_4;
		}
		set
		{
			bool_4 = value;
			if (!value)
			{
				bool_0 = false;
			}
		}
	}

	/// <summary>
	///       Represents a collection of <see cref="T:Aspose.Cells.CellArea" /> which contains the data validation settings.
	///       </summary>
	/// <remarks>
	///       The old valvidations on the area will not be removed if directly adding are to this list.
	///       </remarks>
	public ArrayList AreaList => arrayList_0;

	internal Validation(ValidationCollection validationCollection_1)
	{
		arrayList_0 = new ArrayList();
		validationCollection_0 = validationCollection_1;
	}

	[SpecialName]
	internal bool method_0()
	{
		return bool_0;
	}

	internal byte[] method_1(object object_0)
	{
		object_0 = Class427.GetDoubleValue(object_0, validationCollection_0.Worksheet.method_2().Workbook.Settings.Date1904);
		double num = 0.0;
		if (object_0 != null)
		{
			num = (double)object_0;
			byte[] array = null;
			switch (Type)
			{
			default:
				return null;
			case ValidationType.WholeNumber:
			case ValidationType.Decimal:
			case ValidationType.Date:
			case ValidationType.Time:
			case ValidationType.TextLength:
				if (Math.Abs(num - (double)(int)num) < double.Epsilon)
				{
					int num2 = (int)num;
					if (num2 <= 65535 && num2 >= 0)
					{
						array = new byte[3] { 30, 0, 0 };
						Array.Copy(BitConverter.GetBytes((ushort)num2), 0, array, 1, 2);
					}
					else
					{
						array = new byte[9] { 31, 0, 0, 0, 0, 0, 0, 0, 0 };
						Array.Copy(BitConverter.GetBytes(num), 0, array, 1, 8);
					}
				}
				else
				{
					array = new byte[9] { 31, 0, 0, 0, 0, 0, 0, 0, 0 };
					Array.Copy(BitConverter.GetBytes(num), 0, array, 1, 8);
				}
				return array;
			}
		}
		return null;
	}

	internal void method_2(string string_6)
	{
		string_4 = string_6;
	}

	internal void method_3(string string_6)
	{
		string_5 = string_6;
	}

	internal int[] method_4()
	{
		if (arrayList_0 != null && arrayList_0.Count != 0)
		{
			CellArea cellArea = (CellArea)arrayList_0[0];
			return new int[2] { cellArea.StartRow, cellArea.StartColumn };
		}
		return null;
	}

	/// <summary>
	///       Applies the validation to the area.
	///       </summary>
	/// <param name="cellArea">The area.</param>
	/// <remarks>
	///       In this method , we will remove all old validations on this area.
	///       </remarks>
	public void AddArea(CellArea cellArea)
	{
		validationCollection_0.RemoveArea(cellArea, this);
		arrayList_0.Add(cellArea);
	}

	/// <summary>
	///       Remove the validation settings in the range.
	///       </summary>
	/// <param name="cellArea">The range which contains the data validation settings.</param>
	public void RemoveArea(CellArea cellArea)
	{
		if (arrayList_0 == null || arrayList_0.Count == 0)
		{
			return;
		}
		for (int num = arrayList_0.Count - 1; num >= 0; num--)
		{
			CellArea ca = (CellArea)arrayList_0[num];
			bool flag = false;
			CellArea cellArea2 = smethod_0(cellArea, ca, out flag);
			if (!flag)
			{
				if (cellArea2.StartRow > ca.StartRow)
				{
					CellArea cellArea3 = default(CellArea);
					cellArea3.StartRow = ca.StartRow;
					cellArea3.EndRow = cellArea2.StartRow - 1;
					cellArea3.StartColumn = ca.StartColumn;
					cellArea3.EndColumn = ca.EndColumn;
					arrayList_0.Add(cellArea3);
				}
				if (cellArea2.EndRow < ca.EndRow)
				{
					CellArea cellArea4 = default(CellArea);
					cellArea4.StartRow = cellArea2.EndRow + 1;
					cellArea4.EndRow = ca.EndRow;
					cellArea4.StartColumn = ca.StartColumn;
					cellArea4.EndColumn = ca.EndColumn;
					arrayList_0.Add(cellArea4);
				}
				ca.StartRow = cellArea2.StartRow;
				ca.EndRow = cellArea2.EndRow;
				if (cellArea2.StartColumn > ca.StartColumn)
				{
					CellArea cellArea5 = default(CellArea);
					cellArea5.StartRow = ca.StartRow;
					cellArea5.EndRow = ca.EndRow;
					cellArea5.StartColumn = ca.StartColumn;
					cellArea5.EndColumn = cellArea2.StartColumn - 1;
					arrayList_0.Add(cellArea5);
				}
				if (cellArea2.EndColumn < ca.EndColumn)
				{
					CellArea cellArea6 = default(CellArea);
					cellArea6.StartRow = ca.StartRow;
					cellArea6.EndRow = ca.EndRow;
					cellArea6.StartColumn = cellArea2.EndColumn + 1;
					cellArea6.EndColumn = ca.EndColumn;
					arrayList_0.Add(cellArea6);
				}
				arrayList_0.RemoveAt(num);
			}
		}
	}

	internal static CellArea smethod_0(CellArea ca1, CellArea ca2, out bool flag)
	{
		CellArea result = default(CellArea);
		result.StartRow = ((ca1.StartRow < ca2.StartRow) ? ca2.StartRow : ca1.StartRow);
		result.StartColumn = ((ca1.StartColumn < ca2.StartColumn) ? ca2.StartColumn : ca1.StartColumn);
		result.EndRow = ((ca1.EndRow < ca2.EndRow) ? ca1.EndRow : ca2.EndRow);
		result.EndColumn = ((ca1.EndColumn < ca2.EndColumn) ? ca1.EndColumn : ca2.EndColumn);
		flag = result.StartRow > result.EndRow || result.StartColumn > result.EndColumn;
		return result;
	}

	/// <summary>
	///       Remove the validation settings in the cell.
	///       </summary>
	/// <param name="row">The row index.</param>
	/// <param name="column"> The column index.</param>
	public void RemoveACell(int row, int column)
	{
		if (arrayList_0 == null || arrayList_0.Count == 0)
		{
			return;
		}
		int count = arrayList_0.Count;
		for (int num = count - 1; num >= 0; num--)
		{
			CellArea cellArea = (CellArea)arrayList_0[num];
			if (row >= cellArea.StartRow && row <= cellArea.EndRow && column >= cellArea.StartColumn && column <= cellArea.EndColumn)
			{
				if (row > cellArea.StartRow)
				{
					CellArea cellArea2 = default(CellArea);
					cellArea2.StartRow = cellArea.StartRow;
					cellArea2.EndRow = row - 1;
					cellArea2.StartColumn = cellArea.StartColumn;
					cellArea2.EndColumn = cellArea.EndColumn;
					arrayList_0.Add(cellArea2);
				}
				if (row < cellArea.EndRow)
				{
					CellArea cellArea3 = default(CellArea);
					cellArea3.StartRow = row + 1;
					cellArea3.EndRow = cellArea.EndRow;
					cellArea3.StartColumn = cellArea.StartColumn;
					cellArea3.EndColumn = cellArea.EndColumn;
					arrayList_0.Add(cellArea3);
				}
				cellArea.StartRow = row;
				cellArea.EndRow = row;
				if (column > cellArea.StartColumn)
				{
					CellArea cellArea4 = default(CellArea);
					cellArea4.StartRow = row;
					cellArea4.EndRow = row;
					cellArea4.StartColumn = cellArea.StartColumn;
					cellArea4.EndColumn = column - 1;
					arrayList_0.Add(cellArea4);
				}
				if (column < cellArea.EndColumn)
				{
					CellArea cellArea5 = default(CellArea);
					cellArea5.StartRow = row;
					cellArea5.EndRow = row;
					cellArea5.StartColumn = column + 1;
					cellArea5.EndColumn = cellArea.EndColumn;
					arrayList_0.Add(cellArea5);
				}
				arrayList_0.RemoveAt(num);
			}
		}
	}

	internal void InsertColumns(int int_0, int int_1, Worksheet worksheet_0)
	{
		if (arrayList_0 == null || arrayList_0.Count == 0)
		{
			return;
		}
		int column = 0;
		int row = 0;
		method_12(out row, out column);
		int num = 1048575;
		int num2 = 0;
		for (int num3 = arrayList_0.Count - 1; num3 >= 0; num3--)
		{
			CellArea cellArea = (CellArea)arrayList_0[num3];
			if (cellArea.EndColumn + 1 == int_0 && int_1 > 0)
			{
				cellArea.EndColumn += int_1;
				arrayList_0[num3] = cellArea;
			}
			else
			{
				bool flag = false;
				CellArea cellArea2 = Class1678.InsertColumns(cellArea, int_0, int_1, ref flag);
				if (flag)
				{
					arrayList_0.RemoveAt(num3);
				}
				else
				{
					arrayList_0[num3] = cellArea2;
					if (cellArea2.StartRow < num)
					{
						num = cellArea2.StartRow;
						num2 = cellArea2.StartColumn;
					}
				}
			}
		}
		if (arrayList_0.Count != 0)
		{
			byte[] array = method_7();
			if (array != null)
			{
				Class1674.InsertColumns(worksheet_0, bool_0: true, int_0, int_1, column, num2, 0, array.Length - 1, array);
				string_4 = smethod_2(worksheet_0.method_2(), array, 0, Type, num, num2);
			}
			array = method_9();
			if (array != null)
			{
				Class1674.InsertColumns(worksheet_0, bool_0: true, int_0, int_1, column, num2, 0, array.Length - 1, array);
				string_5 = smethod_2(worksheet_0.method_2(), array, 0, Type, num, num2);
			}
		}
	}

	internal void InsertRows(int int_0, int int_1, Worksheet worksheet_0)
	{
		if (arrayList_0 == null || arrayList_0.Count == 0)
		{
			return;
		}
		int row = 0;
		int column = 0;
		method_12(out row, out column);
		int num = 1048575;
		int int_2 = 0;
		for (int num2 = arrayList_0.Count - 1; num2 >= 0; num2--)
		{
			CellArea cellArea = (CellArea)arrayList_0[num2];
			bool flag = false;
			if (int_1 > 0 && int_0 == cellArea.EndRow + 1)
			{
				cellArea.EndRow = int_0 + int_1 - 1;
			}
			else
			{
				cellArea = Class1678.InsertRows(cellArea, int_0, int_1, ref flag);
			}
			if (flag)
			{
				arrayList_0.RemoveAt(num2);
			}
			else
			{
				arrayList_0[num2] = cellArea;
				if (cellArea.StartRow < num)
				{
					num = cellArea.StartRow;
					int_2 = cellArea.StartColumn;
				}
			}
		}
		if (arrayList_0.Count != 0)
		{
			byte[] array = method_7();
			if (array != null)
			{
				Class1674.InsertRows(worksheet_0, bool_0: true, int_0, int_1, row, num, 0, array.Length - 1, array);
				string_4 = smethod_2(worksheet_0.method_2(), array, 0, Type, num, int_2);
			}
			array = method_9();
			if (array != null)
			{
				Class1674.InsertRows(worksheet_0, bool_0: true, int_0, int_1, row, num, 0, array.Length - 1, array);
				string_5 = smethod_2(worksheet_0.method_2(), array, 0, Type, num, int_2);
			}
		}
	}

	[SpecialName]
	internal Enum228 method_5()
	{
		return enum228_0;
	}

	[SpecialName]
	internal void method_6(Enum228 enum228_1)
	{
		enum228_0 = enum228_1;
	}

	[SpecialName]
	internal byte[] method_7()
	{
		return byte_0;
	}

	[SpecialName]
	internal void method_8(byte[] byte_2)
	{
		byte_0 = byte_2;
	}

	[SpecialName]
	internal byte[] method_9()
	{
		return byte_1;
	}

	[SpecialName]
	internal void method_10(byte[] byte_2)
	{
		byte_1 = byte_2;
	}

	internal void CopyData(Validation validation_0)
	{
		validationAlertType_0 = validation_0.validationAlertType_0;
		string_2 = validation_0.string_2;
		string_3 = validation_0.string_3;
		string_4 = validation_0.string_4;
		string_5 = validation_0.string_5;
		bool_3 = validation_0.bool_3;
		enum228_0 = validation_0.enum228_0;
		bool_4 = validation_0.bool_4;
		string_0 = validation_0.string_0;
		string_1 = validation_0.string_1;
		bool_0 = validation_0.bool_0;
		operatorType_0 = validation_0.operatorType_0;
		bool_2 = validation_0.bool_2;
		bool_1 = validation_0.bool_1;
		validationType_0 = validation_0.validationType_0;
		arrayList_0.Clear();
	}

	internal void Copy(Validation validation_0, CopyOptions copyOptions_0)
	{
		validationAlertType_0 = validation_0.validationAlertType_0;
		string_2 = validation_0.string_2;
		string_3 = validation_0.string_3;
		string_4 = validation_0.string_4;
		string_5 = validation_0.string_5;
		bool_3 = validation_0.bool_3;
		enum228_0 = validation_0.enum228_0;
		bool_4 = validation_0.bool_4;
		string_0 = validation_0.string_0;
		string_1 = validation_0.string_1;
		bool_0 = validation_0.bool_0;
		operatorType_0 = validation_0.operatorType_0;
		bool_2 = validation_0.bool_2;
		bool_1 = validation_0.bool_1;
		validationType_0 = validation_0.validationType_0;
		arrayList_0.Clear();
		for (int i = 0; i < validation_0.arrayList_0.Count; i++)
		{
			CellArea cellArea_ = (CellArea)validation_0.arrayList_0[i];
			arrayList_0.Add(CellArea.CreateCellArea(cellArea_));
		}
	}

	internal void Copy(Validation validation_0, CellArea cellArea_0, Worksheet worksheet_0, CopyOptions copyOptions_0)
	{
		validationAlertType_0 = validation_0.validationAlertType_0;
		string_2 = validation_0.string_2;
		string_3 = validation_0.string_3;
		bool_3 = validation_0.bool_3;
		enum228_0 = validation_0.enum228_0;
		bool_4 = validation_0.bool_4;
		string_0 = validation_0.string_0;
		string_1 = validation_0.string_1;
		bool_0 = validation_0.bool_0;
		operatorType_0 = validation_0.operatorType_0;
		bool_2 = validation_0.bool_2;
		bool_1 = validation_0.bool_1;
		validationType_0 = validation_0.validationType_0;
		arrayList_0.Clear();
		arrayList_0.Add(cellArea_0);
		WorksheetCollection worksheetCollection = validation_0.validationCollection_0.Worksheet.method_2();
		WorksheetCollection worksheetCollection2 = validationCollection_0.Worksheet.method_2();
		if (worksheetCollection != worksheetCollection2)
		{
			if (validation_0.byte_0 != null)
			{
				Formula1 = smethod_2(worksheetCollection, validation_0.byte_0, 0, Type, cellArea_0.StartRow, cellArea_0.StartColumn);
			}
			if (validation_0.byte_1 != null)
			{
				Formula2 = smethod_2(worksheetCollection, validation_0.byte_1, 0, Type, cellArea_0.StartRow, cellArea_0.StartColumn);
			}
			return;
		}
		if (validation_0.byte_0 != null)
		{
			byte_0 = Class1379.Copy(worksheetCollection, worksheetCollection2, validation_0.byte_0, 0, cellArea_0.StartRow, cellArea_0.StartColumn);
			string_4 = smethod_2(worksheet_0.method_2(), byte_0, 0, Type, cellArea_0.StartRow, cellArea_0.StartColumn);
		}
		if (validation_0.byte_1 != null)
		{
			byte_1 = Class1379.Copy(worksheetCollection, worksheetCollection2, validation_0.byte_1, 0, cellArea_0.StartRow, cellArea_0.StartColumn);
			string_5 = smethod_2(worksheet_0.method_2(), byte_1, 0, Type, cellArea_0.StartRow, cellArea_0.StartColumn);
		}
	}

	internal bool method_11()
	{
		WorksheetCollection worksheetCollection_ = validationCollection_0.Worksheet.method_2();
		byte[] array = byte_0;
		if (array != null && Class1674.smethod_24(worksheetCollection_, array, 0, array.Length - 1))
		{
			return true;
		}
		if ((Operator == OperatorType.Between || Operator == OperatorType.NotBetween) && byte_1 != null)
		{
			array = byte_1;
			if (array != null && Class1674.smethod_24(worksheetCollection_, array, 0, array.Length - 1))
			{
				return true;
			}
		}
		return false;
	}

	internal void method_12(out int row, out int column)
	{
		Worksheet worksheet = validationCollection_0.Worksheet;
		if (worksheet.method_2().Workbook.method_24())
		{
			Class1739 @class = new Class1739(worksheet);
			@class.method_0(this);
			row = @class.StartRow;
			column = @class.StartColumn;
		}
		else
		{
			Class1738 class2 = new Class1738(worksheet);
			class2.method_0(this);
			row = class2.StartRow;
			column = class2.StartColumn;
		}
	}

	internal void method_13(string string_6, string string_7)
	{
		Worksheet worksheet = validationCollection_0.Worksheet;
		string_4 = string_6;
		string_5 = string_7;
		method_12(out var row, out var column);
		if (byte_0 != null && Class1674.smethod_2(worksheet.method_2(), byte_0, 0, bool_0: false))
		{
			string_4 = smethod_2(worksheet.method_2(), byte_0, 0, validationType_0, row, column);
		}
		if (byte_1 != null && Class1674.smethod_2(worksheet.method_2(), byte_1, 0, bool_0: false))
		{
			string_5 = smethod_2(worksheet.method_2(), byte_1, 0, validationType_0, row, column);
		}
	}

	internal static object smethod_1(WorksheetCollection worksheetCollection_0, byte[] byte_2, int int_0, ValidationType validationType_1)
	{
		if (byte_2.Length == 0)
		{
			return null;
		}
		object obj = Class1674.smethod_1(worksheetCollection_0, byte_2, int_0);
		if (obj != null)
		{
			switch (validationType_1)
			{
			case ValidationType.WholeNumber:
			case ValidationType.Decimal:
			case ValidationType.Date:
			case ValidationType.Time:
			case ValidationType.TextLength:
			{
				double num = 0.0;
				if (obj is int)
				{
					num = (int)obj;
				}
				else
				{
					if (!(obj is double))
					{
						return obj;
					}
					num = (double)obj;
				}
				switch (validationType_1)
				{
				case ValidationType.Decimal:
					return num;
				default:
					return obj;
				case ValidationType.Date:
				case ValidationType.Time:
					return CellsHelper.GetDateTimeFromDouble(num, worksheetCollection_0.Workbook.Settings.Date1904);
				case ValidationType.WholeNumber:
				case ValidationType.TextLength:
					return (int)num;
				}
			}
			}
		}
		return obj;
	}

	internal static string smethod_2(WorksheetCollection worksheetCollection_0, byte[] byte_2, int int_0, ValidationType validationType_1, int int_1, int int_2)
	{
		if (byte_2.Length == 0)
		{
			return null;
		}
		try
		{
			Class1659 @class = worksheetCollection_0.method_4();
			string text = @class.method_3(0, byte_2, int_1, int_2, bool_0: true);
			switch (validationType_1)
			{
			case ValidationType.List:
				if (Class1675.smethod_0(worksheetCollection_0, byte_2, int_0))
				{
					text = ((text.IndexOf("\"\"") != -1) ? text.Substring(1) : text.Substring(2, text.Length - 3));
					text = text.Replace('\0', ',');
				}
				break;
			case ValidationType.Date:
			{
				string s = text.Substring(1);
				if (Class1677.smethod_19(s))
				{
					double doubleValue = double.Parse(s, CultureInfo.InvariantCulture);
					DateTime dateTimeFromDouble = CellsHelper.GetDateTimeFromDouble(doubleValue, worksheetCollection_0.Workbook.Settings.Date1904);
					string text2 = dateTimeFromDouble.Year + "-" + dateTimeFromDouble.Month + "-" + dateTimeFromDouble.Day;
					text = ((dateTimeFromDouble.Hour != 0 || dateTimeFromDouble.Minute != 0 || dateTimeFromDouble.Second != 0) ? (text2 + " " + dateTimeFromDouble.Hour + ":" + dateTimeFromDouble.Minute + ":" + dateTimeFromDouble.Second) : text2);
				}
				break;
			}
			case ValidationType.Time:
			{
				string s = text.Substring(1);
				if (Class1677.smethod_19(s))
				{
					double num = 86400.0 * double.Parse(s, CultureInfo.InvariantCulture);
					int num2 = (int)num / 3600;
					int num3 = (int)(num - (double)(num2 * 3600)) / 60;
					int num4 = (int)(num - (double)(num2 * 3600) - (double)(num3 * 60));
					text = num2 + ":" + num3 + ":" + num4;
				}
				break;
			}
			}
			return text;
		}
		catch
		{
			return null;
		}
	}
}
