using System;

namespace Quartz.Spi;

/// <summary>
/// Should not be used by end users.
/// </summary>
public interface IMutableTrigger : ITrigger, ICloneable, IComparable<ITrigger>
{
	new TriggerKey Key { get; set; }

	new JobKey JobKey { get; set; }

	/// <summary>
	/// Set a description for the <see cref="T:Quartz.ITrigger" /> instance - may be
	/// useful for remembering/displaying the purpose of the trigger, though the
	/// description has no meaning to Quartz.
	/// </summary>
	new string Description { get; set; }

	/// <summary>
	/// Associate the <see cref="T:Quartz.ICalendar" /> with the given name with this Trigger.
	/// </summary>
	new string CalendarName { get; set; }

	/// <summary>
	/// Set the <see cref="P:Quartz.Spi.IMutableTrigger.JobDataMap" /> to be associated with the
	/// <see cref="T:Quartz.ITrigger" />.
	/// </summary>
	new JobDataMap JobDataMap { get; set; }

	/// <summary>
	/// The priority of a <see cref="T:Quartz.ITrigger" /> acts as a tie breaker such that if
	/// two <see cref="T:Quartz.ITrigger" />s have the same scheduled fire time, then Quartz
	/// will do its best to give the one with the higher priority first access
	/// to a worker thread.
	/// </summary>
	/// <remarks>
	/// If not explicitly set, the default value is 5.
	/// </remarks>
	/// <seealso cref="F:Quartz.TriggerConstants.DefaultPriority" />
	new int Priority { get; set; }

	/// <summary>
	/// <para>
	/// The time at which the trigger's scheduling should start.  May or may not
	/// be the first actual fire time of the trigger, depending upon the type of
	/// trigger and the settings of the other properties of the trigger.  However
	/// the first actual first time will not be before this date.
	/// </para>
	/// <para>
	/// Setting a value in the past may cause a new trigger to compute a first
	/// fire time that is in the past, which may cause an immediate misfire
	/// of the trigger.
	/// </para>
	/// ew DateTimeOffset StartTimeUtc {  get; set; }
	/// </summary>
	new DateTimeOffset StartTimeUtc { get; set; }

	/// <summary>
	/// <para>
	/// Set the time at which the <see cref="T:Quartz.ITrigger" /> should quit repeating -
	/// regardless of any remaining repeats (based on the trigger's particular
	/// repeat settings).
	/// </para>
	/// </summary>
	/// <remarks>
	/// </remarks>
	new DateTimeOffset? EndTimeUtc { get; set; }

	/// <summary>
	/// Set the instruction the <see cref="T:Quartz.IScheduler" /> should be given for
	/// handling misfire situations for this <see cref="T:Quartz.ITrigger" />- the
	/// concrete <see cref="T:Quartz.ITrigger" /> type that you are using will have
	/// defined a set of additional MisfireInstruction.XXX
	/// constants that may be passed to this method.
	/// </summary>
	/// <remarks>
	/// If not explicitly set, the default value is <see cref="F:Quartz.MisfireInstruction.SmartPolicy" />.
	/// </remarks>
	/// <seealso cref="F:Quartz.MisfireInstruction.SmartPolicy" />
	/// <seealso cref="T:Quartz.ISimpleTrigger" />
	/// <seealso cref="T:Quartz.ICronTrigger" />
	new int MisfireInstruction { get; set; }
}
