using System.Collections;

namespace Aspose.Cells;

/// <summary>
///       Encapsulates a collection of <see cref="T:Aspose.Cells.Range" /> objects.
///       </summary>
public class RangeCollection : CollectionBase
{
	/// <summary>
	///        Gets the <see cref="T:Aspose.Cells.Range" /> element at the specified index.
	///        </summary>
	/// <param name="index">The zero based index of the element.</param>
	/// <returns>The element at the specified index.</returns>
	public Range this[int index] => (Range)base.InnerList[index];

	internal RangeCollection()
	{
	}

	internal int Add(Range range_0)
	{
		base.InnerList.Add(range_0);
		return base.Count - 1;
	}
}
