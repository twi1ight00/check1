using System.Collections;

namespace Aspose.Cells;

/// <summary>
///       Represents the multiple filte collection.
///       </summary>
public class MultipleFilterCollection : CollectionBase
{
	private bool bool_0;

	internal string string_0;

	/// <summary>
	///       Indicates whether to filter by blank. 
	///       </summary>
	public bool MatchBlank
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	/// <summary>
	///       DateTimeGroupItem or a simple object.
	///       </summary>
	/// <param name="index">
	/// </param>
	/// <returns>
	/// </returns>
	public object this[int index] => base.InnerList[index];

	internal void RemoveDateFilter(DateTimeGroupingType dateTimeGroupingType_0, int int_0, int int_1, int int_2, int int_3, int int_4, int int_5)
	{
		for (int i = 0; i < base.Count; i++)
		{
			object obj = this[i];
			if (!(obj is DateTimeGroupItem))
			{
				continue;
			}
			DateTimeGroupItem dateTimeGroupItem = (DateTimeGroupItem)obj;
			if (dateTimeGroupItem.DateTimeGroupingType != dateTimeGroupingType_0)
			{
				continue;
			}
			switch (dateTimeGroupingType_0)
			{
			case DateTimeGroupingType.Day:
				if (dateTimeGroupItem.Year == int_0 && dateTimeGroupItem.Month == int_1 && dateTimeGroupItem.Day == int_2)
				{
					base.InnerList.RemoveAt(i);
					return;
				}
				break;
			case DateTimeGroupingType.Hour:
				if (dateTimeGroupItem.Year == int_0 && dateTimeGroupItem.Month == int_1 && dateTimeGroupItem.Day == int_2 && dateTimeGroupItem.Hour == int_3)
				{
					base.InnerList.RemoveAt(i);
					return;
				}
				break;
			case DateTimeGroupingType.Minute:
				if (dateTimeGroupItem.Year == int_0 && dateTimeGroupItem.Month == int_1 && dateTimeGroupItem.Day == int_2 && dateTimeGroupItem.Hour == int_3 && dateTimeGroupItem.Minute == int_4)
				{
					base.InnerList.RemoveAt(i);
					return;
				}
				break;
			case DateTimeGroupingType.Month:
				if (dateTimeGroupItem.Year == int_0 && dateTimeGroupItem.Month == int_1)
				{
					base.InnerList.RemoveAt(i);
					return;
				}
				break;
			case DateTimeGroupingType.Second:
				if (dateTimeGroupItem.Year == int_0 && dateTimeGroupItem.Month == int_1 && dateTimeGroupItem.Day == int_2 && dateTimeGroupItem.Hour == int_3 && dateTimeGroupItem.Minute == int_4 && dateTimeGroupItem.Second == int_5)
				{
					base.InnerList.RemoveAt(i);
					return;
				}
				break;
			case DateTimeGroupingType.Year:
				if (dateTimeGroupItem.Year == int_0)
				{
					base.InnerList.RemoveAt(i);
					return;
				}
				break;
			}
		}
	}

	internal void RemoveFilter(string string_1)
	{
		if (string_1 == null)
		{
			bool_0 = false;
			return;
		}
		int num = 0;
		while (true)
		{
			if (num < base.Count)
			{
				object obj = this[num];
				if (obj is string && (string)obj == string_1)
				{
					break;
				}
				num++;
				continue;
			}
			return;
		}
		base.InnerList.RemoveAt(num);
	}

	internal void Copy(MultipleFilterCollection multipleFilterCollection_0)
	{
		bool_0 = multipleFilterCollection_0.bool_0;
		for (int i = 0; i < multipleFilterCollection_0.Count; i++)
		{
			object obj = multipleFilterCollection_0[i];
			if (obj is DateTimeGroupItem)
			{
				DateTimeGroupItem dateTimeGroupItem_ = (DateTimeGroupItem)obj;
				DateTimeGroupItem dateTimeGroupItem = new DateTimeGroupItem();
				dateTimeGroupItem.Copy(dateTimeGroupItem_);
				base.InnerList.Add(dateTimeGroupItem);
			}
			else
			{
				base.InnerList.Add(obj);
			}
		}
	}

	internal void Add(string string_1)
	{
		base.InnerList.Add(string_1);
	}

	internal void Add(DateTimeGroupItem dateTimeGroupItem_0)
	{
		base.InnerList.Add(dateTimeGroupItem_0);
	}

	internal bool method_0(Cell cell_0)
	{
		if (MatchBlank && (cell_0 == null || cell_0.Type == CellValueType.IsNull))
		{
			return true;
		}
		if (cell_0 != null && cell_0.Type != CellValueType.IsNull)
		{
			int num = 0;
			while (true)
			{
				if (num < base.Count)
				{
					object obj = this[num];
					if (obj is DateTimeGroupItem)
					{
						if (((DateTimeGroupItem)obj).method_0(cell_0))
						{
							return true;
						}
					}
					else if (obj.ToString().Equals(cell_0.StringValue))
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
		return false;
	}

	internal bool method_1(object object_0)
	{
		if (MatchBlank && object_0 == null)
		{
			return true;
		}
		if (object_0 == null)
		{
			return false;
		}
		int num = 0;
		while (true)
		{
			if (num < base.Count)
			{
				object obj = this[num];
				if (obj is DateTimeGroupItem)
				{
					if (((DateTimeGroupItem)obj).method_1(object_0))
					{
						return true;
					}
				}
				else if (obj.ToString().Equals(object_0.ToString()))
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
}
