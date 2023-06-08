using System.Collections;
using System.Runtime.CompilerServices;

namespace Aspose.Cells.Tables;

/// <summary>
///       Returns a collection of <see cref="T:Aspose.Cells.Tables.ListObject" /> objects in the worksheet.
///       </summary>
public class ListObjectCollection : CollectionBase
{
	private Worksheet worksheet_0;

	/// <summary>
	///       Gets the ListObject by index.
	///       </summary>
	/// <param name="index">The index.</param>
	/// <returns>The ListObject</returns>
	public ListObject this[int index] => (ListObject)base.InnerList[index];

	/// <summary>
	///       Gets the ListObject by specified name.
	///       </summary>
	/// <param name="tableName">ListObject name.</param>
	/// <returns>The ListObject</returns>
	public ListObject this[string tableName]
	{
		get
		{
			int num = 0;
			ListObject listObject;
			while (true)
			{
				if (num < base.InnerList.Count)
				{
					listObject = (ListObject)base.InnerList[num];
					if (listObject.Name.ToUpper() == tableName.ToUpper())
					{
						break;
					}
					num++;
					continue;
				}
				return null;
			}
			return listObject;
		}
	}

	internal ListObjectCollection(Worksheet worksheet_1)
	{
		worksheet_0 = worksheet_1;
	}

	internal Style GetCellStyle(int int_0, int int_1)
	{
		return method_0(int_0, int_1)?.GetCellStyle(int_0, int_1);
	}

	internal void Copy(ListObjectCollection listObjectCollection_0)
	{
		Clear();
		for (int i = 0; i < listObjectCollection_0.Count; i++)
		{
			ListObject listObject_ = listObjectCollection_0[i];
			worksheet_0.method_2().int_11++;
			ListObject listObject = new ListObject(this, "Table" + worksheet_0.method_2().int_11, worksheet_0.method_2().int_11);
			listObject.Copy(listObject_);
			base.InnerList.Add(listObject);
		}
	}

	internal ListObject method_0(int int_0, int int_1)
	{
		int num = 0;
		ListObject listObject;
		while (true)
		{
			if (num < base.Count)
			{
				listObject = (ListObject)base.InnerList[num];
				if (int_0 >= listObject.StartRow && int_0 <= listObject.EndRow && int_1 >= listObject.StartColumn && int_1 <= listObject.EndColumn)
				{
					break;
				}
				num++;
				continue;
			}
			return null;
		}
		return listObject;
	}

	internal ListObject method_1(string string_0)
	{
		int num = 0;
		ListObject listObject;
		while (true)
		{
			if (num < base.InnerList.Count)
			{
				listObject = (ListObject)base.InnerList[num];
				if (listObject.DisplayName.ToUpper() == string_0.ToUpper())
				{
					break;
				}
				num++;
				continue;
			}
			return null;
		}
		return listObject;
	}

	/// <summary>
	///       Adds a ListObject to the worksheet.
	///       </summary>
	/// <param name="startRow">The start row of the list range.</param>
	/// <param name="startColumn">The start row of the list range.</param>
	/// <param name="endRow">The start row of the list range.</param>
	/// <param name="endColumn">The start row of the list range.</param>
	/// <param name="hasHeaders">Whether the range has headers.</param>
	/// <returns>The index of the new ListObject</returns>
	public int Add(int startRow, int startColumn, int endRow, int endColumn, bool hasHeaders)
	{
		worksheet_0.method_2().int_11++;
		ListObject listObject = new ListObject(this, "Table" + worksheet_0.method_2().int_11, worksheet_0.method_2().int_11);
		listObject.Resize(startRow, startColumn, endRow, endColumn, hasHeaders);
		base.InnerList.Add(listObject);
		return base.Count - 1;
	}

	/// <summary>
	///       Adds a ListObject to the worksheet.
	///       </summary>
	/// <param name="startCell">The start cell of the list range.</param>
	/// <param name="endCell">The end cell of the list range.</param>
	/// <param name="hasHeaders">Whether the range has headers.</param>
	/// <returns>The index of the new ListObject</returns>
	public int Add(string startCell, string endCell, bool hasHeaders)
	{
		CellsHelper.CellNameToIndex(startCell, out var row, out var column);
		CellsHelper.CellNameToIndex(endCell, out var row2, out var column2);
		worksheet_0.method_2().int_11++;
		ListObject listObject = new ListObject(this, "Table" + worksheet_0.method_2().int_11, worksheet_0.method_2().int_11);
		listObject.Resize(row, column, row2, column2, hasHeaders);
		base.InnerList.Add(listObject);
		return base.Count - 1;
	}

	internal void InsertRows(int int_0, int int_1)
	{
		for (int i = 0; i < base.Count; i++)
		{
			if (this[i].InsertRows(int_0, int_1))
			{
				RemoveAt(i--);
			}
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

	internal bool method_2(int int_0, int int_1, int int_2, int int_3)
	{
		int num = 0;
		while (true)
		{
			if (num < base.Count)
			{
				if (!this[num].method_11(int_0, int_1, int_2, int_3))
				{
					break;
				}
				num++;
				continue;
			}
			return true;
		}
		return false;
	}

	internal void InsertColumns(int int_0, int int_1)
	{
		for (int i = 0; i < base.Count; i++)
		{
			if (this[i].InsertColumns(int_0, int_1))
			{
				RemoveAt(i--);
			}
		}
	}

	internal int Add(ListObject listObject_0)
	{
		base.InnerList.Add(listObject_0);
		return base.Count - 1;
	}

	internal ListObject method_3(int int_0)
	{
		int num = 0;
		while (true)
		{
			if (num < base.Count)
			{
				if (this[num].method_0() == int_0)
				{
					break;
				}
				num++;
				continue;
			}
			return null;
		}
		return this[num];
	}

	[SpecialName]
	internal Worksheet method_4()
	{
		return worksheet_0;
	}

	internal bool method_5(int int_0, int int_1)
	{
		int num = 0;
		while (true)
		{
			if (num < base.Count)
			{
				ListObject listObject = this[num];
				if (listObject.method_53() && int_0 == listObject.AutoFilter.method_7().StartRow && int_1 >= listObject.AutoFilter.method_7().StartColumn && int_1 <= listObject.AutoFilter.method_7().EndColumn)
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

	internal void method_6()
	{
		for (int i = 0; i < base.Count; i++)
		{
			this[i].method_54();
		}
	}

	/// <summary>
	///       Update all column name of the tables.
	///       </summary>
	public void UpdateColumnName()
	{
		for (int i = 0; i < base.Count; i++)
		{
			this[i].UpdateColumnName();
		}
	}

	internal void Remove(ListObject listObject_0)
	{
		base.InnerList.Remove(listObject_0);
	}
}
