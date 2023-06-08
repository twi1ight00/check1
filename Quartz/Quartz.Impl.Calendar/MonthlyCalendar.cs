using System;
using System.Globalization;
using System.Runtime.Serialization;
using System.Security;
using Quartz.Util;

namespace Quartz.Impl.Calendar;

/// <summary>
/// This implementation of the Calendar excludes a set of days of the month. You
/// may use it to exclude every 1. of each month for example. But you may define
/// any day of a month.
/// </summary>
/// <seealso cref="T:Quartz.ICalendar" />
/// <seealso cref="T:Quartz.Impl.Calendar.BaseCalendar" />
/// <author>Juergen Donnerstag</author>
/// <author>Marko Lahma (.NET)</author>
[Serializable]
public class MonthlyCalendar : BaseCalendar
{
	private const int MaxDaysInMonth = 31;

	private bool[] excludeDays = new bool[31];

	private bool excludeAll;

	/// <summary>
	/// Get or set the array which defines the exclude-value of each day of month
	/// Setting will redefine the array of days excluded. The array must of size greater or
	/// equal 31.
	/// </summary>
	public virtual bool[] DaysExcluded
	{
		get
		{
			return excludeDays;
		}
		set
		{
			if (value != null)
			{
				excludeDays = value;
				excludeAll = AreAllDaysExcluded();
			}
		}
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="T:Quartz.Impl.Calendar.MonthlyCalendar" /> class.
	/// </summary>
	public MonthlyCalendar()
	{
		Init();
	}

	/// <summary>
	/// Constructor
	/// </summary>
	/// <param name="baseCalendar">The base calendar.</param>
	public MonthlyCalendar(ICalendar baseCalendar)
		: base(baseCalendar)
	{
		Init();
	}

	/// <summary>
	/// Serialization constructor.
	/// </summary>
	/// <param name="info"></param>
	/// <param name="context"></param>
	protected MonthlyCalendar(SerializationInfo info, StreamingContext context)
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
		case 1:
			excludeDays = (bool[])info.GetValue("excludeDays", typeof(bool[]));
			excludeAll = (bool)info.GetValue("excludeAll", typeof(bool));
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
		info.AddValue("excludeAll", excludeAll);
	}

	/// <summary> 
	/// Initialize internal variables
	/// </summary>
	private void Init()
	{
		excludeAll = AreAllDaysExcluded();
	}

	/// <summary>
	/// Return true, if mday is defined to be exluded.
	/// </summary>
	public virtual bool IsDayExcluded(int day)
	{
		if (day < 1 || day > 31)
		{
			throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "The day parameter must be in the range of 1 to {0}", new object[1] { 31 }));
		}
		return excludeDays[day - 1];
	}

	/// <summary>
	/// Redefine a certain day of the month to be excluded (true) or included
	/// (false).
	/// </summary>
	public virtual void SetDayExcluded(int day, bool exclude)
	{
		excludeDays[day - 1] = exclude;
		excludeAll = AreAllDaysExcluded();
	}

	/// <summary>
	/// Check if all days are excluded. That is no day is included.
	/// </summary>
	/// <returns> boolean
	/// </returns>
	public virtual bool AreAllDaysExcluded()
	{
		for (int i = 1; i <= 31; i++)
		{
			if (!IsDayExcluded(i))
			{
				return false;
			}
		}
		return true;
	}

	/// <summary>
	/// Determine whether the given time (in milliseconds) is 'included' by the
	/// Calendar.
	/// <para>
	/// Note that this Calendar is only has full-day precision.
	/// </para>
	/// </summary>
	public override bool IsTimeIncluded(DateTimeOffset timeStampUtc)
	{
		if (excludeAll)
		{
			return false;
		}
		if (!base.IsTimeIncluded(timeStampUtc))
		{
			return false;
		}
		timeStampUtc = TimeZoneUtil.ConvertTime(timeStampUtc, TimeZone);
		int day = timeStampUtc.Day;
		return !IsDayExcluded(day);
	}

	/// <summary>
	/// Determine the next time (in milliseconds) that is 'included' by the
	/// Calendar after the given time. Return the original value if timeStamp is
	/// included. Return DateTime.MinValue if all days are excluded.
	/// <para>
	/// Note that this Calendar is only has full-day precision.
	/// </para>
	/// </summary>
	public override DateTimeOffset GetNextIncludedTimeUtc(DateTimeOffset timeUtc)
	{
		if (excludeAll)
		{
			return DateTimeOffset.MinValue;
		}
		DateTimeOffset baseTime = base.GetNextIncludedTimeUtc(timeUtc);
		if (baseTime != DateTimeOffset.MinValue && baseTime > timeUtc)
		{
			timeUtc = baseTime;
		}
		timeUtc = TimeZoneUtil.ConvertTime(timeUtc, TimeZone);
		DateTimeOffset newTimeStamp = new DateTimeOffset(timeUtc.Date, timeUtc.Offset);
		int day = newTimeStamp.Day;
		if (!IsDayExcluded(day))
		{
			return newTimeStamp;
		}
		while (IsDayExcluded(day))
		{
			newTimeStamp = newTimeStamp.AddDays(1.0);
			day = newTimeStamp.Day;
		}
		return newTimeStamp;
	}

	/// <summary>
	/// Creates a new object that is a copy of the current instance.
	/// </summary>
	/// <returns>A new object that is a copy of this instance.</returns>
	public override object Clone()
	{
		MonthlyCalendar clone = (MonthlyCalendar)base.Clone();
		bool[] excludeCopy = new bool[excludeDays.Length];
		Array.Copy(excludeDays, excludeCopy, excludeDays.Length);
		clone.excludeDays = excludeCopy;
		return clone;
	}

	public override int GetHashCode()
	{
		int baseHash = 0;
		if (GetBaseCalendar() != null)
		{
			baseHash = GetBaseCalendar().GetHashCode();
		}
		return DaysExcluded.GetHashCode() + 5 * baseHash;
	}

	public bool Equals(MonthlyCalendar obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (GetBaseCalendar() == null || GetBaseCalendar().Equals(obj.GetBaseCalendar()))
		{
			return BaseCalendar.ArraysEqualElementsOnEqualPlaces(DaysExcluded, obj.DaysExcluded);
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (obj == null || !(obj is MonthlyCalendar))
		{
			return false;
		}
		return Equals((MonthlyCalendar)obj);
	}
}
