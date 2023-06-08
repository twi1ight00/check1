using System;

namespace Quartz;

/// <summary>
/// Extension methods that attach <see cref="T:Quartz.CronScheduleBuilder" /> to <see cref="T:Quartz.TriggerBuilder" />.
/// </summary>
public static class CronScheduleTriggerBuilderExtensions
{
	public static TriggerBuilder WithCronSchedule(this TriggerBuilder triggerBuilder, string cronExpression)
	{
		CronScheduleBuilder builder = CronScheduleBuilder.CronSchedule(cronExpression);
		return triggerBuilder.WithSchedule(builder);
	}

	public static TriggerBuilder WithCronSchedule(this TriggerBuilder triggerBuilder, string cronExpression, Action<CronScheduleBuilder> action)
	{
		CronScheduleBuilder builder = CronScheduleBuilder.CronSchedule(cronExpression);
		action(builder);
		return triggerBuilder.WithSchedule(builder);
	}
}
