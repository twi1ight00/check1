using System;

namespace Quartz;

/// <summary>
/// Extension methods that attach <see cref="T:Quartz.SimpleScheduleBuilder" /> to <see cref="T:Quartz.TriggerBuilder" />.
/// </summary>
public static class SimpleScheduleTriggerBuilderExtensions
{
	public static TriggerBuilder WithSimpleSchedule(this TriggerBuilder triggerBuilder, Action<SimpleScheduleBuilder> action)
	{
		SimpleScheduleBuilder builder = SimpleScheduleBuilder.Create();
		action(builder);
		return triggerBuilder.WithSchedule(builder);
	}

	public static TriggerBuilder WithSimpleSchedule(this TriggerBuilder triggerBuilder)
	{
		SimpleScheduleBuilder builder = SimpleScheduleBuilder.Create();
		return triggerBuilder.WithSchedule(builder);
	}
}
