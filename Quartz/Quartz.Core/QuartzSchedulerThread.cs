using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Globalization;
using System.Threading;
using Common.Logging;
using Quartz.Spi;

namespace Quartz.Core;

/// <summary>
/// The thread responsible for performing the work of firing <see cref="T:Quartz.ITrigger" />
/// s that are registered with the <see cref="T:Quartz.Core.QuartzScheduler" />.
/// </summary>
/// <seealso cref="T:Quartz.Core.QuartzScheduler" />
/// <seealso cref="T:Quartz.IJob" />
/// <seealso cref="T:Quartz.ITrigger" />
/// <author>James House</author>
/// <author>Marko Lahma (.NET)</author>
public class QuartzSchedulerThread : QuartzThread
{
	private readonly ILog log;

	private QuartzScheduler qs;

	private QuartzSchedulerResources qsRsrcs;

	private readonly object sigLock = new object();

	private bool signaled;

	private DateTimeOffset? signaledNextFireTimeUtc;

	private bool paused;

	private bool halted;

	private readonly Random random = new Random((int)DateTimeOffset.Now.Ticks);

	private static readonly TimeSpan DefaultIdleWaitTime = TimeSpan.FromSeconds(30.0);

	private TimeSpan idleWaitTime = DefaultIdleWaitTime;

	private int idleWaitVariablness = 7000;

	private TimeSpan dbFailureRetryInterval = TimeSpan.FromSeconds(15.0);

	/// <summary>
	/// Gets the log.
	/// </summary>
	/// <value>The log.</value>
	protected ILog Log => log;

	/// <summary>
	/// Sets the idle wait time.
	/// </summary>
	/// <value>The idle wait time.</value>
	[TimeSpanParseRule(TimeSpanParseRule.Milliseconds)]
	internal virtual TimeSpan IdleWaitTime
	{
		set
		{
			idleWaitTime = value;
			idleWaitVariablness = (int)(value.TotalMilliseconds * 0.2);
		}
	}

	/// <summary>
	/// Gets a value indicating whether this <see cref="T:Quartz.Core.QuartzSchedulerThread" /> is paused.
	/// </summary>
	/// <value><c>true</c> if paused; otherwise, <c>false</c>.</value>
	internal virtual bool Paused => paused;

	/// <summary>
	/// Gets or sets the db failure retry interval.
	/// </summary>
	/// <value>The db failure retry interval.</value>
	[TimeSpanParseRule(TimeSpanParseRule.Milliseconds)]
	public TimeSpan DbFailureRetryInterval
	{
		get
		{
			return dbFailureRetryInterval;
		}
		set
		{
			dbFailureRetryInterval = value;
		}
	}

	/// <summary>
	/// Gets the randomized idle wait time.
	/// </summary>
	/// <value>The randomized idle wait time.</value>
	private TimeSpan GetRandomizedIdleWaitTime()
	{
		return idleWaitTime.Add(TimeSpan.FromMilliseconds(random.Next(idleWaitVariablness)));
	}

	/// <summary>
	/// Construct a new <see cref="T:Quartz.Core.QuartzSchedulerThread" /> for the given
	/// <see cref="T:Quartz.Core.QuartzScheduler" /> as a non-daemon <see cref="T:System.Threading.Thread" />
	/// with normal priority.
	/// </summary>
	internal QuartzSchedulerThread(QuartzScheduler qs, QuartzSchedulerResources qsRsrcs)
		: this(qs, qsRsrcs, qsRsrcs.MakeSchedulerThreadDaemon, 2)
	{
	}

	/// <summary>
	/// Construct a new <see cref="T:Quartz.Core.QuartzSchedulerThread" /> for the given
	/// <see cref="T:Quartz.Core.QuartzScheduler" /> as a <see cref="T:System.Threading.Thread" /> with the given
	/// attributes.
	/// </summary>
	internal QuartzSchedulerThread(QuartzScheduler qs, QuartzSchedulerResources qsRsrcs, bool setDaemon, int threadPrio)
		: base(qsRsrcs.ThreadName)
	{
		log = LogManager.GetLogger(GetType());
		this.qs = qs;
		this.qsRsrcs = qsRsrcs;
		base.IsBackground = setDaemon;
		base.Priority = (ThreadPriority)threadPrio;
		paused = true;
		halted = false;
	}

	/// <summary>
	/// Signals the main processing loop to pause at the next possible point.
	/// </summary>
	internal virtual void TogglePause(bool pause)
	{
		lock (sigLock)
		{
			paused = pause;
			if (paused)
			{
				SignalSchedulingChange(null);
			}
			else
			{
				Monitor.PulseAll(sigLock);
			}
		}
	}

	/// <summary>
	/// Signals the main processing loop to pause at the next possible point.
	/// </summary>
	internal virtual void Halt()
	{
		lock (sigLock)
		{
			halted = true;
			if (paused)
			{
				Monitor.PulseAll(sigLock);
			}
			else
			{
				SignalSchedulingChange(null);
			}
		}
	}

	/// <summary>
	/// Signals the main processing loop that a change in scheduling has been
	/// made - in order to interrupt any sleeping that may be occuring while
	/// waiting for the fire time to arrive.
	/// </summary>
	/// <param name="candidateNewNextFireTimeUtc">
	/// the time when the newly scheduled trigger
	/// will fire.  If this method is being called do to some other even (rather
	/// than scheduling a trigger), the caller should pass null.
	/// </param>
	public void SignalSchedulingChange(DateTimeOffset? candidateNewNextFireTimeUtc)
	{
		lock (sigLock)
		{
			signaled = true;
			signaledNextFireTimeUtc = candidateNewNextFireTimeUtc;
			Monitor.PulseAll(sigLock);
		}
	}

	public void ClearSignaledSchedulingChange()
	{
		lock (sigLock)
		{
			signaled = false;
			signaledNextFireTimeUtc = null;
		}
	}

	public bool IsScheduleChanged()
	{
		lock (sigLock)
		{
			return signaled;
		}
	}

	public DateTimeOffset? GetSignaledNextFireTimeUtc()
	{
		lock (sigLock)
		{
			return signaledNextFireTimeUtc;
		}
	}

	/// <summary>
	/// The main processing loop of the <see cref="T:Quartz.Core.QuartzSchedulerThread" />.
	/// </summary>
	public override void Run()
	{
		bool lastAcquireFailed = false;
		while (!halted)
		{
			try
			{
				lock (sigLock)
				{
					while (paused && !halted)
					{
						try
						{
							Monitor.Wait(sigLock, 1000);
						}
						catch (ThreadInterruptedException)
						{
						}
					}
					if (halted)
					{
						break;
					}
				}
				int availThreadCount = qsRsrcs.ThreadPool.BlockForAvailableThreads();
				if (availThreadCount <= 0)
				{
					continue;
				}
				IList<IOperableTrigger> triggers = null;
				DateTimeOffset now = SystemTime.UtcNow();
				ClearSignaledSchedulingChange();
				try
				{
					triggers = qsRsrcs.JobStore.AcquireNextTriggers(now + idleWaitTime, Math.Min(availThreadCount, qsRsrcs.MaxBatchSize), qsRsrcs.BatchTimeWindow);
					lastAcquireFailed = false;
					if (log.IsDebugEnabled)
					{
						log.DebugFormat("Batch acquisition of {0} triggers", triggers?.Count ?? 0);
					}
				}
				catch (JobPersistenceException jpe)
				{
					if (!lastAcquireFailed)
					{
						qs.NotifySchedulerListenersError("An error occurred while scanning for the next trigger to fire.", jpe);
					}
					lastAcquireFailed = true;
				}
				catch (Exception e)
				{
					if (!lastAcquireFailed)
					{
						Log.Error("quartzSchedulerThreadLoop: RuntimeException " + e.Message, e);
					}
					lastAcquireFailed = true;
				}
				if (triggers != null && triggers.Count > 0)
				{
					now = SystemTime.UtcNow();
					DateTimeOffset triggerTime = triggers[0].GetNextFireTimeUtc().Value;
					TimeSpan timeUntilTrigger = triggerTime - now;
					while (timeUntilTrigger > TimeSpan.FromMilliseconds(2.0) && !ReleaseIfScheduleChangedSignificantly(triggers, triggerTime))
					{
						lock (sigLock)
						{
							if (halted)
							{
								break;
							}
							if (!IsCandidateNewTimeEarlierWithinReason(triggerTime, clearSignal: false))
							{
								try
								{
									now = SystemTime.UtcNow();
									timeUntilTrigger = triggerTime - now;
									if (timeUntilTrigger > TimeSpan.Zero)
									{
										Monitor.Wait(sigLock, timeUntilTrigger);
									}
								}
								catch (ThreadInterruptedException)
								{
								}
							}
							goto IL_024f;
						}
						IL_024f:
						if (ReleaseIfScheduleChangedSignificantly(triggers, triggerTime))
						{
							break;
						}
						now = SystemTime.UtcNow();
						timeUntilTrigger = triggerTime - now;
					}
					if (triggers.Count == 0)
					{
						continue;
					}
					IList<TriggerFiredResult> bndles = new List<TriggerFiredResult>();
					bool goAhead = true;
					lock (sigLock)
					{
						goAhead = !halted;
					}
					if (goAhead)
					{
						try
						{
							IList<TriggerFiredResult> res = qsRsrcs.JobStore.TriggersFired(triggers);
							if (res != null)
							{
								bndles = res;
							}
						}
						catch (SchedulerException se2)
						{
							qs.NotifySchedulerListenersError(string.Concat("An error occurred while firing triggers '", triggers, "'"), se2);
							foreach (IOperableTrigger t in triggers)
							{
								ReleaseTriggerRetryLoop(t);
							}
							continue;
						}
					}
					for (int i = 0; i < bndles.Count; i++)
					{
						TriggerFiredResult result = bndles[i];
						TriggerFiredBundle bndle = result.TriggerFiredBundle;
						Exception exception = result.Exception;
						IOperableTrigger trigger = triggers[i];
						if (exception != null && (exception is DbException || exception.InnerException is DbException))
						{
							Log.Error("DbException while firing trigger " + trigger, exception);
							ReleaseTriggerRetryLoop(trigger);
							continue;
						}
						if (bndle == null)
						{
							try
							{
								qsRsrcs.JobStore.ReleaseAcquiredTrigger(trigger);
							}
							catch (SchedulerException se)
							{
								qs.NotifySchedulerListenersError(string.Concat("An error occurred while releasing triggers '", trigger.Key, "'"), se);
								ReleaseTriggerRetryLoop(trigger);
							}
							continue;
						}
						JobRunShell shell = null;
						try
						{
							shell = qsRsrcs.JobRunShellFactory.CreateJobRunShell(bndle);
							shell.Initialize(qs);
						}
						catch (SchedulerException)
						{
							try
							{
								qsRsrcs.JobStore.TriggeredJobComplete(trigger, bndle.JobDetail, SchedulerInstruction.SetAllJobTriggersError);
							}
							catch (SchedulerException se4)
							{
								qs.NotifySchedulerListenersError(string.Concat("An error occurred while placing job's triggers in error state '", trigger.Key, "'"), se4);
								ErrorTriggerRetryLoop(bndle);
							}
							continue;
						}
						if (!qsRsrcs.ThreadPool.RunInThread(shell))
						{
							try
							{
								Log.Error("ThreadPool.runInThread() return false!");
								qsRsrcs.JobStore.TriggeredJobComplete(trigger, bndle.JobDetail, SchedulerInstruction.SetAllJobTriggersError);
							}
							catch (SchedulerException se3)
							{
								qs.NotifySchedulerListenersError(string.Format(CultureInfo.InvariantCulture, "An error occurred while placing job's triggers in error state '{0}'", new object[1] { trigger.Key }), se3);
								ReleaseTriggerRetryLoop(trigger);
							}
						}
					}
					continue;
				}
				DateTimeOffset utcNow = SystemTime.UtcNow();
				DateTimeOffset waitTime = utcNow.Add(GetRandomizedIdleWaitTime());
				TimeSpan timeUntilContinue = waitTime - utcNow;
				lock (sigLock)
				{
					if (!halted)
					{
						try
						{
							Monitor.Wait(sigLock, timeUntilContinue);
						}
						catch (ThreadInterruptedException)
						{
						}
					}
				}
				continue;
			}
			catch (Exception re)
			{
				if (Log != null)
				{
					Log.Error("Runtime error occurred in main trigger firing loop.", re);
				}
				continue;
			}
		}
		qs = null;
		qsRsrcs = null;
	}

	private bool ReleaseIfScheduleChangedSignificantly(IList<IOperableTrigger> triggers, DateTimeOffset triggerTime)
	{
		if (IsCandidateNewTimeEarlierWithinReason(triggerTime, clearSignal: true))
		{
			foreach (IOperableTrigger trigger in triggers)
			{
				try
				{
					qsRsrcs.JobStore.ReleaseAcquiredTrigger(trigger);
				}
				catch (JobPersistenceException jpe)
				{
					qs.NotifySchedulerListenersError($"An error occurred while releasing trigger '{trigger.Key}'", jpe);
					ReleaseTriggerRetryLoop(trigger);
				}
				catch (Exception e)
				{
					Log.Error("ReleaseTriggerRetryLoop: Exception " + e.Message, e);
					ReleaseTriggerRetryLoop(trigger);
				}
			}
			triggers.Clear();
			return true;
		}
		return false;
	}

	private bool IsCandidateNewTimeEarlierWithinReason(DateTimeOffset oldTimeUtc, bool clearSignal)
	{
		lock (sigLock)
		{
			if (!IsScheduleChanged())
			{
				return false;
			}
			bool earlier = false;
			if (!GetSignaledNextFireTimeUtc().HasValue)
			{
				earlier = true;
			}
			else if (GetSignaledNextFireTimeUtc().Value < oldTimeUtc)
			{
				earlier = true;
			}
			if (earlier)
			{
				TimeSpan diff = oldTimeUtc - SystemTime.UtcNow();
				if (diff < (qsRsrcs.JobStore.SupportsPersistence ? TimeSpan.FromMilliseconds(70.0) : TimeSpan.FromMilliseconds(7.0)))
				{
					earlier = false;
				}
			}
			if (clearSignal)
			{
				ClearSignaledSchedulingChange();
			}
			return earlier;
		}
	}

	/// <summary>
	/// Trigger retry loop that is executed on error condition.
	/// </summary>
	/// <param name="bndle">The bndle.</param>
	public virtual void ErrorTriggerRetryLoop(TriggerFiredBundle bndle)
	{
		int retryCount = 0;
		try
		{
			while (!halted)
			{
				try
				{
					Thread.Sleep(DbFailureRetryInterval);
					retryCount++;
					qsRsrcs.JobStore.TriggeredJobComplete(bndle.Trigger, bndle.JobDetail, SchedulerInstruction.SetAllJobTriggersError);
					retryCount = 0;
					break;
				}
				catch (JobPersistenceException jpe)
				{
					if (retryCount % 4 == 0)
					{
						qs.NotifySchedulerListenersError(string.Format(CultureInfo.InvariantCulture, "An error occurred while releasing trigger '{0}'", new object[1] { bndle.Trigger.Key }), jpe);
					}
				}
				catch (ThreadInterruptedException e2)
				{
					Log.Error(string.Format(CultureInfo.InvariantCulture, "ReleaseTriggerRetryLoop: InterruptedException {0}", new object[1] { e2.Message }), e2);
				}
				catch (Exception e)
				{
					Log.Error(string.Format(CultureInfo.InvariantCulture, "ReleaseTriggerRetryLoop: Exception {0}", new object[1] { e.Message }), e);
				}
			}
		}
		finally
		{
			if (retryCount == 0)
			{
				Log.Info("ReleaseTriggerRetryLoop: connection restored.");
			}
		}
	}

	/// <summary>
	/// Releases the trigger retry loop.
	/// </summary>
	/// <param name="trigger">The trigger.</param>
	public virtual void ReleaseTriggerRetryLoop(IOperableTrigger trigger)
	{
		int retryCount = 0;
		try
		{
			while (!halted)
			{
				try
				{
					Thread.Sleep(DbFailureRetryInterval);
					retryCount++;
					qsRsrcs.JobStore.ReleaseAcquiredTrigger(trigger);
					retryCount = 0;
					break;
				}
				catch (JobPersistenceException jpe)
				{
					if (retryCount % 4 == 0)
					{
						qs.NotifySchedulerListenersError(string.Format(CultureInfo.InvariantCulture, "An error occurred while releasing trigger '{0}'", new object[1] { trigger.Key }), jpe);
					}
				}
				catch (ThreadInterruptedException e2)
				{
					Log.Error(string.Format(CultureInfo.InvariantCulture, "ReleaseTriggerRetryLoop: InterruptedException {0}", new object[1] { e2.Message }), e2);
				}
				catch (Exception e)
				{
					Log.Error(string.Format(CultureInfo.InvariantCulture, "ReleaseTriggerRetryLoop: Exception {0}", new object[1] { e.Message }), e);
				}
			}
		}
		finally
		{
			if (retryCount == 0)
			{
				Log.Info("ReleaseTriggerRetryLoop: connection restored.");
			}
		}
	}
}
