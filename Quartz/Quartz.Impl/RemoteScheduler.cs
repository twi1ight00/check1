using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Remoting;
using Quartz.Collection;
using Quartz.Impl.Matchers;
using Quartz.Simpl;
using Quartz.Spi;

namespace Quartz.Impl;

/// <summary>
/// An implementation of the <see cref="T:Quartz.IScheduler" /> interface that remotely
/// proxies all method calls to the equivalent call on a given <see cref="T:Quartz.Core.QuartzScheduler" />
/// instance, via remoting or similar technology.
/// </summary>
/// <seealso cref="T:Quartz.IScheduler" />
/// <seealso cref="T:Quartz.Core.QuartzScheduler" />
/// <author>James House</author>
/// <author>Marko Lahma (.NET)</author>
public class RemoteScheduler : IScheduler
{
	private IRemotableQuartzScheduler rsched;

	private readonly string schedId;

	private readonly IRemotableSchedulerProxyFactory proxyFactory;

	/// <summary>
	/// Returns the name of the <see cref="T:Quartz.IScheduler" />.
	/// </summary>
	public virtual string SchedulerName => CallInGuard((IRemotableQuartzScheduler x) => x.SchedulerName);

	/// <summary>
	/// Returns the instance Id of the <see cref="T:Quartz.IScheduler" />.
	/// </summary>
	public virtual string SchedulerInstanceId => CallInGuard((IRemotableQuartzScheduler x) => x.SchedulerInstanceId);

	/// <summary> 
	/// Returns the <see cref="T:Quartz.SchedulerContext" /> of the <see cref="T:Quartz.IScheduler" />.
	/// </summary>
	public virtual SchedulerContext Context => CallInGuard((IRemotableQuartzScheduler x) => x.SchedulerContext);

	/// <summary>
	/// Calls the equivalent method on the 'proxied' <see cref="T:Quartz.Core.QuartzScheduler" />.
	/// </summary>
	public virtual bool InStandbyMode => CallInGuard((IRemotableQuartzScheduler x) => x.InStandbyMode);

	/// <summary>
	/// Calls the equivalent method on the 'proxied' <see cref="T:Quartz.Core.QuartzScheduler" />.
	/// </summary>
	public virtual bool IsShutdown => CallInGuard((IRemotableQuartzScheduler x) => x.IsShutdown);

	/// <summary>
	/// Set the <see cref="P:Quartz.Impl.RemoteScheduler.JobFactory" /> that will be responsible for producing
	/// instances of <see cref="T:Quartz.IJob" /> classes.
	/// <para>
	/// JobFactories may be of use to those wishing to have their application
	/// produce <see cref="T:Quartz.IJob" /> instances via some special mechanism, such as to
	/// give the opertunity for dependency injection.
	/// </para>
	/// </summary>
	/// <value></value>
	/// <seealso cref="T:Quartz.Spi.IJobFactory" />
	/// <throws>  SchedulerException </throws>
	public virtual IJobFactory JobFactory
	{
		set
		{
			throw new SchedulerException("Operation not supported for remote schedulers.");
		}
	}

	/// <summary>
	/// Whether the scheduler has been started.
	/// </summary>
	/// <value></value>
	/// <remarks>
	/// Note: This only reflects whether <see cref="M:Quartz.Impl.RemoteScheduler.Start" /> has ever
	/// been called on this Scheduler, so it will return <see langword="true" /> even
	/// if the <see cref="T:Quartz.IScheduler" /> is currently in standby mode or has been
	/// since shutdown.
	/// </remarks>
	/// <seealso cref="M:Quartz.Impl.RemoteScheduler.Start" />
	/// <seealso cref="P:Quartz.Impl.RemoteScheduler.IsShutdown" />
	/// <seealso cref="P:Quartz.Impl.RemoteScheduler.InStandbyMode" />
	public virtual bool IsStarted => CallInGuard((IRemotableQuartzScheduler x) => x.RunningSince.HasValue);

	public IListenerManager ListenerManager
	{
		get
		{
			throw new SchedulerException("Operation not supported for remote schedulers.");
		}
	}

	/// <summary>
	/// Construct a <see cref="T:Quartz.Impl.RemoteScheduler" /> instance to proxy the given
	/// RemoteableQuartzScheduler instance.
	/// </summary>
	public RemoteScheduler(string schedId, IRemotableSchedulerProxyFactory proxyFactory)
	{
		this.schedId = schedId;
		this.proxyFactory = proxyFactory;
	}

	/// <summary>
	/// returns true if the given JobGroup
	/// is paused
	/// </summary>
	/// <param name="groupName"></param>
	/// <returns></returns>
	public virtual bool IsJobGroupPaused(string groupName)
	{
		return CallInGuard((IRemotableQuartzScheduler x) => x.IsJobGroupPaused(groupName));
	}

	/// <summary>
	/// returns true if the given TriggerGroup
	/// is paused
	/// </summary>
	/// <param name="groupName"></param>
	/// <returns></returns>
	public virtual bool IsTriggerGroupPaused(string groupName)
	{
		return CallInGuard((IRemotableQuartzScheduler x) => x.IsTriggerGroupPaused(groupName));
	}

	/// <summary>
	/// Get a <see cref="T:Quartz.SchedulerMetaData" /> object describiing the settings
	/// and capabilities of the scheduler instance.
	/// <para>
	/// Note that the data returned is an 'instantaneous' snap-shot, and that as
	/// soon as it's returned, the meta data values may be different.
	/// </para>
	/// </summary>
	/// <returns></returns>
	public virtual SchedulerMetaData GetMetaData()
	{
		return CallInGuard((IRemotableQuartzScheduler x) => new SchedulerMetaData(SchedulerName, SchedulerInstanceId, GetType(), isRemote: true, IsStarted, InStandbyMode, IsShutdown, x.RunningSince, x.NumJobsExecuted, x.JobStoreClass, x.SupportsPersistence, x.Clustered, x.ThreadPoolClass, x.ThreadPoolSize, x.Version));
	}

	/// <summary>
	/// Calls the equivalent method on the 'proxied' <see cref="T:Quartz.Core.QuartzScheduler" />.
	/// </summary>
	public virtual IList<IJobExecutionContext> GetCurrentlyExecutingJobs()
	{
		return CallInGuard((IRemotableQuartzScheduler x) => x.CurrentlyExecutingJobs);
	}

	/// <summary>
	/// Calls the equivalent method on the 'proxied' <see cref="T:Quartz.Core.QuartzScheduler" />.
	/// </summary>
	public virtual IList<string> GetJobGroupNames()
	{
		return CallInGuard((IRemotableQuartzScheduler x) => x.GetJobGroupNames());
	}

	/// <summary>
	/// Calls the equivalent method on the 'proxied' <see cref="T:Quartz.Core.QuartzScheduler" />.
	/// </summary>
	public virtual IList<string> GetTriggerGroupNames()
	{
		return CallInGuard((IRemotableQuartzScheduler x) => x.GetTriggerGroupNames());
	}

	/// <summary>
	/// Get the names of all <see cref="T:Quartz.ITrigger" /> groups that are paused.
	/// </summary>
	/// <value></value>
	public virtual Quartz.Collection.ISet<string> GetPausedTriggerGroups()
	{
		return CallInGuard((IRemotableQuartzScheduler x) => x.GetPausedTriggerGroups());
	}

	/// <summary> 
	/// Calls the equivalent method on the 'proxied' <see cref="T:Quartz.Core.QuartzScheduler" />.
	/// </summary>
	public virtual void Start()
	{
		CallInGuard(delegate(IRemotableQuartzScheduler x)
		{
			x.Start();
		});
	}

	/// <summary> 
	/// Calls the equivalent method on the 'proxied' <see cref="T:Quartz.Core.QuartzScheduler" />.
	/// </summary>
	public void StartDelayed(TimeSpan delay)
	{
		CallInGuard(delegate(IRemotableQuartzScheduler x)
		{
			x.StartDelayed(delay);
		});
	}

	/// <summary>
	/// Calls the equivalent method on the 'proxied' <see cref="T:Quartz.Core.QuartzScheduler" />.
	/// </summary>
	public virtual void Standby()
	{
		CallInGuard(delegate(IRemotableQuartzScheduler x)
		{
			x.Standby();
		});
	}

	/// <summary>
	/// Calls the equivalent method on the 'proxied' <see cref="T:Quartz.Core.QuartzScheduler" />.
	/// </summary>
	public virtual void Shutdown()
	{
		try
		{
			string schedulerName = SchedulerName;
			GetRemoteScheduler().Shutdown();
			SchedulerRepository.Instance.Remove(schedulerName);
		}
		catch (RemotingException re)
		{
			throw InvalidateHandleCreateException("Error communicating with remote scheduler.", re);
		}
	}

	/// <summary>
	/// Calls the equivalent method on the 'proxied' <see cref="T:Quartz.Core.QuartzScheduler" />.
	/// </summary>
	public virtual void Shutdown(bool waitForJobsToComplete)
	{
		CallInGuard(delegate(IRemotableQuartzScheduler x)
		{
			x.Shutdown(waitForJobsToComplete);
		});
	}

	/// <summary>
	/// Calls the equivalent method on the 'proxied' <see cref="T:Quartz.Core.QuartzScheduler" />.
	/// </summary>
	public virtual DateTimeOffset ScheduleJob(IJobDetail jobDetail, ITrigger trigger)
	{
		return CallInGuard((IRemotableQuartzScheduler x) => x.ScheduleJob(jobDetail, trigger));
	}

	/// <summary>
	/// Calls the equivalent method on the 'proxied' <see cref="T:Quartz.Core.QuartzScheduler" />.
	/// </summary>
	public virtual DateTimeOffset ScheduleJob(ITrigger trigger)
	{
		return CallInGuard((IRemotableQuartzScheduler x) => x.ScheduleJob(trigger));
	}

	/// <summary>
	/// Calls the equivalent method on the 'proxied' <see cref="T:Quartz.Core.QuartzScheduler" />.
	/// </summary>
	public virtual void AddJob(IJobDetail jobDetail, bool replace)
	{
		CallInGuard(delegate(IRemotableQuartzScheduler x)
		{
			x.AddJob(jobDetail, replace);
		});
	}

	public virtual bool DeleteJobs(IList<JobKey> jobKeys)
	{
		return CallInGuard((IRemotableQuartzScheduler x) => x.DeleteJobs(jobKeys));
	}

	public virtual void ScheduleJobs(IDictionary<IJobDetail, Quartz.Collection.ISet<ITrigger>> triggersAndJobs, bool replace)
	{
		CallInGuard(delegate(IRemotableQuartzScheduler x)
		{
			x.ScheduleJobs(triggersAndJobs, replace);
		});
	}

	public void ScheduleJob(IJobDetail jobDetail, Quartz.Collection.ISet<ITrigger> triggersForJob, bool replace)
	{
		CallInGuard(delegate(IRemotableQuartzScheduler x)
		{
			x.ScheduleJob(jobDetail, triggersForJob, replace);
		});
	}

	public virtual bool UnscheduleJobs(IList<TriggerKey> triggerKeys)
	{
		return CallInGuard((IRemotableQuartzScheduler x) => x.UnscheduleJobs(triggerKeys));
	}

	/// <summary>
	/// Calls the equivalent method on the 'proxied' <see cref="T:Quartz.Core.QuartzScheduler" />.
	/// </summary>
	public virtual bool DeleteJob(JobKey jobKey)
	{
		return CallInGuard((IRemotableQuartzScheduler x) => x.DeleteJob(jobKey));
	}

	/// <summary>
	/// Calls the equivalent method on the 'proxied' <see cref="T:Quartz.Core.QuartzScheduler" />.
	/// </summary>
	public virtual bool UnscheduleJob(TriggerKey triggerKey)
	{
		return CallInGuard((IRemotableQuartzScheduler x) => x.UnscheduleJob(triggerKey));
	}

	/// <summary>
	/// Calls the equivalent method on the 'proxied' <see cref="T:Quartz.Core.QuartzScheduler" />.
	/// </summary>
	public virtual DateTimeOffset? RescheduleJob(TriggerKey triggerKey, ITrigger newTrigger)
	{
		return CallInGuard((IRemotableQuartzScheduler x) => x.RescheduleJob(triggerKey, newTrigger));
	}

	/// <summary>
	/// Calls the equivalent method on the 'proxied' <see cref="T:Quartz.Core.QuartzScheduler" />.
	/// </summary>
	public virtual void TriggerJob(JobKey jobKey)
	{
		TriggerJob(jobKey, null);
	}

	/// <summary>
	/// Calls the equivalent method on the 'proxied' <see cref="T:Quartz.Core.QuartzScheduler" />.
	/// </summary>
	public virtual void TriggerJob(JobKey jobKey, JobDataMap data)
	{
		CallInGuard(delegate(IRemotableQuartzScheduler x)
		{
			x.TriggerJob(jobKey, data);
		});
	}

	/// <summary>
	/// Calls the equivalent method on the 'proxied' <see cref="T:Quartz.Core.QuartzScheduler" />.
	/// </summary>
	public virtual void PauseTrigger(TriggerKey triggerKey)
	{
		CallInGuard(delegate(IRemotableQuartzScheduler x)
		{
			x.PauseTrigger(triggerKey);
		});
	}

	/// <summary>
	/// Calls the equivalent method on the 'proxied' <see cref="T:Quartz.Core.QuartzScheduler" />.
	/// </summary>
	public virtual void PauseTriggers(GroupMatcher<TriggerKey> matcher)
	{
		CallInGuard(delegate(IRemotableQuartzScheduler x)
		{
			x.PauseTriggers(matcher);
		});
	}

	/// <summary>
	/// Calls the equivalent method on the 'proxied' <see cref="T:Quartz.Core.QuartzScheduler" />.
	/// </summary>
	public virtual void PauseJob(JobKey jobKey)
	{
		CallInGuard(delegate(IRemotableQuartzScheduler x)
		{
			x.PauseJob(jobKey);
		});
	}

	/// <summary>
	/// Calls the equivalent method on the 'proxied' <see cref="T:Quartz.Core.QuartzScheduler" />.
	/// </summary>
	public virtual void PauseJobs(GroupMatcher<JobKey> matcher)
	{
		CallInGuard(delegate(IRemotableQuartzScheduler x)
		{
			x.PauseJobs(matcher);
		});
	}

	/// <summary>
	/// Calls the equivalent method on the 'proxied' <see cref="T:Quartz.Core.QuartzScheduler" />.
	/// </summary>
	public virtual void ResumeTrigger(TriggerKey triggerKey)
	{
		CallInGuard(delegate(IRemotableQuartzScheduler x)
		{
			x.ResumeTrigger(triggerKey);
		});
	}

	/// <summary>
	/// Calls the equivalent method on the 'proxied' <see cref="T:Quartz.Core.QuartzScheduler" />.
	/// </summary>
	public virtual void ResumeTriggers(GroupMatcher<TriggerKey> matcher)
	{
		CallInGuard(delegate(IRemotableQuartzScheduler x)
		{
			x.ResumeTriggers(matcher);
		});
	}

	/// <summary>
	/// Calls the equivalent method on the 'proxied' <see cref="T:Quartz.Core.QuartzScheduler" />.
	/// </summary>
	public virtual void ResumeJob(JobKey jobKey)
	{
		CallInGuard(delegate(IRemotableQuartzScheduler x)
		{
			x.ResumeJob(jobKey);
		});
	}

	/// <summary>
	/// Calls the equivalent method on the 'proxied' <see cref="T:Quartz.Core.QuartzScheduler" />.
	/// </summary>
	public virtual void ResumeJobs(GroupMatcher<JobKey> matcher)
	{
		CallInGuard(delegate(IRemotableQuartzScheduler x)
		{
			x.ResumeJobs(matcher);
		});
	}

	/// <summary>
	/// Calls the equivalent method on the 'proxied' <see cref="T:Quartz.Core.QuartzScheduler" />.
	/// </summary>
	public virtual void PauseAll()
	{
		CallInGuard(delegate(IRemotableQuartzScheduler x)
		{
			x.PauseAll();
		});
	}

	/// <summary>
	/// Calls the equivalent method on the 'proxied' <see cref="T:Quartz.Core.QuartzScheduler" />.
	/// </summary>
	public virtual void ResumeAll()
	{
		CallInGuard(delegate(IRemotableQuartzScheduler x)
		{
			x.ResumeAll();
		});
	}

	/// <summary>
	/// Calls the equivalent method on the 'proxied' <see cref="T:Quartz.Core.QuartzScheduler" />.
	/// </summary>
	public virtual Quartz.Collection.ISet<JobKey> GetJobKeys(GroupMatcher<JobKey> matcher)
	{
		return CallInGuard((IRemotableQuartzScheduler x) => x.GetJobKeys(matcher));
	}

	/// <summary>
	/// Calls the equivalent method on the 'proxied' <see cref="T:Quartz.Core.QuartzScheduler" />.
	/// </summary>
	public virtual IList<ITrigger> GetTriggersOfJob(JobKey jobKey)
	{
		return CallInGuard((IRemotableQuartzScheduler x) => x.GetTriggersOfJob(jobKey));
	}

	/// <summary>
	/// Calls the equivalent method on the 'proxied' <see cref="T:Quartz.Core.QuartzScheduler" />.
	/// </summary>
	public virtual Quartz.Collection.ISet<TriggerKey> GetTriggerKeys(GroupMatcher<TriggerKey> matcher)
	{
		return CallInGuard((IRemotableQuartzScheduler x) => x.GetTriggerKeys(matcher));
	}

	/// <summary>
	/// Calls the equivalent method on the 'proxied' <see cref="T:Quartz.Core.QuartzScheduler" />.
	/// </summary>
	public virtual IJobDetail GetJobDetail(JobKey jobKey)
	{
		return CallInGuard((IRemotableQuartzScheduler x) => x.GetJobDetail(jobKey));
	}

	/// <summary>
	/// Calls the equivalent method on the 'proxied' <see cref="T:Quartz.Core.QuartzScheduler" />.
	/// </summary>
	public virtual bool CheckExists(JobKey jobKey)
	{
		return CallInGuard((IRemotableQuartzScheduler x) => x.CheckExists(jobKey));
	}

	/// <summary>
	/// Calls the equivalent method on the 'proxied' <see cref="T:Quartz.Core.QuartzScheduler" />.
	/// </summary>
	public virtual bool CheckExists(TriggerKey triggerKey)
	{
		return CallInGuard((IRemotableQuartzScheduler x) => x.CheckExists(triggerKey));
	}

	/// <summary>
	/// Calls the equivalent method on the 'proxied' <see cref="T:Quartz.Core.QuartzScheduler" />.
	/// </summary>
	public virtual void Clear()
	{
		CallInGuard(delegate(IRemotableQuartzScheduler x)
		{
			x.Clear();
		});
	}

	/// <summary>
	/// Calls the equivalent method on the 'proxied' <see cref="T:Quartz.Core.QuartzScheduler" />.
	/// </summary>
	public virtual ITrigger GetTrigger(TriggerKey triggerKey)
	{
		return CallInGuard((IRemotableQuartzScheduler x) => x.GetTrigger(triggerKey));
	}

	/// <summary>
	/// Calls the equivalent method on the 'proxied' <see cref="T:Quartz.Core.QuartzScheduler" />.
	/// </summary>
	public virtual TriggerState GetTriggerState(TriggerKey triggerKey)
	{
		return CallInGuard((IRemotableQuartzScheduler x) => x.GetTriggerState(triggerKey));
	}

	/// <summary>
	/// Calls the equivalent method on the 'proxied' <see cref="T:Quartz.Core.QuartzScheduler" />.
	/// </summary>
	public virtual void AddCalendar(string calName, ICalendar calendar, bool replace, bool updateTriggers)
	{
		CallInGuard(delegate(IRemotableQuartzScheduler x)
		{
			x.AddCalendar(calName, calendar, replace, updateTriggers);
		});
	}

	/// <summary>
	/// Calls the equivalent method on the 'proxied' <see cref="T:Quartz.Core.QuartzScheduler" />.
	/// </summary>
	public virtual bool DeleteCalendar(string calName)
	{
		return CallInGuard((IRemotableQuartzScheduler x) => x.DeleteCalendar(calName));
	}

	/// <summary>
	/// Calls the equivalent method on the 'proxied' <see cref="T:Quartz.Core.QuartzScheduler" />.
	/// </summary>
	public virtual ICalendar GetCalendar(string calName)
	{
		return CallInGuard((IRemotableQuartzScheduler x) => x.GetCalendar(calName));
	}

	/// <summary>
	/// Get the names of all registered <see cref="T:Quartz.ICalendar" />.
	/// </summary>
	/// <returns></returns>
	public IList<string> GetCalendarNames()
	{
		return CallInGuard((IRemotableQuartzScheduler x) => x.GetCalendarNames());
	}

	/// <summary>
	/// Calls the equivalent method on the 'proxied' <see cref="T:Quartz.Core.QuartzScheduler" />.
	/// </summary>
	public virtual bool Interrupt(JobKey jobKey)
	{
		try
		{
			return GetRemoteScheduler().Interrupt(jobKey);
		}
		catch (RemotingException re)
		{
			throw new UnableToInterruptJobException(InvalidateHandleCreateException("Error communicating with remote scheduler.", re));
		}
		catch (SchedulerException se)
		{
			throw new UnableToInterruptJobException(se);
		}
	}

	public bool Interrupt(string fireInstanceId)
	{
		try
		{
			return GetRemoteScheduler().Interrupt(fireInstanceId);
		}
		catch (RemotingException re)
		{
			throw new UnableToInterruptJobException(InvalidateHandleCreateException("Error communicating with remote scheduler.", re));
		}
		catch (SchedulerException se)
		{
			throw new UnableToInterruptJobException(se);
		}
	}

	protected virtual void CallInGuard(Action<IRemotableQuartzScheduler> action)
	{
		try
		{
			action(GetRemoteScheduler());
		}
		catch (RemotingException re)
		{
			throw InvalidateHandleCreateException("Error communicating with remote scheduler.", re);
		}
	}

	protected virtual T CallInGuard<T>(Func<IRemotableQuartzScheduler, T> func)
	{
		try
		{
			return func(GetRemoteScheduler());
		}
		catch (RemotingException re)
		{
			throw InvalidateHandleCreateException("Error communicating with remote scheduler.", re);
		}
	}

	protected virtual IRemotableQuartzScheduler GetRemoteScheduler()
	{
		if (rsched != null)
		{
			return rsched;
		}
		try
		{
			rsched = proxyFactory.GetProxy();
		}
		catch (Exception e)
		{
			string errorMessage = string.Format(CultureInfo.InvariantCulture, "Could not get handle to remote scheduler: {0}", new object[1] { e.Message });
			SchedulerException initException = new SchedulerException(errorMessage, e);
			throw initException;
		}
		return rsched;
	}

	protected virtual SchedulerException InvalidateHandleCreateException(string msg, Exception cause)
	{
		rsched = null;
		return new SchedulerException(msg, cause);
	}
}
