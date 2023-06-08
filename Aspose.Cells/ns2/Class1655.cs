using System;
using System.Collections;
using System.Runtime.CompilerServices;
using Aspose.Cells;

namespace ns2;

internal class Class1655
{
	internal byte[] byte_0;

	internal string string_0;

	internal object object_0;

	internal object object_1;

	internal byte byte_1;

	internal bool IsInArray => (byte_1 & 0x20) != 0;

	internal bool IsArrayHeader
	{
		get
		{
			if (method_0() != null && method_0().method_1())
			{
				return true;
			}
			return false;
		}
	}

	[SpecialName]
	internal Class1348 method_0()
	{
		if (object_1 != null && object_1 is Class1348)
		{
			return (Class1348)object_1;
		}
		return null;
	}

	[SpecialName]
	internal void method_1(Class1348 class1348_0)
	{
		object_1 = class1348_0;
	}

	[SpecialName]
	internal Class1119 method_2()
	{
		if (object_1 != null && object_1 is Class1119)
		{
			return (Class1119)object_1;
		}
		return null;
	}

	[SpecialName]
	internal void method_3(Class1119 class1119_0)
	{
		object_1 = class1119_0;
	}

	[SpecialName]
	internal byte method_4()
	{
		return (byte)(byte_1 & 0xFu);
	}

	[SpecialName]
	internal void method_5(byte byte_2)
	{
		byte_1 &= 240;
		byte_1 |= byte_2;
	}

	[SpecialName]
	internal bool method_6()
	{
		return (byte_1 & 0x10) != 0;
	}

	[SpecialName]
	internal void method_7(bool bool_0)
	{
		byte_1 &= 239;
		if (bool_0)
		{
			byte_1 |= 16;
		}
	}

	[SpecialName]
	internal void method_8(bool bool_0)
	{
		byte_1 &= 223;
		if (bool_0)
		{
			byte_1 |= 32;
		}
	}

	internal Class1655()
	{
	}

	internal Class1655(string string_1, byte[] byte_2, object object_2)
	{
		string_0 = string_1;
		byte_0 = byte_2;
		object_0 = object_2;
	}

	[SpecialName]
	internal bool method_9()
	{
		if (method_0() != null && !method_0().method_1())
		{
			return true;
		}
		return false;
	}

	internal bool method_10(Cells cells_0)
	{
		byte[] array = byte_0;
		if (array == null)
		{
			return false;
		}
		if (cells_0.method_19().Formula.method_13(2, array))
		{
			return true;
		}
		return false;
	}

	internal bool method_11(Cells cells_0)
	{
		if (method_0() != null && !method_0().method_1())
		{
			return true;
		}
		if (IsInArray)
		{
			return false;
		}
		byte[] array = byte_0;
		if (array == null)
		{
			return false;
		}
		if (cells_0.method_19().Formula.method_13(1, array))
		{
			return true;
		}
		return false;
	}

	internal bool method_12(Cells cells_0, WorksheetCollection worksheetCollection_0, Hashtable hashtable_0, Hashtable hashtable_1)
	{
		if (method_0() != null && Class1674.smethod_13(method_0().Formula, -1, -1, worksheetCollection_0, hashtable_0, hashtable_1))
		{
			return true;
		}
		if (byte_0 != null)
		{
			if (worksheetCollection_0.Formula.method_13(1, byte_0))
			{
				int row = 0;
				int column = 0;
				worksheetCollection_0.Formula.method_14(byte_0, out row, out column);
				Cell cell = cells_0.CheckCell(row, column);
				if (cell != null)
				{
					Class1348 @class = cell.method_50();
					byte[] formula = @class.Formula;
					return Class1674.smethod_13(formula, -1, -1, worksheetCollection_0, hashtable_0, hashtable_1);
				}
			}
			if (Class1674.smethod_13(byte_0, -1, -1, worksheetCollection_0, hashtable_0, hashtable_1))
			{
				return true;
			}
		}
		return false;
	}

	internal void Copy(Class1655 class1655_0, WorksheetCollection worksheetCollection_0, WorksheetCollection worksheetCollection_1, CopyOptions copyOptions_0)
	{
		byte_0 = Class1379.Copy(worksheetCollection_0, worksheetCollection_1, class1655_0.byte_0, -1, 0, 0);
		if (class1655_0.method_0() != null)
		{
			method_1(new Class1348());
			method_0().Copy(class1655_0.method_0(), worksheetCollection_0, worksheetCollection_1);
			if (copyOptions_0.hashtable_1 != null)
			{
				Class1674.smethod_17(method_0().Formula, -1, -1, copyOptions_0.hashtable_1, worksheetCollection_1);
			}
		}
		else if (copyOptions_0.hashtable_1 != null)
		{
			Class1674.smethod_17(byte_0, -1, -1, copyOptions_0.hashtable_1, worksheetCollection_1);
		}
		object_0 = class1655_0.object_0;
		method_8(class1655_0.IsInArray);
	}

	internal bool Copy(Cell cell_0, Class1655 class1655_0, Cell cell_1, CopyOptions copyOptions_0)
	{
		bool flag = cell_0.method_4().method_19() == cell_1.method_4().method_19();
		object_0 = cell_0.Value;
		method_8(class1655_0.IsInArray);
		if (class1655_0.method_0() != null && class1655_0.method_0().method_1())
		{
			byte_0 = Class1379.Copy(cell_0.method_4().method_19(), cell_1.method_4().method_19(), cell_0.method_41(), -1, 0, 0);
			if (cell_0.method_50() != null)
			{
				method_1(new Class1348());
				method_0().Copy(cell_0.method_50(), cell_0.method_4().method_19(), cell_1.method_4().method_19());
			}
		}
		else
		{
			try
			{
				if (cell_1.method_4() == cell_0.method_4())
				{
					byte[] array = new byte[class1655_0.byte_0.Length];
					Array.Copy(class1655_0.byte_0, array, array.Length);
					byte_0 = array;
				}
				else
				{
					byte_0 = cell_1.method_4().method_19().Formula.method_5(cell_1, cell_0.Formula.Trim(), 0);
					object_0 = cell_0.Value;
				}
			}
			catch
			{
				if (!flag)
				{
					return false;
				}
				byte_0 = Class1379.Copy(cell_0.method_4().method_19(), cell_1.method_4().method_19(), cell_0.method_41(), -1, 0, 0);
				if (cell_0.method_50() != null)
				{
					method_1(new Class1348());
					method_0().Copy(cell_0.method_50(), cell_0.method_4().method_19(), cell_1.method_4().method_19());
				}
			}
		}
		return true;
	}
}
