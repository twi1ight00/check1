using System.Collections;

namespace Aspose.Cells;

/// <summary>
///       Encapsulates a collection of <see cref="T:Aspose.Cells.HorizontalPageBreak" /> objects.
///       </summary>
/// <example>
///   <code>
///       [C#]
///       //Add a pagebreak at G5
///       excel.Worksheets[0].HorizontalPageBreaks.Add("G5");
///       excel.Worksheets[0].VerticalPageBreaks.Add("G5");
///
///       [VB]
///       'Add a pagebreak at G5
///       excel.Worksheets(0).HorizontalPageBreaks.Add("G5")
///       excel.Worksheets(0).VerticalPageBreaks.Add("G5")
///       </code>
/// </example>
public class HorizontalPageBreakCollection : CollectionBase
{
	/// <summary>
	///        Gets the <see cref="T:Aspose.Cells.HorizontalPageBreak" /> element at the specified index.
	///        </summary>
	/// <param name="index">The zero based index of the element.</param>
	/// <returns>The element at the specified index.</returns>
	public HorizontalPageBreak this[int index] => (HorizontalPageBreak)base.InnerList[index];

	/// <summary>
	///       Gets the <see cref="T:Aspose.Cells.HorizontalPageBreak" /> element with the specified cell name.
	///       </summary>
	/// <param name="cellName">Cell name.</param>
	/// <returns>The element with the specified cell name.</returns>
	public HorizontalPageBreak this[string cellName]
	{
		get
		{
			CellsHelper.CellNameToIndex(cellName, out var row, out var column);
			int num = 0;
			HorizontalPageBreak horizontalPageBreak;
			while (true)
			{
				if (num < base.InnerList.Count)
				{
					horizontalPageBreak = this[num];
					if (horizontalPageBreak.Row == row && horizontalPageBreak.StartColumn <= column && horizontalPageBreak.EndColumn >= column)
					{
						break;
					}
					num++;
					continue;
				}
				return null;
			}
			return horizontalPageBreak;
		}
	}

	internal HorizontalPageBreakCollection()
	{
	}

	/// <summary>
	///       Adds a horizontal page break to the collection.
	///       </summary>
	/// <param name="row">Row index, zero based.</param>
	/// <param name="startColumn">Start column index, zero based.</param>\
	///       <param name="endColumn">End column index, zero based.</param><returns><see cref="T:Aspose.Cells.HorizontalPageBreak" /> object index.</returns><remarks>This method is used to add a horizontal pagebreak within a print area.</remarks>
	public int Add(int row, int startColumn, int endColumn)
	{
		if (base.InnerList.Count >= 1024)
		{
			throw new CellsException(ExceptionType.Limitation, "The count of HPageBreaks cannot be larger than 1024.");
		}
		HorizontalPageBreak horizontalPageBreak = null;
		int num = 0;
		while (true)
		{
			if (num < base.InnerList.Count)
			{
				horizontalPageBreak = this[num];
				if (horizontalPageBreak.Row == row && horizontalPageBreak.StartColumn <= startColumn && horizontalPageBreak.EndColumn >= startColumn)
				{
					break;
				}
				num++;
				continue;
			}
			horizontalPageBreak = new HorizontalPageBreak(row);
			horizontalPageBreak.method_0(startColumn);
			horizontalPageBreak.method_1(endColumn);
			base.InnerList.Add(horizontalPageBreak);
			return base.InnerList.Count - 1;
		}
		horizontalPageBreak.method_0(startColumn);
		horizontalPageBreak.method_1(endColumn);
		return num;
	}

	internal void method_0(int int_0, int int_1, int int_2)
	{
		HorizontalPageBreak horizontalPageBreak = new HorizontalPageBreak(int_0);
		horizontalPageBreak.method_0(int_1);
		horizontalPageBreak.method_1(int_2);
		base.InnerList.Add(horizontalPageBreak);
	}

	/// <summary>
	///       Adds a horizontal page break to the collection.
	///       </summary>
	/// <param name="row">Cell row index, zero based.</param>
	/// <returns>
	///   <see cref="T:Aspose.Cells.HorizontalPageBreak" /> object index.</returns>
	/// <remarks>Page break is added in the top left of the cell.
	///       Please set a horizontal page break and a vertical page break concurrently.</remarks>
	public int Add(int row)
	{
		return Add(row, 0, 16383);
	}

	/// <summary>
	///       Adds a horizontal page break to the collection.
	///       </summary>
	/// <param name="row">Cell row index, zero based.</param>
	/// <param name="column">Cell column index, zero based.</param>
	/// <returns>
	///   <see cref="T:Aspose.Cells.HorizontalPageBreak" /> object index.</returns>
	/// <remarks>Page break is added in the top left of the cell.
	///       Please set a horizontal page break and a vertical page break concurrently.</remarks>
	public int Add(int row, int column)
	{
		return Add(row, 0, 16383);
	}

	/// <summary>
	///       Adds a horizontal page break to the collection.
	///       </summary>
	/// <param name="cellName">Cell name.</param>
	/// <returns>
	///   <see cref="T:Aspose.Cells.HorizontalPageBreak" /> object index.</returns>
	/// <remarks>Page break is added in the top left of the cell.
	///       Please set a horizontal page break and a vertical page break concurrently.</remarks>
	public int Add(string cellName)
	{
		int row = 0;
		int column = 0;
		CellsHelper.CellNameToIndex(cellName, out row, out column);
		return Add(row, 0, 255);
	}

	internal void Copy(HorizontalPageBreakCollection horizontalPageBreakCollection_0)
	{
		for (int i = 0; i < horizontalPageBreakCollection_0.InnerList.Count; i++)
		{
			HorizontalPageBreak horizontalPageBreak = horizontalPageBreakCollection_0[i];
			Add(horizontalPageBreak.Row, horizontalPageBreak.StartColumn, horizontalPageBreak.EndColumn);
		}
	}

	/// <summary>
	///       Removes the HPageBreak element at a specified name.
	///       </summary>
	/// <param name="index">Element index, zero based.</param>
	public new void RemoveAt(int index)
	{
		_ = (HorizontalPageBreak)base.InnerList[index];
		base.RemoveAt(index);
	}

	internal int method_1(int int_0)
	{
		int num = 0;
		while (true)
		{
			if (num < base.InnerList.Count)
			{
				HorizontalPageBreak horizontalPageBreak = (HorizontalPageBreak)base.InnerList[num];
				if (horizontalPageBreak.Row == int_0)
				{
					break;
				}
				num++;
				continue;
			}
			return -1;
		}
		return num;
	}

	internal void InsertRows(int int_0, int int_1)
	{
		for (int i = 0; i < base.InnerList.Count; i++)
		{
			HorizontalPageBreak horizontalPageBreak = (HorizontalPageBreak)base.InnerList[i];
			if (horizontalPageBreak.Row < int_0)
			{
				continue;
			}
			if (int_1 < 0)
			{
				if (int_0 - int_1 > horizontalPageBreak.Row)
				{
					base.InnerList.RemoveAt(i--);
					continue;
				}
				int num = horizontalPageBreak.Row + int_1;
				if (num < int_0)
				{
					num = int_0;
				}
				horizontalPageBreak.method_2(num);
			}
			else
			{
				horizontalPageBreak.method_2(horizontalPageBreak.Row + int_1);
			}
		}
	}
}
