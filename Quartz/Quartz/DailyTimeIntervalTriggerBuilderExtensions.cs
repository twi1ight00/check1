using System;

namespace Quartz;

/// <summary>
/// Extension methods that attach <see cref="T:Quartz.DailyTimeIntervalScheduleBuilder" /> to <see cref="T:Quartz.TriggerBuilder" />.
/// </summary>
public static class DailyTimeIntervalTriggerBuilderExtensions
{
	public static TriggerBuilder WithDailyTimeIntervalSchedule(this TriggerBuilder triggerBuilder)
	{
		DailyTimeIntervalScheduleBuilder builder = DailyTimeIntervalScheduleBuilder.Create();
		return triggerBuilder.WithSchedule(builder);
	}

	public static TriggerBuilder WithDailyTimeIntervalSchedule(this TriggerBuilder triggerBuilder, Action<DailyTimeIntervalScheduleBuilder> action)
	{
		DailyTimeIntervalScheduleBuilder builder = DailyTimeIntervalScheduleBuilder.Create();
		action(builder);
		return triggerBuilder.WithSchedule(builder);
	}
}
