using System;
using System.Collections.Generic;
using Quartz.Collection;
using Quartz.Impl.Matchers;
using Quartz.Spi;

namespace Quartz;

/// <summary>
/// This is the main interface of a Quartz Scheduler.
/// </summary>
/// <remarks>
/// 	<para>
///         A <see cref="T:Quartz.IScheduler" /> maintains a registry of
///         <see cref="T:Quartz.IJobDetail" />s and <see cref="T:Quartz.ITrigger" />s. Once
///         registered, the <see cref="T:Quartz.IScheduler" /> is responsible for executing
///         <see cref="T:Quartz.IJob" /> s when their associated <see cref="T:Quartz.ITrigger" /> s
///         fire (when their scheduled time arrives).
///     </para>
/// 	<para>
/// 		<see cref="T:Quartz.IScheduler" /> instances are produced by a
///         <see cref="T:Quartz.ISchedulerFactory" />. A scheduler that has already been
///         created/initialized can be found and used through the same factory that
///         produced it. After a <see cref="T:Quartz.IScheduler" /> has been created, it is in
///         "stand-by" mode, and must have its <see cref="M:Quartz.IScheduler.Start" /> method
///         called before it will fire any <see cref="T:Quartz.IJob" />s.
///     </para>
/// 	<para>
/// 		<see cref="T:Quartz.IJob" /> s are to be created by the 'client program', by
///         defining a class that implements the <see cref="T:Quartz.IJob" /> interface.
///         <see cref="T:Quartz.IJobDetail" /> objects are then created (also by the client) to
///         define a individual instances of the <see cref="T:Quartz.IJob" />.
///         <see cref="T:Quartz.IJobDetail" /> instances can then be registered with the
///         <see cref="T:Quartz.IScheduler" /> via the %IScheduler.ScheduleJob(JobDetail,
///         Trigger)% or %IScheduler.AddJob(JobDetail, bool)% method.
///     </para>
/// 	<para>
/// 		<see cref="T:Quartz.ITrigger" /> s can then be defined to fire individual
///         <see cref="T:Quartz.IJob" /> instances based on given schedules.
///         <see cref="T:Quartz.ISimpleTrigger" /> s are most useful for one-time firings, or
///         firing at an exact moment in time, with N repeats with a given delay between
///         them. <see cref="T:Quartz.ICronTrigger" /> s allow scheduling based on time of day,
///         day of week, day of month, and month of year.
///     </para>
/// 	<para>
/// 		<see cref="T:Quartz.IJob" /> s and <see cref="T:Quartz.ITrigger" /> s have a name and
///         group associated with them, which should uniquely identify them within a single
///         <see cref="T:Quartz.IScheduler" />. The 'group' feature may be useful for creating
///         logical groupings or categorizations of <see cref="T:Quartz.IJob" />s and
///         <see cref="T:Quartz.ITrigger" />s. If you don't have need for assigning a group to a
///         given <see cref="T:Quartz.IJob" />s of <see cref="T:Quartz.ITrigger" />s, then you can use
///         the <see cref="F:Quartz.SchedulerConstants.DefaultGroup" /> constant defined on
///         this interface.
///     </para>
/// 	<para>
///         Stored <see cref="T:Quartz.IJob" /> s can also be 'manually' triggered through the
///         use of the %IScheduler.TriggerJob(string, string)% function.
///     </para>
/// 	<para>
///         Client programs may also be interested in the 'listener' interfaces that are
///         available from Quartz. The <see cref="T:Quartz.IJobListener" /> interface provides
///         notifications of <see cref="T:Quartz.IJob" /> executions. The
///         <see cref="T:Quartz.ITriggerListener" /> interface provides notifications of
///         <see cref="T:Quartz.ITrigger" /> firings. The <see cref="T:Quartz.ISchedulerListener" />
///         interface provides notifications of <see cref="T:Quartz.IScheduler" /> events and
///         errors.  Listeners can be associated with local schedulers through the
///         <see cref="T:Quartz.IListenerManager" /> interface.  
///     </para>
/// 	<para>
///         The setup/configuration of a <see cref="T:Quartz.IScheduler" /> instance is very
///         customizable. Please consult the documentation distributed with Quartz.
///     </para>
/// </remarks>
/// <seealso cref="T:Quartz.IJob" />
/// <seealso cref="T:Quartz.IJobDetail" />
/// <seealso cref="T:Quartz.ITrigger" />
/// <seealso cref="T:Quartz.IJobListener" />
/// <seealso cref="T:Quartz.ITriggerListener" />
/// <seealso cref="T:Quartz.ISchedulerListener" />
/// <author>Marko Lahma (.NET)</author>
public interface IScheduler
{
	/// <summary> 
	/// Returns the name of the <see cref="T:Quartz.IScheduler" />.
	/// </summary>
	string SchedulerName { get; }

	/// <summary>
	/// Returns the instance Id of the <see cref="T:Quartz.IScheduler" />.
	/// </summary>
	string SchedulerInstanceId { get; }

	/// <summary>
	/// Returns the <see cref="T:Quartz.SchedulerContext" /> of the <see cref="T:Quartz.IScheduler" />.
	/// </summary>
	SchedulerContext Context { get; }

	/// <summary>
	/// Reports whether the <see cref="T:Quartz.IScheduler" /> is in stand-by mode.
	/// </summary>
	/// <seealso cref="M:Quartz.IScheduler.Standby" />
	/// <seealso cref="M:Quartz.IScheduler.Start" />
	bool InStandbyMode { get; }

	/// <summary>
	/// Reports whether the <see cref="T:Quartz.IScheduler" /> has been Shutdown.
	/// </summary>
	bool IsShutdown { get; }

	/// <summary>
	/// Set the <see cref="P:Quartz.IScheduler.JobFactory" /> that will be responsible for producing 
	/// instances of <see cref="T:Quartz.IJob" /> classes.
	/// </summary>
	/// <remarks>
	/// JobFactories may be of use to those wishing to have their application
	/// produce <see cref="T:Quartz.IJob" /> instances via some special mechanism, such as to
	/// give the opportunity for dependency injection.
	/// </remarks>
	/// <seealso cref="T:Quartz.Spi.IJobFactory" />
	IJobFactory JobFactory { set; }

	/// <summary>
	/// Get a reference to the scheduler's <see cref="T:Quartz.IListenerManager" />,
	/// through which listeners may be registered.
	/// </summary>
	/// <returns>the scheduler's <see cref="T:Quartz.IListenerManager" /></returns>
	/// <seealso cref="P:Quartz.IScheduler.ListenerManager" />
	/// <seealso cref="T:Quartz.IJobListener" />
	/// <seealso cref="T:Quartz.ITriggerListener" />
	/// <seealso cref="T:Quartz.ISchedulerListener" />
	IListenerManager ListenerManager { get; }

	/// <summary>
	/// Whether the scheduler has been started.  
	/// </summary>
	/// <remarks>
	/// Note: This only reflects whether <see cref="M:Quartz.IScheduler.Start" /> has ever
	/// been called on this Scheduler, so it will return <see langword="true" /> even 
	/// if the <see cref="T:Quartz.IScheduler" /> is currently in standby mode or has been 
	/// since shutdown.
	/// </remarks>
	/// <seealso cref="M:Quartz.IScheduler.Start" />
	/// <seealso cref="P:Quartz.IScheduler.IsShutdown" />
	/// <seealso cref="P:Quartz.IScheduler.InStandbyMode" />
	bool IsStarted { get; }

	/// <summary>
	/// returns true if the given JobGroup
	/// is paused
	/// </summary>
	/// <param name="groupName"></param>
	/// <returns></returns>
	bool IsJobGroupPaused(string groupName);

	/// <summary>
	/// returns true if the given TriggerGroup
	/// is paused
	/// </summary>
	/// <param name="groupName"></param>
	/// <returns></returns>
	bool IsTriggerGroupPaused(string groupName);

	/// <summary>
	/// Get a <see cref="T:Quartz.SchedulerMetaData" /> object describing the settings
	/// and capabilities of the scheduler instance.
	/// </summary>
	/// <remarks>
	/// Note that the data returned is an 'instantaneous' snap-shot, and that as
	/// soon as it's returned, the meta data values may be different.
	/// </remarks>
	SchedulerMetaData GetMetaData();

	/// <summary>
	/// Return a list of <see cref="T:Quartz.IJobExecutionContext" /> objects that
	/// represent all currently executing Jobs in this Scheduler instance.
	/// </summary>
	/// <remarks>
	/// <para>
	/// This method is not cluster aware.  That is, it will only return Jobs
	/// currently executing in this Scheduler instance, not across the entire
	/// cluster.
	/// </para>
	/// <para>
	/// Note that the list returned is an 'instantaneous' snap-shot, and that as
	/// soon as it's returned, the true list of executing jobs may be different.
	/// Also please read the doc associated with <see cref="T:Quartz.IJobExecutionContext" />-
	/// especially if you're using remoting.
	/// </para>
	/// </remarks>
	/// <seealso cref="T:Quartz.IJobExecutionContext" />
	IList<IJobExecutionContext> GetCurrentlyExecutingJobs();

	/// <summary>
	/// Get the names of all known <see cref="T:Quartz.IJobDetail" /> groups.
	/// </summary>
	IList<string> GetJobGroupNames();

	/// <summary>
	/// Get the names of all known <see cref="T:Quartz.ITrigger" /> groups.
	/// </summary>
	IList<string> GetTriggerGroupNames();

	/// <summary> 
	/// Get the names of all <see cref="T:Quartz.ITrigger" /> groups that are paused.
	/// </summary>
	Quartz.Collection.ISet<string> GetPausedTriggerGroups();

	/// <summary>
	/// Starts the <see cref="T:Quartz.IScheduler" />'s threads that fire <see cref="T:Quartz.ITrigger" />s.
	/// When a scheduler is first created it is in "stand-by" mode, and will not
	/// fire triggers.  The scheduler can also be put into stand-by mode by
	/// calling the <see cref="M:Quartz.IScheduler.Standby" /> method.
	/// </summary>
	/// <remarks>
	/// The misfire/recovery process will be started, if it is the initial call
	/// to this method on this scheduler instance.
	/// </remarks>
	/// <seealso cref="M:Quartz.IScheduler.StartDelayed(System.TimeSpan)" />
	/// <seealso cref="M:Quartz.IScheduler.Standby" />
	/// <seealso cref="M:Quartz.IScheduler.Shutdown(System.Boolean)" />
	void Start();

	/// <summary>
	/// Calls <see cref="M:Quartz.IScheduler.Start" /> after the indicated delay.
	/// (This call does not block). This can be useful within applications that
	/// have initializers that create the scheduler immediately, before the
	/// resources needed by the executing jobs have been fully initialized.
	/// </summary>
	/// <seealso cref="M:Quartz.IScheduler.Start" />
	/// <seealso cref="M:Quartz.IScheduler.Standby" />
	/// <seealso cref="M:Quartz.IScheduler.Shutdown(System.Boolean)" />
	void StartDelayed(TimeSpan delay);

	/// <summary>
	/// Temporarily halts the <see cref="T:Quartz.IScheduler" />'s firing of <see cref="T:Quartz.ITrigger" />s.
	/// </summary>
	/// <remarks>
	/// <para>
	/// When <see cref="M:Quartz.IScheduler.Start" /> is called (to bring the scheduler out of 
	/// stand-by mode), trigger misfire instructions will NOT be applied
	/// during the execution of the <see cref="M:Quartz.IScheduler.Start" /> method - any misfires 
	/// will be detected immediately afterward (by the <see cref="T:Quartz.Spi.IJobStore" />'s 
	/// normal process).
	/// </para>
	/// <para>
	/// The scheduler is not destroyed, and can be re-started at any time.
	/// </para>
	/// </remarks>
	/// <seealso cref="M:Quartz.IScheduler.Start" />
	/// <seealso cref="M:Quartz.IScheduler.PauseAll" />
	void Standby();

	/// <summary> 
	/// Halts the <see cref="T:Quartz.IScheduler" />'s firing of <see cref="T:Quartz.ITrigger" />s,
	/// and cleans up all resources associated with the Scheduler. Equivalent to
	/// <see cref="M:Quartz.IScheduler.Shutdown(System.Boolean)" />.
	/// </summary>
	/// <remarks>
	/// The scheduler cannot be re-started.
	/// </remarks>
	/// <seealso cref="M:Quartz.IScheduler.Shutdown(System.Boolean)" />
	void Shutdown();

	/// <summary>
	/// Halts the <see cref="T:Quartz.IScheduler" />'s firing of <see cref="T:Quartz.ITrigger" />s,
	/// and cleans up all resources associated with the Scheduler. 
	/// </summary>
	/// <remarks>
	/// The scheduler cannot be re-started.
	/// </remarks>
	/// <param name="waitForJobsToComplete">
	/// if <see langword="true" /> the scheduler will not allow this method
	/// to return until all currently executing jobs have completed.
	/// </param>
	/// <seealso cref="M:Quartz.IScheduler.Shutdown" /> 
	void Shutdown(bool waitForJobsToComplete);

	/// <summary>
	/// Add the given <see cref="T:Quartz.IJobDetail" /> to the
	/// Scheduler, and associate the given <see cref="T:Quartz.ITrigger" /> with
	/// it.
	/// </summary>
	/// <remarks>
	/// If the given Trigger does not reference any <see cref="T:Quartz.IJob" />, then it
	/// will be set to reference the Job passed with it into this method.
	/// </remarks>
	DateTimeOffset ScheduleJob(IJobDetail jobDetail, ITrigger trigger);

	/// <summary>
	/// Schedule the given <see cref="T:Quartz.ITrigger" /> with the
	/// <see cref="T:Quartz.IJob" /> identified by the <see cref="T:Quartz.ITrigger" />'s settings.
	/// </summary>
	DateTimeOffset ScheduleJob(ITrigger trigger);

	/// <summary>
	/// Schedule all of the given jobs with the related set of triggers.
	/// </summary>
	/// <remarks>
	/// <para>If any of the given jobs or triggers already exist (or more
	/// specifically, if the keys are not unique) and the replace
	/// parameter is not set to true then an exception will be thrown.</para>
	/// </remarks>
	void ScheduleJobs(IDictionary<IJobDetail, Quartz.Collection.ISet<ITrigger>> triggersAndJobs, bool replace);

	/// <summary>
	/// Schedule the given job with the related set of triggers.
	/// </summary>
	/// <remarks>
	/// If any of the given job or triggers already exist (or more
	/// specifically, if the keys are not unique) and the replace 
	/// parameter is not set to true then an exception will be thrown.
	/// </remarks>
	/// <param name="jobDetail"></param>
	/// <param name="triggersForJob"></param>
	/// <param name="replace"></param>
	void ScheduleJob(IJobDetail jobDetail, Quartz.Collection.ISet<ITrigger> triggersForJob, bool replace);

	/// <summary>
	/// Remove the indicated <see cref="T:Quartz.ITrigger" /> from the scheduler.
	/// <para>If the related job does not have any other triggers, and the job is
	/// not durable, then the job will also be deleted.</para>
	/// </summary>
	bool UnscheduleJob(TriggerKey triggerKey);

	/// <summary>
	/// Remove all of the indicated <see cref="T:Quartz.ITrigger" />s from the scheduler.
	/// </summary>
	/// <remarks>
	/// <para>If the related job does not have any other triggers, and the job is
	/// not durable, then the job will also be deleted.</para>
	/// Note that while this bulk operation is likely more efficient than
	/// invoking <see cref="M:Quartz.IScheduler.UnscheduleJob(Quartz.TriggerKey)" /> several
	/// times, it may have the adverse affect of holding data locks for a
	/// single long duration of time (rather than lots of small durations
	/// of time).
	/// </remarks>
	bool UnscheduleJobs(IList<TriggerKey> triggerKeys);

	/// <summary>
	/// Remove (delete) the <see cref="T:Quartz.ITrigger" /> with the
	/// given key, and store the new given one - which must be associated
	/// with the same job (the new trigger must have the job name &amp; group specified) 
	/// - however, the new trigger need not have the same name as the old trigger.
	/// </summary>
	/// <param name="triggerKey">The <see cref="T:Quartz.ITrigger" /> to be replaced.</param>
	/// <param name="newTrigger">
	/// The new <see cref="T:Quartz.ITrigger" /> to be stored.
	/// </param>
	/// <returns> 
	/// <see langword="null" /> if a <see cref="T:Quartz.ITrigger" /> with the given
	/// name and group was not found and removed from the store (and the 
	/// new trigger is therefore not stored),  otherwise
	/// the first fire time of the newly scheduled trigger.
	/// </returns>
	DateTimeOffset? RescheduleJob(TriggerKey triggerKey, ITrigger newTrigger);

	/// <summary>
	/// Add the given <see cref="T:Quartz.IJob" /> to the Scheduler - with no associated
	/// <see cref="T:Quartz.ITrigger" />. The <see cref="T:Quartz.IJob" /> will be 'dormant' until
	/// it is scheduled with a <see cref="T:Quartz.ITrigger" />, or <see cref="M:Quartz.IScheduler.TriggerJob(Quartz.JobKey)" />
	/// is called for it.
	/// </summary>
	/// <remarks>
	/// The <see cref="T:Quartz.IJob" /> must by definition be 'durable', if it is not,
	/// SchedulerException will be thrown.
	/// </remarks>
	void AddJob(IJobDetail jobDetail, bool replace);

	/// <summary>
	/// Delete the identified <see cref="T:Quartz.IJob" /> from the Scheduler - and any
	/// associated <see cref="T:Quartz.ITrigger" />s.
	/// </summary>
	/// <returns> true if the Job was found and deleted.</returns>
	bool DeleteJob(JobKey jobKey);

	/// <summary>
	/// Delete the identified jobs from the Scheduler - and any
	/// associated <see cref="T:Quartz.ITrigger" />s.
	/// </summary>
	/// <remarks>
	/// <para>Note that while this bulk operation is likely more efficient than
	/// invoking <see cref="M:Quartz.IScheduler.DeleteJob(Quartz.JobKey)" /> several
	/// times, it may have the adverse affect of holding data locks for a
	/// single long duration of time (rather than lots of small durations
	/// of time).</para>
	/// </remarks>
	/// <returns>
	/// true if all of the Jobs were found and deleted, false if
	/// one or more were not deleted.
	/// </returns>
	bool DeleteJobs(IList<JobKey> jobKeys);

	/// <summary>
	/// Trigger the identified <see cref="T:Quartz.IJobDetail" />
	/// (Execute it now).
	/// </summary>
	void TriggerJob(JobKey jobKey);

	/// <summary>
	/// Trigger the identified <see cref="T:Quartz.IJobDetail" /> (Execute it now).
	/// </summary>
	/// <param name="data">
	/// the (possibly <see langword="null" />) JobDataMap to be
	/// associated with the trigger that fires the job immediately.
	/// </param>
	/// <param name="jobKey">
	/// The <see cref="T:Quartz.JobKey" /> of the <see cref="T:Quartz.IJob" /> to be executed.
	/// </param>
	void TriggerJob(JobKey jobKey, JobDataMap data);

	/// <summary>
	/// Pause the <see cref="T:Quartz.IJobDetail" /> with the given
	/// key - by pausing all of its current <see cref="T:Quartz.ITrigger" />s.
	/// </summary>
	void PauseJob(JobKey jobKey);

	/// <summary>
	/// Pause all of the <see cref="T:Quartz.IJobDetail" />s in the
	/// matching groups - by pausing all of their <see cref="T:Quartz.ITrigger" />s.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The Scheduler will "remember" that the groups are paused, and impose the
	/// pause on any new jobs that are added to any of those groups until it is resumed.
	/// </para>
	/// <para>NOTE: There is a limitation that only exactly matched groups
	/// can be remembered as paused.  For example, if there are pre-existing
	/// job in groups "aaa" and "bbb" and a matcher is given to pause
	/// groups that start with "a" then the group "aaa" will be remembered
	/// as paused and any subsequently added jobs in group "aaa" will be paused,
	/// however if a job is added to group "axx" it will not be paused,
	/// as "axx" wasn't known at the time the "group starts with a" matcher 
	/// was applied.  HOWEVER, if there are pre-existing groups "aaa" and
	/// "bbb" and a matcher is given to pause the group "axx" (with a
	/// group equals matcher) then no jobs will be paused, but it will be 
	/// remembered that group "axx" is paused and later when a job is added 
	/// in that group, it will become paused.</para>
	/// </remarks>
	/// <seealso cref="M:Quartz.IScheduler.ResumeJobs(Quartz.Impl.Matchers.GroupMatcher{Quartz.JobKey})" />
	void PauseJobs(GroupMatcher<JobKey> matcher);

	/// <summary> 
	/// Pause the <see cref="T:Quartz.ITrigger" /> with the given key.
	/// </summary>
	void PauseTrigger(TriggerKey triggerKey);

	/// <summary>
	/// Pause all of the <see cref="T:Quartz.ITrigger" />s in the groups matching.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The Scheduler will "remember" all the groups paused, and impose the
	/// pause on any new triggers that are added to any of those groups until it is resumed.
	/// </para>
	/// <para>NOTE: There is a limitation that only exactly matched groups
	/// can be remembered as paused.  For example, if there are pre-existing
	/// triggers in groups "aaa" and "bbb" and a matcher is given to pause
	/// groups that start with "a" then the group "aaa" will be remembered as
	/// paused and any subsequently added triggers in that group be paused,
	/// however if a trigger is added to group "axx" it will not be paused,
	/// as "axx" wasn't known at the time the "group starts with a" matcher 
	/// was applied.  HOWEVER, if there are pre-existing groups "aaa" and
	/// "bbb" and a matcher is given to pause the group "axx" (with a
	/// group equals matcher) then no triggers will be paused, but it will be 
	/// remembered that group "axx" is paused and later when a trigger is added
	/// in that group, it will become paused.</para>
	/// </remarks>
	/// <seealso cref="M:Quartz.IScheduler.ResumeTriggers(Quartz.Impl.Matchers.GroupMatcher{Quartz.TriggerKey})" />
	void PauseTriggers(GroupMatcher<TriggerKey> matcher);

	/// <summary>
	/// Resume (un-pause) the <see cref="T:Quartz.IJobDetail" /> with
	/// the given key.
	/// </summary>
	/// <remarks>
	/// If any of the <see cref="T:Quartz.IJob" />'s<see cref="T:Quartz.ITrigger" /> s missed one
	/// or more fire-times, then the <see cref="T:Quartz.ITrigger" />'s misfire
	/// instruction will be applied.
	/// </remarks>
	void ResumeJob(JobKey jobKey);

	/// <summary>
	/// Resume (un-pause) all of the <see cref="T:Quartz.IJobDetail" />s
	/// in matching groups.
	/// </summary>
	/// <remarks>
	/// If any of the <see cref="T:Quartz.IJob" /> s had <see cref="T:Quartz.ITrigger" /> s that
	/// missed one or more fire-times, then the <see cref="T:Quartz.ITrigger" />'s
	/// misfire instruction will be applied.
	/// </remarks>
	/// <seealso cref="M:Quartz.IScheduler.PauseJobs(Quartz.Impl.Matchers.GroupMatcher{Quartz.JobKey})" />
	void ResumeJobs(GroupMatcher<JobKey> matcher);

	/// <summary>
	/// Resume (un-pause) the <see cref="T:Quartz.ITrigger" /> with the given
	/// key.
	/// </summary>
	/// <remarks>
	/// If the <see cref="T:Quartz.ITrigger" /> missed one or more fire-times, then the
	/// <see cref="T:Quartz.ITrigger" />'s misfire instruction will be applied.
	/// </remarks>
	void ResumeTrigger(TriggerKey triggerKey);

	/// <summary>
	/// Resume (un-pause) all of the <see cref="T:Quartz.ITrigger" />s in matching groups.
	/// </summary>
	/// <remarks>
	/// If any <see cref="T:Quartz.ITrigger" /> missed one or more fire-times, then the
	/// <see cref="T:Quartz.ITrigger" />'s misfire instruction will be applied.
	/// </remarks>
	/// <seealso cref="M:Quartz.IScheduler.PauseTriggers(Quartz.Impl.Matchers.GroupMatcher{Quartz.TriggerKey})" />
	void ResumeTriggers(GroupMatcher<TriggerKey> matcher);

	/// <summary>
	/// Pause all triggers - similar to calling <see cref="M:Quartz.IScheduler.PauseTriggers(Quartz.Impl.Matchers.GroupMatcher{Quartz.TriggerKey})" />
	/// on every group, however, after using this method <see cref="M:Quartz.IScheduler.ResumeAll" /> 
	/// must be called to clear the scheduler's state of 'remembering' that all 
	/// new triggers will be paused as they are added. 
	/// </summary>
	/// <remarks>
	/// When <see cref="M:Quartz.IScheduler.ResumeAll" /> is called (to un-pause), trigger misfire
	/// instructions WILL be applied.
	/// </remarks>
	/// <seealso cref="M:Quartz.IScheduler.ResumeAll" />
	/// <seealso cref="M:Quartz.IScheduler.PauseTriggers(Quartz.Impl.Matchers.GroupMatcher{Quartz.TriggerKey})" />
	/// <seealso cref="M:Quartz.IScheduler.Standby" />
	void PauseAll();

	/// <summary> 
	/// Resume (un-pause) all triggers - similar to calling 
	/// <see cref="M:Quartz.IScheduler.ResumeTriggers(Quartz.Impl.Matchers.GroupMatcher{Quartz.TriggerKey})" /> on every group.
	/// </summary>
	/// <remarks>
	/// If any <see cref="T:Quartz.ITrigger" /> missed one or more fire-times, then the
	/// <see cref="T:Quartz.ITrigger" />'s misfire instruction will be applied.
	/// </remarks>
	/// <seealso cref="M:Quartz.IScheduler.PauseAll" />
	void ResumeAll();

	/// <summary>
	/// Get the keys of all the <see cref="T:Quartz.IJobDetail" />s in the matching groups.
	/// </summary>
	Quartz.Collection.ISet<JobKey> GetJobKeys(GroupMatcher<JobKey> matcher);

	/// <summary>
	/// Get all <see cref="T:Quartz.ITrigger" /> s that are associated with the
	/// identified <see cref="T:Quartz.IJobDetail" />.
	/// </summary>
	/// <remarks>
	/// The returned Trigger objects will be snap-shots of the actual stored
	/// triggers.  If you wish to modify a trigger, you must re-store the
	/// trigger afterward (e.g. see <see cref="M:Quartz.IScheduler.RescheduleJob(Quartz.TriggerKey,Quartz.ITrigger)" />).
	/// </remarks>
	IList<ITrigger> GetTriggersOfJob(JobKey jobKey);

	/// <summary>
	/// Get the names of all the <see cref="T:Quartz.ITrigger" />s in the given
	/// groups.
	/// </summary>
	Quartz.Collection.ISet<TriggerKey> GetTriggerKeys(GroupMatcher<TriggerKey> matcher);

	/// <summary>
	/// Get the <see cref="T:Quartz.IJobDetail" /> for the <see cref="T:Quartz.IJob" />
	/// instance with the given key .
	/// </summary>
	/// <remarks>
	/// The returned JobDetail object will be a snap-shot of the actual stored
	/// JobDetail.  If you wish to modify the JobDetail, you must re-store the
	/// JobDetail afterward (e.g. see <see cref="M:Quartz.IScheduler.AddJob(Quartz.IJobDetail,System.Boolean)" />).
	/// </remarks>
	IJobDetail GetJobDetail(JobKey jobKey);

	/// <summary>
	/// Get the <see cref="T:Quartz.ITrigger" /> instance with the given key.
	/// </summary>
	/// <remarks>
	/// The returned Trigger object will be a snap-shot of the actual stored
	/// trigger.  If you wish to modify the trigger, you must re-store the
	/// trigger afterward (e.g. see <see cref="M:Quartz.IScheduler.RescheduleJob(Quartz.TriggerKey,Quartz.ITrigger)" />).
	/// </remarks>
	ITrigger GetTrigger(TriggerKey triggerKey);

	/// <summary>
	/// Get the current state of the identified <see cref="T:Quartz.ITrigger" />.
	/// </summary>
	/// <seealso cref="F:Quartz.TriggerState.Normal" />
	/// <seealso cref="F:Quartz.TriggerState.Paused" />
	/// <seealso cref="F:Quartz.TriggerState.Complete" />
	/// <seealso cref="F:Quartz.TriggerState.Blocked" />
	/// <seealso cref="F:Quartz.TriggerState.Error" />
	/// <seealso cref="F:Quartz.TriggerState.None" />
	TriggerState GetTriggerState(TriggerKey triggerKey);

	/// <summary>
	/// Add (register) the given <see cref="T:Quartz.ICalendar" /> to the Scheduler.
	/// </summary>
	/// <param name="calName">Name of the calendar.</param>
	/// <param name="calendar">The calendar.</param>
	/// <param name="replace">if set to <c>true</c> [replace].</param>
	/// <param name="updateTriggers">whether or not to update existing triggers that
	/// referenced the already existing calendar so that they are 'correct'
	/// based on the new trigger.</param>
	void AddCalendar(string calName, ICalendar calendar, bool replace, bool updateTriggers);

	/// <summary>
	/// Delete the identified <see cref="T:Quartz.ICalendar" /> from the Scheduler.
	/// </summary>
	/// <remarks>
	/// If removal of the <code>Calendar</code> would result in
	/// <see cref="T:Quartz.ITrigger" />s pointing to non-existent calendars, then a
	/// <see cref="T:Quartz.SchedulerException" /> will be thrown.
	/// </remarks>
	/// <param name="calName">Name of the calendar.</param>
	/// <returns>true if the Calendar was found and deleted.</returns>
	bool DeleteCalendar(string calName);

	/// <summary>
	/// Get the <see cref="T:Quartz.ICalendar" /> instance with the given name.
	/// </summary>
	ICalendar GetCalendar(string calName);

	/// <summary>
	/// Get the names of all registered <see cref="T:Quartz.ICalendar" />.
	/// </summary>
	IList<string> GetCalendarNames();

	/// <summary>
	/// Request the interruption, within this Scheduler instance, of all 
	/// currently executing instances of the identified <see cref="T:Quartz.IJob" />, which 
	/// must be an implementor of the <see cref="T:Quartz.IInterruptableJob" /> interface.
	/// </summary>
	/// <remarks>
	/// <para>
	/// If more than one instance of the identified job is currently executing,
	/// the <see cref="M:Quartz.IInterruptableJob.Interrupt" /> method will be called on
	/// each instance.  However, there is a limitation that in the case that  
	/// <see cref="M:Quartz.IScheduler.Interrupt(Quartz.JobKey)" /> on one instances throws an exception, all 
	/// remaining  instances (that have not yet been interrupted) will not have 
	/// their <see cref="M:Quartz.IScheduler.Interrupt(Quartz.JobKey)" /> method called.
	/// </para>
	///
	/// <para>
	/// If you wish to interrupt a specific instance of a job (when more than
	/// one is executing) you can do so by calling 
	/// <see cref="M:Quartz.IScheduler.GetCurrentlyExecutingJobs" /> to obtain a handle 
	/// to the job instance, and then invoke <see cref="M:Quartz.IScheduler.Interrupt(Quartz.JobKey)" /> on it
	/// yourself.
	/// </para>
	/// <para>
	/// This method is not cluster aware.  That is, it will only interrupt 
	/// instances of the identified InterruptableJob currently executing in this 
	/// Scheduler instance, not across the entire cluster.
	/// </para>
	/// </remarks>
	/// <returns> 
	/// true is at least one instance of the identified job was found and interrupted.
	/// </returns>
	/// <seealso cref="T:Quartz.IInterruptableJob" />
	/// <seealso cref="M:Quartz.IScheduler.GetCurrentlyExecutingJobs" />
	bool Interrupt(JobKey jobKey);

	/// <summary>
	/// Request the interruption, within this Scheduler instance, of the 
	/// identified executing job instance, which 
	/// must be an implementor of the <see cref="T:Quartz.IInterruptableJob" /> interface.
	/// </summary>
	/// <remarks>
	/// This method is not cluster aware.  That is, it will only interrupt 
	/// instances of the identified InterruptableJob currently executing in this 
	/// Scheduler instance, not across the entire cluster.
	/// </remarks>
	/// <seealso cref="M:Quartz.IInterruptableJob.Interrupt" />
	/// <seealso cref="M:Quartz.IScheduler.GetCurrentlyExecutingJobs" />
	/// <seealso cref="P:Quartz.IJobExecutionContext.FireInstanceId" />
	/// <seealso cref="M:Quartz.IScheduler.Interrupt(Quartz.JobKey)" />
	/// <param nane="fireInstanceId">
	/// the unique identifier of the job instance to  be interrupted (see <see cref="P:Quartz.IJobExecutionContext.FireInstanceId" />
	/// </param>
	/// <param name="fireInstanceId"> </param>
	/// <returns>true if the identified job instance was found and interrupted.</returns>
	bool Interrupt(string fireInstanceId);

	/// <summary>
	/// Determine whether a <see cref="T:Quartz.IJob" /> with the given identifier already 
	/// exists within the scheduler.
	/// </summary>
	/// <param name="jobKey">the identifier to check for</param>
	/// <returns>true if a Job exists with the given identifier</returns>
	bool CheckExists(JobKey jobKey);

	/// <summary>
	/// Determine whether a <see cref="T:Quartz.ITrigger" /> with the given identifier already 
	/// exists within the scheduler.
	/// </summary>
	/// <param name="triggerKey">the identifier to check for</param>
	/// <returns>true if a Trigger exists with the given identifier</returns>
	bool CheckExists(TriggerKey triggerKey);

	/// <summary>
	/// Clears (deletes!) all scheduling data - all <see cref="T:Quartz.IJob" />s, <see cref="T:Quartz.ITrigger" />s
	/// <see cref="T:Quartz.ICalendar" />s.
	/// </summary>
	void Clear();
}
