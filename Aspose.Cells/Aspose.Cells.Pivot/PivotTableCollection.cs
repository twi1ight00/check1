using System;
using System.Collections;
using ns2;
using ns45;

namespace Aspose.Cells.Pivot;

/// <summary>
///       Represents the collection of all the PivotTable objects on the specified worksheet.
///       </summary>
public class PivotTableCollection : CollectionBase
{
	internal Worksheet worksheet_0;

	/// <summary>
	///       Gets the PivotTable report by index.
	///       </summary>
	public PivotTable this[int index] => (PivotTable)base.InnerList[index];

	/// <summary>
	///       Gets the PivotTable report by pivottable's name.
	///       </summary>
	public PivotTable this[string name]
	{
		get
		{
			int num = 0;
			PivotTable pivotTable;
			while (true)
			{
				if (num < base.Count)
				{
					pivotTable = (PivotTable)base.InnerList[num];
					if (pivotTable.Name != null && pivotTable.Name.ToUpper().Equals(name.ToUpper()))
					{
						break;
					}
					num++;
					continue;
				}
				return null;
			}
			return pivotTable;
		}
	}

	/// <summary>
	///       Gets the PivotTable report by pivottable's position.
	///       </summary>
	public PivotTable this[int row, int column]
	{
		get
		{
			int num = 0;
			PivotTable pivotTable;
			while (true)
			{
				if (num < base.Count)
				{
					pivotTable = (PivotTable)base.InnerList[num];
					if (row >= pivotTable.int_0 && row <= pivotTable.int_1 && column >= pivotTable.int_2 && column <= pivotTable.int_3)
					{
						break;
					}
					num++;
					continue;
				}
				return null;
			}
			return pivotTable;
		}
	}

	internal PivotTableCollection(Worksheet worksheet_1)
	{
		worksheet_0 = worksheet_1;
	}

	internal void Copy(PivotTableCollection pivotTableCollection_0)
	{
		for (int i = 0; i < pivotTableCollection_0.Count; i++)
		{
			PivotTable pivotTable = new PivotTable(this);
			pivotTable.Copy(pivotTableCollection_0[i]);
			base.InnerList.Add(pivotTable);
		}
	}

	internal void InsertRange(CellArea cellArea_0, int int_0, ShiftType shiftType_0)
	{
		for (int i = 0; i < base.Count; i++)
		{
			if (this[i].InsertRange(cellArea_0, int_0, shiftType_0))
			{
				RemoveAt(i--);
			}
		}
	}

	internal void InsertRows(int int_0, int int_1)
	{
		for (int i = 0; i < base.Count; i++)
		{
			PivotTable pivotTable = this[i];
			if (pivotTable.InsertRows(int_0, int_1))
			{
				RemoveAt(i);
				if (!method_0(pivotTable.class1141_0))
				{
					method_4(pivotTable.class1141_0);
				}
			}
		}
	}

	internal bool method_0(Class1141 class1141_0)
	{
		int num = 0;
		while (true)
		{
			if (num < base.Count)
			{
				PivotTable pivotTable = this[num];
				if (pivotTable.class1141_0 == class1141_0)
				{
					break;
				}
				num++;
				continue;
			}
			return false;
		}
		return true;
	}

	internal object method_1(int int_0, int int_1, string string_0, object[] object_0)
	{
		ArrayList arrayList = new ArrayList();
		ArrayList arrayList2 = new ArrayList();
		Hashtable hashtable = new Hashtable();
		Hashtable hashtable2 = new Hashtable();
		bool flag = false;
		Cell cell = null;
		int num = -1;
		for (int i = 0; i < base.Count; i++)
		{
			PivotTable pivotTable = this[i];
			if (int_0 < pivotTable.int_0 || int_0 > pivotTable.int_1 || int_1 < pivotTable.int_2 || int_1 > pivotTable.int_3)
			{
				continue;
			}
			PivotFieldCollection dataFields = pivotTable.DataFields;
			for (int j = 0; j < dataFields.Count; j++)
			{
				PivotField pivotField = dataFields[j];
				if (pivotField.DisplayName == null || !pivotField.DisplayName.ToUpper().EndsWith(string_0.ToUpper()))
				{
					continue;
				}
				if (pivotTable.DataField != null && pivotTable.DataField.pivotFieldType_0 == PivotFieldType.Column)
				{
					flag = true;
					int num2 = pivotTable.method_6(pivotField);
					hashtable.Add(num2 + pivotTable.int_6, num2 + pivotTable.int_6);
				}
				if (object_0.Length > 0)
				{
					int num3 = 0;
					while (true)
					{
						if (num3 < object_0.Length)
						{
							string string_ = object_0[num3].ToString();
							object object_ = object_0[num3 + 1];
							object obj = pivotTable.BaseFields.method_8(string_);
							if (obj == null)
							{
								break;
							}
							PivotField pivotField2 = (PivotField)obj;
							if (pivotField2.pivotFieldType_0 == PivotFieldType.Column)
							{
								arrayList = pivotTable.method_7(object_, bool_23: true);
								if (arrayList.Count == 0)
								{
									return ErrorType.Ref;
								}
								int num4 = pivotTable.method_6(pivotField2);
								for (int k = 0; k < arrayList.Count; k++)
								{
									int[] array = (int[])arrayList[k];
									if (array[0] != num4)
									{
										continue;
									}
									if (hashtable.Contains(array[1]))
									{
										if (flag)
										{
											break;
										}
										continue;
									}
									if (hashtable.Count == 0)
									{
										hashtable.Add(array[1], array[1]);
										continue;
									}
									return ErrorType.Ref;
								}
							}
							else
							{
								if (pivotField2.pivotFieldType_0 != PivotFieldType.Row)
								{
									return ErrorType.Ref;
								}
								num++;
								arrayList = pivotTable.method_7(object_, bool_23: false);
								if (arrayList.Count == 0)
								{
									return ErrorType.Ref;
								}
								int num5 = pivotTable.method_6(pivotField2);
								int num6 = -1;
								int num7 = num5;
								for (int num8 = num5 - 1; num8 >= 0; num8--)
								{
									if (pivotTable.RowFields[num8].ShowInOutlineForm)
									{
										num7--;
									}
								}
								num7 += pivotTable.int_2;
								ArrayList arrayList_ = new ArrayList();
								if (num5 > 0)
								{
									if (pivotTable.RowFields[num5 - 1].ShowInOutlineForm)
									{
										arrayList_ = pivotTable.method_5(num5);
									}
									else
									{
										num6 = num5;
										for (int num9 = num5 - 1; num9 >= 0; num9--)
										{
											if (pivotTable.RowFields[num9].ShowInOutlineForm)
											{
												num6--;
											}
										}
									}
								}
								else if (pivotTable.RowFields[0].ShowInOutlineForm)
								{
									arrayList_ = pivotTable.method_5(num5);
								}
								else
								{
									num6 = 0;
								}
								if (num6 >= 0)
								{
									num6 += pivotTable.int_2;
									arrayList2 = method_3(arrayList, num6, num5);
								}
								else
								{
									arrayList2 = method_2(arrayList, arrayList_, num5, num7);
								}
								if (hashtable2.Count == 0 && num == 0)
								{
									for (int l = 0; l < arrayList2.Count; l++)
									{
										if (!hashtable2.Contains(((int[])arrayList2[l])[0]))
										{
											hashtable2.Add(((int[])arrayList2[l])[0], ((int[])arrayList2[l])[1]);
										}
									}
								}
								else
								{
									Hashtable hashtable3 = (Hashtable)hashtable2.Clone();
									for (int m = 0; m < arrayList2.Count; m++)
									{
										int num10 = ((int[])arrayList2[m])[0];
										int num11 = ((int[])arrayList2[m])[1];
										IDictionaryEnumerator enumerator = hashtable3.GetEnumerator();
										while (enumerator.MoveNext())
										{
											int num12 = (int)enumerator.Key;
											int num13 = (int)enumerator.Value;
											int num14 = Math.Min(num13, num11);
											if (((int[])pivotTable.arrayList_0[num10 - pivotTable.int_5])[4 + num14] != ((int[])pivotTable.arrayList_0[num12 - pivotTable.int_5])[4 + num14])
											{
												if (num14 == 0 || ((int[])pivotTable.arrayList_0[num10 - pivotTable.int_5])[4] == ((int[])pivotTable.arrayList_0[num12 - pivotTable.int_5])[4])
												{
													hashtable2.Remove(num12);
												}
											}
											else if (num13 < num11)
											{
												hashtable2.Remove(num12);
												hashtable2.Add(num10, num11);
											}
										}
									}
								}
							}
							num3 += 2;
							continue;
						}
						if (hashtable.Count == 0)
						{
							if (hashtable2.Count != 0 && hashtable2.Count <= 1)
							{
								int num15 = -1;
								foreach (int key in hashtable2.Keys)
								{
									num15 = key;
								}
								int num17 = ((int[])pivotTable.arrayList_0[num15 - pivotTable.int_5])[0];
								if ((!pivotTable.RowFields[num17].ShowSubtotalAtTop || !pivotTable.RowFields[num17].ShowInOutlineForm) && num17 != pivotTable.RowFields.Count - 1)
								{
									num15 = pivotTable.method_9(num15, num17);
								}
								cell = worksheet_0.Cells[num15, pivotTable.int_3];
								return cell.method_59();
							}
							return ErrorType.Ref;
						}
						int column = -1;
						foreach (int key2 in hashtable.Keys)
						{
							column = key2;
						}
						if (hashtable2.Count == 0)
						{
							int num19 = pivotTable.method_8(pivotTable.method_6(pivotField));
							cell = worksheet_0.Cells[num19 + pivotTable.int_5, column];
							return cell.method_59();
						}
						if (hashtable2.Count > 1)
						{
							return ErrorType.Ref;
						}
						int num20 = -1;
						int num21 = -1;
						foreach (int key3 in hashtable2.Keys)
						{
							num20 = key3;
							num21 = (int)hashtable2[key3];
						}
						if ((!pivotTable.RowFields[num21].ShowSubtotalAtTop || !pivotTable.RowFields[num21].ShowInOutlineForm) && num21 != pivotTable.RowFields.Count - 1)
						{
							num20 = pivotTable.method_9(num20, num21);
						}
						cell = worksheet_0.Cells[num20, column];
						return cell.method_59();
					}
					return ErrorType.Ref;
				}
				int column2 = -1;
				foreach (int key4 in hashtable.Keys)
				{
					column2 = key4;
				}
				cell = ((hashtable.Count == 0) ? worksheet_0.Cells[pivotTable.int_1, pivotTable.int_3] : worksheet_0.Cells[pivotTable.int_1, column2]);
				return cell.method_59();
			}
		}
		return ErrorType.Ref;
	}

	internal ArrayList method_2(ArrayList arrayList_0, ArrayList arrayList_1, int int_0, int int_1)
	{
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < arrayList_0.Count; i++)
		{
			for (int j = 0; j < arrayList_1.Count; j++)
			{
				if (((int[])arrayList_0[i])[0] == (int)arrayList_1[j] && ((int[])arrayList_0[i])[1] == int_1)
				{
					arrayList.Add(new int[2]
					{
						(int)arrayList_1[j],
						int_0
					});
				}
			}
		}
		return arrayList;
	}

	internal ArrayList method_3(ArrayList arrayList_0, int int_0, int int_1)
	{
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < arrayList_0.Count; i++)
		{
			if (((int[])arrayList_0[i])[1] == int_0)
			{
				arrayList.Add(new int[2]
				{
					((int[])arrayList_0[i])[0],
					int_1
				});
			}
		}
		return arrayList;
	}

	internal void method_4(Class1141 class1141_0)
	{
		if (worksheet_0.Workbook.Worksheets.method_89() == null || worksheet_0.Workbook.Worksheets.method_89().Count == 0)
		{
			return;
		}
		int count = worksheet_0.Workbook.Worksheets.method_89().Count;
		for (int i = 0; i < count; i++)
		{
			Class1141 @class = worksheet_0.Workbook.Worksheets.method_89()[i];
			if (class1141_0 == @class)
			{
				worksheet_0.Workbook.Worksheets.method_89().RemoveAt(i);
			}
		}
	}

	internal ArrayList GetRanges()
	{
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < base.Count; i++)
		{
			PivotTable pivotTable = this[i];
			CellArea cellArea = default(CellArea);
			cellArea.StartRow = pivotTable.int_0;
			cellArea.EndRow = pivotTable.int_1;
			cellArea.StartColumn = pivotTable.int_2;
			cellArea.EndColumn = pivotTable.int_3;
			arrayList.Add(cellArea);
		}
		return arrayList;
	}

	/// <summary>
	///       Adds a new PivotTable cache to a PivotCaches collection.
	///       </summary>
	/// <param name="sourceData">The data for the new PivotTable cache.</param>
	/// <param name="destCellName">The cell in the upper-left corner of the PivotTable report's destination range.</param>
	/// <param name="tableName">The name of the new PivotTable report.</param>
	/// <returns>The new added cache index.</returns>
	public int Add(string sourceData, string destCellName, string tableName)
	{
		int row = 0;
		int column = 0;
		CellsHelper.CellNameToIndex(destCellName, out row, out column);
		return Add(sourceData, row, column, tableName);
	}

	/// <summary>
	///       Adds a new PivotTable cache to a PivotCaches collection.
	///       </summary>
	/// <param name="sourceData">The data for the new PivotTable cache.</param>
	/// <param name="destCellName">The cell in the upper-left corner of the PivotTable report's destination range.</param>
	/// <param name="tableName">The name of the new PivotTable report.</param>
	/// <param name="useSameSource">Indicates whether using same data source when another existing pivot table has used this data source.
	///       If the property is true, it will save memory.</param>
	/// <returns>The new added cache index.</returns>
	public int Add(string sourceData, string destCellName, string tableName, bool useSameSource)
	{
		int row = 0;
		int column = 0;
		CellsHelper.CellNameToIndex(destCellName, out row, out column);
		return Add(sourceData, row, column, tableName, useSameSource);
	}

	/// <summary>
	///       Adds a new PivotTable cache to a PivotCaches collection.
	///       </summary>
	/// <param name="sourceData">The data cell range for the new PivotTable.Example : Sheet1!A1:C8</param>
	/// <param name="row">Row index of the cell in the upper-left corner of the PivotTable report's destination range.</param>
	/// <param name="column">Column index of the cell in the upper-left corner of the PivotTable report's destination range.</param>
	/// <param name="tableName">The name of the new PivotTable report.</param>
	/// <returns>The new added cache index.</returns>
	public int Add(string sourceData, int row, int column, string tableName)
	{
		Class1142 @class = worksheet_0.method_2().method_89();
		int int_ = @class.Add(sourceData, worksheet_0, bool_0: true);
		return Add(@class[int_], row, column, tableName);
	}

	/// <summary>
	///       Adds a new PivotTable cache to a PivotCaches collection.
	///       </summary>
	/// <param name="sourceData">The data cell range for the new PivotTable.Example : Sheet1!A1:C8</param>
	/// <param name="row">Row index of the cell in the upper-left corner of the PivotTable report's destination range.</param>
	/// <param name="column">Column index of the cell in the upper-left corner of the PivotTable report's destination range.</param>
	/// <param name="tableName">The name of the new PivotTable report.</param>
	/// <param name="useSameSource">Indicates whether using same data source when another existing pivot table has used this data source.
	///       If the property is true, it will save memory.</param>
	/// <returns>The new added cache index.</returns>
	public int Add(string sourceData, int row, int column, string tableName, bool useSameSource)
	{
		Class1142 @class = worksheet_0.method_2().method_89();
		int int_ = @class.Add(sourceData, worksheet_0, useSameSource);
		return Add(@class[int_], row, column, tableName);
	}

	/// <summary>
	///       Adds a new PivotTable Object to the collection from another PivotTable.
	///       </summary>
	/// <param name="pivotTable">The source pivotTable.</param>
	/// <param name="destCellName">The cell in the upper-left corner of the PivotTable report's destination range.</param>
	/// <param name="tableName">The name of the new PivotTable report.</param>
	/// <returns>The new added PivotTable index.</returns>
	public int Add(PivotTable pivotTable, string destCellName, string tableName)
	{
		int row = 0;
		int column = 0;
		CellsHelper.CellNameToIndex(destCellName, out row, out column);
		return Add(pivotTable, row, column, tableName);
	}

	/// <summary>
	///       Adds a new PivotTable Object to the collection from another PivotTable.
	///       </summary>
	/// <param name="pivotTable">The source pivotTable.</param>
	/// <param name="row">Row index of the cell in the upper-left corner of the PivotTable report's destination range.</param>
	/// <param name="column">Column index of the cell in the upper-left corner of the PivotTable report's destination range.</param>
	/// <param name="tableName">The name of the new PivotTable report.</param>
	/// <returns>The new added PivotTable index.</returns>
	public int Add(PivotTable pivotTable, int row, int column, string tableName)
	{
		return Add(pivotTable.class1141_0, row, column, tableName);
	}

	/// <summary>
	///       Adds a new PivotTable Object to the collection with multiple consolidation ranges as data source.
	///       </summary>
	/// <param name="sourceData">The multiple consolidation ranges,such as {"Sheet1!A1:C8","Sheet2!A1:B8"}</param>
	/// <param name="isAutoPage">Whether auto create a single page field.
	///       If true,the following param pageFields will be ignored.
	///       </param>
	/// <param name="pageFields">The pivot page field items.
	///       </param>
	/// <param name="destCellName">destCellName The name of the new PivotTable report.</param>
	/// <param name="tableName">the name of the new PivotTable report.</param>
	/// <returns>The new added PivotTable index.</returns>
	public int Add(string[] sourceData, bool isAutoPage, PivotPageFields pageFields, string destCellName, string tableName)
	{
		int row = 0;
		int column = 0;
		CellsHelper.CellNameToIndex(destCellName, out row, out column);
		return Add(sourceData, isAutoPage, pageFields, row, column, tableName);
	}

	/// <summary>
	///       Adds a new PivotTable Object to the collection with multiple consolidation ranges as data source.
	///       </summary>
	/// <param name="sourceData">The multiple consolidation ranges,such as {"Sheet1!A1:C8","Sheet2!A1:B8"}</param>
	/// <param name="isAutoPage">Whether auto create a single page field.
	///       If true,the following param pageFields will be ignored</param>
	/// <param name="pageFields">The pivot page field items.
	///       </param>
	/// <param name="row">Row index of the cell in the upper-left corner of the PivotTable report's destination range.</param>
	/// <param name="column">Column index of the cell in the upper-left corner of the PivotTable report's destination range.</param>
	/// <param name="tableName">The name of the new PivotTable report.</param>
	/// <returns>The new added PivotTable index.</returns>
	public int Add(string[] sourceData, bool isAutoPage, PivotPageFields pageFields, int row, int column, string tableName)
	{
		Class1142 @class = worksheet_0.method_2().method_89();
		int int_ = @class.Add(PivotTableSourceType.Consilidation, sourceData, isAutoPage, pageFields);
		Class1141 class1141_ = @class[int_];
		return Add(class1141_, row, column, tableName);
	}

	internal int Add(Class1141 class1141_0, int int_0, int int_1, string string_0)
	{
		PivotTable value = new PivotTable(this, class1141_0, int_0, (short)int_1, string_0);
		worksheet_0.method_2().method_49();
		base.InnerList.Add(value);
		return base.Count - 1;
	}

	/// <summary>
	///       Clear all pivot tables.
	///       </summary>
	public new void Clear()
	{
		base.InnerList.Clear();
		if (worksheet_0.class1557_0 != null)
		{
			worksheet_0.class1557_0.method_0();
		}
	}

	internal void method_5(PivotTable pivotTable_0)
	{
		if (worksheet_0.method_2().method_50() == null)
		{
			worksheet_0.method_2().method_51(new Class1734());
		}
		if (worksheet_0.method_2().method_50().method_7() == null)
		{
			worksheet_0.method_2().method_50().method_8(new byte[21]
			{
				99, 8, 0, 0, 0, 0, 0, 0, 0, 0,
				0, 0, 21, 0, 0, 0, 0, 0, 0, 0,
				30
			});
		}
		base.InnerList.Add(pivotTable_0);
	}

	internal new void RemoveAt(int int_0)
	{
		this[int_0].class1141_0.int_5--;
		base.InnerList.RemoveAt(int_0);
	}
}
