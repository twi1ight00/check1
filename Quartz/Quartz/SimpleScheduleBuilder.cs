using System;
using Quartz.Impl.Triggers;
using Quartz.Spi;

namespace Quartz;

/// <summary>
/// SimpleScheduleBuilder is a <see cref="T:Quartz.IScheduleBuilder" />
/// that defines strict/literal interval-based schedules for
/// <see cref="T:Quartz.ITrigger" />s.
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
/// <para>Client code can then use the DSL to write code such as this:</para>
/// <code>
/// JobDetail job = JobBuilder.Create&lt;MyJob&gt;()
///     .WithIdentity("myJob")
///     .Build();
/// Trigger trigger = TriggerBuilder.Create()
///     .WithIdentity(triggerKey("myTrigger", "myTriggerGroup"))
///     .WithSimpleSchedule(x =&gt; x
///         .WithIntervalInHours(1)
///         .RepeatForever())
///     .StartAt(DateBuilder.FutureDate(10, IntervalUnit.Minute))
///     .Build();
/// scheduler.scheduleJob(job, trigger);
/// </code>
/// </remarks>
/// <seealso cref="T:Quartz.ISimpleTrigger" />
/// <seealso cref="T:Quartz.CalendarIntervalScheduleBuilder" />
/// <seealso cref="T:Quartz.CronScheduleBuilder" />
/// <seealso cref="T:Quartz.IScheduleBuilder" />
/// <seealso cref="T:Quartz.TriggerBuilder" />
public class SimpleScheduleBuilder : ScheduleBuilder<ISimpleTrigger>
{
	private TimeSpan interval = TimeSpan.Zero;

	private int repeatCount;

	private int misfireInstruction;

	protected SimpleScheduleBuilder()
	{
	}

	/// <summary>
	/// Create a SimpleScheduleBuilder.
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <returns>the new SimpleScheduleBuilder</returns>
	public static SimpleScheduleBuilder Create()
	{
		return new SimpleScheduleBuilder();
	}

	/// <summary>
	/// Create a SimpleScheduleBuilder set to repeat forever with a 1 minute interval.
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <returns>the new SimpleScheduleBuilder</returns>
	public static SimpleScheduleBuilder RepeatMinutelyForever()
	{
		return Create().WithInterval(TimeSpan.FromMinutes(1.0)).RepeatForever();
	}

	/// <summary>
	/// Create a SimpleScheduleBuilder set to repeat forever with an interval
	/// of the given number of minutes.
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <returns>the new SimpleScheduleBuilder</returns>
	public static SimpleScheduleBuilder RepeatMinutelyForever(int minutes)
	{
		return Create().WithInterval(TimeSpan.FromMinutes(minutes)).RepeatForever();
	}

	/// <summary>
	/// Create a SimpleScheduleBuilder set to repeat forever with a 1 second interval.
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <returns>the new SimpleScheduleBuilder</returns>
	public static SimpleScheduleBuilder RepeatSecondlyForever()
	{
		return Create().WithInterval(TimeSpan.FromSeconds(1.0)).RepeatForever();
	}

	/// <summary>
	/// Create a SimpleScheduleBuilder set to repeat forever with an interval
	/// of the given number of seconds.
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <returns>the new SimpleScheduleBuilder</returns>
	public static SimpleScheduleBuilder RepeatSecondlyForever(int seconds)
	{
		return Create().WithInterval(TimeSpan.FromSeconds(seconds)).RepeatForever();
	}

	/// <summary>
	/// Create a SimpleScheduleBuilder set to repeat forever with a 1 hour interval.
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <returns>the new SimpleScheduleBuilder</returns>
	public static SimpleScheduleBuilder RepeatHourlyForever()
	{
		return Create().WithInterval(TimeSpan.FromHours(1.0)).RepeatForever();
	}

	/// <summary>
	/// Create a SimpleScheduleBuilder set to repeat forever with an interval
	/// of the given number of hours.
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <returns>the new SimpleScheduleBuilder</returns>
	public static SimpleScheduleBuilder RepeatHourlyForever(int hours)
	{
		return Create().WithInterval(TimeSpan.FromHours(hours)).RepeatForever();
	}

	/// <summary>
	/// Create a SimpleScheduleBuilder set to repeat the given number
	/// of times - 1  with a 1 minute interval.
	/// </summary>
	/// <remarks>
	/// <para>Note: Total count = 1 (at start time) + repeat count</para>
	/// </remarks>
	/// <returns>the new SimpleScheduleBuilder</returns>
	public static SimpleScheduleBuilder RepeatMinutelyForTotalCount(int count)
	{
		if (count < 1)
		{
			throw new ArgumentException("Total count of firings must be at least one! Given count: " + count);
		}
		return Create().WithInterval(TimeSpan.FromMinutes(1.0)).WithRepeatCount(count - 1);
	}

	/// <summary>
	/// Create a SimpleScheduleBuilder set to repeat the given number
	/// of times - 1  with an interval of the given number of minutes.
	/// </summary>
	/// <remarks>
	/// <para>Note: Total count = 1 (at start time) + repeat count</para>
	/// </remarks>
	/// <returns>the new SimpleScheduleBuilder</returns>
	public static SimpleScheduleBuilder RepeatMinutelyForTotalCount(int count, int minutes)
	{
		if (count < 1)
		{
			throw new ArgumentException("Total count of firings must be at least one! Given count: " + count);
		}
		return Create().WithInterval(TimeSpan.FromMinutes(minutes)).WithRepeatCount(count - 1);
	}

	/// <summary>
	/// Create a SimpleScheduleBuilder set to repeat the given number
	/// of times - 1  with a 1 second interval.
	/// </summary>
	/// <remarks>
	/// <para>Note: Total count = 1 (at start time) + repeat count</para>
	/// </remarks>
	/// <returns>the new SimpleScheduleBuilder</returns>
	public static SimpleScheduleBuilder RepeatSecondlyForTotalCount(int count)
	{
		if (count < 1)
		{
			throw new ArgumentException("Total count of firings must be at least one! Given count: " + count);
		}
		return Create().WithInterval(TimeSpan.FromSeconds(1.0)).WithRepeatCount(count - 1);
	}

	/// <summary>
	/// Create a SimpleScheduleBuilder set to repeat the given number
	/// of times - 1  with an interval of the given number of seconds.
	/// </summary>
	/// <remarks>
	/// <para>Note: Total count = 1 (at start time) + repeat count</para>
	/// </remarks>
	/// <returns>the new SimpleScheduleBuilder</returns>
	public static SimpleScheduleBuilder RepeatSecondlyForTotalCount(int count, int seconds)
	{
		if (count < 1)
		{
			throw new ArgumentException("Total count of firings must be at least one! Given count: " + count);
		}
		return Create().WithInterval(TimeSpan.FromSeconds(seconds)).WithRepeatCount(count - 1);
	}

	/// <summary>
	/// Create a SimpleScheduleBuilder set to repeat the given number
	/// of times - 1  with a 1 hour interval.
	/// </summary>
	/// <remarks>
	/// <para>Note: Total count = 1 (at start time) + repeat count</para>
	/// </remarks>
	/// <returns>the new SimpleScheduleBuilder</returns>
	public static SimpleScheduleBuilder RepeatHourlyForTotalCount(int count)
	{
		if (count < 1)
		{
			throw new ArgumentException("Total count of firings must be at least one! Given count: " + count);
		}
		return Create().WithInterval(TimeSpan.FromHours(1.0)).WithRepeatCount(count - 1);
	}

	/// <summary>
	/// Create a SimpleScheduleBuilder set to repeat the given number
	/// of times - 1  with an interval of the given number of hours.
	/// </summary>
	/// <remarks>
	/// <para>Note: Total count = 1 (at start time) + repeat count</para>
	/// </remarks>
	/// <returns>the new SimpleScheduleBuilder</returns>
	public static SimpleScheduleBuilder RepeatHourlyForTotalCount(int count, int hours)
	{
		if (count < 1)
		{
			throw new ArgumentException("Total count of firings must be at least one! Given count: " + count);
		}
		return Create().WithInterval(TimeSpan.FromHours(hours)).WithRepeatCount(count - 1);
	}

	/// <summary>
	/// Build the actual Trigger -- NOT intended to be invoked by end users,
	/// but will rather be invoked by a TriggerBuilder which this
	/// ScheduleBuilder is given to.
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <seealso cref="M:Quartz.TriggerBuilder.WithSchedule(Quartz.IScheduleBuilder)" />
	public override IMutableTrigger Build()
	{
		SimpleTriggerImpl st = new SimpleTriggerImpl();
		st.RepeatInterval = interval;
		st.RepeatCount = repeatCount;
		st.MisfireInstruction = misfireInstruction;
		return st;
	}

	/// <summary>
	/// Specify a repeat interval in milliseconds.
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <param name="timeSpan">the time span at which the trigger should repeat.</param>
	/// <returns>the updated SimpleScheduleBuilder</returns>
	/// <seealso cref="P:Quartz.ISimpleTrigger.RepeatInterval" />
	/// <seealso cref="M:Quartz.SimpleScheduleBuilder.WithRepeatCount(System.Int32)" />
	public SimpleScheduleBuilder WithInterval(TimeSpan timeSpan)
	{
		interval = timeSpan;
		return this;
	}

	/// <summary>
	/// Specify a repeat interval in seconds.
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <param name="seconds">the time span at which the trigger should repeat.</param>
	/// <returns>the updated SimpleScheduleBuilder</returns>
	/// <seealso cref="P:Quartz.ISimpleTrigger.RepeatInterval" />
	/// <seealso cref="M:Quartz.SimpleScheduleBuilder.WithRepeatCount(System.Int32)" />
	public SimpleScheduleBuilder WithIntervalInSeconds(int seconds)
	{
		return WithInterval(TimeSpan.FromSeconds(seconds));
	}

	/// <summary>
	/// Specify a the number of time the trigger will repeat - total number of
	/// firings will be this number + 1.
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <param name="repeatCount">the number of seconds at which the trigger should repeat.</param>
	/// <returns>the updated SimpleScheduleBuilder</returns>
	/// <seealso cref="P:Quartz.ISimpleTrigger.RepeatCount" />
	/// <seealso cref="M:Quartz.SimpleScheduleBuilder.RepeatForever" />
	public SimpleScheduleBuilder WithRepeatCount(int repeatCount)
	{
		this.repeatCount = repeatCount;
		return this;
	}

	/// <summary>
	/// Specify that the trigger will repeat indefinitely.
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <returns>the updated SimpleScheduleBuilder</returns>
	/// <seealso cref="P:Quartz.ISimpleTrigger.RepeatCount" />
	/// <seealso cref="F:Quartz.Impl.Triggers.SimpleTriggerImpl.RepeatIndefinitely" />
	/// <seealso cref="M:Quartz.SimpleScheduleBuilder.WithInterval(System.TimeSpan)" />
	public SimpleScheduleBuilder RepeatForever()
	{
		repeatCount = -1;
		return this;
	}

	/// <summary>
	/// If the Trigger misfires, use the
	/// <see cref="F:Quartz.MisfireInstruction.IgnoreMisfirePolicy" /> instruction.
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <returns>the updated CronScheduleBuilder</returns>
	///  <seealso cref="F:Quartz.MisfireInstruction.IgnoreMisfirePolicy" />
	public SimpleScheduleBuilder WithMisfireHandlingInstructionIgnoreMisfires()
	{
		misfireInstruction = -1;
		return this;
	}

	/// <summary>
	/// If the Trigger misfires, use the
	/// <see cref="F:Quartz.MisfireInstruction.SimpleTrigger.FireNow" /> instruction.
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <returns>the updated SimpleScheduleBuilder</returns>
	/// <seealso cref="F:Quartz.MisfireInstruction.SimpleTrigger.FireNow" />
	public SimpleScheduleBuilder WithMisfireHandlingInstructionFireNow()
	{
		misfireInstruction = 1;
		return this;
	}

	/// <summary>
	/// If the Trigger misfires, use the
	/// <see cref="F:Quartz.MisfireInstruction.SimpleTrigger.RescheduleNextWithExistingCount" /> instruction.
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <returns>the updated SimpleScheduleBuilder</returns>
	/// <seealso cref="F:Quartz.MisfireInstruction.SimpleTrigger.RescheduleNextWithExistingCount" />
	public SimpleScheduleBuilder WithMisfireHandlingInstructionNextWithExistingCount()
	{
		misfireInstruction = 5;
		return this;
	}

	/// <summary>
	/// If the Trigger misfires, use the
	/// <see cref="F:Quartz.MisfireInstruction.SimpleTrigger.RescheduleNextWithRemainingCount" /> instruction.
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <returns>the updated SimpleScheduleBuilder</returns>
	/// <seealso cref="F:Quartz.MisfireInstruction.SimpleTrigger.RescheduleNextWithRemainingCount" />
	public SimpleScheduleBuilder WithMisfireHandlingInstructionNextWithRemainingCount()
	{
		misfireInstruction = 4;
		return this;
	}

	/// <summary>
	/// If the Trigger misfires, use the
	/// <see cref="F:Quartz.MisfireInstruction.SimpleTrigger.RescheduleNowWithExistingRepeatCount" /> instruction.
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <returns>the updated SimpleScheduleBuilder</returns>
	/// <seealso cref="F:Quartz.MisfireInstruction.SimpleTrigger.RescheduleNowWithExistingRepeatCount" />
	public SimpleScheduleBuilder WithMisfireHandlingInstructionNowWithExistingCount()
	{
		misfireInstruction = 2;
		return this;
	}

	/// <summary>
	/// If the Trigger misfires, use the
	/// <see cref="F:Quartz.MisfireInstruction.SimpleTrigger.RescheduleNowWithRemainingRepeatCount" /> instruction.
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <returns>the updated SimpleScheduleBuilder</returns>
	/// <seealso cref="F:Quartz.MisfireInstruction.SimpleTrigger.RescheduleNowWithRemainingRepeatCount" />
	public SimpleScheduleBuilder WithMisfireHandlingInstructionNowWithRemainingCount()
	{
		misfireInstruction = 3;
		return this;
	}

	internal SimpleScheduleBuilder WithMisfireHandlingInstruction(int readMisfireInstructionFromString)
	{
		misfireInstruction = readMisfireInstructionFromString;
		return this;
	}

	public SimpleScheduleBuilder WithIntervalInMinutes(int minutes)
	{
		return WithInterval(TimeSpan.FromMinutes(minutes));
	}

	public SimpleScheduleBuilder WithIntervalInHours(int hours)
	{
		return WithInterval(TimeSpan.FromHours(hours));
	}
}
