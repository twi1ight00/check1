using System;

namespace Aspose.Cells;

/// <summary>
/// </summary>
public class DateTimeGroupItem
{
	private DateTimeGroupingType dateTimeGroupingType_0;

	private ushort ushort_0;

	private byte byte_0;

	private byte byte_1;

	private byte byte_2;

	private byte byte_3;

	private byte byte_4;

	/// <summary>
	/// </summary>
	public DateTime MinValue => dateTimeGroupingType_0 switch
	{
		DateTimeGroupingType.Day => new DateTime(ushort_0, byte_0, byte_1), 
		DateTimeGroupingType.Hour => new DateTime(ushort_0, byte_0, byte_1, byte_2, 0, 0), 
		DateTimeGroupingType.Minute => new DateTime(ushort_0, byte_0, byte_1, byte_2, byte_3, 0), 
		DateTimeGroupingType.Month => new DateTime(ushort_0, byte_0, 1), 
		DateTimeGroupingType.Second => new DateTime(ushort_0, byte_0, byte_1, byte_2, byte_3, byte_4), 
		DateTimeGroupingType.Year => new DateTime(ushort_0, 1, 1), 
		_ => DateTime.Now, 
	};

	/// <summary>
	/// </summary>
	public DateTimeGroupingType DateTimeGroupingType
	{
		get
		{
			return dateTimeGroupingType_0;
		}
		set
		{
			dateTimeGroupingType_0 = value;
		}
	}

	/// <summary>
	/// </summary>
	public int Year
	{
		get
		{
			return ushort_0;
		}
		set
		{
			ushort_0 = (ushort)value;
		}
	}

	/// <summary>
	/// </summary>
	public int Month
	{
		get
		{
			return byte_0;
		}
		set
		{
			byte_0 = (byte)value;
		}
	}

	/// <summary>
	/// </summary>
	public int Day
	{
		get
		{
			return byte_1;
		}
		set
		{
			byte_1 = (byte)value;
		}
	}

	/// <summary>
	/// </summary>
	public int Hour
	{
		get
		{
			return byte_2;
		}
		set
		{
			byte_2 = (byte)value;
		}
	}

	/// <summary>
	/// </summary>
	public int Minute
	{
		get
		{
			return byte_3;
		}
		set
		{
			byte_3 = (byte)value;
		}
	}

	/// <summary>
	/// </summary>
	public int Second
	{
		get
		{
			return byte_4;
		}
		set
		{
			byte_4 = (byte)value;
		}
	}

	internal void Copy(DateTimeGroupItem dateTimeGroupItem_0)
	{
		dateTimeGroupingType_0 = dateTimeGroupItem_0.dateTimeGroupingType_0;
		ushort_0 = dateTimeGroupItem_0.ushort_0;
		byte_0 = dateTimeGroupItem_0.byte_0;
		byte_1 = dateTimeGroupItem_0.byte_1;
		byte_2 = dateTimeGroupItem_0.byte_2;
		byte_3 = dateTimeGroupItem_0.byte_3;
		byte_4 = dateTimeGroupItem_0.byte_4;
	}

	internal DateTimeGroupItem()
	{
	}

	internal bool method_0(Cell cell_0)
	{
		CellValueType type = cell_0.Type;
		if (type == CellValueType.IsDateTime || type == CellValueType.IsNumeric)
		{
			DateTime dateTimeValue = cell_0.DateTimeValue;
			switch (dateTimeGroupingType_0)
			{
			case DateTimeGroupingType.Day:
				if (dateTimeValue.Year == ushort_0 && dateTimeValue.Month == byte_0)
				{
					return dateTimeValue.Day == byte_1;
				}
				return false;
			case DateTimeGroupingType.Hour:
				if (dateTimeValue.Year == ushort_0 && dateTimeValue.Month == byte_0 && dateTimeValue.Day == byte_1)
				{
					return dateTimeValue.Hour == byte_2;
				}
				return false;
			case DateTimeGroupingType.Minute:
				if (dateTimeValue.Year == ushort_0 && dateTimeValue.Month == byte_0 && dateTimeValue.Day == byte_1 && dateTimeValue.Hour == byte_2)
				{
					return dateTimeValue.Minute == byte_3;
				}
				return false;
			case DateTimeGroupingType.Month:
				if (dateTimeValue.Year == ushort_0)
				{
					return dateTimeValue.Month == byte_0;
				}
				return false;
			case DateTimeGroupingType.Second:
				if (dateTimeValue.Year == ushort_0 && dateTimeValue.Month == byte_0 && dateTimeValue.Day == byte_1 && dateTimeValue.Hour == byte_2 && dateTimeValue.Minute == byte_3)
				{
					return dateTimeValue.Second == byte_4;
				}
				return false;
			case DateTimeGroupingType.Year:
				return dateTimeValue.Year == ushort_0;
			}
		}
		return false;
	}

	internal bool method_1(object object_0)
	{
		DateTime dateTime = (DateTime)object_0;
		switch (dateTimeGroupingType_0)
		{
		default:
			return false;
		case DateTimeGroupingType.Day:
			if (dateTime.Year == ushort_0 && dateTime.Month == byte_0)
			{
				return dateTime.Day == byte_1;
			}
			return false;
		case DateTimeGroupingType.Hour:
			if (dateTime.Year == ushort_0 && dateTime.Month == byte_0 && dateTime.Day == byte_1)
			{
				return dateTime.Hour == byte_2;
			}
			return false;
		case DateTimeGroupingType.Minute:
			if (dateTime.Year == ushort_0 && dateTime.Month == byte_0 && dateTime.Day == byte_1 && dateTime.Hour == byte_2)
			{
				return dateTime.Minute == byte_3;
			}
			return false;
		case DateTimeGroupingType.Month:
			if (dateTime.Year == ushort_0)
			{
				return dateTime.Month == byte_0;
			}
			return false;
		case DateTimeGroupingType.Second:
			if (dateTime.Year == ushort_0 && dateTime.Month == byte_0 && dateTime.Day == byte_1 && dateTime.Hour == byte_2 && dateTime.Minute == byte_3)
			{
				return dateTime.Second == byte_4;
			}
			return false;
		case DateTimeGroupingType.Year:
			return dateTime.Year == ushort_0;
		}
	}

	/// <summary>
	/// </summary>
	/// <param name="type">
	/// </param>
	/// <param name="year">
	/// </param>
	/// <param name="month">
	/// </param>
	/// <param name="day">
	/// </param>
	/// <param name="hour">
	/// </param>
	/// <param name="minute">
	/// </param>
	/// <param name="second">
	/// </param>
	public DateTimeGroupItem(DateTimeGroupingType type, int year, int month, int day, int hour, int minute, int second)
	{
		dateTimeGroupingType_0 = type;
		ushort_0 = (ushort)year;
		byte_0 = (byte)month;
		byte_1 = (byte)day;
		byte_2 = (byte)hour;
		byte_3 = (byte)minute;
		byte_4 = (byte)second;
	}
}
