using System.Collections.Generic;

namespace Quartz;

/// <summary>
/// Client programs may be interested in the 'listener' interfaces that are
/// available from Quartz. The <see cref="T:Quartz.IJobListener" /> interface
/// provides notifications of Job executions. The
/// <see cref="T:Quartz.ITriggerListener" /> interface provides notifications of
/// <see cref="T:Quartz.ITrigger" /> firings. The <see cref="T:Quartz.ISchedulerListener" />
/// interface provides notifications of scheduler events and
/// errors.  Listeners can be associated with local schedulers through the
/// <see cref="T:Quartz.IListenerManager" /> interface.
/// </summary>
/// <remarks>
/// </remarks>
/// <author>jhouse</author>
/// <since>2.0 - previously listeners were managed directly on the Scheduler interface.</since>
public interface IListenerManager
{
	/// <summary>
	/// Add the given <see cref="T:Quartz.IJobListener" /> to the<see cref="T:Quartz.IScheduler" />,
	/// and register it to receive events for Jobs that are matched by ANY of the
	/// given Matchers.
	/// </summary>
	/// <remarks>
	/// If no matchers are provided, the <see cref="T:Quartz.Impl.Matchers.EverythingMatcher`1" /> will be used.
	/// </remarks>
	/// <seealso cref="T:Quartz.IMatcher`1" />
	/// <seealso cref="T:Quartz.Impl.Matchers.EverythingMatcher`1" />
	void AddJobListener(IJobListener jobListener, params IMatcher<JobKey>[] matchers);

	/// <summary>
	/// Add the given <see cref="T:Quartz.IJobListener" /> to the<see cref="T:Quartz.IScheduler" />,
	/// and register it to receive events for Jobs that are matched by ANY of the
	/// given Matchers.
	/// </summary>
	/// <remarks>
	/// If no matchers are provided, the <see cref="T:Quartz.Impl.Matchers.EverythingMatcher`1" /> will be used.
	/// </remarks>
	/// <seealso cref="T:Quartz.IMatcher`1" />
	/// <seealso cref="T:Quartz.Impl.Matchers.EverythingMatcher`1" />
	void AddJobListener(IJobListener jobListener, IList<IMatcher<JobKey>> matchers);

	/// <summary>
	/// Add the given Matcher to the set of matchers for which the listener
	/// will receive events if ANY of the matchers match.
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <param name="listenerName">the name of the listener to add the matcher to</param>
	/// <param name="matcher">the additional matcher to apply for selecting events</param>
	/// <returns>true if the identified listener was found and updated</returns>
	bool AddJobListenerMatcher(string listenerName, IMatcher<JobKey> matcher);

	/// <summary>
	/// Remove the given Matcher to the set of matchers for which the listener
	/// will receive events if ANY of the matchers match.
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <param name="listenerName">the name of the listener to add the matcher to</param>
	/// <param name="matcher">the additional matcher to apply for selecting events</param>
	/// <returns>true if the given matcher was found and removed from the listener's list of matchers</returns>
	bool RemoveJobListenerMatcher(string listenerName, IMatcher<JobKey> matcher);

	/// <summary>
	/// Set the set of Matchers for which the listener
	/// will receive events if ANY of the matchers match.
	/// </summary>
	/// <remarks>
	/// <para>Removes any existing matchers for the identified listener!</para>
	/// </remarks>
	/// <param name="listenerName">the name of the listener to add the matcher to</param>
	/// <param name="matchers">the matchers to apply for selecting events</param>
	/// <returns>true if the given matcher was found and removed from the listener's list of matchers</returns>
	bool SetJobListenerMatchers(string listenerName, IList<IMatcher<JobKey>> matchers);

	/// <summary>
	/// Get the set of Matchers for which the listener
	/// will receive events if ANY of the matchers match.
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <param name="listenerName">the name of the listener to add the matcher to</param>
	/// <returns>the matchers registered for selecting events for the identified listener</returns>
	IList<IMatcher<JobKey>> GetJobListenerMatchers(string listenerName);

	/// <summary>
	/// Remove the identified <see cref="T:Quartz.IJobListener" /> from the<see cref="T:Quartz.IScheduler" />.
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <returns>true if the identified listener was found in the list, and removed.</returns>
	bool RemoveJobListener(string name);

	/// <summary>
	/// Get a List containing all of the <see cref="T:Quartz.IJobListener" />s in
	/// the<see cref="T:Quartz.IScheduler" />.
	/// </summary>
	IList<IJobListener> GetJobListeners();

	/// <summary>
	/// Get the <see cref="T:Quartz.IJobListener" /> that has the given name.
	/// </summary>
	IJobListener GetJobListener(string name);

	/// <summary>
	/// Add the given <see cref="T:Quartz.ITriggerListener" /> to the<see cref="T:Quartz.IScheduler" />,
	/// and register it to receive events for Triggers that are matched by ANY of the
	/// given Matchers.
	/// </summary>
	/// <remarks>
	/// If no matcher is provided, the <see cref="T:Quartz.Impl.Matchers.EverythingMatcher`1" /> will be used.
	/// </remarks>
	/// <seealso cref="T:Quartz.IMatcher`1" />
	/// <seealso cref="T:Quartz.Impl.Matchers.EverythingMatcher`1" />
	void AddTriggerListener(ITriggerListener triggerListener, params IMatcher<TriggerKey>[] matchers);

	/// <summary>
	/// Add the given <see cref="T:Quartz.ITriggerListener" /> to the<see cref="T:Quartz.IScheduler" />,
	/// and register it to receive events for Triggers that are matched by ANY of the
	/// given Matchers.
	/// </summary>
	/// <remarks>
	/// If no matcher is provided, the <see cref="T:Quartz.Impl.Matchers.EverythingMatcher`1" /> will be used.
	/// </remarks>
	/// <seealso cref="T:Quartz.IMatcher`1" />
	/// <seealso cref="T:Quartz.Impl.Matchers.EverythingMatcher`1" />
	void AddTriggerListener(ITriggerListener triggerListener, IList<IMatcher<TriggerKey>> matchers);

	/// <summary>
	/// Add the given Matcher to the set of matchers for which the listener
	/// will receive events if ANY of the matchers match.
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <param name="listenerName">the name of the listener to add the matcher to</param>
	/// <param name="matcher">the additional matcher to apply for selecting events</param>
	/// <returns>true if the identified listener was found and updated</returns>
	bool AddTriggerListenerMatcher(string listenerName, IMatcher<TriggerKey> matcher);

	/// <summary>
	/// Remove the given Matcher to the set of matchers for which the listener
	/// will receive events if ANY of the matchers match.
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <param name="listenerName">the name of the listener to add the matcher to</param>
	/// <param name="matcher">the additional matcher to apply for selecting events</param>
	/// <returns>true if the given matcher was found and removed from the listener's list of matchers</returns>
	bool RemoveTriggerListenerMatcher(string listenerName, IMatcher<TriggerKey> matcher);

	/// <summary>
	/// Set the set of Matchers for which the listener
	/// will receive events if ANY of the matchers match.
	/// </summary>
	/// <remarks>
	/// <para>Removes any existing matchers for the identified listener!</para>
	/// </remarks>
	/// <param name="listenerName">the name of the listener to add the matcher to</param>
	/// <param name="matchers">the matchers to apply for selecting events</param>
	/// <returns>true if the given matcher was found and removed from the listener's list of matchers</returns>
	bool SetTriggerListenerMatchers(string listenerName, IList<IMatcher<TriggerKey>> matchers);

	/// <summary>
	/// Get the set of Matchers for which the listener
	/// will receive events if ANY of the matchers match.
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <param name="listenerName">the name of the listener to add the matcher to</param>
	/// <returns>the matchers registered for selecting events for the identified listener</returns>
	IList<IMatcher<TriggerKey>> GetTriggerListenerMatchers(string listenerName);

	/// <summary>
	/// Remove the identified <see cref="T:Quartz.ITriggerListener" /> from the<see cref="T:Quartz.IScheduler" />.
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <returns>true if the identified listener was found in the list, and</returns>
	/// removed.
	bool RemoveTriggerListener(string name);

	/// <summary>
	/// Get a List containing all of the <see cref="T:Quartz.ITriggerListener" />s
	/// in the<see cref="T:Quartz.IScheduler" />.
	/// </summary>
	IList<ITriggerListener> GetTriggerListeners();

	/// <summary>
	/// Get the <see cref="T:Quartz.ITriggerListener" /> that has the given name.
	/// </summary>
	ITriggerListener GetTriggerListener(string name);

	/// <summary>
	/// Register the given <see cref="T:Quartz.ISchedulerListener" /> with the
	///             <see cref="T:Quartz.IScheduler" />.
	/// </summary>
	void AddSchedulerListener(ISchedulerListener schedulerListener);

	/// <summary>
	/// Remove the given <see cref="T:Quartz.ISchedulerListener" /> from the
	///             <see cref="T:Quartz.IScheduler" />.
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <returns>true if the identified listener was found in the list, and removed.</returns>
	bool RemoveSchedulerListener(ISchedulerListener schedulerListener);

	/// <summary>
	/// Get a List containing all of the <see cref="T:Quartz.ISchedulerListener" />s
	/// registered with the<see cref="T:Quartz.IScheduler" />.
	/// </summary>
	IList<ISchedulerListener> GetSchedulerListeners();
}
