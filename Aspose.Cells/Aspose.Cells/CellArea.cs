using System;
using System.Text;

namespace Aspose.Cells;

/// <summary>
///       Represent an area of cells.
///       </summary>
/// <example>
///   <code>
///
///       [C#]
///
///       //Create Cell Area
///       CellArea ca = new CellArea();
///       ca.StartRow = 0;
///       ca.EndRow = 0;
///       ca.StartColumn = 0;
///       ca.EndColumn = 0;
///
///       [VB.NET]
///
///       'Create Cell Area
///       Dim ca As CellArea = New CellArea()
///       ca.StartRow = 0
///       ca.EndRow = 0
///       ca.StartColumn = 0
///       ca.EndColumn = 0
///
///       </code>
/// </example>
public struct CellArea : IComparable
{
	/// <summary>
	///       Gets or set the start row of this area.
	///       </summary>
	public int StartRow;

	/// <summary>
	///       Gets or set the end row of this area.
	///       </summary>
	public int EndRow;

	/// <summary>
	///       Gets or set the start column of this area.
	///       </summary>
	public int StartColumn;

	/// <summary>
	///       Gets or set the end column of this area.
	///       </summary>
	public int EndColumn;

	/// <summary>
	///       Internal use only.
	///       </summary>
	/// <param name="obj">
	/// </param>
	/// <returns>
	/// </returns>
	public int CompareTo(object obj)
	{
		CellArea cellArea = (CellArea)obj;
		if (StartRow > cellArea.StartRow)
		{
			return 1;
		}
		if (StartRow < cellArea.StartRow)
		{
			return -1;
		}
		if (StartColumn > cellArea.StartColumn)
		{
			return 1;
		}
		if (StartColumn < cellArea.StartColumn)
		{
			return -1;
		}
		return 0;
	}

	/// <summary>
	///       Returns a string represents the current Worksheet object.
	///       </summary>
	/// <returns>
	/// </returns>
	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Aspose.Cells.CellArea(");
		stringBuilder.Append(CellsHelper.CellIndexToName(StartRow, StartColumn));
		stringBuilder.Append(":");
		stringBuilder.Append(CellsHelper.CellIndexToName(EndRow, EndColumn));
		stringBuilder.Append(")");
		stringBuilder.Append("[");
		stringBuilder.Append(StartRow);
		stringBuilder.Append(",");
		stringBuilder.Append(StartColumn);
		stringBuilder.Append(",");
		stringBuilder.Append(EndRow);
		stringBuilder.Append(",");
		stringBuilder.Append(EndColumn);
		stringBuilder.Append("]");
		return stringBuilder.ToString();
	}

	internal static CellArea CreateCellArea(CellArea cellArea_0)
	{
		CellArea result = default(CellArea);
		result.StartRow = cellArea_0.StartRow;
		result.StartColumn = cellArea_0.StartColumn;
		result.EndRow = cellArea_0.EndRow;
		result.EndColumn = cellArea_0.EndColumn;
		return result;
	}

	/// <summary>
	///       Creat a cell area.
	///       </summary>
	/// <param name="startRow">The start row.</param>
	/// <param name="startColumn">The start column.</param>
	/// <param name="endRow">The end row.</param>
	/// <param name="endColumn">The end column.</param>
	/// <returns>Return a <see cref="T:Aspose.Cells.CellArea" />.</returns>
	public static CellArea CreateCellArea(int startRow, int startColumn, int endRow, int endColumn)
	{
		CellArea result = default(CellArea);
		result.StartRow = startRow;
		result.StartColumn = startColumn;
		result.EndRow = endRow;
		result.EndColumn = endColumn;
		return result;
	}

	/// <summary>
	///       Creat a cell area.
	///       </summary>
	/// <param name="startCellName">The top-left cell of the range.</param>
	/// <param name="endCellName">The bottom-right cell of the range.</param>
	/// <returns>Return a <see cref="T:Aspose.Cells.CellArea" />.</returns>
	public static CellArea CreateCellArea(string startCellName, string endCellName)
	{
		CellArea result = default(CellArea);
		CellsHelper.CellNameToIndex(startCellName, out var row, out var column);
		result.StartRow = row;
		result.StartColumn = column;
		CellsHelper.CellNameToIndex(endCellName, out row, out column);
		result.EndRow = row;
		result.EndColumn = column;
		return result;
	}
}
