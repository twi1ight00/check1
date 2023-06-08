using System;
using System.Collections;
using Aspose.Cells;
using Aspose.Cells.Pivot;
using ns16;
using ns45;

namespace ns10;

internal class Class441
{
	private Class1218 class1218_0;

	private Workbook workbook_0;

	private Class1547 class1547_0;

	private WorksheetCollection worksheetCollection_0;

	private Class1212 class1212_0;

	private PivotTable pivotTable_0;

	private int int_0;

	private byte[] byte_0;

	private int int_1;

	private ArrayList arrayList_0;

	private Class1548 class1548_0;

	private Worksheet worksheet_0;

	internal Class441(Class1218 class1218_1)
	{
		class1218_0 = class1218_1;
		workbook_0 = class1218_1.workbook_0;
		class1547_0 = class1218_1.class1547_0;
		arrayList_0 = new ArrayList();
	}

	internal void Read(Class1548 class1548_1, Class1212 class1212_1)
	{
		class1212_0 = class1212_1;
		class1548_0 = class1548_1;
		worksheet_0 = class1548_1.worksheet_0;
		worksheetCollection_0 = class1548_1.worksheet_0.method_2();
		pivotTable_0 = new PivotTable(worksheet_0.PivotTables);
		pivotTable_0.bool_1 = true;
		worksheet_0.PivotTables.method_5(pivotTable_0);
		while (true)
		{
			int_0 = class1212_0.method_0();
			switch (int_0)
			{
			case 513:
				method_11();
				break;
			case 309:
				method_4();
				break;
			case 311:
				method_5();
				break;
			case 314:
				method_1();
				break;
			default:
				int_1 = class1212_0.method_1();
				class1212_0.Seek(int_1);
				break;
			case 1062:
				method_14();
				break;
			case 601:
				method_12();
				break;
			case 558:
				method_20(pivotTable_0.PivotFormatConditions);
				break;
			case 285:
				method_2();
				break;
			case 280:
				method_0();
				break;
			case 299:
				method_8();
				break;
			case 301:
				method_10();
				break;
			case 303:
				method_19();
				break;
			case 293:
				method_7();
				break;
			case 289:
				method_6();
				break;
			case 315:
				class1212_0.Seek(1L);
				pivotTable_0.bool_1 = true;
				return;
			}
		}
	}

	private bool method_0()
	{
		byte_0 = class1218_0.method_0(class1212_0);
		int num = BitConverter.ToInt32(byte_0, 0);
		int num2 = BitConverter.ToInt32(byte_0, 4);
		int num3 = BitConverter.ToInt32(byte_0, 8);
		pivotTable_0.DisplayImmediateItems = ((((uint)((num & 0xF00) >> 8) & (true ? 1u : 0u)) != 0) ? true : false);
		pivotTable_0.bool_18 = ((((uint)((num & 0xF00) >> 8) & 2u) != 0) ? true : false);
		pivotTable_0.EnableFieldList = (((((num & 0xF00) >> 8) & 4) == 0) ? true : false);
		pivotTable_0.ShowDrill = (((((num & 0xF00000) >> 20) & 1) == 0) ? true : false);
		pivotTable_0.PrintDrill = ((((uint)((num & 0xF00000) >> 20) & 2u) != 0) ? true : false);
		pivotTable_0.bool_11 = ((((uint)((num & 0xF00000) >> 20) & 4u) != 0) ? true : false);
		pivotTable_0.ShowDataTips = (((((num & 0xF00000) >> 20) & 8) == 0) ? true : false);
		pivotTable_0.int_9 = (num & 0x7F000000) >> 24;
		pivotTable_0.ShowRowHeaderCaption = (((((num & 0x80000000u) >> 31) & 1) == 0) ? true : false);
		pivotTable_0.ShowEmptyRow = ((((uint)num2 & 0xFu & 4u) != 0) ? true : false);
		pivotTable_0.ShowEmptyCol = ((((uint)num2 & 0xFu & 8u) != 0) ? true : false);
		pivotTable_0.EnableWizard = ((((uint)((num2 & 0xF0) >> 4) & (true ? 1u : 0u)) != 0) ? true : false);
		pivotTable_0.EnableDrilldown = ((((uint)((num2 & 0xF0) >> 4) & 2u) != 0) ? true : false);
		pivotTable_0.EnableFieldDialog = ((((uint)((num2 & 0xF0) >> 4) & 4u) != 0) ? true : false);
		pivotTable_0.PreserveFormatting = ((((uint)((num2 & 0xF0) >> 4) & 8u) != 0) ? true : false);
		pivotTable_0.IsAutoFormat = ((((uint)((num2 & 0xF00) >> 8) & (true ? 1u : 0u)) != 0) ? true : false);
		pivotTable_0.DisplayErrorString = ((((uint)((num2 & 0xF00) >> 8) & 2u) != 0) ? true : false);
		pivotTable_0.DisplayNullString = ((((uint)((num2 & 0xF00) >> 8) & 4u) != 0) ? true : false);
		pivotTable_0.PageFieldOrder = ((((uint)((num2 & 0xF00) >> 8) & 8u) != 0) ? PrintOrderType.OverThenDown : PrintOrderType.DownThenOver);
		pivotTable_0.SubtotalHiddenPageItems = ((((uint)((num2 & 0xF000) >> 12) & (true ? 1u : 0u)) != 0) ? true : false);
		pivotTable_0.ColumnGrand = ((((uint)((num2 & 0xF000) >> 12) & 2u) != 0) ? true : false);
		pivotTable_0.RowGrand = ((((uint)((num2 & 0xF000) >> 12) & 4u) != 0) ? true : false);
		pivotTable_0.PrintTitles = ((((uint)((num2 & 0xF000) >> 12) & 8u) != 0) ? true : false);
		pivotTable_0.ItemPrintTitles = ((((uint)((num2 & 0xF0000) >> 16) & 2u) != 0) ? true : false);
		pivotTable_0.MergeLabels = ((((uint)((num2 & 0xF0000) >> 16) & 4u) != 0) ? true : false);
		bool flag = ((((uint)((num2 & 0xF0000) >> 16) & 8u) != 0) ? true : false);
		bool flag2 = ((((uint)((num2 & 0xF00000) >> 20) & (true ? 1u : 0u)) != 0) ? true : false);
		bool flag3 = ((((uint)((num2 & 0xF00000) >> 20) & 2u) != 0) ? true : false);
		bool flag4 = ((((uint)((num2 & 0xF00000) >> 20) & 4u) != 0) ? true : false);
		bool flag5 = ((((uint)((num2 & 0xF00000) >> 20) & 8u) != 0) ? true : false);
		bool flag6 = (((((num2 & 0xF0000000u) >> 28) & 4) != 0) ? true : false);
		pivotTable_0.bool_3 = (((num3 & 0xF & 1) == 0) ? true : false);
		pivotTable_0.bool_4 = (((num3 & 0xF & 8) == 0) ? true : false);
		pivotTable_0.bool_2 = (((((num3 & 0xF0) >> 4) & 1) == 0) ? true : false);
		bool flag7 = (((((num3 & 0xF0) >> 4) & 4) == 0) ? true : false);
		bool flag8 = (((((num3 & 0xF0) >> 4) & 8) == 0) ? true : false);
		bool flag9 = ((((uint)((num3 & 0xF00) >> 8) & 4u) != 0) ? true : false);
		bool flag10 = ((((uint)((num3 & 0xF00) >> 8) & 8u) != 0) ? true : false);
		pivotTable_0.IsMultipleFieldFilters = (((((num3 & 0xF00) >> 8) & 2) == 0) ? true : false);
		pivotTable_0.FieldListSortAscending = ((((uint)((num3 & 0x1000) >> 12) & (true ? 1u : 0u)) != 0) ? true : false);
		pivotTable_0.CustomListSort = (((num3 & 0x4000) >> 12 == 0) ? true : false);
		pivotTable_0.PageFieldWrapCount = byte_0[13];
		pivotTable_0.bool_5 = true;
		pivotTable_0.bool_6 = true;
		pivotTable_0.int_8 = byte_0[14];
		pivotTable_0.int_7 = byte_0[14];
		int num4 = BitConverter.ToInt16(byte_0, 20);
		pivotTable_0.AutoFormatType = Class1618.smethod_149(num4);
		pivotTable_0.int_11 = BitConverter.ToInt32(byte_0, 28);
		int num5 = 32;
		pivotTable_0.class1175_0.string_0 = Class1217.smethod_5(byte_0, ref num5);
		if (flag)
		{
			pivotTable_0.class1175_0.string_1 = Class1217.smethod_5(byte_0, ref num5);
		}
		if (flag2)
		{
			Class1217.smethod_5(byte_0, ref num5);
		}
		if (flag7)
		{
			pivotTable_0.ErrorString = Class1217.smethod_5(byte_0, ref num5);
		}
		if (flag8)
		{
			pivotTable_0.NullString = Class1217.smethod_5(byte_0, ref num5);
		}
		if (flag3)
		{
			Class1217.smethod_5(byte_0, ref num5);
		}
		if (flag4)
		{
			pivotTable_0.PivotTableStyleName = Class1217.smethod_5(byte_0, ref num5);
		}
		if (flag5)
		{
			Class1217.smethod_5(byte_0, ref num5);
		}
		if (flag6)
		{
			pivotTable_0.Tag = Class1217.smethod_5(byte_0, ref num5);
		}
		if (flag10)
		{
			pivotTable_0.ColumnHeaderCaption = Class1217.smethod_5(byte_0, ref num5);
		}
		if (flag9)
		{
			pivotTable_0.RowHeaderCaption = Class1217.smethod_5(byte_0, ref num5);
		}
		return true;
	}

	private void method_1()
	{
		byte_0 = class1218_0.method_0(class1212_0);
		pivotTable_0.int_0 = BitConverter.ToInt32(byte_0, 0);
		pivotTable_0.int_1 = BitConverter.ToInt32(byte_0, 4);
		pivotTable_0.int_2 = BitConverter.ToInt32(byte_0, 8);
		pivotTable_0.int_3 = BitConverter.ToInt32(byte_0, 12);
		pivotTable_0.int_4 = BitConverter.ToInt32(byte_0, 16);
		pivotTable_0.int_5 = BitConverter.ToInt32(byte_0, 20);
		pivotTable_0.int_6 = BitConverter.ToInt32(byte_0, 24);
	}

	private void method_2()
	{
		PivotField pivotField = new PivotField(pivotTable_0.BaseFields);
		pivotField.pivotTable_0 = pivotTable_0;
		pivotField.int_1 = pivotTable_0.BaseFields.Count;
		if (pivotTable_0.class1141_0 != null && pivotTable_0.class1141_0.arrayList_0 != null && pivotField.int_1 < pivotTable_0.class1141_0.arrayList_0.Count)
		{
			pivotField.class1161_0 = (Class1161)pivotTable_0.class1141_0.arrayList_0[pivotTable_0.BaseFields.Count];
		}
		pivotTable_0.BaseFields.method_4(pivotField);
		byte_0 = class1218_0.method_0(class1212_0);
		int num = byte_0[0] & 0xF;
		pivotField.method_5((byte_0[0] & 8) != 0);
		if (((uint)num & (true ? 1u : 0u)) != 0)
		{
			pivotField.pivotFieldType_0 = PivotFieldType.Row;
		}
		else if (((uint)num & 2u) != 0)
		{
			pivotField.pivotFieldType_0 = PivotFieldType.Column;
		}
		else if (((uint)num & 4u) != 0)
		{
			pivotField.pivotFieldType_0 = PivotFieldType.Page;
		}
		else if (((uint)num & 8u) != 0)
		{
			pivotField.pivotFieldType_0 = PivotFieldType.Data;
		}
		int num2 = BitConverter.ToInt32(byte_0, 4);
		pivotField.class1174_0.short_0 = (short)num2;
		pivotField.class1174_0.string_0 = worksheetCollection_0.method_46(pivotField.class1174_0.short_0);
		short num3 = BitConverter.ToInt16(byte_0, 1);
		if ((num3 & 1) == 0 && (!pivotField.method_4() || pivotField.pivotFieldType_0 != PivotFieldType.Data))
		{
			pivotField.SetSubtotals(PivotFieldSubtotalType.None, shown: true);
		}
		byte b = byte_0[3];
		pivotField.ShowCompact = (((b & 0x10u) != 0) ? true : false);
		pivotField.bool_2 = (((b & 0x80u) != 0) ? true : false);
		short num4 = BitConverter.ToInt16(byte_0, 8);
		pivotField.DragToRow = ((((uint)num4 & (true ? 1u : 0u)) != 0) ? true : false);
		pivotField.DragToColumn = ((((uint)num4 & 2u) != 0) ? true : false);
		pivotField.DragToPage = ((((uint)num4 & 4u) != 0) ? true : false);
		pivotField.DragToHide = ((((uint)num4 & 8u) != 0) ? true : false);
		pivotField.DragToData = ((((uint)num4 & 0x10u) != 0) ? true : false);
		pivotField.ShowAllItems = ((((uint)num4 & 0x20u) != 0) ? true : false);
		pivotField.ShowInOutlineForm = ((((uint)num4 & 0x40u) != 0) ? true : false);
		pivotField.InsertBlankRow = ((((uint)num4 & 0x80u) != 0) ? true : false);
		pivotField.ShowSubtotalAtTop = ((((uint)num4 & 0x100u) != 0) ? true : false);
		pivotField.IsInsertPageBreaksBetweenItems = ((((uint)num4 & 0x200u) != 0) ? true : false);
		pivotField.IsAutoSort = ((((uint)num4 & 0x1000u) != 0) ? true : false);
		pivotField.IsAscendSort = ((((uint)num4 & 0x2000u) != 0) ? true : false);
		pivotField.IsAutoShow = ((((uint)num4 & 0x4000u) != 0) ? true : false);
		pivotField.IsAscendShow = ((((uint)num4 & 0x8000u) != 0) ? true : false);
		short num5 = BitConverter.ToInt16(byte_0, 10);
		pivotField.IsIncludeNewItemsInFilter = (((num5 & 4) == 0) ? true : false);
		pivotField.IsMultipleItemSelectionAllowed = ((((uint)num5 & 8u) != 0) ? true : false);
		int num6 = 20;
		pivotField.DisplayName = Class1217.smethod_5(byte_0, ref num6);
		while (true)
		{
			int_0 = class1212_0.method_0();
			switch (int_0)
			{
			default:
				int_1 = class1212_0.method_1();
				class1212_0.Seek(int_1);
				break;
			case 1061:
				method_13(pivotField);
				break;
			case 459:
				byte_0 = class1218_0.method_0(class1212_0);
				pivotField.class1171_0 = new Class1171();
				method_21(pivotField.class1171_0);
				break;
			case 282:
				method_3(pivotField);
				break;
			case 286:
				class1212_0.Seek(1L);
				return;
			}
		}
	}

	private void method_3(PivotField pivotField_0)
	{
		byte_0 = class1218_0.method_0(class1212_0);
		byte b = byte_0[0];
		switch (b)
		{
		default:
			pivotField_0.SetSubtotals(Class1224.smethod_32(b), shown: true);
			break;
		case 1:
			return;
		case 0:
			break;
		}
		PivotItem pivotItem = new PivotItem(pivotField_0.PivotItems);
		pivotField_0.PivotItems.Add(pivotItem);
		short num = BitConverter.ToInt16(byte_0, 1);
		pivotItem.IsHidden = ((((uint)num & (true ? 1u : 0u)) != 0) ? true : false);
		pivotItem.method_1((((uint)num & 2u) != 0) ? true : false);
		pivotItem.method_2((((uint)num & 4u) != 0) ? true : false);
		pivotItem.method_4((((uint)num & 8u) != 0) ? true : false);
		pivotItem.bool_1 = ((((uint)num & 0x20u) != 0) ? true : false);
		pivotItem.bool_0 = ((((uint)num & 0x40u) != 0) ? true : false);
		pivotItem.Index = BitConverter.ToInt32(byte_0, 3);
		int num2 = 7;
		pivotItem.string_0 = Class1217.smethod_5(byte_0, ref num2);
	}

	private void method_4()
	{
		byte_0 = class1218_0.method_0(class1212_0);
		int num = BitConverter.ToInt32(byte_0, 0);
		PivotFieldCollection rowFields = pivotTable_0.RowFields;
		int num2 = 4;
		for (int i = 0; i < num; i++)
		{
			int num3 = BitConverter.ToInt32(byte_0, num2);
			if (num3 == -2)
			{
				pivotTable_0.pivotField_0 = new PivotField(pivotTable_0, pivotTable_0.DataFields);
				pivotTable_0.pivotField_0.int_1 = -2;
				pivotTable_0.pivotField_0.pivotFieldType_0 = PivotFieldType.Row;
				rowFields.method_4(pivotTable_0.DataField);
			}
			else
			{
				PivotField pivotField = pivotTable_0.BaseFields[num3];
				pivotField.int_1 = num3;
				rowFields.method_4(pivotField);
			}
			num2 += 4;
		}
	}

	private void method_5()
	{
		byte_0 = class1218_0.method_0(class1212_0);
		int num = BitConverter.ToInt32(byte_0, 0);
		PivotFieldCollection columnFields = pivotTable_0.ColumnFields;
		int num2 = 4;
		for (int i = 0; i < num; i++)
		{
			int num3 = BitConverter.ToInt32(byte_0, num2);
			if (num3 == -2)
			{
				pivotTable_0.pivotField_0 = new PivotField(pivotTable_0, pivotTable_0.DataFields);
				pivotTable_0.pivotField_0.int_1 = -2;
				pivotTable_0.pivotField_0.pivotFieldType_0 = PivotFieldType.Column;
				columnFields.method_4(pivotTable_0.DataField);
			}
			else
			{
				PivotField pivotField = pivotTable_0.BaseFields[num3];
				pivotField.int_1 = num3;
				columnFields.method_4(pivotField);
			}
			num2 += 4;
		}
	}

	private void method_6()
	{
		byte_0 = class1218_0.method_0(class1212_0);
		int index = BitConverter.ToInt32(byte_0, 0);
		PivotField pivotField = pivotTable_0.BaseFields[index];
		pivotTable_0.PageFields.method_4(pivotField);
		pivotField.class1159_0 = new Class1159();
		pivotField.class1170_0 = new Class1170(pivotField);
		pivotField.int_1 = index;
		int num = BitConverter.ToInt32(byte_0, 4);
		if (num != 1048830)
		{
			pivotField.class1170_0.short_0 = (short)num;
			pivotField.class1170_0.int_0 = pivotField.pivotItemCollection_0[num].Index;
		}
		pivotField.class1170_0.int_1 = BitConverter.ToInt32(byte_0, 8);
		byte b = byte_0[12];
		int num2 = 13;
		if ((b & 1) == 1)
		{
			pivotField.class1170_0.string_1 = Class1217.smethod_5(byte_0, ref num2);
		}
	}

	private void method_7()
	{
		byte_0 = class1218_0.method_0(class1212_0);
		PivotFieldCollection dataFields = pivotTable_0.DataFields;
		PivotField pivotField = new PivotField();
		pivotField.pivotFieldCollection_0 = dataFields;
		pivotField.Index = dataFields.Count;
		dataFields.method_4(pivotField);
		int index = BitConverter.ToInt32(byte_0, 0);
		pivotField.pivotField_0 = pivotTable_0.BaseFields[index];
		pivotField.method_5(bool_7: true);
		Class1159 @class = (pivotField.class1159_0 = new Class1159());
		@class.pivotField_0 = pivotField;
		switch (byte_0[4])
		{
		case 0:
			@class.consolidationFunction_0 = ConsolidationFunction.Sum;
			break;
		case 1:
			@class.consolidationFunction_0 = ConsolidationFunction.Count;
			break;
		case 2:
			@class.consolidationFunction_0 = ConsolidationFunction.Average;
			break;
		case 3:
			@class.consolidationFunction_0 = ConsolidationFunction.Max;
			break;
		case 4:
			@class.consolidationFunction_0 = ConsolidationFunction.Min;
			break;
		case 5:
			@class.consolidationFunction_0 = ConsolidationFunction.Product;
			break;
		case 6:
			@class.consolidationFunction_0 = ConsolidationFunction.CountNums;
			break;
		case 7:
			@class.consolidationFunction_0 = ConsolidationFunction.StdDev;
			break;
		case 8:
			@class.consolidationFunction_0 = ConsolidationFunction.StdDevp;
			break;
		case 9:
			@class.consolidationFunction_0 = ConsolidationFunction.Var;
			break;
		case 10:
			@class.consolidationFunction_0 = ConsolidationFunction.Varp;
			break;
		}
		@class.pivotFieldDataDisplayFormat_0 = (PivotFieldDataDisplayFormat)byte_0[8];
		@class.int_0 = BitConverter.ToInt32(byte_0, 12);
		@class.int_1 = BitConverter.ToInt32(byte_0, 16);
		@class.short_0 = (short)BitConverter.ToInt32(byte_0, 20);
		@class.string_0 = worksheetCollection_0.method_46(@class.short_0);
		int num = 25;
		if (byte_0[24] == 1)
		{
			@class.string_1 = Class1217.smethod_5(byte_0, ref num);
		}
		if (pivotTable_0.DataField != null)
		{
			PivotItem pivotItem = new PivotItem(pivotTable_0.pivotField_0.pivotItemCollection_0);
			pivotTable_0.pivotField_0.pivotItemCollection_0.Add(pivotItem);
			pivotItem.Index = pivotTable_0.DataFields.Count - 1;
			pivotItem.pivotField_0 = pivotField;
		}
	}

	private void method_8()
	{
		byte_0 = class1218_0.method_0(class1212_0);
		int capacity = BitConverter.ToInt32(byte_0, 0);
		ArrayList arrayList = null;
		int num = 0;
		arrayList = (pivotTable_0.arrayList_0 = new ArrayList(capacity));
		num = 4 + pivotTable_0.RowFields.Count;
		while (true)
		{
			int_0 = class1212_0.method_0();
			switch (int_0)
			{
			case 297:
			{
				int[] array = new int[num];
				for (int i = 4; i < num; i++)
				{
					array[i] = 32767;
				}
				arrayList.Add(array);
				if (pivotTable_0.DataField != null && pivotTable_0.DataField.pivotFieldType_0 == PivotFieldType.Row)
				{
					array[3] |= 4096;
				}
				byte_0 = class1218_0.method_0(class1212_0);
				short num2 = BitConverter.ToInt16(byte_0, 0);
				short num3 = (short)(array[1] = BitConverter.ToInt16(byte_0, 2));
				switch (num3)
				{
				case 13:
					array[3] |= 2560;
					if (pivotTable_0.BaseFields.method_1() > 1)
					{
						array[3] |= 1;
					}
					break;
				case 14:
					array[3] = 8192;
					break;
				case 1:
					array[3] |= 512;
					break;
				}
				if (num3 != 1)
				{
					for (int j = 4; j < num; j++)
					{
						array[j] = 0;
					}
				}
				array[0] = num2;
				if (num2 > 0)
				{
					ArrayList arrayList2 = null;
					int[] array2 = null;
					arrayList2 = pivotTable_0.arrayList_0;
					int count = arrayList2.Count;
					array2 = ((count <= 1) ? ((int[])arrayList2[count - 1]) : ((int[])arrayList2[count - 2]));
					for (int k = 0; k < num2; k++)
					{
						array[4 + k] = array2[4 + k];
					}
				}
				method_9(array, num2);
				break;
			}
			default:
				int_1 = class1212_0.method_1();
				class1212_0.Seek(int_1);
				break;
			case 300:
				class1212_0.Seek(1L);
				return;
			}
		}
	}

	private void method_9(int[] int_2, int int_3)
	{
		int num = 4;
		int num2 = 0;
		int num3 = int_2[0];
		while (true)
		{
			int_0 = class1212_0.method_0();
			switch (int_0)
			{
			default:
				int_1 = class1212_0.method_1();
				class1212_0.Seek(int_1);
				break;
			case 388:
			{
				byte_0 = class1218_0.method_0(class1212_0);
				int num4 = byte_0.Length / 4;
				int num5 = 0;
				for (int i = 0; i < num4; i++)
				{
					int_2[num + num3] = BitConverter.ToInt32(byte_0, num5);
					num5 += 4;
					num++;
					num2++;
				}
				break;
			}
			case 389:
				int_2[2] = num2 + num3;
				class1212_0.Seek(1L);
				return;
			case 298:
				class1212_0.Seek(1L);
				return;
			}
		}
	}

	private void method_10()
	{
		byte_0 = class1218_0.method_0(class1212_0);
		int capacity = BitConverter.ToInt32(byte_0, 0);
		ArrayList arrayList = null;
		int num = 0;
		arrayList = (pivotTable_0.arrayList_1 = new ArrayList(capacity));
		num = 4 + pivotTable_0.ColumnFields.Count;
		while (true)
		{
			int_0 = class1212_0.method_0();
			switch (int_0)
			{
			case 297:
			{
				int[] array = new int[num];
				for (int i = 4; i < num; i++)
				{
					array[i] = 32767;
				}
				arrayList.Add(array);
				if (pivotTable_0.DataField != null && pivotTable_0.DataField.pivotFieldType_0 == PivotFieldType.Column)
				{
					array[3] |= 4096;
				}
				byte_0 = class1218_0.method_0(class1212_0);
				short num2 = BitConverter.ToInt16(byte_0, 0);
				short num3 = BitConverter.ToInt16(byte_0, 2);
				int num4 = BitConverter.ToInt32(byte_0, 8);
				array[3] = (num4 << 1) | array[3];
				array[1] = num3;
				switch (num3)
				{
				case 13:
					array[3] |= 2560;
					if (pivotTable_0.BaseFields.method_1() > 1)
					{
						array[3] |= 1;
					}
					break;
				case 14:
					array[3] = 8192;
					break;
				case 1:
					array[3] |= 512;
					break;
				}
				if (num3 != 1)
				{
					for (int j = 4; j < num; j++)
					{
						array[j] = 0;
					}
				}
				array[0] = num2;
				if (num2 > 0)
				{
					ArrayList arrayList2 = null;
					int[] array2 = null;
					arrayList2 = pivotTable_0.arrayList_0;
					int count = arrayList2.Count;
					array2 = ((count <= 1) ? ((int[])arrayList2[count - 1]) : ((int[])arrayList2[count - 2]));
					for (int k = 0; k < num2; k++)
					{
						array[4 + k] = array2[4 + k];
					}
				}
				method_9(array, num2);
				break;
			}
			default:
				int_1 = class1212_0.method_1();
				class1212_0.Seek(int_1);
				break;
			case 302:
				class1212_0.Seek(1L);
				return;
			}
		}
	}

	private void method_11()
	{
		byte_0 = class1218_0.method_0(class1212_0);
		byte b = byte_0[0];
		pivotTable_0.ShowPivotStyleLastColumn = (((b & 2u) != 0) ? true : false);
		pivotTable_0.ShowPivotStyleRowStripes = (((b & 4u) != 0) ? true : false);
		pivotTable_0.ShowPivotStyleColumnStripes = (((b & 8u) != 0) ? true : false);
		pivotTable_0.ShowPivotStyleRowHeader = (((b & 0x10u) != 0) ? true : false);
		pivotTable_0.ShowPivotStyleColumnHeader = (((b & 0x20u) != 0) ? true : false);
		int num = 2;
		pivotTable_0.PivotTableStyleName = Class1217.smethod_5(byte_0, ref num);
	}

	private void method_12()
	{
		byte_0 = class1218_0.method_0(class1212_0);
		PivotFilter pivotFilter = new PivotFilter(worksheet_0);
		pivotTable_0.pivotFilterCollection_0.Add(pivotFilter);
		pivotFilter.int_0 = BitConverter.ToInt32(byte_0, 0);
		pivotFilter.int_4 = BitConverter.ToInt32(byte_0, 4);
		int num = BitConverter.ToInt32(byte_0, 8);
		pivotFilter.pivotFilterType_0 = Class1224.smethod_34(num);
		pivotFilter.int_3 = BitConverter.ToInt32(byte_0, 12);
		pivotFilter.int_1 = BitConverter.ToInt32(byte_0, 16);
		pivotFilter.int_2 = BitConverter.ToInt32(byte_0, 20);
		byte b = byte_0[28];
		bool flag = ((((uint)b & (true ? 1u : 0u)) != 0) ? true : false);
		bool flag2 = (((b & 4u) != 0) ? true : false);
		bool flag3 = (((b & 8u) != 0) ? true : false);
		int num2 = 30;
		if (flag)
		{
			pivotFilter.string_2 = Class1217.smethod_5(byte_0, ref num2);
		}
		if (flag2)
		{
			pivotFilter.string_0 = Class1217.smethod_5(byte_0, ref num2);
		}
		if (flag3)
		{
			pivotFilter.string_1 = Class1217.smethod_5(byte_0, ref num2);
		}
		while (true)
		{
			int_0 = class1212_0.method_0();
			switch (int_0)
			{
			case 161:
				method_15(pivotFilter.autoFilter_0);
				break;
			default:
				int_1 = class1212_0.method_1();
				class1212_0.Seek(int_1);
				break;
			case 602:
			{
				for (int i = 0; i < pivotFilter.autoFilter_0.method_5().Count; i++)
				{
					FilterColumn filterColumn = pivotFilter.autoFilter_0.method_5()[i];
					if (filterColumn.FilterType == FilterType.Top10)
					{
						PivotField pivotField = pivotTable_0.BaseFields[pivotFilter.int_0];
						pivotField.int_0 = ((Top10Filter)filterColumn.Filter).Items;
					}
				}
				class1212_0.Seek(1L);
				return;
			}
			}
		}
	}

	private void method_13(PivotField pivotField_0)
	{
		byte_0 = class1218_0.method_0(class1212_0);
		pivotField_0.IsRepeatItemLabels = ((((uint)byte_0[4] & (true ? 1u : 0u)) != 0) ? true : false);
	}

	private void method_14()
	{
		byte_0 = class1218_0.method_0(class1212_0);
		pivotTable_0.bool_13 = (((byte_0[4] & 0x10) == 0) ? true : false);
		pivotTable_0.EnableDataValueEditing = (((byte_0[4] & 4u) != 0) ? true : false);
		int num = 9;
		pivotTable_0.AltTextTitle = Class1217.smethod_5(byte_0, ref num);
		pivotTable_0.AltTextDescription = Class1217.smethod_5(byte_0, ref num);
	}

	private void method_15(AutoFilter autoFilter_0)
	{
		byte_0 = class1218_0.method_0(class1212_0);
		Name name = workbook_0.Worksheets.Names["_FILTERDATABASE", worksheet_0.Index];
		if (name != null)
		{
			autoFilter_0.method_3(name);
		}
		int row = BitConverter.ToInt32(byte_0, 0);
		BitConverter.ToInt32(byte_0, 4);
		int startColumn = BitConverter.ToInt32(byte_0, 8);
		int endColumn = BitConverter.ToInt32(byte_0, 12);
		autoFilter_0.SetRange(row, startColumn, endColumn);
		while (true)
		{
			int_0 = class1212_0.method_0();
			switch (int_0)
			{
			case 163:
				method_16(autoFilter_0);
				break;
			default:
				int_1 = class1212_0.method_1();
				class1212_0.Seek(int_1);
				break;
			case 162:
				class1212_0.Seek(1L);
				return;
			}
		}
	}

	private void method_16(AutoFilter autoFilter_0)
	{
		byte_0 = class1218_0.method_0(class1212_0);
		int num = BitConverter.ToInt32(byte_0, 0);
		bool bool_ = (byte_0[4] & 1) == 1;
		bool bool_2 = (((byte_0[4] & 2) == 0) ? true : false);
		FilterColumn filterColumn = null;
		while (true)
		{
			int_0 = class1212_0.method_0();
			switch (int_0)
			{
			case 172:
			{
				filterColumn = new FilterColumn(autoFilter_0.method_5(), num, bool_, bool_2);
				filterColumn.FilterType = FilterType.CustomFilters;
				CustomFilterCollection customFilterCollection_ = (CustomFilterCollection)(filterColumn.Filter = new CustomFilterCollection());
				method_17(customFilterCollection_);
				break;
			}
			case 171:
			{
				byte_0 = class1218_0.method_0(class1212_0);
				filterColumn = new FilterColumn(autoFilter_0.method_5(), num, bool_, bool_2);
				filterColumn.FilterType = FilterType.DynamicFilter;
				DynamicFilter dynamicFilter2 = (DynamicFilter)(filterColumn.Filter = new DynamicFilter());
				int num2 = BitConverter.ToInt32(byte_0, 0);
				dynamicFilter2.DynamicFilterType = Class1224.smethod_17(num2);
				bool flag = byte_0[4] == 1;
				double num3 = BitConverter.ToDouble(byte_0, 5);
				double num4 = BitConverter.ToDouble(byte_0, 13);
				if (flag)
				{
					dynamicFilter2.MaxValue = num4;
				}
				dynamicFilter2.Value = num3;
				break;
			}
			case 170:
			{
				byte_0 = class1218_0.method_0(class1212_0);
				filterColumn = new FilterColumn(autoFilter_0.method_5(), num, bool_, bool_2);
				filterColumn.FilterType = FilterType.Top10;
				bool bool_3 = ((((uint)byte_0[0] & (true ? 1u : 0u)) != 0) ? true : false);
				bool bool_4 = (((byte_0[0] & 2u) != 0) ? true : false);
				bool flag2 = (((byte_0[0] & 4u) != 0) ? true : false);
				double num6 = BitConverter.ToDouble(byte_0, 1);
				double num7 = BitConverter.ToDouble(byte_0, 9);
				int num8 = 10;
				if (flag2)
				{
					num8 = (int)num6;
				}
				Top10Filter top10Filter2 = (Top10Filter)(filterColumn.Filter = new Top10Filter(bool_3, bool_4, num8));
				try
				{
					top10Filter2.Criteria = num7;
				}
				catch
				{
				}
				break;
			}
			case 169:
			{
				byte_0 = class1218_0.method_0(class1212_0);
				int num5 = BitConverter.ToInt32(byte_0, 0);
				int iconId = BitConverter.ToInt32(byte_0, 4);
				filterColumn = new FilterColumn(autoFilter_0.method_5(), num, bool_, bool_2);
				filterColumn.FilterType = FilterType.IconFilter;
				IconFilter iconFilter2 = (IconFilter)(filterColumn.Filter = new IconFilter(filterColumn));
				iconFilter2.IconSetType = Class1224.smethod_14(num5);
				iconFilter2.IconId = iconId;
				break;
			}
			case 168:
			{
				byte_0 = class1218_0.method_0(class1212_0);
				filterColumn = new FilterColumn(autoFilter_0.method_5(), num, bool_, bool_2);
				filterColumn.FilterType = FilterType.ColorFilter;
				ColorFilter colorFilter2 = (ColorFilter)(filterColumn.Filter = new ColorFilter(filterColumn));
				colorFilter2.FilterByFillColor = byte_0[4] == 1;
				colorFilter2.method_2(BitConverter.ToInt32(byte_0, 0));
				break;
			}
			default:
				int_1 = class1212_0.method_1();
				class1212_0.Seek(int_1);
				break;
			case 165:
			{
				filterColumn = new FilterColumn(autoFilter_0.method_5(), num, bool_, bool_2);
				filterColumn.FilterType = FilterType.MultipleFilters;
				MultipleFilterCollection multipleFilterCollection_ = (MultipleFilterCollection)(filterColumn.Filter = new MultipleFilterCollection());
				method_18(multipleFilterCollection_);
				break;
			}
			case 164:
				class1212_0.Seek(1L);
				if (filterColumn != null)
				{
					autoFilter_0.method_5().method_0(filterColumn);
				}
				return;
			}
		}
	}

	private void method_17(CustomFilterCollection customFilterCollection_0)
	{
		byte_0 = class1218_0.method_0(class1212_0);
		bool and = byte_0[0] == 1;
		customFilterCollection_0.And = and;
		while (true)
		{
			int_0 = class1212_0.method_0();
			switch (int_0)
			{
			case 174:
			{
				byte_0 = class1218_0.method_0(class1212_0);
				byte b = byte_0[0];
				byte b2 = byte_0[1];
				CustomFilter customFilter = new CustomFilter();
				customFilterCollection_0.Add(customFilter);
				customFilter.FilterOperatorType = Class1224.smethod_19(b2);
				if (b == 6)
				{
					string criteria = Class1217.smethod_8(byte_0, 10);
					customFilter.Criteria = criteria;
				}
				else
				{
					customFilter.Criteria = BitConverter.ToDouble(byte_0, 2);
				}
				break;
			}
			case 173:
				class1212_0.Seek(1L);
				return;
			}
		}
	}

	private void method_18(MultipleFilterCollection multipleFilterCollection_0)
	{
		byte_0 = class1218_0.method_0(class1212_0);
		if (byte_0[0] == 1)
		{
			multipleFilterCollection_0.MatchBlank = true;
		}
		int num = BitConverter.ToInt32(byte_0, 4);
		multipleFilterCollection_0.string_0 = Class1224.smethod_16(num);
		while (true)
		{
			int_0 = class1212_0.method_0();
			switch (int_0)
			{
			case 167:
			{
				byte_0 = class1218_0.method_0(class1212_0);
				string string_ = Class1217.smethod_8(byte_0, 0);
				multipleFilterCollection_0.Add(string_);
				break;
			}
			default:
				int_1 = class1212_0.method_1();
				class1212_0.Seek(int_1);
				break;
			case 175:
			{
				byte_0 = class1218_0.method_0(class1212_0);
				DateTimeGroupItem dateTimeGroupItem = new DateTimeGroupItem();
				multipleFilterCollection_0.Add(dateTimeGroupItem);
				dateTimeGroupItem.Year = BitConverter.ToInt16(byte_0, 0);
				dateTimeGroupItem.Month = BitConverter.ToInt16(byte_0, 2);
				dateTimeGroupItem.Day = BitConverter.ToInt16(byte_0, 4);
				dateTimeGroupItem.Hour = BitConverter.ToInt16(byte_0, 6);
				dateTimeGroupItem.Minute = BitConverter.ToInt16(byte_0, 8);
				dateTimeGroupItem.Second = BitConverter.ToInt16(byte_0, 10);
				dateTimeGroupItem.DateTimeGroupingType = Class1224.smethod_21(BitConverter.ToInt32(byte_0, 20));
				break;
			}
			case 166:
				class1212_0.Seek(1L);
				return;
			}
		}
	}

	private void method_19()
	{
		byte_0 = class1218_0.method_0(class1212_0);
		Class1163 @class = new Class1163(pivotTable_0.class1164_0);
		pivotTable_0.class1164_0.Add(@class);
		@class.byte_0 = byte_0[0];
		@class.int_0 = BitConverter.ToInt32(byte_0, 2);
		method_21(@class.class1171_0);
	}

	private void method_20(PivotFormatConditionCollection pivotFormatConditionCollection_0)
	{
		byte_0 = class1218_0.method_0(class1212_0);
		int index = pivotFormatConditionCollection_0.method_0();
		PivotFormatCondition pivotFormatCondition = pivotFormatConditionCollection_0[index];
		pivotFormatCondition.pivotConditionFormatScopeType_0 = Class1224.smethod_35(BitConverter.ToInt32(byte_0, 0));
		pivotFormatCondition.int_0 = BitConverter.ToInt32(byte_0, 8);
		Class1171 @class = new Class1171();
		pivotFormatCondition.arrayList_0.Add(@class);
		method_21(@class);
	}

	private void method_21(Class1171 class1171_0)
	{
		Class1162 @class = null;
		while (true)
		{
			int_0 = class1212_0.method_0();
			switch (int_0)
			{
			case 251:
			{
				byte_0 = class1218_0.method_0(class1212_0);
				@class = new Class1162();
				class1171_0.arrayList_0.Add(@class);
				@class.method_2((ushort)BitConverter.ToInt32(byte_0, 0));
				int num = BitConverter.ToInt16(byte_0, 8);
				@class.bool_13 = ((((uint)num & (true ? 1u : 0u)) != 0) ? true : false);
				@class.bool_1 = ((((uint)num & 2u) != 0) ? true : false);
				@class.bool_2 = ((((uint)num & 4u) != 0) ? true : false);
				@class.bool_3 = ((((uint)num & 8u) != 0) ? true : false);
				@class.bool_4 = ((((uint)num & 0x10u) != 0) ? true : false);
				@class.bool_5 = ((((uint)num & 0x20u) != 0) ? true : false);
				@class.bool_6 = ((((uint)num & 0x40u) != 0) ? true : false);
				@class.bool_7 = ((((uint)num & 0x80u) != 0) ? true : false);
				@class.bool_8 = ((((uint)num & 0x100u) != 0) ? true : false);
				@class.bool_9 = ((((uint)num & 0x200u) != 0) ? true : false);
				@class.bool_10 = ((((uint)num & 0x400u) != 0) ? true : false);
				@class.bool_11 = ((((uint)num & 0x800u) != 0) ? true : false);
				@class.bool_12 = ((((uint)num & 0x1000u) != 0) ? true : false);
				@class.method_6((((uint)byte_0[10] & (true ? 1u : 0u)) != 0) ? true : false);
				break;
			}
			default:
				int_1 = class1212_0.method_1();
				class1212_0.Seek(int_1);
				break;
			case 247:
			{
				byte_0 = class1218_0.method_0(class1212_0);
				class1171_0.byte_1 = byte_0[0];
				int num2 = BitConverter.ToInt32(byte_0, 4);
				class1171_0.method_13(byte_0[4]);
				class1171_0.method_1((((uint)num2 & 0x100u) != 0) ? true : false);
				class1171_0.method_3((((uint)num2 & 0x200u) != 0) ? true : false);
				class1171_0.method_5((((uint)num2 & 0x400u) != 0) ? true : false);
				class1171_0.method_7((((uint)num2 & 0x800u) != 0) ? true : false);
				class1171_0.method_9((((uint)num2 & 0x1000u) != 0) ? true : false);
				class1171_0.method_15((((uint)num2 & 0x2000u) != 0) ? true : false);
				class1171_0.method_17((((uint)num2 & 0x4000u) != 0) ? true : false);
				class1171_0.method_11((byte)(byte_0[6] & 0xFu));
				class1171_0.byte_0 = (byte)((uint)((byte_0[6] & 0xF0) >> 4 + byte_0[7]) & 0xFu);
				break;
			}
			case 382:
				byte_0 = class1218_0.method_0(class1212_0);
				if (@class.arrayList_0 == null)
				{
					@class.arrayList_0 = new ArrayList();
				}
				@class.arrayList_0.Add(BitConverter.ToInt32(byte_0, 0));
				break;
			case 248:
				class1212_0.Seek(1L);
				return;
			}
		}
	}
}
