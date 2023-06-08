using System;
using Quartz.Impl.Triggers;
using Quartz.Spi;

namespace Quartz.Impl.AdoJobStore;

/// <summary>
/// Persist a CalendarIntervalTriggerImpl by converting internal fields to and from
/// SimplePropertiesTriggerProperties.
/// </summary>
/// <see cref="T:Quartz.CalendarIntervalScheduleBuilder" />
/// <see cref="T:Quartz.ICalendarIntervalTrigger" />
public class CalendarIntervalTriggerPersistenceDelegate : SimplePropertiesTriggerPersistenceDelegateSupport
{
	public override bool CanHandleTriggerType(IOperableTrigger trigger)
	{
		if (trigger is CalendarIntervalTriggerImpl)
		{
			return !((CalendarIntervalTriggerImpl)trigger).HasAdditionalProperties;
		}
		return false;
	}

	public override string GetHandledTriggerTypeDiscriminator()
	{
		return "CAL_INT";
	}

	protected override SimplePropertiesTriggerProperties GetTriggerProperties(IOperableTrigger trigger)
	{
		CalendarIntervalTriggerImpl calTrig = (CalendarIntervalTriggerImpl)trigger;
		SimplePropertiesTriggerProperties props = new SimplePropertiesTriggerProperties();
		props.Int1 = calTrig.RepeatInterval;
		props.String1 = calTrig.RepeatIntervalUnit.ToString();
		props.Int2 = calTrig.TimesTriggered;
		props.String2 = calTrig.TimeZone.Id;
		props.Boolean1 = calTrig.PreserveHourOfDayAcrossDaylightSavings;
		props.Boolean2 = calTrig.SkipDayIfHourDoesNotExist;
		return props;
	}

	protected override TriggerPropertyBundle GetTriggerPropertyBundle(SimplePropertiesTriggerProperties props)
	{
		TimeZoneInfo tz = null;
		string tzId = props.String2;
		if (tzId != null && tzId.Trim().Length != 0)
		{
			tz = TimeZoneInfo.FindSystemTimeZoneById(tzId);
		}
		CalendarIntervalScheduleBuilder sb = CalendarIntervalScheduleBuilder.Create().WithInterval(props.Int1, (IntervalUnit)Enum.Parse(typeof(IntervalUnit), props.String1, ignoreCase: true)).InTimeZone(tz)
			.PreserveHourOfDayAcrossDaylightSavings(props.Boolean1)
			.SkipDayIfHourDoesNotExist(props.Boolean2);
		int timesTriggered = props.Int2;
		string[] statePropertyNames = new string[1] { "timesTriggered" };
		object[] statePropertyValues = new object[1] { timesTriggered };
		return new TriggerPropertyBundle(sb, statePropertyNames, statePropertyValues);
	}
}
