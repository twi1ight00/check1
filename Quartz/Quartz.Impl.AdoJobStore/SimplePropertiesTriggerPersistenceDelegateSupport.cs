using System;
using System.Data;
using Quartz.Spi;
using Quartz.Util;

namespace Quartz.Impl.AdoJobStore;

/// <summary>
/// A base implementation of <see cref="T:Quartz.Impl.AdoJobStore.ITriggerPersistenceDelegate" /> that persists
/// trigger fields in the "QRTZ_SIMPROP_TRIGGERS" table.  This allows extending
/// concrete classes to simply implement a couple methods that do the work of
/// getting/setting the trigger's fields, and creating the <see cref="T:Quartz.IScheduleBuilder" />
/// for the particular type of trigger.
/// </summary>
/// <seealso cref="T:Quartz.Impl.AdoJobStore.CalendarIntervalTriggerPersistenceDelegate" />
/// <author>jhouse</author>
/// <author>Marko Lahma (.NET)</author>
public abstract class SimplePropertiesTriggerPersistenceDelegateSupport : ITriggerPersistenceDelegate
{
	protected const string TableSimplePropertiesTriggers = "SIMPROP_TRIGGERS";

	protected const string ColumnStrProp1 = "STR_PROP_1";

	protected const string ColumnStrProp2 = "STR_PROP_2";

	protected const string ColumnStrProp3 = "STR_PROP_3";

	protected const string ColumnIntProp1 = "INT_PROP_1";

	protected const string ColumnIntProp2 = "INT_PROP_2";

	protected const string ColumnLongProp1 = "LONG_PROP_1";

	protected const string ColumnLongProp2 = "LONG_PROP_2";

	protected const string ColumnDecProp1 = "DEC_PROP_1";

	protected const string ColumnDecProp2 = "DEC_PROP_2";

	protected const string ColumnBoolProp1 = "BOOL_PROP_1";

	protected const string ColumnBoolProp2 = "BOOL_PROP_2";

	protected const string SelectSimplePropsTrigger = "SELECT * FROM {0}SIMPROP_TRIGGERS WHERE SCHED_NAME = {1} AND TRIGGER_NAME = @triggerName AND TRIGGER_GROUP = @triggerGroup";

	protected const string DeleteSimplePropsTrigger = "DELETE FROM {0}SIMPROP_TRIGGERS WHERE SCHED_NAME = {1} AND TRIGGER_NAME = @triggerName AND TRIGGER_GROUP = @triggerGroup";

	protected const string InsertSimplePropsTrigger = "INSERT INTO {0}SIMPROP_TRIGGERS (SCHED_NAME, TRIGGER_NAME, TRIGGER_GROUP, STR_PROP_1, STR_PROP_2, STR_PROP_3, INT_PROP_1, INT_PROP_2, LONG_PROP_1, LONG_PROP_2, DEC_PROP_1, DEC_PROP_2, BOOL_PROP_1, BOOL_PROP_2)  VALUES({1}, @triggerName, @triggerGroup, @string1, @string2, @string3, @int1, @int2, @long1, @long2, @decimal1, @decimal2, @boolean1, @boolean2)";

	protected const string UpdateSimplePropsTrigger = "UPDATE {0}SIMPROP_TRIGGERS SET STR_PROP_1 = @string1, STR_PROP_2 = @string2, STR_PROP_3 = @string3, INT_PROP_1 = @int1, INT_PROP_2 = @int2, LONG_PROP_1 = @long1, LONG_PROP_2 = @long2, DEC_PROP_1 = @decimal1, DEC_PROP_2 = @decimal2, BOOL_PROP_1 = @boolean1, BOOL_PROP_2 = @boolean2 WHERE SCHED_NAME = {1} AND TRIGGER_NAME = @triggerName AND TRIGGER_GROUP = @triggerGroup";

	protected string TablePrefix { get; private set; }

	protected string SchedNameLiteral { get; private set; }

	protected IDbAccessor DbAccessor { get; private set; }

	public void Initialize(string tablePrefix, string schedName, IDbAccessor dbAccessor)
	{
		TablePrefix = tablePrefix;
		DbAccessor = dbAccessor;
		SchedNameLiteral = "'" + schedName + "'";
	}

	/// <summary>
	/// Returns whether the trigger type can be handled by delegate.
	/// </summary>
	public abstract bool CanHandleTriggerType(IOperableTrigger trigger);

	/// <summary>
	/// Returns database discriminator value for trigger type.
	/// </summary>
	public abstract string GetHandledTriggerTypeDiscriminator();

	protected abstract SimplePropertiesTriggerProperties GetTriggerProperties(IOperableTrigger trigger);

	protected abstract TriggerPropertyBundle GetTriggerPropertyBundle(SimplePropertiesTriggerProperties properties);

	public int DeleteExtendedTriggerProperties(ConnectionAndTransactionHolder conn, TriggerKey triggerKey)
	{
		using IDbCommand cmd = DbAccessor.PrepareCommand(conn, AdoJobStoreUtil.ReplaceTablePrefix("DELETE FROM {0}SIMPROP_TRIGGERS WHERE SCHED_NAME = {1} AND TRIGGER_NAME = @triggerName AND TRIGGER_GROUP = @triggerGroup", TablePrefix, SchedNameLiteral));
		DbAccessor.AddCommandParameter(cmd, "triggerName", triggerKey.Name);
		DbAccessor.AddCommandParameter(cmd, "triggerGroup", triggerKey.Group);
		return cmd.ExecuteNonQuery();
	}

	public int InsertExtendedTriggerProperties(ConnectionAndTransactionHolder conn, IOperableTrigger trigger, string state, IJobDetail jobDetail)
	{
		SimplePropertiesTriggerProperties properties = GetTriggerProperties(trigger);
		using IDbCommand cmd = DbAccessor.PrepareCommand(conn, AdoJobStoreUtil.ReplaceTablePrefix("INSERT INTO {0}SIMPROP_TRIGGERS (SCHED_NAME, TRIGGER_NAME, TRIGGER_GROUP, STR_PROP_1, STR_PROP_2, STR_PROP_3, INT_PROP_1, INT_PROP_2, LONG_PROP_1, LONG_PROP_2, DEC_PROP_1, DEC_PROP_2, BOOL_PROP_1, BOOL_PROP_2)  VALUES({1}, @triggerName, @triggerGroup, @string1, @string2, @string3, @int1, @int2, @long1, @long2, @decimal1, @decimal2, @boolean1, @boolean2)", TablePrefix, SchedNameLiteral));
		DbAccessor.AddCommandParameter(cmd, "triggerName", trigger.Key.Name);
		DbAccessor.AddCommandParameter(cmd, "triggerGroup", trigger.Key.Group);
		DbAccessor.AddCommandParameter(cmd, "string1", properties.String1);
		DbAccessor.AddCommandParameter(cmd, "string2", properties.String2);
		DbAccessor.AddCommandParameter(cmd, "string3", properties.String3);
		DbAccessor.AddCommandParameter(cmd, "int1", properties.Int1);
		DbAccessor.AddCommandParameter(cmd, "int2", properties.Int2);
		DbAccessor.AddCommandParameter(cmd, "long1", properties.Long1);
		DbAccessor.AddCommandParameter(cmd, "long2", properties.Long2);
		DbAccessor.AddCommandParameter(cmd, "decimal1", properties.Decimal1);
		DbAccessor.AddCommandParameter(cmd, "decimal2", properties.Decimal2);
		DbAccessor.AddCommandParameter(cmd, "boolean1", DbAccessor.GetDbBooleanValue(properties.Boolean1));
		DbAccessor.AddCommandParameter(cmd, "boolean2", DbAccessor.GetDbBooleanValue(properties.Boolean2));
		return cmd.ExecuteNonQuery();
	}

	public TriggerPropertyBundle LoadExtendedTriggerProperties(ConnectionAndTransactionHolder conn, TriggerKey triggerKey)
	{
		using (IDbCommand cmd = DbAccessor.PrepareCommand(conn, AdoJobStoreUtil.ReplaceTablePrefix("SELECT * FROM {0}SIMPROP_TRIGGERS WHERE SCHED_NAME = {1} AND TRIGGER_NAME = @triggerName AND TRIGGER_GROUP = @triggerGroup", TablePrefix, SchedNameLiteral)))
		{
			DbAccessor.AddCommandParameter(cmd, "triggerName", triggerKey.Name);
			DbAccessor.AddCommandParameter(cmd, "triggerGroup", triggerKey.Group);
			using IDataReader rs = cmd.ExecuteReader();
			if (rs.Read())
			{
				SimplePropertiesTriggerProperties properties = new SimplePropertiesTriggerProperties();
				properties.String1 = rs.GetString("STR_PROP_1");
				properties.String2 = rs.GetString("STR_PROP_2");
				properties.String3 = rs.GetString("STR_PROP_3");
				properties.Int1 = rs.GetInt32("INT_PROP_1");
				properties.Int2 = rs.GetInt32("INT_PROP_2");
				properties.Long1 = rs.GetInt32("LONG_PROP_1");
				properties.Long2 = rs.GetInt32("LONG_PROP_2");
				properties.Decimal1 = rs.GetDecimal("DEC_PROP_1");
				properties.Decimal2 = rs.GetDecimal("DEC_PROP_2");
				properties.Boolean1 = DbAccessor.GetBooleanFromDbValue(rs["BOOL_PROP_1"]);
				properties.Boolean2 = DbAccessor.GetBooleanFromDbValue(rs["BOOL_PROP_2"]);
				return GetTriggerPropertyBundle(properties);
			}
		}
		throw new InvalidOperationException(string.Concat("No record found for selection of Trigger with key: '", triggerKey, "' and statement: ", AdoJobStoreUtil.ReplaceTablePrefix(StdAdoConstants.SqlSelectSimpleTrigger, TablePrefix, SchedNameLiteral)));
	}

	public int UpdateExtendedTriggerProperties(ConnectionAndTransactionHolder conn, IOperableTrigger trigger, string state, IJobDetail jobDetail)
	{
		SimplePropertiesTriggerProperties properties = GetTriggerProperties(trigger);
		using IDbCommand cmd = DbAccessor.PrepareCommand(conn, AdoJobStoreUtil.ReplaceTablePrefix("UPDATE {0}SIMPROP_TRIGGERS SET STR_PROP_1 = @string1, STR_PROP_2 = @string2, STR_PROP_3 = @string3, INT_PROP_1 = @int1, INT_PROP_2 = @int2, LONG_PROP_1 = @long1, LONG_PROP_2 = @long2, DEC_PROP_1 = @decimal1, DEC_PROP_2 = @decimal2, BOOL_PROP_1 = @boolean1, BOOL_PROP_2 = @boolean2 WHERE SCHED_NAME = {1} AND TRIGGER_NAME = @triggerName AND TRIGGER_GROUP = @triggerGroup", TablePrefix, SchedNameLiteral));
		DbAccessor.AddCommandParameter(cmd, "string1", properties.String1);
		DbAccessor.AddCommandParameter(cmd, "string2", properties.String2);
		DbAccessor.AddCommandParameter(cmd, "string3", properties.String3);
		DbAccessor.AddCommandParameter(cmd, "int1", properties.Int1);
		DbAccessor.AddCommandParameter(cmd, "int2", properties.Int2);
		DbAccessor.AddCommandParameter(cmd, "long1", properties.Long1);
		DbAccessor.AddCommandParameter(cmd, "long2", properties.Long2);
		DbAccessor.AddCommandParameter(cmd, "decimal1", properties.Decimal1);
		DbAccessor.AddCommandParameter(cmd, "decimal2", properties.Decimal2);
		DbAccessor.AddCommandParameter(cmd, "boolean1", DbAccessor.GetDbBooleanValue(properties.Boolean1));
		DbAccessor.AddCommandParameter(cmd, "boolean2", DbAccessor.GetDbBooleanValue(properties.Boolean2));
		DbAccessor.AddCommandParameter(cmd, "triggerName", trigger.Key.Name);
		DbAccessor.AddCommandParameter(cmd, "triggerGroup", trigger.Key.Group);
		return cmd.ExecuteNonQuery();
	}
}
