using System;
using System.Globalization;
using System.Linq;
using System.Text;
using Quartz.Collection;
using Quartz.Impl.Triggers;
using Quartz.Spi;

namespace Quartz.Impl.AdoJobStore;

/// <summary>
/// Persist a DailyTimeIntervalTrigger by converting internal fields to and from
/// SimplePropertiesTriggerProperties.
/// </summary>
/// <see cref="T:Quartz.DailyTimeIntervalScheduleBuilder" />
/// <see cref="T:Quartz.IDailyTimeIntervalTrigger" />
/// <author>Zemian Deng saltnlight5@gmail.com</author>
/// <author>Nuno Maia (.NET)</author>
public class DailyTimeIntervalTriggerPersistenceDelegate : SimplePropertiesTriggerPersistenceDelegateSupport
{
	public override bool CanHandleTriggerType(IOperableTrigger trigger)
	{
		if (trigger is DailyTimeIntervalTriggerImpl)
		{
			return !((DailyTimeIntervalTriggerImpl)trigger).HasAdditionalProperties;
		}
		return false;
	}

	/// <summary>
	///
	/// </summary>
	/// <returns></returns>
	public override string GetHandledTriggerTypeDiscriminator()
	{
		return "DAILY_I";
	}

	protected override SimplePropertiesTriggerProperties GetTriggerProperties(IOperableTrigger trigger)
	{
		DailyTimeIntervalTriggerImpl dailyTrigger = (DailyTimeIntervalTriggerImpl)trigger;
		SimplePropertiesTriggerProperties props = new SimplePropertiesTriggerProperties();
		props.Int1 = dailyTrigger.RepeatInterval;
		props.String1 = dailyTrigger.RepeatIntervalUnit.ToString();
		props.Int2 = dailyTrigger.TimesTriggered;
		ISet<DayOfWeek> days = dailyTrigger.DaysOfWeek;
		string daysStr = string.Join(",", (from int x in days
			select x.ToString(CultureInfo.InvariantCulture)).ToArray());
		props.String2 = daysStr;
		StringBuilder timeOfDayBuffer = new StringBuilder();
		TimeOfDay startTimeOfDay = dailyTrigger.StartTimeOfDay;
		if (startTimeOfDay != null)
		{
			timeOfDayBuffer.Append(startTimeOfDay.Minute).Append(",");
			timeOfDayBuffer.Append(startTimeOfDay.Second).Append(",");
			timeOfDayBuffer.Append(startTimeOfDay.Hour).Append(",");
		}
		else
		{
			timeOfDayBuffer.Append(",,,");
		}
		TimeOfDay endTimeOfDay = dailyTrigger.EndTimeOfDay;
		if (endTimeOfDay != null)
		{
			timeOfDayBuffer.Append(endTimeOfDay.Hour).Append(",");
			timeOfDayBuffer.Append(endTimeOfDay.Minute).Append(",");
			timeOfDayBuffer.Append(endTimeOfDay.Second);
		}
		else
		{
			timeOfDayBuffer.Append(",,,");
		}
		props.String3 = timeOfDayBuffer.ToString();
		props.Long1 = dailyTrigger.RepeatCount;
		return props;
	}

	protected override TriggerPropertyBundle GetTriggerPropertyBundle(SimplePropertiesTriggerProperties props)
	{
		int repeatCount = (int)props.Long1;
		int interval = props.Int1;
		string intervalUnitStr = props.String1;
		string daysOfWeekStr = props.String2;
		string timeOfDayStr = props.String3;
		IntervalUnit intervalUnit = (IntervalUnit)Enum.Parse(typeof(IntervalUnit), intervalUnitStr, ignoreCase: true);
		DailyTimeIntervalScheduleBuilder scheduleBuilder = DailyTimeIntervalScheduleBuilder.Create().WithInterval(interval, intervalUnit).WithRepeatCount(repeatCount);
		if (daysOfWeekStr != null)
		{
			ISet<DayOfWeek> daysOfWeek = new HashSet<DayOfWeek>();
			string[] nums2 = daysOfWeekStr.Split(',');
			if (nums2.Length > 0)
			{
				string[] array = nums2;
				foreach (string num in array)
				{
					daysOfWeek.Add((DayOfWeek)int.Parse(num));
				}
				scheduleBuilder.OnDaysOfTheWeek(daysOfWeek);
			}
		}
		else
		{
			scheduleBuilder.OnDaysOfTheWeek(DailyTimeIntervalScheduleBuilder.AllDaysOfTheWeek);
		}
		if (timeOfDayStr != null)
		{
			string[] nums = timeOfDayStr.Split(',');
			TimeOfDay startTimeOfDay;
			if (nums.Length >= 3)
			{
				int hour2 = int.Parse(nums[0]);
				int min2 = int.Parse(nums[1]);
				int sec2 = int.Parse(nums[2]);
				startTimeOfDay = new TimeOfDay(hour2, min2, sec2);
			}
			else
			{
				startTimeOfDay = TimeOfDay.HourMinuteAndSecondOfDay(0, 0, 0);
			}
			scheduleBuilder.StartingDailyAt(startTimeOfDay);
			TimeOfDay endTimeOfDay;
			if (nums.Length >= 6)
			{
				int hour = int.Parse(nums[3]);
				int min = int.Parse(nums[4]);
				int sec = int.Parse(nums[5]);
				endTimeOfDay = new TimeOfDay(hour, min, sec);
			}
			else
			{
				endTimeOfDay = TimeOfDay.HourMinuteAndSecondOfDay(23, 59, 59);
			}
			scheduleBuilder.EndingDailyAt(endTimeOfDay);
		}
		else
		{
			scheduleBuilder.StartingDailyAt(TimeOfDay.HourMinuteAndSecondOfDay(0, 0, 0));
			scheduleBuilder.EndingDailyAt(TimeOfDay.HourMinuteAndSecondOfDay(23, 59, 59));
		}
		int timesTriggered = props.Int2;
		string[] statePropertyNames = new string[1] { "timesTriggered" };
		object[] statePropertyValues = new object[1] { timesTriggered };
		return new TriggerPropertyBundle(scheduleBuilder, statePropertyNames, statePropertyValues);
	}
}
