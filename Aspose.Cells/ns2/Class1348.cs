using System.Runtime.CompilerServices;
using Aspose.Cells;
using ns29;

namespace ns2;

internal class Class1348
{
	private CellArea cellArea_0;

	private byte[] byte_0;

	private byte byte_1;

	internal CellArea CellArea => cellArea_0;

	internal byte[] Formula
	{
		get
		{
			return byte_0;
		}
		set
		{
			byte_0 = value;
		}
	}

	internal Class1348(CellArea cellArea_1, bool bool_0, byte[] byte_2)
	{
		cellArea_0 = cellArea_1;
		method_2(bool_0);
		byte_0 = byte_2;
	}

	internal Class1348()
	{
	}

	internal void Copy(Class1348 class1348_0, WorksheetCollection worksheetCollection_0, WorksheetCollection worksheetCollection_1)
	{
		byte_1 = class1348_0.byte_1;
		byte_0 = Class1379.Copy(worksheetCollection_0, worksheetCollection_1, class1348_0.byte_0, -1, class1348_0.cellArea_0.StartRow, class1348_0.cellArea_0.EndRow);
		cellArea_0 = default(CellArea);
		cellArea_0.StartRow = class1348_0.cellArea_0.StartRow;
		cellArea_0.StartColumn = class1348_0.cellArea_0.StartColumn;
		cellArea_0.EndRow = class1348_0.cellArea_0.EndRow;
		cellArea_0.EndColumn = class1348_0.cellArea_0.EndColumn;
	}

	[SpecialName]
	internal void method_0(CellArea cellArea_1)
	{
		cellArea_0 = cellArea_1;
	}

	[SpecialName]
	internal bool method_1()
	{
		return (byte_1 & 0x10) != 0;
	}

	[SpecialName]
	internal void method_2(bool bool_0)
	{
		if (bool_0)
		{
			byte_1 |= 16;
		}
		else
		{
			byte_1 &= 254;
		}
	}

	[SpecialName]
	internal byte method_3()
	{
		return (byte)(byte_1 & 0xF0u);
	}

	[SpecialName]
	internal void method_4(byte byte_2)
	{
		byte_1 &= 240;
		byte_1 |= byte_2;
	}

	internal void InsertRows(Worksheet worksheet_0, bool bool_0, int int_0, int int_1, int int_2, int int_3)
	{
		if (int_2 != 0)
		{
			bool bool_ = false;
			if (bool_0)
			{
				cellArea_0 = Class1678.InsertRows(cellArea_0, int_3, int_2, ref bool_);
			}
			Class1674.InsertRows(worksheet_0, bool_0, int_3, int_2, int_0, int_1, -1, byte_0.Length - 1, byte_0);
		}
	}

	internal void method_5(Worksheet worksheet_0, bool bool_0, CellArea cellArea_1, int int_0, ShiftType shiftType_0, int int_1, int int_2, int int_3, int int_4)
	{
		if (bool_0 && shiftType_0 == ShiftType.Down)
		{
			if (cellArea_1.StartRow <= CellArea.StartRow)
			{
				if (cellArea_1.StartColumn <= cellArea_0.StartColumn && cellArea_1.EndColumn >= cellArea_0.EndColumn)
				{
					cellArea_0.StartRow += int_0;
					cellArea_0.EndRow += int_0;
				}
			}
			else
			{
				_ = CellArea.EndRow;
			}
		}
		Class1674.smethod_19(cellArea_1, int_0, shiftType_0, worksheet_0, bool_0, byte_0, -1, -1, int_1, int_2, int_3, int_4);
	}

	internal void InsertColumns(Worksheet worksheet_0, bool bool_0, int int_0, int int_1, int int_2, int int_3)
	{
		if (int_2 != 0)
		{
			bool bool_ = false;
			if (bool_0)
			{
				cellArea_0 = Class1678.InsertColumns(cellArea_0, int_3, int_2, ref bool_);
			}
			Class1674.InsertColumns(worksheet_0, bool_0, int_3, int_2, int_0, int_1, -1, byte_0.Length - 1, byte_0);
		}
	}

	internal void method_6(Worksheet worksheet_0, bool bool_0, CellArea cellArea_1, int int_0, int int_1)
	{
		if (bool_0)
		{
			cellArea_0.StartRow = int_0;
			cellArea_0.StartColumn = int_1;
			cellArea_0.EndRow = int_0 + cellArea_1.EndRow - cellArea_1.StartRow;
			cellArea_0.EndColumn = int_1 + cellArea_1.EndColumn - cellArea_1.StartColumn;
		}
		Class1674.smethod_8(worksheet_0.method_2(), int_0, int_0 - cellArea_1.StartRow, cellArea_1.StartRow, int_1, int_1 - cellArea_1.StartColumn, cellArea_1.StartColumn, byte_0, -1, -1);
	}
}
