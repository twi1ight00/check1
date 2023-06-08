using System;
using System.Data;
using Quartz.Impl.Triggers;
using Quartz.Spi;
using Quartz.Util;

namespace Quartz.Impl.AdoJobStore;

/// <summary>
/// Persist a CronTriggerImpl.
/// </summary>
/// <see cref="T:Quartz.CronScheduleBuilder" />
/// <see cref="T:Quartz.ICronTrigger" />
public class CronTriggerPersistenceDelegate : ITriggerPersistenceDelegate
{
	protected string TablePrefix { get; private set; }

	protected IDbAccessor DbAccessor { get; private set; }

	protected string SchedNameLiteral { get; private set; }

	public void Initialize(string tablePrefix, string schedName, IDbAccessor dbAccessor)
	{
		TablePrefix = tablePrefix;
		SchedNameLiteral = "'" + schedName + "'";
		DbAccessor = dbAccessor;
	}

	public string GetHandledTriggerTypeDiscriminator()
	{
		return "CRON";
	}

	public bool CanHandleTriggerType(IOperableTrigger trigger)
	{
		if (trigger is CronTriggerImpl)
		{
			return !((CronTriggerImpl)trigger).HasAdditionalProperties;
		}
		return false;
	}

	public int DeleteExtendedTriggerProperties(ConnectionAndTransactionHolder conn, TriggerKey triggerKey)
	{
		using IDbCommand cmd = DbAccessor.PrepareCommand(conn, AdoJobStoreUtil.ReplaceTablePrefix(StdAdoConstants.SqlDeleteCronTrigger, TablePrefix, SchedNameLiteral));
		DbAccessor.AddCommandParameter(cmd, "triggerName", triggerKey.Name);
		DbAccessor.AddCommandParameter(cmd, "triggerGroup", triggerKey.Group);
		return cmd.ExecuteNonQuery();
	}

	public int InsertExtendedTriggerProperties(ConnectionAndTransactionHolder conn, IOperableTrigger trigger, string state, IJobDetail jobDetail)
	{
		ICronTrigger cronTrigger = (ICronTrigger)trigger;
		using IDbCommand cmd = DbAccessor.PrepareCommand(conn, AdoJobStoreUtil.ReplaceTablePrefix(StdAdoConstants.SqlInsertCronTrigger, TablePrefix, SchedNameLiteral));
		DbAccessor.AddCommandParameter(cmd, "triggerName", trigger.Key.Name);
		DbAccessor.AddCommandParameter(cmd, "triggerGroup", trigger.Key.Group);
		DbAccessor.AddCommandParameter(cmd, "triggerCronExpression", cronTrigger.CronExpressionString);
		DbAccessor.AddCommandParameter(cmd, "triggerTimeZone", cronTrigger.TimeZone.Id);
		return cmd.ExecuteNonQuery();
	}

	public TriggerPropertyBundle LoadExtendedTriggerProperties(ConnectionAndTransactionHolder conn, TriggerKey triggerKey)
	{
		using IDbCommand cmd = DbAccessor.PrepareCommand(conn, AdoJobStoreUtil.ReplaceTablePrefix(StdAdoConstants.SqlSelectCronTriggers, TablePrefix, SchedNameLiteral));
		DbAccessor.AddCommandParameter(cmd, "triggerName", triggerKey.Name);
		DbAccessor.AddCommandParameter(cmd, "triggerGroup", triggerKey.Group);
		using (IDataReader rs = cmd.ExecuteReader())
		{
			if (rs.Read())
			{
				string cronExpr = rs.GetString("CRON_EXPRESSION");
				string timeZoneId = rs.GetString("TIME_ZONE_ID");
				CronScheduleBuilder cb = CronScheduleBuilder.CronSchedule(cronExpr);
				if (timeZoneId != null)
				{
					cb.InTimeZone(TimeZoneInfo.FindSystemTimeZoneById(timeZoneId));
				}
				return new TriggerPropertyBundle(cb, null, null);
			}
		}
		throw new InvalidOperationException(string.Concat("No record found for selection of Trigger with key: '", triggerKey, "' and statement: ", AdoJobStoreUtil.ReplaceTablePrefix(StdAdoConstants.SqlSelectCronTriggers, TablePrefix, SchedNameLiteral)));
	}

	public int UpdateExtendedTriggerProperties(ConnectionAndTransactionHolder conn, IOperableTrigger trigger, string state, IJobDetail jobDetail)
	{
		ICronTrigger cronTrigger = (ICronTrigger)trigger;
		using IDbCommand cmd = DbAccessor.PrepareCommand(conn, AdoJobStoreUtil.ReplaceTablePrefix(StdAdoConstants.SqlUpdateCronTrigger, TablePrefix, SchedNameLiteral));
		DbAccessor.AddCommandParameter(cmd, "triggerCronExpression", cronTrigger.CronExpressionString);
		DbAccessor.AddCommandParameter(cmd, "timeZoneId", cronTrigger.TimeZone.Id);
		DbAccessor.AddCommandParameter(cmd, "triggerName", trigger.Key.Name);
		DbAccessor.AddCommandParameter(cmd, "triggerGroup", trigger.Key.Group);
		return cmd.ExecuteNonQuery();
	}
}
