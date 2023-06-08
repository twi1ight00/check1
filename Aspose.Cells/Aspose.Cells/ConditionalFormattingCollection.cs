using System;
using System.Collections;
using ns2;
using ns29;

namespace Aspose.Cells;

/// <summary>
///       Encapsulates a collection of <see cref="T:Aspose.Cells.FormatCondition" /> objects.
///       </summary>
/// <example>
///   <code>
///
///       [C#]
///
///       //Instantiating a Workbook object
///       Workbook workbook = new Workbook();
///
///       Worksheet sheet = workbook.Worksheets[0];
///
///       //Get Conditional Formattings
///       ConditionalFormattingCollection cformattings = sheet.ConditionalFormattings;
///
///       //Adds an empty conditional formatting
///       int index = cformattings.Add();
///
///       //Get newly added Conditional formatting
///       FormatConditionCollection fcs = cformattings[index];
///
///       //Sets the conditional format range.
///       CellArea ca = new CellArea();
///
///       ca.StartRow = 0;
///
///       ca.EndRow = 0;
///
///       ca.StartColumn = 0;
///
///       ca.EndColumn = 0;
///
///       fcs.AddArea(ca);
///
///       ca = new CellArea();
///
///       ca.StartRow = 1;
///
///       ca.EndRow = 1;
///
///       ca.StartColumn = 1;
///
///       ca.EndColumn = 1;
///
///       fcs.AddArea(ca);
///
///       //Add condition.
///       int conditionIndex = fcs.AddCondition(FormatConditionType.CellValue, OperatorType.Between, "=A2", "100");
///
///       //Add condition.
///       int conditionIndex2 = fcs.AddCondition(FormatConditionType.CellValue, OperatorType.Between, "50", "100");
///
///       //Sets the background color.
///       FormatCondition fc = fcs[conditionIndex];
///
///       fc.Style.BackgroundColor = Color.Red;
///
///       //Saving the Excel file
///       workbook.Save("C:\\output.xls");
///
///       [VB.NET]
///
///       'Instantiating a Workbook object
///       Dim workbook As New Workbook()
///
///       Dim sheet As Worksheet = workbook.Worksheets(0)
///
///       'Get Conditional Formattings
///       Dim cformattings As ConditionalFormattingCollection = sheet.ConditionalFormattings
///
///       'Adds an empty conditional formatting
///       Dim index As Integer = cformattings.Add()
///
///       'Get newly added Conditional formatting
///       Dim fcs As FormatConditionCollection = cformattings(index)
///
///       'Sets the conditional format range.
///       Dim ca As New CellArea()
///
///       ca.StartRow = 0
///
///       ca.EndRow = 0
///
///       ca.StartColumn = 0
///
///       ca.EndColumn = 0
///
///       fcs.AddArea(ca)
///
///       ca = New CellArea()
///
///       ca.StartRow = 1
///
///       ca.EndRow = 1
///
///       ca.StartColumn = 1
///
///       ca.EndColumn = 1
///
///       fcs.AddArea(ca)
///
///       'Add condition.
///       Dim conditionIndex As Integer = fcs.AddCondition(FormatConditionType.CellValue, OperatorType.Between, "=A2", "100")
///
///       'Add condition.
///       Dim conditionIndex2 As Integer = fcs.AddCondition(FormatConditionType.CellValue, OperatorType.Between, "50", "100")
///
///       'Sets the background color.
///       Dim fc As FormatCondition = fcs(conditionIndex)
///
///       fc.Style.BackgroundColor = Color.Red
///
///       'Saving the Excel file
///       workbook.Save("C:\output.xls")
///       </code>
/// </example>
public class ConditionalFormattingCollection : CollectionBase
{
	internal Worksheet worksheet_0;

	/// <summary>
	///       Gets the FormatConditions element at the specified index.
	///       </summary>
	/// <param name="index">The zero based index of the element.</param>
	public FormatConditionCollection this[int index] => (FormatConditionCollection)base.InnerList[index];

	internal ConditionalFormattingCollection(Worksheet worksheet_1)
	{
		worksheet_0 = worksheet_1;
	}

	/// <summary>
	///       Remove all conditional formattings in the range.
	///       </summary>
	/// <param name="startRow">The start row of the range.</param>
	/// <param name="startColumn">The start column of the range.</param>
	/// <param name="totalRows">The number of rows of the range.</param>
	/// <param name="totalColumns">The number of columns of the range.</param>
	public void RemoveArea(int startRow, int startColumn, int totalRows, int totalColumns)
	{
		for (int i = 0; i < base.Count; i++)
		{
			FormatConditionCollection formatConditionCollection = this[i];
			if (formatConditionCollection.RemoveArea(startRow, startColumn, totalRows, totalColumns))
			{
				base.InnerList.RemoveAt(i--);
			}
		}
	}

	/// <summary>
	///       Copies condtional formattings.
	///       </summary>
	/// <param name="cfs">The condtional formattings</param>
	public void Copy(ConditionalFormattingCollection cfs)
	{
		worksheet_0.int_0 = cfs.worksheet_0.int_0;
		for (int i = 0; i < cfs.Count; i++)
		{
			FormatConditionCollection formatConditionCollection = new FormatConditionCollection(this);
			formatConditionCollection.Copy(cfs[i], null);
			base.InnerList.Add(formatConditionCollection);
		}
	}

	internal void Copy(ConditionalFormattingCollection conditionalFormattingCollection_0, CopyOptions copyOptions_0)
	{
		worksheet_0.int_0 = conditionalFormattingCollection_0.worksheet_0.int_0;
		for (int i = 0; i < conditionalFormattingCollection_0.Count; i++)
		{
			FormatConditionCollection formatConditionCollection = new FormatConditionCollection(this);
			formatConditionCollection.Copy(conditionalFormattingCollection_0[i], copyOptions_0);
			base.InnerList.Add(formatConditionCollection);
		}
	}

	internal void CopyInRange(ConditionalFormattingCollection conditionalFormattingCollection_0, CellArea cellArea_0, CellArea cellArea_1, CopyOptions copyOptions_0, bool bool_0)
	{
		if (bool_0)
		{
			return;
		}
		for (int i = 0; i < conditionalFormattingCollection_0.Count; i++)
		{
			FormatConditionCollection formatConditionCollection = conditionalFormattingCollection_0[i];
			int count = formatConditionCollection.arrayList_1.Count;
			for (int j = 0; j < count; j++)
			{
				CellArea cellArea_2 = (CellArea)formatConditionCollection.arrayList_1[j];
				object obj = Class1678.Intersect(cellArea_2, cellArea_0);
				if (obj != null)
				{
					cellArea_2 = (CellArea)obj;
					CellArea cellArea_3 = default(CellArea);
					cellArea_3.StartRow = cellArea_2.StartRow - cellArea_0.StartRow + cellArea_1.StartRow;
					cellArea_3.StartColumn = cellArea_2.StartColumn - cellArea_0.StartColumn + cellArea_1.StartColumn;
					cellArea_3.EndRow = cellArea_2.EndRow - cellArea_2.StartRow + cellArea_3.StartRow;
					cellArea_3.EndColumn = cellArea_2.EndColumn - cellArea_2.StartColumn + cellArea_3.StartColumn;
					if (conditionalFormattingCollection_0 == this)
					{
						Class1678.smethod_0(formatConditionCollection.arrayList_1, cellArea_3);
						continue;
					}
					FormatConditionCollection formatConditionCollection2 = new FormatConditionCollection(this);
					formatConditionCollection2.method_1(formatConditionCollection, cellArea_3);
					base.InnerList.Add(formatConditionCollection2);
				}
			}
		}
	}

	/// <summary>
	///       Adds a FormatConditions to the collection.
	///       </summary>
	/// <returns>FormatConditions object index.</returns>
	public int Add()
	{
		base.InnerList.Add(new FormatConditionCollection(this));
		return base.Count - 1;
	}

	internal int Add(FormatConditionCollection formatConditionCollection_0)
	{
		base.InnerList.Add(formatConditionCollection_0);
		return base.Count - 1;
	}

	internal void method_0(int int_0, int int_1, int int_2, int int_3)
	{
		for (int i = 0; i < base.Count; i++)
		{
			FormatConditionCollection formatConditionCollection = this[i];
			foreach (CellArea item in formatConditionCollection.arrayList_1)
			{
				if (int_0 < item.StartRow || int_0 > item.EndRow || int_1 < item.StartColumn || int_1 > item.EndColumn)
				{
					continue;
				}
				int num = formatConditionCollection.RangeCount - 1;
				CellArea cellArea2;
				while (true)
				{
					if (num >= 0)
					{
						cellArea2 = (CellArea)formatConditionCollection.arrayList_1[num];
						if (int_2 >= cellArea2.StartRow && int_2 <= cellArea2.EndRow)
						{
							if (int_3 >= cellArea2.StartColumn && int_3 <= cellArea2.EndColumn)
							{
								return;
							}
							if (cellArea2.StartRow == cellArea2.EndRow)
							{
								if (int_3 == cellArea2.StartColumn - 1)
								{
									cellArea2.StartColumn--;
									formatConditionCollection.arrayList_1[num] = cellArea2;
									return;
								}
								if (int_3 == cellArea2.EndColumn + 1)
								{
									cellArea2.EndColumn++;
									formatConditionCollection.arrayList_1[num] = cellArea2;
									return;
								}
							}
						}
						if (cellArea2.StartColumn == cellArea2.EndColumn)
						{
							if (int_2 == cellArea2.StartRow - 1)
							{
								cellArea2.StartRow--;
								formatConditionCollection.arrayList_1[num] = cellArea2;
								return;
							}
							if (int_2 == cellArea2.EndRow + 1)
							{
								break;
							}
						}
						num--;
						continue;
					}
					CellArea cellArea3 = default(CellArea);
					cellArea3.StartRow = int_2;
					cellArea3.StartColumn = int_3;
					cellArea3.EndRow = int_2;
					cellArea3.EndColumn = int_3;
					formatConditionCollection.arrayList_1.Insert(0, cellArea3);
					return;
				}
				cellArea2.EndRow++;
				formatConditionCollection.arrayList_1[num] = cellArea2;
				return;
			}
		}
	}

	internal void CopyRows(ConditionalFormattingCollection conditionalFormattingCollection_0, int int_0, int int_1, int int_2)
	{
		if (conditionalFormattingCollection_0 != this)
		{
			for (int i = 0; i < conditionalFormattingCollection_0.Count; i++)
			{
				FormatConditionCollection formatConditionCollection_ = conditionalFormattingCollection_0[i];
				CopyRows(formatConditionCollection_, int_0, int_1, int_2);
			}
		}
		else if (int_2 == 1)
		{
			for (int j = 0; j < base.Count; j++)
			{
				FormatConditionCollection formatConditionCollection = this[j];
				CopyRow(formatConditionCollection.arrayList_1, int_0, int_1);
			}
		}
		else
		{
			for (int k = 0; k < base.Count; k++)
			{
				FormatConditionCollection formatConditionCollection2 = this[k];
				CopyRows(formatConditionCollection2.arrayList_1, int_0, int_1, int_2);
			}
		}
	}

	private void CopyRows(FormatConditionCollection formatConditionCollection_0, int int_0, int int_1, int int_2)
	{
		ArrayList arrayList_ = formatConditionCollection_0.arrayList_1;
		ArrayList arrayList = new ArrayList();
		for (int num = arrayList_.Count - 1; num >= 0; num--)
		{
			CellArea cellArea_ = (CellArea)arrayList_[num];
			object obj = Class1678.smethod_4(cellArea_, int_0, int_2);
			if (obj != null)
			{
				CellArea cellArea = (CellArea)obj;
				int num2 = cellArea_.StartRow - int_0;
				if (num2 < 0)
				{
					num2 = 0;
				}
				int num3 = int_1 + num2;
				int num4 = cellArea.EndRow - cellArea.StartRow + 1;
				CellArea cellArea2 = default(CellArea);
				cellArea2.StartRow = num3;
				cellArea2.EndRow = num3 + num4 - 1;
				cellArea2.StartColumn = cellArea_.StartColumn;
				cellArea2.EndColumn = cellArea_.EndColumn;
				arrayList.Add(cellArea2);
			}
		}
		if (arrayList.Count != 0)
		{
			FormatConditionCollection formatConditionCollection = new FormatConditionCollection(this);
			formatConditionCollection.method_2(formatConditionCollection_0, arrayList);
			base.InnerList.Add(formatConditionCollection);
		}
	}

	private void CopyRows(ArrayList arrayList_0, int int_0, int int_1, int int_2)
	{
		int num = arrayList_0.Count - 1;
		CellArea cellArea;
		object obj;
		while (true)
		{
			if (num >= 0)
			{
				cellArea = (CellArea)arrayList_0[num];
				obj = Class1678.smethod_4(cellArea, int_0, int_2);
				if (obj != null)
				{
					break;
				}
				num--;
				continue;
			}
			return;
		}
		CellArea cellArea2 = (CellArea)obj;
		int endRow = cellArea2.EndRow;
		int num2 = cellArea.StartRow - int_0;
		if (num2 < 0)
		{
			num2 = 0;
		}
		int num3 = int_1 + num2;
		if (num3 == endRow + 1)
		{
			num3 = num3 + endRow - int_0;
			if (num3 > cellArea.EndRow)
			{
				cellArea.EndRow = num3;
				arrayList_0[num] = cellArea;
			}
		}
		else if (int_0 >= num3 + 1 && int_0 <= num3 + int_2)
		{
			if (num3 < cellArea.StartRow)
			{
				cellArea.StartRow = num3;
				arrayList_0[num] = cellArea;
			}
		}
		else
		{
			int num4 = endRow - cellArea2.StartRow + 1;
			CellArea cellArea3 = default(CellArea);
			cellArea3.StartRow = num3;
			cellArea3.EndRow = num3 + num4 - 1;
			cellArea3.StartColumn = cellArea.StartColumn;
			cellArea3.EndColumn = cellArea.EndColumn;
			arrayList_0.Add(cellArea3);
		}
	}

	private void CopyRow(ArrayList arrayList_0, int int_0, int int_1)
	{
		int num = arrayList_0.Count - 1;
		CellArea cellArea;
		while (true)
		{
			if (num >= 0)
			{
				cellArea = (CellArea)arrayList_0[num];
				if (cellArea.StartRow <= int_0 && cellArea.EndRow >= int_0)
				{
					break;
				}
				num--;
				continue;
			}
			return;
		}
		if (cellArea.StartRow <= int_1 && cellArea.EndRow >= int_1)
		{
			return;
		}
		if (cellArea.StartRow == int_1 + 1)
		{
			cellArea.StartRow--;
			arrayList_0[num] = cellArea;
			return;
		}
		if (cellArea.EndRow == int_1 - 1)
		{
			cellArea.EndRow++;
			arrayList_0[num] = cellArea;
			return;
		}
		int num2 = arrayList_0.Count - 1;
		CellArea cellArea2;
		while (true)
		{
			if (num2 >= 0)
			{
				if (num2 != num)
				{
					cellArea2 = (CellArea)arrayList_0[num2];
					if (cellArea2.StartRow <= int_1 && cellArea.EndRow >= int_1)
					{
						return;
					}
					if (cellArea2.StartRow == int_1 + 1)
					{
						cellArea2.StartRow--;
						arrayList_0[num2] = cellArea2;
						return;
					}
					if (cellArea2.EndRow == int_1 - 1)
					{
						break;
					}
				}
				num2--;
				continue;
			}
			CellArea cellArea3 = default(CellArea);
			cellArea3.StartRow = int_1;
			cellArea3.EndRow = int_1;
			cellArea3.StartColumn = cellArea.StartColumn;
			cellArea3.EndColumn = cellArea.EndColumn;
			arrayList_0.Add(cellArea3);
			return;
		}
		cellArea2.EndRow++;
		arrayList_0[num] = cellArea2;
	}

	internal void method_1(FormatConditionCollection formatConditionCollection_0, ArrayList arrayList_0)
	{
		for (int num = arrayList_0.Count - 1; num > 0; num--)
		{
			int index = Add();
			FormatConditionCollection formatConditionCollection = this[index];
			formatConditionCollection.bool_0 = formatConditionCollection_0.bool_0;
			formatConditionCollection.arrayList_1.Add(arrayList_0[num]);
			for (int i = 0; i < formatConditionCollection_0.Count; i++)
			{
				FormatCondition formatCondition = new FormatCondition(formatConditionCollection);
				formatCondition.Copy(formatConditionCollection_0[i], null);
				formatCondition.Priority = worksheet_0.int_0++;
				formatConditionCollection.AddCondition(formatCondition);
			}
		}
		formatConditionCollection_0.arrayList_1.Clear();
		formatConditionCollection_0.arrayList_1.Add(arrayList_0[0]);
	}

	internal void method_2(FormatConditionCollection formatConditionCollection_0)
	{
		ArrayList arrayList_ = formatConditionCollection_0.arrayList_1;
		for (int num = arrayList_.Count - 1; num > 0; num--)
		{
			int index = Add();
			FormatConditionCollection formatConditionCollection = this[index];
			formatConditionCollection.bool_0 = formatConditionCollection_0.bool_0;
			CellArea cellArea = (CellArea)arrayList_[num];
			CellArea cellArea2 = default(CellArea);
			cellArea2.StartRow = cellArea.StartRow;
			cellArea2.StartColumn = cellArea.StartColumn;
			cellArea2.EndColumn = cellArea.EndColumn;
			cellArea2.EndRow = cellArea.EndRow;
			formatConditionCollection.arrayList_1.Add(cellArea2);
			for (int i = 0; i < formatConditionCollection_0.Count; i++)
			{
				FormatCondition formatCondition = new FormatCondition(formatConditionCollection);
				formatCondition.Copy(formatConditionCollection_0[i], null);
				formatCondition.Priority = worksheet_0.int_0++;
				formatConditionCollection.AddCondition(formatCondition);
			}
			arrayList_.RemoveAt(num);
		}
		for (int j = 0; j < formatConditionCollection_0.Count; j++)
		{
			formatConditionCollection_0[j].string_1 = null;
			formatConditionCollection_0[j].string_2 = null;
		}
	}

	internal void method_3(CellArea cellArea_0, int int_0, ShiftType shiftType_0, Worksheet worksheet_1, bool bool_0)
	{
		switch (shiftType_0)
		{
		case ShiftType.Right:
			method_5(cellArea_0, int_0, worksheet_1, bool_0);
			break;
		case ShiftType.Down:
			method_6(cellArea_0, int_0, worksheet_1, bool_0);
			break;
		}
	}

	private void method_4(FormatConditionCollection formatConditionCollection_0, CellArea cellArea_0, int int_0, ShiftType shiftType_0, Worksheet worksheet_1, bool bool_0, int int_1, int int_2, int int_3, int int_4)
	{
		for (int i = 0; i < formatConditionCollection_0.Count; i++)
		{
			FormatCondition formatCondition = formatConditionCollection_0[i];
			if (formatCondition.method_0() != null)
			{
				byte[] array = formatCondition.method_0();
				Class1674.smethod_19(cellArea_0, int_0, shiftType_0, worksheet_1, bool_0, array, -1, array.Length, int_1, int_2, int_3, int_4);
				formatCondition.method_1(array);
			}
			if ((formatCondition.Operator == OperatorType.Between || formatCondition.Operator == OperatorType.NotBetween) && formatCondition.method_4() != null)
			{
				byte[] array2 = formatCondition.method_4();
				Class1674.smethod_19(cellArea_0, int_0, shiftType_0, worksheet_1, bool_0, array2, -1, array2.Length, int_1, int_2, int_3, int_4);
				formatCondition.method_5(array2);
			}
		}
	}

	private void method_5(CellArea cellArea_0, int int_0, Worksheet worksheet_1, bool bool_0)
	{
		for (int i = 0; i < base.Count; i++)
		{
			FormatConditionCollection formatConditionCollection = this[i];
			if (formatConditionCollection.arrayList_1 == null || formatConditionCollection.arrayList_1.Count == 0)
			{
				continue;
			}
			_ = formatConditionCollection.arrayList_1.Count;
			formatConditionCollection.method_10();
			bool flag = formatConditionCollection.method_8();
			ArrayList arrayList = new ArrayList();
			ArrayList arrayList2 = new ArrayList();
			Class1678.smethod_20(formatConditionCollection.arrayList_1, worksheet_0.method_2().Workbook.method_23(), cellArea_0, int_0, arrayList, arrayList2);
			int[] array = formatConditionCollection.method_9();
			int num = array[0];
			int num2 = array[1];
			if (flag)
			{
				formatConditionCollection.arrayList_1.Clear();
				if (arrayList.Count != 0)
				{
					formatConditionCollection.arrayList_1.AddRange(arrayList);
					method_4(formatConditionCollection, cellArea_0, int_0, ShiftType.Right, worksheet_1, bool_0, num, num2, num, num2);
					if (arrayList2.Count != 0)
					{
						FormatConditionCollection formatConditionCollection2 = new FormatConditionCollection(this);
						formatConditionCollection2.CopyData(formatConditionCollection);
						formatConditionCollection = formatConditionCollection2;
						base.InnerList.Insert(i, formatConditionCollection);
						formatConditionCollection.arrayList_1.AddRange(arrayList2);
						array = formatConditionCollection.method_9();
						num = array[0];
						num2 = array[1];
						method_4(formatConditionCollection, cellArea_0, int_0, ShiftType.Right, worksheet_1, bool_0, num, num2 - int_0, num, num2);
						i++;
					}
				}
				else if (arrayList2.Count != 0)
				{
					formatConditionCollection.arrayList_1.AddRange(arrayList2);
					array = formatConditionCollection.method_9();
					num = array[0];
					num2 = array[1];
					method_4(formatConditionCollection, cellArea_0, int_0, ShiftType.Right, worksheet_1, bool_0, num, num2 - int_0, num, num2);
				}
			}
			else
			{
				formatConditionCollection.arrayList_1.Clear();
				formatConditionCollection.arrayList_1.AddRange(arrayList);
				formatConditionCollection.arrayList_1.AddRange(arrayList2);
				method_4(formatConditionCollection, cellArea_0, int_0, ShiftType.Right, worksheet_1, bool_0, num, num2, num, num2);
			}
		}
	}

	private void method_6(CellArea cellArea_0, int int_0, Worksheet worksheet_1, bool bool_0)
	{
		for (int i = 0; i < base.Count; i++)
		{
			FormatConditionCollection formatConditionCollection = this[i];
			if (formatConditionCollection.arrayList_1 == null || formatConditionCollection.arrayList_1.Count == 0)
			{
				continue;
			}
			int num = formatConditionCollection.arrayList_1.Count;
			bool flag = false;
			formatConditionCollection.method_10();
			if (!formatConditionCollection.method_7() && formatConditionCollection.method_8())
			{
				if (num > 1)
				{
					method_2(formatConditionCollection);
				}
				CellArea ca = (CellArea)formatConditionCollection.arrayList_1[0];
				ArrayList arrayList = Class1678.smethod_18(cellArea_0, ca, out flag);
				if (flag && arrayList != null && arrayList.Count > 1)
				{
					method_1(formatConditionCollection, arrayList);
				}
				ca = (CellArea)formatConditionCollection.arrayList_1[0];
				int startRow = ca.StartRow;
				int startColumn = ca.StartColumn;
				int int_ = startRow;
				int int_2 = startColumn;
				arrayList = Class1678.smethod_13(worksheet_1.method_2().Workbook.method_23(), cellArea_0, int_0, ca, out flag);
				if (flag)
				{
					formatConditionCollection.arrayList_1 = arrayList;
					int[] array = formatConditionCollection.method_9();
					int_ = array[0];
					int_2 = array[1];
				}
				for (int j = 0; j < formatConditionCollection.Count; j++)
				{
					FormatCondition formatCondition = formatConditionCollection[j];
					if (formatCondition.method_0() != null)
					{
						byte[] array2 = formatCondition.method_0();
						Class1674.smethod_19(cellArea_0, int_0, ShiftType.Down, worksheet_1, bool_0, array2, -1, array2.Length, startRow, startColumn, int_, int_2);
						formatCondition.method_1(array2);
					}
					if ((formatCondition.Operator == OperatorType.Between || formatCondition.Operator == OperatorType.NotBetween) && formatCondition.method_4() != null)
					{
						byte[] array3 = formatCondition.method_4();
						Class1674.smethod_19(cellArea_0, int_0, ShiftType.Down, worksheet_1, bool_0, array3, -1, array3.Length, startRow, startColumn, int_, int_2);
						formatCondition.method_5(array3);
					}
				}
				continue;
			}
			for (int k = 0; k < num; k++)
			{
				CellArea ca2 = (CellArea)formatConditionCollection.arrayList_1[k];
				ArrayList arrayList2 = Class1678.smethod_13(worksheet_1.method_2().Workbook.method_23(), cellArea_0, int_0, ca2, out flag);
				if (flag)
				{
					if (arrayList2.Count == 1)
					{
						formatConditionCollection.arrayList_1[k] = arrayList2[0];
						continue;
					}
					formatConditionCollection.arrayList_1.RemoveAt(k--);
					num--;
					formatConditionCollection.arrayList_1.AddRange(arrayList2);
				}
			}
		}
	}

	internal void InsertRows(int int_0, int int_1)
	{
		for (int i = 0; i < base.Count; i++)
		{
			FormatConditionCollection formatConditionCollection = this[i];
			if (formatConditionCollection.arrayList_1 == null || formatConditionCollection.arrayList_1.Count == 0)
			{
				continue;
			}
			formatConditionCollection.method_10();
			if (formatConditionCollection.arrayList_1.Count > 1 && formatConditionCollection.method_8())
			{
				method_2(formatConditionCollection);
			}
			int startRow = ((CellArea)formatConditionCollection.arrayList_1[0]).StartRow;
			for (int num = formatConditionCollection.RangeCount - 1; num >= 0; num--)
			{
				CellArea cellArea = (CellArea)formatConditionCollection.arrayList_1[num];
				bool bool_ = false;
				if (int_1 > 0 && int_0 == cellArea.EndRow + 1)
				{
					cellArea.EndRow = int_0 + int_1 - 1;
				}
				else
				{
					cellArea = Class1678.InsertRows(cellArea, int_0, int_1, ref bool_);
				}
				if (bool_)
				{
					formatConditionCollection.arrayList_1.RemoveAt(num);
				}
				else
				{
					formatConditionCollection.arrayList_1[num] = cellArea;
				}
			}
			if (formatConditionCollection.RangeCount == 0)
			{
				RemoveAt(i);
				i--;
				continue;
			}
			int[] array = formatConditionCollection.method_9();
			int int_2 = array[0];
			foreach (FormatCondition item in formatConditionCollection.method_0())
			{
				byte[] array2 = item.method_0();
				if (array2 != null)
				{
					Class1674.InsertRows(worksheet_0, bool_0: true, int_0, int_1, startRow, int_2, -1, array2.Length - 1, array2);
					item.method_1(array2);
					if (item.method_4() != null)
					{
						array2 = item.method_4();
						Class1674.InsertRows(worksheet_0, bool_0: true, int_0, int_1, startRow, int_2, -1, array2.Length - 1, array2);
						item.method_5(array2);
					}
				}
			}
		}
	}

	internal void InsertColumns(int int_0, int int_1)
	{
		for (int i = 0; i < base.Count; i++)
		{
			FormatConditionCollection formatConditionCollection = this[i];
			if (formatConditionCollection.arrayList_1 == null || formatConditionCollection.arrayList_1.Count == 0)
			{
				continue;
			}
			formatConditionCollection.method_10();
			if (formatConditionCollection.arrayList_1.Count > 1 && formatConditionCollection.method_8())
			{
				method_2(formatConditionCollection);
			}
			int startColumn = ((CellArea)formatConditionCollection.arrayList_1[0]).StartColumn;
			for (int num = formatConditionCollection.RangeCount - 1; num >= 0; num--)
			{
				CellArea cellArea = (CellArea)formatConditionCollection.arrayList_1[num];
				bool bool_ = false;
				if (int_1 > 0 && int_0 == cellArea.EndColumn + 1)
				{
					cellArea.EndColumn = int_0 + int_1 - 1;
				}
				else
				{
					cellArea = Class1678.InsertColumns(cellArea, int_0, int_1, ref bool_);
				}
				if (bool_)
				{
					formatConditionCollection.arrayList_1.RemoveAt(num);
				}
				else
				{
					formatConditionCollection.arrayList_1[num] = cellArea;
				}
			}
			if (formatConditionCollection.RangeCount == 0)
			{
				RemoveAt(i);
				i--;
				continue;
			}
			int[] array = formatConditionCollection.method_9();
			int int_2 = array[1];
			foreach (FormatCondition item in formatConditionCollection.method_0())
			{
				byte[] array2 = item.method_0();
				if (array2 != null)
				{
					Class1674.InsertColumns(worksheet_0, bool_0: true, int_0, int_1, startColumn, int_2, -1, array2.Length - 1, array2);
					item.method_1(array2);
				}
				if (item.method_4() != null)
				{
					array2 = item.method_4();
					Class1674.InsertColumns(worksheet_0, bool_0: true, int_0, int_1, startColumn, int_2, -1, array2.Length - 1, array2);
					item.method_5(array2);
				}
			}
		}
	}

	internal bool method_7()
	{
		for (int i = 0; i < base.Count; i++)
		{
			FormatConditionCollection formatConditionCollection = this[i];
			if (formatConditionCollection.RangeCount == 0)
			{
				RemoveAt(i--);
				continue;
			}
			for (int j = 0; j < formatConditionCollection.Count; j++)
			{
				FormatCondition formatCondition = formatConditionCollection[j];
				if (formatCondition == null)
				{
					formatConditionCollection.RemoveCondition(j--);
					continue;
				}
				switch (formatCondition.Type)
				{
				default:
					formatCondition.Formula1 = formatCondition.method_13();
					break;
				case FormatConditionType.CellValue:
				case FormatConditionType.Expression:
					formatCondition.method_11();
					if (formatCondition.method_0() == null)
					{
						formatConditionCollection.RemoveCondition(j--);
					}
					else if (formatCondition.formatConditionType_0 == FormatConditionType.CellValue && (formatCondition.operatorType_0 == OperatorType.Between || formatCondition.operatorType_0 == OperatorType.NotBetween) && formatCondition.method_4() == null)
					{
						formatConditionCollection.RemoveCondition(j--);
					}
					break;
				case FormatConditionType.ColorScale:
				case FormatConditionType.DataBar:
				case FormatConditionType.IconSet:
					break;
				}
			}
			if (formatConditionCollection.Count == 0)
			{
				RemoveAt(i--);
			}
		}
		return true;
	}

	internal bool method_8()
	{
		if (base.Count == 0)
		{
			return false;
		}
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				FormatConditionCollection formatConditionCollection = (FormatConditionCollection)enumerator.Current;
				if (formatConditionCollection.method_6(bool_2: true))
				{
					return true;
				}
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
		return false;
	}
}
