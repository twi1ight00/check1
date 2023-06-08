using System;
using System.Collections;
using Aspose.Cells;
using ns2;
using ns22;

namespace ns29;

internal class Class774
{
	public static bool smethod_0(ICellsDataTable icellsDataTable_0, int int_0, ImportTableOptions importTableOptions_0)
	{
		string[] columns = icellsDataTable_0.Columns;
		if (columns == null)
		{
			throw new CellsException(ExceptionType.InvalidData, "Columns must be defined for ICellsDataTable");
		}
		if (columns.Length == 0)
		{
			return false;
		}
		int num = importTableOptions_0.TotalColumns;
		if (importTableOptions_0.ColumnIndexes != null)
		{
			num = importTableOptions_0.ColumnIndexes.Length;
		}
		else if (num < 0)
		{
			num = columns.Length;
		}
		if (num == 0)
		{
			return false;
		}
		if (int_0 + num > 16383)
		{
			num = 16383 - int_0 + 1;
		}
		importTableOptions_0.TotalColumns = num;
		if (importTableOptions_0.ColumnIndexes == null)
		{
			importTableOptions_0.ColumnIndexes = new int[num];
			for (int i = 0; i < num; i++)
			{
				importTableOptions_0.ColumnIndexes[i] = i;
			}
		}
		else if (num < importTableOptions_0.ColumnIndexes.Length)
		{
			int[] array = new int[num];
			for (int j = 0; j < num; j++)
			{
				array[j] = importTableOptions_0.ColumnIndexes[j];
			}
			importTableOptions_0.ColumnIndexes = array;
		}
		return true;
	}

	internal static int ImportData(ICellsDataTable icellsDataTable_0, Cells cells_0, int int_0, int int_1, ImportTableOptions importTableOptions_0)
	{
		cells_0.Rows.method_7();
		cells_0.method_19().Workbook.method_3();
		Class1677.CheckCell(int_0, int_1);
		if (importTableOptions_0 == null)
		{
			importTableOptions_0 = new ImportTableOptions();
		}
		if (!smethod_0(icellsDataTable_0, int_1, importTableOptions_0))
		{
			return 0;
		}
		int[] columnIndexes = importTableOptions_0.ColumnIndexes;
		int num = importTableOptions_0.TotalRows;
		if (num < 0)
		{
			num = icellsDataTable_0.Count;
		}
		bool insertRows = importTableOptions_0.InsertRows;
		RowCollection rowCollection;
		if (num > -1)
		{
			if (importTableOptions_0.IsFieldNameShown)
			{
				num++;
			}
			if (int_0 + num > 1048575)
			{
				num = 1048575 - int_0 + 1;
			}
			rowCollection = new RowCollection(cells_0, cells_0.double_0, num);
		}
		else
		{
			num = 1048575 - int_0 + 1;
			rowCollection = new RowCollection(cells_0, cells_0.double_0, 64);
		}
		Row row = null;
		int num2 = 0;
		object obj = null;
		Hashtable hashtable_ = new Hashtable();
		object obj2 = null;
		bool flag = false;
		int totalColumns = importTableOptions_0.TotalColumns;
		if (insertRows)
		{
			row = cells_0.Rows.GetRow(int_0, bool_0: true, bool_1: false);
			int[][] array = null;
			int[][] array2 = null;
			int num3 = 0;
			Hashtable hashtable = new Hashtable();
			int num4 = int_1 + totalColumns - 1;
			if (row != null)
			{
				ArrayList arrayList = new ArrayList();
				ArrayList arrayList2 = new ArrayList();
				for (int i = 0; i < row.method_0(); i++)
				{
					Cell cellByIndex = row.GetCellByIndex(i);
					if (cellByIndex.Column < int_1)
					{
						arrayList.Add(new int[2] { cellByIndex.Column, cellByIndex.int_1 });
					}
					else if (cellByIndex.Column > num4)
					{
						arrayList2.Add(new int[2] { cellByIndex.Column, cellByIndex.int_1 });
					}
					else
					{
						hashtable[cellByIndex.Column] = cellByIndex.int_1;
					}
				}
				if (arrayList.Count > 0)
				{
					array = new int[arrayList.Count][];
					for (int j = 0; j < arrayList.Count; j++)
					{
						array[j] = (int[])arrayList[j];
					}
					num3 += arrayList.Count;
				}
				if (arrayList2.Count > 0)
				{
					array2 = new int[arrayList2.Count][];
					for (int k = 0; k < arrayList2.Count; k++)
					{
						array2[k] = (int[])arrayList2[k];
					}
					num3 += arrayList2.Count;
				}
			}
			Row row2 = row;
			int num5 = int_0;
			num2 = 0;
			if (importTableOptions_0.IsFieldNameShown)
			{
				row = rowCollection.method_1(int_0, totalColumns + num3);
				if (row2 != null)
				{
					row.CopyData(row2);
				}
				if (array != null)
				{
					for (int l = 0; l < array.Length; l++)
					{
						Cell cell = row.method_5(array[l][0]);
						cell.int_1 = array[l][1];
					}
				}
				string[] columns = icellsDataTable_0.Columns;
				for (int m = 0; m < columnIndexes.Length; m++)
				{
					Cell cell = row.GetCell(int_1 + m, bool_1: false, bool_2: false);
					object obj3 = hashtable[int_1 + m];
					if (obj3 != null)
					{
						cell.int_1 = (int)obj3;
					}
					cell.PutValue(columns[columnIndexes[m]]);
				}
				if (array2 != null)
				{
					for (int n = 0; n < array2.Length; n++)
					{
						Cell cell = row.method_5(array2[n][0]);
						cell.int_1 = array2[n][1];
					}
				}
				num2++;
				num5++;
			}
			while (icellsDataTable_0.Next())
			{
				if (num != -1)
				{
					if (num2 >= num)
					{
						break;
					}
				}
				else if (num5 > 1048575)
				{
					break;
				}
				num2++;
				row = rowCollection.method_1(num5, totalColumns + num3);
				if (row2 != null)
				{
					row.CopyData(row2);
				}
				if (array != null)
				{
					for (int num6 = 0; num6 < array.Length; num6++)
					{
						Cell cell = row.method_5(array[num6][0]);
						cell.int_1 = array[num6][1];
					}
				}
				for (int num7 = 0; num7 < totalColumns; num7++)
				{
					obj2 = icellsDataTable_0[columnIndexes[num7]];
					flag = smethod_1(obj2);
					object obj4 = hashtable[int_1 + num7];
					obj = importTableOptions_0.method_0(num7);
					if (!flag || obj4 != null || obj != null)
					{
						Cell cell = row.method_5(int_1 + num7);
						if (obj4 != null)
						{
							cell.int_1 = (int)obj4;
						}
						smethod_2(cell, obj2, flag, obj, importTableOptions_0, num7, hashtable_);
					}
				}
				if (array2 != null)
				{
					for (int num8 = 0; num8 < array2.Length; num8++)
					{
						Cell cell = row.method_5(array2[num8][0]);
						cell.int_1 = array2[num8][1];
					}
				}
				num5++;
			}
			if (rowCollection.Count > 0)
			{
				Class739 @class = new Class739();
				@class.bool_1 = false;
				@class.bool_0 = false;
				cells_0.method_31(int_0, rowCollection.Count, @class);
				cells_0.Rows.method_16(-1, -1, 0, rowCollection);
			}
		}
		else
		{
			int num9 = 0;
			if (importTableOptions_0.IsFieldNameShown)
			{
				string[] columns2 = icellsDataTable_0.Columns;
				row = cells_0.Rows.GetRow(int_0, bool_0: false, bool_1: false);
				for (int num10 = 0; num10 < columnIndexes.Length; num10++)
				{
					Cell cell = row.GetCell(int_1 + num10, bool_1: false, bool_2: true);
					cell.PutValue(columns2[columnIndexes[num10]]);
				}
				int_0++;
				num2 = 1;
			}
			int num11 = int_0;
			cells_0.Rows.method_15(num11, out var arrIndex);
			int int_2 = arrIndex;
			bool flag2 = false;
			while (icellsDataTable_0.Next())
			{
				if (num != -1)
				{
					if (num2 >= num)
					{
						break;
					}
				}
				else if (num11 > 1048575)
				{
					break;
				}
				num2++;
				flag2 = false;
				if (arrIndex != -1 && arrIndex < cells_0.Rows.Count)
				{
					row = cells_0.Rows.GetRowByIndex(arrIndex);
					if (row.int_0 == num11)
					{
						num9 += row.method_0();
						arrIndex++;
						row = rowCollection.method_2(row);
					}
					else
					{
						row = rowCollection.method_1(num11, totalColumns);
						flag2 = true;
					}
				}
				else
				{
					row = rowCollection.method_1(num11, totalColumns);
					flag2 = true;
				}
				if (flag2)
				{
					for (int num12 = 0; num12 < totalColumns; num12++)
					{
						obj2 = icellsDataTable_0[columnIndexes[num12]];
						flag = smethod_1(obj2);
						obj = importTableOptions_0.method_0(num12);
						if (!flag || obj != null)
						{
							Cell cell = row.method_5(int_1 + num12);
							smethod_2(cell, obj2, flag, obj, importTableOptions_0, num12, hashtable_);
						}
					}
				}
				else
				{
					for (int num13 = 0; num13 < totalColumns; num13++)
					{
						obj2 = icellsDataTable_0[columnIndexes[num13]];
						flag = smethod_1(obj2);
						obj = importTableOptions_0.method_0(num13);
						Cell cell = row.GetCell(int_1 + num13, flag && obj == null, bool_2: false);
						smethod_2(cell, obj2, flag, obj, importTableOptions_0, num13, hashtable_);
					}
				}
				num11++;
			}
			if (rowCollection.Count > 0)
			{
				cells_0.Rows.method_16(int_2, arrIndex - 1, num9, rowCollection);
			}
		}
		return num2;
	}

	internal static bool smethod_1(object object_0)
	{
		if (object_0 == null)
		{
			return true;
		}
		switch (Type.GetTypeCode(object_0.GetType()))
		{
		default:
			return false;
		case TypeCode.Empty:
		case TypeCode.DBNull:
			return true;
		}
	}

	internal static void smethod_2(Cell cell_0, object object_0, bool bool_0, object object_1, ImportTableOptions importTableOptions_0, int int_0, Hashtable hashtable_0)
	{
		if (cell_0 == null)
		{
			return;
		}
		if (bool_0)
		{
			cell_0.PutValue(object_1);
		}
		else if (importTableOptions_0.ConvertNumericData)
		{
			if (object_0 is string)
			{
				cell_0.PutValue((string)object_0, isConverted: true);
			}
			else
			{
				cell_0.PutValue(object_0);
			}
		}
		else
		{
			cell_0.PutValue(object_0);
		}
		if (importTableOptions_0.NumberFormats != null && int_0 < importTableOptions_0.NumberFormats.Length && importTableOptions_0.NumberFormats[int_0] != null && importTableOptions_0.NumberFormats[int_0] != "")
		{
			Style style = cell_0.method_28();
			style.Custom = importTableOptions_0.NumberFormats[int_0];
			cell_0.method_30(style);
		}
		else
		{
			if (!Class1180.smethod_0(object_0))
			{
				return;
			}
			if (importTableOptions_0.DateFormat != null && importTableOptions_0.DateFormat != "")
			{
				Style style2 = cell_0.method_28();
				style2.Custom = importTableOptions_0.DateFormat;
				cell_0.method_30(style2);
				return;
			}
			int num = cell_0.method_35();
			bool flag = false;
			if (hashtable_0[num] != null)
			{
				flag = (bool)hashtable_0[num];
			}
			else
			{
				Style style3 = null;
				WorksheetCollection worksheetCollection = cell_0.method_4().method_19();
				style3 = ((num < 0 || num > worksheetCollection.method_58().Count) ? worksheetCollection.method_58()[15] : worksheetCollection.method_58()[num]);
				flag = style3.Number != 0 || (style3.Custom != null && style3.Custom != "");
				hashtable_0[num] = flag;
			}
			if (!flag)
			{
				Style style4 = cell_0.method_28();
				style4.Number = 14;
				cell_0.method_30(style4);
			}
		}
	}
}
