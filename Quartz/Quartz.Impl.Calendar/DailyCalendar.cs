using System;
using System.Globalization;
using System.Runtime.Serialization;
using System.Security;
using System.Text;
using Quartz.Util;

namespace Quartz.Impl.Calendar;

/// <summary>
/// This implementation of the Calendar excludes (or includes - see below) a
/// specified time range each day. 
/// </summary>
/// <remarks>
/// For example, you could use this calendar to
/// exclude business hours (8AM - 5PM) every day. Each <see cref="T:Quartz.Impl.Calendar.DailyCalendar" />
/// only allows a single time range to be specified, and that time range may not
/// * cross daily boundaries (i.e. you cannot specify a time range from 8PM - 5AM).
/// If the property <see cref="F:Quartz.Impl.Calendar.DailyCalendar.invertTimeRange" /> is <see langword="false" /> (default),
/// the time range defines a range of times in which triggers are not allowed to
/// * fire. If <see cref="F:Quartz.Impl.Calendar.DailyCalendar.invertTimeRange" /> is <see langword="true" />, the time range
/// is inverted: that is, all times <i>outside</i> the defined time range
/// are excluded.
/// <para>
/// Note when using <see cref="T:Quartz.Impl.Calendar.DailyCalendar" />, it behaves on the same principals
/// as, for example, WeeklyCalendar defines a set of days that are
/// excluded <i>every week</i>. Likewise, <see cref="T:Quartz.Impl.Calendar.DailyCalendar" /> defines a
/// set of times that are excluded <i>every day</i>.
/// </para>
/// </remarks>
/// <author>Mike Funk</author>
/// <author>Aaron Craven</author>
/// <author>Marko Lahma (.NET)</author>
[Serializable]
public class DailyCalendar : BaseCalendar
{
	private const string InvalidHourOfDay = "Invalid hour of day: ";

	private const string InvalidMinute = "Invalid minute: ";

	private const string InvalidSecond = "Invalid second: ";

	private const string InvalidMillis = "Invalid millis: ";

	private const string InvalidTimeRange = "Invalid time range: ";

	private const string Separator = " - ";

	private const long OneMillis = 1L;

	private const char Colon = ':';

	private int rangeStartingHourOfDay;

	private int rangeStartingMinute;

	private int rangeStartingSecond;

	private int rangeStartingMillis;

	private int rangeEndingHourOfDay;

	private int rangeEndingMinute;

	private int rangeEndingSecond;

	private int rangeEndingMillis;

	private bool invertTimeRange;

	/// <summary>
	/// Indicates whether the time range represents an inverted time range (see
	/// class description).
	/// </summary>
	/// <value><c>true</c> if invert time range; otherwise, <c>false</c>.</value>
	public bool InvertTimeRange
	{
		get
		{
			return invertTimeRange;
		}
		set
		{
			invertTimeRange = value;
		}
	}

	/// <summary>
	/// Create a <see cref="T:Quartz.Impl.Calendar.DailyCalendar" /> with a time range defined by the
	/// specified strings and no baseCalendar. 
	/// <param name="rangeStartingTime" /> and <param name="rangeEndingTime" />
	/// must be in the format "HH:MM[:SS[:mmm]]" where:
	/// <ul>
	///     <li>
	///         HH is the hour of the specified time. The hour should be
	///          specified using military (24-hour) time and must be in the range
	///          0 to 23.
	///     </li>
	///     <li>
	///         MM is the minute of the specified time and must be in the range
	///         0 to 59.
	///     </li>
	///     <li>
	///         SS is the second of the specified time and must be in the range
	///         0 to 59.
	///     </li>
	///     <li>
	///         mmm is the millisecond of the specified time and must be in the
	///         range 0 to 999.
	///     </li>
	///     <li>items enclosed in brackets ('[', ']') are optional.</li>
	///     <li>
	///         The time range starting time must be before the time range ending
	///         time. Note this means that a time range may not cross daily 
	///         boundaries (10PM - 2AM)
	///     </li>  
	/// </ul>
	/// </summary>
	public DailyCalendar(string rangeStartingTime, string rangeEndingTime)
	{
		SetTimeRange(rangeStartingTime, rangeEndingTime);
	}

	/// <summary>
	/// Create a <see cref="T:Quartz.Impl.Calendar.DailyCalendar" /> with a time range defined by the
	/// specified strings and the specified baseCalendar.
	/// <param name="rangeStartingTime" /> and <param name="rangeEndingTime" />
	/// must be in the format "HH:MM[:SS[:mmm]]" where:
	/// <ul>
	/// 		<li>
	/// HH is the hour of the specified time. The hour should be
	/// specified using military (24-hour) time and must be in the range
	/// 0 to 23.
	/// </li>
	/// 		<li>
	/// MM is the minute of the specified time and must be in the range
	/// 0 to 59.
	/// </li>
	/// 		<li>
	/// SS is the second of the specified time and must be in the range
	/// 0 to 59.
	/// </li>
	/// 		<li>
	/// mmm is the millisecond of the specified time and must be in the
	/// range 0 to 999.
	/// </li>
	/// 		<li>
	/// items enclosed in brackets ('[', ']') are optional.
	/// </li>
	/// 		<li>
	/// The time range starting time must be before the time range ending
	/// time. Note this means that a time range may not cross daily
	/// boundaries (10PM - 2AM)
	/// </li>
	/// 	</ul>
	/// </summary>
	/// <param name="baseCalendar">The base calendar for this calendar instance see BaseCalendar for more
	/// information on base calendar functionality.</param>
	public DailyCalendar(ICalendar baseCalendar, string rangeStartingTime, string rangeEndingTime)
		: base(baseCalendar)
	{
		SetTimeRange(rangeStartingTime, rangeEndingTime);
	}

	/// <summary>
	/// Create a <see cref="T:Quartz.Impl.Calendar.DailyCalendar" /> with a time range defined by the
	/// specified values and no baseCalendar. Values are subject to
	/// the following validations:
	/// <ul>
	///     <li>
	///         Hours must be in the range 0-23 and are expressed using military
	/// 	    (24-hour) time.
	///     </li>
	/// 	<li>Minutes must be in the range 0-59</li>
	/// 	<li>Seconds must be in the range 0-59</li>
	/// 	<li>Milliseconds must be in the range 0-999</li>
	/// 	<li>
	///         The time range starting time must be before the time range ending
	/// 	    time. Note this means that a time range may not cross daily 
	/// 	    boundaries (10PM - 2AM)
	///     </li>  
	/// </ul>
	/// </summary>
	/// <param name="rangeStartingHourOfDay">The range starting hour of day.</param>
	/// <param name="rangeStartingMinute">The range starting minute.</param>
	/// <param name="rangeStartingSecond">The range starting second.</param>
	/// <param name="rangeStartingMillis">The range starting millis.</param>
	/// <param name="rangeEndingHourOfDay">The range ending hour of day.</param>
	/// <param name="rangeEndingMinute">The range ending minute.</param>
	/// <param name="rangeEndingSecond">The range ending second.</param>
	/// <param name="rangeEndingMillis">The range ending millis.</param>
	public DailyCalendar(int rangeStartingHourOfDay, int rangeStartingMinute, int rangeStartingSecond, int rangeStartingMillis, int rangeEndingHourOfDay, int rangeEndingMinute, int rangeEndingSecond, int rangeEndingMillis)
	{
		SetTimeRange(rangeStartingHourOfDay, rangeStartingMinute, rangeStartingSecond, rangeStartingMillis, rangeEndingHourOfDay, rangeEndingMinute, rangeEndingSecond, rangeEndingMillis);
	}

	/// <summary>
	/// Create a <see cref="T:Quartz.Impl.Calendar.DailyCalendar" /> with a time range defined by the
	/// specified values and the specified <param name="baseCalendar" />. Values are
	/// subject to the following validations:
	/// <ul>
	/// 		<li>
	/// Hours must be in the range 0-23 and are expressed using military
	/// (24-hour) time.
	/// </li>
	/// 		<li>Minutes must be in the range 0-59</li>
	/// 		<li>Seconds must be in the range 0-59</li>
	/// 		<li>Milliseconds must be in the range 0-999</li>
	/// 		<li>
	/// The time range starting time must be before the time range ending
	/// time. Note this means that a time range may not cross daily
	/// boundaries (10PM - 2AM)
	/// </li>
	/// 	</ul>
	/// </summary>
	/// <param name="rangeStartingHourOfDay">The range starting hour of day.</param>
	/// <param name="rangeStartingMinute">The range starting minute.</param>
	/// <param name="rangeStartingSecond">The range starting second.</param>
	/// <param name="rangeStartingMillis">The range starting millis.</param>
	/// <param name="rangeEndingHourOfDay">The range ending hour of day.</param>
	/// <param name="rangeEndingMinute">The range ending minute.</param>
	/// <param name="rangeEndingSecond">The range ending second.</param>
	/// <param name="rangeEndingMillis">The range ending millis.</param>
	public DailyCalendar(ICalendar baseCalendar, int rangeStartingHourOfDay, int rangeStartingMinute, int rangeStartingSecond, int rangeStartingMillis, int rangeEndingHourOfDay, int rangeEndingMinute, int rangeEndingSecond, int rangeEndingMillis)
		: base(baseCalendar)
	{
		SetTimeRange(rangeStartingHourOfDay, rangeStartingMinute, rangeStartingSecond, rangeStartingMillis, rangeEndingHourOfDay, rangeEndingMinute, rangeEndingSecond, rangeEndingMillis);
	}

	/// <summary>
	/// Create a <see cref="T:Quartz.Impl.Calendar.DailyCalendar" /> with a time range defined by the
	/// specified <see cref="T:System.DateTime" />s and no 
	/// baseCalendar. The Calendars are subject to the following
	/// considerations:
	/// <ul>
	///     <li>
	///         Only the time-of-day fields of the specified Calendars will be
	/// 	    used (the date fields will be ignored)
	///     </li>
	/// 	<li>
	///         The starting time must be before the ending time of the defined
	/// 	    time range. Note this means that a time range may not cross
	/// 	    daily boundaries (10PM - 2AM). <i>(because only time fields are
	/// 	    are used, it is possible for two Calendars to represent a valid
	/// 	    time range and 
	/// 	    <c>rangeStartingCalendar.after(rangeEndingCalendar) ==  true</c>)
	/// 		</i>
	///     </li>  
	/// </ul> 
	/// </summary>
	/// <param name="rangeStartingCalendarUtc">The range starting calendar.</param>
	/// <param name="rangeEndingCalendarUtc">The range ending calendar.</param>
	public DailyCalendar(DateTime rangeStartingCalendarUtc, DateTime rangeEndingCalendarUtc)
	{
		SetTimeRange(rangeStartingCalendarUtc, rangeEndingCalendarUtc);
	}

	/// <summary>
	/// Create a <see cref="T:Quartz.Impl.Calendar.DailyCalendar" /> with a time range defined by the
	/// specified <see cref="T:System.DateTime" />s and the specified
	/// <param name="baseCalendar" />. The Calendars are subject to the following
	/// considerations:
	/// <ul>
	/// 		<li>
	/// Only the time-of-day fields of the specified Calendars will be
	/// used (the date fields will be ignored)
	/// </li>
	/// 		<li>
	/// The starting time must be before the ending time of the defined
	/// time range. Note this means that a time range may not cross
	/// daily boundaries (10PM - 2AM). <i>(because only time fields are
	/// are used, it is possible for two Calendars to represent a valid
	/// time range and
	/// <c>rangeStartingCalendarUtc &gt; rangeEndingCalendarUtc == true</c>)</i>
	/// 		</li>
	/// 	</ul>
	/// </summary>
	/// <param name="rangeStartingCalendarUtc">The range starting calendar.</param>
	/// <param name="rangeEndingCalendarUtc">The range ending calendar.</param>
	public DailyCalendar(ICalendar baseCalendar, DateTime rangeStartingCalendarUtc, DateTime rangeEndingCalendarUtc)
		: base(baseCalendar)
	{
		SetTimeRange(rangeStartingCalendarUtc, rangeEndingCalendarUtc);
	}

	/// <summary>
	/// Create a <see cref="T:Quartz.Impl.Calendar.DailyCalendar" /> with a time range defined by the
	/// specified values and no baseCalendar. The values are 
	/// subject to the following considerations:
	/// <ul>
	///     <li>
	///         Only the time-of-day portion of the specified values will be
	/// 	    used
	///     </li>
	/// 	<li>
	///         The starting time must be before the ending time of the defined
	/// 	    time range. Note this means that a time range may not cross
	/// 	    daily boundaries (10PM - 2AM). <i>(because only time value are
	/// 	    are used, it is possible for the two values to represent a valid
	/// 	    time range and <c>rangeStartingTime &gt; rangeEndingTime</c>)</i>
	///     </li>  
	/// </ul> 
	/// </summary>
	/// <param name="rangeStartingTimeInMillis">The range starting time in millis.</param>
	/// <param name="rangeEndingTimeInMillis">The range ending time in millis.</param>
	public DailyCalendar(long rangeStartingTimeInMillis, long rangeEndingTimeInMillis)
	{
		SetTimeRange(rangeStartingTimeInMillis, rangeEndingTimeInMillis);
	}

	/// <summary>
	/// Create a <see cref="T:Quartz.Impl.Calendar.DailyCalendar" /> with a time range defined by the
	/// specified values and the specified <param name="baseCalendar" />. The values
	/// are subject to the following considerations:
	/// <ul>
	/// 		<li>
	/// Only the time-of-day portion of the specified values will be
	/// used
	/// </li>
	/// 		<li>
	/// The starting time must be before the ending time of the defined
	/// time range. Note this means that a time range may not cross
	/// daily boundaries (10PM - 2AM). <i>(because only time value are
	/// are used, it is possible for the two values to represent a valid
	/// time range and <c>rangeStartingTime &gt; rangeEndingTime</c>)</i>
	/// 		</li>
	/// 	</ul>
	/// </summary>
	/// <param name="rangeStartingTimeInMillis">The range starting time in millis.</param>
	/// <param name="rangeEndingTimeInMillis">The range ending time in millis.</param>
	public DailyCalendar(ICalendar baseCalendar, long rangeStartingTimeInMillis, long rangeEndingTimeInMillis)
		: base(baseCalendar)
	{
		SetTimeRange(rangeStartingTimeInMillis, rangeEndingTimeInMillis);
	}

	/// <summary>
	/// Serialization constructor.
	/// </summary>
	/// <param name="info"></param>
	/// <param name="context"></param>
	protected DailyCalendar(SerializationInfo info, StreamingContext context)
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
			rangeStartingHourOfDay = info.GetInt32("rangeStartingHourOfDay");
			rangeStartingMinute = info.GetInt32("rangeStartingMinute");
			rangeStartingSecond = info.GetInt32("rangeStartingSecond");
			rangeStartingMillis = info.GetInt32("rangeStartingMillis");
			rangeEndingHourOfDay = info.GetInt32("rangeEndingHourOfDay");
			rangeEndingMinute = info.GetInt32("rangeEndingMinute");
			rangeEndingSecond = info.GetInt32("rangeEndingSecond");
			rangeEndingMillis = info.GetInt32("rangeEndingMillis");
			invertTimeRange = info.GetBoolean("invertTimeRange");
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
		info.AddValue("rangeStartingHourOfDay", rangeStartingHourOfDay);
		info.AddValue("rangeStartingMinute", rangeStartingMinute);
		info.AddValue("rangeStartingSecond", rangeStartingSecond);
		info.AddValue("rangeStartingMillis", rangeStartingMillis);
		info.AddValue("rangeEndingHourOfDay", rangeEndingHourOfDay);
		info.AddValue("rangeEndingMinute", rangeEndingMinute);
		info.AddValue("rangeEndingSecond", rangeEndingSecond);
		info.AddValue("rangeEndingMillis", rangeEndingMillis);
		info.AddValue("invertTimeRange", invertTimeRange);
	}

	/// <summary>
	/// Determine whether the given time  is 'included' by the
	/// Calendar.
	/// </summary>
	/// <param name="timeUtc"></param>
	/// <returns></returns>
	public override bool IsTimeIncluded(DateTimeOffset timeUtc)
	{
		if (GetBaseCalendar() != null && !GetBaseCalendar().IsTimeIncluded(timeUtc))
		{
			return false;
		}
		timeUtc = TimeZoneUtil.ConvertTime(timeUtc, TimeZone);
		DateTimeOffset startOfDayInMillis = GetStartOfDay(timeUtc);
		DateTimeOffset endOfDayInMillis = GetEndOfDay(timeUtc);
		DateTimeOffset timeRangeStartingTimeInMillis = GetTimeRangeStartingTimeUtc(timeUtc);
		DateTimeOffset timeRangeEndingTimeInMillis = GetTimeRangeEndingTimeUtc(timeUtc);
		if (!invertTimeRange)
		{
			if ((timeUtc > startOfDayInMillis && timeUtc < timeRangeStartingTimeInMillis) || (timeUtc > timeRangeEndingTimeInMillis && timeUtc < endOfDayInMillis))
			{
				return true;
			}
			return false;
		}
		if (timeUtc >= timeRangeStartingTimeInMillis && timeUtc <= timeRangeEndingTimeInMillis)
		{
			return true;
		}
		return false;
	}

	/// <summary>
	/// Determine the next time (in milliseconds) that is 'included' by the
	/// Calendar after the given time. Return the original value if timeStamp is
	/// included. Return 0 if all days are excluded.
	/// </summary>
	/// <param name="timeUtc"></param>
	/// <returns></returns>
	/// <seealso cref="M:Quartz.ICalendar.GetNextIncludedTimeUtc(System.DateTimeOffset)" />
	public override DateTimeOffset GetNextIncludedTimeUtc(DateTimeOffset timeUtc)
	{
		DateTimeOffset nextIncludedTime = timeUtc.AddMilliseconds(1.0);
		while (!IsTimeIncluded(nextIncludedTime))
		{
			nextIncludedTime = (invertTimeRange ? ((!(nextIncludedTime < GetTimeRangeStartingTimeUtc(nextIncludedTime))) ? ((!(nextIncludedTime > GetTimeRangeEndingTimeUtc(nextIncludedTime))) ? ((GetBaseCalendar() == null || GetBaseCalendar().IsTimeIncluded(nextIncludedTime)) ? nextIncludedTime.AddMilliseconds(1.0) : GetBaseCalendar().GetNextIncludedTimeUtc(nextIncludedTime)) : GetEndOfDay(nextIncludedTime).AddMilliseconds(1.0)) : GetTimeRangeStartingTimeUtc(nextIncludedTime)) : ((nextIncludedTime >= GetTimeRangeStartingTimeUtc(nextIncludedTime) && nextIncludedTime <= GetTimeRangeEndingTimeUtc(nextIncludedTime)) ? GetTimeRangeEndingTimeUtc(nextIncludedTime).AddMilliseconds(1.0) : ((GetBaseCalendar() == null || GetBaseCalendar().IsTimeIncluded(nextIncludedTime)) ? nextIncludedTime.AddMilliseconds(1.0) : GetBaseCalendar().GetNextIncludedTimeUtc(nextIncludedTime))));
		}
		return nextIncludedTime;
	}

	public override object Clone()
	{
		return (DailyCalendar)base.Clone();
	}

	/// <summary>
	/// Returns the start time of the time range of the day 
	/// specified in <param name="timeUtc" />.
	/// </summary>
	/// <returns>
	///     a DateTime representing the start time of the
	///     time range for the specified date.
	/// </returns>
	public DateTimeOffset GetTimeRangeStartingTimeUtc(DateTimeOffset timeUtc)
	{
		return new DateTimeOffset(timeUtc.Year, timeUtc.Month, timeUtc.Day, rangeStartingHourOfDay, rangeStartingMinute, rangeStartingSecond, rangeStartingMillis, timeUtc.Offset);
	}

	/// <summary>
	/// Returns the end time of the time range of the day
	/// specified in <param name="timeUtc" />
	/// </summary>
	/// <returns>
	/// A DateTime representing the end time of the
	/// time range for the specified date.
	/// </returns>
	public DateTimeOffset GetTimeRangeEndingTimeUtc(DateTimeOffset timeUtc)
	{
		return new DateTimeOffset(timeUtc.Year, timeUtc.Month, timeUtc.Day, rangeEndingHourOfDay, rangeEndingMinute, rangeEndingSecond, rangeEndingMillis, timeUtc.Offset);
	}

	/// <summary>
	/// Returns a <see cref="T:System.String"></see> that represents the current <see cref="T:System.Object"></see>.
	/// </summary>
	/// <returns>
	/// A <see cref="T:System.String"></see> that represents the current <see cref="T:System.Object"></see>.
	/// </returns>
	public override string ToString()
	{
		StringBuilder buffer = new StringBuilder();
		buffer.Append("base calendar: [");
		if (GetBaseCalendar() != null)
		{
			buffer.Append(GetBaseCalendar());
		}
		else
		{
			buffer.Append("null");
		}
		buffer.Append("], time range: '");
		buffer.Append(rangeStartingHourOfDay.ToString("00", CultureInfo.InvariantCulture));
		buffer.Append(":");
		buffer.Append(rangeStartingMinute.ToString("00", CultureInfo.InvariantCulture));
		buffer.Append(":");
		buffer.Append(rangeStartingSecond.ToString("00", CultureInfo.InvariantCulture));
		buffer.Append(":");
		buffer.Append(rangeStartingMillis.ToString("000", CultureInfo.InvariantCulture));
		buffer.Append(" - ");
		buffer.Append(rangeEndingHourOfDay.ToString("00", CultureInfo.InvariantCulture));
		buffer.Append(":");
		buffer.Append(rangeEndingMinute.ToString("00", CultureInfo.InvariantCulture));
		buffer.Append(":");
		buffer.Append(rangeEndingSecond.ToString("00", CultureInfo.InvariantCulture));
		buffer.Append(":");
		buffer.Append(rangeEndingMillis.ToString("000", CultureInfo.InvariantCulture));
		buffer.AppendFormat("', inverted: {0}]", invertTimeRange);
		return buffer.ToString();
	}

	/// <summary>
	/// Sets the time range for the <see cref="T:Quartz.Impl.Calendar.DailyCalendar" /> to the times 
	/// represented in the specified Strings. 
	/// </summary>
	/// <param name="rangeStartingTimeString">The range starting time string.</param>
	/// <param name="rangeEndingTimeString">The range ending time string.</param>
	public void SetTimeRange(string rangeStartingTimeString, string rangeEndingTimeString)
	{
		string[] rangeStartingTime = rangeStartingTimeString.Split(':');
		if (rangeStartingTime.Length < 2 || rangeStartingTime.Length > 4)
		{
			throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "Invalid time string '{0}'", new object[1] { rangeStartingTimeString }));
		}
		int rangeStartingHourOfDay = Convert.ToInt32(rangeStartingTime[0], CultureInfo.InvariantCulture);
		int rangeStartingMinute = Convert.ToInt32(rangeStartingTime[1], CultureInfo.InvariantCulture);
		int rangeStartingSecond = ((rangeStartingTime.Length > 2) ? Convert.ToInt32(rangeStartingTime[2], CultureInfo.InvariantCulture) : 0);
		int rangeStartingMillis = ((rangeStartingTime.Length == 4) ? Convert.ToInt32(rangeStartingTime[3], CultureInfo.InvariantCulture) : 0);
		string[] rangeEndingTime = rangeEndingTimeString.Split(':');
		if (rangeEndingTime.Length < 2 || rangeEndingTime.Length > 4)
		{
			throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "Invalid time string '{0}'", new object[1] { rangeEndingTimeString }));
		}
		int rangeEndingHourOfDay = Convert.ToInt32(rangeEndingTime[0], CultureInfo.InvariantCulture);
		int rangeEndingMinute = Convert.ToInt32(rangeEndingTime[1], CultureInfo.InvariantCulture);
		int rangeEndingSecond = ((rangeEndingTime.Length > 2) ? Convert.ToInt32(rangeEndingTime[2], CultureInfo.InvariantCulture) : 0);
		int rangeEndingMillis = ((rangeEndingTime.Length == 4) ? Convert.ToInt32(rangeEndingTime[3], CultureInfo.InvariantCulture) : 0);
		SetTimeRange(rangeStartingHourOfDay, rangeStartingMinute, rangeStartingSecond, rangeStartingMillis, rangeEndingHourOfDay, rangeEndingMinute, rangeEndingSecond, rangeEndingMillis);
	}

	/// <summary>
	/// Sets the time range for the <see cref="T:Quartz.Impl.Calendar.DailyCalendar" /> to the times
	/// represented in the specified values. 
	/// </summary>
	/// <param name="rangeStartingHourOfDay">The range starting hour of day.</param>
	/// <param name="rangeStartingMinute">The range starting minute.</param>
	/// <param name="rangeStartingSecond">The range starting second.</param>
	/// <param name="rangeStartingMillis">The range starting millis.</param>
	/// <param name="rangeEndingHourOfDay">The range ending hour of day.</param>
	/// <param name="rangeEndingMinute">The range ending minute.</param>
	/// <param name="rangeEndingSecond">The range ending second.</param>
	/// <param name="rangeEndingMillis">The range ending millis.</param>
	public void SetTimeRange(int rangeStartingHourOfDay, int rangeStartingMinute, int rangeStartingSecond, int rangeStartingMillis, int rangeEndingHourOfDay, int rangeEndingMinute, int rangeEndingSecond, int rangeEndingMillis)
	{
		Validate(rangeStartingHourOfDay, rangeStartingMinute, rangeStartingSecond, rangeStartingMillis);
		Validate(rangeEndingHourOfDay, rangeEndingMinute, rangeEndingSecond, rangeEndingMillis);
		DateTimeOffset startCal = SystemTime.UtcNow();
		startCal = new DateTimeOffset(startCal.Year, startCal.Month, startCal.Day, rangeStartingHourOfDay, rangeStartingMinute, rangeStartingSecond, rangeStartingMillis, TimeSpan.Zero);
		DateTimeOffset endCal = SystemTime.UtcNow();
		endCal = new DateTimeOffset(endCal.Year, endCal.Month, endCal.Day, rangeEndingHourOfDay, rangeEndingMinute, rangeEndingSecond, rangeEndingMillis, TimeSpan.Zero);
		if (!(startCal < endCal))
		{
			throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "{0}{1}:{2}:{3}:{4}{5}{6}:{7}:{8}:{9}", "Invalid time range: ", rangeStartingHourOfDay, rangeStartingMinute, rangeStartingSecond, rangeStartingMillis, " - ", rangeEndingHourOfDay, rangeEndingMinute, rangeEndingSecond, rangeEndingMillis));
		}
		this.rangeStartingHourOfDay = rangeStartingHourOfDay;
		this.rangeStartingMinute = rangeStartingMinute;
		this.rangeStartingSecond = rangeStartingSecond;
		this.rangeStartingMillis = rangeStartingMillis;
		this.rangeEndingHourOfDay = rangeEndingHourOfDay;
		this.rangeEndingMinute = rangeEndingMinute;
		this.rangeEndingSecond = rangeEndingSecond;
		this.rangeEndingMillis = rangeEndingMillis;
	}

	/// <summary>
	/// Sets the time range for the <see cref="T:Quartz.Impl.Calendar.DailyCalendar" /> to the times
	/// represented in the specified <see cref="T:System.DateTime" />s. 
	/// </summary>
	/// <param name="rangeStartingCalendarUtc">The range starting calendar.</param>
	/// <param name="rangeEndingCalendarUtc">The range ending calendar.</param>
	public void SetTimeRange(DateTime rangeStartingCalendarUtc, DateTime rangeEndingCalendarUtc)
	{
		SetTimeRange(rangeStartingCalendarUtc.Hour, rangeStartingCalendarUtc.Minute, rangeStartingCalendarUtc.Second, rangeStartingCalendarUtc.Millisecond, rangeEndingCalendarUtc.Hour, rangeEndingCalendarUtc.Minute, rangeEndingCalendarUtc.Second, rangeEndingCalendarUtc.Millisecond);
	}

	/// <summary>
	/// Sets the time range for the <see cref="T:Quartz.Impl.Calendar.DailyCalendar" /> to the times
	/// represented in the specified values. 
	/// </summary>
	/// <param name="rangeStartingTime">The range starting time.</param>
	/// <param name="rangeEndingTime">The range ending time.</param>
	public void SetTimeRange(long rangeStartingTime, long rangeEndingTime)
	{
		SetTimeRange(new DateTime(rangeStartingTime), new DateTime(rangeEndingTime));
	}

	/// <summary>
	/// Gets the start of day, practically zeroes time part.
	/// </summary>
	/// <param name="time">The time.</param>
	/// <returns></returns>
	private static DateTimeOffset GetStartOfDay(DateTimeOffset time)
	{
		return time.Date;
	}

	/// <summary>
	/// Gets the end of day, pratically sets time parts to maximum allowed values.
	/// </summary>
	/// <param name="time">The time.</param>
	/// <returns></returns>
	private static DateTimeOffset GetEndOfDay(DateTimeOffset time)
	{
		DateTime endOfDay = new DateTime(time.Year, time.Month, time.Day, 23, 59, 59, 999);
		return endOfDay;
	}

	/// <summary>
	/// Checks the specified values for validity as a set of time values.
	/// </summary>
	/// <param name="hourOfDay">The hour of day.</param>
	/// <param name="minute">The minute.</param>
	/// <param name="second">The second.</param>
	/// <param name="millis">The millis.</param>
	private static void Validate(int hourOfDay, int minute, int second, int millis)
	{
		if (hourOfDay < 0 || hourOfDay > 23)
		{
			throw new ArgumentException("Invalid hour of day: " + hourOfDay);
		}
		if (minute < 0 || minute > 59)
		{
			throw new ArgumentException("Invalid minute: " + minute);
		}
		if (second < 0 || second > 59)
		{
			throw new ArgumentException("Invalid second: " + second);
		}
		if (millis < 0 || millis > 999)
		{
			throw new ArgumentException("Invalid millis: " + millis);
		}
	}

	public override int GetHashCode()
	{
		int baseHash = 0;
		if (GetBaseCalendar() != null)
		{
			baseHash = GetBaseCalendar().GetHashCode();
		}
		return rangeStartingHourOfDay.GetHashCode() + rangeEndingHourOfDay.GetHashCode() + 2 * (rangeStartingMinute.GetHashCode() + rangeEndingMinute.GetHashCode()) + 3 * (rangeStartingSecond.GetHashCode() + rangeEndingSecond.GetHashCode()) + 4 * (rangeStartingMillis.GetHashCode() + rangeEndingMillis.GetHashCode()) + 5 * baseHash;
	}

	public bool Equals(DailyCalendar obj)
	{
		if (obj == null)
		{
			return false;
		}
		if ((GetBaseCalendar() == null || GetBaseCalendar().Equals(obj.GetBaseCalendar())) && InvertTimeRange == obj.InvertTimeRange && rangeStartingHourOfDay == obj.rangeStartingHourOfDay && rangeStartingMinute == obj.rangeStartingMinute && rangeStartingSecond == obj.rangeStartingSecond && rangeStartingMillis == obj.rangeStartingMillis && rangeEndingHourOfDay == obj.rangeEndingHourOfDay && rangeEndingMinute == obj.rangeEndingMinute && rangeEndingSecond == obj.rangeEndingSecond)
		{
			return rangeEndingMillis == obj.rangeEndingMillis;
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (obj == null || !(obj is DailyCalendar))
		{
			return false;
		}
		return Equals((DailyCalendar)obj);
	}
}
