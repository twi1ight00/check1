using System;

namespace Quartz.Impl.Triggers;

/// <summary> 
/// A concrete <see cref="T:Quartz.ITrigger" /> that is used to fire a <see cref="T:Quartz.IJobDetail" />
/// at a given moment in time, and optionally repeated at a specified interval.
/// </summary>
/// <seealso cref="T:Quartz.ITrigger" />
/// <seealso cref="T:Quartz.ICronTrigger" />
/// <author>James House</author>
/// <author>Contributions by Lieven Govaerts of Ebitec Nv, Belgium.</author>
/// <author>Marko Lahma (.NET)</author>
[Serializable]
public class SimpleTriggerImpl : AbstractTrigger, ISimpleTrigger, ITrigger, ICloneable, IComparable<ITrigger>
{
	/// <summary>
	/// Used to indicate the 'repeat count' of the trigger is indefinite. Or in
	/// other words, the trigger should repeat continually until the trigger's
	/// ending timestamp.
	/// </summary>
	public const int RepeatIndefinitely = -1;

	private const int YearToGiveupSchedulingAt = 2299;

	private DateTimeOffset? nextFireTimeUtc;

	private DateTimeOffset? previousFireTimeUtc;

	private int repeatCount;

	private TimeSpan repeatInterval = TimeSpan.Zero;

	private int timesTriggered;

	private bool complete;

	/// <summary>
	/// Get or set thhe number of times the <see cref="T:Quartz.Impl.Triggers.SimpleTriggerImpl" /> should
	/// repeat, after which it will be automatically deleted.
	/// </summary>
	/// <seealso cref="F:Quartz.Impl.Triggers.SimpleTriggerImpl.RepeatIndefinitely" />
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
	/// Get or set the the time interval at which the <see cref="T:Quartz.ISimpleTrigger" /> should repeat.
	/// </summary>
	public TimeSpan RepeatInterval
	{
		get
		{
			return repeatInterval;
		}
		set
		{
			if (value < TimeSpan.Zero)
			{
				throw new ArgumentException("Repeat interval must be >= 0");
			}
			repeatInterval = value;
		}
	}

	/// <summary>
	/// Get or set the number of times the <see cref="T:Quartz.ISimpleTrigger" /> has already
	/// fired.
	/// </summary>
	public virtual int TimesTriggered
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
	/// Returns the final UTC time at which the <see cref="T:Quartz.ISimpleTrigger" /> will
	/// fire, if repeatCount is RepeatIndefinitely, null will be returned.
	/// <para>
	/// Note that the return time may be in the past.
	/// </para>
	/// </summary>
	public override DateTimeOffset? FinalFireTimeUtc
	{
		get
		{
			if (repeatCount == 0)
			{
				return StartTimeUtc;
			}
			if (repeatCount == -1 && !EndTimeUtc.HasValue)
			{
				return null;
			}
			if (repeatCount == -1 && !EndTimeUtc.HasValue)
			{
				return null;
			}
			if (repeatCount == -1)
			{
				return GetFireTimeBefore(EndTimeUtc);
			}
			DateTimeOffset lastTrigger = StartTimeUtc.AddMilliseconds((double)repeatCount * repeatInterval.TotalMilliseconds);
			if (!EndTimeUtc.HasValue || lastTrigger < EndTimeUtc.Value)
			{
				return lastTrigger;
			}
			return GetFireTimeBefore(EndTimeUtc);
		}
	}

	/// <summary>
	/// Tells whether this Trigger instance can handle events
	/// in millisecond precision.
	/// </summary>
	/// <value></value>
	public override bool HasMillisecondPrecision => true;

	/// <summary>
	/// Create a <see cref="T:Quartz.Impl.Triggers.SimpleTriggerImpl" /> with no settings.
	/// </summary>
	public SimpleTriggerImpl()
	{
	}

	/// <summary>
	/// Create a <see cref="T:Quartz.Impl.Triggers.SimpleTriggerImpl" /> that will occur immediately, and
	/// not repeat.
	/// </summary>
	public SimpleTriggerImpl(string name)
		: this(name, null)
	{
	}

	/// <summary>
	/// Create a <see cref="T:Quartz.Impl.Triggers.SimpleTriggerImpl" /> that will occur immediately, and
	/// not repeat.
	/// </summary>
	public SimpleTriggerImpl(string name, string group)
		: this(name, group, SystemTime.UtcNow(), null, 0, TimeSpan.Zero)
	{
	}

	/// <summary>
	/// Create a <see cref="T:Quartz.Impl.Triggers.SimpleTriggerImpl" /> that will occur immediately, and
	/// repeat at the the given interval the given number of times.
	/// </summary>
	public SimpleTriggerImpl(string name, int repeatCount, TimeSpan repeatInterval)
		: this(name, null, repeatCount, repeatInterval)
	{
	}

	/// <summary>
	/// Create a <see cref="T:Quartz.Impl.Triggers.SimpleTriggerImpl" /> that will occur immediately, and
	/// repeat at the the given interval the given number of times.
	/// </summary>
	public SimpleTriggerImpl(string name, string group, int repeatCount, TimeSpan repeatInterval)
		: this(name, group, SystemTime.UtcNow(), null, repeatCount, repeatInterval)
	{
	}

	/// <summary>
	/// Create a <see cref="T:Quartz.Impl.Triggers.SimpleTriggerImpl" /> that will occur at the given time,
	/// and not repeat.
	/// </summary>
	public SimpleTriggerImpl(string name, DateTimeOffset startTimeUtc)
		: this(name, null, startTimeUtc)
	{
	}

	/// <summary>
	/// Create a <see cref="T:Quartz.Impl.Triggers.SimpleTriggerImpl" /> that will occur at the given time,
	/// and not repeat.
	/// </summary>
	public SimpleTriggerImpl(string name, string group, DateTimeOffset startTimeUtc)
		: this(name, group, startTimeUtc, null, 0, TimeSpan.Zero)
	{
	}

	/// <summary>
	/// Create a <see cref="T:Quartz.Impl.Triggers.SimpleTriggerImpl" /> that will occur at the given time,
	/// and repeat at the the given interval the given number of times, or until
	/// the given end time.
	/// </summary>
	/// <param name="name">The name.</param>
	/// <param name="startTimeUtc">A UTC <see cref="T:System.DateTimeOffset" /> set to the time for the <see cref="T:Quartz.ITrigger" /> to fire.</param>
	/// <param name="endTimeUtc">A UTC <see cref="T:System.DateTimeOffset" /> set to the time for the <see cref="T:Quartz.ITrigger" />
	/// to quit repeat firing.</param>
	/// <param name="repeatCount">The number of times for the <see cref="T:Quartz.ITrigger" /> to repeat
	/// firing, use <see cref="F:Quartz.Impl.Triggers.SimpleTriggerImpl.RepeatIndefinitely" /> for unlimited times.</param>
	/// <param name="repeatInterval">The time span to pause between the repeat firing.</param>
	public SimpleTriggerImpl(string name, DateTimeOffset startTimeUtc, DateTimeOffset? endTimeUtc, int repeatCount, TimeSpan repeatInterval)
		: this(name, null, startTimeUtc, endTimeUtc, repeatCount, repeatInterval)
	{
	}

	/// <summary>
	/// Create a <see cref="T:Quartz.Impl.Triggers.SimpleTriggerImpl" /> that will occur at the given time,
	/// and repeat at the the given interval the given number of times, or until
	/// the given end time.
	/// </summary>
	/// <param name="name">The name.</param>
	/// <param name="group">The group.</param>
	/// <param name="startTimeUtc">A UTC <see cref="T:System.DateTimeOffset" /> set to the time for the <see cref="T:Quartz.ITrigger" /> to fire.</param>
	/// <param name="endTimeUtc">A UTC <see cref="T:System.DateTimeOffset" /> set to the time for the <see cref="T:Quartz.ITrigger" />
	/// to quit repeat firing.</param>
	/// <param name="repeatCount">The number of times for the <see cref="T:Quartz.ITrigger" /> to repeat
	/// firing, use <see cref="F:Quartz.Impl.Triggers.SimpleTriggerImpl.RepeatIndefinitely" /> for unlimited times.</param>
	/// <param name="repeatInterval">The time span to pause between the repeat firing.</param>
	public SimpleTriggerImpl(string name, string group, DateTimeOffset startTimeUtc, DateTimeOffset? endTimeUtc, int repeatCount, TimeSpan repeatInterval)
		: base(name, group)
	{
		StartTimeUtc = startTimeUtc;
		EndTimeUtc = endTimeUtc;
		RepeatCount = repeatCount;
		RepeatInterval = repeatInterval;
	}

	/// <summary>
	/// Create a <see cref="T:Quartz.Impl.Triggers.SimpleTriggerImpl" /> that will occur at the given time,
	/// fire the identified <see cref="T:Quartz.IJob" /> and repeat at the the given
	/// interval the given number of times, or until the given end time.
	/// </summary>
	/// <param name="name">The name.</param>
	/// <param name="group">The group.</param>
	/// <param name="jobName">Name of the job.</param>
	/// <param name="jobGroup">The job group.</param>
	/// <param name="startTimeUtc">A <see cref="T:System.DateTimeOffset" /> set to the time for the <see cref="T:Quartz.ITrigger" />
	/// to fire.</param>
	/// <param name="endTimeUtc">A <see cref="T:System.DateTimeOffset" /> set to the time for the <see cref="T:Quartz.ITrigger" />
	/// to quit repeat firing.</param>
	/// <param name="repeatCount">The number of times for the <see cref="T:Quartz.ITrigger" /> to repeat
	/// firing, use RepeatIndefinitely for unlimited times.</param>
	/// <param name="repeatInterval">The time span to pause between the repeat firing.</param>
	public SimpleTriggerImpl(string name, string group, string jobName, string jobGroup, DateTimeOffset startTimeUtc, DateTimeOffset? endTimeUtc, int repeatCount, TimeSpan repeatInterval)
		: base(name, group, jobName, jobGroup)
	{
		StartTimeUtc = startTimeUtc;
		EndTimeUtc = endTimeUtc;
		RepeatCount = repeatCount;
		RepeatInterval = repeatInterval;
	}

	public TriggerBuilder GetTriggerBuilder()
	{
		return GetTriggerBuilder<ISimpleTrigger>();
	}

	public override IScheduleBuilder GetScheduleBuilder()
	{
		SimpleScheduleBuilder sb = SimpleScheduleBuilder.Create().WithInterval(RepeatInterval).WithRepeatCount(RepeatCount);
		switch (MisfireInstruction)
		{
		case 1:
			sb.WithMisfireHandlingInstructionFireNow();
			break;
		case 5:
			sb.WithMisfireHandlingInstructionNextWithExistingCount();
			break;
		case 4:
			sb.WithMisfireHandlingInstructionNextWithRemainingCount();
			break;
		case 2:
			sb.WithMisfireHandlingInstructionNowWithExistingCount();
			break;
		case 3:
			sb.WithMisfireHandlingInstructionNowWithRemainingCount();
			break;
		}
		return sb;
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
		if (misfireInstruction > 5)
		{
			return false;
		}
		return true;
	}

	/// <summary>
	/// Updates the <see cref="T:Quartz.ISimpleTrigger" />'s state based on the
	/// MisfireInstruction value that was selected when the <see cref="T:Quartz.ISimpleTrigger" />
	/// was created.
	/// </summary>
	/// <remarks>
	/// If MisfireSmartPolicyEnabled is set to true,
	/// then the following scheme will be used: <br />
	/// <ul>
	/// <li>If the Repeat Count is 0, then the instruction will
	/// be interpreted as <see cref="F:Quartz.MisfireInstruction.SimpleTrigger.FireNow" />.</li>
	/// <li>If the Repeat Count is <see cref="F:Quartz.Impl.Triggers.SimpleTriggerImpl.RepeatIndefinitely" />, then
	/// the instruction will be interpreted as <see cref="F:Quartz.MisfireInstruction.SimpleTrigger.RescheduleNowWithRemainingRepeatCount" />.
	/// <b>WARNING:</b> using MisfirePolicy.SimpleTrigger.RescheduleNowWithRemainingRepeatCount 
	/// with a trigger that has a non-null end-time may cause the trigger to 
	/// never fire again if the end-time arrived during the misfire time span. 
	/// </li>
	/// <li>If the Repeat Count is &gt; 0, then the instruction
	/// will be interpreted as <see cref="F:Quartz.MisfireInstruction.SimpleTrigger.RescheduleNowWithExistingRepeatCount" />.
	/// </li>
	/// </ul>
	/// </remarks>
	public override void UpdateAfterMisfire(ICalendar cal)
	{
		int instr = MisfireInstruction;
		switch (instr)
		{
		case 0:
			instr = ((RepeatCount == 0) ? 1 : ((RepeatCount != -1) ? 2 : 4));
			break;
		case 1:
			if (RepeatCount != 0)
			{
				instr = 3;
			}
			break;
		}
		switch (instr)
		{
		case 1:
			nextFireTimeUtc = SystemTime.UtcNow();
			break;
		case 5:
		{
			DateTimeOffset? newFireTime = GetFireTimeAfter(SystemTime.UtcNow());
			while (newFireTime.HasValue && cal != null && !cal.IsTimeIncluded(newFireTime.Value))
			{
				newFireTime = GetFireTimeAfter(newFireTime);
				if (!newFireTime.HasValue)
				{
					break;
				}
				if (newFireTime.Value.Year > 2299)
				{
					newFireTime = null;
				}
			}
			nextFireTimeUtc = newFireTime;
			break;
		}
		case 4:
		{
			DateTimeOffset? newFireTime3 = GetFireTimeAfter(SystemTime.UtcNow());
			while (newFireTime3.HasValue && cal != null && !cal.IsTimeIncluded(newFireTime3.Value))
			{
				newFireTime3 = GetFireTimeAfter(newFireTime3);
				if (!newFireTime3.HasValue)
				{
					break;
				}
				if (newFireTime3.Value.Year > 2299)
				{
					newFireTime3 = null;
				}
			}
			if (newFireTime3.HasValue)
			{
				int timesMissed2 = ComputeNumTimesFiredBetween(nextFireTimeUtc, newFireTime3);
				TimesTriggered += timesMissed2;
			}
			nextFireTimeUtc = newFireTime3;
			break;
		}
		case 2:
		{
			DateTimeOffset newFireTime4 = SystemTime.UtcNow();
			if (repeatCount != 0 && repeatCount != -1)
			{
				RepeatCount -= TimesTriggered;
				TimesTriggered = 0;
			}
			if (EndTimeUtc.HasValue && EndTimeUtc.Value < newFireTime4)
			{
				nextFireTimeUtc = null;
				break;
			}
			StartTimeUtc = newFireTime4;
			nextFireTimeUtc = newFireTime4;
			break;
		}
		case 3:
		{
			DateTimeOffset newFireTime2 = SystemTime.UtcNow();
			int timesMissed = ComputeNumTimesFiredBetween(nextFireTimeUtc, newFireTime2);
			if (repeatCount != 0 && repeatCount != -1)
			{
				int remainingCount = RepeatCount - (TimesTriggered + timesMissed);
				if (remainingCount <= 0)
				{
					remainingCount = 0;
				}
				RepeatCount = remainingCount;
				TimesTriggered = 0;
			}
			if (EndTimeUtc.HasValue && EndTimeUtc.Value < newFireTime2)
			{
				nextFireTimeUtc = null;
				break;
			}
			StartTimeUtc = newFireTime2;
			nextFireTimeUtc = newFireTime2;
			break;
		}
		}
	}

	/// <summary>
	/// Called when the <see cref="T:Quartz.IScheduler" /> has decided to 'fire'
	/// the trigger (Execute the associated <see cref="T:Quartz.IJob" />), in order to
	/// give the <see cref="T:Quartz.ITrigger" /> a chance to update itself for its next
	/// triggering (if any).
	/// </summary>
	/// <seealso cref="T:Quartz.JobExecutionException" />
	public override void Triggered(ICalendar cal)
	{
		timesTriggered++;
		previousFireTimeUtc = nextFireTimeUtc;
		nextFireTimeUtc = GetFireTimeAfter(nextFireTimeUtc);
		while (nextFireTimeUtc.HasValue && cal != null && !cal.IsTimeIncluded(nextFireTimeUtc.Value))
		{
			nextFireTimeUtc = GetFireTimeAfter(nextFireTimeUtc);
			if (!nextFireTimeUtc.HasValue)
			{
				break;
			}
			if (nextFireTimeUtc.Value.Year > 2299)
			{
				nextFireTimeUtc = null;
			}
		}
	}

	/// <summary>
	/// Updates the instance with new calendar.
	/// </summary>
	/// <param name="calendar">The calendar.</param>
	/// <param name="misfireThreshold">The misfire threshold.</param>
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
			if (nextFireTimeUtc.Value.Year > 2299)
			{
				nextFireTimeUtc = null;
			}
			if (nextFireTimeUtc.HasValue && nextFireTimeUtc.Value < now)
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
	/// Called by the scheduler at the time a <see cref="T:Quartz.ITrigger" /> is first
	/// added to the scheduler, in order to have the <see cref="T:Quartz.ITrigger" />
	/// compute its first fire time, based on any associated calendar.
	/// <para>
	/// After this method has been called, <see cref="M:Quartz.Impl.Triggers.SimpleTriggerImpl.GetNextFireTimeUtc" />
	/// should return a valid answer.
	/// </para>
	/// </summary>
	/// <returns> 
	/// The first time at which the <see cref="T:Quartz.ITrigger" /> will be fired
	/// by the scheduler, which is also the same value <see cref="M:Quartz.Impl.Triggers.SimpleTriggerImpl.GetNextFireTimeUtc" />
	/// will return (until after the first firing of the <see cref="T:Quartz.ITrigger" />).
	/// </returns>
	public override DateTimeOffset? ComputeFirstFireTimeUtc(ICalendar cal)
	{
		nextFireTimeUtc = StartTimeUtc;
		while (cal != null && !cal.IsTimeIncluded(nextFireTimeUtc.Value))
		{
			nextFireTimeUtc = GetFireTimeAfter(nextFireTimeUtc);
			if (!nextFireTimeUtc.HasValue)
			{
				break;
			}
			if (nextFireTimeUtc.Value.Year > 2299)
			{
				return null;
			}
		}
		return nextFireTimeUtc;
	}

	/// <summary>
	/// Returns the next time at which the <see cref="T:Quartz.ISimpleTrigger" /> will
	/// fire. If the trigger will not fire again, <see langword="null" /> will be
	/// returned. The value returned is not guaranteed to be valid until after
	/// the <see cref="T:Quartz.ITrigger" /> has been added to the scheduler.
	/// </summary>
	public override DateTimeOffset? GetNextFireTimeUtc()
	{
		return nextFireTimeUtc;
	}

	public override void SetNextFireTimeUtc(DateTimeOffset? nextFireTime)
	{
		nextFireTimeUtc = nextFireTime;
	}

	public override void SetPreviousFireTimeUtc(DateTimeOffset? previousFireTime)
	{
		previousFireTimeUtc = previousFireTime;
	}

	/// <summary>
	/// Returns the previous time at which the <see cref="T:Quartz.ISimpleTrigger" /> fired.
	/// If the trigger has not yet fired, <see langword="null" /> will be
	/// returned.
	/// </summary>
	public override DateTimeOffset? GetPreviousFireTimeUtc()
	{
		return previousFireTimeUtc;
	}

	/// <summary> 
	/// Returns the next UTC time at which the <see cref="T:Quartz.ISimpleTrigger" /> will
	/// fire, after the given UTC time. If the trigger will not fire after the given
	/// time, <see langword="null" /> will be returned.
	/// </summary>
	public override DateTimeOffset? GetFireTimeAfter(DateTimeOffset? afterTimeUtc)
	{
		if (complete)
		{
			return null;
		}
		if (timesTriggered > repeatCount && repeatCount != -1)
		{
			return null;
		}
		if (!afterTimeUtc.HasValue)
		{
			afterTimeUtc = SystemTime.UtcNow();
		}
		if (repeatCount == 0 && afterTimeUtc.Value.CompareTo(StartTimeUtc) >= 0)
		{
			return null;
		}
		DateTimeOffset startMillis = StartTimeUtc;
		DateTimeOffset afterMillis = afterTimeUtc.Value;
		DateTimeOffset endMillis = ((!EndTimeUtc.HasValue) ? DateTimeOffset.MaxValue : EndTimeUtc.Value);
		if (endMillis <= afterMillis)
		{
			return null;
		}
		if (afterMillis < startMillis)
		{
			return startMillis;
		}
		long numberOfTimesExecuted = (long)((double)(long)(afterMillis - startMillis).TotalMilliseconds / repeatInterval.TotalMilliseconds + 1.0);
		if (numberOfTimesExecuted > repeatCount && repeatCount != -1)
		{
			return null;
		}
		DateTimeOffset time = startMillis.AddMilliseconds((double)numberOfTimesExecuted * repeatInterval.TotalMilliseconds);
		if (endMillis <= time)
		{
			return null;
		}
		return time;
	}

	/// <summary>
	/// Returns the last UTC time at which the <see cref="T:Quartz.ISimpleTrigger" /> will
	/// fire, before the given time. If the trigger will not fire before the
	/// given time, <see langword="null" /> will be returned.
	/// </summary>
	public virtual DateTimeOffset? GetFireTimeBefore(DateTimeOffset? endUtc)
	{
		if (endUtc.Value < StartTimeUtc)
		{
			return null;
		}
		int numFires = ComputeNumTimesFiredBetween(StartTimeUtc, endUtc);
		return StartTimeUtc.AddMilliseconds((double)numFires * repeatInterval.TotalMilliseconds);
	}

	/// <summary>
	/// Computes the number of times fired between the two UTC date times.
	/// </summary>
	/// <param name="startTimeUtc">The UTC start date and time.</param>
	/// <param name="endTimeUtc">The UTC end date and time.</param>
	/// <returns></returns>
	public virtual int ComputeNumTimesFiredBetween(DateTimeOffset? startTimeUtc, DateTimeOffset? endTimeUtc)
	{
		long time = (long)(endTimeUtc.Value - startTimeUtc.Value).TotalMilliseconds;
		return (int)((double)time / repeatInterval.TotalMilliseconds);
	}

	/// <summary> 
	/// Determines whether or not the <see cref="T:Quartz.ISimpleTrigger" /> will occur
	/// again.
	/// </summary>
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
		if (repeatCount != 0 && repeatInterval.TotalMilliseconds < 1.0)
		{
			throw new SchedulerException("Repeat Interval cannot be zero.");
		}
	}
}
