using System;
using System.Collections.Generic;
using Quartz.Spi;

namespace Quartz;

/// <summary>
/// Convenience and utility methods for simplifying the construction and
/// configuration of <see cref="T:Quartz.ITrigger" />s and DateTimeOffsetOffsets.
/// </summary>
/// <seealso cref="T:Quartz.ICronTrigger" />
/// <seealso cref="T:Quartz.ISimpleTrigger" />
/// <author>James House</author>
/// <author>Marko Lahma (.NET)</author>
public static class TriggerUtils
{
	/// <summary>
	/// Returns a list of Dates that are the next fire times of a
	/// <see cref="T:Quartz.ITrigger" />.
	/// The input trigger will be cloned before any work is done, so you need
	/// not worry about its state being altered by this method.
	/// </summary>
	/// <param name="trigg">The trigger upon which to do the work</param>
	/// <param name="cal">The calendar to apply to the trigger's schedule</param>
	/// <param name="numTimes">The number of next fire times to produce</param>
	/// <returns>List of java.util.Date objects</returns>
	public static IList<DateTimeOffset> ComputeFireTimes(IOperableTrigger trigg, ICalendar cal, int numTimes)
	{
		List<DateTimeOffset> lst = new List<DateTimeOffset>();
		IOperableTrigger t = (IOperableTrigger)trigg.Clone();
		if (!t.GetNextFireTimeUtc().HasValue || !t.GetNextFireTimeUtc().HasValue)
		{
			t.ComputeFirstFireTimeUtc(cal);
		}
		for (int i = 0; i < numTimes; i++)
		{
			DateTimeOffset? d = t.GetNextFireTimeUtc();
			if (!d.HasValue)
			{
				break;
			}
			lst.Add(d.Value);
			t.Triggered(cal);
		}
		return lst.AsReadOnly();
	}

	/// <summary>
	/// Compute the <see cref="T:System.DateTimeOffset" /> that is 1 second after the Nth firing of 
	/// the given <see cref="T:Quartz.ITrigger" />, taking the triger's associated 
	/// <see cref="T:Quartz.ICalendar" /> into consideration.
	/// </summary>
	/// <remarks>
	/// The input trigger will be cloned before any work is done, so you need
	/// not worry about its state being altered by this method.
	/// </remarks>
	/// <param name="trigger">The trigger upon which to do the work</param>
	/// <param name="calendar">The calendar to apply to the trigger's schedule</param>
	/// <param name="numberOfTimes">The number of next fire times to produce</param>
	/// <returns>the computed Date, or null if the trigger (as configured) will not fire that many times</returns>
	public static DateTimeOffset? ComputeEndTimeToAllowParticularNumberOfFirings(IOperableTrigger trigger, ICalendar calendar, int numberOfTimes)
	{
		IOperableTrigger t = (IOperableTrigger)trigger.Clone();
		if (!t.GetNextFireTimeUtc().HasValue)
		{
			t.ComputeFirstFireTimeUtc(calendar);
		}
		int c = 0;
		DateTimeOffset? endTime = null;
		for (int i = 0; i < numberOfTimes; i++)
		{
			DateTimeOffset? d = t.GetNextFireTimeUtc();
			if (!d.HasValue)
			{
				break;
			}
			c++;
			t.Triggered(calendar);
			if (c == numberOfTimes)
			{
				endTime = d;
			}
		}
		if (!endTime.HasValue)
		{
			return null;
		}
		endTime = endTime.Value.AddSeconds(1.0);
		return endTime;
	}

	/// <summary>
	/// Returns a list of Dates that are the next fire times of a  <see cref="T:Quartz.ITrigger" />
	/// that fall within the given date range. The input trigger will be cloned
	/// before any work is done, so you need not worry about its state being
	/// altered by this method.
	/// <para>
	/// NOTE: if this is a trigger that has previously fired within the given
	/// date range, then firings which have already occurred will not be listed
	/// in the output List.
	/// </para>
	/// </summary>
	/// <param name="trigg">The trigger upon which to do the work</param>
	/// <param name="cal">The calendar to apply to the trigger's schedule</param>
	/// <param name="from">The starting date at which to find fire times</param>
	/// <param name="to">The ending date at which to stop finding fire times</param>
	/// <returns>List of java.util.Date objects</returns>
	public static IList<DateTimeOffset> ComputeFireTimesBetween(IOperableTrigger trigg, ICalendar cal, DateTimeOffset from, DateTimeOffset to)
	{
		List<DateTimeOffset> lst = new List<DateTimeOffset>();
		IOperableTrigger t = (IOperableTrigger)trigg.Clone();
		if (!t.GetNextFireTimeUtc().HasValue || !t.GetNextFireTimeUtc().HasValue)
		{
			t.StartTimeUtc = from;
			t.EndTimeUtc = to;
			t.ComputeFirstFireTimeUtc(cal);
		}
		while (true)
		{
			DateTimeOffset? d = t.GetNextFireTimeUtc();
			if (!d.HasValue)
			{
				break;
			}
			if (d.Value < from)
			{
				t.Triggered(cal);
				continue;
			}
			if (d.Value > to)
			{
				break;
			}
			lst.Add(d.Value);
			t.Triggered(cal);
		}
		return lst.AsReadOnly();
	}
}
