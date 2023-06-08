using System;
using Quartz.Impl.Triggers;
using Quartz.Spi;

namespace Quartz;

/// <summary>
/// CronScheduleBuilder is a <see cref="T:Quartz.IScheduleBuilder" /> that defines
/// <see cref="T:Quartz.CronExpression" />-based schedules for <see cref="T:Quartz.ITrigger" />s.
/// </summary>
/// <remarks>
/// <para>
/// Quartz provides a builder-style API for constructing scheduling-related
/// entities via a Domain-Specific Language (DSL).  The DSL can best be
/// utilized through the usage of static imports of the methods on the classes
/// <see cref="T:Quartz.TriggerBuilder" />, <see cref="T:Quartz.JobBuilder" />,
/// <see cref="T:Quartz.DateBuilder" />, <see cref="T:Quartz.JobKey" />, <see cref="T:Quartz.TriggerKey" />
/// and the various <see cref="T:Quartz.IScheduleBuilder" /> implementations.
/// </para>
/// <para>
/// Client code can then use the DSL to write code such as this:
/// </para>
/// <code>
/// IJobDetail job = JobBuilder.Create&lt;MyJob&gt;()
///   .WithIdentity("myJob")
///   .Build();
/// ITrigger trigger = newTrigger()
///  .WithIdentity(triggerKey("myTrigger", "myTriggerGroup"))
///  .WithSimpleSchedule(x =&gt; x.WithIntervalInHours(1).RepeatForever())
///  .StartAt(DateBuilder.FutureDate(10, IntervalUnit.Minute))
///  .Build();
/// scheduler.scheduleJob(job, trigger);
/// </code>
/// </remarks>
/// <seealso cref="T:Quartz.CronExpression" />
/// <seealso cref="T:Quartz.ICronTrigger" />
/// <seealso cref="T:Quartz.IScheduleBuilder" />
/// <seealso cref="T:Quartz.SimpleScheduleBuilder" />
/// <seealso cref="T:Quartz.CalendarIntervalScheduleBuilder" />
/// <seealso cref="T:Quartz.TriggerBuilder" />
public class CronScheduleBuilder : ScheduleBuilder<ICronTrigger>
{
	private readonly CronExpression cronExpression;

	private int misfireInstruction;

	protected CronScheduleBuilder(CronExpression cronExpression)
	{
		if (cronExpression == null)
		{
			throw new ArgumentNullException("cronExpression", "cronExpression cannot be null");
		}
		this.cronExpression = cronExpression;
	}

	/// <summary>
	/// Build the actual Trigger -- NOT intended to be invoked by end users,
	/// but will rather be invoked by a TriggerBuilder which this
	/// ScheduleBuilder is given to.
	/// </summary>
	/// <seealso cref="M:Quartz.TriggerBuilder.WithSchedule(Quartz.IScheduleBuilder)" />
	public override IMutableTrigger Build()
	{
		CronTriggerImpl ct = new CronTriggerImpl();
		ct.CronExpression = cronExpression;
		ct.TimeZone = cronExpression.TimeZone;
		ct.MisfireInstruction = misfireInstruction;
		return ct;
	}

	/// <summary>
	/// Create a CronScheduleBuilder with the given cron-expression - which
	/// is presumed to b e valid cron expression (and hence only a RuntimeException
	/// will be thrown if it is not).
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <param name="cronExpression">the cron expression to base the schedule on.</param>
	/// <returns>the new CronScheduleBuilder</returns>
	/// <seealso cref="T:Quartz.CronExpression" />
	public static CronScheduleBuilder CronSchedule(string cronExpression)
	{
		CronExpression.ValidateExpression(cronExpression);
		return CronScheduleNoParseException(cronExpression);
	}

	/// <summary>
	/// Create a CronScheduleBuilder with the given cron-expression string - which
	/// may not be a valid cron expression (and hence a ParseException will be thrown
	/// f it is not).
	/// </summary>
	/// <param name="presumedValidCronExpression">the cron expression string to base the schedule on</param>
	/// <returns>the new CronScheduleBuilder</returns>
	/// <seealso cref="T:Quartz.CronExpression" /> 
	private static CronScheduleBuilder CronScheduleNoParseException(string presumedValidCronExpression)
	{
		try
		{
			return CronSchedule(new CronExpression(presumedValidCronExpression));
		}
		catch (FormatException e)
		{
			throw new Exception("CronExpression '" + presumedValidCronExpression + "' is invalid, which should not be possible, please report bug to Quartz developers.", e);
		}
	}

	/// <summary>
	/// Create a CronScheduleBuilder with the given cron-expression.
	/// </summary>
	/// <param name="cronExpression">the cron expression to base the schedule on.</param>
	/// <returns>the new CronScheduleBuilder</returns>
	/// <seealso cref="T:Quartz.CronExpression" /> 
	public static CronScheduleBuilder CronSchedule(CronExpression cronExpression)
	{
		return new CronScheduleBuilder(cronExpression);
	}

	/// <summary>
	/// Create a CronScheduleBuilder with a cron-expression that sets the
	/// schedule to fire every day at the given time (hour and minute).
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <param name="hour">the hour of day to fire</param>
	/// <param name="minute">the minute of the given hour to fire</param>
	/// <returns>the new CronScheduleBuilder</returns>
	/// <seealso cref="T:Quartz.CronExpression" />
	public static CronScheduleBuilder DailyAtHourAndMinute(int hour, int minute)
	{
		DateBuilder.ValidateHour(hour);
		DateBuilder.ValidateMinute(minute);
		string cronExpression = $"0 {minute} {hour} ? * *";
		return CronScheduleNoParseException(cronExpression);
	}

	/// <summary>
	/// Create a CronScheduleBuilder with a cron-expression that sets the
	/// schedule to fire at the given day at the given time (hour and minute) on the given days of the week.
	/// </summary>
	/// <param name="hour">the hour of day to fire</param>
	/// <param name="minute">the minute of the given hour to fire</param>
	/// <param name="daysOfWeek">the days of the week to fire</param>
	/// <returns>the new CronScheduleBuilder</returns>
	/// <seealso cref="T:Quartz.CronExpression" />
	public static CronScheduleBuilder AtHourAndMinuteOnGivenDaysOfWeek(int hour, int minute, params DayOfWeek[] daysOfWeek)
	{
		if (daysOfWeek == null || daysOfWeek.Length == 0)
		{
			throw new ArgumentException("You must specify at least one day of week.");
		}
		DateBuilder.ValidateHour(hour);
		DateBuilder.ValidateMinute(minute);
		string cronExpression = $"0 {minute} {hour} ? * {(int)(daysOfWeek[0] + 1)}";
		for (int i = 1; i < daysOfWeek.Length; i++)
		{
			cronExpression = cronExpression + "," + (int)(daysOfWeek[i] + 1);
		}
		return CronScheduleNoParseException(cronExpression);
	}

	/// <summary>
	/// Create a CronScheduleBuilder with a cron-expression that sets the
	/// schedule to fire one per week on the given day at the given time
	/// (hour and minute).
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <param name="dayOfWeek">the day of the week to fire</param>
	/// <param name="hour">the hour of day to fire</param>
	/// <param name="minute">the minute of the given hour to fire</param>
	/// <returns>the new CronScheduleBuilder</returns>
	/// <seealso cref="T:Quartz.CronExpression" />
	public static CronScheduleBuilder WeeklyOnDayAndHourAndMinute(DayOfWeek dayOfWeek, int hour, int minute)
	{
		DateBuilder.ValidateHour(hour);
		DateBuilder.ValidateMinute(minute);
		string cronExpression = $"0 {minute} {hour} ? * {(int)(dayOfWeek + 1)}";
		return CronScheduleNoParseException(cronExpression);
	}

	/// <summary>
	/// Create a CronScheduleBuilder with a cron-expression that sets the
	/// schedule to fire one per month on the given day of month at the given
	/// time (hour and minute).
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <param name="dayOfMonth">the day of the month to fire</param>
	/// <param name="hour">the hour of day to fire</param>
	/// <param name="minute">the minute of the given hour to fire</param>
	/// <returns>the new CronScheduleBuilder</returns>
	/// <seealso cref="T:Quartz.CronExpression" />
	public static CronScheduleBuilder MonthlyOnDayAndHourAndMinute(int dayOfMonth, int hour, int minute)
	{
		DateBuilder.ValidateDayOfMonth(dayOfMonth);
		DateBuilder.ValidateHour(hour);
		DateBuilder.ValidateMinute(minute);
		string cronExpression = $"0 {minute} {hour} {dayOfMonth} * ?";
		return CronScheduleNoParseException(cronExpression);
	}

	/// <summary>
	/// The <see cref="T:System.TimeZoneInfo" /> in which to base the schedule.
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <param name="tz">the time-zone for the schedule.</param>
	/// <returns>the updated CronScheduleBuilder</returns>
	/// <seealso cref="P:Quartz.CronExpression.TimeZone" />
	public CronScheduleBuilder InTimeZone(TimeZoneInfo tz)
	{
		cronExpression.TimeZone = tz;
		return this;
	}

	/// <summary>
	/// If the Trigger misfires, use the
	/// <see cref="F:Quartz.MisfireInstruction.IgnoreMisfirePolicy" /> instruction.
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <returns>the updated CronScheduleBuilder</returns>
	/// <seealso cref="F:Quartz.MisfireInstruction.IgnoreMisfirePolicy" />
	public CronScheduleBuilder WithMisfireHandlingInstructionIgnoreMisfires()
	{
		misfireInstruction = -1;
		return this;
	}

	/// <summary>
	/// If the Trigger misfires, use the <see cref="F:Quartz.MisfireInstruction.CronTrigger.DoNothing" />
	/// instruction.
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <returns>the updated CronScheduleBuilder</returns>
	/// <seealso cref="F:Quartz.MisfireInstruction.CronTrigger.DoNothing" />
	public CronScheduleBuilder WithMisfireHandlingInstructionDoNothing()
	{
		misfireInstruction = 2;
		return this;
	}

	/// <summary>
	/// If the Trigger misfires, use the <see cref="F:Quartz.MisfireInstruction.CronTrigger.FireOnceNow" />
	/// instruction.
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <returns>the updated CronScheduleBuilder</returns>
	/// <seealso cref="F:Quartz.MisfireInstruction.CronTrigger.FireOnceNow" />
	public CronScheduleBuilder WithMisfireHandlingInstructionFireAndProceed()
	{
		misfireInstruction = 1;
		return this;
	}

	internal CronScheduleBuilder WithMisfireHandlingInstruction(int readMisfireInstructionFromString)
	{
		misfireInstruction = readMisfireInstructionFromString;
		return this;
	}
}
