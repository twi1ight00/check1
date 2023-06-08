using System;
using System.Collections;
using System.Runtime.CompilerServices;
using ns2;

namespace Aspose.Cells;

/// <summary>
///        Represents conditional formatting.
///        The FormatConditions can contain up to three conditional formats. 
///        </summary>
/// <example>
///   <code>
///
///        [C#]
///
///        //Adds an empty conditional formatting
///        int index = sheet.ConditionalFormattings.Add();
///        FormatConditionCollection fcs = sheet.ConditionalFormattings[index];
///        //Sets the conditional format range.
///        CllArea ca = new CellArea();
///        ca.StartRow = 0;
///        ca.EndRow = 0;
///        ca.StartColumn = 0;
///        ca.EndColumn = 0;
///        fcs.AddArea(ca);
///        ca = new CellArea();
///        ca.StartRow = 1;
///        ca.EndRow = 1;
///        ca.StartColumn = 1;
///        ca.EndColumn = 1;
///        fcs.AddArea(ca);
///        //Adds condition.
///        int conditionIndex = fcs.AddCondition(FormatConditionType.CellValue, OperatorType.Between, "=A2", "100");
///        //Adds condition.
///        int conditionIndex2 = fcs.AddCondition(FormatConditionType.CellValue, OperatorType.Between, "50", "100");
///        //Sets the background color.
///        FormatCondition fc = fcs[conditionIndex];
///        fc.Style.BackgroundColor = Color.Red;
///        //Saving the Excel file
///        workbook.Save("C:\\output.xls");   
///
///        [Visual Basic]
///
///        'Instantiating a Workbook object
///        Dim workbook As Workbook = New Workbook()
///        Dim sheet As Worksheet = workbook.Worksheets(0)
///        ' Adds an empty conditional formatting
///        Dim index As Integer = sheet.ConditionalFormattings.Add()
///        Dim fcs As FormatConditionCollection = sheet.ConditionalFormattings(index)
///        'Sets the conditional format range.
///        Dim ca As CellArea = New CellArea()
///        ca.StartRow = 0
///        ca.EndRow = 0
///        ca.StartColumn = 0
///        ca.EndColumn = 0
///        fcs.AddArea(ca)
///        ca = New CellArea()
///        ca.StartRow = 1
///        ca.EndRow = 1
///        ca.StartColumn = 1
///        ca.EndColumn = 1
///        fcs.AddArea(ca)
///        'Adds condition.
///        Dim conditionIndex As Integer = fcs.AddCondition(FormatConditionType.CellValue, OperatorType.Between, "=A2", "100")
///        'Adds condition.
///        Dim conditionIndex2 As Integer = fcs.AddCondition(FormatConditionType.CellValue, OperatorType.Between, "50", "100")
///        'Sets the background color.
///        Dim fc As FormatCondition = fcs(conditionIndex)
///        fc.Style.BackgroundColor = Color.Red
///        'Saving the Excel file
///        workbook.Save("C:\output.xls")
///        </code>
/// </example>
public class FormatConditionCollection
{
	internal ConditionalFormattingCollection conditionalFormattingCollection_0;

	private ArrayList arrayList_0;

	internal ArrayList arrayList_1;

	internal bool bool_0;

	internal bool bool_1;

	internal Worksheet worksheet_0;

	/// <summary>
	///       Gets the count of the conditions.
	///       </summary>
	public int Count => arrayList_0.Count;

	/// <summary>
	///       Gets count of conditionally formatted ranges.
	///        </summary>
	public int RangeCount => arrayList_1.Count;

	/// <summary>
	///       Gets the formatting conidition by index.
	///       </summary>
	/// <param name="index">the index of the formatting conidition to return.</param>
	/// <returns>the formatting conidition </returns>
	public FormatCondition this[int index]
	{
		get
		{
			if (index < 0 || index >= Count)
			{
				throw new ArgumentException("Invalid formatting condition index : " + index);
			}
			return (FormatCondition)arrayList_0[index];
		}
	}

	internal FormatConditionCollection(ConditionalFormattingCollection conditionalFormattingCollection_1)
	{
		conditionalFormattingCollection_0 = conditionalFormattingCollection_1;
		arrayList_1 = new ArrayList(4);
		arrayList_0 = new ArrayList(3);
		bool_0 = false;
		worksheet_0 = conditionalFormattingCollection_1.worksheet_0;
	}

	internal FormatConditionCollection(Worksheet worksheet_1)
	{
		arrayList_1 = new ArrayList(4);
		arrayList_0 = new ArrayList(3);
		bool_0 = false;
		worksheet_0 = worksheet_1;
	}

	[SpecialName]
	internal ArrayList method_0()
	{
		return arrayList_0;
	}

	internal void CopyData(FormatConditionCollection formatConditionCollection_0)
	{
		bool_0 = formatConditionCollection_0.bool_0;
		arrayList_1 = new ArrayList(formatConditionCollection_0.arrayList_1.Count);
		arrayList_0 = new ArrayList(formatConditionCollection_0.Count);
		bool_1 = formatConditionCollection_0.bool_1;
		for (int i = 0; i < formatConditionCollection_0.Count; i++)
		{
			FormatCondition formatCondition = new FormatCondition(this);
			formatCondition.Copy(formatConditionCollection_0[i], null);
			arrayList_0.Add(formatCondition);
		}
	}

	internal void method_1(FormatConditionCollection formatConditionCollection_0, CellArea cellArea_0)
	{
		bool_0 = formatConditionCollection_0.bool_0;
		arrayList_1 = new ArrayList(formatConditionCollection_0.arrayList_1.Count);
		arrayList_0 = new ArrayList(formatConditionCollection_0.Count);
		bool_1 = formatConditionCollection_0.bool_1;
		arrayList_1.Add(cellArea_0);
		for (int i = 0; i < formatConditionCollection_0.Count; i++)
		{
			FormatCondition formatCondition = new FormatCondition(this);
			formatCondition.Copy(formatConditionCollection_0[i], null);
			arrayList_0.Add(formatCondition);
		}
	}

	internal void method_2(FormatConditionCollection formatConditionCollection_0, ArrayList arrayList_2)
	{
		bool_0 = formatConditionCollection_0.bool_0;
		arrayList_1 = new ArrayList(formatConditionCollection_0.arrayList_1.Count);
		arrayList_0 = new ArrayList(formatConditionCollection_0.Count);
		bool_1 = formatConditionCollection_0.bool_1;
		arrayList_1 = arrayList_2;
		for (int i = 0; i < formatConditionCollection_0.Count; i++)
		{
			FormatCondition formatCondition = new FormatCondition(this);
			formatCondition.Copy(formatConditionCollection_0[i], null);
			arrayList_0.Add(formatCondition);
		}
	}

	internal void method_3()
	{
		if (Count == 1 || method_4() || !method_5())
		{
			return;
		}
		FormatConditionCollection formatConditionCollection = new FormatConditionCollection(conditionalFormattingCollection_0);
		formatConditionCollection.arrayList_1 = arrayList_1;
		for (int i = 0; i < Count; i++)
		{
			FormatCondition formatCondition = new FormatCondition(formatConditionCollection);
			if (this[i].method_23())
			{
				formatCondition = this[i];
				formatConditionCollection.arrayList_0.Add(formatCondition);
				arrayList_0.RemoveAt(i);
				i--;
			}
		}
		worksheet_0.ConditionalFormattings.Add(formatConditionCollection);
	}

	internal bool method_4()
	{
		foreach (FormatCondition item in arrayList_0)
		{
			if (!item.method_23())
			{
				return false;
			}
		}
		return true;
	}

	internal bool method_5()
	{
		if (Count > 0)
		{
			foreach (FormatCondition item in arrayList_0)
			{
				if (item.method_23())
				{
					return true;
				}
			}
		}
		return false;
	}

	internal bool method_6(bool bool_2)
	{
		if (Count > 0)
		{
			foreach (FormatCondition item in arrayList_0)
			{
				switch (item.Type)
				{
				case FormatConditionType.IconSet:
					if (!item.method_23())
					{
						if (item.IconSet.IsCustom)
						{
							return true;
						}
						break;
					}
					return true;
				case FormatConditionType.ContainsText:
				case FormatConditionType.NotContainsText:
				case FormatConditionType.BeginsWith:
				case FormatConditionType.EndsWith:
				{
					string text = item.Text;
					if (text != null && text.Length > 1 && text[0] == '=')
					{
						return true;
					}
					break;
				}
				case FormatConditionType.DataBar:
					if (bool_2)
					{
						return true;
					}
					return false;
				}
			}
		}
		return false;
	}

	internal void Copy(FormatConditionCollection formatConditionCollection_0, CopyOptions copyOptions_0)
	{
		bool_0 = formatConditionCollection_0.bool_0;
		arrayList_1 = new ArrayList(formatConditionCollection_0.arrayList_1.Count);
		arrayList_0 = new ArrayList(formatConditionCollection_0.Count);
		bool_1 = formatConditionCollection_0.bool_1;
		foreach (CellArea item in formatConditionCollection_0.arrayList_1)
		{
			CellArea cellArea2 = default(CellArea);
			cellArea2.StartRow = item.StartRow;
			cellArea2.StartColumn = item.StartColumn;
			cellArea2.EndRow = item.EndRow;
			cellArea2.EndColumn = item.EndColumn;
			arrayList_1.Add(cellArea2);
		}
		for (int i = 0; i < formatConditionCollection_0.Count; i++)
		{
			FormatCondition formatCondition = new FormatCondition(this);
			formatCondition.Copy(formatConditionCollection_0[i], copyOptions_0);
			arrayList_0.Add(formatCondition);
		}
	}

	/// <summary>
	///       Adds a formatting condition and effected cell rang to the FormatConditions
	///        The FormatConditions can contain up to three conditional formats.
	///        References to the other sheets are not allowed in the formulas of conditional formattin
	///       </summary>
	/// <param name="cellArea">Conditional formatted cell range.</param>
	/// <param name="type">Type of conditional formatting.It could be one of the members of FormatConditionType.</param>
	/// <param name="operatorType">Comparison operator.It could be one of the members of OperatorType.</param>
	/// <param name="formula1">The value or expression associated with conditional formatting.</param>
	/// <param name="formula2">The value or expression associated with conditional formatting</param>
	/// <returns>[0]:Formatting condition object index;[1] Effected cell rang index.</returns>
	/// <see cref="T:Aspose.Cells.OperatorType" />
	/// <set cref="T:Aspose.Cells.FormatConditionType" />
	public int[] Add(CellArea cellArea, FormatConditionType type, OperatorType operatorType, string formula1, string formula2)
	{
		return new int[2]
		{
			AddCondition(type, operatorType, formula1, formula2),
			arrayList_1.Add(cellArea)
		};
	}

	/// <summary>
	///       Adds a conditional formatted cell range.
	///       </summary>
	/// <param name="cellArea">Conditional formatted cell range.</param>
	/// <returns>Conditional formatted cell rang index.</returns>
	public int AddArea(CellArea cellArea)
	{
		int num = arrayList_1.Add(cellArea);
		if (num == 0)
		{
			for (int i = 0; i < method_0().Count; i++)
			{
				((FormatCondition)method_0()[i]).method_11();
			}
		}
		return num;
	}

	/// <summary>
	///       Adds a formatting condition.
	///       </summary>
	/// <param name="type">
	///   <set cref="T:Aspose.Cells.FormatConditionType" /> of conditinal formatting.It could be one of the members of FormatConditionType.</param>
	/// <param name="operatorType">The comparison <see cref="T:Aspose.Cells.OperatorType" />.It could be one of the members of OperatorType.</param>
	/// <param name="formula1">The value or expression associated with conditinal formatting.</param>
	/// <param name="formula2">The value or expression associated with conditinal formatting.</param>
	/// <returns>Formatting condition object index;</returns>
	public int AddCondition(FormatConditionType type, OperatorType operatorType, string formula1, string formula2)
	{
		FormatCondition formatCondition = new FormatCondition(this);
		formatCondition.Type = type;
		formatCondition.Operator = operatorType;
		formatCondition.Formula1 = formula1;
		formatCondition.Formula2 = formula2;
		arrayList_0.Add(formatCondition);
		formatCondition.Priority = worksheet_0.method_3();
		Worksheet worksheet = worksheet_0;
		worksheet.method_4(worksheet.method_3() + 1);
		return arrayList_0.Count - 1;
	}

	/// <summary>
	///       Add a format condition.
	///       </summary>
	/// <param name="type">Format condition type.</param>
	/// <returns>Formatting condition object index;</returns>
	public int AddCondition(FormatConditionType type)
	{
		FormatCondition formatCondition = new FormatCondition(this);
		formatCondition.Type = type;
		formatCondition.Priority = worksheet_0.method_3();
		Worksheet worksheet = worksheet_0;
		worksheet.method_4(worksheet.method_3() + 1);
		return arrayList_0.Add(formatCondition);
	}

	internal int AddCondition(FormatCondition formatCondition_0)
	{
		return arrayList_0.Add(formatCondition_0);
	}

	/// <summary>
	///       Gets the conditional formatted cell range by index.
	///       </summary>
	/// <param name="index">the index of the coditional formatted cell range.</param>
	/// <returns>the conditional formatted cell range</returns>
	public CellArea GetCellArea(int index)
	{
		method_11(index);
		return (CellArea)arrayList_1[index];
	}

	/// <summary>
	///       Removes conditional formatted cell range by index.
	///       </summary>
	/// <param name="index">The index of the conditional formatted cell range to be removed.</param>
	public void RemoveArea(int index)
	{
		method_11(index);
		arrayList_1.RemoveAt(index);
	}

	/// <summary>
	///       Remove conditional formatting int the range.
	///       </summary>
	/// <param name="startRow">The startRow of the range.</param>
	/// <param name="startColumn">The startColumn of the range.</param>
	/// <param name="totalRows">The number of rows of the range.</param>
	/// <param name="totalColumns">The number of columns of the range.</param>
	/// <returns>
	///       Returns TRUE, this FormatCondtionCollection should be removed.
	///       </returns>
	public bool RemoveArea(int startRow, int startColumn, int totalRows, int totalColumns)
	{
		if (arrayList_1 != null && arrayList_1.Count != 0)
		{
			CellArea ca = default(CellArea);
			ca.StartRow = startRow;
			ca.StartColumn = startColumn;
			ca.EndRow = startRow + totalRows - 1;
			ca.EndColumn = startColumn + totalColumns - 1;
			for (int num = arrayList_1.Count - 1; num >= 0; num--)
			{
				CellArea ca2 = (CellArea)arrayList_1[num];
				bool flag = false;
				CellArea cellArea = smethod_0(ca, ca2, out flag);
				if (!flag)
				{
					if (cellArea.StartRow > ca2.StartRow)
					{
						CellArea cellArea2 = default(CellArea);
						cellArea2.StartRow = ca2.StartRow;
						cellArea2.EndRow = cellArea.StartRow - 1;
						cellArea2.StartColumn = ca2.StartColumn;
						cellArea2.EndColumn = ca2.EndColumn;
						arrayList_1.Add(cellArea2);
					}
					if (cellArea.EndRow < ca2.EndRow)
					{
						CellArea cellArea3 = default(CellArea);
						cellArea3.StartRow = cellArea.EndRow + 1;
						cellArea3.EndRow = ca2.EndRow;
						cellArea3.StartColumn = ca2.StartColumn;
						cellArea3.EndColumn = ca2.EndColumn;
						arrayList_1.Add(cellArea3);
					}
					ca2.StartRow = cellArea.StartRow;
					ca2.EndRow = cellArea.EndRow;
					if (cellArea.StartColumn > ca2.StartColumn)
					{
						CellArea cellArea4 = default(CellArea);
						cellArea4.StartRow = ca2.StartRow;
						cellArea4.EndRow = ca2.EndRow;
						cellArea4.StartColumn = ca2.StartColumn;
						cellArea4.EndColumn = cellArea.StartColumn - 1;
						arrayList_1.Add(cellArea4);
					}
					if (cellArea.EndColumn < ca2.EndColumn)
					{
						CellArea cellArea5 = default(CellArea);
						cellArea5.StartRow = ca2.StartRow;
						cellArea5.EndRow = ca2.EndRow;
						cellArea5.StartColumn = cellArea.EndColumn + 1;
						cellArea5.EndColumn = ca2.EndColumn;
						arrayList_1.Add(cellArea5);
					}
					arrayList_1.RemoveAt(num);
				}
			}
			return arrayList_1.Count == 0;
		}
		return true;
	}

	internal static CellArea smethod_0(CellArea ca1, CellArea ca2, out bool flag)
	{
		CellArea result = default(CellArea);
		result.StartRow = ((ca1.StartRow < ca2.StartRow) ? ca2.StartRow : ca1.StartRow);
		result.StartColumn = ((ca1.StartColumn < ca2.StartColumn) ? ca2.StartColumn : ca1.StartColumn);
		result.EndRow = ((ca1.EndRow < ca2.EndRow) ? ca1.EndRow : ca2.EndRow);
		result.EndColumn = ((ca1.EndColumn < ca2.EndColumn) ? ca1.EndColumn : ca2.EndColumn);
		flag = result.StartRow > result.EndRow || result.StartColumn > result.EndColumn;
		return result;
	}

	/// <summary>
	///       Removes the formatting condition by index.
	///       </summary>
	/// <param name="index">The index of the formatting condition to be removed.</param>
	public void RemoveCondition(int index)
	{
		arrayList_0.RemoveAt(index);
	}

	[SpecialName]
	internal bool method_7()
	{
		foreach (FormatCondition item in arrayList_0)
		{
			switch (item.Type)
			{
			case FormatConditionType.ContainsText:
			case FormatConditionType.NotContainsText:
			case FormatConditionType.NotContainsBlanks:
			case FormatConditionType.NotContainsErrors:
				return true;
			}
		}
		return false;
	}

	internal bool method_8()
	{
		foreach (FormatCondition item in arrayList_0)
		{
			byte[] array = item.method_0();
			if (array == null || !Class1674.smethod_24(conditionalFormattingCollection_0.worksheet_0.method_2(), array, -1, array.Length - 1))
			{
				if ((item.Operator == OperatorType.Between || item.Operator == OperatorType.NotBetween) && item.method_4() != null)
				{
					array = item.method_4();
					if (array != null && Class1674.smethod_24(conditionalFormattingCollection_0.worksheet_0.method_2(), array, -1, array.Length - 1))
					{
						return true;
					}
				}
				continue;
			}
			return true;
		}
		return false;
	}

	internal int[] method_9()
	{
		int num = 0;
		int num2 = 0;
		if (arrayList_1.Count == 0)
		{
			return null;
		}
		for (int i = 0; i < arrayList_1.Count; i++)
		{
			CellArea cellArea = (CellArea)arrayList_1[i];
			if (i == 0)
			{
				num = cellArea.StartRow;
				num2 = cellArea.StartColumn;
				continue;
			}
			if (num > cellArea.StartRow)
			{
				num = cellArea.StartRow;
			}
			if (num2 > cellArea.StartColumn)
			{
				num2 = cellArea.StartColumn;
			}
		}
		return new int[2] { num, num2 };
	}

	internal void Read(byte[] byte_0, int int_0)
	{
		bool_0 = (byte_0[2] & 1) != 0;
		BitConverter.ToInt16(byte_0, 12);
		for (int i = 14; i < int_0; i += 8)
		{
			CellArea cellArea = default(CellArea);
			cellArea.StartRow = BitConverter.ToUInt16(byte_0, i);
			cellArea.StartColumn = BitConverter.ToUInt16(byte_0, i + 4);
			cellArea.EndRow = BitConverter.ToUInt16(byte_0, i + 2);
			cellArea.EndColumn = BitConverter.ToUInt16(byte_0, i + 6);
			arrayList_1.Add(cellArea);
		}
	}

	internal void method_10()
	{
		foreach (FormatCondition item in arrayList_0)
		{
			item.method_11();
		}
	}

	private void method_11(int int_0)
	{
		if (int_0 < 0 || int_0 >= arrayList_1.Count)
		{
			throw new ArgumentException("Invalid conditional formatted cell range index:" + int_0);
		}
	}

	internal void method_12(bool bool_2)
	{
		int[] array = method_9();
		if (array == null)
		{
			return;
		}
		int int_ = array[0];
		int int_2 = array[1];
		foreach (FormatCondition item in method_0())
		{
			item?.method_25(bool_2, int_, int_2);
		}
	}
}
