using System;
using System.Runtime.Serialization;
using System.Security;
using Quartz.Collection;
using Quartz.Util;

namespace Quartz.Impl.Calendar;

/// <summary>
/// This implementation of the Calendar stores a list of holidays (full days
/// that are excluded from scheduling).
/// </summary>
/// <remarks>
/// The implementation DOES take the year into consideration, so if you want to
/// exclude July 4th for the next 10 years, you need to add 10 entries to the
/// exclude list.
/// </remarks>
/// <author>Sharada Jambula</author>
/// <author>Juergen Donnerstag</author>
/// <author>Marko Lahma (.NET)</author>
[Serializable]
public class HolidayCalendar : BaseCalendar
{
	private TreeSet<DateTime> dates = new TreeSet<DateTime>();

	/// <summary>
	/// Returns a <see cref="T:Quartz.Collection.ISortedSet`1" /> of Dates representing the excluded
	/// days. Only the month, day and year of the returned dates are
	/// significant.
	/// </summary>
	public virtual ISortedSet<DateTime> ExcludedDates => new TreeSet<DateTime>(dates);

	/// <summary>
	/// Initializes a new instance of the <see cref="T:Quartz.Impl.Calendar.HolidayCalendar" /> class.
	/// </summary>
	public HolidayCalendar()
	{
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="T:Quartz.Impl.Calendar.HolidayCalendar" /> class.
	/// </summary>
	/// <param name="baseCalendar">The base calendar.</param>
	public HolidayCalendar(ICalendar baseCalendar)
	{
		base.CalendarBase = baseCalendar;
	}

	/// <summary>
	/// Serialization constructor.
	/// </summary>
	/// <param name="info"></param>
	/// <param name="context"></param>
	protected HolidayCalendar(SerializationInfo info, StreamingContext context)
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
			object o = info.GetValue("dates", typeof(object));
			if (o is TreeSet oldTreeset)
			{
				{
					foreach (DateTime dateTime in oldTreeset)
					{
						dates.Add(dateTime);
					}
					break;
				}
			}
			dates = (TreeSet<DateTime>)o;
			break;
		}
		case 1:
			dates = (TreeSet<DateTime>)info.GetValue("dates", typeof(TreeSet<DateTime>));
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
		info.AddValue("dates", dates);
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
		if (!base.IsTimeIncluded(timeStampUtc))
		{
			return false;
		}
		timeStampUtc = TimeZoneUtil.ConvertTime(timeStampUtc, TimeZone);
		DateTime lookFor = timeStampUtc.Date;
		return !dates.Contains(lookFor);
	}

	/// <summary>
	/// Determine the next time (in milliseconds) that is 'included' by the
	/// Calendar after the given time.
	/// <para>
	/// Note that this Calendar is only has full-day precision.
	/// </para>
	/// </summary>
	public override DateTimeOffset GetNextIncludedTimeUtc(DateTimeOffset timeUtc)
	{
		DateTimeOffset baseTime = base.GetNextIncludedTimeUtc(timeUtc);
		if (timeUtc != DateTimeOffset.MinValue && baseTime > timeUtc)
		{
			timeUtc = baseTime;
		}
		timeUtc = TimeZoneUtil.ConvertTime(timeUtc, TimeZone);
		DateTimeOffset day = new DateTimeOffset(timeUtc.Date, timeUtc.Offset);
		while (!IsTimeIncluded(day))
		{
			day = day.AddDays(1.0);
		}
		return day;
	}

	/// <summary>
	/// Creates a new object that is a copy of the current instance.
	/// </summary>
	/// <returns>A new object that is a copy of this instance.</returns>
	public override object Clone()
	{
		HolidayCalendar clone = (HolidayCalendar)base.Clone();
		clone.dates = new TreeSet<DateTime>(dates);
		return clone;
	}

	/// <summary>
	/// Add the given Date to the list of excluded days. Only the month, day and
	/// year of the returned dates are significant.
	/// </summary>
	public virtual void AddExcludedDate(DateTime excludedDateUtc)
	{
		DateTime date = excludedDateUtc.Date;
		dates.Add(date);
	}

	/// <summary>
	/// Removes the excluded date.
	/// </summary>
	/// <param name="dateToRemoveUtc">The date to remove.</param>
	public virtual void RemoveExcludedDate(DateTime dateToRemoveUtc)
	{
		DateTime date = dateToRemoveUtc.Date;
		dates.Remove(date);
	}

	public override int GetHashCode()
	{
		int baseHash = 0;
		if (GetBaseCalendar() != null)
		{
			baseHash = GetBaseCalendar().GetHashCode();
		}
		return ExcludedDates.GetHashCode() + 5 * baseHash;
	}

	public bool Equals(HolidayCalendar obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (GetBaseCalendar() == null || GetBaseCalendar().Equals(obj.GetBaseCalendar()))
		{
			return ExcludedDates.Equals(obj.ExcludedDates);
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (obj == null || !(obj is HolidayCalendar))
		{
			return false;
		}
		return Equals((HolidayCalendar)obj);
	}
}
