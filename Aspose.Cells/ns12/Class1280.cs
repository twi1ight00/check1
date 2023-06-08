using System;
using System.Runtime.CompilerServices;
using Aspose.Cells;
using ns2;
using ns38;
using ns51;

namespace ns12;

internal class Class1280
{
	private Workbook workbook_0;

	private Class1263 class1263_0;

	private Class1272 class1272_0;

	internal Class1280(WorksheetCollection worksheetCollection_0)
	{
		workbook_0 = worksheetCollection_0.Workbook;
		class1263_0 = new Class1263(worksheetCollection_0);
		class1272_0 = new Class1272(worksheetCollection_0);
	}

	[SpecialName]
	internal bool method_0()
	{
		if (workbook_0.method_24())
		{
			return class1272_0.method_3();
		}
		return class1263_0.method_3();
	}

	internal byte[] method_1(Class1661 class1661_0, WorksheetCollection worksheetCollection_0, Cell cell_0, int int_0, int int_1, int int_2, Enum227 enum227_0, Enum226 enum226_0, bool bool_0)
	{
		if (workbook_0.method_24())
		{
			Class1272 @class = class1272_0;
			@class.method_0(cell_0);
			@class.method_1(cell_0, int_0, int_1, int_2);
			return @class.method_5(class1661_0, enum227_0, enum226_0, bool_0);
		}
		Class1263 class2 = class1263_0;
		class2.method_0(cell_0);
		class2.method_1(cell_0, int_0, int_1, int_2);
		return class2.method_5(class1661_0, enum227_0, enum226_0, bool_0);
	}

	internal byte[] method_2(byte byte_0, int int_0, int int_1)
	{
		if (workbook_0.method_24())
		{
			byte[] array = new byte[15]
			{
				7, 0, 0, 0, byte_0, 0, 0, 0, 0, 0,
				0, 0, 0, 0, 0
			};
			Array.Copy(BitConverter.GetBytes(int_0), 0, array, 5, 4);
			Array.Copy(BitConverter.GetBytes(int_1), 0, array, 9, 2);
			return array;
		}
		byte[] array2 = new byte[7] { 5, 0, byte_0, 0, 0, 0, 0 };
		Array.Copy(BitConverter.GetBytes(int_0), 0, array2, 3, 2);
		array2[5] = (byte)int_1;
		return array2;
	}
}
