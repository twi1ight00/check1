using System;
using System.Globalization;
using System.Threading;
using Common.Logging;
using Quartz.Impl;
using Quartz.Listener;
using Quartz.Spi;

namespace Quartz.Core;

/// <summary> 
/// JobRunShell instances are responsible for providing the 'safe' environment
/// for <see cref="T:Quartz.IJob" /> s to run in, and for performing all of the work of
/// executing the <see cref="T:Quartz.IJob" />, catching ANY thrown exceptions, updating
/// the <see cref="T:Quartz.ITrigger" /> with the <see cref="T:Quartz.IJob" />'s completion code,
/// etc.
/// <para>
/// A <see cref="T:Quartz.Core.JobRunShell" /> instance is created by a <see cref="T:Quartz.Core.IJobRunShellFactory" />
/// on behalf of the <see cref="T:Quartz.Core.QuartzSchedulerThread" /> which then runs the
/// shell in a thread from the configured <see cref="T:System.Threading.ThreadPool" /> when the
/// scheduler determines that a <see cref="T:Quartz.IJob" /> has been triggered.
/// </para>
/// </summary>
/// <seealso cref="T:Quartz.Core.IJobRunShellFactory" /> 
/// <seealso cref="T:Quartz.Core.QuartzSchedulerThread" />
/// <seealso cref="T:Quartz.IJob" />
/// <seealso cref="T:Quartz.ITrigger" />
/// <author>James House</author>
/// <author>Marko Lahma (.NET)</author>
public class JobRunShell : SchedulerListenerSupport, IThreadRunnable
{
	[Serializable]
	internal class VetoedException : Exception
	{
		private readonly JobRunShell enclosingInstance;

		public JobRunShell EnclosingInstance => enclosingInstance;

		public VetoedException(JobRunShell shell)
		{
			enclosingInstance = shell;
		}
	}

	private readonly ILog log;

	private JobExecutionContextImpl jec;

	private QuartzScheduler qs;

	private readonly IScheduler scheduler;

	private readonly TriggerFiredBundle firedTriggerBundle;

	private volatile bool shutdownRequested;

	/// <summary>
	/// Create a JobRunShell instance with the given settings.
	/// </summary>
	/// <param name="scheduler">The <see cref="T:Quartz.IScheduler" /> instance that should be made
	/// available within the <see cref="T:Quartz.IJobExecutionContext" />.</param>
	/// <param name="bundle"></param>
	public JobRunShell(IScheduler scheduler, TriggerFiredBundle bundle)
	{
		this.scheduler = scheduler;
		firedTriggerBundle = bundle;
		log = LogManager.GetLogger(GetType());
	}

	public override void SchedulerShuttingdown()
	{
		RequestShutdown();
	}

	/// <summary>
	/// Initializes the job execution context with given scheduler and bundle.
	/// </summary>
	/// <param name="sched">The scheduler.</param>
	public virtual void Initialize(QuartzScheduler sched)
	{
		qs = sched;
		IJobDetail jobDetail = firedTriggerBundle.JobDetail;
		IJob job;
		try
		{
			job = sched.JobFactory.NewJob(firedTriggerBundle, scheduler);
		}
		catch (SchedulerException se2)
		{
			sched.NotifySchedulerListenersError(string.Format(CultureInfo.InvariantCulture, "An error occured instantiating job to be executed. job= '{0}'", new object[1] { jobDetail.Key }), se2);
			throw;
		}
		catch (Exception e)
		{
			SchedulerException se = new SchedulerException(string.Format(CultureInfo.InvariantCulture, "Problem instantiating type '{0}'", new object[1] { jobDetail.JobType.FullName }), e);
			sched.NotifySchedulerListenersError(string.Format(CultureInfo.InvariantCulture, "An error occured instantiating job to be executed. job= '{0}'", new object[1] { jobDetail.Key }), se);
			throw se;
		}
		jec = new JobExecutionContextImpl(scheduler, firedTriggerBundle, job);
	}

	/// <summary>
	/// Requests the Shutdown.
	/// </summary>
	public virtual void RequestShutdown()
	{
		shutdownRequested = true;
	}

	/// <summary>
	/// This method has to be implemented in order that starting of the thread causes the object's
	/// run method to be called in that separately executing thread.
	/// </summary>
	public virtual void Run()
	{
		qs.AddInternalSchedulerListener(this);
		try
		{
			IOperableTrigger trigger = (IOperableTrigger)jec.Trigger;
			IJobDetail jobDetail = jec.JobDetail;
			while (true)
			{
				JobExecutionException jobExEx = null;
				IJob job = jec.JobInstance;
				try
				{
					Begin();
				}
				catch (SchedulerException se6)
				{
					qs.NotifySchedulerListenersError(string.Format(CultureInfo.InvariantCulture, "Error executing Job ({0}: couldn't begin execution.", new object[1] { jec.JobDetail.Key }), se6);
					break;
				}
				SchedulerInstruction instCode;
				try
				{
					if (!NotifyListenersBeginning(jec))
					{
						break;
					}
				}
				catch (VetoedException)
				{
					try
					{
						instCode = trigger.ExecutionComplete(jec, null);
						try
						{
							qs.NotifyJobStoreJobVetoed(trigger, jobDetail, instCode);
						}
						catch (JobPersistenceException)
						{
							VetoedJobRetryLoop(trigger, jobDetail, instCode);
						}
						if (!jec.Trigger.GetNextFireTimeUtc().HasValue)
						{
							qs.NotifySchedulerListenersFinalized(jec.Trigger);
						}
						Complete(successfulExecution: true);
						break;
					}
					catch (SchedulerException se5)
					{
						qs.NotifySchedulerListenersError(string.Format(CultureInfo.InvariantCulture, "Error during veto of Job ({0}: couldn't finalize execution.", new object[1] { jec.JobDetail.Key }), se5);
						break;
					}
				}
				DateTimeOffset startTime = SystemTime.UtcNow();
				DateTimeOffset endTime;
				try
				{
					if (log.IsDebugEnabled)
					{
						log.Debug("Calling Execute on job " + jobDetail.Key);
					}
					job.Execute(jec);
					endTime = SystemTime.UtcNow();
				}
				catch (JobExecutionException jee)
				{
					endTime = SystemTime.UtcNow();
					jobExEx = jee;
					log.Info(string.Format(CultureInfo.InvariantCulture, "Job {0} threw a JobExecutionException: ", new object[1] { jobDetail.Key }), jobExEx);
				}
				catch (Exception e2)
				{
					endTime = SystemTime.UtcNow();
					log.Error(string.Format(CultureInfo.InvariantCulture, "Job {0} threw an unhandled Exception: ", new object[1] { jobDetail.Key }), e2);
					SchedulerException se4 = new SchedulerException("Job threw an unhandled exception.", e2);
					qs.NotifySchedulerListenersError(string.Format(CultureInfo.InvariantCulture, "Job ({0} threw an exception.", new object[1] { jec.JobDetail.Key }), se4);
					jobExEx = new JobExecutionException(se4, refireImmediately: false);
				}
				jec.JobRunTime = endTime - startTime;
				if (!NotifyJobListenersComplete(jec, jobExEx))
				{
					break;
				}
				instCode = SchedulerInstruction.NoInstruction;
				try
				{
					instCode = trigger.ExecutionComplete(jec, jobExEx);
					if (log.IsDebugEnabled)
					{
						log.Debug(string.Format(CultureInfo.InvariantCulture, "Trigger instruction : {0}", new object[1] { instCode }));
					}
				}
				catch (Exception e)
				{
					SchedulerException se3 = new SchedulerException("Trigger threw an unhandled exception.", e);
					qs.NotifySchedulerListenersError("Please report this error to the Quartz developers.", se3);
				}
				if (!NotifyTriggerListenersComplete(jec, instCode))
				{
					break;
				}
				if (instCode == SchedulerInstruction.ReExecuteJob)
				{
					if (log.IsDebugEnabled)
					{
						log.Debug("Rescheduling trigger to reexecute");
					}
					jec.IncrementRefireCount();
					try
					{
						Complete(successfulExecution: false);
					}
					catch (SchedulerException se2)
					{
						qs.NotifySchedulerListenersError(string.Format(CultureInfo.InvariantCulture, "Error executing Job ({0}: couldn't finalize execution.", new object[1] { jec.JobDetail.Key }), se2);
					}
					continue;
				}
				try
				{
					Complete(successfulExecution: true);
				}
				catch (SchedulerException se)
				{
					qs.NotifySchedulerListenersError(string.Format(CultureInfo.InvariantCulture, "Error executing Job ({0}: couldn't finalize execution.", new object[1] { jec.JobDetail.Key }), se);
					continue;
				}
				try
				{
					qs.NotifyJobStoreJobComplete(trigger, jobDetail, instCode);
					break;
				}
				catch (JobPersistenceException jpe)
				{
					qs.NotifySchedulerListenersError(string.Format(CultureInfo.InvariantCulture, "An error occured while marking executed job complete. job= '{0}'", new object[1] { jobDetail.Key }), jpe);
					if (CompleteTriggerRetryLoop(trigger, jobDetail, instCode))
					{
					}
					break;
				}
			}
		}
		finally
		{
			qs.RemoveInternalSchedulerListener(this);
			if (jec != null && jec.JobInstance != null)
			{
				qs.JobFactory.ReturnJob(jec.JobInstance);
			}
		}
	}

	/// <summary>
	/// Runs begin procedures on this instance.
	/// </summary>
	protected virtual void Begin()
	{
	}

	/// <summary>
	/// Completes the execution.
	/// </summary>
	/// <param name="successfulExecution">if set to <c>true</c> [successful execution].</param>
	protected virtual void Complete(bool successfulExecution)
	{
	}

	/// <summary>
	/// Passivates this instance.
	/// </summary>
	public virtual void Passivate()
	{
		jec = null;
		qs = null;
	}

	private bool NotifyListenersBeginning(IJobExecutionContext ctx)
	{
		bool vetoed;
		try
		{
			vetoed = qs.NotifyTriggerListenersFired(ctx);
		}
		catch (SchedulerException se3)
		{
			qs.NotifySchedulerListenersError(string.Format(CultureInfo.InvariantCulture, "Unable to notify TriggerListener(s) while firing trigger (Trigger and Job will NOT be fired!). trigger= {0} job= {1}", new object[2]
			{
				ctx.Trigger.Key,
				ctx.JobDetail.Key
			}), se3);
			return false;
		}
		if (vetoed)
		{
			try
			{
				qs.NotifyJobListenersWasVetoed(ctx);
			}
			catch (SchedulerException se2)
			{
				qs.NotifySchedulerListenersError(string.Format(CultureInfo.InvariantCulture, "Unable to notify JobListener(s) of vetoed execution while firing trigger (Trigger and Job will NOT be fired!). trigger= {0} job= {1}", new object[2]
				{
					ctx.Trigger.Key,
					ctx.JobDetail.Key
				}), se2);
			}
			throw new VetoedException(this);
		}
		try
		{
			qs.NotifyJobListenersToBeExecuted(ctx);
		}
		catch (SchedulerException se)
		{
			qs.NotifySchedulerListenersError(string.Format(CultureInfo.InvariantCulture, "Unable to notify JobListener(s) of Job to be executed: (Job will NOT be executed!). trigger= {0} job= {1}", new object[2]
			{
				ctx.Trigger.Key,
				ctx.JobDetail.Key
			}), se);
			return false;
		}
		return true;
	}

	private bool NotifyJobListenersComplete(IJobExecutionContext ctx, JobExecutionException jobExEx)
	{
		try
		{
			qs.NotifyJobListenersWasExecuted(ctx, jobExEx);
		}
		catch (SchedulerException se)
		{
			qs.NotifySchedulerListenersError(string.Format(CultureInfo.InvariantCulture, "Unable to notify JobListener(s) of Job that was executed: (error will be ignored). trigger= {0} job= {1}", new object[2]
			{
				ctx.Trigger.Key,
				ctx.JobDetail.Key
			}), se);
			return false;
		}
		return true;
	}

	private bool NotifyTriggerListenersComplete(IJobExecutionContext ctx, SchedulerInstruction instCode)
	{
		try
		{
			qs.NotifyTriggerListenersComplete(ctx, instCode);
		}
		catch (SchedulerException se)
		{
			qs.NotifySchedulerListenersError(string.Format(CultureInfo.InvariantCulture, "Unable to notify TriggerListener(s) of Job that was executed: (error will be ignored). trigger= {0} job= {1}", new object[2]
			{
				ctx.Trigger.Key,
				ctx.JobDetail.Key
			}), se);
			return false;
		}
		if (!ctx.Trigger.GetNextFireTimeUtc().HasValue)
		{
			qs.NotifySchedulerListenersFinalized(ctx.Trigger);
		}
		return true;
	}

	/// <summary>
	/// Completes the trigger retry loop.
	/// </summary>
	/// <param name="trigger">The trigger.</param>
	/// <param name="jobDetail">The job detail.</param>
	/// <param name="instCode">The inst code.</param>
	/// <returns></returns>
	public virtual bool CompleteTriggerRetryLoop(IOperableTrigger trigger, IJobDetail jobDetail, SchedulerInstruction instCode)
	{
		long count = 0L;
		while (!shutdownRequested && !qs.IsShuttingDown)
		{
			try
			{
				Thread.Sleep(qs.DbRetryInterval);
				qs.NotifyJobStoreJobComplete(trigger, jobDetail, instCode);
				return true;
			}
			catch (JobPersistenceException jpe)
			{
				if (count % 4 == 0)
				{
					qs.NotifySchedulerListenersError(string.Concat("An error occured while marking executed job complete (will continue attempts). job= '", jobDetail.Key, "'"), jpe);
				}
			}
			catch (ThreadInterruptedException)
			{
			}
			count++;
		}
		return false;
	}

	/// <summary>
	/// Vetoeds the job retry loop.
	/// </summary>
	/// <param name="trigger">The trigger.</param>
	/// <param name="jobDetail">The job detail.</param>
	/// <param name="instCode">The inst code.</param>
	/// <returns></returns>
	public bool VetoedJobRetryLoop(IOperableTrigger trigger, IJobDetail jobDetail, SchedulerInstruction instCode)
	{
		while (!shutdownRequested)
		{
			try
			{
				Thread.Sleep(qs.DbRetryInterval);
				qs.NotifyJobStoreJobVetoed(trigger, jobDetail, instCode);
				return true;
			}
			catch (JobPersistenceException jpe)
			{
				qs.NotifySchedulerListenersError(string.Format(CultureInfo.InvariantCulture, "An error occured while marking executed job vetoed. job= '{0}'", new object[1] { jobDetail.Key }), jpe);
			}
			catch (ThreadInterruptedException)
			{
			}
		}
		return false;
	}
}
