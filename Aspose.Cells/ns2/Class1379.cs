using System;
using System.Runtime.CompilerServices;
using Aspose.Cells;
using ns12;
using ns38;
using ns51;

namespace ns2;

internal class Class1379
{
	private WorksheetCollection worksheetCollection_0;

	private Class1280 class1280_0;

	private Class1278 class1278_0;

	private Class1257 class1257_0;

	private Class1273 class1273_0;

	[SpecialName]
	internal Class1280 method_0()
	{
		return class1280_0;
	}

	internal static byte[] Copy(WorksheetCollection worksheetCollection_1, WorksheetCollection worksheetCollection_2, byte[] byte_0, int int_0, int int_1, int int_2)
	{
		if (byte_0 == null)
		{
			return null;
		}
		byte[] result = null;
		if (worksheetCollection_1.Workbook.method_21() == worksheetCollection_2.Workbook.method_21())
		{
			result = new byte[byte_0.Length];
			Array.Copy(byte_0, 0, result, 0, byte_0.Length);
			return result;
		}
		switch (worksheetCollection_1.Workbook.method_21())
		{
		case Enum187.const_0:
			switch (worksheetCollection_2.Workbook.method_21())
			{
			case Enum187.const_1:
				result = Class1247.smethod_1(byte_0, int_0, int_1, int_2, bool_0: false);
				break;
			}
			break;
		case Enum187.const_1:
			switch (worksheetCollection_2.Workbook.method_21())
			{
			case Enum187.const_0:
				result = Class1248.smethod_1(byte_0, int_0);
				break;
			}
			break;
		}
		return result;
	}

	internal Class1379(WorksheetCollection worksheetCollection_1)
	{
		worksheetCollection_0 = worksheetCollection_1;
		class1278_0 = new Class1278(worksheetCollection_0);
		class1280_0 = new Class1280(worksheetCollection_0);
		class1257_0 = new Class1257(worksheetCollection_0);
		class1273_0 = new Class1273(worksheetCollection_0);
	}

	internal byte[] method_1(string addInFormula, out string functionName, Cell cell)
	{
		if (addInFormula[0] != '=')
		{
			throw new CellsException(ExceptionType.Formula, "Invalid function format.");
		}
		Class1661 @class = method_7(addInFormula);
		if (@class.Type != Enum180.const_3)
		{
			throw new CellsException(ExceptionType.Formula, "Invalid function format.");
		}
		@class.Type = Enum180.const_4;
		functionName = @class.method_3();
		byte[] array = class1280_0.method_1(@class, worksheetCollection_0, cell, 0, 0, 0, Enum227.const_1, Enum226.const_0, bool_0: false);
		byte[] array2 = new byte[array.Length + 5];
		array2[0] = 57;
		Array.Copy(array, 2, array2, 7, array.Length - 2);
		return array2;
	}

	[SpecialName]
	internal bool method_2()
	{
		return class1280_0.method_0();
	}

	internal byte[] method_3(string string_0, int int_0, int int_1, Enum226 enum226_0, Enum227 enum227_0, bool bool_0, bool bool_1)
	{
		try
		{
			Class1661 class1661_ = method_7(string_0);
			return class1280_0.method_1(class1661_, worksheetCollection_0, null, int_0, int_1, (byte)(bool_0 ? 1 : 0), enum227_0, enum226_0, bool_1);
		}
		catch (Exception ex)
		{
			throw new CellsException(ExceptionType.Formula, ex.Message + "\"" + string_0 + "\".");
		}
	}

	internal void method_4(Cell cell_0, string string_0, byte byte_0, bool bool_0)
	{
		int int_ = 1;
		if (string_0[0] != '=')
		{
			int_ = 0;
		}
		try
		{
			Class1661 class1661_ = class1278_0.method_0(string_0, int_);
			byte[] byte_ = class1280_0.method_1(class1661_, worksheetCollection_0, cell_0, cell_0.Row, cell_0.Column, byte_0, Enum227.const_1, Enum226.const_0, bool_0: true);
			Class1655 @class = new Class1655(string_0, byte_, null);
			if (!bool_0)
			{
				@class.string_0 = null;
			}
			cell_0.SetFormula(@class);
		}
		catch (Exception ex)
		{
			Class1655 object_ = new Class1655(string_0, null, null);
			cell_0.method_65(object_);
			throw new CellsException(ExceptionType.Formula, "Error in Cell: " + cell_0.Name + "-" + ex.Message + "\"" + cell_0.Formula + "\".");
		}
	}

	internal byte[] method_5(Cell cell_0, string string_0, byte byte_0)
	{
		if (string_0[0] != '=')
		{
			throw new CellsException(ExceptionType.Formula, "Invalid formula:\"" + cell_0.Formula + "\".");
		}
		try
		{
			Class1661 class1661_ = method_7(string_0);
			return class1280_0.method_1(class1661_, worksheetCollection_0, cell_0, cell_0.Row, cell_0.Column, byte_0, Enum227.const_1, Enum226.const_0, bool_0: true);
		}
		catch (Exception ex)
		{
			throw new CellsException(ExceptionType.Formula, "Error in Cell: " + cell_0.Name + "-" + ex.Message + "\"" + cell_0.Formula + "\".");
		}
	}

	internal void method_6(Cell cell_0, string string_0, int int_0, int int_1)
	{
		if (string_0[0] != '=')
		{
			throw new CellsException(ExceptionType.Formula, "Invalid formula:\"" + string_0 + "\".");
		}
		Class1661 class1661_ = method_7(string_0);
		byte[] byte_ = class1280_0.method_1(class1661_, worksheetCollection_0, cell_0, 0, 0, 0, Enum227.const_1, Enum226.const_1, bool_0: true);
		CellArea cellArea_ = default(CellArea);
		cellArea_.StartRow = cell_0.Row;
		cellArea_.StartColumn = cell_0.Column;
		cellArea_.EndRow = cell_0.Row + int_0 - 1;
		cellArea_.EndColumn = cell_0.Column + int_1 - 1;
		Class1348 class1348_ = new Class1348(cellArea_, bool_0: true, byte_);
		byte_ = class1280_0.method_2(1, cell_0.Row, cell_0.Column);
		Class1655 @class = new Class1655(string_0, byte_, null);
		@class.method_1(class1348_);
		cell_0.SetFormula(@class);
	}

	internal Class1661 method_7(string string_0)
	{
		int int_ = 1;
		if (string_0[0] != '=')
		{
			int_ = 0;
		}
		return class1278_0.method_0(string_0, int_);
	}

	internal void method_8(Cell cell_0, string string_0, int int_0, int int_1)
	{
		if (string_0[0] != '=')
		{
			throw new CellsException(ExceptionType.Formula, "Invalid formula:\"" + string_0 + "\".");
		}
		try
		{
			Class1661 class1661_ = method_7(string_0);
			byte[] byte_ = class1280_0.method_1(class1661_, worksheetCollection_0, cell_0, cell_0.Row, cell_0.Column, 1, Enum227.const_1, Enum226.const_0, bool_0: true);
			CellArea cellArea_ = default(CellArea);
			cellArea_.StartRow = cell_0.Row;
			cellArea_.StartColumn = cell_0.Column;
			cellArea_.EndRow = cell_0.Row + int_0 - 1;
			cellArea_.EndColumn = cell_0.Column + int_1 - 1;
			Class1348 class1348_ = new Class1348(cellArea_, bool_0: false, byte_);
			byte_ = class1280_0.method_2(1, cell_0.Row, cell_0.Column);
			Class1655 @class = new Class1655(string_0, byte_, null);
			@class.method_1(class1348_);
			cell_0.SetFormula(@class);
		}
		catch (Exception ex)
		{
			throw new CellsException(ExceptionType.Formula, "Error in Cell: " + cell_0.Name + "-" + ex.Message + "\"" + string_0 + "\".");
		}
	}

	internal Class1661 method_9(Name name_0, Cell cell_0)
	{
		if (name_0.method_2() != null)
		{
			return method_11(cell_0, name_0.method_2(), -1);
		}
		Class1661 @class = method_7(name_0.RefersTo);
		class1280_0.method_1(@class, worksheetCollection_0, null, 0, 0, 0, Enum227.const_1, Enum226.const_2, bool_0: true);
		return @class;
	}

	internal Class1661 method_10(Cell cell_0)
	{
		if (cell_0.method_41() == null)
		{
			throw new CellsException(ExceptionType.Formula, "Unsupported formula in cell " + cell_0.Name + ":\"" + cell_0.Formula + "\".");
		}
		return method_11(cell_0, null, -1);
	}

	internal Class1661 method_11(Cell cell_0, byte[] byte_0, int int_0)
	{
		if (worksheetCollection_0.Workbook.method_24())
		{
			return class1273_0.method_0(cell_0, byte_0, int_0);
		}
		return class1257_0.method_0(cell_0, byte_0, int_0);
	}

	[SpecialName]
	internal bool method_12()
	{
		if (worksheetCollection_0.Workbook.method_24())
		{
			return class1273_0.bool_0;
		}
		return class1257_0.bool_0;
	}

	internal bool method_13(byte byte_0, byte[] byte_1)
	{
		if (worksheetCollection_0.Workbook.method_24())
		{
			int num = BitConverter.ToInt32(byte_1, 0);
			if (num == 7)
			{
				return byte_1[4] == byte_0;
			}
			return false;
		}
		if (byte_1[0] == 5)
		{
			return byte_1[2] == byte_0;
		}
		return false;
	}

	internal void method_14(byte[] data, out int row, out int column)
	{
		if (worksheetCollection_0.Workbook.method_24())
		{
			row = BitConverter.ToInt32(data, 5);
			column = Class1268.smethod_1(data, 9);
		}
		else
		{
			row = BitConverter.ToUInt16(data, 3);
			column = data[5];
		}
	}

	internal static void smethod_0(object object_0, Cell cell_0)
	{
		CellArea cellArea = cell_0.method_50().CellArea;
		Cells cells = cell_0.method_4();
		Cell cell = null;
		if (object_0 == null)
		{
			for (int i = cellArea.StartRow; i <= cellArea.EndRow; i++)
			{
				for (int j = cellArea.StartColumn; j <= cellArea.EndColumn; j++)
				{
					cell = cells.GetCell(i, j, bool_2: false);
					cell.method_66(ErrorType.NA, 2);
				}
			}
			return;
		}
		if (!(object_0 is Array))
		{
			for (int k = cellArea.StartRow; k <= cellArea.EndRow; k++)
			{
				for (int l = cellArea.StartColumn; l <= cellArea.EndColumn; l++)
				{
					cell = cells.GetCell(k, l, bool_2: false);
					cell.method_66(object_0, 2);
				}
			}
			return;
		}
		Array array = (Array)object_0;
		for (int m = 0; m < array.Length && cellArea.StartRow + m <= cellArea.EndRow; m++)
		{
			int int_ = cellArea.StartRow + m;
			object value = array.GetValue(m);
			if (value == null)
			{
				for (int n = cellArea.StartColumn; n <= cellArea.EndColumn; n++)
				{
					cell = cells.GetCell(int_, n, bool_2: false);
					cell.method_66(ErrorType.NA, 2);
				}
			}
			else
			{
				if (!(value is Array))
				{
					continue;
				}
				Array array2 = (Array)value;
				for (int num = 0; num < array2.Length && cellArea.StartColumn + num <= cellArea.EndColumn; num++)
				{
					cell = cells.GetCell(int_, cellArea.StartColumn + num, bool_2: false);
					object value2 = array2.GetValue(num);
					cell.method_66(value2, 2);
				}
				if (cellArea.EndColumn - cellArea.StartColumn + 1 > array2.Length)
				{
					for (int num2 = cellArea.StartColumn + array2.Length; num2 <= cellArea.EndColumn; num2++)
					{
						cell = cells.GetCell(int_, num2, bool_2: false);
						cell.method_66(ErrorType.NA, 2);
					}
				}
			}
		}
		if (array.Length >= cellArea.EndRow - cellArea.StartRow + 1)
		{
			return;
		}
		for (int num3 = cellArea.StartRow + array.Length; num3 <= cellArea.EndRow; num3++)
		{
			for (int num4 = cellArea.StartColumn; num4 <= cellArea.EndColumn; num4++)
			{
				cell = cells.GetCell(num3, num4, bool_2: false);
				cell.method_66(ErrorType.NA, 2);
			}
		}
	}
}
