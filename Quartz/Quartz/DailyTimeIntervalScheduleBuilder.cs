using System;
using Quartz.Collection;
using Quartz.Impl.Triggers;
using Quartz.Spi;

namespace Quartz;

/// <summary>
/// A <see cref="T:Quartz.IScheduleBuilder" /> implementation that build schedule for DailyTimeIntervalTrigger.
/// </summary>
/// <remarks>
/// <para>
/// This builder provide an extra convenient method for you to set the trigger's EndTimeOfDay. You may
/// use either endingDailyAt() or EndingDailyAfterCount() to set the value. The later will auto calculate
/// your EndTimeOfDay by using the interval, IntervalUnit and StartTimeOfDay to perform the calculation.
/// </para>
/// <para>
/// When using EndingDailyAfterCount(), you should note that it is used to calculating EndTimeOfDay. So
/// if your startTime on the first day is already pass by a time that would not add up to the count you
/// expected, until the next day comes. Remember that DailyTimeIntervalTrigger will use StartTimeOfDay
/// and endTimeOfDay as fresh per each day!
/// </para>
/// <para>
/// Quartz provides a builder-style API for constructing scheduling-related
/// entities via a Domain-Specific Language (DSL).  The DSL can best be
/// utilized through the usage of static imports of the methods on the classes
/// <see cref="T:Quartz.TriggerBuilder" />, <see cref="T:Quartz.JobBuilder" />,
/// <see cref="T:Quartz.DateBuilder" />, <see cref="T:Quartz.JobKey" />, <see cref="T:Quartz.TriggerKey" />
/// and the various <see cref="T:Quartz.IScheduleBuilder" /> implementations.
/// </para>
/// <para>Client code can then use the DSL to write code such as this:</para>
/// <code>
///         IJobDetail job = JobBuilder.Create&lt;MyJob&gt;()
///             .WithIdentity("myJob")
///             .Build();
///
///         ITrigger trigger = TriggerBuilder.Create() 
///             .WithIdentity(triggerKey("myTrigger", "myTriggerGroup"))
///             .WithDailyTimeIntervalSchedule(x =&gt; 
///                        x.WithIntervalInMinutes(15)
///                        .StartingDailyAt(TimeOfDay.HourAndMinuteOfDay(8, 0))
///             .Build();
///
///         scheduler.scheduleJob(job, trigger);
/// </code>
/// </remarks>
/// <author>James House</author>
/// <author>Zemian Deng saltnlight5@gmail.com</author>
/// <author>Nuno Maia (.NET)</author>
public class DailyTimeIntervalScheduleBuilder : ScheduleBuilder<IDailyTimeIntervalTrigger>
{
	private int interval = 1;

	private IntervalUnit intervalUnit = IntervalUnit.Minute;

	private ISet<DayOfWeek> daysOfWeek;

	private TimeOfDay startTimeOfDayUtc;

	private TimeOfDay endTimeOfDayUtc;

	private int repeatCount = -1;

	private TimeZoneInfo timeZone;

	private int misfireInstruction;

	/// <summary>
	/// A set of all days of the week.
	/// </summary>
	/// <remarks>
	/// The set contains all values between <see cref="F:System.DayOfWeek.Sunday" /> and <see cref="F:System.DayOfWeek.Saturday" />
	/// </remarks>
	public static readonly ISet<DayOfWeek> AllDaysOfTheWeek;

	/// <summary>
	/// A set of the business days of the week (for locales similar to the USA).
	/// </summary>
	/// <remarks>
	/// The set contains all values between <see cref="F:System.DayOfWeek.Monday" /> and <see cref="F:System.DayOfWeek.Friday" /> 
	/// </remarks>
	public static readonly ISet<DayOfWeek> MondayThroughFriday;

	/// <summary>
	/// A set of the weekend days of the week (for locales similar to the USA).
	/// </summary>
	/// <remarks>
	/// The set contains <see cref="F:System.DayOfWeek.Saturday" /> and <see cref="F:System.DayOfWeek.Sunday" />
	/// </remarks>
	public static readonly ISet<DayOfWeek> SaturdayAndSunday;

	static DailyTimeIntervalScheduleBuilder()
	{
		AllDaysOfTheWeek = new HashSet<DayOfWeek>();
		MondayThroughFriday = new HashSet<DayOfWeek>();
		foreach (DayOfWeek d in Enum.GetValues(typeof(DayOfWeek)))
		{
			AllDaysOfTheWeek.Add(d);
			if (d >= DayOfWeek.Monday && d <= DayOfWeek.Friday)
			{
				MondayThroughFriday.Add(d);
			}
		}
		SaturdayAndSunday = new HashSet<DayOfWeek>();
		SaturdayAndSunday.Add(DayOfWeek.Sunday);
		SaturdayAndSunday.Add(DayOfWeek.Saturday);
		AllDaysOfTheWeek = new ReadOnlySet<DayOfWeek>(AllDaysOfTheWeek);
		MondayThroughFriday = new ReadOnlySet<DayOfWeek>(MondayThroughFriday);
		SaturdayAndSunday = new ReadOnlySet<DayOfWeek>(SaturdayAndSunday);
	}

	protected DailyTimeIntervalScheduleBuilder()
	{
	}

	/// <summary>
	/// Create a DailyTimeIntervalScheduleBuilder
	/// </summary>
	/// <returns>The new DailyTimeIntervalScheduleBuilder</returns>
	public static DailyTimeIntervalScheduleBuilder Create()
	{
		return new DailyTimeIntervalScheduleBuilder();
	}

	/// <summary>
	/// Build the actual Trigger -- NOT intended to be invoked by end users,
	/// but will rather be invoked by a TriggerBuilder which this 
	/// ScheduleBuilder is given to.
	/// </summary>
	/// <returns></returns>
	public override IMutableTrigger Build()
	{
		DailyTimeIntervalTriggerImpl st = new DailyTimeIntervalTriggerImpl();
		st.RepeatInterval = interval;
		st.RepeatIntervalUnit = intervalUnit;
		st.MisfireInstruction = misfireInstruction;
		st.RepeatCount = repeatCount;
		st.TimeZone = timeZone;
		if (daysOfWeek != null)
		{
			st.DaysOfWeek = new HashSet<DayOfWeek>(daysOfWeek);
		}
		else
		{
			st.DaysOfWeek = new HashSet<DayOfWeek>(AllDaysOfTheWeek);
		}
		if (startTimeOfDayUtc != null)
		{
			st.StartTimeOfDay = startTimeOfDayUtc;
		}
		else
		{
			st.StartTimeOfDay = TimeOfDay.HourAndMinuteOfDay(0, 0);
		}
		if (endTimeOfDayUtc != null)
		{
			st.EndTimeOfDay = endTimeOfDayUtc;
		}
		else
		{
			st.EndTimeOfDay = TimeOfDay.HourMinuteAndSecondOfDay(23, 59, 59);
		}
		return st;
	}

	/// <summary>
	/// Specify the time unit and interval for the Trigger to be produced.
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <param name="interval">the interval at which the trigger should repeat.</param>
	/// <param name="unit"> the time unit (IntervalUnit) of the interval.</param>
	/// <returns>the updated CalendarIntervalScheduleBuilder</returns>
	/// <seealso cref="P:Quartz.ICalendarIntervalTrigger.RepeatInterval" />
	/// <seealso cref="P:Quartz.ICalendarIntervalTrigger.RepeatIntervalUnit" />
	public DailyTimeIntervalScheduleBuilder WithInterval(int interval, IntervalUnit unit)
	{
		if (unit != IntervalUnit.Second && unit != IntervalUnit.Minute && unit != IntervalUnit.Hour)
		{
			throw new ArgumentException("Invalid repeat IntervalUnit (must be Second, Minute or Hour).");
		}
		ValidateInterval(interval);
		this.interval = interval;
		intervalUnit = unit;
		return this;
	}

	/// <summary>
	/// Specify an interval in the IntervalUnit.Second that the produced
	/// Trigger will repeat at.
	/// </summary>
	/// <param name="intervalInSeconds">The number of seconds at which the trigger should repeat.</param>
	/// <returns>the updated DailyTimeIntervalScheduleBuilder&gt;</returns>
	/// <see cref="P:Quartz.IDailyTimeIntervalTrigger.RepeatInterval" />
	/// <see cref="P:Quartz.IDailyTimeIntervalTrigger.RepeatIntervalUnit" />
	public DailyTimeIntervalScheduleBuilder WithIntervalInSeconds(int intervalInSeconds)
	{
		WithInterval(intervalInSeconds, IntervalUnit.Second);
		return this;
	}

	/// <summary>
	/// Specify an interval in the IntervalUnit.Minute that the produced
	/// Trigger will repeat at.
	/// </summary>
	/// <param name="intervalInMinutes">The number of minutes at which the trigger should repeat.</param>
	/// <returns>the updated DailyTimeIntervalScheduleBuilder&gt;</returns>
	/// <see cref="P:Quartz.IDailyTimeIntervalTrigger.RepeatInterval" />
	/// <see cref="P:Quartz.IDailyTimeIntervalTrigger.RepeatIntervalUnit" />
	public DailyTimeIntervalScheduleBuilder WithIntervalInMinutes(int intervalInMinutes)
	{
		WithInterval(intervalInMinutes, IntervalUnit.Minute);
		return this;
	}

	/// <summary>
	/// Specify an interval in the IntervalUnit.Hour that the produced
	/// Trigger will repeat at.
	/// </summary>
	/// <param name="intervalInHours">The number of hours at which the trigger should repeat.</param>
	/// <returns>the updated DailyTimeIntervalScheduleBuilder&gt;</returns>
	/// <see cref="P:Quartz.IDailyTimeIntervalTrigger.RepeatInterval" />
	/// <see cref="P:Quartz.IDailyTimeIntervalTrigger.RepeatIntervalUnit" />
	public DailyTimeIntervalScheduleBuilder WithIntervalInHours(int intervalInHours)
	{
		WithInterval(intervalInHours, IntervalUnit.Hour);
		return this;
	}

	/// <summary>
	/// Set the trigger to fire on the given days of the week.
	/// </summary>
	/// <param name="onDaysOfWeek">a Set containing the integers representing the days of the week, defined by <see cref="F:System.DayOfWeek.Sunday" /> - <see cref="F:System.DayOfWeek.Saturday" />. 
	/// </param>
	/// <returns>the updated DailyTimeIntervalScheduleBuilder</returns>
	public DailyTimeIntervalScheduleBuilder OnDaysOfTheWeek(ISet<DayOfWeek> onDaysOfWeek)
	{
		if (onDaysOfWeek == null || onDaysOfWeek.Count == 0)
		{
			throw new ArgumentException("Days of week must be an non-empty set.");
		}
		foreach (DayOfWeek day in onDaysOfWeek)
		{
			if (!AllDaysOfTheWeek.Contains(day))
			{
				throw new ArgumentException("Invalid value for day of week: " + day);
			}
		}
		daysOfWeek = onDaysOfWeek;
		return this;
	}

	/// <summary>
	/// Set the trigger to fire on the given days of the week.
	/// </summary>
	/// <param name="onDaysOfWeek">a variable length list of week days representing the days of the week</param>
	/// <returns>the updated DailyTimeIntervalScheduleBuilder</returns>
	public DailyTimeIntervalScheduleBuilder OnDaysOfTheWeek(params DayOfWeek[] onDaysOfWeek)
	{
		ISet<DayOfWeek> daysAsSet = new HashSet<DayOfWeek>();
		foreach (DayOfWeek day in onDaysOfWeek)
		{
			daysAsSet.Add(day);
		}
		return OnDaysOfTheWeek(daysAsSet);
	}

	/// <summary>
	/// Set the trigger to fire on the days from Monday through Friday.
	/// </summary>
	/// <returns>the updated DailyTimeIntervalScheduleBuilder</returns>
	public DailyTimeIntervalScheduleBuilder OnMondayThroughFriday()
	{
		daysOfWeek = MondayThroughFriday;
		return this;
	}

	/// <summary>
	/// Set the trigger to fire on the days Saturday and Sunday.
	/// </summary>
	/// <returns>the updated DailyTimeIntervalScheduleBuilder</returns>
	public DailyTimeIntervalScheduleBuilder OnSaturdayAndSunday()
	{
		daysOfWeek = SaturdayAndSunday;
		return this;
	}

	/// <summary>
	/// Set the trigger to fire on all days of the week.
	/// </summary>
	/// <returns>the updated DailyTimeIntervalScheduleBuilder</returns>
	public DailyTimeIntervalScheduleBuilder OnEveryDay()
	{
		daysOfWeek = AllDaysOfTheWeek;
		return this;
	}

	/// <summary>
	/// Set the trigger to begin firing each day at the given time.
	/// </summary>
	/// <param name="timeOfDayUtc"></param>
	/// <returns>the updated DailyTimeIntervalScheduleBuilder</returns>
	public DailyTimeIntervalScheduleBuilder StartingDailyAt(TimeOfDay timeOfDayUtc)
	{
		if (timeOfDayUtc == null)
		{
			throw new ArgumentException("Start time of day cannot be null!");
		}
		startTimeOfDayUtc = timeOfDayUtc;
		return this;
	}

	/// <summary>
	/// Set the startTimeOfDay for this trigger to end firing each day at the given time.
	/// </summary>
	/// <param name="timeOfDayUtc"></param>
	/// <returns>the updated DailyTimeIntervalScheduleBuilder</returns>
	public DailyTimeIntervalScheduleBuilder EndingDailyAt(TimeOfDay timeOfDayUtc)
	{
		endTimeOfDayUtc = timeOfDayUtc;
		return this;
	}

	/// <summary>
	/// Calculate and set the EndTimeOfDay using count, interval and StarTimeOfDay. This means
	/// that these must be set before this method is call.
	/// </summary>
	/// <param name="count"></param>
	/// <returns>the updated DailyTimeIntervalScheduleBuilder</returns>
	public DailyTimeIntervalScheduleBuilder EndingDailyAfterCount(int count)
	{
		if (count <= 0)
		{
			throw new ArgumentException("Ending daily after count must be a positive number!");
		}
		if (startTimeOfDayUtc == null)
		{
			throw new ArgumentException("You must set the StartDailyAt() before calling this EndingDailyAfterCount()!");
		}
		DateTimeOffset today = SystemTime.UtcNow();
		DateTimeOffset startTimeOfDayDate = startTimeOfDayUtc.GetTimeOfDayForDate(today).Value;
		DateTimeOffset maxEndTimeOfDayDate = TimeOfDay.HourMinuteAndSecondOfDay(23, 59, 59).GetTimeOfDayForDate(today).Value;
		TimeZoneInfo targetTimeZone = timeZone ?? TimeZoneInfo.Local;
		startTimeOfDayDate = new DateTimeOffset(startTimeOfDayDate.DateTime, targetTimeZone.GetUtcOffset(startTimeOfDayDate.DateTime));
		maxEndTimeOfDayDate = new DateTimeOffset(maxEndTimeOfDayDate.DateTime, targetTimeZone.GetUtcOffset(maxEndTimeOfDayDate.DateTime));
		TimeSpan remainingMillisInDay = maxEndTimeOfDayDate - startTimeOfDayDate;
		TimeSpan intervalInMillis = TimeSpan.Zero;
		if (intervalUnit == IntervalUnit.Second)
		{
			intervalInMillis = TimeSpan.FromSeconds(interval);
		}
		else if (intervalUnit == IntervalUnit.Minute)
		{
			intervalInMillis = TimeSpan.FromSeconds(interval * 60);
		}
		else
		{
			if (intervalUnit != IntervalUnit.Hour)
			{
				throw new ArgumentException(string.Concat("The IntervalUnit: ", intervalUnit, " is invalid for this trigger."));
			}
			intervalInMillis = TimeSpan.FromSeconds(interval * 60 * 24);
		}
		if (remainingMillisInDay < intervalInMillis)
		{
			throw new ArgumentException("The startTimeOfDay is too late with given Interval and IntervalUnit values.");
		}
		long maxNumOfCount = remainingMillisInDay.Ticks / intervalInMillis.Ticks;
		if (count > maxNumOfCount)
		{
			throw new ArgumentException("The given count " + count + " is too large! The max you can set is " + maxNumOfCount);
		}
		TimeSpan incrementInMillis = TimeSpan.FromTicks((count - 1) * intervalInMillis.Ticks);
		DateTimeOffset endTimeOfDayDate = startTimeOfDayDate.Add(incrementInMillis);
		if (endTimeOfDayDate > maxEndTimeOfDayDate)
		{
			throw new ArgumentException("The given count " + count + " is too large! The max you can set is " + maxNumOfCount);
		}
		DateTime cal = SystemTime.UtcNow().Date.Add(endTimeOfDayDate.TimeOfDay);
		endTimeOfDayUtc = TimeOfDay.HourMinuteAndSecondOfDay(cal.Hour, cal.Minute, cal.Second);
		return this;
	}

	/// <summary>
	/// If the Trigger misfires, use the 
	/// <see cref="F:Quartz.MisfireInstruction.IgnoreMisfirePolicy" /> instruction.
	/// </summary>
	/// <returns>the updated DailyTimeIntervalScheduleBuilder</returns>
	/// <seealso cref="F:Quartz.MisfireInstruction.IgnoreMisfirePolicy" />
	public DailyTimeIntervalScheduleBuilder WithMisfireHandlingInstructionIgnoreMisfires()
	{
		misfireInstruction = -1;
		return this;
	}

	/// <summary>
	/// If the Trigger misfires, use the 
	/// <see cref="F:Quartz.MisfireInstruction.DailyTimeIntervalTrigger.DoNothing" /> instruction.
	/// </summary>
	/// <returns>the updated DailyTimeIntervalScheduleBuilder</returns>
	/// <seealso cref="F:Quartz.MisfireInstruction.DailyTimeIntervalTrigger.DoNothing" />
	public DailyTimeIntervalScheduleBuilder WithMisfireHandlingInstructionDoNothing()
	{
		misfireInstruction = 2;
		return this;
	}

	/// <summary>
	/// If the Trigger misfires, use the 
	/// <see cref="F:Quartz.MisfireInstruction.DailyTimeIntervalTrigger.FireOnceNow" /> instruction.
	/// </summary>
	/// <returns>the updated DailyTimeIntervalScheduleBuilder</returns>
	/// <seealso cref="F:Quartz.MisfireInstruction.DailyTimeIntervalTrigger.FireOnceNow" />
	public DailyTimeIntervalScheduleBuilder WithMisfireHandlingInstructionFireAndProceed()
	{
		misfireInstruction = 1;
		return this;
	}

	/// <summary>
	/// Set number of times for interval to repeat.
	/// </summary>
	/// <remarks>
	/// Note: if you want total count = 1 (at start time) + repeatCount
	/// </remarks>
	/// <param name="repeatCount"></param>
	/// <returns></returns>
	public DailyTimeIntervalScheduleBuilder WithRepeatCount(int repeatCount)
	{
		this.repeatCount = repeatCount;
		return this;
	}

	/// <summary>
	/// TimeZone in which to base the schedule.
	/// </summary>
	/// <param name="timezone">the time-zone for the schedule</param>
	/// <returns>the updated CalendarIntervalScheduleBuilder</returns>
	/// <seealso cref="P:Quartz.ICalendarIntervalTrigger.TimeZone" />
	public DailyTimeIntervalScheduleBuilder InTimeZone(TimeZoneInfo timezone)
	{
		timeZone = timezone;
		return this;
	}

	private void ValidateInterval(int interval)
	{
		if (interval <= 0)
		{
			throw new ArgumentException("Interval must be a positive value.");
		}
	}
}
