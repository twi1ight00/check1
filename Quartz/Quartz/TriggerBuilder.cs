using System;
using Quartz.Spi;

namespace Quartz;

/// <summary>
/// TriggerBuilder is used to instantiate <see cref="T:Quartz.ITrigger" />s.
/// </summary>
/// <remarks>
/// <para>
/// The builder will always try to keep itself in a valid state, with 
/// reasonable defaults set for calling build() at any point.  For instance
/// if you do not invoke <i>WithSchedule(..)</i> method, a default schedule
/// of firing once immediately will be used.  As another example, if you
/// do not invoked <i>WithIdentity(..)</i> a trigger name will be generated
/// for you.
/// </para>
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
///     .WithIdentity("myJob")
///     .Build();
/// ITrigger trigger = TriggerBuilder.Create()
///     .WithIdentity("myTrigger", "myTriggerGroup")
///     .WithSimpleSchedule(x =&gt; x
///         .WithIntervalInHours(1)
///         .RepeatForever())
///     .StartAt(DateBuilder.FutureDate(10, IntervalUnit.Minute))
///     .Build();
/// scheduler.scheduleJob(job, trigger);
/// </code>
/// </remarks>
/// <seealso cref="T:Quartz.JobBuilder" />
/// <seealso cref="T:Quartz.IScheduleBuilder" />
/// <seealso cref="T:Quartz.DateBuilder" />
/// <seealso cref="T:Quartz.ITrigger" />
public class TriggerBuilder
{
	private TriggerKey key;

	private string description;

	private DateTimeOffset startTime = SystemTime.UtcNow();

	private DateTimeOffset? endTime;

	private int priority = 5;

	private string calendarName;

	private JobKey jobKey;

	private JobDataMap jobDataMap = new JobDataMap();

	private IScheduleBuilder scheduleBuilder;

	private TriggerBuilder()
	{
	}

	/// <summary>
	/// Create a new TriggerBuilder with which to define a
	/// specification for a Trigger.
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <returns>the new TriggerBuilder</returns>
	public static TriggerBuilder Create()
	{
		return new TriggerBuilder();
	}

	/// <summary>
	/// Produce the <see cref="T:Quartz.ITrigger" />.
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <returns>a Trigger that meets the specifications of the builder.</returns>
	public ITrigger Build()
	{
		if (scheduleBuilder == null)
		{
			scheduleBuilder = SimpleScheduleBuilder.Create();
		}
		IMutableTrigger trig = scheduleBuilder.Build();
		trig.CalendarName = calendarName;
		trig.Description = description;
		trig.StartTimeUtc = startTime;
		trig.EndTimeUtc = endTime;
		if (key == null)
		{
			key = new TriggerKey(Guid.NewGuid().ToString(), null);
		}
		trig.Key = key;
		if (jobKey != null)
		{
			trig.JobKey = jobKey;
		}
		trig.Priority = priority;
		if (!jobDataMap.IsEmpty)
		{
			trig.JobDataMap = jobDataMap;
		}
		return trig;
	}

	/// <summary>
	/// Use a <see cref="T:Quartz.TriggerKey" /> with the given name and default group to
	/// identify the Trigger.
	/// </summary>
	/// <remarks>
	/// <para>If none of the 'withIdentity' methods are set on the TriggerBuilder,
	/// then a random, unique TriggerKey will be generated.</para>
	/// </remarks>
	/// <param name="name">the name element for the Trigger's TriggerKey</param>
	/// <returns>the updated TriggerBuilder</returns>
	/// <seealso cref="T:Quartz.TriggerKey" />
	/// <seealso cref="P:Quartz.ITrigger.Key" />
	public TriggerBuilder WithIdentity(string name)
	{
		key = new TriggerKey(name, null);
		return this;
	}

	/// <summary>
	/// Use a TriggerKey with the given name and group to
	/// identify the Trigger.
	/// </summary>
	/// <remarks>
	/// <para>If none of the 'withIdentity' methods are set on the TriggerBuilder,
	/// then a random, unique TriggerKey will be generated.</para>
	/// </remarks>
	/// <param name="name">the name element for the Trigger's TriggerKey</param>
	/// <param name="group">the group element for the Trigger's TriggerKey</param>
	/// <returns>the updated TriggerBuilder</returns>
	/// <seealso cref="T:Quartz.TriggerKey" />
	/// <seealso cref="P:Quartz.ITrigger.Key" />
	public TriggerBuilder WithIdentity(string name, string group)
	{
		key = new TriggerKey(name, group);
		return this;
	}

	/// <summary>
	/// Use the given TriggerKey to identify the Trigger.
	/// </summary>
	/// <remarks>
	/// <para>If none of the 'withIdentity' methods are set on the TriggerBuilder,
	/// then a random, unique TriggerKey will be generated.</para>
	/// </remarks>
	/// <param name="key">the TriggerKey for the Trigger to be built</param>
	/// <returns>the updated TriggerBuilder</returns>
	/// <seealso cref="T:Quartz.TriggerKey" />
	/// <seealso cref="P:Quartz.ITrigger.Key" />
	public TriggerBuilder WithIdentity(TriggerKey key)
	{
		this.key = key;
		return this;
	}

	/// <summary>
	/// Set the given (human-meaningful) description of the Trigger.
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <param name="description">the description for the Trigger</param>
	/// <returns>the updated TriggerBuilder</returns>
	/// <seealso cref="P:Quartz.ITrigger.Description" />
	public TriggerBuilder WithDescription(string description)
	{
		this.description = description;
		return this;
	}

	/// <summary>
	/// Set the Trigger's priority.  When more than one Trigger have the same
	/// fire time, the scheduler will fire the one with the highest priority
	/// first.
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <param name="priority">the priority for the Trigger</param>
	/// <returns>the updated TriggerBuilder</returns>
	/// <seealso cref="F:Quartz.TriggerConstants.DefaultPriority" />
	/// <seealso cref="P:Quartz.ITrigger.Priority" />
	public TriggerBuilder WithPriority(int priority)
	{
		this.priority = priority;
		return this;
	}

	/// <summary>
	/// Set the name of the <see cref="T:Quartz.ICalendar" /> that should be applied to this
	/// Trigger's schedule.
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <param name="calendarName">the name of the Calendar to reference.</param>
	/// <returns>the updated TriggerBuilder</returns>
	/// <seealso cref="T:Quartz.ICalendar" />
	/// <seealso cref="P:Quartz.ITrigger.CalendarName" />
	public TriggerBuilder ModifiedByCalendar(string calendarName)
	{
		this.calendarName = calendarName;
		return this;
	}

	/// <summary>
	/// Set the time the Trigger should start at - the trigger may or may
	/// not fire at this time - depending upon the schedule configured for
	/// the Trigger.  However the Trigger will NOT fire before this time,
	/// regardless of the Trigger's schedule.
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <param name="startTimeUtc">the start time for the Trigger.</param>
	/// <returns>the updated TriggerBuilder</returns>
	/// <seealso cref="P:Quartz.ITrigger.StartTimeUtc" />
	/// <seealso cref="T:Quartz.DateBuilder" />
	public TriggerBuilder StartAt(DateTimeOffset startTimeUtc)
	{
		startTime = startTimeUtc;
		return this;
	}

	/// <summary>
	/// Set the time the Trigger should start at to the current moment -
	/// the trigger may or may not fire at this time - depending upon the
	/// schedule configured for the Trigger.
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <returns>the updated TriggerBuilder</returns>
	/// <seealso cref="P:Quartz.ITrigger.StartTimeUtc" />
	public TriggerBuilder StartNow()
	{
		startTime = SystemTime.UtcNow();
		return this;
	}

	/// <summary>
	/// Set the time at which the Trigger will no longer fire - even if it's
	/// schedule has remaining repeats.
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <param name="endTimeUtc">the end time for the Trigger.  If null, the end time is indefinite.</param>
	/// <returns>the updated TriggerBuilder</returns>
	/// <seealso cref="P:Quartz.ITrigger.EndTimeUtc" />
	/// <seealso cref="T:Quartz.DateBuilder" />
	public TriggerBuilder EndAt(DateTimeOffset? endTimeUtc)
	{
		endTime = endTimeUtc;
		return this;
	}

	/// <summary>
	/// Set the <see cref="T:Quartz.IScheduleBuilder" /> that will be used to define the
	/// Trigger's schedule.
	/// </summary>
	/// <remarks>
	/// <para>The particular <see cref="T:Quartz.IScheduleBuilder" /> used will dictate
	/// the concrete type of Trigger that is produced by the TriggerBuilder.</para>
	/// </remarks>
	/// <param name="scheduleBuilder">the SchedulerBuilder to use.</param>
	/// <returns>the updated TriggerBuilder</returns>
	/// <seealso cref="T:Quartz.IScheduleBuilder" />
	/// <seealso cref="T:Quartz.SimpleScheduleBuilder" />
	/// <seealso cref="T:Quartz.CronScheduleBuilder" />
	/// <seealso cref="T:Quartz.CalendarIntervalScheduleBuilder" />
	public TriggerBuilder WithSchedule(IScheduleBuilder scheduleBuilder)
	{
		this.scheduleBuilder = scheduleBuilder;
		return this;
	}

	/// <summary>
	/// Set the identity of the Job which should be fired by the produced
	/// Trigger.
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <param name="jobKey">the identity of the Job to fire.</param>
	/// <returns>the updated TriggerBuilder</returns>
	/// <seealso cref="P:Quartz.ITrigger.JobKey" />
	public TriggerBuilder ForJob(JobKey jobKey)
	{
		this.jobKey = jobKey;
		return this;
	}

	/// <summary>
	/// Set the identity of the Job which should be fired by the produced
	/// Trigger - a <see cref="T:Quartz.JobKey" /> will be produced with the given
	/// name and default group.
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <param name="jobName">the name of the job (in default group) to fire.</param>
	/// <returns>the updated TriggerBuilder</returns>
	/// <seealso cref="P:Quartz.ITrigger.JobKey" />
	public TriggerBuilder ForJob(string jobName)
	{
		jobKey = new JobKey(jobName, null);
		return this;
	}

	/// <summary>
	/// Set the identity of the Job which should be fired by the produced
	/// Trigger - a <see cref="T:Quartz.JobKey" /> will be produced with the given
	/// name and group.
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <param name="jobName">the name of the job to fire.</param>
	/// <param name="jobGroup">the group of the job to fire.</param>
	/// <returns>the updated TriggerBuilder</returns>
	/// <seealso cref="P:Quartz.ITrigger.JobKey" />
	public TriggerBuilder ForJob(string jobName, string jobGroup)
	{
		jobKey = new JobKey(jobName, jobGroup);
		return this;
	}

	/// <summary>
	/// Set the identity of the Job which should be fired by the produced
	/// Trigger, by extracting the JobKey from the given job.
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <param name="jobDetail">the Job to fire.</param>
	/// <returns>the updated TriggerBuilder</returns>
	/// <seealso cref="P:Quartz.ITrigger.JobKey" />
	public TriggerBuilder ForJob(IJobDetail jobDetail)
	{
		JobKey i = jobDetail.Key;
		if (i.Name == null)
		{
			throw new ArgumentException("The given job has not yet had a name assigned to it.");
		}
		jobKey = i;
		return this;
	}

	/// <summary>
	/// Add the given key-value pair to the Trigger's <see cref="T:Quartz.JobDataMap" />.
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <returns>the updated TriggerBuilder</returns>
	/// <seealso cref="P:Quartz.ITrigger.JobDataMap" />
	public TriggerBuilder UsingJobData(string key, string value)
	{
		jobDataMap.Put(key, value);
		return this;
	}

	/// <summary>
	/// Add the given key-value pair to the Trigger's <see cref="T:Quartz.JobDataMap" />.
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <returns>the updated TriggerBuilder</returns>
	/// <seealso cref="P:Quartz.ITrigger.JobDataMap" />
	public TriggerBuilder UsingJobData(string key, int value)
	{
		jobDataMap.Put(key, value);
		return this;
	}

	/// <summary>
	/// Add the given key-value pair to the Trigger's <see cref="T:Quartz.JobDataMap" />.
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <returns>the updated TriggerBuilder</returns>
	/// <seealso cref="P:Quartz.ITrigger.JobDataMap" />
	public TriggerBuilder UsingJobData(string key, long value)
	{
		jobDataMap.Put(key, value);
		return this;
	}

	/// <summary>
	/// Add the given key-value pair to the Trigger's <see cref="T:Quartz.JobDataMap" />.
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <returns>the updated TriggerBuilder</returns>
	/// <seealso cref="P:Quartz.ITrigger.JobDataMap" />
	public TriggerBuilder UsingJobData(string key, float value)
	{
		jobDataMap.Put(key, value);
		return this;
	}

	/// <summary>
	/// Add the given key-value pair to the Trigger's <see cref="T:Quartz.JobDataMap" />.
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <returns>the updated TriggerBuilder</returns>
	/// <seealso cref="P:Quartz.ITrigger.JobDataMap" />
	public TriggerBuilder UsingJobData(string key, double value)
	{
		jobDataMap.Put(key, value);
		return this;
	}

	/// <summary>
	/// Add the given key-value pair to the Trigger's <see cref="T:Quartz.JobDataMap" />.
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <returns>the updated TriggerBuilder</returns>
	/// <seealso cref="P:Quartz.ITrigger.JobDataMap" />
	public TriggerBuilder UsingJobData(string key, decimal value)
	{
		jobDataMap.Put(key, value);
		return this;
	}

	/// <summary>
	/// Add the given key-value pair to the Trigger's <see cref="T:Quartz.JobDataMap" />.
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <returns>the updated TriggerBuilder</returns>
	/// <seealso cref="P:Quartz.ITrigger.JobDataMap" />
	public TriggerBuilder UsingJobData(string key, bool value)
	{
		jobDataMap.Put(key, value);
		return this;
	}

	/// <summary>
	/// Add the given key-value pair to the Trigger's <see cref="T:Quartz.JobDataMap" />.
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <returns>the updated TriggerBuilder</returns>
	/// <seealso cref="P:Quartz.ITrigger.JobDataMap" />
	public TriggerBuilder UsingJobData(JobDataMap newJobDataMap)
	{
		foreach (string i in jobDataMap.Keys)
		{
			newJobDataMap.Put(i, jobDataMap.Get(i));
		}
		jobDataMap = newJobDataMap;
		return this;
	}
}
