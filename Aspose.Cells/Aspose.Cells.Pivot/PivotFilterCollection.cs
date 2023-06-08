using System.Collections;

namespace Aspose.Cells.Pivot;

/// <summary>
///       Represents a collection of all the PivotFilter objects 
///       </summary>
public class PivotFilterCollection : CollectionBase
{
	internal PivotTable pivotTable_0;

	public PivotFilter this[int index] => (PivotFilter)base.InnerList[index];

	internal PivotFilterCollection(PivotTable pivotTable_1)
	{
		pivotTable_0 = pivotTable_1;
	}

	internal void Add(PivotFilter pivotFilter_0)
	{
		base.InnerList.Add(pivotFilter_0);
	}

	/// <summary>
	///       Adds a PivotFilter Object to the specific type 
	///       </summary>
	/// <param name="fieldIndex">the PivotField index </param>
	/// <param name="type">the PivotFilter type </param>
	/// <returns>the index of  the PivotFilter Object in this PivotFilterCollection.</returns>
	public int Add(int fieldIndex, PivotFilterType type)
	{
		if (fieldIndex < 0 || fieldIndex >= pivotTable_0.BaseFields.Count)
		{
			throw new CellsException(ExceptionType.PivotTable, "This pivot field index is out of range");
		}
		PivotFilter pivotFilter = new PivotFilter(pivotTable_0.pivotTableCollection_0.worksheet_0);
		pivotFilter.int_0 = fieldIndex;
		pivotFilter.pivotFilterType_0 = type;
		return base.InnerList.Add(pivotFilter);
	}

	/// <summary>
	///       Clear PivotFilter from the specific PivotField 
	///       </summary>
	/// <param name="fieldIndex">the PivotField index </param>
	public void ClearFilter(int fieldIndex)
	{
		if (fieldIndex >= 0 && fieldIndex < pivotTable_0.BaseFields.Count)
		{
			for (int i = 0; i < base.Count; i++)
			{
				PivotFilter pivotFilter = this[i];
				if (pivotFilter.int_0 == fieldIndex)
				{
					RemoveAt(i);
				}
			}
			return;
		}
		throw new CellsException(ExceptionType.PivotTable, "This pivot field index is out of range");
	}
}
