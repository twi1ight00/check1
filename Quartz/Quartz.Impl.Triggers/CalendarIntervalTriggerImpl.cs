using System;
using Quartz.Util;

namespace Quartz.Impl.Triggers;

/// <summary>
///  A concrete <see cref="T:Quartz.ITrigger" /> that is used to fire a <see cref="T:Quartz.IJobDetail" />
///  based upon repeating calendar time intervals.
///  </summary>
/// <remarks>
/// The trigger will fire every N (see <see cref="P:Quartz.Impl.Triggers.CalendarIntervalTriggerImpl.RepeatInterval" />) units of calendar time
/// (see <see cref="P:Quartz.Impl.Triggers.CalendarIntervalTriggerImpl.RepeatIntervalUnit" />) as specified in the trigger's definition.  
/// This trigger can achieve schedules that are not possible with <see cref="T:Quartz.ISimpleTrigger" /> (e.g 
/// because months are not a fixed number of seconds) or <see cref="T:Quartz.ICronTrigger" /> (e.g. because
/// "every 5 months" is not an even divisor of 12).
/// <para>
/// If you use an interval unit of <see cref="F:Quartz.IntervalUnit.Month" /> then care should be taken when setting
/// a <see cref="P:Quartz.Impl.Triggers.CalendarIntervalTriggerImpl.StartTimeUtc" /> value that is on a day near the end of the month.  For example,
/// if you choose a start time that occurs on January 31st, and have a trigger with unit
/// <see cref="F:Quartz.IntervalUnit.Month" /> and interval 1, then the next fire time will be February 28th, 
/// and the next time after that will be March 28th - and essentially each subsequent firing will 
/// occur on the 28th of the month, even if a 31st day exists.  If you want a trigger that always
/// fires on the last day of the month - regardless of the number of days in the month, 
/// you should use <see cref="T:Quartz.ICronTrigger" />.
/// </para> 
/// </remarks>
/// <see cref="T:Quartz.ITrigger" />
/// <see cref="T:Quartz.ICronTrigger" />
/// <see cref="T:Quartz.ISimpleTrigger" />
/// <see cref="T:Quartz.IDailyTimeIntervalTrigger" />
/// <since>2.0</since>
/// <author>James House</author>
/// <author>Marko Lahma (.NET)</author>
[Serializable]
public class CalendarIntervalTriggerImpl : AbstractTrigger, ICalendarIntervalTrigger, ITrigger, ICloneable, IComparable<ITrigger>
{
	private static readonly int YearToGiveupSchedulingAt = DateTime.Now.AddYears(100).Year;

	private DateTimeOffset startTime;

	private DateTimeOffset? endTime;

	private DateTimeOffset? nextFireTimeUtc;

	private DateTimeOffset? previousFireTimeUtc;

	private int repeatInterval;

	private IntervalUnit repeatIntervalUnit = IntervalUnit.Day;

	private TimeZoneInfo timeZone;

	private bool preserveHourOfDayAcrossDaylightSavings;

	private bool skipDayIfHourDoesNotExist;

	private int timesTriggered;

	private bool complete;

	/// <summary>
	/// Get the time at which the <see cref="T:Quartz.Impl.Triggers.CalendarIntervalTriggerImpl" /> should occur.
	/// </summary>
	public override DateTimeOffset StartTimeUtc
	{
		get
		{
			if (startTime == DateTimeOffset.MinValue)
			{
				startTime = SystemTime.UtcNow();
			}
			return startTime;
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
			startTime = value;
		}
	}

	/// <summary>
	/// Tells whether this Trigger instance can handle events
	/// in millisecond precision.
	/// </summary>
	public override bool HasMillisecondPrecision => true;

	/// <summary>
	/// Get the time at which the <see cref="T:Quartz.ICalendarIntervalTrigger" /> should quit
	/// repeating.
	/// </summary>
	public override DateTimeOffset? EndTimeUtc
	{
		get
		{
			return endTime;
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
			endTime = value;
		}
	}

	/// <summary>
	/// Get or set the interval unit - the time unit on with the interval applies.
	/// </summary>
	public IntervalUnit RepeatIntervalUnit
	{
		get
		{
			return repeatIntervalUnit;
		}
		set
		{
			repeatIntervalUnit = value;
		}
	}

	/// <summary>
	/// Get the the time interval that will be added to the <see cref="T:Quartz.ICalendarIntervalTrigger" />'s
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
	///  If intervals are a day or greater, this property (set to true) will 
	///  cause the firing of the trigger to always occur at the same time of day,
	///  (the time of day of the startTime) regardless of daylight saving time 
	///  transitions.  Default value is false.
	///  </summary>
	///  <remarks>
	///  <para>
	///  For example, without the property set, your trigger may have a start 
	///  time of 9:00 am on March 1st, and a repeat interval of 2 days.  But 
	///  after the daylight saving transition occurs, the trigger may start 
	///  firing at 8:00 am every other day.
	///  </para>
	///  <para>
	///  If however, the time of day does not exist on a given day to fire
	///  (e.g. 2:00 am in the United States on the days of daylight saving
	///  transition), the trigger will go ahead and fire one hour off on 
	///  that day, and then resume the normal hour on other days.  If
	///  you wish for the trigger to never fire at the "wrong" hour, then
	///  you should set the property skipDayIfHourDoesNotExist.
	///  </para>
	/// </remarks>
	///  <seealso cref="P:Quartz.ICalendarIntervalTrigger.SkipDayIfHourDoesNotExist" />
	///  <seealso cref="P:Quartz.ICalendarIntervalTrigger.TimeZone" />
	///  <seealso cref="M:Quartz.TriggerBuilder.StartAt(System.DateTimeOffset)" />
	public bool PreserveHourOfDayAcrossDaylightSavings
	{
		get
		{
			return preserveHourOfDayAcrossDaylightSavings;
		}
		set
		{
			preserveHourOfDayAcrossDaylightSavings = value;
		}
	}

	/// <summary>
	/// If intervals are a day or greater, and 
	/// preserveHourOfDayAcrossDaylightSavings property is set to true, and the
	/// hour of the day does not exist on a given day for which the trigger 
	/// would fire, the day will be skipped and the trigger advanced a second
	/// interval if this property is set to true.  Defaults to false.
	/// </summary>
	/// <remarks>
	/// <b>CAUTION!</b>  If you enable this property, and your hour of day happens 
	/// to be that of daylight savings transition (e.g. 2:00 am in the United 
	/// States) and the trigger's interval would have had the trigger fire on
	/// that day, then you may actually completely miss a firing on the day of 
	/// transition if that hour of day does not exist on that day!  In such a 
	/// case the next fire time of the trigger will be computed as double (if 
	/// the interval is 2 days, then a span of 4 days between firings will 
	/// occur).
	/// </remarks>
	/// <seealso cref="P:Quartz.ICalendarIntervalTrigger.PreserveHourOfDayAcrossDaylightSavings" />
	public bool SkipDayIfHourDoesNotExist
	{
		get
		{
			return skipDayIfHourDoesNotExist;
		}
		set
		{
			skipDayIfHourDoesNotExist = value;
		}
	}

	/// <summary>
	/// Get the number of times the <see cref="T:Quartz.ICalendarIntervalTrigger" /> has already fired.
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

	/// <summary>
	/// Returns the final time at which the <see cref="T:Quartz.ICalendarIntervalTrigger" /> will
	/// fire, if there is no end time set, null will be returned.
	/// </summary>
	/// <value></value>
	/// <remarks>Note that the return time may be in the past.</remarks>
	public override DateTimeOffset? FinalFireTimeUtc
	{
		get
		{
			if (complete || !EndTimeUtc.HasValue)
			{
				return null;
			}
			DateTimeOffset? fTime = EndTimeUtc.Value.AddSeconds(-1.0);
			fTime = GetFireTimeAfter(fTime, ignoreEndTime: true);
			if (fTime == EndTimeUtc)
			{
				return fTime;
			}
			DateTimeOffset lTime = fTime.Value;
			if (RepeatIntervalUnit == IntervalUnit.Second)
			{
				lTime = lTime.AddSeconds(-1 * RepeatInterval);
			}
			else if (RepeatIntervalUnit == IntervalUnit.Minute)
			{
				lTime = lTime.AddMinutes(-1 * RepeatInterval);
			}
			else if (RepeatIntervalUnit == IntervalUnit.Hour)
			{
				lTime = lTime.AddHours(-1 * RepeatInterval);
			}
			else if (RepeatIntervalUnit == IntervalUnit.Day)
			{
				lTime = lTime.AddDays(-1 * RepeatInterval);
			}
			else if (RepeatIntervalUnit == IntervalUnit.Week)
			{
				lTime = lTime.AddDays(-1 * RepeatInterval * 7);
			}
			else if (RepeatIntervalUnit == IntervalUnit.Month)
			{
				lTime = lTime.AddMonths(-1 * RepeatInterval);
			}
			else if (RepeatIntervalUnit == IntervalUnit.Year)
			{
				lTime = lTime.AddYears(-1 * RepeatInterval);
			}
			return lTime;
		}
	}

	public override bool HasAdditionalProperties => false;

	/// <summary>
	/// Create a <see cref="T:Quartz.ICalendarIntervalTrigger" /> with no settings.
	/// </summary>
	public CalendarIntervalTriggerImpl()
	{
	}

	/// <summary>
	/// Create a <see cref="T:Quartz.Impl.Triggers.CalendarIntervalTriggerImpl" /> that will occur immediately, and
	/// repeat at the the given interval.
	/// </summary>
	/// <param name="name">Name for the trigger instance.</param>
	/// <param name="intervalUnit">The repeat interval unit (minutes, days, months, etc).</param>
	/// <param name="repeatInterval">The number of milliseconds to pause between the repeat firing.</param>
	public CalendarIntervalTriggerImpl(string name, IntervalUnit intervalUnit, int repeatInterval)
		: this(name, null, intervalUnit, repeatInterval)
	{
	}

	/// <summary>
	/// Create a <see cref="T:Quartz.ICalendarIntervalTrigger" /> that will occur immediately, and
	/// repeat at the the given interval
	/// </summary>
	/// <param name="name">Name for the trigger instance.</param>
	/// <param name="group">Group for the trigger instance.</param>
	/// <param name="intervalUnit">The repeat interval unit (minutes, days, months, etc).</param>
	/// <param name="repeatInterval">The number of milliseconds to pause between the repeat firing.</param>
	public CalendarIntervalTriggerImpl(string name, string group, IntervalUnit intervalUnit, int repeatInterval)
		: this(name, group, SystemTime.UtcNow(), null, intervalUnit, repeatInterval)
	{
	}

	/// <summary>
	/// Create a <see cref="T:Quartz.ICalendarIntervalTrigger" /> that will occur at the given time,
	/// and repeat at the the given interval until the given end time.
	/// </summary>
	/// <param name="name">Name for the trigger instance.</param>
	/// <param name="startTimeUtc">A <see cref="T:System.DateTimeOffset" /> set to the time for the <see cref="T:Quartz.ITrigger" /> to fire.</param>
	/// <param name="endTimeUtc">A <see cref="T:System.DateTimeOffset" /> set to the time for the <see cref="T:Quartz.ITrigger" /> to quit repeat firing.</param>
	/// <param name="intervalUnit">The repeat interval unit (minutes, days, months, etc).</param>
	/// <param name="repeatInterval">The number of milliseconds to pause between the repeat firing.</param>
	public CalendarIntervalTriggerImpl(string name, DateTimeOffset startTimeUtc, DateTimeOffset? endTimeUtc, IntervalUnit intervalUnit, int repeatInterval)
		: this(name, null, startTimeUtc, endTimeUtc, intervalUnit, repeatInterval)
	{
	}

	/// <summary>
	/// Create a <see cref="T:Quartz.ICalendarIntervalTrigger" /> that will occur at the given time,
	/// and repeat at the the given interval until the given end time.
	/// </summary>
	/// <param name="name">Name for the trigger instance.</param>
	/// <param name="group">Group for the trigger instance.</param>
	/// <param name="startTimeUtc">A <see cref="T:System.DateTimeOffset" /> set to the time for the <see cref="T:Quartz.ITrigger" /> to fire.</param>
	/// <param name="endTimeUtc">A <see cref="T:System.DateTimeOffset" /> set to the time for the <see cref="T:Quartz.ITrigger" /> to quit repeat firing.</param>
	/// <param name="intervalUnit">The repeat interval unit (minutes, days, months, etc).</param>
	/// <param name="repeatInterval">The number of milliseconds to pause between the repeat firing.</param>
	public CalendarIntervalTriggerImpl(string name, string group, DateTimeOffset startTimeUtc, DateTimeOffset? endTimeUtc, IntervalUnit intervalUnit, int repeatInterval)
		: base(name, group)
	{
		StartTimeUtc = startTimeUtc;
		EndTimeUtc = endTimeUtc;
		RepeatIntervalUnit = intervalUnit;
		RepeatInterval = repeatInterval;
	}

	/// <summary>
	/// Create a <see cref="T:Quartz.ICalendarIntervalTrigger" /> that will occur at the given time,
	/// and repeat at the the given interval until the given end time.
	/// </summary>
	/// <param name="name">Name for the trigger instance.</param>
	/// <param name="group">Group for the trigger instance.</param>
	/// <param name="jobName">Name of the associated job.</param>
	/// <param name="jobGroup">Group of the associated job.</param>
	/// <param name="startTimeUtc">A <see cref="T:System.DateTimeOffset" /> set to the time for the <see cref="T:Quartz.ITrigger" /> to fire.</param>
	/// <param name="endTimeUtc">A <see cref="T:System.DateTimeOffset" /> set to the time for the <see cref="T:Quartz.ITrigger" /> to quit repeat firing.</param>
	/// <param name="intervalUnit">The repeat interval unit (minutes, days, months, etc).</param>
	/// <param name="repeatInterval">The number of milliseconds to pause between the repeat firing.</param>
	public CalendarIntervalTriggerImpl(string name, string group, string jobName, string jobGroup, DateTimeOffset startTimeUtc, DateTimeOffset? endTimeUtc, IntervalUnit intervalUnit, int repeatInterval)
		: base(name, group, jobName, jobGroup)
	{
		StartTimeUtc = startTimeUtc;
		EndTimeUtc = endTimeUtc;
		RepeatIntervalUnit = intervalUnit;
		RepeatInterval = repeatInterval;
	}

	public TriggerBuilder GetTriggerBuilder()
	{
		throw new NotImplementedException();
	}

	/// <summary>
	/// Validates the misfire instruction.
	/// </summary>
	/// <param name="misfireInstruction">The misfire instruction.</param>
	/// <returns></returns>
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
	/// MisfireInstruction.XXX that was selected when the <see cref="T:Quartz.ICalendarIntervalTrigger" />
	/// was created.
	/// </summary>
	/// <remarks>
	/// If the misfire instruction is set to <see cref="F:Quartz.MisfireInstruction.SmartPolicy" />,
	/// then the following scheme will be used:
	/// <ul>
	///     <li>The instruction will be interpreted as <see cref="F:Quartz.MisfireInstruction.CalendarIntervalTrigger.FireOnceNow" /></li>
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
	/// This method should not be used by the Quartz client.
	/// <para>
	/// Called when the <see cref="T:Quartz.IScheduler" /> has decided to 'fire'
	/// the trigger (Execute the associated <see cref="T:Quartz.IJob" />), in order to
	/// give the <see cref="T:Quartz.ITrigger" /> a chance to update itself for its next
	/// triggering (if any).
	/// </para>
	/// </summary>
	/// <seealso cref="T:Quartz.JobExecutionException" />
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
	}

	/// <summary> 
	/// This method should not be used by the Quartz client.
	/// <para>
	/// The implementation should update the <see cref="T:Quartz.ITrigger" />'s state
	/// based on the given new version of the associated <see cref="T:Quartz.ICalendar" />
	/// (the state should be updated so that it's next fire time is appropriate
	/// given the Calendar's new settings). 
	/// </para>
	/// </summary>
	/// <param name="calendar"> </param>
	/// <param name="misfireThreshold"></param>
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
		nextFireTimeUtc = StartTimeUtc;
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

	public override void SetNextFireTimeUtc(DateTimeOffset? value)
	{
		nextFireTimeUtc = value;
	}

	public override void SetPreviousFireTimeUtc(DateTimeOffset? previousFireTimeUtc)
	{
		this.previousFireTimeUtc = previousFireTimeUtc;
	}

	/// <summary>
	/// Returns the next time at which the <see cref="T:Quartz.ICalendarIntervalTrigger" /> will fire,
	/// after the given time. If the trigger will not fire after the given time,
	/// <see langword="null" /> will be returned.
	/// </summary>
	public override DateTimeOffset? GetFireTimeAfter(DateTimeOffset? afterTime)
	{
		return GetFireTimeAfter(afterTime, ignoreEndTime: false);
	}

	protected DateTimeOffset? GetFireTimeAfter(DateTimeOffset? afterTime, bool ignoreEndTime)
	{
		if (complete)
		{
			return null;
		}
		afterTime = (afterTime.HasValue ? new DateTimeOffset?(afterTime.Value.AddSeconds(1.0)) : new DateTimeOffset?(SystemTime.UtcNow().AddSeconds(1.0)));
		DateTimeOffset startMillis = StartTimeUtc;
		DateTimeOffset afterMillis = afterTime.Value;
		DateTimeOffset endMillis = ((!EndTimeUtc.HasValue) ? DateTimeOffset.MaxValue : EndTimeUtc.Value);
		if (!ignoreEndTime && endMillis <= afterMillis)
		{
			return null;
		}
		if (afterMillis < startMillis)
		{
			return startMillis;
		}
		long secondsAfterStart = (long)(afterMillis - startMillis).TotalSeconds;
		DateTimeOffset? time = null;
		long repeatLong = RepeatInterval;
		DateTimeOffset sTime = StartTimeUtc;
		if (timeZone != null)
		{
			sTime = TimeZoneUtil.ConvertTime(sTime, timeZone);
		}
		if (RepeatIntervalUnit == IntervalUnit.Second)
		{
			long jumpCount5 = secondsAfterStart / repeatLong;
			if (secondsAfterStart % repeatLong != 0)
			{
				jumpCount5++;
			}
			time = sTime.AddSeconds(RepeatInterval * (int)jumpCount5);
		}
		else if (RepeatIntervalUnit == IntervalUnit.Minute)
		{
			long jumpCount4 = secondsAfterStart / (repeatLong * 60);
			if (secondsAfterStart % (repeatLong * 60) != 0)
			{
				jumpCount4++;
			}
			time = sTime.AddMinutes(RepeatInterval * (int)jumpCount4);
		}
		else if (RepeatIntervalUnit == IntervalUnit.Hour)
		{
			long jumpCount3 = secondsAfterStart / (repeatLong * 60 * 60);
			if (secondsAfterStart % (repeatLong * 60 * 60) != 0)
			{
				jumpCount3++;
			}
			time = sTime.AddHours(RepeatInterval * (int)jumpCount3);
		}
		else
		{
			int initialHourOfDay = sTime.Hour;
			if (RepeatIntervalUnit == IntervalUnit.Day)
			{
				long jumpCount2 = secondsAfterStart / (repeatLong * 24 * 60 * 60);
				if (jumpCount2 > 20)
				{
					jumpCount2 = ((jumpCount2 < 50) ? ((long)((double)jumpCount2 * 0.8)) : ((jumpCount2 >= 500) ? ((long)((double)jumpCount2 * 0.95)) : ((long)((double)jumpCount2 * 0.9))));
					sTime = sTime.AddDays(RepeatInterval * jumpCount2);
				}
				sTime = TimeZoneUtil.ConvertTime(sTime, TimeZone);
				while (sTime.UtcDateTime < afterTime.Value.UtcDateTime && sTime.Year < YearToGiveupSchedulingAt)
				{
					sTime = sTime.AddDays(RepeatInterval);
					MakeHourAdjustmentIfNeeded(ref sTime, initialHourOfDay);
				}
				while (DaylightSavingHourShiftOccuredAndAdvanceNeeded(ref sTime, initialHourOfDay) && sTime.Year < YearToGiveupSchedulingAt)
				{
					sTime = sTime.AddDays(RepeatInterval);
				}
				time = sTime;
			}
			else if (RepeatIntervalUnit == IntervalUnit.Week)
			{
				long jumpCount = secondsAfterStart / (repeatLong * 7 * 24 * 60 * 60);
				if (jumpCount > 20)
				{
					jumpCount = ((jumpCount < 50) ? ((long)((double)jumpCount * 0.8)) : ((jumpCount >= 500) ? ((long)((double)jumpCount * 0.95)) : ((long)((double)jumpCount * 0.9))));
					sTime = sTime.AddDays((int)(RepeatInterval * jumpCount * 7));
				}
				sTime = TimeZoneUtil.ConvertTime(sTime, TimeZone);
				while (sTime.UtcDateTime < afterTime.Value.UtcDateTime && sTime.Year < YearToGiveupSchedulingAt)
				{
					sTime = sTime.AddDays(RepeatInterval * 7);
					MakeHourAdjustmentIfNeeded(ref sTime, initialHourOfDay);
				}
				while (DaylightSavingHourShiftOccuredAndAdvanceNeeded(ref sTime, initialHourOfDay) && sTime.Year < YearToGiveupSchedulingAt)
				{
					sTime = sTime.AddDays(RepeatInterval * 7);
				}
				time = sTime;
			}
			else if (RepeatIntervalUnit == IntervalUnit.Month)
			{
				sTime = TimeZoneUtil.ConvertTime(sTime, TimeZone);
				while (sTime.UtcDateTime < afterTime.Value.UtcDateTime && sTime.Year < YearToGiveupSchedulingAt)
				{
					sTime = sTime.AddMonths(RepeatInterval);
					MakeHourAdjustmentIfNeeded(ref sTime, initialHourOfDay);
				}
				while (DaylightSavingHourShiftOccuredAndAdvanceNeeded(ref sTime, initialHourOfDay) && sTime.Year < YearToGiveupSchedulingAt)
				{
					sTime = sTime.AddMonths(RepeatInterval);
				}
				time = sTime;
			}
			else if (RepeatIntervalUnit == IntervalUnit.Year)
			{
				sTime = TimeZoneUtil.ConvertTime(sTime, TimeZone);
				while (sTime.UtcDateTime < afterTime.Value.UtcDateTime && sTime.Year < YearToGiveupSchedulingAt)
				{
					sTime = sTime.AddYears(RepeatInterval);
					MakeHourAdjustmentIfNeeded(ref sTime, initialHourOfDay);
				}
				while (DaylightSavingHourShiftOccuredAndAdvanceNeeded(ref sTime, initialHourOfDay) && sTime.Year < YearToGiveupSchedulingAt)
				{
					sTime = sTime.AddYears(RepeatInterval);
				}
				time = sTime;
			}
		}
		if (!ignoreEndTime && endMillis <= time)
		{
			return null;
		}
		sTime = TimeZoneUtil.ConvertTime(sTime, TimeZone);
		return time;
	}

	private bool DaylightSavingHourShiftOccuredAndAdvanceNeeded(ref DateTimeOffset newTime, int initialHourOfDay)
	{
		DateTimeOffset toCheck = TimeZoneUtil.ConvertTime(newTime, TimeZone);
		if (PreserveHourOfDayAcrossDaylightSavings && toCheck.Hour != initialHourOfDay)
		{
			newTime = new DateTimeOffset(newTime.Year, newTime.Month, newTime.Day, initialHourOfDay, newTime.Minute, newTime.Second, newTime.Millisecond, TimeSpan.Zero);
			newTime = new DateTimeOffset(newTime.DateTime, TimeZone.GetUtcOffset(newTime.DateTime));
			if (TimeZone.IsInvalidTime(newTime.DateTime) && skipDayIfHourDoesNotExist)
			{
				return skipDayIfHourDoesNotExist;
			}
			while (TimeZone.IsInvalidTime(newTime.DateTime))
			{
				newTime = newTime.AddMinutes(1.0);
			}
			newTime = new DateTimeOffset(newTime.DateTime, TimeZone.GetUtcOffset(newTime.DateTime));
		}
		return false;
	}

	private void MakeHourAdjustmentIfNeeded(ref DateTimeOffset sTime, int initialHourOfDay)
	{
		int initalYear = sTime.Year;
		int initalMonth = sTime.Month;
		int initialDay = sTime.Day;
		sTime = TimeZoneUtil.ConvertTime(sTime, TimeZone);
		if (PreserveHourOfDayAcrossDaylightSavings && sTime.Hour != initialHourOfDay)
		{
			sTime = new DateTimeOffset(initalYear, initalMonth, initialDay, initialHourOfDay, sTime.Minute, sTime.Second, sTime.Millisecond, TimeSpan.Zero);
			sTime = new DateTimeOffset(sTime.DateTime, TimeZone.GetUtcOffset(sTime.DateTime));
		}
	}

	/// <summary>
	/// Determines whether or not the <see cref="T:Quartz.ICalendarIntervalTrigger" /> will occur
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
		if (repeatIntervalUnit == IntervalUnit.Millisecond)
		{
			throw new SchedulerException("Invalid repeat IntervalUnit (must be Second, Minute, Hour, Day, Month, Week or Year).");
		}
		if (repeatInterval < 1)
		{
			throw new SchedulerException("Repeat Interval cannot be zero.");
		}
	}

	/// <summary>
	/// Get a <see cref="T:Quartz.IScheduleBuilder" /> that is configured to produce a
	/// schedule identical to this trigger's schedule.
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <seealso cref="M:Quartz.Impl.Triggers.CalendarIntervalTriggerImpl.GetTriggerBuilder" />
	public override IScheduleBuilder GetScheduleBuilder()
	{
		CalendarIntervalScheduleBuilder cb = CalendarIntervalScheduleBuilder.Create().WithInterval(RepeatInterval, RepeatIntervalUnit);
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
}
