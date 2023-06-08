using System;

namespace Quartz;

/// <summary>
/// The base interface with properties common to all <see cref="T:Quartz.ITrigger" />s - 
/// use <see cref="T:Quartz.TriggerBuilder" /> to instantiate an actual Trigger.
/// </summary>
/// <remarks>
/// <para>
/// <see cref="T:Quartz.ITrigger" />s have a <see cref="T:Quartz.TriggerKey" /> associated with them, which
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
/// into the <see cref="P:Quartz.ITrigger.JobDataMap" /> on the <see cref="T:Quartz.ITrigger" />.
/// </para>
/// </remarks>
/// <seealso cref="T:Quartz.TriggerBuilder" />
/// <seealso cref="T:Quartz.ICalendarIntervalTrigger" />
/// <seealso cref="T:Quartz.ISimpleTrigger" />
/// <seealso cref="T:Quartz.ICronTrigger" />
/// <seealso cref="T:Quartz.IDailyTimeIntervalTrigger" />
/// <seealso cref="P:Quartz.ITrigger.JobDataMap" />
/// <seealso cref="T:Quartz.IJobExecutionContext" />
/// <author>James House</author>
/// <author>Sharada Jambula</author>
/// <author>Marko Lahma (.NET)</author>
public interface ITrigger : ICloneable, IComparable<ITrigger>
{
	TriggerKey Key { get; }

	JobKey JobKey { get; }

	/// <summary>
	/// Get or set the description given to the <see cref="T:Quartz.ITrigger" /> instance by
	/// its creator (if any).
	/// </summary>
	string Description { get; }

	/// <summary>
	/// Get or set  the <see cref="T:Quartz.ICalendar" /> with the given name with
	/// this Trigger. Use <see langword="null" /> when setting to dis-associate a Calendar.
	/// </summary>
	string CalendarName { get; }

	/// <summary>
	/// Get or set the <see cref="P:Quartz.ITrigger.JobDataMap" /> that is associated with the 
	/// <see cref="T:Quartz.ITrigger" />.
	/// <para>
	/// Changes made to this map during job execution are not re-persisted, and
	/// in fact typically result in an illegal state.
	/// </para>
	/// </summary>
	JobDataMap JobDataMap { get; }

	/// <summary>
	/// Returns the last UTC time at which the <see cref="T:Quartz.ITrigger" /> will fire, if
	/// the Trigger will repeat indefinitely, null will be returned.
	/// <para>
	/// Note that the return time *may* be in the past.
	/// </para>
	/// </summary>
	DateTimeOffset? FinalFireTimeUtc { get; }

	/// <summary>
	/// Get or set the instruction the <see cref="T:Quartz.IScheduler" /> should be given for
	/// handling misfire situations for this <see cref="T:Quartz.ITrigger" />- the
	/// concrete <see cref="T:Quartz.ITrigger" /> type that you are using will have
	/// defined a set of additional MISFIRE_INSTRUCTION_XXX
	/// constants that may be set to this property.
	/// <para>
	/// If not explicitly set, the default value is <see cref="F:Quartz.MisfireInstruction.InstructionNotSet" />.
	/// </para>
	/// </summary>
	/// <seealso cref="F:Quartz.MisfireInstruction.InstructionNotSet" />
	/// <seealso cref="T:Quartz.ISimpleTrigger" />
	/// <seealso cref="T:Quartz.ICronTrigger" />
	int MisfireInstruction { get; }

	/// <summary>
	/// Gets and sets the date/time on which the trigger must stop firing. This 
	/// defines the final boundary for trigger firings 舒 the trigger will
	/// not fire after to this date and time. If this value is null, no end time
	/// boundary is assumed, and the trigger can continue indefinitely.
	/// </summary>
	DateTimeOffset? EndTimeUtc { get; }

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
	DateTimeOffset StartTimeUtc { get; }

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
	int Priority { get; set; }

	bool HasMillisecondPrecision { get; }

	/// <summary>
	/// Get a <see cref="T:Quartz.IScheduleBuilder" /> that is configured to produce a 
	/// schedule identical to this trigger's schedule.
	/// </summary>
	/// <returns></returns>
	IScheduleBuilder GetScheduleBuilder();

	/// <summary> 
	/// Used by the <see cref="T:Quartz.IScheduler" /> to determine whether or not
	/// it is possible for this <see cref="T:Quartz.ITrigger" /> to fire again.
	/// <para>
	/// If the returned value is <see langword="false" /> then the <see cref="T:Quartz.IScheduler" />
	/// may remove the <see cref="T:Quartz.ITrigger" /> from the <see cref="T:Quartz.Spi.IJobStore" />.
	/// </para>
	/// </summary>
	bool GetMayFireAgain();

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
	DateTimeOffset? GetNextFireTimeUtc();

	/// <summary>
	/// Returns the previous time at which the <see cref="T:Quartz.ITrigger" /> fired.
	/// If the trigger has not yet fired, <see langword="null" /> will be returned.
	/// </summary>
	DateTimeOffset? GetPreviousFireTimeUtc();

	/// <summary>
	/// Returns the next time at which the <see cref="T:Quartz.ITrigger" /> will fire,
	/// after the given time. If the trigger will not fire after the given time,
	/// <see langword="null" /> will be returned.
	/// </summary>
	DateTimeOffset? GetFireTimeAfter(DateTimeOffset? afterTime);
}
