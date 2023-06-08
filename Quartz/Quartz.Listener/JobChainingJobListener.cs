using System;
using System.Collections.Generic;
using System.Globalization;

namespace Quartz.Listener;

/// <summary>
/// Keeps a collection of mappings of which Job to trigger after the completion
/// of a given job.  If this listener is notified of a job completing that has a
/// mapping, then it will then attempt to trigger the follow-up job.  This
/// achieves "job chaining", or a "poor man's workflow".
///             </summary>
/// <remarks>
/// <para>
/// Generally an instance of this listener would be registered as a global
/// job listener, rather than being registered directly to a given job.
/// </para>
/// <para>
/// If for some reason there is a failure creating the trigger for the
/// follow-up job (which would generally only be caused by a rare serious
/// failure in the system, or the non-existence of the follow-up job), an error
/// messsage is logged, but no other action is taken. If you need more rigorous
/// handling of the error, consider scheduling the triggering of the flow-up
/// job within your job itself.
/// </para>
///             </remarks>
/// <author>James House</author>
/// <author>Marko Lahma (.NET)</author>
public class JobChainingJobListener : JobListenerSupport
{
	private readonly string name;

	private readonly IDictionary<JobKey, JobKey> chainLinks;

	public override string Name => name;

	/// <summary>
	/// Construct an instance with the given name.
	/// </summary>
	/// <param name="name">The name of this instance.</param>
	public JobChainingJobListener(string name)
	{
		if (name == null)
		{
			throw new ArgumentException("Listener name cannot be null!");
		}
		this.name = name;
		chainLinks = new Dictionary<JobKey, JobKey>();
	}

	/// <summary>
	/// Add a chain mapping - when the Job identified by the first key completes
	/// the job identified by the second key will be triggered.
	/// </summary>
	/// <param name="firstJob">a JobKey with the name and group of the first job</param>
	/// <param name="secondJob">a JobKey with the name and group of the follow-up job</param>
	public void AddJobChainLink(JobKey firstJob, JobKey secondJob)
	{
		if (firstJob == null || secondJob == null)
		{
			throw new ArgumentException("Key cannot be null!");
		}
		if (firstJob.Name == null || secondJob.Name == null)
		{
			throw new ArgumentException("Key cannot have a null name!");
		}
		chainLinks.Add(firstJob, secondJob);
	}

	public override void JobWasExecuted(IJobExecutionContext context, JobExecutionException jobException)
	{
		chainLinks.TryGetValue(context.JobDetail.Key, out var sj);
		if (sj == null)
		{
			return;
		}
		base.Log.Info(string.Format(CultureInfo.InvariantCulture, "Job '{0}' will now chain to Job '{1}'", new object[2]
		{
			context.JobDetail.Key,
			sj
		}));
		try
		{
			context.Scheduler.TriggerJob(sj);
		}
		catch (SchedulerException se)
		{
			base.Log.Error(string.Format(CultureInfo.InvariantCulture, "Error encountered during chaining to Job '{0}'", new object[1] { sj }), se);
		}
	}
}
