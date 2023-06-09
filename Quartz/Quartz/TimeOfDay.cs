using System;

namespace Quartz;

/// <summary>
/// Represents a time in hour, minute and second of any given day.
/// <remarks>
/// <para>
/// The hour is in 24-hour convention, meaning values are from 0 to 23. 
/// </para>
/// </remarks>
/// </summary>
/// <seealso cref="T:Quartz.IDailyTimeIntervalTrigger" />
/// <author>James House</author>
/// <author>Zemian Deng saltnlight5@gmail.com</author>
/// <author>Nuno Maia (.NET)</author>
[Serializable]
public class TimeOfDay
{
	private readonly int hour;

	private readonly int minute;

	private readonly int second;

	/// <summary>
	/// The hour of the day (between 0 and 23). 
	/// </summary>
	public int Hour => hour;

	/// <summary>
	/// The minute of the hour (between 0 and 59). 
	/// </summary>
	public int Minute => minute;

	/// <summary>
	/// The second of the minute (between 0 and 59). 
	/// </summary>
	public int Second => second;

	/// <summary>
	/// Create a TimeOfDay instance for the given hour, minute and second.
	/// </summary>
	/// <param name="hour">The hour of day, between 0 and 23.</param>
	/// <param name="minute">The minute of the hour, between 0 and 59.</param>
	/// <param name="second">The second of the minute, between 0 and 59.</param>
	public TimeOfDay(int hour, int minute, int second)
	{
		this.hour = hour;
		this.minute = minute;
		this.second = second;
		Validate();
	}

	/// <summary>
	/// Create a TimeOfDay instance for the given hour, minute (at the zero second of the minute).
	/// </summary>
	/// <param name="hour">The hour of day, between 0 and 23.</param>
	/// <param name="minute">The minute of the hour, between 0 and 59.</param>
	public TimeOfDay(int hour, int minute)
	{
		this.hour = hour;
		this.minute = minute;
		second = 0;
		Validate();
	}

	private void Validate()
	{
		if (hour < 0 || hour > 23)
		{
			throw new ArgumentException("Hour must be from 0 to 23");
		}
		if (minute < 0 || minute > 59)
		{
			throw new ArgumentException("Minute must be from 0 to 59");
		}
		if (second < 0 || second > 59)
		{
			throw new ArgumentException("Second must be from 0 to 59");
		}
	}

	/// <summary>
	/// Create a TimeOfDay instance for the given hour, minute and second.
	/// </summary>
	/// <param name="hour">The hour of day, between 0 and 23.</param>
	/// <param name="minute">The minute of the hour, between 0 and 59.</param>
	/// <param name="second">The second of the minute, between 0 and 59.</param>
	/// <returns></returns>
	public static TimeOfDay HourMinuteAndSecondOfDay(int hour, int minute, int second)
	{
		return new TimeOfDay(hour, minute, second);
	}

	/// <summary>
	/// Create a TimeOfDay instance for the given hour, minute (at the zero second of the minute)..
	/// </summary>
	/// <param name="hour">The hour of day, between 0 and 23.</param>
	/// <param name="minute">The minute of the hour, between 0 and 59.</param>
	/// <returns>The newly instantiated TimeOfDay</returns>
	public static TimeOfDay HourAndMinuteOfDay(int hour, int minute)
	{
		return new TimeOfDay(hour, minute);
	}

	/// <summary>
	/// Determine with this time of day is before the given time of day.
	/// </summary>
	/// <param name="timeOfDay"></param>
	/// <returns>True this time of day is before the given time of day.</returns>
	public bool Before(TimeOfDay timeOfDay)
	{
		if (timeOfDay.hour > hour)
		{
			return true;
		}
		if (timeOfDay.hour < hour)
		{
			return false;
		}
		if (timeOfDay.minute > minute)
		{
			return true;
		}
		if (timeOfDay.minute < minute)
		{
			return false;
		}
		if (timeOfDay.second > second)
		{
			return true;
		}
		if (timeOfDay.second < second)
		{
			return false;
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (!(obj is TimeOfDay))
		{
			return false;
		}
		TimeOfDay other = (TimeOfDay)obj;
		if (other.hour == hour && other.minute == minute)
		{
			return other.second == second;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return (hour + 1) ^ (minute + 1) ^ (second + 1);
	}

	/// <summary>
	/// Return a date with time of day reset to this object values. The millisecond value will be zero. 
	/// </summary>
	/// <param name="dateTime"></param>
	public DateTimeOffset? GetTimeOfDayForDate(DateTimeOffset? dateTime)
	{
		if (!dateTime.HasValue)
		{
			return null;
		}
		DateTimeOffset cal = new DateTimeOffset(dateTime.Value.Date, dateTime.Value.Offset);
		TimeSpan t = new TimeSpan(0, hour, minute, second);
		return cal.Add(t);
	}

	public override string ToString()
	{
		return "TimeOfDay[" + hour + ":" + minute + ":" + second + "]";
	}
}
