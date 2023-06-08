using System.Collections;
using System.Runtime.CompilerServices;
using Aspose.Cells.Drawing;
using ns2;

namespace Aspose.Cells;

/// <summary>
///       Encapsulates a collection of <see cref="T:Aspose.Cells.Comment" /> objects.
///       </summary>
/// <example>
///   <code>
///       [C#]
///
///       Workbook workbook = new Workbook();
///
///       CommentCollection comments = workbook.Worksheets[0].Comments;
///
///
///       [Visual Basic]
///
///       Dim workbook as Workbook = new Workbook()
///
///       Dim comments as CommentCollection = workbook.Worksheets(0).Comments
///       </code>
/// </example>
public class CommentCollection : CollectionBase
{
	private Worksheet worksheet_0;

	/// <summary>
	///        Gets the <see cref="T:Aspose.Cells.Comment" /> element at the specified index.
	///        </summary>
	/// <param name="index">The zero based index of the element.</param>
	/// <returns>The element at the specified index.</returns>
	public Comment this[int index] => (Comment)base.InnerList[index];

	/// <summary>
	///       Gets the <see cref="T:Aspose.Cells.Comment" /> element at the specified cell.
	///       </summary>
	/// <param name="cellName">Cell name.</param>
	/// <returns>The element at the specified cell.</returns>
	public Comment this[string cellName]
	{
		get
		{
			CellsHelper.CellNameToIndex(cellName, out var row, out var column);
			int num = 0;
			Comment comment;
			while (true)
			{
				if (num < base.InnerList.Count)
				{
					comment = (Comment)base.InnerList[num];
					if (row == comment.Row && column == comment.Column)
					{
						break;
					}
					num++;
					continue;
				}
				return null;
			}
			return comment;
		}
	}

	/// <summary>
	///       Gets the <see cref="T:Aspose.Cells.Comment" /> element at the specified row index and column index.
	///       </summary>
	/// <param name="row">Row index.</param>
	/// <param name="column">Column index.</param>
	/// <returns>The element at the specified cell.</returns>
	public Comment this[int row, int column]
	{
		get
		{
			Class1677.CheckCell(row, column);
			int num = 0;
			Comment comment;
			while (true)
			{
				if (num < base.InnerList.Count)
				{
					comment = (Comment)base.InnerList[num];
					if (row == comment.Row && column == comment.Column)
					{
						break;
					}
					num++;
					continue;
				}
				return null;
			}
			return comment;
		}
	}

	internal CommentCollection(Worksheet worksheet_1)
	{
		worksheet_0 = worksheet_1;
	}

	[SpecialName]
	internal Worksheet method_0()
	{
		return worksheet_0;
	}

	/// <summary>
	///       Adds a comment to the collection.
	///       </summary>
	/// <param name="row">Cell row index.</param>
	/// <param name="column">Cell column index.</param>
	/// <returns>
	///   <see cref="T:Aspose.Cells.Comment" /> object index.</returns>
	public int Add(int row, int column)
	{
		Class1677.CheckCell(row, column);
		int num = 0;
		while (true)
		{
			if (num < base.InnerList.Count)
			{
				Comment comment = (Comment)base.InnerList[num];
				if (row == comment.Row && column == comment.Column)
				{
					break;
				}
				num++;
				continue;
			}
			Comment comment2 = new Comment(this, row, column);
			comment2.method_3();
			base.InnerList.Add(comment2);
			worksheet_0.Shapes.Add(comment2.CommentShape);
			return base.InnerList.Count - 1;
		}
		return num;
	}

	/// <summary>
	///       Adds a comment to the collection.
	///       </summary>
	/// <param name="cellName">Cell name.</param>
	/// <returns>
	///   <see cref="T:Aspose.Cells.Comment" /> object index.</returns>
	public int Add(string cellName)
	{
		CellsHelper.CellNameToIndex(cellName, out var row, out var column);
		return Add(row, column);
	}

	internal int method_1(string string_0)
	{
		CellsHelper.CellNameToIndex(string_0, out var row, out var column);
		Comment comment = new Comment(this, row, column);
		comment.method_3();
		base.InnerList.Add(comment);
		worksheet_0.Shapes.Add(comment.CommentShape);
		return base.InnerList.Count - 1;
	}

	internal void Add(Comment comment_0)
	{
		base.InnerList.Add(comment_0);
	}

	internal void Remove(Comment comment_0)
	{
		base.InnerList.Remove(comment_0);
	}

	/// <summary>
	///       Removes the comment of the specific cell.
	///       </summary>
	/// <param name="cellName">The name of cell which contains a comment.</param>
	public void RemoveAt(string cellName)
	{
		CellsHelper.CellNameToIndex(cellName, out var row, out var column);
		for (int i = 0; i < base.Count; i++)
		{
			Comment comment = this[i];
			if (comment.Row == row && comment.Column == column)
			{
				worksheet_0.Shapes.method_26(comment.CommentShape);
			}
		}
	}

	/// <summary>
	///       Removes the comment of the specific cell.
	///       </summary>
	/// <param name="row">The row index.</param>
	/// <param name="column">the column index.</param>
	public void RemoveAt(int row, int column)
	{
		for (int i = 0; i < base.Count; i++)
		{
			Comment comment = this[i];
			if (comment.Row == row && comment.Column == column)
			{
				worksheet_0.Shapes.method_26(comment.CommentShape);
			}
		}
	}

	/// <summary>
	///       Removes all comments;
	///       </summary>
	public new void Clear()
	{
		base.InnerList.Clear();
		ShapeCollection shapes = worksheet_0.Shapes;
		for (int num = shapes.Count - 1; num >= 0; num--)
		{
			if (shapes[num].MsoDrawingType == MsoDrawingType.Comment)
			{
				shapes.method_16(num);
			}
		}
	}

	internal void method_2(Range range_0, Range range_1, bool bool_0)
	{
		for (int i = 0; i < base.Count; i++)
		{
			Comment comment = this[i];
			if (comment.Row >= range_1.Area.StartRow && comment.Row <= range_1.Area.EndRow && comment.Column >= range_1.Area.StartColumn && comment.Column <= range_1.Area.EndColumn)
			{
				method_0().Shapes.method_26(comment.CommentShape);
				i--;
			}
		}
		for (int j = 0; j < range_0.Worksheet.Comments.Count; j++)
		{
			Comment comment2 = range_0.Worksheet.Comments[j];
			if (comment2.Row >= range_0.Area.StartRow && comment2.Row <= range_0.Area.EndRow && comment2.Column >= range_0.Area.StartColumn && comment2.Column <= range_0.Area.EndColumn)
			{
				int num = comment2.Row - range_0.Area.StartRow;
				int num2 = comment2.Column - range_0.Area.StartColumn;
				if (bool_0)
				{
					int num3 = num;
					num = num2;
					num2 = num3;
				}
				int index = Add(range_1.Area.StartRow + num, range_1.Area.StartColumn + num2);
				Comment comment3 = this[index];
				comment3.Copy(comment2);
			}
		}
	}

	internal void CopyColumns(CommentCollection commentCollection_0, int int_0, int int_1, int int_2)
	{
		int num = int_0 + int_2 - 1;
		int num2 = int_1 + int_2 - 1;
		for (int i = 0; i < base.Count; i++)
		{
			Comment comment = (Comment)base.InnerList[i];
			if (comment.Column >= int_1 && comment.Column <= num2)
			{
				worksheet_0.Shapes.method_26(comment.CommentShape);
				i--;
			}
		}
		int count = commentCollection_0.Count;
		for (int j = 0; j < count; j++)
		{
			Comment comment2 = (Comment)commentCollection_0.InnerList[j];
			if (comment2.Column >= int_0 && comment2.Column <= num)
			{
				int num3 = comment2.Column - int_0;
				int index = Add(comment2.Row, int_1 + num3);
				Comment comment3 = this[index];
				comment3.method_2().Copy(comment2.method_2());
			}
		}
	}

	internal void method_3(int int_0, int int_1)
	{
		if (int_1 == 0)
		{
			return;
		}
		int num = 0;
		while (true)
		{
			if (num >= base.Count)
			{
				return;
			}
			Comment comment = this[num];
			if (int_0 <= comment.Row)
			{
				if (int_1 < 0 && comment.Row >= int_0 && comment.Row < int_0 - int_1)
				{
					RemoveAt(num);
					worksheet_0.Shapes.method_26(comment.CommentShape);
					num--;
				}
				else
				{
					if (comment.Row + int_1 > 1048575)
					{
						break;
					}
					comment.method_4(comment.Row + int_1);
					if (comment.CommentShape.Placement == PlacementType.FreeFloating)
					{
						int num2 = comment.CommentShape.method_41(int_0, 0, (int_1 < 0) ? (int_0 - int_1) : (int_0 + int_1), 0);
						if (int_1 < 0)
						{
							comment.CommentShape.method_27().method_7().Top -= num2;
						}
						else
						{
							comment.CommentShape.method_27().method_7().Top += num2;
						}
					}
				}
			}
			num++;
		}
		throw new CellsException(ExceptionType.Limitation, "Aspose.Cells cannot shift nonblank cell off the worksheet.");
	}

	internal void method_4(int int_0, int int_1)
	{
		if (int_1 == 0)
		{
			return;
		}
		int num = 0;
		while (true)
		{
			if (num >= base.Count)
			{
				return;
			}
			Comment comment = this[num];
			if (int_0 <= comment.Column)
			{
				if (int_1 < 0 && int_0 - int_1 > comment.Column)
				{
					RemoveAt(num);
					worksheet_0.Shapes.method_26(comment.CommentShape);
					num--;
				}
				if (comment.Column + int_1 > 16383)
				{
					break;
				}
				comment.method_5(comment.Column + int_1);
				if (comment.CommentShape.Placement == PlacementType.FreeFloating)
				{
					int num2 = comment.CommentShape.method_44(int_0, 0, (int_1 < 0) ? (int_0 - int_1) : (int_0 + int_1), 0);
					if (int_1 < 0)
					{
						comment.CommentShape.method_27().method_7().Left -= num2;
					}
					else
					{
						comment.CommentShape.method_27().method_7().Left += num2;
					}
				}
			}
			num++;
		}
		throw new CellsException(ExceptionType.Limitation, "Aspose.Cells cannot shift nonblank cell off the worksheet.");
	}

	internal void method_5(CellArea cellArea_0, int int_0, ShiftType shiftType_0)
	{
		switch (shiftType_0)
		{
		case ShiftType.Down:
			method_9(cellArea_0, int_0, shiftType_0);
			break;
		case ShiftType.Left:
			method_6(cellArea_0, int_0, shiftType_0);
			break;
		case ShiftType.None:
			break;
		case ShiftType.Right:
			method_8(cellArea_0, int_0, shiftType_0);
			break;
		case ShiftType.Up:
			method_7(cellArea_0, int_0, shiftType_0);
			break;
		}
	}

	private void method_6(CellArea cellArea_0, int int_0, ShiftType shiftType_0)
	{
		for (int i = 0; i < base.Count; i++)
		{
			Comment comment = this[i];
			int row = comment.Row;
			int column = comment.Column;
			if (row < cellArea_0.StartRow || row > cellArea_0.EndRow || column < cellArea_0.StartColumn)
			{
				continue;
			}
			if (column <= cellArea_0.EndColumn)
			{
				worksheet_0.Shapes.method_26(comment.CommentShape);
				i--;
				continue;
			}
			comment.method_5(comment.Column - int_0);
			int num = comment.CommentShape.UpperLeftColumn - int_0;
			if (num < 0)
			{
				num = 0;
			}
			comment.CommentShape.UpperLeftColumn = num;
		}
	}

	private void method_7(CellArea cellArea_0, int int_0, ShiftType shiftType_0)
	{
		for (int i = 0; i < base.Count; i++)
		{
			Comment comment = this[i];
			int row = comment.Row;
			int column = comment.Column;
			if (column < cellArea_0.StartColumn || column > cellArea_0.EndColumn || row < cellArea_0.StartRow)
			{
				continue;
			}
			if (row <= cellArea_0.EndRow)
			{
				worksheet_0.Shapes.method_26(comment.CommentShape);
				i--;
				continue;
			}
			comment.method_4(row - int_0);
			int num = comment.CommentShape.UpperLeftRow - int_0;
			if (num < 0)
			{
				num = 0;
			}
			comment.CommentShape.UpperLeftRow = num;
		}
	}

	private void method_8(CellArea cellArea_0, int int_0, ShiftType shiftType_0)
	{
		for (int i = 0; i < base.Count; i++)
		{
			Comment comment = this[i];
			if (comment.Row >= cellArea_0.StartRow && comment.Row <= cellArea_0.EndRow && comment.Column >= cellArea_0.StartColumn)
			{
				comment.method_5(comment.Column + int_0);
				if (comment.CommentShape.Placement == PlacementType.FreeFloating)
				{
					int num = comment.CommentShape.method_44(cellArea_0.StartColumn, 0, cellArea_0.StartColumn + int_0, 0);
					comment.CommentShape.method_27().method_7().Left += num;
				}
			}
		}
	}

	private void method_9(CellArea cellArea_0, int int_0, ShiftType shiftType_0)
	{
		for (int i = 0; i < base.Count; i++)
		{
			Comment comment = this[i];
			if (comment.Row >= cellArea_0.StartRow && comment.Column >= cellArea_0.StartColumn && comment.Column <= cellArea_0.EndColumn)
			{
				comment.method_4(comment.Row + int_0);
				if (comment.CommentShape.Placement == PlacementType.FreeFloating)
				{
					int num = comment.CommentShape.method_41(cellArea_0.StartRow, 0, cellArea_0.StartRow + int_0, 0);
					comment.CommentShape.method_27().method_7().Top += num;
				}
			}
		}
	}
}
