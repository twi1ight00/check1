using System;

namespace Quartz;

/// <summary> 
/// A <see cref="T:Quartz.ITrigger" /> that is used to fire a <see cref="T:Quartz.IJob" />
/// at a given moment in time, and optionally repeated at a specified interval.
/// </summary>
/// <seealso cref="T:Quartz.TriggerBuilder" />
/// <seealso cref="T:Quartz.SimpleScheduleBuilder" />
/// <author>James House</author>
/// <author>Contributions by Lieven Govaerts of Ebitec Nv, Belgium.</author>
/// <author>Marko Lahma (.NET)</author>
public interface ISimpleTrigger : ITrigger, ICloneable, IComparable<ITrigger>
{
	/// <summary>
	/// Get or set thhe number of times the <see cref="T:Quartz.ISimpleTrigger" /> should
	/// repeat, after which it will be automatically deleted.
	/// </summary>
	/// <seealso cref="F:Quartz.Impl.Triggers.SimpleTriggerImpl.RepeatIndefinitely" />
	int RepeatCount { get; set; }

	/// <summary>
	/// Get or set the the time interval at which the <see cref="T:Quartz.ISimpleTrigger" /> should repeat.
	/// </summary>
	TimeSpan RepeatInterval { get; set; }

	/// <summary>
	/// Get or set the number of times the <see cref="T:Quartz.ISimpleTrigger" /> has already
	/// fired.
	/// </summary>
	int TimesTriggered { get; set; }

	TriggerBuilder GetTriggerBuilder();
}
