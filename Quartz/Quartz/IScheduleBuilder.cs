using Quartz.Spi;

namespace Quartz;

/// <summary>
/// Schedule builders offer fluent interface and are responsible for creating schedules.
/// </summary>
/// <seealso cref="T:Quartz.SimpleScheduleBuilder" />
/// <seealso cref="T:Quartz.CalendarIntervalScheduleBuilder" />
/// <seealso cref="T:Quartz.CronScheduleBuilder" />
/// <seealso cref="T:Quartz.DailyTimeIntervalScheduleBuilder" />
public interface IScheduleBuilder
{
	/// <summary>
	/// Build the actual Trigger -- NOT intended to be invoked by end users,
	/// but will rather be invoked by a TriggerBuilder which this
	/// ScheduleBuilder is given to.
	/// </summary>
	/// <seealso cref="M:Quartz.TriggerBuilder.WithSchedule(Quartz.IScheduleBuilder)" />
	IMutableTrigger Build();
}
