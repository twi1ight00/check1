using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Security;
using Quartz.Util;

namespace Quartz.Impl.Calendar;

/// <summary>
/// This implementation of the Calendar excludes a set of days of the year. You
/// may use it to exclude bank holidays which are on the same date every year.
/// </summary>
/// <seealso cref="T:Quartz.ICalendar" />
/// <seealso cref="T:Quartz.Impl.Calendar.BaseCalendar" />
/// <author>Juergen Donnerstag</author>
/// <author>Marko Lahma (.NET)</author>
[Serializable]
public class AnnualCalendar : BaseCalendar
{
	private const int FixedYear = 2000;

	private List<DateTimeOffset> excludeDays = new List<DateTimeOffset>();

	private bool dataSorted;

	/// <summary> 
	/// Get or the array which defines the exclude-value of each day of month.
	/// Setting will redefine the array of days excluded. The array must of size greater or
	/// equal 31.
	/// </summary>
	public virtual IList<DateTimeOffset> DaysExcluded
	{
		get
		{
			return excludeDays;
		}
		set
		{
			if (value == null)
			{
				excludeDays = new List<DateTimeOffset>();
			}
			else
			{
				excludeDays = new List<DateTimeOffset>(value);
			}
			dataSorted = false;
		}
	}

	/// <summary>
	/// Constructor
	/// </summary>
	public AnnualCalendar()
	{
	}

	/// <summary>
	/// Constructor
	/// </summary>
	/// <param name="baseCalendar">The base calendar.</param>
	public AnnualCalendar(ICalendar baseCalendar)
		: base(baseCalendar)
	{
	}

	/// <summary>
	/// Serialization constructor.
	/// </summary>
	/// <param name="info"></param>
	/// <param name="context"></param>
	protected AnnualCalendar(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		int version;
		try
		{
			version = info.GetInt32("version");
		}
		catch
		{
			version = 0;
		}
		switch (version)
		{
		case 0:
		{
			object o = info.GetValue("excludeDays", typeof(object));
			if (o is ArrayList oldFormat)
			{
				{
					foreach (DateTime dateTime in oldFormat)
					{
						excludeDays.Add(dateTime);
					}
					break;
				}
			}
			excludeDays = (List<DateTimeOffset>)o;
			break;
		}
		case 1:
			excludeDays = (List<DateTimeOffset>)info.GetValue("excludeDays", typeof(List<DateTimeOffset>));
			break;
		default:
			throw new NotSupportedException("Unknown serialization version");
		}
	}

	[SecurityCritical]
	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue("version", 1);
		info.AddValue("excludeDays", excludeDays);
	}

	/// <summary>
	/// Return true, if day is defined to be exluded.
	/// </summary>
	public virtual bool IsDayExcluded(DateTimeOffset day)
	{
		return IsDateTimeExcluded(day);
	}

	protected virtual bool IsDateTimeExcluded(DateTimeOffset day)
	{
		if (!base.IsTimeIncluded(day))
		{
			return true;
		}
		int dmonth = day.Month;
		int dday = day.Day;
		if (!dataSorted)
		{
			excludeDays.Sort();
			dataSorted = true;
		}
		foreach (DateTimeOffset cl in excludeDays)
		{
			if (dmonth < cl.Month)
			{
				return false;
			}
			if (dday == cl.Day && dmonth == cl.Month)
			{
				return true;
			}
		}
		return false;
	}

	/// <summary>
	/// Redefine a certain day to be excluded (true) or included (false).
	/// </summary>
	public virtual void SetDayExcluded(DateTimeOffset day, bool exclude)
	{
		DateTimeOffset d = new DateTimeOffset(2000, day.Month, day.Day, 0, 0, 0, TimeSpan.Zero);
		if (exclude)
		{
			if (!IsDayExcluded(day))
			{
				excludeDays.Add(d);
			}
		}
		else if (IsDayExcluded(day))
		{
			excludeDays.Remove(d);
		}
		dataSorted = false;
	}

	/// <summary>
	/// Determine whether the given UTC time (in milliseconds) is 'included' by the
	/// Calendar.
	/// <para>
	/// Note that this Calendar is only has full-day precision.
	/// </para>
	/// </summary>
	public override bool IsTimeIncluded(DateTimeOffset dateUtc)
	{
		if (!base.IsTimeIncluded(dateUtc))
		{
			return false;
		}
		dateUtc = TimeZoneUtil.ConvertTime(dateUtc, TimeZone);
		return !IsDayExcluded(dateUtc);
	}

	/// <summary>
	/// Determine the next UTC time (in milliseconds) that is 'included' by the
	/// Calendar after the given time. Return the original value if timeStampUtc is
	/// included. Return 0 if all days are excluded.
	/// <para>
	/// Note that this Calendar is only has full-day precision.
	/// </para>
	/// </summary>
	public override DateTimeOffset GetNextIncludedTimeUtc(DateTimeOffset timeStampUtc)
	{
		DateTimeOffset baseTime = base.GetNextIncludedTimeUtc(timeStampUtc);
		if (baseTime != DateTimeOffset.MinValue && baseTime > timeStampUtc)
		{
			timeStampUtc = baseTime;
		}
		timeStampUtc = TimeZoneUtil.ConvertTime(timeStampUtc, TimeZone);
		DateTimeOffset day = new DateTimeOffset(timeStampUtc.Date, timeStampUtc.Offset);
		if (!IsDayExcluded(day))
		{
			return timeStampUtc;
		}
		while (IsDayExcluded(day))
		{
			day = day.AddDays(1.0);
		}
		return day;
	}

	public override int GetHashCode()
	{
		int baseHash = 13;
		if (GetBaseCalendar() != null)
		{
			baseHash = GetBaseCalendar().GetHashCode();
		}
		return excludeDays.GetHashCode() + 5 * baseHash;
	}

	public bool Equals(AnnualCalendar obj)
	{
		if (obj == null)
		{
			return false;
		}
		bool toReturn = (GetBaseCalendar() == null || GetBaseCalendar().Equals(obj.GetBaseCalendar())) && DaysExcluded.Count == obj.DaysExcluded.Count;
		if (toReturn)
		{
			foreach (DateTimeOffset date in DaysExcluded)
			{
				toReturn = toReturn && obj.DaysExcluded.Contains(date);
			}
		}
		return toReturn;
	}

	public override bool Equals(object obj)
	{
		if (obj == null || !(obj is AnnualCalendar))
		{
			return false;
		}
		return Equals((AnnualCalendar)obj);
	}

	public override object Clone()
	{
		AnnualCalendar copy = (AnnualCalendar)base.Clone();
		copy.excludeDays = new List<DateTimeOffset>(excludeDays);
		return copy;
	}
}
