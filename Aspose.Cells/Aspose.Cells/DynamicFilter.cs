using System;

namespace Aspose.Cells;

/// <summary>
///       Represents the dynamic filter.
///       </summary>
public class DynamicFilter
{
	private DynamicFilterType dynamicFilterType_0;

	private object object_0;

	private object object_1;

	/// <summary>
	///       Gets and sets the dynamic filter type.
	///       </summary>
	public DynamicFilterType DynamicFilterType
	{
		get
		{
			return dynamicFilterType_0;
		}
		set
		{
			dynamicFilterType_0 = value;
		}
	}

	/// <summary>
	///       Gets and sets the dynamic filter value.
	///       </summary>
	public object Value
	{
		get
		{
			return object_0;
		}
		set
		{
			object_0 = value;
		}
	}

	/// <summary>
	///       Gets and sets the dynamic filter max value.
	///       </summary>
	public object MaxValue
	{
		get
		{
			return object_1;
		}
		set
		{
			object_1 = value;
		}
	}

	internal DynamicFilter()
	{
	}

	internal void Copy(DynamicFilter dynamicFilter_0)
	{
		dynamicFilterType_0 = dynamicFilter_0.dynamicFilterType_0;
		object_1 = dynamicFilter_0.object_1;
		object_0 = dynamicFilter_0.object_0;
	}

	internal void method_0(Cells cells_0, int int_0, int int_1, int int_2)
	{
		switch (dynamicFilterType_0)
		{
		case DynamicFilterType.ThisWeek:
		{
			DateTime now = DateTime.Now;
			double num5 = (int)CellsHelper.GetDoubleFromDateTime(now, cells_0.method_19().Workbook.Settings.Date1904);
			object_0 = num5 - (double)now.DayOfWeek;
			object_1 = num5 + 6.0 - (double)now.DayOfWeek;
			break;
		}
		case DynamicFilterType.NextWeek:
		{
			DateTime dateTime2 = DateTime.Now.AddDays(7.0);
			double num4 = (int)CellsHelper.GetDoubleFromDateTime(dateTime2, cells_0.method_19().Workbook.Settings.Date1904);
			object_0 = num4 - (double)dateTime2.DayOfWeek;
			object_1 = num4 + 6.0 - (double)dateTime2.DayOfWeek;
			break;
		}
		case DynamicFilterType.AboveAverage:
		case DynamicFilterType.BelowAverage:
		{
			int num2 = 0;
			double num3 = 0.0;
			for (int i = int_1; i <= int_2; i++)
			{
				Cell cell = cells_0.CheckCell(i, int_0);
				if (cell != null && (cell.Type == CellValueType.IsNumeric || cell.Type == CellValueType.IsDateTime))
				{
					num3 += cell.DoubleValue;
					num2++;
				}
			}
			object_0 = num3 / (double)num2;
			break;
		}
		case DynamicFilterType.LastWeek:
		{
			DateTime dateTime = DateTime.Now.AddDays(-7.0);
			double num = (int)CellsHelper.GetDoubleFromDateTime(dateTime, cells_0.method_19().Workbook.Settings.Date1904);
			object_0 = num - (double)dateTime.DayOfWeek;
			object_1 = num + 6.0 - (double)dateTime.DayOfWeek;
			break;
		}
		}
	}

	internal bool method_1(object object_2, bool bool_0)
	{
		if (dynamicFilterType_0 == DynamicFilterType.None)
		{
			return true;
		}
		if (object_2 != null && !(object_2 is DateTime))
		{
			return false;
		}
		double num = ((object_2 == null) ? 0.0 : CellsHelper.GetDoubleFromDateTime((DateTime)object_2, bool_0));
		switch (dynamicFilterType_0)
		{
		default:
		{
			DateTime dateTimeFromDouble = CellsHelper.GetDateTimeFromDouble(num, bool_0);
			DateTime now = DateTime.Now;
			switch (dynamicFilterType_0)
			{
			case DynamicFilterType.LastMonth:
				if (dateTimeFromDouble.Year == now.Year)
				{
					return dateTimeFromDouble.Month + 1 == now.Month;
				}
				if (dateTimeFromDouble.Year + 1 == now.Year)
				{
					if (dateTimeFromDouble.Month == 12)
					{
						return now.Month == 1;
					}
					return false;
				}
				return false;
			case DynamicFilterType.LastQuarter:
				if (dateTimeFromDouble.Year == now.Year)
				{
					return Math.Ceiling((float)dateTimeFromDouble.Month / 3f) + 1.0 == Math.Ceiling((float)now.Month / 3f);
				}
				if (dateTimeFromDouble.Year + 1 == now.Year)
				{
					if (Math.Ceiling((float)dateTimeFromDouble.Month / 3f) == 4.0)
					{
						return Math.Ceiling((float)now.Month / 3f) == 1.0;
					}
					return false;
				}
				return false;
			case DynamicFilterType.LastYear:
				return dateTimeFromDouble.Year + 1 == now.Year;
			case DynamicFilterType.January:
				return dateTimeFromDouble.Month == 1;
			case DynamicFilterType.October:
				return dateTimeFromDouble.Month == 10;
			case DynamicFilterType.November:
				return dateTimeFromDouble.Month == 11;
			case DynamicFilterType.December:
				return dateTimeFromDouble.Month == 12;
			case DynamicFilterType.Februray:
				return dateTimeFromDouble.Month == 2;
			case DynamicFilterType.March:
				return dateTimeFromDouble.Month == 3;
			case DynamicFilterType.April:
				return dateTimeFromDouble.Month == 4;
			case DynamicFilterType.May:
				return dateTimeFromDouble.Month == 5;
			case DynamicFilterType.June:
				return dateTimeFromDouble.Month == 6;
			case DynamicFilterType.July:
				return dateTimeFromDouble.Month == 7;
			case DynamicFilterType.August:
				return dateTimeFromDouble.Month == 8;
			case DynamicFilterType.September:
				return dateTimeFromDouble.Month == 9;
			case DynamicFilterType.NextMonth:
				if (dateTimeFromDouble.Year == now.Year)
				{
					return dateTimeFromDouble.Month - 1 == now.Month;
				}
				if (dateTimeFromDouble.Year - 1 == now.Year)
				{
					if (dateTimeFromDouble.Month == 1)
					{
						return now.Month == 12;
					}
					return false;
				}
				return false;
			case DynamicFilterType.NextQuarter:
				if (dateTimeFromDouble.Year == now.Year)
				{
					return Math.Ceiling((float)dateTimeFromDouble.Month / 3f) - 1.0 == Math.Ceiling((float)now.Month / 3f);
				}
				if (dateTimeFromDouble.Year + 1 == now.Year)
				{
					if (Math.Ceiling((float)dateTimeFromDouble.Month / 3f) == 1.0)
					{
						return Math.Ceiling((float)now.Month / 3f) == 4.0;
					}
					return false;
				}
				return false;
			case DynamicFilterType.NextYear:
				return dateTimeFromDouble.Year - 1 == now.Year;
			default:
				return true;
			case DynamicFilterType.Quarter1:
				if (dateTimeFromDouble.Month >= 1)
				{
					return dateTimeFromDouble.Month <= 3;
				}
				return false;
			case DynamicFilterType.Quarter2:
				if (dateTimeFromDouble.Month >= 4)
				{
					return dateTimeFromDouble.Month <= 6;
				}
				return false;
			case DynamicFilterType.Quarter3:
				if (dateTimeFromDouble.Month >= 7)
				{
					return dateTimeFromDouble.Month <= 9;
				}
				return false;
			case DynamicFilterType.Quarter4:
				if (dateTimeFromDouble.Month >= 10)
				{
					return dateTimeFromDouble.Month <= 20;
				}
				return false;
			case DynamicFilterType.ThisMonth:
				if (dateTimeFromDouble.Year == now.Year)
				{
					return dateTimeFromDouble.Month == now.Month;
				}
				return false;
			case DynamicFilterType.ThisQuarter:
				if (dateTimeFromDouble.Year == now.Year)
				{
					return Math.Ceiling((float)dateTimeFromDouble.Month / 3f) == Math.Ceiling((float)now.Month / 3f);
				}
				return false;
			case DynamicFilterType.LastWeek:
			case DynamicFilterType.NextWeek:
			case DynamicFilterType.ThisWeek:
			{
				double num2 = (int)CellsHelper.GetDoubleFromDateTime(dateTimeFromDouble, bool_0);
				if (num2 >= (double)object_0)
				{
					return num2 <= (double)object_1;
				}
				return false;
			}
			case DynamicFilterType.ThisYear:
				return dateTimeFromDouble.Year == now.Year;
			case DynamicFilterType.Today:
				if (dateTimeFromDouble.Year == now.Year && dateTimeFromDouble.Month == now.Month)
				{
					return dateTimeFromDouble.Day == now.Day;
				}
				return false;
			case DynamicFilterType.Tomorrow:
				dateTimeFromDouble = dateTimeFromDouble.AddDays(-1.0);
				if (dateTimeFromDouble.Year == now.Year && dateTimeFromDouble.Month == now.Month)
				{
					return dateTimeFromDouble.Day == now.Day;
				}
				return false;
			case DynamicFilterType.YearToDate:
				if (dateTimeFromDouble.Year == now.Year)
				{
					if (dateTimeFromDouble.Month < now.Month)
					{
						return true;
					}
					if (dateTimeFromDouble.Month == now.Month)
					{
						return dateTimeFromDouble.Day <= now.Day;
					}
				}
				return false;
			case DynamicFilterType.Yesterday:
				dateTimeFromDouble = dateTimeFromDouble.AddDays(1.0);
				if (dateTimeFromDouble.Year == now.Year && dateTimeFromDouble.Month == now.Month)
				{
					return dateTimeFromDouble.Day == now.Day;
				}
				return false;
			}
		}
		case DynamicFilterType.AboveAverage:
			return num > (double)Value;
		case DynamicFilterType.BelowAverage:
			return num < (double)Value;
		}
	}

	internal bool method_2(Cell cell_0, bool bool_0)
	{
		if (dynamicFilterType_0 == DynamicFilterType.None)
		{
			return true;
		}
		if (cell_0 != null && cell_0.Type != CellValueType.IsDateTime && cell_0.Type != CellValueType.IsNumeric)
		{
			return false;
		}
		double num = cell_0?.DoubleValue ?? 0.0;
		switch (dynamicFilterType_0)
		{
		default:
		{
			DateTime dateTimeFromDouble = CellsHelper.GetDateTimeFromDouble(num, bool_0);
			DateTime now = DateTime.Now;
			switch (dynamicFilterType_0)
			{
			case DynamicFilterType.LastMonth:
				if (dateTimeFromDouble.Year == now.Year)
				{
					return dateTimeFromDouble.Month + 1 == now.Month;
				}
				if (dateTimeFromDouble.Year + 1 == now.Year)
				{
					if (dateTimeFromDouble.Month == 12)
					{
						return now.Month == 1;
					}
					return false;
				}
				return false;
			case DynamicFilterType.LastQuarter:
				if (dateTimeFromDouble.Year == now.Year)
				{
					return Math.Ceiling((float)dateTimeFromDouble.Month / 3f) + 1.0 == Math.Ceiling((float)now.Month / 3f);
				}
				if (dateTimeFromDouble.Year + 1 == now.Year)
				{
					if (Math.Ceiling((float)dateTimeFromDouble.Month / 3f) == 4.0)
					{
						return Math.Ceiling((float)now.Month / 3f) == 1.0;
					}
					return false;
				}
				return false;
			case DynamicFilterType.LastYear:
				return dateTimeFromDouble.Year + 1 == now.Year;
			case DynamicFilterType.January:
				return dateTimeFromDouble.Month == 1;
			case DynamicFilterType.October:
				return dateTimeFromDouble.Month == 10;
			case DynamicFilterType.November:
				return dateTimeFromDouble.Month == 11;
			case DynamicFilterType.December:
				return dateTimeFromDouble.Month == 12;
			case DynamicFilterType.Februray:
				return dateTimeFromDouble.Month == 2;
			case DynamicFilterType.March:
				return dateTimeFromDouble.Month == 3;
			case DynamicFilterType.April:
				return dateTimeFromDouble.Month == 4;
			case DynamicFilterType.May:
				return dateTimeFromDouble.Month == 5;
			case DynamicFilterType.June:
				return dateTimeFromDouble.Month == 6;
			case DynamicFilterType.July:
				return dateTimeFromDouble.Month == 7;
			case DynamicFilterType.August:
				return dateTimeFromDouble.Month == 8;
			case DynamicFilterType.September:
				return dateTimeFromDouble.Month == 9;
			case DynamicFilterType.NextMonth:
				if (dateTimeFromDouble.Year == now.Year)
				{
					return dateTimeFromDouble.Month - 1 == now.Month;
				}
				if (dateTimeFromDouble.Year - 1 == now.Year)
				{
					if (dateTimeFromDouble.Month == 1)
					{
						return now.Month == 12;
					}
					return false;
				}
				return false;
			case DynamicFilterType.NextQuarter:
				if (dateTimeFromDouble.Year == now.Year)
				{
					return Math.Ceiling((float)dateTimeFromDouble.Month / 3f) - 1.0 == Math.Ceiling((float)now.Month / 3f);
				}
				if (dateTimeFromDouble.Year + 1 == now.Year)
				{
					if (Math.Ceiling((float)dateTimeFromDouble.Month / 3f) == 1.0)
					{
						return Math.Ceiling((float)now.Month / 3f) == 4.0;
					}
					return false;
				}
				return false;
			case DynamicFilterType.NextYear:
				return dateTimeFromDouble.Year - 1 == now.Year;
			default:
				return true;
			case DynamicFilterType.Quarter1:
				if (dateTimeFromDouble.Month >= 1)
				{
					return dateTimeFromDouble.Month <= 3;
				}
				return false;
			case DynamicFilterType.Quarter2:
				if (dateTimeFromDouble.Month >= 4)
				{
					return dateTimeFromDouble.Month <= 6;
				}
				return false;
			case DynamicFilterType.Quarter3:
				if (dateTimeFromDouble.Month >= 7)
				{
					return dateTimeFromDouble.Month <= 9;
				}
				return false;
			case DynamicFilterType.Quarter4:
				if (dateTimeFromDouble.Month >= 10)
				{
					return dateTimeFromDouble.Month <= 20;
				}
				return false;
			case DynamicFilterType.ThisMonth:
				if (dateTimeFromDouble.Year == now.Year)
				{
					return dateTimeFromDouble.Month == now.Month;
				}
				return false;
			case DynamicFilterType.ThisQuarter:
				if (dateTimeFromDouble.Year == now.Year)
				{
					return Math.Ceiling((float)dateTimeFromDouble.Month / 3f) == Math.Ceiling((float)now.Month / 3f);
				}
				return false;
			case DynamicFilterType.LastWeek:
			case DynamicFilterType.NextWeek:
			case DynamicFilterType.ThisWeek:
			{
				double num2 = (int)CellsHelper.GetDoubleFromDateTime(dateTimeFromDouble, bool_0);
				if (num2 >= (double)object_0)
				{
					return num2 <= (double)object_1;
				}
				return false;
			}
			case DynamicFilterType.ThisYear:
				return dateTimeFromDouble.Year == now.Year;
			case DynamicFilterType.Today:
				if (dateTimeFromDouble.Year == now.Year && dateTimeFromDouble.Month == now.Month)
				{
					return dateTimeFromDouble.Day == now.Day;
				}
				return false;
			case DynamicFilterType.Tomorrow:
				dateTimeFromDouble = dateTimeFromDouble.AddDays(-1.0);
				if (dateTimeFromDouble.Year == now.Year && dateTimeFromDouble.Month == now.Month)
				{
					return dateTimeFromDouble.Day == now.Day;
				}
				return false;
			case DynamicFilterType.YearToDate:
				if (dateTimeFromDouble.Year == now.Year)
				{
					if (dateTimeFromDouble.Month < now.Month)
					{
						return true;
					}
					if (dateTimeFromDouble.Month == now.Month)
					{
						return dateTimeFromDouble.Day <= now.Day;
					}
				}
				return false;
			case DynamicFilterType.Yesterday:
				dateTimeFromDouble = dateTimeFromDouble.AddDays(1.0);
				if (dateTimeFromDouble.Year == now.Year && dateTimeFromDouble.Month == now.Month)
				{
					return dateTimeFromDouble.Day == now.Day;
				}
				return false;
			}
		}
		case DynamicFilterType.AboveAverage:
			return num > (double)Value;
		case DynamicFilterType.BelowAverage:
			return num < (double)Value;
		}
	}
}
