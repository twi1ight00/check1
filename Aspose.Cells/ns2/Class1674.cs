using System;
using System.Collections;
using Aspose.Cells;
using ns38;
using ns51;

namespace ns2;

internal class Class1674
{
	internal static byte[] smethod_0(WorksheetCollection worksheetCollection_0, object object_0)
	{
		if (worksheetCollection_0.Workbook.method_24())
		{
			return Class1266.smethod_0(object_0);
		}
		return Class1258.smethod_0(object_0);
	}

	internal static object smethod_1(WorksheetCollection worksheetCollection_0, byte[] byte_0, int int_0)
	{
		if (worksheetCollection_0.Workbook.method_24())
		{
			return Class1266.smethod_1(byte_0, int_0);
		}
		return Class1258.smethod_1(byte_0, int_0);
	}

	internal static bool smethod_2(WorksheetCollection worksheetCollection_0, byte[] byte_0, int int_0, bool bool_0)
	{
		if (worksheetCollection_0.Workbook.method_24())
		{
			return Class1266.smethod_2(byte_0, int_0, bool_0);
		}
		return Class1258.smethod_2(byte_0, int_0, bool_0);
	}

	internal static bool smethod_3(WorksheetCollection worksheetCollection_0, byte[] byte_0, int int_0)
	{
		if (int_0 == -1)
		{
			int_0 = ((!worksheetCollection_0.Workbook.method_24()) ? 2 : 4);
		}
		if (byte_0.Length > int_0 + 4 && byte_0[int_0] == 25)
		{
			return byte_0[int_0 + 1] == 1;
		}
		return false;
	}

	internal static int smethod_4(WorksheetCollection worksheetCollection_0, byte[] byte_0, int int_0)
	{
		int result = -1;
		switch (byte_0[int_0])
		{
		case 58:
		case 90:
		case 122:
			result = BitConverter.ToUInt16(byte_0, int_0 + 1);
			break;
		case 59:
		case 91:
		case 123:
			result = BitConverter.ToUInt16(byte_0, int_0 + 1);
			break;
		}
		return result;
	}

	internal static void smethod_5(byte[] byte_0, int int_0, int int_1, WorksheetCollection worksheetCollection_0, WorksheetCollection worksheetCollection_1, int int_2, Class1718 class1718_0, bool bool_0, Workbook workbook_0)
	{
		if (workbook_0.method_24())
		{
			Class1266.smethod_3(byte_0, int_0, int_1, worksheetCollection_0, worksheetCollection_1, int_2, class1718_0, bool_0);
		}
		else
		{
			Class1258.smethod_3(byte_0, int_0, int_1, worksheetCollection_0, worksheetCollection_1, int_2, class1718_0, bool_0);
		}
	}

	internal static byte[] smethod_6(byte[] byte_0, int int_0, int int_1, Worksheet worksheet_0)
	{
		if (worksheet_0.method_2().Workbook.method_24())
		{
			return Class1266.smethod_5(byte_0, int_0, int_1, worksheet_0);
		}
		return Class1258.smethod_5(byte_0, int_0, int_1, worksheet_0);
	}

	internal static void smethod_7(byte[] byte_0, int int_0, int int_1, Cell cell_0)
	{
		if (cell_0.method_4().method_19().Workbook.method_24())
		{
			Class1266.smethod_6(byte_0, int_0, int_1, cell_0);
		}
		else
		{
			Class1258.smethod_6(byte_0, int_0, int_1, cell_0);
		}
	}

	internal static void smethod_8(WorksheetCollection worksheetCollection_0, int int_0, int int_1, int int_2, int int_3, int int_4, int int_5, byte[] byte_0, int int_6, int int_7)
	{
		if (worksheetCollection_0.Workbook.method_24())
		{
			Class1266.smethod_7(int_0, int_1, int_2, int_3, int_4, int_5, byte_0, int_6, int_7);
		}
		else
		{
			Class1258.smethod_7(int_0, int_1, int_2, int_3, int_4, int_5, byte_0, int_6, int_7);
		}
	}

	internal static bool smethod_9(Hashtable hashtable_0, Hashtable hashtable_1, Worksheet worksheet_0, Worksheet worksheet_1, Hashtable hashtable_2, int int_0, int int_1, int int_2, byte[] byte_0)
	{
		if (worksheet_1.Workbook.method_24())
		{
			return Class1266.smethod_9(hashtable_0, hashtable_1, worksheet_0, worksheet_1, hashtable_2, int_0, int_1, int_2, byte_0);
		}
		return Class1258.smethod_8(hashtable_0, hashtable_1, worksheet_0, worksheet_1, hashtable_2, int_0, int_1, int_2, byte_0);
	}

	internal static void smethod_10(WorksheetCollection worksheetCollection_0, Hashtable hashtable_0, bool bool_0, int int_0, int int_1, int int_2, byte[] byte_0)
	{
		if (worksheetCollection_0.Workbook.method_24())
		{
			Class1266.smethod_8(hashtable_0, bool_0, int_0, int_1, int_2, byte_0);
		}
		else
		{
			Class1258.smethod_9(hashtable_0, bool_0, int_0, int_1, int_2, byte_0);
		}
	}

	internal static void InsertRows(Worksheet worksheet_0, bool bool_0, int int_0, int int_1, int int_2, int int_3, int int_4, int int_5, byte[] byte_0)
	{
		if (worksheet_0.method_2().Workbook.method_24())
		{
			Class1266.InsertRows(worksheet_0, bool_0, int_0, int_1, int_2, int_3, int_4, int_5, byte_0);
		}
		else
		{
			Class1258.InsertRows(worksheet_0, bool_0, int_0, int_1, int_2, int_3, int_4, int_5, byte_0);
		}
	}

	internal static void smethod_11(Worksheet worksheet_0, bool bool_0, int int_0, int int_1, int int_2, int int_3, int int_4, int int_5, byte[] byte_0)
	{
		if (worksheet_0.method_2().Workbook.method_24())
		{
			Class1266.smethod_10(worksheet_0, bool_0, int_0, int_1, int_2, int_3, int_4, int_5, ref byte_0);
		}
		else
		{
			Class1258.smethod_10(worksheet_0, bool_0, int_0, int_1, int_2, int_3, int_4, int_5, ref byte_0);
		}
	}

	internal static void InsertColumns(Worksheet worksheet_0, bool bool_0, int int_0, int int_1, int int_2, int int_3, int int_4, int int_5, byte[] byte_0)
	{
		if (worksheet_0.method_2().Workbook.method_24())
		{
			Class1266.InsertColumns(worksheet_0, bool_0, int_0, int_1, int_2, int_3, int_4, int_5, byte_0);
		}
		else
		{
			Class1258.InsertColumns(worksheet_0, bool_0, int_0, int_1, int_2, int_3, int_4, int_5, byte_0);
		}
	}

	internal static bool GetPrecedents(byte[] byte_0, int int_0, int int_1, int int_2, int int_3, WorksheetCollection worksheetCollection_0, Cells cells_0, ReferredAreaCollection referredAreaCollection_0, bool bool_0, string string_0, string string_1)
	{
		if (worksheetCollection_0.Workbook.method_24())
		{
			return Class1266.GetPrecedents(byte_0, int_0, int_1, int_2, int_3, worksheetCollection_0, cells_0, referredAreaCollection_0, bool_0, string_0, string_1);
		}
		return Class1258.GetPrecedents(byte_0, int_0, int_1, int_2, int_3, worksheetCollection_0, cells_0, referredAreaCollection_0, bool_0, string_0, string_1);
	}

	internal static bool GetDependents(int int_0, int int_1, byte[] byte_0, int int_2, int int_3, int int_4, int int_5, int int_6, Cells cells_0, bool bool_0, Hashtable hashtable_0)
	{
		if (cells_0.method_19().Workbook.method_24())
		{
			return Class1266.GetDependents(int_0, int_1, byte_0, int_2, int_3, int_4, int_5, int_6, cells_0, bool_0, hashtable_0);
		}
		return Class1258.GetDependents(int_0, int_1, byte_0, int_2, int_3, int_4, int_5, int_6, cells_0, bool_0, hashtable_0);
	}

	internal static bool smethod_12(byte[] byte_0, int int_0, int int_1, WorksheetCollection worksheetCollection_0)
	{
		if (worksheetCollection_0.Workbook.method_24())
		{
			return Class1266.smethod_11(byte_0, int_0, int_1, worksheetCollection_0);
		}
		return Class1258.smethod_11(byte_0, int_0, int_1, worksheetCollection_0);
	}

	internal static bool smethod_13(byte[] byte_0, int int_0, int int_1, WorksheetCollection worksheetCollection_0, Hashtable hashtable_0, Hashtable hashtable_1)
	{
		if (worksheetCollection_0.Workbook.method_24())
		{
			return Class1266.smethod_12(byte_0, int_0, int_1, worksheetCollection_0, hashtable_0, hashtable_1);
		}
		return Class1258.smethod_12(byte_0, int_0, int_1, worksheetCollection_0, hashtable_0, hashtable_1);
	}

	internal static bool smethod_14(byte[] byte_0, int int_0, int int_1, int int_2, WorksheetCollection worksheetCollection_0)
	{
		if (worksheetCollection_0.Workbook.method_24())
		{
			return Class1266.smethod_13(byte_0, int_0, int_1, int_2);
		}
		return Class1258.smethod_13(byte_0, int_0, int_1, int_2);
	}

	internal static void smethod_15(byte[] byte_0, int int_0, int int_1, bool[] bool_0, WorksheetCollection worksheetCollection_0)
	{
		if (worksheetCollection_0.Workbook.method_24())
		{
			Class1266.smethod_14(byte_0, int_0, int_1, bool_0);
		}
		else
		{
			Class1258.smethod_14(byte_0, int_0, int_1, bool_0);
		}
	}

	internal static void smethod_16(byte[] byte_0, int int_0, int int_1, SortedList sortedList_0, WorksheetCollection worksheetCollection_0)
	{
		if (worksheetCollection_0.Workbook.method_24())
		{
			Class1266.smethod_15(byte_0, int_0, int_1, sortedList_0);
		}
		else
		{
			Class1258.smethod_15(byte_0, int_0, int_1, sortedList_0);
		}
	}

	internal static ArrayList GetRanges(byte[] byte_0, int int_0, int int_1, WorksheetCollection worksheetCollection_0, Cells cells_0)
	{
		if (worksheetCollection_0.Workbook.method_24())
		{
			return Class1266.GetRanges(byte_0, int_0, int_1, worksheetCollection_0, cells_0);
		}
		return Class1258.GetRanges(byte_0, int_0, int_1, worksheetCollection_0, cells_0);
	}

	internal static void smethod_17(byte[] byte_0, int int_0, int int_1, Hashtable hashtable_0, WorksheetCollection worksheetCollection_0)
	{
		if (worksheetCollection_0.Workbook.method_24())
		{
			Class1266.smethod_16(byte_0, int_0, int_1, hashtable_0, worksheetCollection_0);
		}
		else
		{
			Class1258.smethod_16(byte_0, int_0, int_1, hashtable_0, worksheetCollection_0);
		}
	}

	internal static void smethod_18(byte[] byte_0, int int_0, int int_1, int int_2, int int_3, WorksheetCollection worksheetCollection_0)
	{
		if (worksheetCollection_0.Workbook.method_24())
		{
			Class1266.smethod_17(byte_0, int_0, int_1, int_2, int_3);
		}
		else
		{
			Class1258.smethod_18(byte_0, int_0, int_1, int_2, int_3);
		}
	}

	internal static void smethod_19(CellArea cellArea_0, int int_0, ShiftType shiftType_0, Worksheet worksheet_0, bool bool_0, byte[] byte_0, int int_1, int int_2, int int_3, int int_4, int int_5, int int_6)
	{
		switch (shiftType_0)
		{
		case ShiftType.Down:
			smethod_20(cellArea_0, int_0, worksheet_0, bool_0, byte_0, int_1, int_2);
			break;
		case ShiftType.Left:
			smethod_23(cellArea_0, int_0, worksheet_0, bool_0, byte_0, int_1, int_2);
			break;
		case ShiftType.None:
			break;
		case ShiftType.Right:
			smethod_22(cellArea_0, int_0, worksheet_0, bool_0, byte_0, int_1, int_2, int_3, int_4, int_5, int_6);
			break;
		case ShiftType.Up:
			smethod_21(cellArea_0, int_0, worksheet_0, bool_0, byte_0, int_1, int_2);
			break;
		}
	}

	internal static void smethod_20(CellArea cellArea_0, int int_0, Worksheet worksheet_0, bool bool_0, byte[] byte_0, int int_1, int int_2)
	{
		if (worksheet_0.method_2().Workbook.method_24())
		{
			Class1266.smethod_18(cellArea_0, int_0, worksheet_0, bool_0, byte_0, int_1, int_2);
		}
		else
		{
			Class1258.smethod_19(cellArea_0, int_0, worksheet_0, bool_0, byte_0, int_1, int_2);
		}
	}

	internal static void smethod_21(CellArea cellArea_0, int int_0, Worksheet worksheet_0, bool bool_0, byte[] byte_0, int int_1, int int_2)
	{
		if (worksheet_0.method_2().Workbook.method_24())
		{
			Class1266.smethod_19(cellArea_0, int_0, worksheet_0, bool_0, byte_0, int_1, int_2);
		}
		else
		{
			Class1258.smethod_20(cellArea_0, int_0, worksheet_0, bool_0, byte_0, int_1, int_2);
		}
	}

	internal static void smethod_22(CellArea cellArea_0, int int_0, Worksheet worksheet_0, bool bool_0, byte[] byte_0, int int_1, int int_2, int int_3, int int_4, int int_5, int int_6)
	{
		if (worksheet_0.method_2().Workbook.method_24())
		{
			Class1266.smethod_20(cellArea_0, int_0, worksheet_0, bool_0, byte_0, int_1, int_2, int_3, int_4, int_5, int_6);
		}
		else
		{
			Class1258.smethod_21(cellArea_0, int_0, worksheet_0, bool_0, byte_0, int_1, int_2, int_3, int_4, int_5, int_6);
		}
	}

	internal static void smethod_23(CellArea cellArea_0, int int_0, Worksheet worksheet_0, bool bool_0, byte[] byte_0, int int_1, int int_2)
	{
		if (worksheet_0.method_2().Workbook.method_24())
		{
			Class1266.smethod_23(cellArea_0, int_0, worksheet_0, bool_0, byte_0, int_1, int_2);
		}
		else
		{
			Class1258.smethod_24(cellArea_0, int_0, worksheet_0, bool_0, byte_0, int_1, int_2);
		}
	}

	internal static void MoveRange(CellArea cellArea_0, int int_0, int int_1, Worksheet worksheet_0, bool bool_0, byte[] byte_0, int int_2, int int_3)
	{
		if (worksheet_0.method_2().Workbook.method_24())
		{
			Class1266.MoveRange(cellArea_0, int_0, int_1, worksheet_0, bool_0, byte_0, int_2, int_3);
		}
		else
		{
			Class1258.MoveRange(cellArea_0, int_0, int_1, worksheet_0, bool_0, byte_0, int_2, int_3);
		}
	}

	internal static bool smethod_24(WorksheetCollection worksheetCollection_0, byte[] byte_0, int int_0, int int_1)
	{
		if (worksheetCollection_0.Workbook.method_24())
		{
			return Class1266.smethod_24(byte_0, int_0, int_1);
		}
		return Class1258.smethod_26(byte_0, int_0, int_1);
	}

	internal static void smethod_25(Worksheet worksheet_0, bool bool_0, int int_0, int int_1, bool bool_1, int int_2, int int_3, int int_4, byte[] byte_0)
	{
		if (worksheet_0.method_2().Workbook.method_24())
		{
			Class1266.smethod_25(worksheet_0, bool_0, int_0, int_1, bool_1, int_2, int_3, int_4, byte_0);
		}
		else
		{
			Class1258.smethod_27(worksheet_0, bool_0, int_0, int_1, bool_1, int_2, int_3, int_4, byte_0);
		}
	}
}
