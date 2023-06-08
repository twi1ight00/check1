using System;
using System.Data;
using Quartz.Impl.Triggers;
using Quartz.Spi;
using Quartz.Util;

namespace Quartz.Impl.AdoJobStore;

public class SimpleTriggerPersistenceDelegate : ITriggerPersistenceDelegate
{
	protected IDbAccessor DbAccessor { get; private set; }

	protected string TablePrefix { get; private set; }

	protected string SchedNameLiteral { get; private set; }

	public void Initialize(string tablePrefix, string schedName, IDbAccessor dbAccessor)
	{
		TablePrefix = tablePrefix;
		SchedNameLiteral = "'" + schedName + "'";
		DbAccessor = dbAccessor;
	}

	public string GetHandledTriggerTypeDiscriminator()
	{
		return "SIMPLE";
	}

	public bool CanHandleTriggerType(IOperableTrigger trigger)
	{
		if (trigger is SimpleTriggerImpl)
		{
			return !((SimpleTriggerImpl)trigger).HasAdditionalProperties;
		}
		return false;
	}

	public int DeleteExtendedTriggerProperties(ConnectionAndTransactionHolder conn, TriggerKey triggerKey)
	{
		using IDbCommand cmd = DbAccessor.PrepareCommand(conn, AdoJobStoreUtil.ReplaceTablePrefix(StdAdoConstants.SqlDeleteSimpleTrigger, TablePrefix, SchedNameLiteral));
		DbAccessor.AddCommandParameter(cmd, "triggerName", triggerKey.Name);
		DbAccessor.AddCommandParameter(cmd, "triggerGroup", triggerKey.Group);
		return cmd.ExecuteNonQuery();
	}

	public int InsertExtendedTriggerProperties(ConnectionAndTransactionHolder conn, IOperableTrigger trigger, string state, IJobDetail jobDetail)
	{
		ISimpleTrigger simpleTrigger = (ISimpleTrigger)trigger;
		using IDbCommand cmd = DbAccessor.PrepareCommand(conn, AdoJobStoreUtil.ReplaceTablePrefix(StdAdoConstants.SqlInsertSimpleTrigger, TablePrefix, SchedNameLiteral));
		DbAccessor.AddCommandParameter(cmd, "triggerName", trigger.Key.Name);
		DbAccessor.AddCommandParameter(cmd, "triggerGroup", trigger.Key.Group);
		DbAccessor.AddCommandParameter(cmd, "triggerRepeatCount", simpleTrigger.RepeatCount);
		DbAccessor.AddCommandParameter(cmd, "triggerRepeatInterval", DbAccessor.GetDbTimeSpanValue(simpleTrigger.RepeatInterval));
		DbAccessor.AddCommandParameter(cmd, "triggerTimesTriggered", simpleTrigger.TimesTriggered);
		return cmd.ExecuteNonQuery();
	}

	public TriggerPropertyBundle LoadExtendedTriggerProperties(ConnectionAndTransactionHolder conn, TriggerKey triggerKey)
	{
		using IDbCommand cmd = DbAccessor.PrepareCommand(conn, AdoJobStoreUtil.ReplaceTablePrefix(StdAdoConstants.SqlSelectSimpleTrigger, TablePrefix, SchedNameLiteral));
		DbAccessor.AddCommandParameter(cmd, "triggerName", triggerKey.Name);
		DbAccessor.AddCommandParameter(cmd, "triggerGroup", triggerKey.Group);
		using (IDataReader rs = cmd.ExecuteReader())
		{
			if (rs.Read())
			{
				int repeatCount = rs.GetInt32("REPEAT_COUNT");
				TimeSpan repeatInterval = DbAccessor.GetTimeSpanFromDbValue(rs["REPEAT_INTERVAL"]) ?? TimeSpan.Zero;
				int timesTriggered = rs.GetInt32("TIMES_TRIGGERED");
				SimpleScheduleBuilder sb = SimpleScheduleBuilder.Create().WithRepeatCount(repeatCount).WithInterval(repeatInterval);
				string[] statePropertyNames = new string[1] { "timesTriggered" };
				object[] statePropertyValues = new object[1] { timesTriggered };
				return new TriggerPropertyBundle(sb, statePropertyNames, statePropertyValues);
			}
		}
		throw new InvalidOperationException(string.Concat("No record found for selection of Trigger with key: '", triggerKey, "' and statement: ", AdoJobStoreUtil.ReplaceTablePrefix(StdAdoConstants.SqlSelectSimpleTrigger, TablePrefix, SchedNameLiteral)));
	}

	public int UpdateExtendedTriggerProperties(ConnectionAndTransactionHolder conn, IOperableTrigger trigger, string state, IJobDetail jobDetail)
	{
		ISimpleTrigger simpleTrigger = (ISimpleTrigger)trigger;
		using IDbCommand cmd = DbAccessor.PrepareCommand(conn, AdoJobStoreUtil.ReplaceTablePrefix(StdAdoConstants.SqlUpdateSimpleTrigger, TablePrefix, SchedNameLiteral));
		DbAccessor.AddCommandParameter(cmd, "triggerRepeatCount", simpleTrigger.RepeatCount);
		DbAccessor.AddCommandParameter(cmd, "triggerRepeatInterval", DbAccessor.GetDbTimeSpanValue(simpleTrigger.RepeatInterval));
		DbAccessor.AddCommandParameter(cmd, "triggerTimesTriggered", simpleTrigger.TimesTriggered);
		DbAccessor.AddCommandParameter(cmd, "triggerName", trigger.Key.Name);
		DbAccessor.AddCommandParameter(cmd, "triggerGroup", trigger.Key.Group);
		return cmd.ExecuteNonQuery();
	}
}
