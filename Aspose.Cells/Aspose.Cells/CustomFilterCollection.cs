using System.Collections;
using System.Text.RegularExpressions;
using ns12;

namespace Aspose.Cells;

/// <summary>
///       Represents the custom filters.
///       </summary>
public class CustomFilterCollection : CollectionBase
{
	private bool bool_0;

	/// <summary>
	///       Indicates whether the two criterias have an "and" relationship. 
	///       </summary>
	public bool And
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
	///       Gets the custom filter in the specific index.
	///       </summary>
	/// <param name="index">The index.</param>
	/// <returns>
	/// </returns>
	public CustomFilter this[int index] => (CustomFilter)base.InnerList[index];

	internal void Copy(CustomFilterCollection customFilterCollection_0)
	{
		bool_0 = customFilterCollection_0.bool_0;
		for (int i = 0; i < customFilterCollection_0.Count; i++)
		{
			CustomFilter customFilter_ = customFilterCollection_0[i];
			CustomFilter customFilter = new CustomFilter();
			customFilter.Copy(customFilter_);
			base.InnerList.Add(customFilter);
		}
	}

	internal void Add(CustomFilter customFilter_0)
	{
		base.InnerList.Add(customFilter_0);
	}

	internal bool method_0(object object_0, bool bool_1)
	{
		int num = 0;
		while (true)
		{
			if (num < base.Count)
			{
				CustomFilter customFilter = this[num];
				if (method_1(object_0, customFilter.FilterOperatorType, customFilter.Criteria, bool_1))
				{
					if (!And)
					{
						return true;
					}
				}
				else if (And)
				{
					break;
				}
				num++;
				continue;
			}
			if (And)
			{
				return true;
			}
			return false;
		}
		return false;
	}

	private bool method_1(object object_0, FilterOperatorType filterOperatorType_0, object object_1, bool bool_1)
	{
		if (object_0 == null)
		{
			return filterOperatorType_0 switch
			{
				FilterOperatorType.Equal => object_1 == null, 
				FilterOperatorType.NotEqual => object_1 != null, 
				_ => false, 
			};
		}
		switch (filterOperatorType_0)
		{
		default:
			return true;
		case FilterOperatorType.LessOrEqual:
		{
			object obj4 = Class1662.Compare(object_0, object_1, "<=", bool_1);
			if (obj4 is bool)
			{
				return (bool)obj4;
			}
			return false;
		}
		case FilterOperatorType.LessThan:
		{
			object obj3 = Class1662.Compare(object_0, object_1, "<", bool_1);
			if (obj3 is bool)
			{
				return (bool)obj3;
			}
			return false;
		}
		case FilterOperatorType.Equal:
		{
			if (object_1 == null)
			{
				return object_0 == null;
			}
			string text2 = object_1.ToString().ToLower();
			text2 = text2.Replace("?", ".?");
			text2 = text2.Replace("*", ".*");
			Regex regex2 = new Regex("^" + text2 + "$");
			if (regex2.IsMatch(object_0.ToString().ToLower()))
			{
				return true;
			}
			return false;
		}
		case FilterOperatorType.GreaterThan:
		{
			object obj2 = Class1662.Compare(object_0, object_1, ">", bool_1);
			if (obj2 is bool)
			{
				return (bool)obj2;
			}
			return false;
		}
		case FilterOperatorType.NotEqual:
		{
			if (object_1 == null)
			{
				return object_0 != null;
			}
			string text = object_1.ToString().ToLower();
			text = text.Replace("?", ".?");
			text = text.Replace("*", ".*");
			Regex regex = new Regex("^" + text + "$");
			if (!regex.IsMatch(object_0.ToString().ToLower()))
			{
				return true;
			}
			return false;
		}
		case FilterOperatorType.GreaterOrEqual:
		{
			object obj = Class1662.Compare(object_0, object_1, ">=", bool_1);
			if (obj is bool)
			{
				return (bool)obj;
			}
			return false;
		}
		}
	}

	internal bool method_2(Cell cell_0, bool bool_1)
	{
		int num = 0;
		while (true)
		{
			if (num < base.Count)
			{
				CustomFilter customFilter = this[num];
				if (method_3(cell_0, customFilter.FilterOperatorType, customFilter.Criteria, bool_1))
				{
					if (!And)
					{
						return true;
					}
				}
				else if (And)
				{
					break;
				}
				num++;
				continue;
			}
			if (And)
			{
				return true;
			}
			return false;
		}
		return false;
	}

	private bool method_3(Cell cell_0, FilterOperatorType filterOperatorType_0, object object_0, bool bool_1)
	{
		if (cell_0 != null && cell_0.Value != null)
		{
			switch (filterOperatorType_0)
			{
			default:
				return true;
			case FilterOperatorType.LessOrEqual:
			{
				object obj4 = Class1662.Compare(cell_0.Value, object_0, "<=", bool_1);
				if (obj4 is bool)
				{
					return (bool)obj4;
				}
				return false;
			}
			case FilterOperatorType.LessThan:
			{
				object obj3 = Class1662.Compare(cell_0.Value, object_0, "<", bool_1);
				if (obj3 is bool)
				{
					return (bool)obj3;
				}
				return false;
			}
			case FilterOperatorType.Equal:
			{
				if (object_0 == null)
				{
					return cell_0.Value == null;
				}
				string text = object_0.ToString().ToLower();
				text = text.Replace("?", ".?");
				text = text.Replace("*", ".*");
				Regex regex = new Regex("^" + text + "$");
				if (regex.IsMatch(cell_0.StringValue.ToLower()))
				{
					return true;
				}
				return false;
			}
			case FilterOperatorType.GreaterThan:
			{
				object obj2 = Class1662.Compare(cell_0.Value, object_0, ">", bool_1);
				if (obj2 is bool)
				{
					return (bool)obj2;
				}
				return false;
			}
			case FilterOperatorType.NotEqual:
			{
				if (object_0 == null)
				{
					if (cell_0 != null)
					{
						return cell_0.Value != null;
					}
					return false;
				}
				string text2 = object_0.ToString().ToLower();
				text2 = text2.Replace("?", ".?");
				text2 = text2.Replace("*", ".*");
				Regex regex2 = new Regex("^" + text2 + "$");
				if (!regex2.IsMatch(cell_0.StringValue.ToLower()))
				{
					return true;
				}
				return false;
			}
			case FilterOperatorType.GreaterOrEqual:
			{
				object obj = Class1662.Compare(cell_0.Value, object_0, ">=", bool_1);
				if (obj is bool)
				{
					return (bool)obj;
				}
				return false;
			}
			}
		}
		return filterOperatorType_0 switch
		{
			FilterOperatorType.Equal => object_0 == null, 
			FilterOperatorType.NotEqual => object_0 != null, 
			_ => false, 
		};
	}
}
