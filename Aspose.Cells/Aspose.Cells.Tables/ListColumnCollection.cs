using System.Collections;
using System.Runtime.CompilerServices;

namespace Aspose.Cells.Tables;

/// <summary>
///       A collection of all the <see cref="T:Aspose.Cells.Tables.ListColumn" /> objects in the specified ListObject object. 
///       </summary>
public class ListColumnCollection : CollectionBase
{
	private ListObject listObject_0;

	/// <summary>
	///       Gets the ListColumn by the index.
	///       </summary>
	/// <param name="index">The index.</param>
	/// <returns>the ListColumn object.</returns>
	public ListColumn this[int index] => (ListColumn)base.InnerList[index];

	/// <summary>
	///       Gets the ListColumn by the name.
	///       </summary>
	/// <param name="name">The name of the ListColumn</param>
	/// <returns>The ListColumn object.</returns>
	public ListColumn this[string name]
	{
		get
		{
			foreach (ListColumn inner in base.InnerList)
			{
				if (inner.Name == name)
				{
					return inner;
				}
			}
			return null;
		}
	}

	internal ListColumnCollection(ListObject listObject_1)
	{
		listObject_0 = listObject_1;
	}

	internal void Insert(int int_0, ListColumn listColumn_0)
	{
		base.InnerList.Insert(int_0, listColumn_0);
	}

	internal void Copy(ListColumnCollection listColumnCollection_0)
	{
		for (int i = 0; i < listColumnCollection_0.Count; i++)
		{
			ListColumn listColumn_ = listColumnCollection_0[i];
			ListColumn listColumn = new ListColumn(this);
			listColumn.Copy(listColumn_);
			base.InnerList.Add(listColumn);
		}
	}

	internal int method_0(string string_0)
	{
		int num = 0;
		while (true)
		{
			if (num < base.InnerList.Count)
			{
				ListColumn listColumn = (ListColumn)base.InnerList[num];
				if (listColumn.Name == string_0)
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

	[SpecialName]
	internal bool method_1()
	{
		int num = 0;
		while (true)
		{
			if (num < base.Count)
			{
				if (this[num].TotalsCalculation != 0)
				{
					break;
				}
				num++;
				continue;
			}
			return false;
		}
		return true;
	}

	internal void Add(ListColumn listColumn_0)
	{
		base.InnerList.Add(listColumn_0);
	}

	[SpecialName]
	internal ListObject method_2()
	{
		return listObject_0;
	}
}
