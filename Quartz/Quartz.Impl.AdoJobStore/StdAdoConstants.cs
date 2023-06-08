using System.Globalization;

namespace Quartz.Impl.AdoJobStore;

/// <summary>
/// This class extends <see cref="T:Quartz.Impl.AdoJobStore.AdoConstants" />
/// to include the query string constants in use by the <see cref="T:Quartz.Impl.AdoJobStore.StdAdoDelegate" />
/// class.
/// </summary>
/// <author><a href="mailto:jeff@binaryfeed.org">Jeffrey Wescott</a></author>
/// <author>Marko Lahma (.NET)</author>
public class StdAdoConstants : AdoConstants
{
	public const string TablePrefixSubst = "{0}";

	public const string SchedulerNameSubst = "{1}";

	public static readonly string SqlDeleteBlobTrigger = string.Format(CultureInfo.InvariantCulture, "DELETE FROM {0}{1} WHERE {2} = {3} AND {4} = @triggerName AND {5} = @triggerGroup", "{0}", "BLOB_TRIGGERS", "SCHED_NAME", "{1}", "TRIGGER_NAME", "TRIGGER_GROUP");

	public static readonly string SqlDeleteCalendar = string.Format(CultureInfo.InvariantCulture, "DELETE FROM {0}{1} WHERE {2} = {3} AND {4} = @calendarName", "{0}", "CALENDARS", "SCHED_NAME", "{1}", "CALENDAR_NAME");

	public static readonly string SqlDeleteCronTrigger = string.Format(CultureInfo.InvariantCulture, "DELETE FROM {0}{1} WHERE {2} = {3} AND {4} = @triggerName AND {5} = @triggerGroup", "{0}", "CRON_TRIGGERS", "SCHED_NAME", "{1}", "TRIGGER_NAME", "TRIGGER_GROUP");

	public static readonly string SqlDeleteFiredTrigger = string.Format(CultureInfo.InvariantCulture, "DELETE FROM {0}{1} WHERE {2} = {3} AND {4} = @triggerEntryId", "{0}", "FIRED_TRIGGERS", "SCHED_NAME", "{1}", "ENTRY_ID");

	public static readonly string SqlDeleteFiredTriggers = string.Format(CultureInfo.InvariantCulture, "DELETE FROM {0}{1} WHERE {2} = {3}", "{0}", "FIRED_TRIGGERS", "SCHED_NAME", "{1}");

	public static readonly string SqlDeleteInstancesFiredTriggers = string.Format(CultureInfo.InvariantCulture, "DELETE FROM {0}{1} WHERE {2} = {3} AND {4} = @instanceName", "{0}", "FIRED_TRIGGERS", "SCHED_NAME", "{1}", "INSTANCE_NAME");

	public static readonly string SqlDeleteJobDetail = string.Format(CultureInfo.InvariantCulture, "DELETE FROM {0}{1} WHERE {2} = {3} AND {4} = @jobName AND {5} = @jobGroup", "{0}", "JOB_DETAILS", "SCHED_NAME", "{1}", "JOB_NAME", "JOB_GROUP");

	public static readonly string SqlDeleteNoRecoveryFiredTriggers = string.Format(CultureInfo.InvariantCulture, "DELETE FROM {0}{1} WHERE {2} = {3} AND {4} = @instanceName AND {5} = @requestsRecovery", "{0}", "FIRED_TRIGGERS", "SCHED_NAME", "{1}", "INSTANCE_NAME", "REQUESTS_RECOVERY");

	public static readonly string SqlDeletePausedTriggerGroup = string.Format(CultureInfo.InvariantCulture, "DELETE FROM {0}{1} WHERE {2} = {3} AND {4} LIKE @triggerGroup", "{0}", "PAUSED_TRIGGER_GRPS", "SCHED_NAME", "{1}", "TRIGGER_GROUP");

	public static readonly string SqlDeletePausedTriggerGroups = string.Format(CultureInfo.InvariantCulture, "DELETE FROM {0}{1} WHERE {2} = {3}", "{0}", "PAUSED_TRIGGER_GRPS", "SCHED_NAME", "{1}");

	public static readonly string SqlDeleteSchedulerState = string.Format(CultureInfo.InvariantCulture, "DELETE FROM {0}{1} WHERE {2} = {3} AND {4} = @instanceName", "{0}", "SCHEDULER_STATE", "SCHED_NAME", "{1}", "INSTANCE_NAME");

	public static readonly string SqlDeleteSimpleTrigger = string.Format(CultureInfo.InvariantCulture, "DELETE FROM {0}{1} WHERE {2} = {3} AND {4} = @triggerName AND {5} = @triggerGroup", "{0}", "SIMPLE_TRIGGERS", "SCHED_NAME", "{1}", "TRIGGER_NAME", "TRIGGER_GROUP");

	public static readonly string SqlDeleteTrigger = string.Format(CultureInfo.InvariantCulture, "DELETE FROM {0}{1} WHERE {2} = {3} AND {4} = @triggerName AND {5} = @triggerGroup", "{0}", "TRIGGERS", "SCHED_NAME", "{1}", "TRIGGER_NAME", "TRIGGER_GROUP");

	public static readonly string SqlDeleteAllSimpleTriggers = string.Format("DELETE FROM {0}SIMPLE_TRIGGERS WHERE {1} = {2}", "{0}", "SCHED_NAME", "{1}");

	public static readonly string SqlDeleteAllSimpropTriggers = string.Format("DELETE FROM {0}SIMPROP_TRIGGERS WHERE {1} = {2}", "{0}", "SCHED_NAME", "{1}");

	public static readonly string SqlDeleteAllCronTriggers = string.Format("DELETE FROM {0}CRON_TRIGGERS WHERE {1} = {2}", "{0}", "SCHED_NAME", "{1}");

	public static readonly string SqlDeleteAllBlobTriggers = string.Format("DELETE FROM {0}BLOB_TRIGGERS WHERE {1} = {2}", "{0}", "SCHED_NAME", "{1}");

	public static readonly string SqlDeleteAllTriggers = string.Format("DELETE FROM {0}TRIGGERS WHERE {1} = {2}", "{0}", "SCHED_NAME", "{1}");

	public static readonly string SqlDeleteAllJobDetails = string.Format("DELETE FROM {0}JOB_DETAILS WHERE {1} = {2}", "{0}", "SCHED_NAME", "{1}");

	public static readonly string SqlDeleteAllCalendars = string.Format("DELETE FROM {0}CALENDARS WHERE {1} = {2}", "{0}", "SCHED_NAME", "{1}");

	public static readonly string SqlDeleteAllPausedTriggerGrps = string.Format("DELETE FROM {0}PAUSED_TRIGGER_GRPS WHERE {1} = {2}", "{0}", "SCHED_NAME", "{1}");

	public static readonly string SqlInsertBlobTrigger = string.Format(CultureInfo.InvariantCulture, "INSERT INTO {0}{1} ({2}, {3}, {4}, {5})  VALUES({6}, @triggerName, @triggerGroup, @blob)", "{0}", "BLOB_TRIGGERS", "SCHED_NAME", "TRIGGER_NAME", "TRIGGER_GROUP", "BLOB_DATA", "{1}");

	public static readonly string SqlInsertCalendar = string.Format(CultureInfo.InvariantCulture, "INSERT INTO {0}{1} ({2}, {3}, {4})  VALUES({5}, @calendarName, @calendar)", "{0}", "CALENDARS", "SCHED_NAME", "CALENDAR_NAME", "CALENDAR", "{1}");

	public static readonly string SqlInsertCronTrigger = string.Format(CultureInfo.InvariantCulture, "INSERT INTO {0}{1} ({2}, {3}, {4}, {5}, {6}) VALUES({7}, @triggerName, @triggerGroup, @triggerCronExpression, @triggerTimeZone)", "{0}", "CRON_TRIGGERS", "SCHED_NAME", "TRIGGER_NAME", "TRIGGER_GROUP", "CRON_EXPRESSION", "TIME_ZONE_ID", "{1}");

	public static readonly string SqlInsertFiredTrigger = string.Format(CultureInfo.InvariantCulture, "INSERT INTO {0}{1} ({2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}) VALUES({14}, @triggerEntryId, @triggerName, @triggerGroup, @triggerInstanceName, @triggerFireTime, @triggerState, @triggerJobName, @triggerJobGroup, @triggerJobStateful, @triggerJobRequestsRecovery, @triggerPriority)", "{0}", "FIRED_TRIGGERS", "SCHED_NAME", "ENTRY_ID", "TRIGGER_NAME", "TRIGGER_GROUP", "INSTANCE_NAME", "FIRED_TIME", "STATE", "JOB_NAME", "JOB_GROUP", "IS_NONCONCURRENT", "REQUESTS_RECOVERY", "PRIORITY", "{1}");

	public static readonly string SqlInsertJobDetail = string.Format(CultureInfo.InvariantCulture, "INSERT INTO {0}{1} ({2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11})  VALUES({12}, @jobName, @jobGroup, @jobDescription, @jobType, @jobDurable, @jobVolatile, @jobStateful, @jobRequestsRecovery, @jobDataMap)", "{0}", "JOB_DETAILS", "SCHED_NAME", "JOB_NAME", "JOB_GROUP", "DESCRIPTION", "JOB_CLASS_NAME", "IS_DURABLE", "IS_NONCONCURRENT", "IS_UPDATE_DATA", "REQUESTS_RECOVERY", "JOB_DATA", "{1}");

	public static readonly string SqlInsertPausedTriggerGroup = string.Format(CultureInfo.InvariantCulture, "INSERT INTO {0}{1} ({2}, {3}) VALUES ({4}, @triggerGroup)", "{0}", "PAUSED_TRIGGER_GRPS", "SCHED_NAME", "TRIGGER_GROUP", "{1}");

	public static readonly string SqlInsertSchedulerState = string.Format(CultureInfo.InvariantCulture, "INSERT INTO {0}{1} ({2}, {3}, {4}, {5}) VALUES({6}, @instanceName, @lastCheckinTime, @checkinInterval)", "{0}", "SCHEDULER_STATE", "SCHED_NAME", "INSTANCE_NAME", "LAST_CHECKIN_TIME", "CHECKIN_INTERVAL", "{1}");

	public static readonly string SqlInsertSimpleTrigger = string.Format(CultureInfo.InvariantCulture, "INSERT INTO {0}{1} ({2}, {3}, {4}, {5}, {6}, {7})  VALUES({8}, @triggerName, @triggerGroup, @triggerRepeatCount, @triggerRepeatInterval, @triggerTimesTriggered)", "{0}", "SIMPLE_TRIGGERS", "SCHED_NAME", "TRIGGER_NAME", "TRIGGER_GROUP", "REPEAT_COUNT", "REPEAT_INTERVAL", "TIMES_TRIGGERED", "{1}");

	public static readonly string SqlInsertTrigger = string.Format(CultureInfo.InvariantCulture, "INSERT INTO {0}{1} ({2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17})  \r\n                        VALUES({18}, @triggerName, @triggerGroup, @triggerJobName, @triggerJobGroup, @triggerDescription, @triggerNextFireTime, @triggerPreviousFireTime, @triggerState, @triggerType, @triggerStartTime, @triggerEndTime, @triggerCalendarName, @triggerMisfireInstruction, @triggerJobJobDataMap, @triggerPriority)", "{0}", "TRIGGERS", "SCHED_NAME", "TRIGGER_NAME", "TRIGGER_GROUP", "JOB_NAME", "JOB_GROUP", "DESCRIPTION", "NEXT_FIRE_TIME", "PREV_FIRE_TIME", "TRIGGER_STATE", "TRIGGER_TYPE", "START_TIME", "END_TIME", "CALENDAR_NAME", "MISFIRE_INSTR", "JOB_DATA", "PRIORITY", "{1}");

	public static readonly string SqlSelectBlobTrigger = string.Format(CultureInfo.InvariantCulture, "SELECT {6} FROM {0}{1} WHERE {2} = {3} AND {4} = @triggerName AND {5} = @triggerGroup", "{0}", "BLOB_TRIGGERS", "SCHED_NAME", "{1}", "TRIGGER_NAME", "TRIGGER_GROUP", "BLOB_DATA");

	public static readonly string SqlSelectCalendar = string.Format(CultureInfo.InvariantCulture, "SELECT {5} FROM {0}{1} WHERE {2} = {3} AND {4} = @calendarName", "{0}", "CALENDARS", "SCHED_NAME", "{1}", "CALENDAR_NAME", "CALENDAR");

	public static readonly string SqlSelectCalendarExistence = string.Format(CultureInfo.InvariantCulture, "SELECT {0} FROM {1}{2} WHERE {3} = {4} AND {5} = @calendarName", "CALENDAR_NAME", "{0}", "CALENDARS", "SCHED_NAME", "{1}", "CALENDAR_NAME");

	public static readonly string SqlSelectCalendars = string.Format(CultureInfo.InvariantCulture, "SELECT {0} FROM {1}{2} WHERE {3} = {4}", "CALENDAR_NAME", "{0}", "CALENDARS", "SCHED_NAME", "{1}");

	public static readonly string SqlSelectCronTriggers = string.Format(CultureInfo.InvariantCulture, "SELECT * FROM {0}{1} WHERE {2} = {3} AND {4} = @triggerName AND {5} = @triggerGroup", "{0}", "CRON_TRIGGERS", "SCHED_NAME", "{1}", "TRIGGER_NAME", "TRIGGER_GROUP");

	public static readonly string SqlSelectFiredTrigger = string.Format(CultureInfo.InvariantCulture, "SELECT * FROM {0}{1} WHERE {2} = {3} AND {4} = @triggerName AND {5} = @triggerGroup", "{0}", "FIRED_TRIGGERS", "SCHED_NAME", "{1}", "TRIGGER_NAME", "TRIGGER_GROUP");

	public static readonly string SqlSelectFiredTriggerGroup = string.Format(CultureInfo.InvariantCulture, "SELECT * FROM {0}{1} WHERE {2} = {3} AND {4} = @triggerGroup", "{0}", "FIRED_TRIGGERS", "SCHED_NAME", "{1}", "TRIGGER_GROUP");

	public static readonly string SqlSelectFiredTriggers = string.Format(CultureInfo.InvariantCulture, "SELECT * FROM {0}{1} WHERE {2} = {3}", "{0}", "FIRED_TRIGGERS", "SCHED_NAME", "{1}");

	public static readonly string SqlSelectFiredTriggerInstanceNames = string.Format(CultureInfo.InvariantCulture, "SELECT DISTINCT {0} FROM {1}{2} WHERE {3} = {4}", "INSTANCE_NAME", "{0}", "FIRED_TRIGGERS", "SCHED_NAME", "{1}");

	public static readonly string SqlSelectFiredTriggersOfJob = string.Format(CultureInfo.InvariantCulture, "SELECT * FROM {0}{1} WHERE {2} = {3} AND {4} = @jobName AND {5} = @jobGroup", "{0}", "FIRED_TRIGGERS", "SCHED_NAME", "{1}", "JOB_NAME", "JOB_GROUP");

	public static readonly string SqlSelectFiredTriggersOfJobGroup = string.Format(CultureInfo.InvariantCulture, "SELECT * FROM {0}{1} WHERE {2} = {3} AND {4} = @jobGroup", "{0}", "FIRED_TRIGGERS", "SCHED_NAME", "{1}", "JOB_GROUP");

	public static readonly string SqlSelectInstancesFiredTriggers = string.Format(CultureInfo.InvariantCulture, "SELECT * FROM {0}{1} WHERE {2} = {3} AND {4} = @instanceName", "{0}", "FIRED_TRIGGERS", "SCHED_NAME", "{1}", "INSTANCE_NAME");

	public static readonly string SqlSelectInstancesRecoverableFiredTriggers = string.Format(CultureInfo.InvariantCulture, "SELECT * FROM {0}{1} WHERE {2} = {3} AND {4} = @instanceName AND {5} = @requestsRecovery", "{0}", "FIRED_TRIGGERS", "SCHED_NAME", "{1}", "INSTANCE_NAME", "REQUESTS_RECOVERY");

	public static readonly string SqlSelectJobDetail = string.Format(CultureInfo.InvariantCulture, "SELECT {6},{7},{8},{9},{10},{11},{12} FROM {0}{1} WHERE {2} = {3} AND {4} = @jobName AND {5} = @jobGroup", "{0}", "JOB_DETAILS", "SCHED_NAME", "{1}", "JOB_NAME", "JOB_GROUP", "JOB_NAME", "JOB_GROUP", "DESCRIPTION", "JOB_CLASS_NAME", "IS_DURABLE", "REQUESTS_RECOVERY", "JOB_DATA");

	public static readonly string SqlSelectJobExecutionCount = string.Format(CultureInfo.InvariantCulture, "SELECT COUNT({0}) FROM {1}{2} WHERE {3} = {4} AND {5} = @jobName AND {6} = @jobGroup", "TRIGGER_NAME", "{0}", "FIRED_TRIGGERS", "SCHED_NAME", "{1}", "JOB_NAME", "JOB_GROUP");

	public static readonly string SqlSelectJobExistence = string.Format(CultureInfo.InvariantCulture, "SELECT {0} FROM {1}{2} WHERE {3} = {4} AND {5} = @jobName AND {6} = @jobGroup", "JOB_NAME", "{0}", "JOB_DETAILS", "SCHED_NAME", "{1}", "JOB_NAME", "JOB_GROUP");

	public static readonly string SqlSelectJobForTrigger = string.Format(CultureInfo.InvariantCulture, "SELECT J.{0}, J.{1}, J.{2}, J.{3}, J.{4} FROM {5}{6} T, {7}{8} J WHERE T.{9} = {10} AND T.{11} = {12} AND T.{13} = @triggerName AND T.{14} = @triggerGroup AND T.{15} = J.{16} AND T.{17} = J.{18}", "JOB_NAME", "JOB_GROUP", "IS_DURABLE", "JOB_CLASS_NAME", "REQUESTS_RECOVERY", "{0}", "TRIGGERS", "{0}", "JOB_DETAILS", "SCHED_NAME", "{1}", "SCHED_NAME", "{1}", "TRIGGER_NAME", "TRIGGER_GROUP", "JOB_NAME", "JOB_NAME", "JOB_GROUP", "JOB_GROUP");

	public static readonly string SqlSelectJobGroups = string.Format(CultureInfo.InvariantCulture, "SELECT DISTINCT({0}) FROM {1}{2} WHERE {3} = {4}", "JOB_GROUP", "{0}", "JOB_DETAILS", "SCHED_NAME", "{1}");

	public static readonly string SqlSelectJobNonConcurrent = string.Format(CultureInfo.InvariantCulture, "SELECT {0} FROM {1}{2} WHERE {3} = {4} AND {5} = @jobName AND {6} = @jobGroup", "IS_NONCONCURRENT", "{0}", "JOB_DETAILS", "SCHED_NAME", "{1}", "JOB_NAME", "JOB_GROUP");

	public static readonly string SqlSelectJobsInGroup = string.Format(CultureInfo.InvariantCulture, "SELECT {0}, {1} FROM {2}{3} WHERE {4} = {5} AND {6} LIKE @jobGroup", "JOB_NAME", "JOB_GROUP", "{0}", "JOB_DETAILS", "SCHED_NAME", "{1}", "JOB_GROUP");

	public static readonly string SqlSelectMisfiredTriggers = string.Format(CultureInfo.InvariantCulture, "SELECT * FROM {0}{1} WHERE {2} = {3} AND {4} <> {5} AND {6} < @nextFireTime ORDER BY {7} ASC, {8} DESC", "{0}", "TRIGGERS", "SCHED_NAME", "{1}", "MISFIRE_INSTR", -1, "NEXT_FIRE_TIME", "NEXT_FIRE_TIME", "PRIORITY");

	public static readonly string SqlSelectMisfiredTriggersInGroupInState = string.Format(CultureInfo.InvariantCulture, "SELECT {0} FROM {1}{2} WHERE {3} = {4} AND {5} <> {6} AND {7} < @nextFireTime AND {8} = @triggerGroup AND {9} = @state ORDER BY {10} ASC, {11} DESC", "TRIGGER_NAME", "{0}", "TRIGGERS", "SCHED_NAME", "{1}", "MISFIRE_INSTR", -1, "NEXT_FIRE_TIME", "TRIGGER_GROUP", "TRIGGER_STATE", "NEXT_FIRE_TIME", "PRIORITY");

	public static readonly string SqlSelectMisfiredTriggersInState = string.Format(CultureInfo.InvariantCulture, "SELECT {0}, {1} FROM {2}{3} WHERE {4} = {5} AND {6} <> {7} AND {8} < @nextFireTime AND {9} = @state ORDER BY {10} ASC, {11} DESC", "TRIGGER_NAME", "TRIGGER_GROUP", "{0}", "TRIGGERS", "SCHED_NAME", "{1}", "MISFIRE_INSTR", -1, "NEXT_FIRE_TIME", "TRIGGER_STATE", "NEXT_FIRE_TIME", "PRIORITY");

	public static readonly string SqlCountMisfiredTriggersInStates = string.Format("SELECT COUNT({0}) FROM {1}{2} WHERE {3} = {4} AND {5} <> {6} AND {7} < @nextFireTime AND {8} = @state1", "TRIGGER_NAME", "{0}", "TRIGGERS", "SCHED_NAME", "{1}", "MISFIRE_INSTR", -1, "NEXT_FIRE_TIME", "TRIGGER_STATE");

	public static readonly string SqlSelectHasMisfiredTriggersInState = string.Format("SELECT {0}, {1} FROM {2}{3} WHERE {4} = {5} AND {6} <> {7} AND {8} < @nextFireTime AND {9} = @state1 ORDER BY {10} ASC, {11} DESC", "TRIGGER_NAME", "TRIGGER_GROUP", "{0}", "TRIGGERS", "SCHED_NAME", "{1}", "MISFIRE_INSTR", -1, "NEXT_FIRE_TIME", "TRIGGER_STATE", "NEXT_FIRE_TIME", "PRIORITY");

	public static readonly string SqlSelectNextTriggerToAcquire = string.Format(CultureInfo.InvariantCulture, "SELECT {0}, {1}, {2}, {3} FROM {4}{5} WHERE {6} = {7} AND {8} = @state AND {9} <= @noLaterThan AND ({10} = -1 OR ({10} <> -1 AND {9} >= @noEarlierThan)) ORDER BY {9} ASC, {11} DESC", "TRIGGER_NAME", "TRIGGER_GROUP", "NEXT_FIRE_TIME", "PRIORITY", "{0}", "TRIGGERS", "SCHED_NAME", "{1}", "TRIGGER_STATE", "NEXT_FIRE_TIME", "MISFIRE_INSTR", "PRIORITY");

	public static readonly string SqlSelectNumCalendars = string.Format(CultureInfo.InvariantCulture, "SELECT COUNT({0})  FROM {1}{2} WHERE {3} = {4}", "CALENDAR_NAME", "{0}", "CALENDARS", "SCHED_NAME", "{1}");

	public static readonly string SqlSelectNumJobs = string.Format(CultureInfo.InvariantCulture, "SELECT COUNT({0})  FROM {1}{2} WHERE {3} = {4}", "JOB_NAME", "{0}", "JOB_DETAILS", "SCHED_NAME", "{1}");

	public static readonly string SqlSelectNumTriggers = string.Format(CultureInfo.InvariantCulture, "SELECT COUNT({0})  FROM {1}{2} WHERE {3} = {4}", "TRIGGER_NAME", "{0}", "TRIGGERS", "SCHED_NAME", "{1}");

	public static readonly string SqlSelectNumTriggersForJob = string.Format(CultureInfo.InvariantCulture, "SELECT COUNT({0}) FROM {1}{2} WHERE {3} = {4} AND {5} = @jobName AND {6} = @jobGroup", "TRIGGER_NAME", "{0}", "TRIGGERS", "SCHED_NAME", "{1}", "JOB_NAME", "JOB_GROUP");

	public static readonly string SqlSelectNumTriggersInGroup = string.Format(CultureInfo.InvariantCulture, "SELECT COUNT({0})  FROM {1}{2} WHERE {3} = {4} AND {5} = @triggerGroup", "TRIGGER_NAME", "{0}", "TRIGGERS", "SCHED_NAME", "{1}", "TRIGGER_GROUP");

	public static readonly string SqlSelectPausedTriggerGroup = string.Format(CultureInfo.InvariantCulture, "SELECT {0} FROM {1}{2} WHERE {3} = {4} AND {5} = @triggerGroup", "TRIGGER_GROUP", "{0}", "PAUSED_TRIGGER_GRPS", "SCHED_NAME", "{1}", "TRIGGER_GROUP");

	public static readonly string SqlSelectPausedTriggerGroups = string.Format(CultureInfo.InvariantCulture, "SELECT {0} FROM {1}{2} WHERE {3} = {4}", "TRIGGER_GROUP", "{0}", "PAUSED_TRIGGER_GRPS", "SCHED_NAME", "{1}");

	public static readonly string SqlSelectReferencedCalendar = string.Format(CultureInfo.InvariantCulture, "SELECT {0} FROM {1}{2} WHERE {3} = {4} AND {5} = @calendarName", "CALENDAR_NAME", "{0}", "TRIGGERS", "SCHED_NAME", "{1}", "CALENDAR_NAME");

	public static readonly string SqlSelectSchedulerState = string.Format(CultureInfo.InvariantCulture, "SELECT * FROM {0}{1} WHERE {2} = {3} AND {4} = @instanceName", "{0}", "SCHEDULER_STATE", "SCHED_NAME", "{1}", "INSTANCE_NAME");

	public static readonly string SqlSelectSchedulerStates = string.Format(CultureInfo.InvariantCulture, "SELECT * FROM {0}{1}", new object[2] { "{0}", "SCHEDULER_STATE" });

	public static readonly string SqlSelectSimpleTrigger = string.Format(CultureInfo.InvariantCulture, "SELECT * FROM {0}{1} WHERE {2} = {3} AND {4} = @triggerName AND {5} = @triggerGroup", "{0}", "SIMPLE_TRIGGERS", "SCHED_NAME", "{1}", "TRIGGER_NAME", "TRIGGER_GROUP");

	public static readonly string SqlSelectTrigger = string.Format(CultureInfo.InvariantCulture, "SELECT {6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17} FROM {0}{1} WHERE {2} = {3} AND {4} = @triggerName AND {5} = @triggerGroup", "{0}", "TRIGGERS", "SCHED_NAME", "{1}", "TRIGGER_NAME", "TRIGGER_GROUP", "JOB_NAME", "JOB_GROUP", "DESCRIPTION", "NEXT_FIRE_TIME", "PREV_FIRE_TIME", "TRIGGER_TYPE", "START_TIME", "END_TIME", "CALENDAR_NAME", "MISFIRE_INSTR", "PRIORITY", "JOB_DATA");

	public static readonly string SqlSelectTriggerData = string.Format(CultureInfo.InvariantCulture, "SELECT {0} FROM {1}{2} WHERE {3} = {4} AND {5} = @triggerName AND {6} = @triggerGroup", "JOB_DATA", "{0}", "TRIGGERS", "SCHED_NAME", "{1}", "TRIGGER_NAME", "TRIGGER_GROUP");

	public static readonly string SqlSelectTriggerExistence = string.Format(CultureInfo.InvariantCulture, "SELECT {0} FROM {1}{2} WHERE {3} = {4} AND {5} = @triggerName AND {6} = @triggerGroup", "TRIGGER_NAME", "{0}", "TRIGGERS", "SCHED_NAME", "{1}", "TRIGGER_NAME", "TRIGGER_GROUP");

	public static readonly string SqlSelectTriggerForFireTime = string.Format(CultureInfo.InvariantCulture, "SELECT {0}, {1} FROM {2}{3} WHERE {4} = {5} AND {6} = @state AND {7} = @nextFireTime", "TRIGGER_NAME", "TRIGGER_GROUP", "{0}", "TRIGGERS", "SCHED_NAME", "{1}", "TRIGGER_STATE", "NEXT_FIRE_TIME");

	public static readonly string SqlSelectTriggerGroups = string.Format(CultureInfo.InvariantCulture, "SELECT DISTINCT({0}) FROM {1}{2} WHERE {3} = {4}", "TRIGGER_GROUP", "{0}", "TRIGGERS", "SCHED_NAME", "{1}");

	public static readonly string SqlSelectTriggerGroupsFiltered = string.Format(CultureInfo.InvariantCulture, "SELECT DISTINCT({0}) FROM {1}{2} WHERE {3} = {4} AND {0} LIKE @triggerGroup", "TRIGGER_GROUP", "{0}", "TRIGGERS", "SCHED_NAME", "{1}");

	public static readonly string SqlSelectTriggerState = string.Format(CultureInfo.InvariantCulture, "SELECT {0} FROM {1}{2} WHERE {3} = {4} AND {5} = @triggerName AND {6} = @triggerGroup", "TRIGGER_STATE", "{0}", "TRIGGERS", "SCHED_NAME", "{1}", "TRIGGER_NAME", "TRIGGER_GROUP");

	public static readonly string SqlSelectTriggerStatus = string.Format(CultureInfo.InvariantCulture, "SELECT {0}, {1}, {2}, {3} FROM {4}{5} WHERE {6} = {7} AND {8} = @triggerName AND {9} = @triggerGroup", "TRIGGER_STATE", "NEXT_FIRE_TIME", "JOB_NAME", "JOB_GROUP", "{0}", "TRIGGERS", "SCHED_NAME", "{1}", "TRIGGER_NAME", "TRIGGER_GROUP");

	public static readonly string SqlSelectTriggersForCalendar = string.Format(CultureInfo.InvariantCulture, "SELECT {0}, {1} FROM {2}{3} WHERE {4} = {5} AND {6} = @calendarName", "TRIGGER_NAME", "TRIGGER_GROUP", "{0}", "TRIGGERS", "SCHED_NAME", "{1}", "CALENDAR_NAME");

	public static readonly string SqlSelectTriggersForJob = string.Format(CultureInfo.InvariantCulture, "SELECT {0}, {1} FROM {2}{3} WHERE {4} = {5} AND {6} = @jobName AND {7} = @jobGroup", "TRIGGER_NAME", "TRIGGER_GROUP", "{0}", "TRIGGERS", "SCHED_NAME", "{1}", "JOB_NAME", "JOB_GROUP");

	public static readonly string SqlSelectTriggersInGroup = string.Format(CultureInfo.InvariantCulture, "SELECT {0}, {1} FROM {2}{3} WHERE {4} = {5} AND {6} LIKE @triggerGroup", "TRIGGER_NAME", "TRIGGER_GROUP", "{0}", "TRIGGERS", "SCHED_NAME", "{1}", "TRIGGER_GROUP");

	public static readonly string SqlSelectTriggersInState = string.Format(CultureInfo.InvariantCulture, "SELECT {0}, {1} FROM {2}{3} WHERE {4} = {5} AND {6} = @state", "TRIGGER_NAME", "TRIGGER_GROUP", "{0}", "TRIGGERS", "SCHED_NAME", "{1}", "TRIGGER_STATE");

	public static readonly string SqlUpdateBlobTrigger = string.Format(CultureInfo.InvariantCulture, "UPDATE {0}{1} SET {2} = @blob WHERE {3} = {4} AND {5} = @triggerName AND {6} = @triggerGroup", "{0}", "BLOB_TRIGGERS", "BLOB_DATA", "SCHED_NAME", "{1}", "TRIGGER_NAME", "TRIGGER_GROUP");

	public static readonly string SqlUpdateCalendar = string.Format(CultureInfo.InvariantCulture, "UPDATE {0}{1} SET {2} = @calendar WHERE {3} = {4} AND {5} = @calendarName", "{0}", "CALENDARS", "CALENDAR", "SCHED_NAME", "{1}", "CALENDAR_NAME");

	public static readonly string SqlUpdateCronTrigger = string.Format(CultureInfo.InvariantCulture, "UPDATE {0}{1} SET {2} = @triggerCronExpression, {3} = @timeZoneId WHERE {4} = {5} AND {6} = @triggerName AND {7} = @triggerGroup", "{0}", "CRON_TRIGGERS", "CRON_EXPRESSION", "TIME_ZONE_ID", "SCHED_NAME", "{1}", "TRIGGER_NAME", "TRIGGER_GROUP");

	public static readonly string SqlUpdateInstancesFiredTriggerState = string.Format(CultureInfo.InvariantCulture, "UPDATE {0}{1} SET {2} = @triggerEntryState AND {3} = @firedTime AND {4} = @priority WHERE {5} = {6} AND {7} = @instanceName", "{0}", "FIRED_TRIGGERS", "STATE", "FIRED_TIME", "PRIORITY", "SCHED_NAME", "{1}", "INSTANCE_NAME");

	public static readonly string SqlUpdateJobData = string.Format(CultureInfo.InvariantCulture, "UPDATE {0}{1} SET {2} = @jobDataMap WHERE {3} = {4} AND {5} = @jobName AND {6} = @jobGroup", "{0}", "JOB_DETAILS", "JOB_DATA", "SCHED_NAME", "{1}", "JOB_NAME", "JOB_GROUP");

	public static readonly string SqlUpdateJobDetail = string.Format(CultureInfo.InvariantCulture, "UPDATE {0}{1} SET {2} = @jobDescription, {3} = @jobType, {4} = @jobDurable, {5} = @jobVolatile, {6} = @jobStateful, {7} = @jobRequestsRecovery, {8} = @jobDataMap  WHERE {9} = {10} AND {11} = @jobName AND {12} = @jobGroup", "{0}", "JOB_DETAILS", "DESCRIPTION", "JOB_CLASS_NAME", "IS_DURABLE", "IS_NONCONCURRENT", "IS_UPDATE_DATA", "REQUESTS_RECOVERY", "JOB_DATA", "SCHED_NAME", "{1}", "JOB_NAME", "JOB_GROUP");

	public static readonly string SqlUpdateJobTriggerStates = string.Format(CultureInfo.InvariantCulture, "UPDATE {0}{1} SET {2} = @state WHERE {3} = {4} AND {5} = @jobName AND {6} = @jobGroup", "{0}", "TRIGGERS", "TRIGGER_STATE", "SCHED_NAME", "{1}", "JOB_NAME", "JOB_GROUP");

	public static readonly string SqlUpdateJobTriggerStatesFromOtherState = string.Format(CultureInfo.InvariantCulture, "UPDATE {0}{1} SET {2} = @state WHERE {3} = {4} AND {5} = @jobName AND {6} = @jobGroup AND {7} = @oldState", "{0}", "TRIGGERS", "TRIGGER_STATE", "SCHED_NAME", "{1}", "JOB_NAME", "JOB_GROUP", "TRIGGER_STATE");

	public static readonly string SqlUpdateSchedulerState = string.Format(CultureInfo.InvariantCulture, "UPDATE {0}{1} SET {2} = @lastCheckinTime WHERE {3} = {4} AND {5} = @instanceName", "{0}", "SCHEDULER_STATE", "LAST_CHECKIN_TIME", "SCHED_NAME", "{1}", "INSTANCE_NAME");

	public static readonly string SqlUpdateSimpleTrigger = string.Format(CultureInfo.InvariantCulture, "UPDATE {0}{1} SET {2} = @triggerRepeatCount, {3} = @triggerRepeatInterval, {4} = @triggerTimesTriggered WHERE {5} = {6} AND {7} = @triggerName AND {8} = @triggerGroup", "{0}", "SIMPLE_TRIGGERS", "REPEAT_COUNT", "REPEAT_INTERVAL", "TIMES_TRIGGERED", "SCHED_NAME", "{1}", "TRIGGER_NAME", "TRIGGER_GROUP");

	public static readonly string SqlUpdateTrigger = string.Format(CultureInfo.InvariantCulture, "UPDATE {0}{1} SET {2} = @triggerJobName, {3} = @triggerJobGroup, {4} = @triggerDescription, {5} = @triggerNextFireTime, {6} = @triggerPreviousFireTime,\r\n                        {7} = @triggerState, {8} = @triggerType, {9} = @triggerStartTime, {10} = @triggerEndTime, {11} = @triggerCalendarName, {12} = @triggerMisfireInstruction, {13} = @triggerPriority, {14} = @triggerJobJobDataMap\r\n                        WHERE {15} = {16} AND {17} = @triggerName AND {18} = @triggerGroup", "{0}", "TRIGGERS", "JOB_NAME", "JOB_GROUP", "DESCRIPTION", "NEXT_FIRE_TIME", "PREV_FIRE_TIME", "TRIGGER_STATE", "TRIGGER_TYPE", "START_TIME", "END_TIME", "CALENDAR_NAME", "MISFIRE_INSTR", "PRIORITY", "JOB_DATA", "SCHED_NAME", "{1}", "TRIGGER_NAME", "TRIGGER_GROUP");

	public static readonly string SqlUpdateFiredTrigger = string.Format(CultureInfo.InvariantCulture, "UPDATE {0}{1} SET {2} = @instanceName, {3} = @firedTime, {4} = @entryState, {5} = @jobName, {6} = @jobGroup, {7} = @isNonConcurrent, {8} = @requestsRecover WHERE {9} = {10} AND {11} = @entryId", "{0}", "FIRED_TRIGGERS", "INSTANCE_NAME", "FIRED_TIME", "STATE", "JOB_NAME", "JOB_GROUP", "IS_NONCONCURRENT", "REQUESTS_RECOVERY", "SCHED_NAME", "{1}", "ENTRY_ID");

	public static readonly string SqlUpdateTriggerGroupStateFromState = string.Format(CultureInfo.InvariantCulture, "UPDATE {0}{1} SET {2} = @newState WHERE {3} = {4} AND {5} LIKE @triggerGroup AND {6} = @oldState", "{0}", "TRIGGERS", "TRIGGER_STATE", "SCHED_NAME", "{1}", "TRIGGER_GROUP", "TRIGGER_STATE");

	public static readonly string SqlUpdateTriggerGroupStateFromStates = string.Format(CultureInfo.InvariantCulture, "UPDATE {0}{1} SET {2} = @newState WHERE {3} = {4} AND {5} LIKE @groupName AND ({6} = @oldState1 OR {7} = @oldState2 OR {8} = @oldState3)", "{0}", "TRIGGERS", "TRIGGER_STATE", "SCHED_NAME", "{1}", "TRIGGER_GROUP", "TRIGGER_STATE", "TRIGGER_STATE", "TRIGGER_STATE");

	public static readonly string SqlUpdateTriggerSkipData = string.Format(CultureInfo.InvariantCulture, "UPDATE {0}{1} SET {2} = @triggerJobName, {3} = @triggerJobGroup, {4} = @triggerDescription, {5} = @triggerNextFireTime, {6} = @triggerPreviousFireTime, \r\n                        {7} = @triggerState, {8} = @triggerType, {9} = @triggerStartTime, {10} = @triggerEndTime, {11} = @triggerCalendarName, {12} = @triggerMisfireInstruction, {13} = @triggerPriority\r\n                    WHERE {14} = {15} AND {16} = @triggerName AND {17} = @triggerGroup", "{0}", "TRIGGERS", "JOB_NAME", "JOB_GROUP", "DESCRIPTION", "NEXT_FIRE_TIME", "PREV_FIRE_TIME", "TRIGGER_STATE", "TRIGGER_TYPE", "START_TIME", "END_TIME", "CALENDAR_NAME", "MISFIRE_INSTR", "PRIORITY", "SCHED_NAME", "{1}", "TRIGGER_NAME", "TRIGGER_GROUP");

	public static readonly string SqlUpdateTriggerState = string.Format(CultureInfo.InvariantCulture, "UPDATE {0}{1} SET {2} = @state WHERE {3} = {4} AND {5} = @triggerName AND {6} = @triggerGroup", "{0}", "TRIGGERS", "TRIGGER_STATE", "SCHED_NAME", "{1}", "TRIGGER_NAME", "TRIGGER_GROUP");

	public static readonly string SqlUpdateTriggerStateFromState = string.Format(CultureInfo.InvariantCulture, "UPDATE {0}{1} SET {2} = @newState WHERE {3} = {4} AND {5} = @triggerName AND {6} = @triggerGroup AND {7} = @oldState", "{0}", "TRIGGERS", "TRIGGER_STATE", "SCHED_NAME", "{1}", "TRIGGER_NAME", "TRIGGER_GROUP", "TRIGGER_STATE");

	public static readonly string SqlUpdateTriggerStateFromStates = string.Format(CultureInfo.InvariantCulture, "UPDATE {0}{1} SET {2} = @newState WHERE {3} = {4} AND {5} = @triggerName AND {6} = @triggerGroup AND ({7} = @oldState1 OR {8} = @oldState2 OR {9} = @oldState3)", "{0}", "TRIGGERS", "TRIGGER_STATE", "SCHED_NAME", "{1}", "TRIGGER_NAME", "TRIGGER_GROUP", "TRIGGER_STATE", "TRIGGER_STATE", "TRIGGER_STATE");

	public static readonly string SqlUpdateTriggerStatesFromOtherStates = string.Format(CultureInfo.InvariantCulture, "UPDATE {0}{1} SET {2} = @newState WHERE {3} = {4} AND ({5} = @oldState1 OR {6} = @oldState2)", "{0}", "TRIGGERS", "TRIGGER_STATE", "SCHED_NAME", "{1}", "TRIGGER_STATE", "TRIGGER_STATE");
}
