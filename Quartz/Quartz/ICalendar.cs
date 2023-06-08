using System;

namespace Quartz;

/// <summary> 
/// An interface to be implemented by objects that define spaces of time during 
/// which an associated <see cref="T:Quartz.ITrigger" /> may (not) fire. Calendars 
/// do not define actual fire times, but rather are used to limit a 
/// <see cref="T:Quartz.ITrigger" /> from firing on its normal schedule if necessary. Most 
/// Calendars include all times by default and allow the user to specify times 
/// to exclude. 
/// </summary>
/// <remarks>
/// As such, it is often useful to think of Calendars as being used to <I>exclude</I> a block
/// of time - as opposed to <I>include</I> a block of time. (i.e. the 
/// schedule "fire every five minutes except on Sundays" could be 
/// implemented with a <see cref="T:Quartz.ISimpleTrigger" /> and a 
/// <see cref="T:Quartz.Impl.Calendar.WeeklyCalendar" /> which excludes Sundays)
/// <para>
/// Implementations MUST take care of being properly cloneable and Serializable.
/// </para>
/// </remarks>
/// <author>James House</author>
/// <author>Juergen Donnerstag</author>
/// <author>Marko Lahma (.NET)</author>
public interface ICalendar : ICloneable
{
	/// <summary> 
	/// Gets or sets a description for the <see cref="T:Quartz.ICalendar" /> instance - may be
	/// useful for remembering/displaying the purpose of the calendar, though
	/// the description has no meaning to Quartz.
	/// </summary>
	string Description { get; set; }

	/// <summary>
	/// Set a new base calendar or remove the existing one.
	/// Get the base calendar.
	/// </summary>
	ICalendar CalendarBase { get; set; }

	/// <summary>
	/// Determine whether the given UTC time  is 'included' by the
	/// Calendar.
	/// </summary>
	bool IsTimeIncluded(DateTimeOffset timeUtc);

	/// <summary>
	/// Determine the next UTC time that is 'included' by the
	/// Calendar after the given UTC time.
	/// </summary>
	DateTimeOffset GetNextIncludedTimeUtc(DateTimeOffset timeUtc);
}
