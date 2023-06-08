using System.Collections;
using ns2;

namespace Aspose.Cells;

/// <summary>
///       Encapsulates a collection of <see cref="T:Aspose.Cells.ProtectedRange" /> objects.
///       </summary>
public class ProtectedRangeCollection : CollectionBase
{
	private Worksheet worksheet_0;

	/// <summary>
	///        Gets the <see cref="T:Aspose.Cells.ProtectedRange" /> element at the specified index.
	///        </summary>
	/// <param name="index">The zero based index of the element.</param>
	/// <returns>The element at the specified index.</returns>
	public ProtectedRange this[int index] => (ProtectedRange)base.InnerList[index];

	internal ProtectedRangeCollection(Worksheet worksheet_1)
	{
		worksheet_0 = worksheet_1;
	}

	/// <summary>
	///       Adds a <see cref="T:Aspose.Cells.ProtectedRange" /> item to the collection.
	///       </summary>
	/// <param name="name">Range title. This is used as a descriptor, not as a named range definition.</param>
	/// <param name="startRow">Start row index of the range.</param>
	/// <param name="startColumn">Start column index of the range.</param>
	/// <param name="endRow">End row index of the range.</param>
	/// <param name="endColumn">End column index of the range.</param>
	/// <returns>object index.</returns>
	public int Add(string name, int startRow, int startColumn, int endRow, int endColumn)
	{
		if (name == null)
		{
			throw new CellsException(ExceptionType.InvalidData, "Name of AllowEditRange cannot be null");
		}
		Class1677.smethod_26(startRow, startColumn, endRow, endColumn);
		CellArea cellArea_ = default(CellArea);
		cellArea_.StartRow = startRow;
		cellArea_.StartColumn = startColumn;
		cellArea_.EndRow = endRow;
		cellArea_.EndColumn = endColumn;
		ProtectedRange value = new ProtectedRange(this, name, cellArea_);
		base.InnerList.Add(value);
		return base.Count - 1;
	}

	internal int Add(ProtectedRange protectedRange_0)
	{
		base.InnerList.Add(protectedRange_0);
		return base.Count - 1;
	}

	internal int Add(string string_0, ArrayList arrayList_0)
	{
		if (string_0 == null)
		{
			throw new CellsException(ExceptionType.InvalidData, "Name of AllowEditRange cannot be null");
		}
		ProtectedRange value = new ProtectedRange(this, string_0, arrayList_0);
		base.InnerList.Add(value);
		return base.Count - 1;
	}

	internal void Copy(ProtectedRangeCollection protectedRangeCollection_0)
	{
		base.InnerList.Clear();
		for (int i = 0; i < protectedRangeCollection_0.Count; i++)
		{
			ProtectedRange protectedRange_ = protectedRangeCollection_0[i];
			ProtectedRange protectedRange = new ProtectedRange(this);
			protectedRange.Copy(protectedRange_);
		}
	}
}
