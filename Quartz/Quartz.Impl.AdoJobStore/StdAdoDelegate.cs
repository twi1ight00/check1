using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using Common.Logging;
using Quartz.Collection;
using Quartz.Impl.AdoJobStore.Common;
using Quartz.Impl.Matchers;
using Quartz.Impl.Triggers;
using Quartz.Spi;
using Quartz.Util;

namespace Quartz.Impl.AdoJobStore;

/// <summary>
/// This is meant to be an abstract base class for most, if not all, <see cref="T:Quartz.Impl.AdoJobStore.IDriverDelegate" />
/// implementations. Subclasses should override only those methods that need
/// special handling for the DBMS driver in question.
/// </summary>
/// <author><a href="mailto:jeff@binaryfeed.org">Jeffrey Wescott</a></author>
/// <author>James House</author>
/// <author>Marko Lahma (.NET)</author>
public class StdAdoDelegate : StdAdoConstants, IDriverDelegate, IDbAccessor
{
	private ILog logger;

	private string tablePrefix = "QRTZ_";

	private string instanceId;

	private string schedName;

	private bool useProperties;

	private IDbProvider dbProvider;

	private ITypeLoadHelper typeLoadHelper;

	private AdoUtil adoUtil;

	private readonly IList<ITriggerPersistenceDelegate> triggerPersistenceDelegates = new List<ITriggerPersistenceDelegate>();

	private string schedNameLiteral;

	private IObjectSerializer objectSerializer;

	protected virtual bool CanUseProperties => useProperties;

	protected string SchedulerNameLiteral
	{
		get
		{
			if (schedNameLiteral == null)
			{
				schedNameLiteral = "'" + schedName + "'";
			}
			return schedNameLiteral;
		}
	}

	/// <summary>
	/// Initializes the driver delegate.
	/// </summary>
	public virtual void Initialize(DelegateInitializationArgs args)
	{
		logger = args.Logger;
		tablePrefix = args.TablePrefix;
		schedName = args.InstanceName;
		instanceId = args.InstanceId;
		dbProvider = args.DbProvider;
		typeLoadHelper = args.TypeLoadHelper;
		useProperties = args.UseProperties;
		adoUtil = new AdoUtil(args.DbProvider);
		objectSerializer = args.ObjectSerializer;
		AddDefaultTriggerPersistenceDelegates();
		if (string.IsNullOrEmpty(args.InitString))
		{
			return;
		}
		string[] settings = args.InitString.Split('\\', '|');
		string[] array = settings;
		foreach (string setting in array)
		{
			string[] parts = setting.Split('=');
			string name = parts[0];
			if (parts.Length == 1 || parts[1] == null || parts[1].Equals(""))
			{
				continue;
			}
			if (name.Equals("triggerPersistenceDelegateClasses"))
			{
				string[] trigDelegates = parts[1].Split(',');
				string[] array2 = trigDelegates;
				foreach (string triggerTypeName in array2)
				{
					try
					{
						Type trigDelClass = typeLoadHelper.LoadType(triggerTypeName);
						AddTriggerPersistenceDelegate((ITriggerPersistenceDelegate)Activator.CreateInstance(trigDelClass));
					}
					catch (Exception e)
					{
						throw new NoSuchDelegateException("Error instantiating TriggerPersistenceDelegate of type: " + triggerTypeName, e);
					}
				}
				continue;
			}
			throw new NoSuchDelegateException("Unknown setting: '" + name + "'");
		}
	}

	protected virtual void AddDefaultTriggerPersistenceDelegates()
	{
		AddTriggerPersistenceDelegate(new SimpleTriggerPersistenceDelegate());
		AddTriggerPersistenceDelegate(new CronTriggerPersistenceDelegate());
		AddTriggerPersistenceDelegate(new CalendarIntervalTriggerPersistenceDelegate());
		AddTriggerPersistenceDelegate(new DailyTimeIntervalTriggerPersistenceDelegate());
	}

	public virtual void AddTriggerPersistenceDelegate(ITriggerPersistenceDelegate del)
	{
		logger.Debug("Adding TriggerPersistenceDelegate of type: " + del.GetType());
		del.Initialize(tablePrefix, schedName, this);
		triggerPersistenceDelegates.Add(del);
	}

	public virtual ITriggerPersistenceDelegate FindTriggerPersistenceDelegate(IOperableTrigger trigger)
	{
		return triggerPersistenceDelegates.FirstOrDefault((ITriggerPersistenceDelegate del) => del.CanHandleTriggerType(trigger));
	}

	public virtual ITriggerPersistenceDelegate FindTriggerPersistenceDelegate(string discriminator)
	{
		return triggerPersistenceDelegates.FirstOrDefault((ITriggerPersistenceDelegate del) => del.GetHandledTriggerTypeDiscriminator() == discriminator);
	}

	/// <summary>
	/// Insert the job detail record.
	/// </summary>
	/// <param name="conn">the DB Connection</param>
	/// <param name="newState">the new state for the triggers</param>
	/// <param name="oldState1">the first old state to update</param>
	/// <param name="oldState2">the second old state to update</param>
	/// <returns>number of rows updated</returns>
	public virtual int UpdateTriggerStatesFromOtherStates(ConnectionAndTransactionHolder conn, string newState, string oldState1, string oldState2)
	{
		using IDbCommand cmd = PrepareCommand(conn, ReplaceTablePrefix(StdAdoConstants.SqlUpdateTriggerStatesFromOtherStates));
		AddCommandParameter(cmd, "newState", newState);
		AddCommandParameter(cmd, "oldState1", oldState1);
		AddCommandParameter(cmd, "oldState2", oldState2);
		return cmd.ExecuteNonQuery();
	}

	/// <summary>
	/// Get the names of all of the triggers that have misfired.
	/// </summary>
	/// <param name="conn">the DB Connection</param>
	/// <param name="ts">The ts.</param>
	/// <returns>an array of <see cref="T:Quartz.TriggerKey" /> objects</returns>
	public virtual IList<TriggerKey> SelectMisfiredTriggers(ConnectionAndTransactionHolder conn, DateTimeOffset ts)
	{
		using IDbCommand cmd = PrepareCommand(conn, ReplaceTablePrefix(StdAdoConstants.SqlSelectMisfiredTriggers));
		AddCommandParameter(cmd, "timestamp", GetDbDateTimeValue(ts));
		using IDataReader rs = cmd.ExecuteReader();
		List<TriggerKey> list = new List<TriggerKey>();
		while (rs.Read())
		{
			string triggerName = rs.GetString("TRIGGER_NAME");
			string groupName = rs.GetString("TRIGGER_GROUP");
			list.Add(new TriggerKey(triggerName, groupName));
		}
		return list;
	}

	/// <summary> 
	/// Select all of the triggers in a given state.
	/// </summary>
	/// <param name="conn">The DB Connection</param>
	/// <param name="state">The state the triggers must be in</param>
	/// <returns> an array of trigger <see cref="T:Quartz.TriggerKey" />s </returns>
	public virtual IList<TriggerKey> SelectTriggersInState(ConnectionAndTransactionHolder conn, string state)
	{
		using IDbCommand cmd = PrepareCommand(conn, ReplaceTablePrefix(StdAdoConstants.SqlSelectTriggersInState));
		AddCommandParameter(cmd, "state", state);
		using IDataReader rs = cmd.ExecuteReader();
		List<TriggerKey> list = new List<TriggerKey>();
		while (rs.Read())
		{
			list.Add(new TriggerKey(rs.GetString(0), rs.GetString(1)));
		}
		return list;
	}

	/// <summary>
	/// Get the names of all of the triggers in the given state that have
	/// misfired - according to the given timestamp.
	/// </summary>
	/// <param name="conn">The DB Connection</param>
	/// <param name="state">The state.</param>
	/// <param name="ts">The time stamp.</param>
	/// <returns>An array of <see cref="T:Quartz.TriggerKey" /> objects</returns>
	public virtual IList<TriggerKey> HasMisfiredTriggersInState(ConnectionAndTransactionHolder conn, string state, DateTimeOffset ts)
	{
		using IDbCommand cmd = PrepareCommand(conn, ReplaceTablePrefix(StdAdoConstants.SqlSelectMisfiredTriggersInState));
		AddCommandParameter(cmd, "timestamp", GetDbDateTimeValue(ts));
		AddCommandParameter(cmd, "state", state);
		using IDataReader rs = cmd.ExecuteReader();
		List<TriggerKey> list = new List<TriggerKey>();
		while (rs.Read())
		{
			string triggerName = rs.GetString("TRIGGER_NAME");
			string groupName = rs.GetString("TRIGGER_GROUP");
			list.Add(new TriggerKey(triggerName, groupName));
		}
		return list;
	}

	/// <summary>
	/// Get the names of all of the triggers in the given state that have
	/// misfired - according to the given timestamp.  No more than count will
	/// be returned.
	/// </summary>
	/// <param name="conn">The conn.</param>
	/// <param name="state1">The state1.</param>
	/// <param name="ts">The ts.</param>
	/// <param name="count">The most misfired triggers to return, negative for all</param>
	/// <param name="resultList">
	///   Output parameter.  A List of <see cref="T:Quartz.TriggerKey" /> objects.  Must not be null
	/// </param>
	/// <returns>Whether there are more misfired triggers left to find beyond the given count.</returns>
	public virtual bool HasMisfiredTriggersInState(ConnectionAndTransactionHolder conn, string state1, DateTimeOffset ts, int count, IList<TriggerKey> resultList)
	{
		using IDbCommand cmd = PrepareCommand(conn, ReplaceTablePrefix(StdAdoConstants.SqlSelectHasMisfiredTriggersInState));
		AddCommandParameter(cmd, "nextFireTime", GetDbDateTimeValue(ts));
		AddCommandParameter(cmd, "state1", state1);
		using IDataReader rs = cmd.ExecuteReader();
		bool hasReachedLimit = false;
		while (rs.Read() && !hasReachedLimit)
		{
			if (resultList.Count == count)
			{
				hasReachedLimit = true;
				continue;
			}
			string triggerName = rs.GetString("TRIGGER_NAME");
			string groupName = rs.GetString("TRIGGER_GROUP");
			resultList.Add(new TriggerKey(triggerName, groupName));
		}
		return hasReachedLimit;
	}

	/// <summary>
	/// Get the number of triggers in the given state that have
	/// misfired - according to the given timestamp.
	/// </summary>
	/// <param name="conn"></param>
	/// <param name="state1"></param>
	/// <param name="ts"></param>
	/// <returns></returns>
	public int CountMisfiredTriggersInState(ConnectionAndTransactionHolder conn, string state1, DateTimeOffset ts)
	{
		using IDbCommand cmd = PrepareCommand(conn, ReplaceTablePrefix(StdAdoConstants.SqlCountMisfiredTriggersInStates));
		AddCommandParameter(cmd, "nextFireTime", GetDbDateTimeValue(ts));
		AddCommandParameter(cmd, "state1", state1);
		using (IDataReader rs = cmd.ExecuteReader())
		{
			if (rs.Read())
			{
				return Convert.ToInt32(rs.GetValue(0), CultureInfo.InvariantCulture);
			}
		}
		throw new Exception("No misfired trigger count returned.");
	}

	/// <summary>
	/// Get the names of all of the triggers in the given group and state that
	/// have misfired.
	/// </summary>
	/// <param name="conn">The DB Connection</param>
	/// <param name="groupName">Name of the group.</param>
	/// <param name="state">The state.</param>
	/// <param name="ts">The timestamp.</param>
	/// <returns>an array of <see cref="T:Quartz.TriggerKey" /> objects</returns>
	public virtual IList<TriggerKey> SelectMisfiredTriggersInGroupInState(ConnectionAndTransactionHolder conn, string groupName, string state, DateTimeOffset ts)
	{
		using IDbCommand cmd = PrepareCommand(conn, ReplaceTablePrefix(StdAdoConstants.SqlSelectMisfiredTriggersInGroupInState));
		AddCommandParameter(cmd, "timestamp", GetDbDateTimeValue(ts));
		AddCommandParameter(cmd, "triggerGroup", groupName);
		AddCommandParameter(cmd, "state", state);
		using IDataReader rs = cmd.ExecuteReader();
		List<TriggerKey> list = new List<TriggerKey>();
		while (rs.Read())
		{
			string triggerName = rs.GetString("TRIGGER_NAME");
			list.Add(new TriggerKey(triggerName, groupName));
		}
		return list;
	}

	/// <summary>
	/// Select all of the triggers for jobs that are requesting recovery. The
	/// returned trigger objects will have unique "recoverXXX" trigger names and
	/// will be in the <see cref="F:Quartz.SchedulerConstants.DefaultRecoveryGroup" />
	/// trigger group.
	/// </summary>
	/// <remarks>
	/// In order to preserve the ordering of the triggers, the fire time will be
	/// set from the <i>ColumnFiredTime</i> column in the <i>TableFiredTriggers</i>
	/// table. The caller is responsible for calling <see cref="M:Quartz.Spi.IOperableTrigger.ComputeFirstFireTimeUtc(Quartz.ICalendar)" />
	/// on each returned trigger. It is also up to the caller to insert the
	/// returned triggers to ensure that they are fired.
	/// </remarks>
	/// <param name="conn">The DB Connection</param>
	/// <returns> an array of <see cref="T:Quartz.ITrigger" /> objects</returns>
	public virtual IList<IOperableTrigger> SelectTriggersForRecoveringJobs(ConnectionAndTransactionHolder conn)
	{
		List<IOperableTrigger> list = new List<IOperableTrigger>();
		List<TriggerKey> keys = new List<TriggerKey>();
		using (IDbCommand cmd = PrepareCommand(conn, ReplaceTablePrefix(StdAdoConstants.SqlSelectInstancesRecoverableFiredTriggers)))
		{
			AddCommandParameter(cmd, "instanceName", instanceId);
			AddCommandParameter(cmd, "requestsRecovery", GetDbBooleanValue(booleanValue: true));
			using IDataReader rs = cmd.ExecuteReader();
			long dumId = SystemTime.UtcNow().Ticks;
			while (rs.Read())
			{
				string jobName = rs.GetString("JOB_NAME");
				string jobGroup = rs.GetString("JOB_GROUP");
				string trigName = rs.GetString("TRIGGER_NAME");
				string trigGroup = rs.GetString("TRIGGER_GROUP");
				int priority = Convert.ToInt32(rs["PRIORITY"], CultureInfo.InvariantCulture);
				DateTimeOffset firedTime = GetDateTimeFromDbValue(rs["FIRED_TIME"]) ?? DateTimeOffset.MinValue;
				SimpleTriggerImpl rcvryTrig = new SimpleTriggerImpl("recover_" + instanceId + "_" + Convert.ToString(dumId++, CultureInfo.InvariantCulture), "RECOVERING_JOBS", firedTime);
				rcvryTrig.JobName = jobName;
				rcvryTrig.JobGroup = jobGroup;
				rcvryTrig.Priority = priority;
				rcvryTrig.MisfireInstruction = 1;
				list.Add(rcvryTrig);
				keys.Add(new TriggerKey(trigName, trigGroup));
			}
		}
		for (int i = 0; i < list.Count; i++)
		{
			IOperableTrigger trigger = list[i];
			TriggerKey key = keys[i];
			JobDataMap jd = SelectTriggerJobDataMap(conn, key);
			jd.Put("QRTZ_FAILED_JOB_ORIG_TRIGGER_NAME", key.Name);
			jd.Put("QRTZ_FAILED_JOB_ORIG_TRIGGER_GROUP", key.Group);
			jd.Put("QRTZ_FAILED_JOB_ORIG_TRIGGER_FIRETIME_IN_MILLISECONDS_AS_STRING", Convert.ToString(trigger.StartTimeUtc, CultureInfo.InvariantCulture));
			trigger.JobDataMap = jd;
		}
		return list;
	}

	/// <summary>
	/// Delete all fired triggers.
	/// </summary>
	/// <param name="conn">The DB Connection.</param>
	/// <returns>The number of rows deleted.</returns>
	public virtual int DeleteFiredTriggers(ConnectionAndTransactionHolder conn)
	{
		using IDbCommand cmd = PrepareCommand(conn, ReplaceTablePrefix(StdAdoConstants.SqlDeleteFiredTriggers));
		return cmd.ExecuteNonQuery();
	}

	/// <summary>
	/// Delete all fired triggers of the given instance.
	/// </summary>
	/// <param name="conn">The DB Connection</param>
	/// <param name="instanceName">The instance id.</param>
	/// <returns>The number of rows deleted</returns>
	public virtual int DeleteFiredTriggers(ConnectionAndTransactionHolder conn, string instanceName)
	{
		using IDbCommand cmd = PrepareCommand(conn, ReplaceTablePrefix(StdAdoConstants.SqlDeleteInstancesFiredTriggers));
		AddCommandParameter(cmd, "instanceName", instanceName);
		return cmd.ExecuteNonQuery();
	}

	/// <summary>
	/// Clear (delete!) all scheduling data - all <see cref="T:Quartz.IJob" />s, <see cref="T:Quartz.ITrigger" />s
	/// <see cref="T:Quartz.ICalendar" />s.
	/// </summary>
	/// <remarks>
	/// </remarks>
	public void ClearData(ConnectionAndTransactionHolder conn)
	{
		IDbCommand ps = PrepareCommand(conn, ReplaceTablePrefix(StdAdoConstants.SqlDeleteAllSimpleTriggers));
		ps.ExecuteNonQuery();
		ps = PrepareCommand(conn, ReplaceTablePrefix(StdAdoConstants.SqlDeleteAllSimpropTriggers));
		ps.ExecuteNonQuery();
		ps = PrepareCommand(conn, ReplaceTablePrefix(StdAdoConstants.SqlDeleteAllCronTriggers));
		ps.ExecuteNonQuery();
		ps = PrepareCommand(conn, ReplaceTablePrefix(StdAdoConstants.SqlDeleteAllBlobTriggers));
		ps.ExecuteNonQuery();
		ps = PrepareCommand(conn, ReplaceTablePrefix(StdAdoConstants.SqlDeleteAllTriggers));
		ps.ExecuteNonQuery();
		ps = PrepareCommand(conn, ReplaceTablePrefix(StdAdoConstants.SqlDeleteAllJobDetails));
		ps.ExecuteNonQuery();
		ps = PrepareCommand(conn, ReplaceTablePrefix(StdAdoConstants.SqlDeleteAllCalendars));
		ps.ExecuteNonQuery();
		ps = PrepareCommand(conn, ReplaceTablePrefix(StdAdoConstants.SqlDeleteAllPausedTriggerGrps));
		ps.ExecuteNonQuery();
	}

	/// <summary>
	/// Insert the job detail record.
	/// </summary>
	/// <param name="conn">The DB Connection.</param>
	/// <param name="job">The job to insert.</param>
	/// <returns>Number of rows inserted.</returns>
	public virtual int InsertJobDetail(ConnectionAndTransactionHolder conn, IJobDetail job)
	{
		byte[] baos = SerializeJobData(job.JobDataMap);
		using IDbCommand cmd = PrepareCommand(conn, ReplaceTablePrefix(StdAdoConstants.SqlInsertJobDetail));
		AddCommandParameter(cmd, "jobName", job.Key.Name);
		AddCommandParameter(cmd, "jobGroup", job.Key.Group);
		AddCommandParameter(cmd, "jobDescription", job.Description);
		AddCommandParameter(cmd, "jobType", GetStorableJobTypeName(job.JobType));
		AddCommandParameter(cmd, "jobDurable", GetDbBooleanValue(job.Durable));
		AddCommandParameter(cmd, "jobVolatile", GetDbBooleanValue(job.ConcurrentExecutionDisallowed));
		AddCommandParameter(cmd, "jobStateful", GetDbBooleanValue(job.PersistJobDataAfterExecution));
		AddCommandParameter(cmd, "jobRequestsRecovery", GetDbBooleanValue(job.RequestsRecovery));
		AddCommandParameter(cmd, "jobDataMap", baos, dbProvider.Metadata.DbBinaryType);
		return cmd.ExecuteNonQuery();
	}

	/// <summary>
	/// Gets the db presentation for boolean value. Subclasses can overwrite this behaviour.
	/// </summary>
	/// <param name="booleanValue">Value to map to database.</param>
	/// <returns></returns>
	public virtual object GetDbBooleanValue(bool booleanValue)
	{
		return booleanValue;
	}

	/// <summary>
	/// Gets the boolean value from db presentation. Subclasses can overwrite this behaviour.
	/// </summary>
	/// <param name="columnValue">Value to map from database.</param>
	/// <returns></returns>
	public virtual bool GetBooleanFromDbValue(object columnValue)
	{
		if (columnValue != null && columnValue != DBNull.Value)
		{
			return Convert.ToBoolean(columnValue);
		}
		throw new ArgumentException("Value must be non-null.");
	}

	/// <summary>
	/// Gets the db presentation for date/time value. Subclasses can overwrite this behaviour.
	/// </summary>
	/// <param name="dateTimeValue">Value to map to database.</param>
	/// <returns></returns>
	public virtual object GetDbDateTimeValue(DateTimeOffset? dateTimeValue)
	{
		if (dateTimeValue.HasValue)
		{
			return dateTimeValue.Value.UtcTicks;
		}
		return null;
	}

	/// <summary>
	/// Gets the date/time value from db presentation. Subclasses can overwrite this behaviour.
	/// </summary>
	/// <param name="columnValue">Value to map from database.</param>
	/// <returns></returns>
	public virtual DateTimeOffset? GetDateTimeFromDbValue(object columnValue)
	{
		if (columnValue != null && columnValue != DBNull.Value)
		{
			long ticks = Convert.ToInt64(columnValue, CultureInfo.CurrentCulture);
			if (ticks > 0)
			{
				return new DateTimeOffset(ticks, TimeSpan.Zero);
			}
		}
		return null;
	}

	/// <summary>
	/// Gets the db presentation for time span value. Subclasses can overwrite this behaviour.
	/// </summary>
	/// <param name="timeSpanValue">Value to map to database.</param>
	/// <returns></returns>
	public virtual object GetDbTimeSpanValue(TimeSpan? timeSpanValue)
	{
		return timeSpanValue.HasValue ? new long?((long)timeSpanValue.Value.TotalMilliseconds) : null;
	}

	/// <summary>
	/// Gets the time span value from db presentation. Subclasses can overwrite this behaviour.
	/// </summary>
	/// <param name="columnValue">Value to map from database.</param>
	/// <returns></returns>
	public virtual TimeSpan? GetTimeSpanFromDbValue(object columnValue)
	{
		if (columnValue != null && columnValue != DBNull.Value)
		{
			long millis = Convert.ToInt64(columnValue, CultureInfo.CurrentCulture);
			if (millis > 0)
			{
				return TimeSpan.FromMilliseconds(millis);
			}
		}
		return null;
	}

	protected virtual string GetStorableJobTypeName(Type jobType)
	{
		if (jobType.AssemblyQualifiedName == null)
		{
			throw new ArgumentException("Cannot determine job type name when type's AssemblyQualifiedName is null");
		}
		int idx = jobType.AssemblyQualifiedName.IndexOf(',');
		idx = jobType.AssemblyQualifiedName.IndexOf(',', idx + 1);
		return jobType.AssemblyQualifiedName.Substring(0, idx);
	}

	/// <summary>
	/// Update the job detail record.
	/// </summary>
	/// <param name="conn">The DB Connection.</param>
	/// <param name="job">The job to update.</param>
	/// <returns>Number of rows updated.</returns>
	public virtual int UpdateJobDetail(ConnectionAndTransactionHolder conn, IJobDetail job)
	{
		byte[] baos = SerializeJobData(job.JobDataMap);
		using IDbCommand cmd = PrepareCommand(conn, ReplaceTablePrefix(StdAdoConstants.SqlUpdateJobDetail));
		AddCommandParameter(cmd, "jobDescription", job.Description);
		AddCommandParameter(cmd, "jobType", GetStorableJobTypeName(job.JobType));
		AddCommandParameter(cmd, "jobDurable", GetDbBooleanValue(job.Durable));
		AddCommandParameter(cmd, "jobVolatile", GetDbBooleanValue(job.ConcurrentExecutionDisallowed));
		AddCommandParameter(cmd, "jobStateful", GetDbBooleanValue(job.PersistJobDataAfterExecution));
		AddCommandParameter(cmd, "jobRequestsRecovery", GetDbBooleanValue(job.RequestsRecovery));
		AddCommandParameter(cmd, "jobDataMap", baos, dbProvider.Metadata.DbBinaryType);
		AddCommandParameter(cmd, "jobName", job.Key.Name);
		AddCommandParameter(cmd, "jobGroup", job.Key.Group);
		return cmd.ExecuteNonQuery();
	}

	/// <summary>
	/// Get the names of all of the triggers associated with the given job.
	/// </summary>
	/// <param name="conn">The DB Connection.</param>
	/// <param name="jobKey">The key identifying the job.</param>
	/// <returns>An array of <see cref="T:Quartz.TriggerKey" /> objects</returns>
	public virtual IList<TriggerKey> SelectTriggerNamesForJob(ConnectionAndTransactionHolder conn, JobKey jobKey)
	{
		using IDbCommand cmd = PrepareCommand(conn, ReplaceTablePrefix(StdAdoConstants.SqlSelectTriggersForJob));
		AddCommandParameter(cmd, "jobName", jobKey.Name);
		AddCommandParameter(cmd, "jobGroup", jobKey.Group);
		using IDataReader rs = cmd.ExecuteReader();
		List<TriggerKey> list = new List<TriggerKey>(10);
		while (rs.Read())
		{
			string trigName = rs.GetString("TRIGGER_NAME");
			string trigGroup = rs.GetString("TRIGGER_GROUP");
			list.Add(new TriggerKey(trigName, trigGroup));
		}
		return list;
	}

	/// <summary>
	/// Delete the job detail record for the given job.
	/// </summary>
	/// <param name="conn">the DB Connection</param>
	/// <param name="jobKey">The key identifying the job.</param>
	/// <returns>the number of rows deleted</returns>
	public virtual int DeleteJobDetail(ConnectionAndTransactionHolder conn, JobKey jobKey)
	{
		using IDbCommand cmd = PrepareCommand(conn, ReplaceTablePrefix(StdAdoConstants.SqlDeleteJobDetail));
		if (logger.IsDebugEnabled)
		{
			logger.Debug("Deleting job: " + jobKey);
		}
		AddCommandParameter(cmd, "jobName", jobKey.Name);
		AddCommandParameter(cmd, "jobGroup", jobKey.Group);
		return cmd.ExecuteNonQuery();
	}

	/// <summary>
	/// Check whether or not the given job is stateful.
	/// </summary>
	/// <param name="conn">the DB Connection</param>
	/// <param name="jobKey">The key identifying the job.</param>
	/// <returns>
	/// true if the job exists and is stateful, false otherwise
	/// </returns>
	public virtual bool IsJobStateful(ConnectionAndTransactionHolder conn, JobKey jobKey)
	{
		using IDbCommand cmd = PrepareCommand(conn, ReplaceTablePrefix(StdAdoConstants.SqlSelectJobNonConcurrent));
		AddCommandParameter(cmd, "jobName", jobKey.Name);
		AddCommandParameter(cmd, "jobGroup", jobKey.Group);
		object o = cmd.ExecuteScalar();
		if (o != null)
		{
			return (bool)o;
		}
		return false;
	}

	/// <summary>
	/// Check whether or not the given job exists.
	/// </summary>
	/// <param name="conn">the DB Connection</param>
	/// <param name="jobKey">The key identifying the job.</param>
	/// <returns>true if the job exists, false otherwise</returns>
	public virtual bool JobExists(ConnectionAndTransactionHolder conn, JobKey jobKey)
	{
		using IDbCommand cmd = PrepareCommand(conn, ReplaceTablePrefix(StdAdoConstants.SqlSelectJobExistence));
		AddCommandParameter(cmd, "jobName", jobKey.Name);
		AddCommandParameter(cmd, "jobGroup", jobKey.Group);
		using IDataReader dr = cmd.ExecuteReader();
		if (dr.Read())
		{
			return true;
		}
		return false;
	}

	/// <summary>
	/// Update the job data map for the given job.
	/// </summary>
	/// <param name="conn">The conn.</param>
	/// <param name="job">the job to update</param>
	/// <returns>the number of rows updated</returns>
	public virtual int UpdateJobData(ConnectionAndTransactionHolder conn, IJobDetail job)
	{
		byte[] baos = SerializeJobData(job.JobDataMap);
		using IDbCommand cmd = PrepareCommand(conn, ReplaceTablePrefix(StdAdoConstants.SqlUpdateJobData));
		AddCommandParameter(cmd, "jobDataMap", baos, dbProvider.Metadata.DbBinaryType);
		AddCommandParameter(cmd, "jobName", job.Key.Name);
		AddCommandParameter(cmd, "jobGroup", job.Key.Group);
		return cmd.ExecuteNonQuery();
	}

	/// <summary>
	/// Select the JobDetail object for a given job name / group name.
	/// </summary>
	/// <param name="conn">The DB Connection.</param>
	/// <param name="jobKey">The key identifying the job.</param>
	/// <param name="loadHelper">The load helper.</param>
	/// <returns>The populated JobDetail object.</returns>
	public virtual IJobDetail SelectJobDetail(ConnectionAndTransactionHolder conn, JobKey jobKey, ITypeLoadHelper loadHelper)
	{
		using IDbCommand cmd = PrepareCommand(conn, ReplaceTablePrefix(StdAdoConstants.SqlSelectJobDetail));
		AddCommandParameter(cmd, "jobName", jobKey.Name);
		AddCommandParameter(cmd, "jobGroup", jobKey.Group);
		using IDataReader rs = cmd.ExecuteReader();
		JobDetailImpl job = null;
		if (rs.Read())
		{
			job = new JobDetailImpl();
			job.Name = rs.GetString("JOB_NAME");
			job.Group = rs.GetString("JOB_GROUP");
			job.Description = rs.GetString("DESCRIPTION");
			job.JobType = loadHelper.LoadType(rs.GetString("JOB_CLASS_NAME"));
			job.Durable = GetBooleanFromDbValue(rs["IS_DURABLE"]);
			job.RequestsRecovery = GetBooleanFromDbValue(rs["REQUESTS_RECOVERY"]);
			IDictionary map = (CanUseProperties ? GetMapFromProperties(rs, 6) : GetObjectFromBlob<IDictionary>(rs, 6));
			if (map != null)
			{
				job.JobDataMap = (map as JobDataMap) ?? new JobDataMap(map);
			}
		}
		return job;
	}

	/// <summary> build Map from java.util.Properties encoding.</summary>
	private IDictionary GetMapFromProperties(IDataReader rs, int idx)
	{
		NameValueCollection properties = GetJobDataFromBlob<NameValueCollection>(rs, idx);
		if (properties == null)
		{
			return null;
		}
		return ConvertFromProperty(properties);
	}

	/// <summary>
	/// Select the total number of jobs stored.
	/// </summary>
	/// <param name="conn">The DB Connection.</param>
	/// <returns>The total number of jobs stored.</returns>
	public virtual int SelectNumJobs(ConnectionAndTransactionHolder conn)
	{
		using IDbCommand cmd = PrepareCommand(conn, ReplaceTablePrefix(StdAdoConstants.SqlSelectNumJobs));
		return (int)cmd.ExecuteScalar();
	}

	/// <summary>
	/// Select all of the job group names that are stored.
	/// </summary>
	/// <param name="conn">The DB Connection.</param>
	/// <returns>An array of <see cref="T:System.String" /> group names.</returns>
	public virtual IList<string> SelectJobGroups(ConnectionAndTransactionHolder conn)
	{
		using IDbCommand cmd = PrepareCommand(conn, ReplaceTablePrefix(StdAdoConstants.SqlSelectJobGroups));
		using IDataReader rs = cmd.ExecuteReader();
		List<string> list = new List<string>();
		while (rs.Read())
		{
			list.Add(rs.GetString(0));
		}
		return list;
	}

	/// <summary>
	/// Select all of the jobs contained in a given group.
	/// </summary>
	/// <param name="conn">The DB Connection.</param>
	/// <param name="matcher"></param>
	/// <returns>An array of <see cref="T:System.String" /> job names.</returns>
	public virtual Quartz.Collection.ISet<JobKey> SelectJobsInGroup(ConnectionAndTransactionHolder conn, GroupMatcher<JobKey> matcher)
	{
		using IDbCommand cmd = PrepareCommand(conn, ReplaceTablePrefix(StdAdoConstants.SqlSelectJobsInGroup));
		AddCommandParameter(cmd, "jobGroup", ToSqlLikeClause(matcher));
		using IDataReader rs = cmd.ExecuteReader();
		Quartz.Collection.HashSet<JobKey> list = new Quartz.Collection.HashSet<JobKey>();
		while (rs.Read())
		{
			list.Add(new JobKey(rs.GetString(0), rs.GetString(1)));
		}
		return list;
	}

	protected static string ToSqlLikeClause<T>(GroupMatcher<T> matcher) where T : Key<T>
	{
		if (StringOperator.Equality.Equals(matcher.CompareWithOperator))
		{
			return matcher.CompareToValue;
		}
		if (StringOperator.Contains.Equals(matcher.CompareWithOperator))
		{
			return "%" + matcher.CompareToValue + "%";
		}
		if (StringOperator.EndsWith.Equals(matcher.CompareWithOperator))
		{
			return "%" + matcher.CompareToValue;
		}
		if (StringOperator.StartsWith.Equals(matcher.CompareWithOperator))
		{
			return matcher.CompareToValue + "%";
		}
		throw new ArgumentOutOfRangeException(string.Concat("Don't know how to translate ", matcher.CompareWithOperator, " into SQL"));
	}

	/// <summary>
	/// Insert the base trigger data.
	/// </summary>
	/// <param name="conn">the DB Connection</param>
	/// <param name="trigger">the trigger to insert</param>
	/// <param name="state">the state that the trigger should be stored in</param>
	/// <param name="jobDetail">The job detail.</param>
	/// <returns>the number of rows inserted</returns>
	public virtual int InsertTrigger(ConnectionAndTransactionHolder conn, IOperableTrigger trigger, string state, IJobDetail jobDetail)
	{
		byte[] baos = null;
		if (trigger.JobDataMap.Count > 0)
		{
			baos = SerializeJobData(trigger.JobDataMap);
		}
		using IDbCommand cmd = PrepareCommand(conn, ReplaceTablePrefix(StdAdoConstants.SqlInsertTrigger));
		AddCommandParameter(cmd, "triggerName", trigger.Key.Name);
		AddCommandParameter(cmd, "triggerGroup", trigger.Key.Group);
		AddCommandParameter(cmd, "triggerJobName", trigger.JobKey.Name);
		AddCommandParameter(cmd, "triggerJobGroup", trigger.JobKey.Group);
		AddCommandParameter(cmd, "triggerDescription", trigger.Description);
		AddCommandParameter(cmd, "triggerNextFireTime", GetDbDateTimeValue(trigger.GetNextFireTimeUtc()));
		AddCommandParameter(cmd, "triggerPreviousFireTime", GetDbDateTimeValue(trigger.GetPreviousFireTimeUtc()));
		AddCommandParameter(cmd, "triggerState", state);
		string paramName = "triggerType";
		ITriggerPersistenceDelegate tDel = FindTriggerPersistenceDelegate(trigger);
		string type = "BLOB";
		if (tDel != null)
		{
			type = tDel.GetHandledTriggerTypeDiscriminator();
		}
		AddCommandParameter(cmd, paramName, type);
		AddCommandParameter(cmd, "triggerStartTime", GetDbDateTimeValue(trigger.StartTimeUtc));
		AddCommandParameter(cmd, "triggerEndTime", GetDbDateTimeValue(trigger.EndTimeUtc));
		AddCommandParameter(cmd, "triggerCalendarName", trigger.CalendarName);
		AddCommandParameter(cmd, "triggerMisfireInstruction", trigger.MisfireInstruction);
		paramName = "triggerJobJobDataMap";
		if (baos != null)
		{
			AddCommandParameter(cmd, paramName, baos, dbProvider.Metadata.DbBinaryType);
		}
		else
		{
			AddCommandParameter(cmd, paramName, null, dbProvider.Metadata.DbBinaryType);
		}
		AddCommandParameter(cmd, "triggerPriority", trigger.Priority);
		int insertResult = cmd.ExecuteNonQuery();
		if (tDel == null)
		{
			InsertBlobTrigger(conn, trigger);
		}
		else
		{
			tDel.InsertExtendedTriggerProperties(conn, trigger, state, jobDetail);
		}
		return insertResult;
	}

	/// <summary>
	/// Insert the blob trigger data.
	/// </summary>
	/// <param name="conn">The DB Connection.</param>
	/// <param name="trigger">The trigger to insert.</param>
	/// <returns>The number of rows inserted.</returns>
	public virtual int InsertBlobTrigger(ConnectionAndTransactionHolder conn, IOperableTrigger trigger)
	{
		using IDbCommand cmd = PrepareCommand(conn, ReplaceTablePrefix(StdAdoConstants.SqlInsertBlobTrigger));
		byte[] buf = SerializeObject(trigger);
		AddCommandParameter(cmd, "triggerName", trigger.Key.Name);
		AddCommandParameter(cmd, "triggerGroup", trigger.Key.Group);
		AddCommandParameter(cmd, "blob", buf, dbProvider.Metadata.DbBinaryType);
		return cmd.ExecuteNonQuery();
	}

	/// <summary>
	/// Update the base trigger data.
	/// </summary>
	/// <param name="conn">The DB Connection.</param>
	/// <param name="trigger">The trigger to insert.</param>
	/// <param name="state">The state that the trigger should be stored in.</param>
	/// <param name="jobDetail">The job detail.</param>
	/// <returns>The number of rows updated.</returns>
	public virtual int UpdateTrigger(ConnectionAndTransactionHolder conn, IOperableTrigger trigger, string state, IJobDetail jobDetail)
	{
		bool updateJobData = trigger.JobDataMap.Dirty;
		byte[] baos = null;
		if (updateJobData && trigger.JobDataMap.Count > 0)
		{
			baos = SerializeJobData(trigger.JobDataMap);
		}
		IDbCommand cmd = ((!updateJobData) ? PrepareCommand(conn, ReplaceTablePrefix(StdAdoConstants.SqlUpdateTriggerSkipData)) : PrepareCommand(conn, ReplaceTablePrefix(StdAdoConstants.SqlUpdateTrigger)));
		AddCommandParameter(cmd, "triggerJobName", trigger.JobKey.Name);
		AddCommandParameter(cmd, "triggerJobGroup", trigger.JobKey.Group);
		AddCommandParameter(cmd, "triggerDescription", trigger.Description);
		AddCommandParameter(cmd, "triggerNextFireTime", GetDbDateTimeValue(trigger.GetNextFireTimeUtc()));
		AddCommandParameter(cmd, "triggerPreviousFireTime", GetDbDateTimeValue(trigger.GetPreviousFireTimeUtc()));
		AddCommandParameter(cmd, "triggerState", state);
		ITriggerPersistenceDelegate tDel = FindTriggerPersistenceDelegate(trigger);
		string type = "BLOB";
		if (tDel != null)
		{
			type = tDel.GetHandledTriggerTypeDiscriminator();
		}
		AddCommandParameter(cmd, "triggerType", type);
		AddCommandParameter(cmd, "triggerStartTime", GetDbDateTimeValue(trigger.StartTimeUtc));
		AddCommandParameter(cmd, "triggerEndTime", GetDbDateTimeValue(trigger.EndTimeUtc));
		AddCommandParameter(cmd, "triggerCalendarName", trigger.CalendarName);
		AddCommandParameter(cmd, "triggerMisfireInstruction", trigger.MisfireInstruction);
		AddCommandParameter(cmd, "triggerPriority", trigger.Priority);
		if (updateJobData)
		{
			if (baos != null)
			{
				AddCommandParameter(cmd, "triggerJobJobDataMap", baos, dbProvider.Metadata.DbBinaryType);
			}
			else
			{
				AddCommandParameter(cmd, "triggerJobJobDataMap", null, dbProvider.Metadata.DbBinaryType);
			}
			AddCommandParameter(cmd, "triggerName", trigger.Key.Name);
			AddCommandParameter(cmd, "triggerGroup", trigger.Key.Group);
		}
		else
		{
			AddCommandParameter(cmd, "triggerName", trigger.Key.Name);
			AddCommandParameter(cmd, "triggerGroup", trigger.Key.Group);
		}
		int insertResult = cmd.ExecuteNonQuery();
		if (tDel == null)
		{
			UpdateBlobTrigger(conn, trigger);
		}
		else
		{
			tDel.UpdateExtendedTriggerProperties(conn, trigger, state, jobDetail);
		}
		return insertResult;
	}

	/// <summary>
	/// Update the blob trigger data.
	/// </summary>
	/// <param name="conn">The DB Connection.</param>
	/// <param name="trigger">The trigger to insert.</param>
	/// <returns>The number of rows updated.</returns>
	public virtual int UpdateBlobTrigger(ConnectionAndTransactionHolder conn, IOperableTrigger trigger)
	{
		using IDbCommand cmd = PrepareCommand(conn, ReplaceTablePrefix(StdAdoConstants.SqlUpdateBlobTrigger));
		byte[] os = SerializeObject(trigger);
		AddCommandParameter(cmd, "blob", os, dbProvider.Metadata.DbBinaryType);
		AddCommandParameter(cmd, "triggerName", trigger.Key.Name);
		AddCommandParameter(cmd, "triggerGroup", trigger.Key.Group);
		return cmd.ExecuteNonQuery();
	}

	/// <summary>
	/// Check whether or not a trigger exists.
	/// </summary>
	/// <param name="conn">The DB Connection.</param>
	/// <param name="triggerKey">the key of the trigger</param>
	/// <returns>true if the trigger exists, false otherwise</returns>
	public virtual bool TriggerExists(ConnectionAndTransactionHolder conn, TriggerKey triggerKey)
	{
		using IDbCommand cmd = PrepareCommand(conn, ReplaceTablePrefix(StdAdoConstants.SqlSelectTriggerExistence));
		AddCommandParameter(cmd, "triggerName", triggerKey.Name);
		AddCommandParameter(cmd, "triggerGroup", triggerKey.Group);
		using IDataReader dr = cmd.ExecuteReader();
		if (dr.Read())
		{
			return true;
		}
		return false;
	}

	/// <summary>
	/// Update the state for a given trigger.
	/// </summary>
	/// <param name="conn">The DB Connection.</param>
	/// <param name="triggerKey">the key of the trigger</param>
	/// <param name="state">The new state for the trigger.</param>
	/// <returns>The number of rows updated.</returns>
	public virtual int UpdateTriggerState(ConnectionAndTransactionHolder conn, TriggerKey triggerKey, string state)
	{
		using IDbCommand cmd = PrepareCommand(conn, ReplaceTablePrefix(StdAdoConstants.SqlUpdateTriggerState));
		AddCommandParameter(cmd, "state", state);
		AddCommandParameter(cmd, "triggerName", triggerKey.Name);
		AddCommandParameter(cmd, "triggerGroup", triggerKey.Group);
		return cmd.ExecuteNonQuery();
	}

	/// <summary>
	/// Update the given trigger to the given new state, if it is one of the
	/// given old states.
	/// </summary>
	/// <param name="conn">The DB connection.</param>
	/// <param name="triggerKey">the key of the trigger</param>
	/// <param name="newState">The new state for the trigger.</param>
	/// <param name="oldState1">One of the old state the trigger must be in.</param>
	/// <param name="oldState2">One of the old state the trigger must be in.</param>
	/// <param name="oldState3">One of the old state the trigger must be in.</param>
	/// <returns>The number of rows updated.</returns>
	public virtual int UpdateTriggerStateFromOtherStates(ConnectionAndTransactionHolder conn, TriggerKey triggerKey, string newState, string oldState1, string oldState2, string oldState3)
	{
		using IDbCommand cmd = PrepareCommand(conn, ReplaceTablePrefix(StdAdoConstants.SqlUpdateTriggerStateFromStates));
		AddCommandParameter(cmd, "newState", newState);
		AddCommandParameter(cmd, "triggerName", triggerKey.Name);
		AddCommandParameter(cmd, "triggerGroup", triggerKey.Group);
		AddCommandParameter(cmd, "oldState1", oldState1);
		AddCommandParameter(cmd, "oldState2", oldState2);
		AddCommandParameter(cmd, "oldState3", oldState3);
		return cmd.ExecuteNonQuery();
	}

	/// <summary>
	/// Update all triggers in the given group to the given new state, if they
	/// are in one of the given old states.
	/// </summary>
	/// <param name="conn">The DB connection.</param>
	/// <param name="matcher"></param>
	/// <param name="newState">The new state for the trigger.</param>
	/// <param name="oldState1">One of the old state the trigger must be in.</param>
	/// <param name="oldState2">One of the old state the trigger must be in.</param>
	/// <param name="oldState3">One of the old state the trigger must be in.</param>
	/// <returns>The number of rows updated.</returns>
	public virtual int UpdateTriggerGroupStateFromOtherStates(ConnectionAndTransactionHolder conn, GroupMatcher<TriggerKey> matcher, string newState, string oldState1, string oldState2, string oldState3)
	{
		using IDbCommand cmd = PrepareCommand(conn, ReplaceTablePrefix(StdAdoConstants.SqlUpdateTriggerGroupStateFromStates));
		AddCommandParameter(cmd, "newState", newState);
		AddCommandParameter(cmd, "groupName", ToSqlLikeClause(matcher));
		AddCommandParameter(cmd, "oldState1", oldState1);
		AddCommandParameter(cmd, "oldState2", oldState2);
		AddCommandParameter(cmd, "oldState3", oldState3);
		return cmd.ExecuteNonQuery();
	}

	/// <summary>
	/// Update the given trigger to the given new state, if it is in the given
	/// old state.
	/// </summary>
	/// <param name="conn">the DB connection</param>
	/// <param name="triggerKey">the key of the trigger</param>
	/// <param name="newState">the new state for the trigger</param>
	/// <param name="oldState">the old state the trigger must be in</param>
	/// <returns>int the number of rows updated</returns>
	public virtual int UpdateTriggerStateFromOtherState(ConnectionAndTransactionHolder conn, TriggerKey triggerKey, string newState, string oldState)
	{
		using IDbCommand cmd = PrepareCommand(conn, ReplaceTablePrefix(StdAdoConstants.SqlUpdateTriggerStateFromState));
		AddCommandParameter(cmd, "newState", newState);
		AddCommandParameter(cmd, "triggerName", triggerKey.Name);
		AddCommandParameter(cmd, "triggerGroup", triggerKey.Group);
		AddCommandParameter(cmd, "oldState", oldState);
		return cmd.ExecuteNonQuery();
	}

	/// <summary>
	/// Update all of the triggers of the given group to the given new state, if
	/// they are in the given old state.
	/// </summary>
	/// <param name="conn">the DB connection</param>
	/// <param name="matcher"></param>
	/// <param name="newState">the new state for the trigger group</param>
	/// <param name="oldState">the old state the triggers must be in</param>
	/// <returns>int the number of rows updated</returns>
	public virtual int UpdateTriggerGroupStateFromOtherState(ConnectionAndTransactionHolder conn, GroupMatcher<TriggerKey> matcher, string newState, string oldState)
	{
		using IDbCommand cmd = PrepareCommand(conn, ReplaceTablePrefix(StdAdoConstants.SqlUpdateTriggerGroupStateFromState));
		AddCommandParameter(cmd, "newState", newState);
		AddCommandParameter(cmd, "triggerGroup", ToSqlLikeClause(matcher));
		AddCommandParameter(cmd, "oldState", oldState);
		return cmd.ExecuteNonQuery();
	}

	/// <summary>
	/// Update the states of all triggers associated with the given job.
	/// </summary>
	/// <param name="conn">the DB Connection</param>
	/// <param name="jobKey">the key of the job</param>
	/// <param name="state">the new state for the triggers</param>
	/// <returns>the number of rows updated</returns>
	public virtual int UpdateTriggerStatesForJob(ConnectionAndTransactionHolder conn, JobKey jobKey, string state)
	{
		using IDbCommand cmd = PrepareCommand(conn, ReplaceTablePrefix(StdAdoConstants.SqlUpdateJobTriggerStates));
		AddCommandParameter(cmd, "state", state);
		AddCommandParameter(cmd, "jobName", jobKey.Name);
		AddCommandParameter(cmd, "jobGroup", jobKey.Group);
		return cmd.ExecuteNonQuery();
	}

	/// <summary>
	/// Updates the state of the trigger states for job from other.
	/// </summary>
	/// <param name="conn">The conn.</param>
	/// <param name="jobKey">Key of the job.</param>
	/// <param name="state">The state.</param>
	/// <param name="oldState">The old state.</param>
	/// <returns></returns>
	public virtual int UpdateTriggerStatesForJobFromOtherState(ConnectionAndTransactionHolder conn, JobKey jobKey, string state, string oldState)
	{
		using IDbCommand cmd = PrepareCommand(conn, ReplaceTablePrefix(StdAdoConstants.SqlUpdateJobTriggerStatesFromOtherState));
		AddCommandParameter(cmd, "state", state);
		AddCommandParameter(cmd, "jobName", jobKey.Name);
		AddCommandParameter(cmd, "jobGroup", jobKey.Group);
		AddCommandParameter(cmd, "oldState", oldState);
		return cmd.ExecuteNonQuery();
	}

	/// <summary>
	/// Delete the cron trigger data for a trigger.
	/// </summary>
	/// <param name="conn">the DB Connection</param>
	/// <param name="triggerKey">the key of the trigger</param>
	/// <returns>the number of rows deleted</returns>
	public virtual int DeleteBlobTrigger(ConnectionAndTransactionHolder conn, TriggerKey triggerKey)
	{
		using IDbCommand cmd = PrepareCommand(conn, ReplaceTablePrefix(StdAdoConstants.SqlDeleteBlobTrigger));
		AddCommandParameter(cmd, "triggerName", triggerKey.Name);
		AddCommandParameter(cmd, "triggerGroup", triggerKey.Group);
		return cmd.ExecuteNonQuery();
	}

	/// <summary>
	/// Delete the base trigger data for a trigger.
	/// </summary>
	/// <param name="conn">the DB Connection</param>
	/// <param name="triggerKey">the key of the trigger</param>
	/// <returns>the number of rows deleted</returns>
	public virtual int DeleteTrigger(ConnectionAndTransactionHolder conn, TriggerKey triggerKey)
	{
		DeleteTriggerExtension(conn, triggerKey);
		using IDbCommand cmd = PrepareCommand(conn, ReplaceTablePrefix(StdAdoConstants.SqlDeleteTrigger));
		AddCommandParameter(cmd, "triggerName", triggerKey.Name);
		AddCommandParameter(cmd, "triggerGroup", triggerKey.Group);
		return cmd.ExecuteNonQuery();
	}

	protected virtual void DeleteTriggerExtension(ConnectionAndTransactionHolder conn, TriggerKey triggerKey)
	{
		foreach (ITriggerPersistenceDelegate tDel in triggerPersistenceDelegates)
		{
			if (tDel.DeleteExtendedTriggerProperties(conn, triggerKey) > 0)
			{
				return;
			}
		}
		DeleteBlobTrigger(conn, triggerKey);
	}

	/// <summary>
	/// Select the number of triggers associated with a given job.
	/// </summary>
	/// <param name="conn">the DB Connection</param>
	/// <param name="jobKey">the key of the job</param>
	/// <returns>the number of triggers for the given job</returns>
	public virtual int SelectNumTriggersForJob(ConnectionAndTransactionHolder conn, JobKey jobKey)
	{
		using IDbCommand cmd = PrepareCommand(conn, ReplaceTablePrefix(StdAdoConstants.SqlSelectNumTriggersForJob));
		AddCommandParameter(cmd, "jobName", jobKey.Name);
		AddCommandParameter(cmd, "jobGroup", jobKey.Group);
		using IDataReader rs = cmd.ExecuteReader();
		if (rs.Read())
		{
			return Convert.ToInt32(rs.GetValue(0), CultureInfo.InvariantCulture);
		}
		return 0;
	}

	/// <summary>
	/// Select the job to which the trigger is associated.
	/// </summary>
	/// <param name="conn">the DB Connection</param>
	/// <param name="triggerKey">the key of the trigger</param>
	/// <param name="loadHelper">The load helper.</param>
	/// <returns>The <see cref="T:Quartz.IJobDetail" /> object associated with the given trigger</returns>
	public virtual IJobDetail SelectJobForTrigger(ConnectionAndTransactionHolder conn, TriggerKey triggerKey, ITypeLoadHelper loadHelper)
	{
		using IDbCommand cmd = PrepareCommand(conn, ReplaceTablePrefix(StdAdoConstants.SqlSelectJobForTrigger));
		AddCommandParameter(cmd, "triggerName", triggerKey.Name);
		AddCommandParameter(cmd, "triggerGroup", triggerKey.Group);
		using IDataReader rs = cmd.ExecuteReader();
		if (rs.Read())
		{
			JobDetailImpl job = new JobDetailImpl();
			job.Name = rs.GetString("JOB_NAME");
			job.Group = rs.GetString("JOB_GROUP");
			job.Durable = GetBooleanFromDbValue(rs["IS_DURABLE"]);
			job.JobType = loadHelper.LoadType(rs.GetString("JOB_CLASS_NAME"));
			job.RequestsRecovery = GetBooleanFromDbValue(rs["REQUESTS_RECOVERY"]);
			return job;
		}
		if (logger.IsDebugEnabled)
		{
			logger.Debug(string.Concat("No job for trigger '", triggerKey, "'."));
		}
		return null;
	}

	/// <summary>
	/// Select the triggers for a job
	/// </summary>
	/// <param name="conn">the DB Connection</param>
	/// <param name="jobKey">the key of the job</param>
	/// <returns>
	/// an array of <see cref="T:Quartz.ITrigger" /> objects
	/// associated with a given job.
	/// </returns>
	public virtual IList<IOperableTrigger> SelectTriggersForJob(ConnectionAndTransactionHolder conn, JobKey jobKey)
	{
		List<IOperableTrigger> trigList = new List<IOperableTrigger>();
		List<TriggerKey> keys = new List<TriggerKey>();
		using (IDbCommand cmd = PrepareCommand(conn, ReplaceTablePrefix(StdAdoConstants.SqlSelectTriggersForJob)))
		{
			AddCommandParameter(cmd, "jobName", jobKey.Name);
			AddCommandParameter(cmd, "jobGroup", jobKey.Group);
			using IDataReader rs = cmd.ExecuteReader();
			while (rs.Read())
			{
				keys.Add(new TriggerKey(rs.GetString(0), rs.GetString(1)));
			}
		}
		foreach (TriggerKey triggerKey in keys)
		{
			IOperableTrigger t = SelectTrigger(conn, triggerKey);
			if (t != null)
			{
				trigList.Add(t);
			}
		}
		return trigList;
	}

	/// <summary>
	/// Select the triggers for a calendar
	/// </summary>
	/// <param name="conn">The DB Connection.</param>
	/// <param name="calName">Name of the calendar.</param>
	/// <returns>
	/// An array of <see cref="T:Quartz.ITrigger" /> objects associated with a given job.
	/// </returns>
	public virtual IList<IOperableTrigger> SelectTriggersForCalendar(ConnectionAndTransactionHolder conn, string calName)
	{
		List<TriggerKey> keys = new List<TriggerKey>();
		using (IDbCommand cmd = PrepareCommand(conn, ReplaceTablePrefix(StdAdoConstants.SqlSelectTriggersForCalendar)))
		{
			AddCommandParameter(cmd, "calendarName", calName);
			using IDataReader rs = cmd.ExecuteReader();
			while (rs.Read())
			{
				keys.Add(new TriggerKey(rs.GetString("TRIGGER_NAME"), rs.GetString("TRIGGER_GROUP")));
			}
		}
		return keys.Select((TriggerKey key) => SelectTrigger(conn, key)).ToList();
	}

	/// <summary>
	/// Select a trigger.
	/// </summary>
	/// <param name="conn">the DB Connection</param>
	/// <param name="triggerKey">the key of the trigger</param>
	/// <returns>The <see cref="T:Quartz.ITrigger" /> object</returns>
	public virtual IOperableTrigger SelectTrigger(ConnectionAndTransactionHolder conn, TriggerKey triggerKey)
	{
		IOperableTrigger trigger = null;
		using (IDbCommand cmd = PrepareCommand(conn, ReplaceTablePrefix(StdAdoConstants.SqlSelectTrigger)))
		{
			AddCommandParameter(cmd, "triggerName", triggerKey.Name);
			AddCommandParameter(cmd, "triggerGroup", triggerKey.Group);
			using IDataReader rs = cmd.ExecuteReader();
			if (rs.Read())
			{
				string jobName = rs.GetString("JOB_NAME");
				string jobGroup = rs.GetString("JOB_GROUP");
				string description = rs.GetString("DESCRIPTION");
				string triggerType = rs.GetString("TRIGGER_TYPE");
				string calendarName = rs.GetString("CALENDAR_NAME");
				int misFireInstr = rs.GetInt32("MISFIRE_INSTR");
				int priority = rs.GetInt32("PRIORITY");
				IDictionary map = (CanUseProperties ? GetMapFromProperties(rs, 11) : GetObjectFromBlob<IDictionary>(rs, 11));
				DateTimeOffset? nextFireTimeUtc = GetDateTimeFromDbValue(rs["NEXT_FIRE_TIME"]);
				DateTimeOffset? previousFireTimeUtc = GetDateTimeFromDbValue(rs["PREV_FIRE_TIME"]);
				DateTimeOffset startTimeUtc = GetDateTimeFromDbValue(rs["START_TIME"]) ?? DateTimeOffset.MinValue;
				DateTimeOffset? endTimeUtc = GetDateTimeFromDbValue(rs["END_TIME"]);
				rs.Close();
				if (triggerType.Equals("BLOB"))
				{
					using IDbCommand cmd2 = PrepareCommand(conn, ReplaceTablePrefix(StdAdoConstants.SqlSelectBlobTrigger));
					AddCommandParameter(cmd2, "triggerName", triggerKey.Name);
					AddCommandParameter(cmd2, "triggerGroup", triggerKey.Group);
					using IDataReader rs2 = cmd2.ExecuteReader();
					if (rs2.Read())
					{
						trigger = GetObjectFromBlob<IOperableTrigger>(rs2, 0);
					}
				}
				else
				{
					ITriggerPersistenceDelegate tDel = FindTriggerPersistenceDelegate(triggerType);
					if (tDel == null)
					{
						throw new JobPersistenceException("No TriggerPersistenceDelegate for trigger discriminator type: " + triggerType);
					}
					TriggerPropertyBundle triggerProps = tDel.LoadExtendedTriggerProperties(conn, triggerKey);
					TriggerBuilder tb = TriggerBuilder.Create().WithDescription(description).WithPriority(priority)
						.StartAt(startTimeUtc)
						.EndAt(endTimeUtc)
						.WithIdentity(triggerKey)
						.ModifiedByCalendar(calendarName)
						.WithSchedule(triggerProps.ScheduleBuilder)
						.ForJob(new JobKey(jobName, jobGroup));
					if (map != null)
					{
						tb.UsingJobData((map as JobDataMap) ?? new JobDataMap(map));
					}
					trigger = (IOperableTrigger)tb.Build();
					trigger.MisfireInstruction = misFireInstr;
					trigger.SetNextFireTimeUtc(nextFireTimeUtc);
					trigger.SetPreviousFireTimeUtc(previousFireTimeUtc);
					SetTriggerStateProperties(trigger, triggerProps);
				}
			}
		}
		return trigger;
	}

	private static void SetTriggerStateProperties(IOperableTrigger trigger, TriggerPropertyBundle props)
	{
		if (props.StatePropertyNames != null)
		{
			ObjectUtils.SetObjectProperties(trigger, props.StatePropertyNames, props.StatePropertyValues);
		}
	}

	/// <summary>
	/// Select a trigger's JobDataMap.
	/// </summary>
	/// <param name="conn">the DB Connection</param>
	/// <param name="triggerKey">the key of the trigger</param>
	/// <returns>The <see cref="T:Quartz.JobDataMap" /> of the Trigger, never null, but possibly empty. </returns>
	public virtual JobDataMap SelectTriggerJobDataMap(ConnectionAndTransactionHolder conn, TriggerKey triggerKey)
	{
		using (IDbCommand cmd = PrepareCommand(conn, ReplaceTablePrefix(StdAdoConstants.SqlSelectTriggerData)))
		{
			AddCommandParameter(cmd, "triggerName", triggerKey.Name);
			AddCommandParameter(cmd, "triggerGroup", triggerKey.Group);
			using IDataReader rs = cmd.ExecuteReader();
			if (rs.Read())
			{
				IDictionary map = ((!CanUseProperties) ? GetObjectFromBlob<IDictionary>(rs, 0) : GetMapFromProperties(rs, 0));
				if (map != null)
				{
					return (map as JobDataMap) ?? new JobDataMap(map);
				}
			}
		}
		return new JobDataMap();
	}

	/// <summary>
	/// Select a trigger's state value.
	/// </summary>
	/// <param name="conn">the DB Connection</param>
	/// <param name="triggerKey">the key of the trigger</param>
	/// <returns>The <see cref="T:Quartz.ITrigger" /> object</returns>
	public virtual string SelectTriggerState(ConnectionAndTransactionHolder conn, TriggerKey triggerKey)
	{
		using IDbCommand cmd = PrepareCommand(conn, ReplaceTablePrefix(StdAdoConstants.SqlSelectTriggerState));
		AddCommandParameter(cmd, "triggerName", triggerKey.Name);
		AddCommandParameter(cmd, "triggerGroup", triggerKey.Group);
		string state;
		using (IDataReader rs = cmd.ExecuteReader())
		{
			state = ((!rs.Read()) ? "DELETED" : rs.GetString("TRIGGER_STATE"));
		}
		return string.Intern(state);
	}

	/// <summary>
	/// Select a trigger status (state and next fire time).
	/// </summary>
	/// <param name="conn">the DB Connection</param>
	/// <param name="triggerKey">the key of the trigger</param>
	/// <returns>
	/// a <see cref="T:Quartz.Impl.AdoJobStore.TriggerStatus" /> object, or null
	/// </returns>
	public virtual TriggerStatus SelectTriggerStatus(ConnectionAndTransactionHolder conn, TriggerKey triggerKey)
	{
		using IDbCommand cmd = PrepareCommand(conn, ReplaceTablePrefix(StdAdoConstants.SqlSelectTriggerStatus));
		TriggerStatus status = null;
		AddCommandParameter(cmd, "triggerName", triggerKey.Name);
		AddCommandParameter(cmd, "triggerGroup", triggerKey.Group);
		using (IDataReader rs = cmd.ExecuteReader())
		{
			if (rs.Read())
			{
				string state = rs.GetString("TRIGGER_STATE");
				object nextFireTime = rs["NEXT_FIRE_TIME"];
				string jobName = rs.GetString("JOB_NAME");
				string jobGroup = rs.GetString("JOB_GROUP");
				DateTimeOffset? nft = GetDateTimeFromDbValue(nextFireTime);
				status = new TriggerStatus(state, nft);
				status.Key = triggerKey;
				status.JobKey = new JobKey(jobName, jobGroup);
			}
		}
		return status;
	}

	/// <summary>
	/// Select the total number of triggers stored.
	/// </summary>
	/// <param name="conn">the DB Connection</param>
	/// <returns>the total number of triggers stored</returns>
	public virtual int SelectNumTriggers(ConnectionAndTransactionHolder conn)
	{
		using IDbCommand cmd = PrepareCommand(conn, ReplaceTablePrefix(StdAdoConstants.SqlSelectNumTriggers));
		int count = 0;
		using (IDataReader rs = cmd.ExecuteReader())
		{
			if (rs.Read())
			{
				count = Convert.ToInt32(rs.GetInt32(0));
			}
		}
		return count;
	}

	/// <summary>
	/// Select all of the trigger group names that are stored.
	/// </summary>
	/// <param name="conn">the DB Connection</param>
	/// <returns>
	/// an array of <see cref="T:System.String" /> group names
	/// </returns>
	public virtual IList<string> SelectTriggerGroups(ConnectionAndTransactionHolder conn)
	{
		using IDbCommand cmd = PrepareCommand(conn, ReplaceTablePrefix(StdAdoConstants.SqlSelectTriggerGroups));
		using IDataReader rs = cmd.ExecuteReader();
		List<string> list = new List<string>();
		while (rs.Read())
		{
			list.Add((string)rs[0]);
		}
		return list;
	}

	public IList<string> SelectTriggerGroups(ConnectionAndTransactionHolder conn, GroupMatcher<TriggerKey> matcher)
	{
		using IDbCommand cmd = PrepareCommand(conn, ReplaceTablePrefix(StdAdoConstants.SqlSelectTriggerGroupsFiltered));
		AddCommandParameter(cmd, "triggerGroup", ToSqlLikeClause(matcher));
		using IDataReader rs = cmd.ExecuteReader();
		List<string> list = new List<string>();
		while (rs.Read())
		{
			list.Add((string)rs[0]);
		}
		return list;
	}

	/// <summary>
	/// Select all of the triggers contained in a given group.
	/// </summary>
	/// <param name="conn">the DB Connection</param>
	/// <param name="matcher"></param>
	/// <returns>
	/// an array of <see cref="T:System.String" /> trigger names
	/// </returns>
	public virtual Quartz.Collection.ISet<TriggerKey> SelectTriggersInGroup(ConnectionAndTransactionHolder conn, GroupMatcher<TriggerKey> matcher)
	{
		using IDbCommand cmd = PrepareCommand(conn, ReplaceTablePrefix(StdAdoConstants.SqlSelectTriggersInGroup));
		AddCommandParameter(cmd, "triggerGroup", ToSqlLikeClause(matcher));
		using IDataReader rs = cmd.ExecuteReader();
		Quartz.Collection.HashSet<TriggerKey> keys = new Quartz.Collection.HashSet<TriggerKey>();
		while (rs.Read())
		{
			keys.Add(new TriggerKey(rs.GetString(0), rs.GetString(1)));
		}
		return keys;
	}

	/// <summary>
	/// Inserts the paused trigger group.
	/// </summary>
	/// <param name="conn">The conn.</param>
	/// <param name="groupName">Name of the group.</param>
	/// <returns></returns>
	public virtual int InsertPausedTriggerGroup(ConnectionAndTransactionHolder conn, string groupName)
	{
		using IDbCommand cmd = PrepareCommand(conn, ReplaceTablePrefix(StdAdoConstants.SqlInsertPausedTriggerGroup));
		AddCommandParameter(cmd, "triggerGroup", groupName);
		return cmd.ExecuteNonQuery();
	}

	/// <summary>
	/// Deletes the paused trigger group.
	/// </summary>
	/// <param name="conn">The conn.</param>
	/// <param name="groupName">Name of the group.</param>
	/// <returns></returns>
	public virtual int DeletePausedTriggerGroup(ConnectionAndTransactionHolder conn, string groupName)
	{
		using IDbCommand cmd = PrepareCommand(conn, ReplaceTablePrefix(StdAdoConstants.SqlDeletePausedTriggerGroup));
		AddCommandParameter(cmd, "triggerGroup", groupName);
		return cmd.ExecuteNonQuery();
	}

	public virtual int DeletePausedTriggerGroup(ConnectionAndTransactionHolder conn, GroupMatcher<TriggerKey> matcher)
	{
		using IDbCommand cmd = PrepareCommand(conn, ReplaceTablePrefix(StdAdoConstants.SqlDeletePausedTriggerGroup));
		AddCommandParameter(cmd, "triggerGroup", ToSqlLikeClause(matcher));
		return cmd.ExecuteNonQuery();
	}

	/// <summary>
	/// Deletes all paused trigger groups.
	/// </summary>
	/// <param name="conn">The conn.</param>
	/// <returns></returns>
	public virtual int DeleteAllPausedTriggerGroups(ConnectionAndTransactionHolder conn)
	{
		using IDbCommand cmd = PrepareCommand(conn, ReplaceTablePrefix(StdAdoConstants.SqlDeletePausedTriggerGroups));
		return cmd.ExecuteNonQuery();
	}

	/// <summary>
	/// Determines whether the specified trigger group is paused.
	/// </summary>
	/// <param name="conn">The conn.</param>
	/// <param name="groupName">Name of the group.</param>
	/// <returns>
	/// 	<c>true</c> if trigger group is paused; otherwise, <c>false</c>.
	/// </returns>
	public virtual bool IsTriggerGroupPaused(ConnectionAndTransactionHolder conn, string groupName)
	{
		using IDbCommand cmd = PrepareCommand(conn, ReplaceTablePrefix(StdAdoConstants.SqlSelectPausedTriggerGroup));
		AddCommandParameter(cmd, "triggerGroup", groupName);
		using IDataReader rs = cmd.ExecuteReader();
		return rs.Read();
	}

	/// <summary>
	/// Determines whether given trigger group already exists.
	/// </summary>
	/// <param name="conn">The conn.</param>
	/// <param name="groupName">Name of the group.</param>
	/// <returns>
	/// 	<c>true</c> if trigger group exists; otherwise, <c>false</c>.
	/// </returns>
	public virtual bool IsExistingTriggerGroup(ConnectionAndTransactionHolder conn, string groupName)
	{
		using IDbCommand cmd = PrepareCommand(conn, ReplaceTablePrefix(StdAdoConstants.SqlSelectNumTriggersInGroup));
		AddCommandParameter(cmd, "triggerGroup", groupName);
		using IDataReader rs = cmd.ExecuteReader();
		if (!rs.Read())
		{
			return false;
		}
		return Convert.ToInt32(rs.GetInt32(0)) > 0;
	}

	/// <summary>
	/// Insert a new calendar.
	/// </summary>
	/// <param name="conn">the DB Connection</param>
	/// <param name="calendarName">The name for the new calendar.</param>
	/// <param name="calendar">The calendar.</param>
	/// <returns>the number of rows inserted</returns>
	/// <throws>  IOException </throws>
	public virtual int InsertCalendar(ConnectionAndTransactionHolder conn, string calendarName, ICalendar calendar)
	{
		byte[] baos = SerializeObject(calendar);
		using IDbCommand cmd = PrepareCommand(conn, ReplaceTablePrefix(StdAdoConstants.SqlInsertCalendar));
		AddCommandParameter(cmd, "calendarName", calendarName);
		AddCommandParameter(cmd, "calendar", baos, dbProvider.Metadata.DbBinaryType);
		return cmd.ExecuteNonQuery();
	}

	/// <summary>
	/// Update a calendar.
	/// </summary>
	/// <param name="conn">the DB Connection</param>
	/// <param name="calendarName">The name for the new calendar.</param>
	/// <param name="calendar">The calendar.</param>
	/// <returns>the number of rows updated</returns>
	/// <throws>  IOException </throws>
	public virtual int UpdateCalendar(ConnectionAndTransactionHolder conn, string calendarName, ICalendar calendar)
	{
		byte[] baos = SerializeObject(calendar);
		using IDbCommand cmd = PrepareCommand(conn, ReplaceTablePrefix(StdAdoConstants.SqlUpdateCalendar));
		AddCommandParameter(cmd, "calendar", baos, dbProvider.Metadata.DbBinaryType);
		AddCommandParameter(cmd, "calendarName", calendarName);
		return cmd.ExecuteNonQuery();
	}

	/// <summary>
	/// Check whether or not a calendar exists.
	/// </summary>
	/// <param name="conn">the DB Connection</param>
	/// <param name="calendarName">The name of the calendar.</param>
	/// <returns>
	/// true if the trigger exists, false otherwise
	/// </returns>
	public virtual bool CalendarExists(ConnectionAndTransactionHolder conn, string calendarName)
	{
		using IDbCommand cmd = PrepareCommand(conn, ReplaceTablePrefix(StdAdoConstants.SqlSelectCalendarExistence));
		AddCommandParameter(cmd, "calendarName", calendarName);
		using IDataReader rs = cmd.ExecuteReader();
		if (rs.Read())
		{
			return true;
		}
		return false;
	}

	/// <summary>
	/// Select a calendar.
	/// </summary>
	/// <param name="conn">the DB Connection</param>
	/// <param name="calendarName">The name of the calendar.</param>
	/// <returns>the Calendar</returns>
	/// <throws>  ClassNotFoundException </throws>
	/// <throws>  IOException </throws>
	public virtual ICalendar SelectCalendar(ConnectionAndTransactionHolder conn, string calendarName)
	{
		using IDbCommand cmd = PrepareCommand(conn, ReplaceTablePrefix(StdAdoConstants.SqlSelectCalendar));
		AddCommandParameter(cmd, "calendarName", calendarName);
		using IDataReader rs = cmd.ExecuteReader();
		ICalendar cal = null;
		if (rs.Read())
		{
			cal = GetObjectFromBlob<ICalendar>(rs, 0);
		}
		if (cal == null)
		{
			logger.Warn("Couldn't find calendar with name '" + calendarName + "'.");
		}
		return cal;
	}

	/// <summary>
	/// Check whether or not a calendar is referenced by any triggers.
	/// </summary>
	/// <param name="conn">the DB Connection</param>
	/// <param name="calendarName">The name of the calendar.</param>
	/// <returns>
	/// true if any triggers reference the calendar, false otherwise
	/// </returns>
	public virtual bool CalendarIsReferenced(ConnectionAndTransactionHolder conn, string calendarName)
	{
		using IDbCommand cmd = PrepareCommand(conn, ReplaceTablePrefix(StdAdoConstants.SqlSelectReferencedCalendar));
		AddCommandParameter(cmd, "calendarName", calendarName);
		using IDataReader rs = cmd.ExecuteReader();
		if (rs.Read())
		{
			return true;
		}
		return false;
	}

	/// <summary>
	/// Delete a calendar.
	/// </summary>
	/// <param name="conn">the DB Connection</param>
	/// <param name="calendarName">The name of the trigger.</param>
	/// <returns>the number of rows deleted</returns>
	public virtual int DeleteCalendar(ConnectionAndTransactionHolder conn, string calendarName)
	{
		using IDbCommand cmd = PrepareCommand(conn, ReplaceTablePrefix(StdAdoConstants.SqlDeleteCalendar));
		AddCommandParameter(cmd, "calendarName", calendarName);
		return cmd.ExecuteNonQuery();
	}

	/// <summary>
	/// Select the total number of calendars stored.
	/// </summary>
	/// <param name="conn">the DB Connection</param>
	/// <returns>the total number of calendars stored</returns>
	public virtual int SelectNumCalendars(ConnectionAndTransactionHolder conn)
	{
		using IDbCommand cmd = PrepareCommand(conn, ReplaceTablePrefix(StdAdoConstants.SqlSelectNumCalendars));
		int count = 0;
		using IDataReader rs = cmd.ExecuteReader();
		if (rs.Read())
		{
			count = Convert.ToInt32(rs.GetValue(0), CultureInfo.InvariantCulture);
		}
		return count;
	}

	/// <summary>
	/// Select all of the stored calendars.
	/// </summary>
	/// <param name="conn">the DB Connection</param>
	/// <returns>
	/// an array of <see cref="T:System.String" /> calendar names
	/// </returns>
	public virtual IList<string> SelectCalendars(ConnectionAndTransactionHolder conn)
	{
		using IDbCommand cmd = PrepareCommand(conn, ReplaceTablePrefix(StdAdoConstants.SqlSelectCalendars));
		using IDataReader rs = cmd.ExecuteReader();
		List<string> list = new List<string>();
		while (rs.Read())
		{
			list.Add((string)rs[0]);
		}
		return list;
	}

	/// <summary>
	/// Select the trigger that will be fired at the given fire time.
	/// </summary>
	/// <param name="conn">the DB Connection</param>
	/// <param name="fireTime">the time that the trigger will be fired</param>
	/// <returns>
	/// a <see cref="T:Quartz.TriggerKey" /> representing the
	/// trigger that will be fired at the given fire time, or null if no
	/// trigger will be fired at that time
	/// </returns>
	public virtual TriggerKey SelectTriggerForFireTime(ConnectionAndTransactionHolder conn, DateTimeOffset fireTime)
	{
		using IDbCommand cmd = PrepareCommand(conn, ReplaceTablePrefix(StdAdoConstants.SqlSelectTriggerForFireTime));
		AddCommandParameter(cmd, "state", "WAITING");
		AddCommandParameter(cmd, "fireTime", GetDbDateTimeValue(fireTime));
		using IDataReader rs = cmd.ExecuteReader();
		if (rs.Read())
		{
			return new TriggerKey(rs.GetString("TRIGGER_NAME"), rs.GetString("TRIGGER_GROUP"));
		}
		return null;
	}

	/// <summary>
	/// Select the next trigger which will fire to fire between the two given timestamps 
	/// in ascending order of fire time, and then descending by priority.
	/// </summary>
	/// <param name="conn">The conn.</param>
	/// <param name="noLaterThan">highest value of <see cref="M:Quartz.ITrigger.GetNextFireTimeUtc" /> of the triggers (exclusive)</param>
	/// <param name="noEarlierThan">highest value of <see cref="M:Quartz.ITrigger.GetNextFireTimeUtc" /> of the triggers (inclusive)</param>
	/// <param name="maxCount">maximum number of trigger keys allow to acquired in the returning list.</param>
	/// <returns>A (never null, possibly empty) list of the identifiers (Key objects) of the next triggers to be fired.</returns>
	public virtual IList<TriggerKey> SelectTriggerToAcquire(ConnectionAndTransactionHolder conn, DateTimeOffset noLaterThan, DateTimeOffset noEarlierThan, int maxCount)
	{
		if (maxCount < 1)
		{
			maxCount = 1;
		}
		using IDbCommand cmd = PrepareCommand(conn, ReplaceTablePrefix(GetSelectNextTriggerToAcquireSql(maxCount)));
		List<TriggerKey> nextTriggers = new List<TriggerKey>();
		AddCommandParameter(cmd, "state", "WAITING");
		AddCommandParameter(cmd, "noLaterThan", GetDbDateTimeValue(noLaterThan));
		AddCommandParameter(cmd, "noEarlierThan", GetDbDateTimeValue(noEarlierThan));
		using (IDataReader rs = cmd.ExecuteReader())
		{
			while (rs.Read() && nextTriggers.Count < maxCount)
			{
				nextTriggers.Add(new TriggerKey((string)rs["TRIGGER_NAME"], (string)rs["TRIGGER_GROUP"]));
			}
		}
		return nextTriggers;
	}

	protected virtual string GetSelectNextTriggerToAcquireSql(int maxCount)
	{
		return StdAdoConstants.SqlSelectNextTriggerToAcquire;
	}

	/// <summary>
	/// Insert a fired trigger.
	/// </summary>
	/// <param name="conn">the DB Connection</param>
	/// <param name="trigger">the trigger</param>
	/// <param name="state">the state that the trigger should be stored in</param>
	/// <param name="job">The job.</param>
	/// <returns>the number of rows inserted</returns>
	public virtual int InsertFiredTrigger(ConnectionAndTransactionHolder conn, IOperableTrigger trigger, string state, IJobDetail job)
	{
		using IDbCommand cmd = PrepareCommand(conn, ReplaceTablePrefix(StdAdoConstants.SqlInsertFiredTrigger));
		AddCommandParameter(cmd, "triggerEntryId", trigger.FireInstanceId);
		AddCommandParameter(cmd, "triggerName", trigger.Key.Name);
		AddCommandParameter(cmd, "triggerGroup", trigger.Key.Group);
		AddCommandParameter(cmd, "triggerInstanceName", instanceId);
		AddCommandParameter(cmd, "triggerFireTime", GetDbDateTimeValue(trigger.GetNextFireTimeUtc()));
		AddCommandParameter(cmd, "triggerState", state);
		if (job != null)
		{
			AddCommandParameter(cmd, "triggerJobName", trigger.JobKey.Name);
			AddCommandParameter(cmd, "triggerJobGroup", trigger.JobKey.Group);
			AddCommandParameter(cmd, "triggerJobStateful", GetDbBooleanValue(job.ConcurrentExecutionDisallowed));
			AddCommandParameter(cmd, "triggerJobRequestsRecovery", GetDbBooleanValue(job.RequestsRecovery));
		}
		else
		{
			AddCommandParameter(cmd, "triggerJobName", null);
			AddCommandParameter(cmd, "triggerJobGroup", null);
			AddCommandParameter(cmd, "triggerJobStateful", GetDbBooleanValue(booleanValue: false));
			AddCommandParameter(cmd, "triggerJobRequestsRecovery", GetDbBooleanValue(booleanValue: false));
		}
		AddCommandParameter(cmd, "triggerPriority", trigger.Priority);
		return cmd.ExecuteNonQuery();
	}

	/// <summary>
	/// <para>
	/// Update a fired trigger.
	/// </para>
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <param name="conn"></param>
	/// the DB Connection
	/// <param name="trigger"></param>
	/// the trigger
	/// <param name="state"></param>
	/// <param name="job"></param>
	/// the state that the trigger should be stored in
	/// <returns>the number of rows inserted</returns>
	public int UpdateFiredTrigger(ConnectionAndTransactionHolder conn, IOperableTrigger trigger, string state, IJobDetail job)
	{
		IDbCommand ps = PrepareCommand(conn, ReplaceTablePrefix(StdAdoConstants.SqlUpdateFiredTrigger));
		AddCommandParameter(ps, "instanceName", instanceId);
		AddCommandParameter(ps, "firedTime", GetDbDateTimeValue(trigger.GetNextFireTimeUtc()));
		AddCommandParameter(ps, "entryState", state);
		if (job != null)
		{
			AddCommandParameter(ps, "jobName", trigger.JobKey.Name);
			AddCommandParameter(ps, "jobGroup", trigger.JobKey.Group);
			AddCommandParameter(ps, "isNonConcurrent", GetDbBooleanValue(job.ConcurrentExecutionDisallowed));
			AddCommandParameter(ps, "requestsRecover", GetDbBooleanValue(job.RequestsRecovery));
		}
		else
		{
			AddCommandParameter(ps, "jobName", null);
			AddCommandParameter(ps, "JobGroup", null);
			AddCommandParameter(ps, "isNonConcurrent", GetDbBooleanValue(booleanValue: false));
			AddCommandParameter(ps, "requestsRecover", GetDbBooleanValue(booleanValue: false));
		}
		AddCommandParameter(ps, "entryId", trigger.FireInstanceId);
		return ps.ExecuteNonQuery();
	}

	/// <summary>
	/// Select the states of all fired-trigger records for a given trigger, or
	/// trigger group if trigger name is <see langword="null" />.
	/// </summary>
	/// <param name="conn">The DB connection.</param>
	/// <param name="triggerName">Name of the trigger.</param>
	/// <param name="groupName">Name of the group.</param>
	/// <returns>a List of <see cref="T:Quartz.Impl.AdoJobStore.FiredTriggerRecord" /> objects.</returns>
	public virtual IList<FiredTriggerRecord> SelectFiredTriggerRecords(ConnectionAndTransactionHolder conn, string triggerName, string groupName)
	{
		IList<FiredTriggerRecord> lst = new List<FiredTriggerRecord>();
		IDbCommand cmd;
		if (triggerName != null)
		{
			cmd = PrepareCommand(conn, ReplaceTablePrefix(StdAdoConstants.SqlSelectFiredTrigger));
			AddCommandParameter(cmd, "triggerName", triggerName);
			AddCommandParameter(cmd, "triggerGroup", groupName);
		}
		else
		{
			cmd = PrepareCommand(conn, ReplaceTablePrefix(StdAdoConstants.SqlSelectFiredTriggerGroup));
			AddCommandParameter(cmd, "triggerGroup", groupName);
		}
		using IDataReader rs = cmd.ExecuteReader();
		while (rs.Read())
		{
			FiredTriggerRecord rec = new FiredTriggerRecord();
			rec.FireInstanceId = rs.GetString("ENTRY_ID");
			rec.FireInstanceState = rs.GetString("STATE");
			rec.FireTimestamp = GetDateTimeFromDbValue(rs["FIRED_TIME"]) ?? DateTimeOffset.MinValue;
			rec.Priority = Convert.ToInt32(rs["PRIORITY"], CultureInfo.InvariantCulture);
			rec.SchedulerInstanceId = rs.GetString("INSTANCE_NAME");
			rec.TriggerKey = new TriggerKey(rs.GetString("TRIGGER_NAME"), rs.GetString("TRIGGER_GROUP"));
			if (!rec.FireInstanceState.Equals("ACQUIRED"))
			{
				rec.JobDisallowsConcurrentExecution = GetBooleanFromDbValue(rs["IS_NONCONCURRENT"]);
				rec.JobRequestsRecovery = GetBooleanFromDbValue(rs["REQUESTS_RECOVERY"]);
				rec.JobKey = new JobKey(rs.GetString("JOB_NAME"), rs.GetString("JOB_GROUP"));
			}
			lst.Add(rec);
		}
		return lst;
	}

	/// <summary>
	/// Select the states of all fired-trigger records for a given job, or job
	/// group if job name is <see langword="null" />.
	/// </summary>
	/// <param name="conn">The DB connection.</param>
	/// <param name="jobName">Name of the job.</param>
	/// <param name="groupName">Name of the group.</param>
	/// <returns>a List of <see cref="T:Quartz.Impl.AdoJobStore.FiredTriggerRecord" /> objects.</returns>
	public virtual IList<FiredTriggerRecord> SelectFiredTriggerRecordsByJob(ConnectionAndTransactionHolder conn, string jobName, string groupName)
	{
		IList<FiredTriggerRecord> lst = new List<FiredTriggerRecord>();
		IDbCommand cmd;
		if (jobName != null)
		{
			cmd = PrepareCommand(conn, ReplaceTablePrefix(StdAdoConstants.SqlSelectFiredTriggersOfJob));
			AddCommandParameter(cmd, "jobName", jobName);
			AddCommandParameter(cmd, "jobGroup", groupName);
		}
		else
		{
			cmd = PrepareCommand(conn, ReplaceTablePrefix(StdAdoConstants.SqlSelectFiredTriggersOfJobGroup));
			AddCommandParameter(cmd, "jobGroup", groupName);
		}
		using IDataReader rs = cmd.ExecuteReader();
		while (rs.Read())
		{
			FiredTriggerRecord rec = new FiredTriggerRecord();
			rec.FireInstanceId = rs.GetString("ENTRY_ID");
			rec.FireInstanceState = rs.GetString("STATE");
			rec.FireTimestamp = GetDateTimeFromDbValue(rs["FIRED_TIME"]) ?? DateTimeOffset.MinValue;
			rec.Priority = Convert.ToInt32(rs["PRIORITY"], CultureInfo.InvariantCulture);
			rec.SchedulerInstanceId = rs.GetString("INSTANCE_NAME");
			rec.TriggerKey = new TriggerKey(rs.GetString("TRIGGER_NAME"), rs.GetString("TRIGGER_GROUP"));
			if (!rec.FireInstanceState.Equals("ACQUIRED"))
			{
				rec.JobDisallowsConcurrentExecution = GetBooleanFromDbValue(rs["IS_NONCONCURRENT"]);
				rec.JobRequestsRecovery = GetBooleanFromDbValue(rs["REQUESTS_RECOVERY"]);
				rec.JobKey = new JobKey(rs.GetString("JOB_NAME"), rs.GetString("JOB_GROUP"));
			}
			lst.Add(rec);
		}
		return lst;
	}

	/// <summary>
	/// Select the states of all fired-trigger records for a given scheduler
	/// instance.
	/// </summary>
	/// <param name="conn">The DB Connection</param>
	/// <param name="instanceName">Name of the instance.</param>
	/// <returns>A list of FiredTriggerRecord objects.</returns>
	public virtual IList<FiredTriggerRecord> SelectInstancesFiredTriggerRecords(ConnectionAndTransactionHolder conn, string instanceName)
	{
		IList<FiredTriggerRecord> lst = new List<FiredTriggerRecord>();
		using IDbCommand cmd = PrepareCommand(conn, ReplaceTablePrefix(StdAdoConstants.SqlSelectInstancesFiredTriggers));
		AddCommandParameter(cmd, "instanceName", instanceName);
		using (IDataReader rs = cmd.ExecuteReader())
		{
			while (rs.Read())
			{
				FiredTriggerRecord rec = new FiredTriggerRecord();
				rec.FireInstanceId = rs.GetString("ENTRY_ID");
				rec.FireInstanceState = rs.GetString("STATE");
				rec.FireTimestamp = GetDateTimeFromDbValue(rs["FIRED_TIME"]) ?? DateTimeOffset.MinValue;
				rec.SchedulerInstanceId = rs.GetString("INSTANCE_NAME");
				rec.TriggerKey = new TriggerKey(rs.GetString("TRIGGER_NAME"), rs.GetString("TRIGGER_GROUP"));
				if (!rec.FireInstanceState.Equals("ACQUIRED"))
				{
					rec.JobDisallowsConcurrentExecution = GetBooleanFromDbValue(rs["IS_NONCONCURRENT"]);
					rec.JobRequestsRecovery = GetBooleanFromDbValue(rs["REQUESTS_RECOVERY"]);
					rec.JobKey = new JobKey(rs.GetString("JOB_NAME"), rs.GetString("JOB_GROUP"));
				}
				lst.Add(rec);
			}
		}
		return lst;
	}

	/// <summary>
	/// Select the distinct instance names of all fired-trigger records.
	/// </summary>
	/// <param name="conn">The conn.</param>
	/// <returns></returns>
	/// <remarks>
	/// This is useful when trying to identify orphaned fired triggers (a
	/// fired trigger without a scheduler state record.)
	/// </remarks>
	public Quartz.Collection.ISet<string> SelectFiredTriggerInstanceNames(ConnectionAndTransactionHolder conn)
	{
		Quartz.Collection.HashSet<string> instanceNames = new Quartz.Collection.HashSet<string>();
		using IDbCommand cmd = PrepareCommand(conn, ReplaceTablePrefix(StdAdoConstants.SqlSelectFiredTriggerInstanceNames));
		using IDataReader rs = cmd.ExecuteReader();
		while (rs.Read())
		{
			instanceNames.Add(rs.GetString("INSTANCE_NAME"));
		}
		return instanceNames;
	}

	/// <summary>
	/// Delete a fired trigger.
	/// </summary>
	/// <param name="conn">the DB Connection</param>
	/// <param name="entryId">the fired trigger entry to delete</param>
	/// <returns>the number of rows deleted</returns>
	public virtual int DeleteFiredTrigger(ConnectionAndTransactionHolder conn, string entryId)
	{
		using IDbCommand cmd = PrepareCommand(conn, ReplaceTablePrefix(StdAdoConstants.SqlDeleteFiredTrigger));
		AddCommandParameter(cmd, "triggerEntryId", entryId);
		return cmd.ExecuteNonQuery();
	}

	/// <summary>
	/// Selects the job execution count.
	/// </summary>
	/// <param name="conn">The DB connection.</param>
	/// <param name="jobKey">The key of the job.</param>
	/// <returns></returns>
	public virtual int SelectJobExecutionCount(ConnectionAndTransactionHolder conn, JobKey jobKey)
	{
		using IDbCommand cmd = PrepareCommand(conn, ReplaceTablePrefix(StdAdoConstants.SqlSelectJobExecutionCount));
		AddCommandParameter(cmd, "jobName", jobKey.Name);
		AddCommandParameter(cmd, "jobGroup", jobKey.Group);
		using IDataReader rs = cmd.ExecuteReader();
		if (rs.Read())
		{
			return Convert.ToInt32(rs.GetValue(0), CultureInfo.InvariantCulture);
		}
		return 0;
	}

	/// <summary>
	/// Inserts the state of the scheduler.
	/// </summary>
	/// <param name="conn">The conn.</param>
	/// <param name="instanceName">The instance id.</param>
	/// <param name="checkInTime">The check in time.</param>
	/// <param name="interval">The interval.</param>
	/// <returns></returns>
	public virtual int InsertSchedulerState(ConnectionAndTransactionHolder conn, string instanceName, DateTimeOffset checkInTime, TimeSpan interval)
	{
		using IDbCommand cmd = PrepareCommand(conn, ReplaceTablePrefix(StdAdoConstants.SqlInsertSchedulerState));
		AddCommandParameter(cmd, "instanceName", instanceName);
		AddCommandParameter(cmd, "lastCheckinTime", GetDbDateTimeValue(checkInTime));
		AddCommandParameter(cmd, "checkinInterval", GetDbTimeSpanValue(interval));
		return cmd.ExecuteNonQuery();
	}

	/// <summary>
	/// Deletes the state of the scheduler.
	/// </summary>
	/// <param name="conn">The database connection.</param>
	/// <param name="instanceName">The instance id.</param>
	/// <returns></returns>
	public virtual int DeleteSchedulerState(ConnectionAndTransactionHolder conn, string instanceName)
	{
		using IDbCommand cmd = PrepareCommand(conn, ReplaceTablePrefix(StdAdoConstants.SqlDeleteSchedulerState));
		AddCommandParameter(cmd, "instanceName", instanceName);
		return cmd.ExecuteNonQuery();
	}

	/// <summary>
	/// Updates the state of the scheduler.
	/// </summary>
	/// <param name="conn">The database connection.</param>
	/// <param name="instanceName">The instance id.</param>
	/// <param name="checkInTime">The check in time.</param>
	/// <returns></returns>
	public virtual int UpdateSchedulerState(ConnectionAndTransactionHolder conn, string instanceName, DateTimeOffset checkInTime)
	{
		using IDbCommand cmd = PrepareCommand(conn, ReplaceTablePrefix(StdAdoConstants.SqlUpdateSchedulerState));
		AddCommandParameter(cmd, "lastCheckinTime", GetDbDateTimeValue(checkInTime));
		AddCommandParameter(cmd, "instanceName", instanceName);
		return cmd.ExecuteNonQuery();
	}

	/// <summary>
	/// A List of all current <see cref="T:Quartz.Impl.AdoJobStore.SchedulerStateRecord" />s.
	/// <para>
	/// If instanceId is not null, then only the record for the identified
	/// instance will be returned.
	/// </para>
	/// </summary>
	/// <param name="conn">The DB Connection</param>
	/// <param name="instanceName">The instance id.</param>
	/// <returns></returns>
	public virtual IList<SchedulerStateRecord> SelectSchedulerStateRecords(ConnectionAndTransactionHolder conn, string instanceName)
	{
		List<SchedulerStateRecord> list = new List<SchedulerStateRecord>();
		IDbCommand cmd;
		if (instanceName != null)
		{
			cmd = PrepareCommand(conn, ReplaceTablePrefix(StdAdoConstants.SqlSelectSchedulerState));
			AddCommandParameter(cmd, "instanceName", instanceName);
		}
		else
		{
			cmd = PrepareCommand(conn, ReplaceTablePrefix(StdAdoConstants.SqlSelectSchedulerStates));
		}
		using IDataReader rs = cmd.ExecuteReader();
		while (rs.Read())
		{
			SchedulerStateRecord rec = new SchedulerStateRecord();
			rec.SchedulerInstanceId = rs.GetString("INSTANCE_NAME");
			rec.CheckinTimestamp = GetDateTimeFromDbValue(rs["LAST_CHECKIN_TIME"]) ?? DateTimeOffset.MinValue;
			rec.CheckinInterval = GetTimeSpanFromDbValue(rs["CHECKIN_INTERVAL"]) ?? TimeSpan.Zero;
			list.Add(rec);
		}
		return list;
	}

	/// <summary>
	/// Replace the table prefix in a query by replacing any occurrences of
	/// "{0}" with the table prefix.
	/// </summary>
	/// <param name="query">The unsubstitued query</param>
	/// <returns>The query, with proper table prefix substituted</returns>
	protected string ReplaceTablePrefix(string query)
	{
		return AdoJobStoreUtil.ReplaceTablePrefix(query, tablePrefix, SchedulerNameLiteral);
	}

	/// <summary>
	/// Create a serialized <see lanword="byte[]" /> version of an Object.
	/// </summary>
	/// <param name="obj">the object to serialize</param>
	/// <returns>Serialized object as byte array.</returns>
	protected virtual byte[] SerializeObject(object obj)
	{
		byte[] retValue = null;
		if (obj != null)
		{
			retValue = objectSerializer.Serialize(obj);
		}
		return retValue;
	}

	/// <summary>
	/// Remove the transient data from and then create a serialized <see cref="T:System.IO.MemoryStream" />
	/// version of a <see cref="T:Quartz.JobDataMap" /> and returns the underlying bytes.
	/// </summary>
	/// <param name="data">The data.</param>
	/// <returns>the serialized data as byte array</returns>
	public virtual byte[] SerializeJobData(JobDataMap data)
	{
		if (CanUseProperties)
		{
			return SerializeProperties(data);
		}
		try
		{
			return SerializeObject(data);
		}
		catch (SerializationException e)
		{
			throw new SerializationException(string.Concat("Unable to serialize JobDataMap for insertion into database because the value of property '", GetKeyOfNonSerializableValue(data), "' is not serializable: ", e.Message));
		}
	}

	protected object GetKeyOfNonSerializableValue(IDictionary data)
	{
		foreach (DictionaryEntry entry in data)
		{
			try
			{
				SerializeObject(entry.Value);
			}
			catch (Exception)
			{
				return entry.Key;
			}
		}
		return null;
	}

	/// <summary>
	/// serialize
	/// </summary>
	/// <param name="data">The data.</param>
	/// <returns></returns>
	private byte[] SerializeProperties(JobDataMap data)
	{
		byte[] retValue = null;
		if (data != null)
		{
			NameValueCollection properties = ConvertToProperty(data.WrappedMap);
			retValue = SerializeObject(properties);
		}
		return retValue;
	}

	/// <summary> 
	/// Convert the JobDataMap into a list of properties.
	/// </summary>
	protected virtual IDictionary ConvertFromProperty(NameValueCollection properties)
	{
		IDictionary<string, string> data = new Dictionary<string, string>();
		string[] allKeys = properties.AllKeys;
		foreach (string key in allKeys)
		{
			data[key] = properties[key];
		}
		return (IDictionary)data;
	}

	/// <summary>
	/// Convert the JobDataMap into a list of properties.
	/// </summary>
	protected virtual NameValueCollection ConvertToProperty(IDictionary<string, object> data)
	{
		NameValueCollection properties = new NameValueCollection();
		foreach (KeyValuePair<string, object> entry in data)
		{
			object key = entry.Key;
			object val = entry.Value ?? string.Empty;
			if (!(key is string))
			{
				throw new IOException("JobDataMap keys/values must be Strings when the 'useProperties' property is set.  offending Key: " + key);
			}
			if (!(val is string))
			{
				throw new IOException("JobDataMap values must be Strings when the 'useProperties' property is set.  Key of offending value: " + key);
			}
			properties[(string)key] = (string)val;
		}
		return properties;
	}

	/// <summary>
	/// This method should be overridden by any delegate subclasses that need
	/// special handling for BLOBs. The default implementation uses standard
	/// ADO.NET operations.
	/// </summary>
	/// <param name="rs">The data reader, already queued to the correct row.</param>
	/// <param name="colIndex">The column index for the BLOB.</param>
	/// <returns>The deserialized object from the DataReader BLOB.</returns>
	protected virtual T GetObjectFromBlob<T>(IDataReader rs, int colIndex) where T : class
	{
		T obj = null;
		byte[] data = ReadBytesFromBlob(rs, colIndex);
		if (data != null && data.Length > 0)
		{
			return objectSerializer.DeSerialize<T>(data);
		}
		return obj;
	}

	protected virtual byte[] ReadBytesFromBlob(IDataReader dr, int colIndex)
	{
		if (dr.IsDBNull(colIndex))
		{
			return null;
		}
		byte[] outbyte = new byte[dr.GetBytes(colIndex, 0L, null, 0, int.MaxValue)];
		dr.GetBytes(colIndex, 0L, outbyte, 0, outbyte.Length);
		using MemoryStream stream = new MemoryStream();
		stream.Write(outbyte, 0, outbyte.Length);
		return outbyte;
	}

	/// <summary>
	/// This method should be overridden by any delegate subclasses that need
	/// special handling for BLOBs for job details. 
	/// </summary>
	/// <param name="rs">The result set, already queued to the correct row.</param>
	/// <param name="colIndex">The column index for the BLOB.</param>
	/// <returns>The deserialized Object from the ResultSet BLOB.</returns>
	protected virtual T GetJobDataFromBlob<T>(IDataReader rs, int colIndex) where T : class
	{
		if (CanUseProperties)
		{
			if (!rs.IsDBNull(colIndex))
			{
				return GetObjectFromBlob<T>(rs, colIndex);
			}
			return null;
		}
		return GetObjectFromBlob<T>(rs, colIndex);
	}

	/// <summary>
	/// Selects the paused trigger groups.
	/// </summary>
	/// <param name="conn">The DB Connection.</param>
	/// <returns></returns>
	public virtual Quartz.Collection.ISet<string> SelectPausedTriggerGroups(ConnectionAndTransactionHolder conn)
	{
		Quartz.Collection.HashSet<string> retValue = new Quartz.Collection.HashSet<string>();
		using IDbCommand cmd = PrepareCommand(conn, ReplaceTablePrefix(StdAdoConstants.SqlSelectPausedTriggerGroups));
		using (IDataReader dr = cmd.ExecuteReader())
		{
			while (dr.Read())
			{
				string groupName = (string)dr["TRIGGER_GROUP"];
				retValue.Add(groupName);
			}
		}
		return retValue;
	}

	public virtual IDbCommand PrepareCommand(ConnectionAndTransactionHolder cth, string commandText)
	{
		return adoUtil.PrepareCommand(cth, commandText);
	}

	public virtual void AddCommandParameter(IDbCommand cmd, string paramName, object paramValue)
	{
		AddCommandParameter(cmd, paramName, paramValue, null);
	}

	public virtual void AddCommandParameter(IDbCommand cmd, string paramName, object paramValue, Enum dataType)
	{
		adoUtil.AddCommandParameter(cmd, paramName, paramValue, dataType);
	}
}
