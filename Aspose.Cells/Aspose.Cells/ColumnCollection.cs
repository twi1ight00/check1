using System;
using System.Collections;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ns2;
using ns27;

namespace Aspose.Cells;

/// <summary>
///       Collects the <seealso cref="T:Aspose.Cells.Column" /> objects that represent the individual columns in a worksheet.
///       </summary>
/// <example>
///   <code>
///
///       [C#]
///
///       //Instantiating a Workbook object
///       Workbook workbook = new Workbook();
///
///       //Obtaining the reference of the first worksheet
///       Worksheet worksheet = workbook.Worksheets[0];
///
///       //Add new Style to Workbook
///       Style style = workbook.Styles[workbook.Styles.Add()];
///
///       //Setting the background color to Blue
///       style.ForegroundColor = Color.Blue;
///
///       //setting Background Pattern
///       style.Pattern = BackgroundType.Solid;
///
///       //New Style Flag
///       StyleFlag styleFlag = new StyleFlag();
///
///       //Set All Styles
///       styleFlag.All = true;
///
///       //Change the default width of first ten columns
///       for (int i = 0; i &lt; 10; i++)
///       {
///           worksheet.Cells.Columns[i].Width = 20;
///       }
///
///       //Get the Column with non default formatting
///       ColumnCollection columns = worksheet.Cells.Columns;
///
///       foreach (Column column in columns)
///       {
///           //Apply Style to first ten Columns
///           column.ApplyStyle(style, styleFlag);
///       }
///
///       //Saving the Excel file
///       workbook.Save("D:\\book1.xls");
///
///       [VB.NET]
///
///       'Instantiating a Workbook object
///       Dim workbook As New Workbook()
///
///       'Obtaining the reference of the first worksheet
///       Dim worksheet As Worksheet = workbook.Worksheets(0)
///
///       'Add new Style to Workbook
///       Dim style As Style = workbook.Styles(workbook.Styles.Add())
///
///       'Setting the background color to Blue
///       style.ForegroundColor = Color.Blue
///
///       'setting Background Pattern
///       style.Pattern = BackgroundType.Solid
///
///       'New Style Flag
///       Dim styleFlag As New StyleFlag()
///
///       'Set All Styles
///       styleFlag.All = True
///
///       'Change the default width of first ten columns
///       For i As Integer = 0 To 9
///           worksheet.Cells.Columns(i).Width = 20
///       Next i
///
///       'Get the Column with non default formatting
///       Dim columns As ColumnCollection = worksheet.Cells.Columns
///
///       For Each column As Column In columns
///           'Apply Style to first ten Columns
///           column.ApplyStyle(style, styleFlag)
///       Next column
///
///       'Saving the Excel file
///       workbook.Save("D:\book1.xls")
///
///       </code>
/// </example>
public class ColumnCollection : CollectionBase
{
	internal Column column_0;

	private double double_0;

	private Worksheet worksheet_0;

	/// <summary>
	///       Gets a <seealso cref="T:Aspose.Cells.Column" /> object by column index. The Column object of given column index will be instantiated if it does not exist before.
	///       </summary>
	public Column this[int columnIndex]
	{
		get
		{
			int arrIndex = -1;
			if (!method_8(columnIndex, out arrIndex))
			{
				Column column = new Column((short)columnIndex, worksheet_0, double_0, column_0);
				base.InnerList.Insert(arrIndex, column);
				return column;
			}
			return (Column)base.InnerList[arrIndex];
		}
	}

	internal double Width
	{
		get
		{
			return double_0;
		}
		set
		{
			double_0 = value;
		}
	}

	internal ColumnCollection(Worksheet worksheet_1, double double_1)
	{
		worksheet_0 = worksheet_1;
		double_0 = double_1;
	}

	[SpecialName]
	internal Column method_0()
	{
		if (column_0 == null)
		{
			column_0 = new Column(0, worksheet_0, double_0);
		}
		return column_0;
	}

	internal int method_1(int int_0)
	{
		if (column_0 != null && column_0.Index <= int_0 && column_0.method_10())
		{
			return column_0.method_5();
		}
		return -1;
	}

	internal bool method_2(int int_0)
	{
		if (column_0 != null && column_0.Index <= int_0)
		{
			return column_0.IsHidden;
		}
		return false;
	}

	internal double method_3(int int_0, bool bool_0)
	{
		if (column_0 != null && column_0.Index <= int_0)
		{
			if (bool_0)
			{
				return column_0.double_0;
			}
			if (!column_0.IsHidden)
			{
				return column_0.double_0;
			}
			return 0.0;
		}
		return double_0;
	}

	internal int method_4(int int_0, int int_1, bool bool_0, bool bool_1)
	{
		bool flag = worksheet_0.ViewType == ViewType.PageLayoutView;
		double num = ((!bool_1 || !flag) ? 1.0 : 1.05);
		int num2 = 0;
		for (int i = int_0; i <= int_1; i++)
		{
			double num3 = double_0;
			if (column_0 != null && column_0.Index <= i)
			{
				num3 = ((!bool_0) ? (column_0.IsHidden ? 0.0 : column_0.double_0) : column_0.double_0);
			}
			num2 += Class1677.smethod_1(num3, worksheet_0.method_2());
		}
		return (int)((double)num2 * num + 0.5);
	}

	/// <summary>
	///       Gets the column object by the index.
	///       </summary>
	/// <param name="index">
	/// </param>
	/// <returns>Returns the column object.</returns>
	/// <remarks>NOTE: This member is now obsolete. Instead, 
	///       please use Columns.GetColumnByIndex() method.
	///       This property will be removed 12 months later since June 2010. 
	///       Aspose apologizes for any inconvenience you may have experienced.</remarks>
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("Use Columns.GetColumnByIndex() method instead.")]
	public Column GetByIndex(int index)
	{
		return (Column)base.InnerList[index];
	}

	/// <summary>
	///       Gets the <see cref="T:Aspose.Cells.Column" /> object by the position in the list.
	///       </summary>
	/// <param name="index">The position in the list.</param>
	/// <returns>Returns the column object.</returns>
	public Column GetColumnByIndex(int index)
	{
		return (Column)base.InnerList[index];
	}

	internal Column method_5(int int_0)
	{
		int num = method_7(int_0);
		if (num == -1)
		{
			return null;
		}
		return (Column)base.List[num];
	}

	internal Column method_6(int int_0)
	{
		Column column = new Column((short)int_0, worksheet_0, double_0);
		base.InnerList.Add(column);
		return column;
	}

	internal int method_7(int int_0)
	{
		if (base.Count == 0)
		{
			return -1;
		}
		int num = 0;
		int num2 = base.Count - 1;
		int num3 = 0;
		Column column = null;
		while (true)
		{
			if (num <= num2)
			{
				num3 = (num + num2) / 2;
				column = (Column)base.InnerList[num3];
				if (column.Index == int_0)
				{
					break;
				}
				if (column.Index < int_0)
				{
					num = num3 + 1;
				}
				else
				{
					num2 = num3 - 1;
				}
				continue;
			}
			return -1;
		}
		return num3;
	}

	internal bool method_8(int columnIndex, out int arrIndex)
	{
		if (base.Count == 0)
		{
			arrIndex = 0;
			return false;
		}
		int num = 0;
		int num2 = base.Count - 1;
		int num3 = 0;
		Column column = null;
		while (true)
		{
			if (num <= num2)
			{
				num3 = (num + num2) / 2;
				column = (Column)base.InnerList[num3];
				if (column.Index == columnIndex)
				{
					break;
				}
				if (column.Index < columnIndex)
				{
					num = num3 + 1;
				}
				else
				{
					num2 = num3 - 1;
				}
				continue;
			}
			if (column.Index < columnIndex)
			{
				arrIndex = num3 + 1;
			}
			else
			{
				arrIndex = num3;
			}
			return false;
		}
		arrIndex = num3;
		return true;
	}

	internal int method_9(int int_0, int int_1, int int_2)
	{
		if (base.Count == 0)
		{
			return -1;
		}
		int num = 0;
		while (true)
		{
			if (int_1 <= int_2)
			{
				num = (int_1 + int_2) / 2;
				Column column = (Column)base.InnerList[num];
				if (column.Index == int_0)
				{
					break;
				}
				if (column.Index < int_0)
				{
					int_1 = num + 1;
				}
				else
				{
					int_2 = num - 1;
				}
				continue;
			}
			return -1;
		}
		return num;
	}

	internal void method_10(int int_0, int int_1)
	{
		if (base.Count == 0)
		{
			return;
		}
		Column column = (Column)base.InnerList[base.Count - 1];
		int num = 16383;
		bool flag = 16383 == column.Index;
		for (int i = 0; i < int_1; i++)
		{
			int num2 = method_7(int_0 + i);
			if (num2 != -1)
			{
				base.InnerList.RemoveAt(num2);
			}
		}
		for (int j = 0; j < base.Count; j++)
		{
			Column column2 = (Column)base.InnerList[j];
			if (column2.Index > int_0)
			{
				column2.method_0(column2.Index - int_1);
			}
		}
		if (flag && int_0 + int_1 - 1 < num)
		{
			for (int k = 1; k <= int_1; k++)
			{
				Column column3 = new Column((short)(column.Index + k), worksheet_0, double_0);
				column3.method_6(column.method_5());
				column3.method_4(column.method_3());
				column3.Width = column.Width;
				base.InnerList.Add(column3);
			}
		}
	}

	internal void InsertColumns(int int_0, int int_1)
	{
		if (base.Count == 0)
		{
			return;
		}
		for (int i = 0; i < base.Count; i++)
		{
			Column columnByIndex = GetColumnByIndex(i);
			if (columnByIndex.Index < int_0)
			{
				continue;
			}
			if (columnByIndex.Index + int_1 <= 16383)
			{
				columnByIndex.method_0(columnByIndex.Index + int_1);
				continue;
			}
			while (i < base.Count)
			{
				RemoveAt(i);
			}
			break;
		}
		if (int_0 <= 0)
		{
			return;
		}
		int num = method_7(int_0 - 1);
		if (num != -1)
		{
			Column columnByIndex2 = GetColumnByIndex(num);
			for (int j = 0; j < int_1; j++)
			{
				Column column = new Column((short)(int_0 + j), worksheet_0, double_0);
				column.method_6(columnByIndex2.method_5());
				column.method_4(columnByIndex2.method_3());
				column.Width = columnByIndex2.Width;
				base.InnerList.Insert(num + j + 1, column);
			}
		}
	}

	internal ArrayList method_11()
	{
		ArrayList arrayList = new ArrayList();
		Column column = column_0;
		int num = 16383;
		if (column != null)
		{
			if (column.method_18())
			{
				Column column2 = new Column(column.Index, worksheet_0, double_0, column);
				column = column2;
				num = column2.Index;
				if (num > 256)
				{
					num = 256;
				}
			}
			else
			{
				column = null;
			}
		}
		int num2 = 0;
		int num3 = 0;
		int num4;
		for (num4 = 0; num4 < base.Count; num4++)
		{
			Column columnByIndex = GetColumnByIndex(num4);
			if (columnByIndex.Index - num3 != 0 && column != null && columnByIndex.Index > num)
			{
				if (num3 < num)
				{
					num3 = num;
				}
				Class617 @class = new Class617();
				@class.method_4(column, worksheet_0.method_2().method_72(), worksheet_0.method_2().method_71(), num3, columnByIndex.Index - 1);
				arrayList.Add(@class);
			}
			num2 = columnByIndex.Index;
			int num5 = 0;
			for (num4++; num4 < base.Count; num4++)
			{
				Column columnByIndex2 = GetColumnByIndex(num4);
				if (columnByIndex2.Index == columnByIndex.Index + num5 + 1 && columnByIndex.method_9(columnByIndex2))
				{
					num5++;
					continue;
				}
				num4--;
				break;
			}
			Class617 class2 = new Class617();
			class2.method_4(columnByIndex, worksheet_0.method_2().method_72(), worksheet_0.method_2().method_71(), num2, num2 + num5);
			arrayList.Add(class2);
			num3 = num2 + num5 + 1;
		}
		if (column != null)
		{
			if (num3 < num)
			{
				num3 = num;
			}
			Class617 class3 = new Class617();
			class3.method_4(column, worksheet_0.method_2().method_72(), worksheet_0.method_2().method_71(), num3, 256);
			arrayList.Add(class3);
		}
		return arrayList;
	}

	internal void Copy(ColumnCollection columnCollection_0, CopyOptions copyOptions_0)
	{
		double_0 = columnCollection_0.double_0;
		base.InnerList.Clear();
		for (int i = 0; i < columnCollection_0.Count; i++)
		{
			Column columnByIndex = columnCollection_0.GetColumnByIndex(i);
			Column column = method_6(columnByIndex.Index);
			column.Copy(columnByIndex, copyOptions_0);
		}
		if (columnCollection_0.column_0 != null)
		{
			column_0 = new Column(columnCollection_0.column_0.Index, worksheet_0, double_0);
			column_0.Copy(columnCollection_0.column_0, copyOptions_0);
		}
	}
}
