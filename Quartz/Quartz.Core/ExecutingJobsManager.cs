using System.Collections.Generic;
using System.Threading;
using Quartz.Spi;

namespace Quartz.Core;

internal class ExecutingJobsManager : IJobListener
{
	private readonly Dictionary<string, IJobExecutionContext> executingJobs = new Dictionary<string, IJobExecutionContext>();

	private int numJobsFired;

	public virtual string Name => GetType().FullName;

	public virtual int NumJobsCurrentlyExecuting
	{
		get
		{
			lock (executingJobs)
			{
				return executingJobs.Count;
			}
		}
	}

	public virtual int NumJobsFired => numJobsFired;

	public virtual IList<IJobExecutionContext> ExecutingJobs
	{
		get
		{
			lock (executingJobs)
			{
				return new List<IJobExecutionContext>(executingJobs.Values).AsReadOnly();
			}
		}
	}

	public virtual void JobToBeExecuted(IJobExecutionContext context)
	{
		Interlocked.Increment(ref numJobsFired);
		lock (executingJobs)
		{
			executingJobs[((IOperableTrigger)context.Trigger).FireInstanceId] = context;
		}
	}

	public virtual void JobWasExecuted(IJobExecutionContext context, JobExecutionException jobException)
	{
		lock (executingJobs)
		{
			executingJobs.Remove(((IOperableTrigger)context.Trigger).FireInstanceId);
		}
	}

	public virtual void JobExecutionVetoed(IJobExecutionContext context)
	{
	}
}
