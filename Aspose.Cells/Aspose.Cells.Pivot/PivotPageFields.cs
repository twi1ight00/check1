using System.Collections;
using System.Runtime.CompilerServices;

namespace Aspose.Cells.Pivot;

/// <summary>
///       Represents the pivot page field items 
///       if the pivot table data source is consolidation ranges.
///       It only can contain up to 4 fields.
///       </summary>
public class PivotPageFields
{
	private ArrayList arrayList_0;

	private ArrayList arrayList_1;

	/// <summary>
	///       Gets the number of page fields.
	///       </summary>
	public int PageFieldCount => arrayList_0.Count;

	/// <summary>
	///       Represents the pivot page field items.
	///       </summary>
	public PivotPageFields()
	{
		arrayList_0 = new ArrayList();
		arrayList_1 = new ArrayList();
	}

	/// <summary>
	///       Adds a page field.
	///       </summary>
	/// <param name="pageItems">Page field item label</param>
	public void AddPageField(string[] pageItems)
	{
		if (arrayList_0.Count != 4)
		{
			arrayList_0.Add(pageItems);
		}
	}

	/// <summary>
	///       Sets which item label in each page field to use to identify the data range.
	///       The pageItemIndex.Length must be equal to PageFieldCount, so please add the page field first.
	///       </summary>
	/// <param name="rangeIndex">The consilidation data range index.</param>
	/// <param name="pageItemIndex">The page item index in the each page field.
	///       pageItemIndex[2] = 1 means the seconde item in the third field to use to identify this range.
	///       pageItemIndex[1] = -1 means no item in the second field to use to identify this range 
	///       and MS will auto create "blank" item in the second field  to identify this range.
	///       </param>
	public void AddIdentify(int rangeIndex, int[] pageItemIndex)
	{
		arrayList_1.Insert(rangeIndex, pageItemIndex);
	}

	[SpecialName]
	internal ArrayList method_0()
	{
		return arrayList_0;
	}

	[SpecialName]
	internal ArrayList method_1()
	{
		return arrayList_1;
	}
}
