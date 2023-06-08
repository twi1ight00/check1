using System.Collections;

namespace Aspose.Cells;

/// <summary>
///       Encapsulates a collection of <see cref="T:Aspose.Cells.VerticalPageBreak" /> objects.
///       </summary>
public class VerticalPageBreakCollection : CollectionBase
{
	/// <summary>
	///        Gets the <see cref="T:Aspose.Cells.VerticalPageBreak" /> element at the specified index.
	///        </summary>
	/// <param name="index">The zero based index of the element.</param>
	/// <returns>The element at the specified index.</returns>
	public VerticalPageBreak this[int index] => (VerticalPageBreak)base.InnerList[index];

	/// <summary>
	///       Gets the <see cref="T:Aspose.Cells.VerticalPageBreak" /> element with the specified cell name.
	///       </summary>
	/// <param name="cellName">Cell name.</param>
	/// <returns>The element with the specified cell name.</returns>
	public VerticalPageBreak this[string cellName]
	{
		get
		{
			CellsHelper.CellNameToIndex(cellName, out var row, out var column);
			int num = 0;
			VerticalPageBreak verticalPageBreak;
			while (true)
			{
				if (num < base.InnerList.Count)
				{
					verticalPageBreak = this[num];
					if (verticalPageBreak.Column == column && verticalPageBreak.StartRow <= row && verticalPageBreak.EndRow >= row)
					{
						break;
					}
					num++;
					continue;
				}
				return null;
			}
			return verticalPageBreak;
		}
	}

	internal VerticalPageBreakCollection()
	{
	}

	/// <summary>
	///       Adds a vertical page break to the collection.
	///       </summary>
	/// <param name="startRow">Start row index, zero based.</param>
	/// <param name="endRow">End row index, zero based.</param>
	/// <param name="column">Column index, zero based.</param>
	/// <returns>
	///   <see cref="T:Aspose.Cells.VerticalPageBreak" /> object index.</returns>
	/// <remarks>This method is used to add a vertical pagebreak within a print area.</remarks>
	public int Add(int startRow, int endRow, int column)
	{
		if (base.InnerList.Count >= 1024)
		{
			throw new CellsException(ExceptionType.Limitation, "The count of VPageBreaks cannot be larger than 1024.");
		}
		VerticalPageBreak verticalPageBreak = null;
		int num = 0;
		while (true)
		{
			if (num < base.InnerList.Count)
			{
				verticalPageBreak = this[num];
				if (verticalPageBreak.Column == column && verticalPageBreak.StartRow <= startRow && verticalPageBreak.EndRow >= startRow)
				{
					break;
				}
				num++;
				continue;
			}
			verticalPageBreak = new VerticalPageBreak(column);
			verticalPageBreak.method_0(startRow);
			verticalPageBreak.method_1(endRow);
			base.InnerList.Add(verticalPageBreak);
			return base.InnerList.Count - 1;
		}
		verticalPageBreak.method_0(startRow);
		verticalPageBreak.method_1(endRow);
		return num;
	}

	internal void method_0(int int_0, int int_1, int int_2)
	{
		VerticalPageBreak verticalPageBreak = new VerticalPageBreak(int_2);
		verticalPageBreak.method_0(int_0);
		verticalPageBreak.method_1(int_1);
		base.InnerList.Add(verticalPageBreak);
	}

	/// <summary>
	///       Adds a vertical page break to the collection.
	///       </summary>
	/// <param name="column">Cell column index, zero based.</param>
	/// <returns>
	///   <see cref="T:Aspose.Cells.VerticalPageBreak" /> object index.</returns>
	/// <remarks>Page break is added in the top left of the cell.
	///       Please set a horizontal page break and a vertical page break concurrently.</remarks>
	public int Add(int column)
	{
		return Add(0, 1048575, column);
	}

	/// <summary>
	///       Adds a vertical page break to the collection.
	///       </summary>
	/// <param name="row">Cell row index, zero based.</param>
	/// <param name="column">Cell column index, zero based.</param>
	/// <returns>
	///   <see cref="T:Aspose.Cells.VerticalPageBreak" /> object index.</returns>
	/// <remarks>Page break is added in the top left of the cell.
	///       Please set a horizontal page break and a vertical page break concurrently.</remarks>
	public int Add(int row, int column)
	{
		return Add(0, 1048575, column);
	}

	/// <summary>
	///       Adds a vertical page break to the collection.
	///       </summary>
	/// <param name="cellName">Cell name.</param>
	/// <returns>
	///   <see cref="T:Aspose.Cells.VerticalPageBreak" /> object index.</returns>
	/// <remarks>Page break is added in the top left of the cell.
	///       Please set a horizontal page break and a vertical page break concurrently.</remarks>
	public int Add(string cellName)
	{
		int row = 0;
		int column = 0;
		CellsHelper.CellNameToIndex(cellName, out row, out column);
		return Add(0, 65535, column);
	}

	internal void Copy(VerticalPageBreakCollection verticalPageBreakCollection_0)
	{
		for (int i = 0; i < verticalPageBreakCollection_0.InnerList.Count; i++)
		{
			VerticalPageBreak verticalPageBreak = verticalPageBreakCollection_0[i];
			method_0(verticalPageBreak.StartRow, verticalPageBreak.EndRow, verticalPageBreak.Column);
		}
	}

	/// <summary>
	///       Removes the VPageBreak element at a specified name.
	///       </summary>
	/// <param name="index">Element index, zero based.</param>
	public new void RemoveAt(int index)
	{
		_ = (VerticalPageBreak)base.InnerList[index];
		base.RemoveAt(index);
	}
}
