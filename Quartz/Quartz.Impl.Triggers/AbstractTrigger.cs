using System;
using System.Globalization;
using Quartz.Spi;

namespace Quartz.Impl.Triggers;

/// <summary>
/// The base abstract class to be extended by all triggers.
/// </summary>
/// <remarks>
/// <para>
/// <see cref="T:Quartz.ITrigger" />s have a name and group associated with them, which
/// should uniquely identify them within a single <see cref="T:Quartz.IScheduler" />.
/// </para>
///
/// <para>
/// <see cref="T:Quartz.ITrigger" />s are the 'mechanism' by which <see cref="T:Quartz.IJob" /> s
/// are scheduled. Many <see cref="T:Quartz.ITrigger" /> s can point to the same <see cref="T:Quartz.IJob" />,
/// but a single <see cref="T:Quartz.ITrigger" /> can only point to one <see cref="T:Quartz.IJob" />.
/// </para>
///
/// <para>
/// Triggers can 'send' parameters/data to <see cref="T:Quartz.IJob" />s by placing contents
/// into the <see cref="P:Quartz.Impl.Triggers.AbstractTrigger.JobDataMap" /> on the <see cref="T:Quartz.ITrigger" />.
/// </para>
/// </remarks>
/// <seealso cref="T:Quartz.ISimpleTrigger" />
/// <seealso cref="T:Quartz.ICronTrigger" />
/// <seealso cref="T:Quartz.IDailyTimeIntervalTrigger" />
/// <seealso cref="P:Quartz.Impl.Triggers.AbstractTrigger.JobDataMap" />
/// <seealso cref="T:Quartz.IJobExecutionContext" />
/// <author>James House</author>
/// <author>Sharada Jambula</author>
/// <author>Marko Lahma (.NET)</author>
[Serializable]
public abstract class AbstractTrigger : IOperableTrigger, IMutableTrigger, ITrigger, ICloneable, IComparable<ITrigger>, IEquatable<AbstractTrigger>
{
	private string name;

	private string group = "DEFAULT";

	private string jobName;

	private string jobGroup = "DEFAULT";

	private string description;

	private JobDataMap jobDataMap;

	private string calendarName;

	private string fireInstanceId;

	private int misfireInstruction;

	private DateTimeOffset? endTimeUtc;

	private DateTimeOffset startTimeUtc;

	private int priority = 5;

	[NonSerialized]
	private TriggerKey key;

	/// <summary>
	/// Get or sets the name of this <see cref="T:Quartz.ITrigger" />.
	/// </summary>
	/// <exception cref="T:System.ArgumentException">If name is null or empty.</exception>
	public virtual string Name
	{
		get
		{
			return name;
		}
		set
		{
			if (value == null || value.Trim().Length == 0)
			{
				throw new ArgumentException("Trigger name cannot be null or empty.");
			}
			name = value;
			key = null;
		}
	}

	/// <summary>
	/// Get the group of this <see cref="T:Quartz.ITrigger" />. If <see langword="null" />, Scheduler.DefaultGroup will be used.
	/// </summary>
	/// <exception cref="T:System.ArgumentException"> 
	/// if group is an empty string.
	/// </exception>
	public virtual string Group
	{
		get
		{
			return group;
		}
		set
		{
			if (value != null && value.Trim().Length == 0)
			{
				throw new ArgumentException("Group name cannot be an empty string.");
			}
			if (value == null)
			{
				value = "DEFAULT";
			}
			group = value;
			key = null;
		}
	}

	/// <summary>
	/// Get or set the name of the associated <see cref="T:Quartz.IJobDetail" />.
	/// </summary> 
	/// <exception cref="T:System.ArgumentException"> 
	/// if jobName is null or empty.
	/// </exception>
	public virtual string JobName
	{
		get
		{
			return jobName;
		}
		set
		{
			if (value == null || value.Trim().Length == 0)
			{
				throw new ArgumentException("Job name cannot be null or empty.");
			}
			jobName = value;
		}
	}

	/// <summary>
	/// Gets or sets the name of the associated <see cref="T:Quartz.IJobDetail" />'s
	/// group. If set with <see langword="null" />, Scheduler.DefaultGroup will be used.
	/// </summary>
	/// <exception cref="T:System.ArgumentException"> ArgumentException
	/// if group is an empty string.
	/// </exception>
	public virtual string JobGroup
	{
		get
		{
			return jobGroup;
		}
		set
		{
			if (value != null && value.Trim().Length == 0)
			{
				throw new ArgumentException("Group name cannot be null or empty.");
			}
			if (value == null)
			{
				value = "DEFAULT";
			}
			jobGroup = value;
		}
	}

	/// <summary>
	/// Returns the 'full name' of the <see cref="T:Quartz.ITrigger" /> in the format
	/// "group.name".
	/// </summary>
	public virtual string FullName => group + "." + name;

	/// <summary>
	/// Gets the key.
	/// </summary>
	/// <value>The key.</value>
	public virtual TriggerKey Key
	{
		get
		{
			if (key == null)
			{
				key = new TriggerKey(Name, Group);
			}
			return key;
		}
		set
		{
			Name = value.Name;
			Group = value.Group;
			key = value;
		}
	}

	public JobKey JobKey
	{
		get
		{
			if (JobName == null)
			{
				return null;
			}
			return new JobKey(JobName, JobGroup);
		}
		set
		{
			JobName = value.Name;
			JobGroup = value.Group;
		}
	}

	/// <summary>
	/// Returns the 'full name' of the <see cref="T:Quartz.IJob" /> that the <see cref="T:Quartz.ITrigger" />
	/// points to, in the format "group.name".
	/// </summary>
	public virtual string FullJobName => jobGroup + "." + jobName;

	/// <summary>
	/// Get or set the description given to the <see cref="T:Quartz.ITrigger" /> instance by
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
	/// Get or set  the <see cref="T:Quartz.ICalendar" /> with the given name with
	/// this Trigger. Use <see langword="null" /> when setting to dis-associate a Calendar.
	/// </summary>
	public virtual string CalendarName
	{
		get
		{
			return calendarName;
		}
		set
		{
			calendarName = value;
		}
	}

	/// <summary>
	/// Get or set the <see cref="P:Quartz.Impl.Triggers.AbstractTrigger.JobDataMap" /> that is associated with the 
	/// <see cref="T:Quartz.ITrigger" />.
	/// <para>
	/// Changes made to this map during job execution are not re-persisted, and
	/// in fact typically result in an illegal state.
	/// </para>
	/// </summary>
	public virtual JobDataMap JobDataMap
	{
		get
		{
			if (jobDataMap == null)
			{
				jobDataMap = new JobDataMap();
			}
			return jobDataMap;
		}
		set
		{
			jobDataMap = value;
		}
	}

	/// <summary>
	/// Returns the last UTC time at which the <see cref="T:Quartz.ITrigger" /> will fire, if
	/// the Trigger will repeat indefinitely, null will be returned.
	/// <para>
	/// Note that the return time *may* be in the past.
	/// </para>
	/// </summary>
	public abstract DateTimeOffset? FinalFireTimeUtc { get; }

	/// <summary>
	/// Get or set the instruction the <see cref="T:Quartz.IScheduler" /> should be given for
	/// handling misfire situations for this <see cref="T:Quartz.ITrigger" />- the
	/// concrete <see cref="T:Quartz.ITrigger" /> type that you are using will have
	/// defined a set of additional MISFIRE_INSTRUCTION_XXX
	/// constants that may be passed to this method.
	/// <para>
	/// If not explicitly set, the default value is <see cref="F:Quartz.MisfireInstruction.InstructionNotSet" />.
	/// </para>
	/// </summary>
	/// <seealso cref="F:Quartz.MisfireInstruction.InstructionNotSet" />
	/// <seealso cref="M:Quartz.Impl.Triggers.AbstractTrigger.UpdateAfterMisfire(Quartz.ICalendar)" />
	/// <seealso cref="T:Quartz.ISimpleTrigger" />
	/// <seealso cref="T:Quartz.ICronTrigger" />
	public virtual int MisfireInstruction
	{
		get
		{
			return misfireInstruction;
		}
		set
		{
			if (!ValidateMisfireInstruction(value))
			{
				throw new ArgumentException("The misfire instruction code is invalid for this type of trigger.");
			}
			misfireInstruction = value;
		}
	}

	/// <summary> 
	/// This method should not be used by the Quartz client.
	/// </summary>
	/// <remarks>
	/// Usable by <see cref="T:Quartz.Spi.IJobStore" />
	/// implementations, in order to facilitate 'recognizing' instances of fired
	/// <see cref="T:Quartz.ITrigger" /> s as their jobs complete execution.
	/// </remarks>
	public virtual string FireInstanceId
	{
		get
		{
			return fireInstanceId;
		}
		set
		{
			fireInstanceId = value;
		}
	}

	/// <summary>
	/// Gets and sets the date/time on which the trigger must stop firing. This 
	/// defines the final boundary for trigger firings 舒 the trigger will
	/// not fire after to this date and time. If this value is null, no end time
	/// boundary is assumed, and the trigger can continue indefinitely.
	/// </summary>
	public virtual DateTimeOffset? EndTimeUtc
	{
		get
		{
			return endTimeUtc;
		}
		set
		{
			DateTimeOffset sTime = StartTimeUtc;
			if (value.HasValue && sTime > value.Value)
			{
				throw new ArgumentException("End time cannot be before start time");
			}
			endTimeUtc = value;
		}
	}

	/// <summary>
	/// The time at which the trigger's scheduling should start.  May or may not
	/// be the first actual fire time of the trigger, depending upon the type of
	/// trigger and the settings of the other properties of the trigger.  However
	/// the first actual first time will not be before this date.
	/// </summary>
	/// <remarks>
	/// Setting a value in the past may cause a new trigger to compute a first
	/// fire time that is in the past, which may cause an immediate misfire
	/// of the trigger.
	/// </remarks>
	public virtual DateTimeOffset StartTimeUtc
	{
		get
		{
			return startTimeUtc;
		}
		set
		{
			if (EndTimeUtc.HasValue && EndTimeUtc.Value < value)
			{
				throw new ArgumentException("End time cannot be before start time");
			}
			if (!HasMillisecondPrecision)
			{
				startTimeUtc = new DateTime(value.Year, value.Month, value.Day, value.Hour, value.Minute, value.Second);
			}
			else
			{
				startTimeUtc = value;
			}
		}
	}

	/// <summary>
	/// Tells whether this Trigger instance can handle events
	/// in millisecond precision.
	/// </summary>
	public abstract bool HasMillisecondPrecision { get; }

	/// <summary>
	/// The priority of a <see cref="T:Quartz.ITrigger" /> acts as a tie breaker such that if 
	/// two <see cref="T:Quartz.ITrigger" />s have the same scheduled fire time, then Quartz
	/// will do its best to give the one with the higher priority first access 
	/// to a worker thread.
	/// </summary>
	/// <remarks>
	/// If not explicitly set, the default value is <i>5</i>.
	/// </remarks>
	/// <returns></returns>
	/// <see cref="F:Quartz.TriggerConstants.DefaultPriority" />
	public virtual int Priority
	{
		get
		{
			return priority;
		}
		set
		{
			priority = value;
		}
	}

	/// <summary>
	/// Gets a value indicating whether this instance has additional properties
	/// that should be considered when for example saving to database. 
	/// </summary>
	/// <remarks>
	/// If trigger implementation has additional properties that need to be saved 
	/// with base properties you need to make your class override this property with value true.
	/// Returning true will effectively mean that ADOJobStore needs to serialize 
	/// this trigger instance to make sure additional properties are also saved.
	/// </remarks>
	/// <value>
	/// 	<c>true</c> if this instance has additional properties; otherwise, <c>false</c>.
	/// </value>
	public virtual bool HasAdditionalProperties => false;

	public abstract IScheduleBuilder GetScheduleBuilder();

	public abstract void SetNextFireTimeUtc(DateTimeOffset? nextFireTime);

	public abstract void SetPreviousFireTimeUtc(DateTimeOffset? previousFireTime);

	/// <summary>
	/// Returns the previous time at which the <see cref="T:Quartz.ITrigger" /> fired.
	/// If the trigger has not yet fired, <see langword="null" /> will be returned.
	/// </summary>
	public abstract DateTimeOffset? GetPreviousFireTimeUtc();

	/// <summary>
	/// Create a <see cref="T:Quartz.ITrigger" /> with no specified name, group, or <see cref="T:Quartz.IJobDetail" />.
	/// </summary>
	/// <remarks>
	/// Note that the <see cref="P:Quartz.Impl.Triggers.AbstractTrigger.Name" />, <see cref="P:Quartz.Impl.Triggers.AbstractTrigger.Group" /> and
	/// the <see cref="P:Quartz.Impl.Triggers.AbstractTrigger.JobName" /> and <see cref="P:Quartz.Impl.Triggers.AbstractTrigger.JobGroup" /> properties
	/// must be set before the <see cref="T:Quartz.ITrigger" /> can be placed into a
	/// <see cref="T:Quartz.IScheduler" />.
	/// </remarks>
	protected AbstractTrigger()
	{
	}

	/// <summary>
	/// Create a <see cref="T:Quartz.ITrigger" /> with the given name, and default group.
	/// </summary>
	/// <remarks>
	/// Note that the <see cref="P:Quartz.Impl.Triggers.AbstractTrigger.JobName" /> and <see cref="P:Quartz.Impl.Triggers.AbstractTrigger.JobGroup" />
	/// properties must be set before the <see cref="T:Quartz.ITrigger" />
	/// can be placed into a <see cref="T:Quartz.IScheduler" />.
	/// </remarks>
	/// <param name="name">The name.</param>
	protected AbstractTrigger(string name)
		: this(name, null)
	{
	}

	/// <summary>
	/// Create a <see cref="T:Quartz.ITrigger" /> with the given name, and group.
	/// </summary>
	/// <remarks>
	/// Note that the <see cref="P:Quartz.Impl.Triggers.AbstractTrigger.JobName" /> and <see cref="P:Quartz.Impl.Triggers.AbstractTrigger.JobGroup" />
	/// properties must be set before the <see cref="T:Quartz.ITrigger" />
	/// can be placed into a <see cref="T:Quartz.IScheduler" />.
	/// </remarks>
	/// <param name="name">The name.</param>
	/// <param name="group">if <see langword="null" />, Scheduler.DefaultGroup will be used.</param>
	protected AbstractTrigger(string name, string group)
	{
		Name = name;
		Group = group;
	}

	/// <summary>
	/// Create a <see cref="T:Quartz.ITrigger" /> with the given name, and group.
	/// </summary>
	/// <param name="name">The name.</param>
	/// <param name="group">if <see langword="null" />, Scheduler.DefaultGroup will be used.</param>
	/// <param name="jobName">Name of the job.</param>
	/// <param name="jobGroup">The job group.</param>
	/// <exception cref="T:System.ArgumentException"> ArgumentException
	/// if name is null or empty, or the group is an empty string.
	/// </exception>
	protected AbstractTrigger(string name, string group, string jobName, string jobGroup)
	{
		Name = name;
		Group = group;
		JobName = jobName;
		JobGroup = jobGroup;
	}

	/// <summary>
	/// This method should not be used by the Quartz client.
	/// </summary>
	/// <remarks>
	/// Called when the <see cref="T:Quartz.IScheduler" /> has decided to 'fire'
	/// the trigger (Execute the associated <see cref="T:Quartz.IJob" />), in order to
	/// give the <see cref="T:Quartz.ITrigger" /> a chance to update itself for its next
	/// triggering (if any).
	/// </remarks>
	/// <seealso cref="T:Quartz.JobExecutionException" />
	public abstract void Triggered(ICalendar cal);

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
	/// After this method has been called, <see cref="M:Quartz.Impl.Triggers.AbstractTrigger.GetNextFireTimeUtc" />
	/// should return a valid answer.
	/// </para>
	/// </remarks>
	/// <returns> 
	/// The first time at which the <see cref="T:Quartz.ITrigger" /> will be fired
	/// by the scheduler, which is also the same value <see cref="M:Quartz.Impl.Triggers.AbstractTrigger.GetNextFireTimeUtc" />
	/// will return (until after the first firing of the <see cref="T:Quartz.ITrigger" />).
	/// </returns>        
	public abstract DateTimeOffset? ComputeFirstFireTimeUtc(ICalendar cal);

	/// <summary>
	/// This method should not be used by the Quartz client.
	/// </summary>
	/// <remarks>
	/// Called after the <see cref="T:Quartz.IScheduler" /> has executed the
	/// <see cref="T:Quartz.IJobDetail" /> associated with the <see cref="T:Quartz.ITrigger" />
	/// in order to get the final instruction code from the trigger.
	/// </remarks>
	/// <param name="context">
	/// is the <see cref="T:Quartz.IJobExecutionContext" /> that was used by the
	/// <see cref="T:Quartz.IJob" />'s<see cref="M:Quartz.IJob.Execute(Quartz.IJobExecutionContext)" /> method.</param>
	/// <param name="result">is the <see cref="T:Quartz.JobExecutionException" /> thrown by the
	/// <see cref="T:Quartz.IJob" />, if any (may be null).
	/// </param>
	/// <returns>
	/// One of the <see cref="T:Quartz.SchedulerInstruction" /> members.
	/// </returns>
	/// <seealso cref="T:Quartz.SchedulerInstruction" />
	/// <seealso cref="M:Quartz.Impl.Triggers.AbstractTrigger.Triggered(Quartz.ICalendar)" />
	public virtual SchedulerInstruction ExecutionComplete(IJobExecutionContext context, JobExecutionException result)
	{
		if (result != null && result.RefireImmediately)
		{
			return SchedulerInstruction.ReExecuteJob;
		}
		if (result != null && result.UnscheduleFiringTrigger)
		{
			return SchedulerInstruction.SetTriggerComplete;
		}
		if (result != null && result.UnscheduleAllTriggers)
		{
			return SchedulerInstruction.SetAllJobTriggersComplete;
		}
		if (result != null && !result.RefireImmediately)
		{
			return SchedulerInstruction.NoInstruction;
		}
		if (!GetMayFireAgain())
		{
			return SchedulerInstruction.DeleteTrigger;
		}
		return SchedulerInstruction.NoInstruction;
	}

	/// <summary> 
	/// Used by the <see cref="T:Quartz.IScheduler" /> to determine whether or not
	/// it is possible for this <see cref="T:Quartz.ITrigger" /> to fire again.
	/// <para>
	/// If the returned value is <see langword="false" /> then the <see cref="T:Quartz.IScheduler" />
	/// may remove the <see cref="T:Quartz.ITrigger" /> from the <see cref="T:Quartz.Spi.IJobStore" />.
	/// </para>
	/// </summary>
	public abstract bool GetMayFireAgain();

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
	public abstract DateTimeOffset? GetNextFireTimeUtc();

	/// <summary>
	/// Returns the next time at which the <see cref="T:Quartz.ITrigger" /> will fire,
	/// after the given time. If the trigger will not fire after the given time,
	/// <see langword="null" /> will be returned.
	/// </summary>
	public abstract DateTimeOffset? GetFireTimeAfter(DateTimeOffset? afterTime);

	/// <summary>
	/// Validates the misfire instruction.
	/// </summary>
	/// <param name="misfireInstruction">The misfire instruction.</param>
	/// <returns></returns>
	protected abstract bool ValidateMisfireInstruction(int misfireInstruction);

	/// <summary> 
	/// This method should not be used by the Quartz client.
	/// <para>
	/// To be implemented by the concrete classes that extend this class.
	/// </para>
	/// <para>
	/// The implementation should update the <see cref="T:Quartz.ITrigger" />'s state
	/// based on the MISFIRE_INSTRUCTION_XXX that was selected when the <see cref="T:Quartz.ITrigger" />
	/// was created.
	/// </para>
	/// </summary>
	public abstract void UpdateAfterMisfire(ICalendar cal);

	/// <summary> 
	/// This method should not be used by the Quartz client.
	/// <para>
	/// The implementation should update the <see cref="T:Quartz.ITrigger" />'s state
	/// based on the given new version of the associated <see cref="T:Quartz.ICalendar" />
	/// (the state should be updated so that it's next fire time is appropriate
	/// given the Calendar's new settings). 
	/// </para>
	/// </summary>
	/// <param name="cal"> </param>
	/// <param name="misfireThreshold"></param>
	public abstract void UpdateWithNewCalendar(ICalendar cal, TimeSpan misfireThreshold);

	/// <summary>
	/// Validates whether the properties of the <see cref="T:Quartz.IJobDetail" /> are
	/// valid for submission into a <see cref="T:Quartz.IScheduler" />.
	/// </summary>
	public virtual void Validate()
	{
		if (name == null)
		{
			throw new SchedulerException("Trigger's name cannot be null");
		}
		if (group == null)
		{
			throw new SchedulerException("Trigger's group cannot be null");
		}
		if (jobName == null)
		{
			throw new SchedulerException("Trigger's related Job's name cannot be null");
		}
		if (jobGroup == null)
		{
			throw new SchedulerException("Trigger's related Job's group cannot be null");
		}
	}

	/// <summary>
	/// Return a simple string representation of this object.
	/// </summary>
	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "Trigger '{0}':  triggerClass: '{1} calendar: '{2}' misfireInstruction: {3} nextFireTime: {4}", FullName, GetType().FullName, CalendarName, MisfireInstruction, GetNextFireTimeUtc());
	}

	/// <summary>
	/// Compare the next fire time of this <see cref="T:Quartz.ITrigger" /> to that of
	/// another by comparing their keys, or in other words, sorts them
	/// according to the natural (i.e. alphabetical) order of their keys.
	/// </summary>
	/// <param name="other"></param>
	/// <returns></returns>
	public virtual int CompareTo(ITrigger other)
	{
		if (other.Key == null && Key == null)
		{
			return 0;
		}
		if (other.Key == null)
		{
			return -1;
		}
		if (Key == null)
		{
			return 1;
		}
		return Key.CompareTo(other.Key);
	}

	/// <summary>
	/// Determines whether the specified <see cref="T:System.Object"></see> is equal to the current <see cref="T:System.Object"></see>.
	/// </summary>
	/// <param name="obj">The <see cref="T:System.Object"></see> to compare with the current <see cref="T:System.Object"></see>.</param>
	/// <returns>
	/// true if the specified <see cref="T:System.Object"></see> is equal to the current <see cref="T:System.Object"></see>; otherwise, false.
	/// </returns>
	public override bool Equals(object obj)
	{
		return Equals(obj as AbstractTrigger);
	}

	/// <summary>
	/// Trigger equality is based upon the equality of the TriggerKey.
	/// </summary>
	/// <param name="trigger"></param>
	/// <returns>true if the key of this Trigger equals that of the given Trigger</returns>
	public virtual bool Equals(AbstractTrigger trigger)
	{
		if (trigger == null)
		{
			return false;
		}
		if (trigger.Key == null || Key == null)
		{
			return false;
		}
		return Key.Equals(trigger.Key);
	}

	/// <summary>
	/// Serves as a hash function for a particular type. <see cref="M:System.Object.GetHashCode"></see> is suitable for use in hashing algorithms and data structures like a hash table.
	/// </summary>
	/// <returns>
	/// A hash code for the current <see cref="T:System.Object"></see>.
	/// </returns>
	public override int GetHashCode()
	{
		if (Key == null)
		{
			return base.GetHashCode();
		}
		return Key.GetHashCode();
	}

	/// <summary>
	/// Creates a new object that is a copy of the current instance.
	/// </summary>
	/// <returns>
	/// A new object that is a copy of this instance.
	/// </returns>
	public virtual object Clone()
	{
		AbstractTrigger copy;
		try
		{
			copy = (AbstractTrigger)MemberwiseClone();
			if (jobDataMap != null)
			{
				copy.jobDataMap = (JobDataMap)jobDataMap.Clone();
			}
		}
		catch (Exception ex)
		{
			throw new Exception("Not Cloneable.", ex);
		}
		return copy;
	}

	protected TriggerBuilder GetTriggerBuilder<T>() where T : ITrigger
	{
		return TriggerBuilder.Create().ForJob(JobKey).ModifiedByCalendar(CalendarName)
			.UsingJobData(JobDataMap)
			.WithDescription(Description)
			.EndAt(EndTimeUtc)
			.WithIdentity(Key)
			.WithPriority(Priority)
			.StartAt(StartTimeUtc)
			.WithSchedule(GetScheduleBuilder());
	}
}
