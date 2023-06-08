using System.Collections;

namespace Aspose.Cells;

/// <summary>
///       A collection of Filter objects that represents all the filters in an autofiltered range.
///       </summary>
public class FilterColumnCollection : CollectionBase
{
	private AutoFilter autoFilter_0;

	/// <summary>
	///       Gets <see cref="T:Aspose.Cells.FilterColumn" /> object at the special field.
	///       </summary>
	/// <param name="fieldIndex">The integer offset of the field on which you want to base the filter 
	///       (from the left of the list; the leftmost field is field 0).
	///       </param>
	/// <returns>
	///       Returens <see cref="T:Aspose.Cells.FilterColumn" /> object.
	///       </returns>
	public FilterColumn this[int fieldIndex]
	{
		get
		{
			int num = 0;
			while (true)
			{
				if (num < base.InnerList.Count)
				{
					FilterColumn filterColumn = (FilterColumn)base.InnerList[num];
					if (filterColumn.FieldIndex != fieldIndex)
					{
						if (filterColumn.FieldIndex > fieldIndex)
						{
							break;
						}
						num++;
						continue;
					}
					return filterColumn;
				}
				FilterColumn filterColumn2 = new FilterColumn(this, fieldIndex);
				base.InnerList.Add(filterColumn2);
				return filterColumn2;
			}
			FilterColumn filterColumn3 = new FilterColumn(this, fieldIndex);
			base.InnerList.Insert(num, filterColumn3);
			return filterColumn3;
		}
	}

	internal AutoFilter AutoFilter => autoFilter_0;

	internal FilterColumnCollection(AutoFilter autoFilter_1)
	{
		autoFilter_0 = autoFilter_1;
	}

	/// <summary>
	/// </summary>
	/// <param name="index">
	/// </param>
	public new void RemoveAt(int index)
	{
		base.InnerList.RemoveAt(index);
	}

	/// <summary>
	///       Returns a single Filter object from a collection.
	///       </summary>
	public FilterColumn GetByIndex(int index)
	{
		return (FilterColumn)base.InnerList[index];
	}

	internal int method_0(FilterColumn filterColumn_0)
	{
		if (base.InnerList.Count == 0)
		{
			base.InnerList.Add(filterColumn_0);
			return 0;
		}
		int num = base.InnerList.Count - 1;
		while (true)
		{
			if (num >= 0)
			{
				FilterColumn filterColumn = (FilterColumn)base.InnerList[num];
				if (filterColumn.FieldIndex != filterColumn_0.FieldIndex)
				{
					if (filterColumn.FieldIndex < filterColumn_0.FieldIndex)
					{
						break;
					}
					num--;
					continue;
				}
				base.InnerList[num] = filterColumn_0;
				return num;
			}
			base.InnerList.Insert(0, filterColumn_0);
			return 0;
		}
		if (num == base.InnerList.Count - 1)
		{
			base.InnerList.Add(filterColumn_0);
		}
		else
		{
			base.InnerList.Insert(num + 1, filterColumn_0);
		}
		return num + 1;
	}

	internal void Copy(FilterColumnCollection filterColumnCollection_0)
	{
		if (filterColumnCollection_0.InnerList == null || filterColumnCollection_0.InnerList.Count == 0)
		{
			return;
		}
		foreach (FilterColumn inner in filterColumnCollection_0.InnerList)
		{
			FilterColumn filterColumn2 = this[inner.FieldIndex];
			filterColumn2.Copy(inner);
		}
	}
}
