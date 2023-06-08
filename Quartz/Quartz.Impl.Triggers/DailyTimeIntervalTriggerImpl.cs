using System;
using Quartz.Collection;
using Quartz.Util;

namespace Quartz.Impl.Triggers;

/// <summary>
/// A concrete implementation of DailyTimeIntervalTrigger that is used to fire a <see cref="T:Quartz.IJobDetail" />
/// based upon daily repeating time intervals.
/// </summary>
/// <remarks>
/// <para>
/// The trigger will fire every N (<see cref="P:Quartz.IDailyTimeIntervalTrigger.RepeatInterval" /> ) seconds, minutes or hours
/// (see <see cref="P:Quartz.IDailyTimeIntervalTrigger.RepeatInterval" />) during a given time window on specified days of the week.
/// </para>
/// <para>
/// For example#1, a trigger can be set to fire every 72 minutes between 8:00 and 11:00 everyday. It's fire times would
/// be 8:00, 9:12, 10:24, then next day would repeat: 8:00, 9:12, 10:24 again.
/// </para>
/// <para>
/// For example#2, a trigger can be set to fire every 23 minutes between 9:20 and 16:47 Monday through Friday.
/// </para>
/// <para>
/// On each day, the starting fire time is reset to startTimeOfDay value, and then it will add repeatInterval value to it until
/// the endTimeOfDay is reached. If you set daysOfWeek values, then fire time will only occur during those week days period. Again,
/// remember this trigger will reset fire time each day with startTimeOfDay, regardless of your interval or endTimeOfDay!
/// </para>
/// <para>
/// The default values for fields if not set are: startTimeOfDay defaults to 00:00:00, the endTimeOfDay default to 23:59:59,
/// and daysOfWeek is default to every day. The startTime default to current time-stamp now, while endTime has not value.
/// </para>
/// <para>
/// If startTime is before startTimeOfDay, then startTimeOfDay will be used and startTime has no affect. Else if startTime is 
/// after startTimeOfDay, then the first fire time for that day will be the next interval after the startTime. For example, if
/// you set startingTimeOfDay=9am, endingTimeOfDay=11am, interval=15 mins, and startTime=9:33am, then the next fire time will
/// be 9:45pm. Note also that if you do not set startTime value, the trigger builder will default to current time, and current time 
/// maybe before or after the startTimeOfDay! So be aware how you set your startTime.
/// </para>
/// <para>
/// This trigger also supports "repeatCount" feature to end the trigger fire time after
/// a certain number of count is reached. Just as the SimpleTrigger, setting repeatCount=0 
/// means trigger will fire once only! Setting any positive count then the trigger will repeat 
/// count + 1 times. Unlike SimpleTrigger, the default value of repeatCount of this trigger
/// is set to REPEAT_INDEFINITELY instead of 0 though.
/// </para>
/// </remarks>
/// <see cref="T:Quartz.IDailyTimeIntervalTrigger" />
/// <see cref="T:Quartz.DailyTimeIntervalScheduleBuilder" />
/// <since>2.0</since>
/// <author>James House</author>
/// <author>Zemian Deng saltnlight5@gmail.com</author>
/// <author>Nuno Maia (.NET)</author>
[Serializable]
public class DailyTimeIntervalTriggerImpl : AbstractTrigger, IDailyTimeIntervalTrigger, ITrigger, ICloneable, IComparable<ITrigger>
{
	/// <summary>
	/// Used to indicate the 'repeat count' of the trigger is indefinite. Or in
	/// other words, the trigger should repeat continually until the trigger's
	/// ending timestamp.
	/// </summary>
	public const int RepeatIndefinitely = -1;

	private static readonly int YearToGiveupSchedulingAt = DateTime.Now.Year + 100;

	private DateTimeOffset startTimeUtc;

	private DateTimeOffset? endTimeUtc;

	private DateTimeOffset? nextFireTimeUtc;

	private DateTimeOffset? previousFireTimeUtc;

	private int repeatInterval = 1;

	private IntervalUnit repeatIntervalUnit = IntervalUnit.Minute;

	private ISet<DayOfWeek> daysOfWeek;

	private TimeOfDay startTimeOfDay;

	private TimeOfDay endTimeOfDay;

	private int timesTriggered;

	private bool complete;

	private int repeatCount = -1;

	private TimeZoneInfo timeZone;

	/// <summary>
	/// The time at which the <see cref="T:Quartz.IDailyTimeIntervalTrigger" /> should occur.
	/// </summary>
	public override DateTimeOffset StartTimeUtc
	{
		get
		{
			if (startTimeUtc == DateTimeOffset.MinValue)
			{
				startTimeUtc = SystemTime.UtcNow();
			}
			return startTimeUtc;
		}
		set
		{
			if (value == DateTimeOffset.MinValue)
			{
				throw new ArgumentException("Start time cannot be DateTimeOffset.MinValue");
			}
			DateTimeOffset? eTime = EndTimeUtc;
			if (eTime.HasValue && eTime < value)
			{
				throw new ArgumentException("End time cannot be before start time");
			}
			startTimeUtc = value;
		}
	}

	/// <summary>
	/// the time at which the <see cref="T:Quartz.IDailyTimeIntervalTrigger" /> should quit repeating.
	/// </summary>
	/// <see cref="P:Quartz.Impl.Triggers.DailyTimeIntervalTriggerImpl.FinalFireTimeUtc" />
	public override DateTimeOffset? EndTimeUtc
	{
		get
		{
			return endTimeUtc;
		}
		set
		{
			DateTimeOffset sTime = StartTimeUtc;
			if (value.HasValue)
			{
				DateTimeOffset value2 = sTime;
				DateTimeOffset? dateTimeOffset = value;
				if (value2 > dateTimeOffset)
				{
					throw new ArgumentException("End time cannot be before start time");
				}
			}
			endTimeUtc = value;
		}
	}

	/// <summary>
	/// Get the the number of times for interval this trigger should repeat, 
	/// after which it will be automatically deleted.
	/// </summary>
	public int RepeatCount
	{
		get
		{
			return repeatCount;
		}
		set
		{
			if (value < 0 && value != -1)
			{
				throw new ArgumentException("Repeat count must be >= 0, use the constant RepeatIndefinitely for infinite.");
			}
			repeatCount = value;
		}
	}

	/// <summary>
	/// the interval unit - the time unit on with the interval applies.
	/// </summary>
	/// <remarks>
	/// The repeat interval unit. The only intervals that are valid for this type of trigger are
	/// <see cref="F:Quartz.IntervalUnit.Second" />, <see cref="F:Quartz.IntervalUnit.Minute" />, and <see cref="F:Quartz.IntervalUnit.Hour" />.
	/// </remarks>
	public IntervalUnit RepeatIntervalUnit
	{
		get
		{
			return repeatIntervalUnit;
		}
		set
		{
			if (value != IntervalUnit.Second && value != IntervalUnit.Minute && value != IntervalUnit.Hour)
			{
				throw new ArgumentException("Invalid repeat IntervalUnit (must be Second, Minute or Hour");
			}
			repeatIntervalUnit = value;
		}
	}

	/// <summary>
	/// the the time interval that will be added to the <see cref="T:Quartz.IDailyTimeIntervalTrigger" />'s
	/// fire time (in the set repeat interval unit) in order to calculate the time of the
	/// next trigger repeat.
	/// </summary>
	public int RepeatInterval
	{
		get
		{
			return repeatInterval;
		}
		set
		{
			if (value < 0)
			{
				throw new ArgumentException("Repeat interval must be >= 1");
			}
			repeatInterval = value;
		}
	}

	/// <summary>
	/// the number of times the <see cref="T:Quartz.IDailyTimeIntervalTrigger" /> has already
	/// fired.
	/// </summary>
	public int TimesTriggered
	{
		get
		{
			return timesTriggered;
		}
		set
		{
			timesTriggered = value;
		}
	}

	public TimeZoneInfo TimeZone
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
	/// Returns the final time at which the <see cref="T:Quartz.IDailyTimeIntervalTrigger" /> will
	/// fire, if there is no end time set, null will be returned.
	/// </summary>
	/// <remarks>Note that the return time may be in the past.</remarks>
	/// <returns></returns>
	public override DateTimeOffset? FinalFireTimeUtc
	{
		get
		{
			if (complete || !EndTimeUtc.HasValue)
			{
				return null;
			}
			DateTimeOffset? endTime = EndTimeUtc;
			if (endTimeOfDay != null)
			{
				DateTimeOffset? endTimeOfDayDate = endTimeOfDay.GetTimeOfDayForDate(endTime);
				if (endTime < endTimeOfDayDate)
				{
					endTime = endTimeOfDayDate;
				}
			}
			return endTime;
		}
	}

	/// <summary>
	/// The days of the week upon which to fire.
	/// </summary>
	/// <returns>
	/// A Set containing the integers representing the days of the week, per the values 0-6 as defined by
	/// DayOfWees.Sunday - DayOfWeek.Saturday. 
	/// </returns>
	public ISet<DayOfWeek> DaysOfWeek
	{
		get
		{
			if (daysOfWeek == null)
			{
				daysOfWeek = new HashSet<DayOfWeek>(DailyTimeIntervalScheduleBuilder.AllDaysOfTheWeek);
			}
			return daysOfWeek;
		}
		set
		{
			if (value == null || value.Count == 0)
			{
				throw new ArgumentException("DaysOfWeek set must be a set that contains at least one day.");
			}
			if (value.Count == 0)
			{
				throw new ArgumentException("DaysOfWeek set must contain at least one day.");
			}
			daysOfWeek = value;
		}
	}

	/// <summary>
	/// The time of day to start firing at the given interval.
	/// </summary>
	public TimeOfDay StartTimeOfDay
	{
		get
		{
			if (startTimeOfDay == null)
			{
				startTimeOfDay = new TimeOfDay(0, 0, 0);
			}
			return startTimeOfDay;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentException("Start time of day cannot be null");
			}
			TimeOfDay eTime = EndTimeOfDay;
			if (eTime != null && value != null && eTime.Before(value))
			{
				throw new ArgumentException("End time of day cannot be before start time of day");
			}
			startTimeOfDay = value;
		}
	}

	/// <summary>
	/// The time of day to complete firing at the given interval.
	/// </summary>
	public TimeOfDay EndTimeOfDay
	{
		get
		{
			return endTimeOfDay;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentException("End time of day cannot be null");
			}
			TimeOfDay sTime = StartTimeOfDay;
			if (sTime != null && endTimeOfDay != null && endTimeOfDay.Before(value))
			{
				throw new ArgumentException("End time of day cannot be before start time of day");
			}
			endTimeOfDay = value;
		}
	}

	/// <summary>
	/// This trigger has no additional properties besides what's defined in this class.
	/// </summary>
	/// <returns></returns>
	public override bool HasAdditionalProperties => false;

	/// <summary>
	/// Tells whether this Trigger instance can handle events
	/// in millisecond precision.
	/// </summary>
	public override bool HasMillisecondPrecision => true;

	/// <summary>
	/// Create a  <see cref="T:Quartz.IDailyTimeIntervalTrigger" /> with no settings.
	/// </summary>
	public DailyTimeIntervalTriggerImpl()
	{
	}

	/// <summary>
	/// Create a <see cref="T:Quartz.IDailyTimeIntervalTrigger" /> that will occur immediately, and
	/// repeat at the the given interval.
	/// </summary>
	/// <param name="name"></param>
	/// <param name="startTimeOfDayUtc">The <see cref="T:Quartz.TimeOfDay" /> that the repeating should begin occurring.</param>
	/// <param name="endTimeOfDayUtc">The <see cref="T:Quartz.TimeOfDay" /> that the repeating should stop occurring.</param>
	/// <param name="intervalUnit">The repeat interval unit. The only intervals that are valid for this type of trigger are
	/// <see cref="F:Quartz.IntervalUnit.Second" />, <see cref="F:Quartz.IntervalUnit.Minute" />, and <see cref="F:Quartz.IntervalUnit.Hour" />.</param>
	/// <param name="repeatInterval"></param>
	public DailyTimeIntervalTriggerImpl(string name, TimeOfDay startTimeOfDayUtc, TimeOfDay endTimeOfDayUtc, IntervalUnit intervalUnit, int repeatInterval)
		: this(name, null, startTimeOfDayUtc, endTimeOfDayUtc, intervalUnit, repeatInterval)
	{
	}

	/// <summary>
	/// Create a <see cref="T:Quartz.IDailyTimeIntervalTrigger" /> that will occur immediately, and
	/// repeat at the the given interval.
	/// </summary>
	/// <param name="name"></param>
	/// <param name="group"></param>
	/// <param name="startTimeOfDayUtc">The <see cref="T:Quartz.TimeOfDay" /> that the repeating should begin occurring.</param>
	/// <param name="endTimeOfDayUtc">The <see cref="T:Quartz.TimeOfDay" /> that the repeating should stop occurring.</param>
	/// <param name="intervalUnit">The repeat interval unit. The only intervals that are valid for this type of trigger are
	/// <see cref="F:Quartz.IntervalUnit.Second" />, <see cref="F:Quartz.IntervalUnit.Minute" />, and <see cref="F:Quartz.IntervalUnit.Hour" />.</param>
	/// <param name="repeatInterval"></param>
	public DailyTimeIntervalTriggerImpl(string name, string group, TimeOfDay startTimeOfDayUtc, TimeOfDay endTimeOfDayUtc, IntervalUnit intervalUnit, int repeatInterval)
		: this(name, group, SystemTime.UtcNow(), null, startTimeOfDayUtc, endTimeOfDayUtc, intervalUnit, repeatInterval)
	{
	}

	/// <summary>
	/// Create a <see cref="T:Quartz.IDailyTimeIntervalTrigger" /> that will occur at the given time,
	/// and repeat at the the given interval until the given end time.
	/// </summary>
	/// <param name="name"></param>
	/// <param name="startTimeUtc">A <see cref="T:System.DateTimeOffset" /> set to the time for the <see cref="T:Quartz.ITrigger" />to fire.</param>
	/// <param name="endTimeUtc">A <see cref="T:System.DateTimeOffset" /> set to the time for the <see cref="T:Quartz.ITrigger" />to quit repeat firing.</param>
	/// <param name="startTimeOfDayUtc">The <see cref="T:Quartz.TimeOfDay" /> that the repeating should begin occurring.</param>
	/// <param name="endTimeOfDayUtc">The <see cref="T:Quartz.TimeOfDay" /> that the repeating should stop occurring.</param>
	/// <param name="intervalUnit">The repeat interval unit. The only intervals that are valid for this type of trigger are
	/// <see cref="F:Quartz.IntervalUnit.Second" />, <see cref="F:Quartz.IntervalUnit.Minute" />, and <see cref="F:Quartz.IntervalUnit.Hour" />.</param>
	/// <param name="repeatInterval">The number of milliseconds to pause between the repeat firing.</param>
	public DailyTimeIntervalTriggerImpl(string name, DateTimeOffset startTimeUtc, DateTimeOffset? endTimeUtc, TimeOfDay startTimeOfDayUtc, TimeOfDay endTimeOfDayUtc, IntervalUnit intervalUnit, int repeatInterval)
		: this(name, null, startTimeUtc, endTimeUtc, startTimeOfDayUtc, endTimeOfDayUtc, intervalUnit, repeatInterval)
	{
	}

	/// <summary>
	/// Create a <see cref="T:Quartz.IDailyTimeIntervalTrigger" /> that will occur at the given time,
	/// and repeat at the the given interval until the given end time.
	/// </summary>
	/// <param name="name"></param>
	/// <param name="group"></param>
	/// <param name="startTimeUtc">A <see cref="T:System.DateTimeOffset" /> set to the time for the <see cref="T:Quartz.ITrigger" />to fire.</param>
	/// <param name="endTimeUtc">A <see cref="T:System.DateTimeOffset" /> set to the time for the <see cref="T:Quartz.ITrigger" />to quit repeat firing.</param>
	/// <param name="startTimeOfDayUtc">The <see cref="T:Quartz.TimeOfDay" /> that the repeating should begin occurring.</param>
	/// <param name="endTimeOfDayUtc">The <see cref="T:Quartz.TimeOfDay" /> that the repeating should stop occurring.</param>
	/// <param name="intervalUnit">The repeat interval unit. The only intervals that are valid for this type of trigger are
	/// <see cref="F:Quartz.IntervalUnit.Second" />, <see cref="F:Quartz.IntervalUnit.Minute" />, and <see cref="F:Quartz.IntervalUnit.Hour" />.</param>
	/// <param name="repeatInterval">The number of milliseconds to pause between the repeat firing.</param>
	public DailyTimeIntervalTriggerImpl(string name, string group, DateTimeOffset startTimeUtc, DateTimeOffset? endTimeUtc, TimeOfDay startTimeOfDayUtc, TimeOfDay endTimeOfDayUtc, IntervalUnit intervalUnit, int repeatInterval)
		: base(name, group)
	{
		StartTimeUtc = startTimeUtc;
		EndTimeUtc = endTimeUtc;
		RepeatIntervalUnit = intervalUnit;
		RepeatInterval = repeatInterval;
		StartTimeOfDay = startTimeOfDayUtc;
		EndTimeOfDay = endTimeOfDayUtc;
	}

	/// <summary>
	/// Create a <see cref="T:Quartz.IDailyTimeIntervalTrigger" /> that will occur at the given time,
	/// fire the identified job and repeat at the the given
	/// interval until the given end time.
	/// </summary>
	/// <param name="name"></param>
	/// <param name="group"></param>
	/// <param name="jobName"></param>
	/// <param name="jobGroup"></param>
	/// <param name="startTimeUtc">A <see cref="T:System.DateTimeOffset" /> set to the time for the <see cref="T:Quartz.ITrigger" />to fire.</param>
	/// <param name="endTimeUtc">A <see cref="T:System.DateTimeOffset" /> set to the time for the <see cref="T:Quartz.ITrigger" />to quit repeat firing.</param>
	/// <param name="startTimeOfDayUtc">The <see cref="T:Quartz.TimeOfDay" /> that the repeating should begin occurring.</param>
	/// <param name="endTimeOfDayUtc">The <see cref="T:Quartz.TimeOfDay" /> that the repeating should stop occurring.</param>
	/// <param name="intervalUnit">The repeat interval unit. The only intervals that are valid for this type of trigger are
	/// <see cref="F:Quartz.IntervalUnit.Second" />, <see cref="F:Quartz.IntervalUnit.Minute" />, and <see cref="F:Quartz.IntervalUnit.Hour" />.</param>
	/// <param name="repeatInterval">The number of milliseconds to pause between the repeat firing.</param>
	public DailyTimeIntervalTriggerImpl(string name, string group, string jobName, string jobGroup, DateTimeOffset startTimeUtc, DateTimeOffset endTimeUtc, TimeOfDay startTimeOfDayUtc, TimeOfDay endTimeOfDayUtc, IntervalUnit intervalUnit, int repeatInterval)
		: base(name, group, jobName, jobGroup)
	{
		StartTimeUtc = startTimeUtc;
		EndTimeUtc = endTimeUtc;
		RepeatIntervalUnit = intervalUnit;
		RepeatInterval = repeatInterval;
		StartTimeOfDay = startTimeOfDayUtc;
		EndTimeOfDay = endTimeOfDayUtc;
	}

	protected override bool ValidateMisfireInstruction(int misfireInstruction)
	{
		if (misfireInstruction < -1)
		{
			return false;
		}
		if (misfireInstruction > 2)
		{
			return false;
		}
		return true;
	}

	/// <summary> 
	/// Updates the <see cref="T:Quartz.ICalendarIntervalTrigger" />'s state based on the
	/// MisfireInstruction.XXX that was selected when the <see cref="T:Quartz.IDailyTimeIntervalTrigger" />
	/// was created.
	/// </summary>
	/// <remarks>
	/// If the misfire instruction is set to <see cref="F:Quartz.MisfireInstruction.SmartPolicy" />,
	/// then the following scheme will be used:
	/// <ul>
	///     <li>The instruction will be interpreted as <see cref="F:Quartz.MisfireInstruction.DailyTimeIntervalTrigger.FireOnceNow" /></li>
	/// </ul>
	/// </remarks>
	public override void UpdateAfterMisfire(ICalendar cal)
	{
		int instr = MisfireInstruction;
		switch (instr)
		{
		case -1:
			return;
		case 0:
			instr = 1;
			break;
		}
		switch (instr)
		{
		case 2:
		{
			DateTimeOffset? newFireTime = GetFireTimeAfter(SystemTime.UtcNow());
			while (newFireTime.HasValue && cal != null && !cal.IsTimeIncluded(newFireTime.Value))
			{
				newFireTime = GetFireTimeAfter(newFireTime);
			}
			SetNextFireTimeUtc(newFireTime);
			break;
		}
		case 1:
			SetNextFireTimeUtc(SystemTime.UtcNow());
			break;
		}
	}

	/// <summary>
	/// Called when the scheduler has decided to 'fire'
	/// the trigger (execute the associated job), in order to
	/// give the trigger a chance to update itself for its next
	/// triggering (if any).
	/// </summary>
	/// <param name="calendar"></param>
	/// <see cref="M:Quartz.Impl.Triggers.AbstractTrigger.ExecutionComplete(Quartz.IJobExecutionContext,Quartz.JobExecutionException)" />
	public override void Triggered(ICalendar calendar)
	{
		timesTriggered++;
		previousFireTimeUtc = nextFireTimeUtc;
		nextFireTimeUtc = GetFireTimeAfter(nextFireTimeUtc);
		while (nextFireTimeUtc.HasValue && calendar != null && !calendar.IsTimeIncluded(nextFireTimeUtc.Value))
		{
			nextFireTimeUtc = GetFireTimeAfter(nextFireTimeUtc);
			if (!nextFireTimeUtc.HasValue)
			{
				break;
			}
			if (nextFireTimeUtc.Value.Year > YearToGiveupSchedulingAt)
			{
				nextFireTimeUtc = null;
			}
		}
		if (!nextFireTimeUtc.HasValue)
		{
			complete = true;
		}
	}

	/// <summary>
	///
	/// </summary>
	/// <param name="calendar"></param>
	/// <param name="misfireThreshold"></param>
	/// <see cref="M:Quartz.Impl.Triggers.AbstractTrigger.UpdateWithNewCalendar(Quartz.ICalendar,System.TimeSpan)" />
	public override void UpdateWithNewCalendar(ICalendar calendar, TimeSpan misfireThreshold)
	{
		nextFireTimeUtc = GetFireTimeAfter(previousFireTimeUtc);
		if (!nextFireTimeUtc.HasValue || calendar == null)
		{
			return;
		}
		DateTimeOffset now = SystemTime.UtcNow();
		while (nextFireTimeUtc.HasValue && !calendar.IsTimeIncluded(nextFireTimeUtc.Value))
		{
			nextFireTimeUtc = GetFireTimeAfter(nextFireTimeUtc);
			if (!nextFireTimeUtc.HasValue)
			{
				break;
			}
			if (nextFireTimeUtc.Value.Year > YearToGiveupSchedulingAt)
			{
				nextFireTimeUtc = null;
			}
			if (nextFireTimeUtc.HasValue && nextFireTimeUtc < now)
			{
				TimeSpan diff = now - nextFireTimeUtc.Value;
				if (diff >= misfireThreshold)
				{
					nextFireTimeUtc = GetFireTimeAfter(nextFireTimeUtc);
				}
			}
		}
	}

	/// <summary>
	/// This method should not be used by the Quartz client.
	/// </summary>
	/// <remarks>
	/// <para>
	/// Called by the scheduler at the time a <see cref="T:Quartz.ITrigger" /> is first
	/// added to the scheduler, in order to have the <see cref="T:Quartz.ITrigger" />
	/// compute its first fire time, based on any associated calendar.
	/// </para>
	///
	/// <para>
	/// After this method has been called, <see cref="M:Quartz.ITrigger.GetNextFireTimeUtc" />
	/// should return a valid answer.
	/// </para>
	/// </remarks>
	/// <returns> 
	/// The first time at which the <see cref="T:Quartz.ITrigger" /> will be fired
	/// by the scheduler, which is also the same value <see cref="M:Quartz.ITrigger.GetNextFireTimeUtc" />
	/// will return (until after the first firing of the <see cref="T:Quartz.ITrigger" />).
	/// </returns>        
	public override DateTimeOffset? ComputeFirstFireTimeUtc(ICalendar calendar)
	{
		DateTimeOffset startTime = TimeZoneUtil.ConvertTime(StartTimeUtc, TimeZone);
		DateTimeOffset? startTimeOfDayDate = StartTimeOfDay.GetTimeOfDayForDate(startTime);
		DateTimeOffset value = startTime;
		DateTimeOffset? dateTimeOffset = startTimeOfDayDate;
		if (value > dateTimeOffset)
		{
			nextFireTimeUtc = GetFireTimeAfter(startTime);
		}
		else
		{
			nextFireTimeUtc = AdvanceToNextDayOfWeek(startTimeOfDayDate.Value, forceToAdvanceNextDay: false);
		}
		while (nextFireTimeUtc.HasValue && calendar != null && !calendar.IsTimeIncluded(nextFireTimeUtc.Value))
		{
			nextFireTimeUtc = GetFireTimeAfter(nextFireTimeUtc);
			if (!nextFireTimeUtc.HasValue)
			{
				break;
			}
			if (nextFireTimeUtc.Value.Year > YearToGiveupSchedulingAt)
			{
				return null;
			}
		}
		return nextFireTimeUtc;
	}

	private DateTimeOffset CreateCalendarTime(DateTimeOffset dateTime)
	{
		return TimeZoneUtil.ConvertTime(dateTime, TimeZone);
	}

	/// <summary>
	/// Returns the next time at which the <see cref="T:Quartz.ITrigger" /> is scheduled to fire. If
	/// the trigger will not fire again, <see langword="null" /> will be returned.  Note that
	/// the time returned can possibly be in the past, if the time that was computed
	/// for the trigger to next fire has already arrived, but the scheduler has not yet
	/// been able to fire the trigger (which would likely be due to lack of resources
	/// e.g. threads).
	/// </summary>
	///             <remarks>
	/// The value returned is not guaranteed to be valid until after the <see cref="T:Quartz.ITrigger" />
	/// has been added to the scheduler.
	/// </remarks>
	/// <returns></returns>
	public override DateTimeOffset? GetNextFireTimeUtc()
	{
		return nextFireTimeUtc;
	}

	/// <summary>
	/// Returns the previous time at which the <see cref="T:Quartz.ICalendarIntervalTrigger" /> fired.
	/// If the trigger has not yet fired, <see langword="null" /> will be returned.
	/// </summary>
	public override DateTimeOffset? GetPreviousFireTimeUtc()
	{
		return previousFireTimeUtc;
	}

	/// <summary>
	/// Set the next time at which the <see cref="T:Quartz.IDailyTimeIntervalTrigger" /> should fire.
	/// </summary>
	/// <remarks>
	/// This method should not be invoked by client code.
	/// </remarks>
	/// <param name="value"></param>
	public override void SetNextFireTimeUtc(DateTimeOffset? value)
	{
		nextFireTimeUtc = value;
	}

	/// <summary>
	/// Set the previous time at which the <see cref="T:Quartz.IDailyTimeIntervalTrigger" /> fired.
	/// </summary>
	/// <remarks>
	/// This method should not be invoked by client code.
	/// </remarks>
	/// <param name="previousFireTimeUtc"></param>
	public override void SetPreviousFireTimeUtc(DateTimeOffset? previousFireTimeUtc)
	{
		this.previousFireTimeUtc = previousFireTimeUtc;
	}

	/// <summary>
	/// Returns the next time at which the <see cref="T:Quartz.IDailyTimeIntervalTrigger" /> will
	/// fire, after the given time. If the trigger will not fire after the given
	/// time, <see langword="null" /> will be returned.
	/// </summary>
	/// <param name="afterTime"></param>
	/// <returns></returns>
	public override DateTimeOffset? GetFireTimeAfter(DateTimeOffset? afterTime)
	{
		if (complete)
		{
			return null;
		}
		if (repeatCount != -1 && timesTriggered > repeatCount)
		{
			return null;
		}
		afterTime = (afterTime.HasValue ? new DateTimeOffset?(afterTime.Value.AddSeconds(1.0)) : new DateTimeOffset?(SystemTime.UtcNow().AddSeconds(1.0)));
		afterTime = TimeZoneUtil.ConvertTime(afterTime.Value, TimeZone);
		bool afterTimePassEndTimeOfDay = false;
		if (endTimeOfDay != null)
		{
			afterTimePassEndTimeOfDay = afterTime.Value > endTimeOfDay.GetTimeOfDayForDate(afterTime).Value;
		}
		DateTimeOffset? fireTime = AdvanceToNextDayOfWeek(afterTime.Value, afterTimePassEndTimeOfDay);
		if (!fireTime.HasValue)
		{
			return null;
		}
		fireTime = new DateTimeOffset(fireTime.Value.DateTime, TimeZone.GetUtcOffset(fireTime.Value));
		DateTimeOffset fireTimeEndDate = ((endTimeOfDay != null) ? endTimeOfDay.GetTimeOfDayForDate(fireTime).Value : new TimeOfDay(23, 59, 59).GetTimeOfDayForDate(fireTime).Value);
		fireTimeEndDate = new DateTimeOffset(fireTimeEndDate.DateTime, TimeZone.GetUtcOffset(fireTimeEndDate.DateTime));
		DateTimeOffset fireTimeStartDate = startTimeOfDay.GetTimeOfDayForDate(fireTime).Value;
		fireTimeStartDate = new DateTimeOffset(fireTimeStartDate.DateTime, TimeZone.GetUtcOffset(fireTimeStartDate.DateTime));
		DateTimeOffset? dateTimeOffset = fireTime;
		DateTimeOffset dateTimeOffset2 = startTimeUtc;
		if (dateTimeOffset.HasValue && dateTimeOffset.GetValueOrDefault() < dateTimeOffset2 && startTimeUtc < fireTimeStartDate)
		{
			return fireTimeStartDate;
		}
		DateTimeOffset? dateTimeOffset3 = fireTime;
		DateTimeOffset dateTimeOffset4 = startTimeUtc;
		if (dateTimeOffset3.HasValue && dateTimeOffset3.GetValueOrDefault() < dateTimeOffset4 && startTimeUtc > fireTimeStartDate)
		{
			return startTimeUtc;
		}
		DateTimeOffset? dateTimeOffset5 = fireTime;
		DateTimeOffset dateTimeOffset6 = startTimeUtc;
		if (dateTimeOffset5.HasValue && dateTimeOffset5.GetValueOrDefault() > dateTimeOffset6 && fireTime < fireTimeStartDate)
		{
			return fireTimeStartDate;
		}
		startTimeUtc = fireTimeStartDate.ToUniversalTime();
		startTimeUtc = TimeZoneUtil.ConvertTime(startTimeUtc, TimeZone);
		long secondsAfterStart = (long)(fireTime.Value - startTimeUtc).TotalSeconds;
		long repeatLong = RepeatInterval;
		DateTimeOffset sTime = startTimeUtc;
		switch (RepeatIntervalUnit)
		{
		case IntervalUnit.Second:
		{
			long jumpCount3 = secondsAfterStart / repeatLong;
			if (secondsAfterStart % repeatLong != 0)
			{
				jumpCount3++;
			}
			sTime = sTime.AddSeconds(RepeatInterval * (int)jumpCount3);
			fireTime = sTime;
			break;
		}
		case IntervalUnit.Minute:
		{
			long jumpCount2 = secondsAfterStart / (repeatLong * 60);
			if (secondsAfterStart % (repeatLong * 60) != 0)
			{
				jumpCount2++;
			}
			sTime = sTime.AddMinutes(RepeatInterval * (int)jumpCount2);
			fireTime = sTime;
			break;
		}
		case IntervalUnit.Hour:
		{
			long jumpCount = secondsAfterStart / (repeatLong * 60 * 60);
			if (secondsAfterStart % (repeatLong * 60 * 60) != 0)
			{
				jumpCount++;
			}
			sTime = sTime.AddHours(RepeatInterval * (int)jumpCount);
			fireTime = sTime;
			break;
		}
		}
		if (fireTime > fireTimeEndDate)
		{
			DateTimeOffset fireTimeEndOfDay = new TimeOfDay(23, 59, 59).GetTimeOfDayForDate(fireTimeEndDate).Value;
			fireTime = ((!(fireTime > fireTimeEndOfDay)) ? AdvanceToNextDayOfWeek(fireTime.Value, forceToAdvanceNextDay: true) : AdvanceToNextDayOfWeek(fireTime.Value, forceToAdvanceNextDay: false));
			if (!fireTime.HasValue)
			{
				return null;
			}
			DateTimeOffset nextDayfireTimeStartDate = StartTimeOfDay.GetTimeOfDayForDate(fireTime).Value;
			if (fireTime < nextDayfireTimeStartDate)
			{
				fireTime = nextDayfireTimeStartDate;
			}
		}
		return fireTime.Value.ToUniversalTime();
	}

	/// <summary>
	/// Given fireTime time, we need to advance/calculate and return a time of next available week day.
	/// </summary>
	/// <param name="fireTime">given next fireTime.</param>
	/// <param name="forceToAdvanceNextDay">flag to whether to advance day without check existing week day. This scenario
	/// can happen when a caller determine fireTime has passed the endTimeOfDay that fireTime should move to next day anyway.
	/// </param>
	/// <returns>a next day fireTime.</returns>
	private DateTimeOffset? AdvanceToNextDayOfWeek(DateTimeOffset fireTime, bool forceToAdvanceNextDay)
	{
		TimeOfDay startTimeOfDay = StartTimeOfDay;
		DateTimeOffset fireTimeStartDate = startTimeOfDay.GetTimeOfDayForDate(fireTime).Value;
		DateTimeOffset fireTimeStartDateCal = CreateCalendarTime(fireTimeStartDate);
		DayOfWeek dayOfWeekOfFireTime = fireTimeStartDateCal.DayOfWeek;
		ISet<DayOfWeek> daysOfWeek = DaysOfWeek;
		if (forceToAdvanceNextDay || !daysOfWeek.Contains(dayOfWeekOfFireTime))
		{
			for (int i = 1; i <= 7; i++)
			{
				fireTimeStartDateCal = fireTimeStartDateCal.AddDays(1.0);
				dayOfWeekOfFireTime = fireTimeStartDateCal.DayOfWeek;
				if (daysOfWeek.Contains(dayOfWeekOfFireTime))
				{
					fireTime = fireTimeStartDateCal;
					break;
				}
			}
		}
		DateTimeOffset? endTime = EndTimeUtc;
		if (endTime.HasValue && fireTime > endTime.Value)
		{
			return null;
		}
		return fireTime;
	}

	/// <summary>
	/// Determines whether or not the <see cref="T:Quartz.IDailyTimeIntervalTrigger" /> will occur
	/// again.
	/// </summary>
	/// <returns></returns>
	public override bool GetMayFireAgain()
	{
		return GetNextFireTimeUtc().HasValue;
	}

	/// <summary>
	/// Validates whether the properties of the <see cref="T:Quartz.IJobDetail" /> are
	/// valid for submission into a <see cref="T:Quartz.IScheduler" />.
	/// </summary>
	public override void Validate()
	{
		base.Validate();
		if (repeatIntervalUnit != IntervalUnit.Second && repeatIntervalUnit != IntervalUnit.Minute && repeatIntervalUnit != IntervalUnit.Hour)
		{
			throw new SchedulerException("Invalid repeat IntervalUnit (must be Second, Minute or Hour).");
		}
		if (repeatInterval < 1)
		{
			throw new SchedulerException("Repeat Interval cannot be zero.");
		}
		if (repeatIntervalUnit == IntervalUnit.Second && (long)repeatInterval > 86400L)
		{
			throw new SchedulerException("repeatInterval can not exceed 24 hours (" + 86400L + " seconds). Given " + repeatInterval);
		}
		if (repeatIntervalUnit == IntervalUnit.Minute && (long)repeatInterval > 1440L)
		{
			throw new SchedulerException("repeatInterval can not exceed 24 hours (" + 1440L + " minutes). Given " + repeatInterval);
		}
		if (repeatIntervalUnit == IntervalUnit.Hour && repeatInterval > 24)
		{
			throw new SchedulerException("repeatInterval can not exceed 24 hours. Given " + repeatInterval + " hours.");
		}
		if (EndTimeOfDay != null && !StartTimeOfDay.Before(EndTimeOfDay))
		{
			throw new SchedulerException(string.Concat("StartTimeOfDay ", startTimeOfDay, " should not come after endTimeOfDay ", endTimeOfDay));
		}
	}

	/// <summary>
	/// Get a <see cref="T:Quartz.IScheduleBuilder" /> that is configured to produce a 
	/// schedule identical to this trigger's schedule.
	/// </summary>
	/// <returns></returns>
	/// <see cref="T:Quartz.TriggerBuilder" />
	public override IScheduleBuilder GetScheduleBuilder()
	{
		DailyTimeIntervalScheduleBuilder cb = DailyTimeIntervalScheduleBuilder.Create().WithInterval(RepeatInterval, RepeatIntervalUnit).OnDaysOfTheWeek(DaysOfWeek)
			.StartingDailyAt(StartTimeOfDay)
			.EndingDailyAt(EndTimeOfDay);
		switch (MisfireInstruction)
		{
		case 2:
			cb.WithMisfireHandlingInstructionDoNothing();
			break;
		case 1:
			cb.WithMisfireHandlingInstructionFireAndProceed();
			break;
		}
		return cb;
	}

	public TriggerBuilder GetTriggerBuilder()
	{
		return GetTriggerBuilder<IDailyTimeIntervalTrigger>();
	}
}
