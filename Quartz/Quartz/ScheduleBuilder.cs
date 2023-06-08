using Quartz.Spi;

namespace Quartz;

/// <summary>
/// Base class for <see cref="T:Quartz.IScheduleBuilder" /> implementors.
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class ScheduleBuilder<T> : IScheduleBuilder where T : ITrigger
{
	/// <summary>
	/// Build the actual Trigger -- NOT intended to be invoked by end users,
	/// but will rather be invoked by a TriggerBuilder which this
	/// ScheduleBuilder is given to.
	/// </summary>
	/// <seealso cref="M:Quartz.TriggerBuilder.WithSchedule(Quartz.IScheduleBuilder)" />
	public abstract IMutableTrigger Build();
}
