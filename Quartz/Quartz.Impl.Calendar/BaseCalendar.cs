using System;
using System.Runtime.Serialization;
using System.Security;

namespace Quartz.Impl.Calendar;

/// <summary>
/// This implementation of the Calendar may be used (you don't have to) as a
/// base class for more sophisticated one's. It merely implements the base
/// functionality required by each Calendar.
/// </summary>
/// <remarks>
/// Regarded as base functionality is the treatment of base calendars. Base
/// calendar allow you to chain (stack) as much calendars as you may need. For
/// example to exclude weekends you may use WeeklyCalendar. In order to exclude
/// holidays as well you may define a WeeklyCalendar instance to be the base
/// calendar for HolidayCalendar instance.
/// </remarks>
/// <seealso cref="T:Quartz.ICalendar" /> 
/// <author>Juergen Donnerstag</author>
/// <author>James House</author>
/// <author>Marko Lahma (.NET)</author>
[Serializable]
public class BaseCalendar : ICalendar, ICloneable, ISerializable
{
	private ICalendar baseCalendar;

	private string description;

	private TimeZoneInfo timeZone;

	/// <summary>
	/// Gets or sets the time zone.
	/// </summary>
	/// <value>The time zone.</value>
	public virtual TimeZoneInfo TimeZone
	{
		get
		{
			if (timeZone == null)
			{
				timeZone = TimeZoneInfo.Local;
			}
			return timeZone;
		}
		set
		{
			timeZone = value;
		}
	}

	/// <summary> 
	/// Gets or sets the description given to the <see cref="T:Quartz.ICalendar" /> instance by
	/// its creator (if any).
	/// </summary>
	public virtual string Description
	{
		get
		{
			return description;
		}
		set
		{
			description = value;
		}
	}

	/// <summary>
	/// Set a new base calendar or remove the existing one
	/// </summary>
	/// <value></value>
	public ICalendar CalendarBase
	{
		get
		{
			return baseCalendar;
		}
		set
		{
			baseCalendar = value;
		}
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="T:Quartz.Impl.Calendar.BaseCalendar" /> class.
	/// </summary>
	public BaseCalendar()
	{
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="T:Quartz.Impl.Calendar.BaseCalendar" /> class.
	/// </summary>
	/// <param name="baseCalendar">The base calendar.</param>
	public BaseCalendar(ICalendar baseCalendar)
	{
		CalendarBase = baseCalendar;
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="T:Quartz.Impl.Calendar.BaseCalendar" /> class.
	/// </summary>
	/// <param name="timeZone">The time zone.</param>
	public BaseCalendar(TimeZoneInfo timeZone)
	{
		this.timeZone = timeZone;
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="T:Quartz.Impl.Calendar.BaseCalendar" /> class.
	/// </summary>
	/// <param name="baseCalendar">The base calendar.</param>
	/// <param name="timeZone">The time zone.</param>
	public BaseCalendar(ICalendar baseCalendar, TimeZoneInfo timeZone)
	{
		this.baseCalendar = baseCalendar;
		this.timeZone = timeZone;
	}

	/// <summary>
	/// Serialization constructor.
	/// </summary>
	/// <param name="info"></param>
	/// <param name="context"></param>
	protected BaseCalendar(SerializationInfo info, StreamingContext context)
	{
		string prefix = "";
		try
		{
			info.GetValue("description", typeof(string));
		}
		catch
		{
			prefix = "BaseCalendar+";
		}
		baseCalendar = (ICalendar)info.GetValue(prefix + "baseCalendar", typeof(ICalendar));
		description = (string)info.GetValue(prefix + "description", typeof(string));
		timeZone = (TimeZoneInfo)info.GetValue(prefix + "timeZone", typeof(TimeZoneInfo));
	}

	[SecurityCritical]
	public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		info.AddValue("baseCalendar", baseCalendar);
		info.AddValue("description", description);
		info.AddValue("timeZone", timeZone);
	}

	/// <summary>
	/// checks whether two arrays have 
	/// the same length and 
	/// for any given place there are equal elements 
	/// in both arrays
	/// </summary>
	/// <returns></returns>
	protected static bool ArraysEqualElementsOnEqualPlaces(Array array1, Array array2)
	{
		if (array1.Length != array2.Length)
		{
			return false;
		}
		bool toReturn = true;
		for (int i = 0; i < array1.Length; i++)
		{
			toReturn = toReturn && array1.GetValue(i).Equals(array2.GetValue(i));
		}
		return toReturn;
	}

	/// <summary>
	/// Get the base calendar. Will be null, if not set.
	/// </summary>
	public ICalendar GetBaseCalendar()
	{
		return baseCalendar;
	}

	/// <summary>
	/// Check if date/time represented by timeStamp is included. If included
	/// return true. The implementation of BaseCalendar simply calls the base
	/// calendars IsTimeIncluded() method if base calendar is set.
	/// </summary>
	/// <seealso cref="M:Quartz.ICalendar.IsTimeIncluded(System.DateTimeOffset)" />
	public virtual bool IsTimeIncluded(DateTimeOffset timeStampUtc)
	{
		if (timeStampUtc == DateTimeOffset.MinValue)
		{
			throw new ArgumentException("timeStampUtc must be greater 0");
		}
		if (baseCalendar != null && !baseCalendar.IsTimeIncluded(timeStampUtc))
		{
			return false;
		}
		return true;
	}

	/// <summary>
	/// Determine the next UTC time (in milliseconds) that is 'included' by the
	/// Calendar after the given time. Return the original value if timeStamp is
	/// included. Return 0 if all days are excluded.
	/// </summary>
	/// <seealso cref="M:Quartz.ICalendar.GetNextIncludedTimeUtc(System.DateTimeOffset)" />
	public virtual DateTimeOffset GetNextIncludedTimeUtc(DateTimeOffset timeUtc)
	{
		if (timeUtc == DateTimeOffset.MinValue)
		{
			throw new ArgumentException("timeStamp must be greater DateTimeOffset.MinValue");
		}
		if (baseCalendar != null)
		{
			return baseCalendar.GetNextIncludedTimeUtc(timeUtc);
		}
		return timeUtc;
	}

	/// <summary>
	/// Creates a new object that is a copy of the current instance.
	/// </summary>
	/// <returns>A new object that is a copy of this instance.</returns>
	public virtual object Clone()
	{
		BaseCalendar clone = (BaseCalendar)MemberwiseClone();
		if (GetBaseCalendar() != null)
		{
			clone.baseCalendar = (ICalendar)GetBaseCalendar().Clone();
		}
		return clone;
	}
}
