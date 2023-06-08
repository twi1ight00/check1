using System;

namespace Quartz;

/// <summary>
/// Extension methods that attach <see cref="T:Quartz.CalendarIntervalScheduleBuilder" /> to <see cref="T:Quartz.TriggerBuilder" />.
/// </summary>
public static class CalendarIntervalTriggerBuilderExtensions
{
	public static TriggerBuilder WithCalendarIntervalSchedule(this TriggerBuilder triggerBuilder)
	{
		CalendarIntervalScheduleBuilder builder = CalendarIntervalScheduleBuilder.Create();
		return triggerBuilder.WithSchedule(builder);
	}

	public static TriggerBuilder WithCalendarIntervalSchedule(this TriggerBuilder triggerBuilder, Action<CalendarIntervalScheduleBuilder> action)
	{
		CalendarIntervalScheduleBuilder builder = CalendarIntervalScheduleBuilder.Create();
		action(builder);
		return triggerBuilder.WithSchedule(builder);
	}
}
