using System;
using System.Runtime.Serialization;
using System.Security;
using Quartz.Util;

namespace Quartz.Impl.Calendar;

/// <summary>
/// This implementation of the Calendar excludes a set of days of the week. You
/// may use it to exclude weekends for example. But you may define any day of
/// the week.
/// </summary>
/// <seealso cref="T:Quartz.ICalendar" />
/// <seealso cref="T:Quartz.Impl.Calendar.BaseCalendar" />
/// <author>Juergen Donnerstag</author>
/// <author>Marko Lahma (.NET)</author>
[Serializable]
public class WeeklyCalendar : BaseCalendar
{
	private bool[] excludeDays = new bool[7];

	private bool excludeAll;

	/// <summary> 
	/// Get the array with the week days.
	/// Setting will redefine the array of days excluded. The array must of size greater or
	/// equal 8. java.util.Calendar's constants like MONDAY should be used as
	/// index. A value of true is regarded as: exclude it.
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
	/// Initializes a new instance of the <see cref="T:Quartz.Impl.Calendar.WeeklyCalendar" /> class.
	/// </summary>
	public WeeklyCalendar()
	{
		Init();
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="T:Quartz.Impl.Calendar.WeeklyCalendar" /> class.
	/// </summary>
	/// <param name="baseCalendar">The base calendar.</param>
	public WeeklyCalendar(ICalendar baseCalendar)
		: base(baseCalendar)
	{
		Init();
	}

	/// <summary>
	/// Serialization constructor.
	/// </summary>
	/// <param name="info"></param>
	/// <param name="context"></param>
	protected WeeklyCalendar(SerializationInfo info, StreamingContext context)
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
		excludeDays[0] = true;
		excludeDays[6] = true;
		excludeAll = AreAllDaysExcluded();
	}

	/// <summary> 
	/// Return true, if wday is defined to be exluded. E. g.
	/// saturday and sunday.
	/// </summary>
	public virtual bool IsDayExcluded(DayOfWeek wday)
	{
		return excludeDays[(int)wday];
	}

	/// <summary>
	/// Redefine a certain day of the week to be excluded (true) or included
	/// (false). Use <see cref="T:System.DayOfWeek" /> enum to determine the weekday.
	/// </summary>
	public virtual void SetDayExcluded(DayOfWeek wday, bool exclude)
	{
		excludeDays[(int)wday] = exclude;
		excludeAll = AreAllDaysExcluded();
	}

	/// <summary>
	/// Check if all week ays are excluded. That is no day is included.
	/// </summary>
	public virtual bool AreAllDaysExcluded()
	{
		if (!IsDayExcluded(DayOfWeek.Sunday))
		{
			return false;
		}
		if (!IsDayExcluded(DayOfWeek.Monday))
		{
			return false;
		}
		if (!IsDayExcluded(DayOfWeek.Tuesday))
		{
			return false;
		}
		if (!IsDayExcluded(DayOfWeek.Wednesday))
		{
			return false;
		}
		if (!IsDayExcluded(DayOfWeek.Thursday))
		{
			return false;
		}
		if (!IsDayExcluded(DayOfWeek.Friday))
		{
			return false;
		}
		if (!IsDayExcluded(DayOfWeek.Saturday))
		{
			return false;
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
	public override bool IsTimeIncluded(DateTimeOffset timeUtc)
	{
		if (excludeAll)
		{
			return false;
		}
		if (!base.IsTimeIncluded(timeUtc))
		{
			return false;
		}
		timeUtc = TimeZoneUtil.ConvertTime(timeUtc, TimeZone);
		return !IsDayExcluded(timeUtc.DayOfWeek);
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
		DateTimeOffset d = new DateTimeOffset(timeUtc.Date, timeUtc.Offset);
		if (!IsDayExcluded(d.DayOfWeek))
		{
			return d;
		}
		while (IsDayExcluded(d.DayOfWeek))
		{
			d = d.AddDays(1.0);
		}
		return d;
	}

	public override object Clone()
	{
		WeeklyCalendar clone = (WeeklyCalendar)base.Clone();
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

	public bool Equals(WeeklyCalendar obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (GetBaseCalendar() == null || GetBaseCalendar().Equals(obj.GetBaseCalendar()))
		{
			return BaseCalendar.ArraysEqualElementsOnEqualPlaces(obj.DaysExcluded, DaysExcluded);
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (obj == null || !(obj is WeeklyCalendar))
		{
			return false;
		}
		return Equals((WeeklyCalendar)obj);
	}
}
