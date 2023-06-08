using System;
using System.Collections.Generic;
using System.Globalization;
using Quartz.Spi;

namespace Quartz.Core;

/// <summary>
/// Contains all of the resources (<see cref="T:Quartz.Spi.IJobStore" />,<see cref="T:Quartz.Spi.IThreadPool" />,
/// etc.) necessary to create a <see cref="T:Quartz.Core.QuartzScheduler" /> instance.
/// </summary>
/// <seealso cref="T:Quartz.Core.QuartzScheduler" />
/// <author>James House</author>
/// <author>Marko Lahma (.NET)</author>
public class QuartzSchedulerResources
{
	private string name;

	private string instanceId;

	private string threadName;

	private IThreadPool threadPool;

	private IJobStore jobStore;

	private IJobRunShellFactory jobRunShellFactory;

	private readonly IList<ISchedulerPlugin> schedulerPlugins = new List<ISchedulerPlugin>(10);

	/// <summary>
	/// Get or set the name for the <see cref="T:Quartz.Core.QuartzScheduler" />.
	/// </summary>
	/// <exception cref="T:System.ArgumentException">
	/// if name is null or empty.
	/// </exception>
	public virtual string Name
	{
		get
		{
			return name;
		}
		set
		{
			if (value == null || value.Trim().Length == 0)
			{
				throw new ArgumentException("Scheduler name cannot be empty.");
			}
			name = value;
			if (threadName == null)
			{
				ThreadName = string.Format(CultureInfo.InvariantCulture, "{0}_QuartzSchedulerThread", new object[1] { value });
			}
		}
	}

	/// <summary>
	/// Get or set the instance Id for the <see cref="T:Quartz.Core.QuartzScheduler" />.
	/// </summary>
	/// <exception cref="T:System.ArgumentException"> 
	/// if name is null or empty.
	/// </exception>
	public virtual string InstanceId
	{
		get
		{
			return instanceId;
		}
		set
		{
			if (value == null || value.Trim().Length == 0)
			{
				throw new ArgumentException("Scheduler instanceId cannot be empty.");
			}
			instanceId = value;
		}
	}

	/// <summary>
	/// Get or set the name for the <see cref="T:Quartz.Core.QuartzSchedulerThread" />.
	/// </summary>
	/// <exception cref="T:System.ArgumentException"> 
	/// if name is null or empty.
	/// </exception>
	public virtual string ThreadName
	{
		get
		{
			return threadName;
		}
		set
		{
			if (value == null || value.Trim().Length == 0)
			{
				throw new ArgumentException("Scheduler thread name cannot be empty.");
			}
			threadName = value;
		}
	}

	/// <summary>
	/// Get or set the <see cref="P:Quartz.Core.QuartzSchedulerResources.ThreadPool" /> for the <see cref="T:Quartz.Core.QuartzScheduler" />
	/// to use.
	/// </summary>
	/// <exception cref="T:System.ArgumentException"> 
	/// if threadPool is null.
	/// </exception>
	public virtual IThreadPool ThreadPool
	{
		get
		{
			return threadPool;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentException("ThreadPool cannot be null.");
			}
			threadPool = value;
		}
	}

	/// <summary>
	/// Get or set the <see cref="T:Quartz.Spi.IJobStore" /> for the <see cref="T:Quartz.Core.QuartzScheduler" />
	/// to use.
	/// </summary>
	/// <exception cref="T:System.ArgumentException"> 
	/// if jobStore is null.
	/// </exception>
	public virtual IJobStore JobStore
	{
		get
		{
			return jobStore;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentException("JobStore cannot be null.");
			}
			jobStore = value;
		}
	}

	/// <summary> 
	/// Get or set the <see cref="P:Quartz.Core.QuartzSchedulerResources.JobRunShellFactory" /> for the <see cref="T:Quartz.Core.QuartzScheduler" />
	/// to use.
	/// </summary>
	/// <exception cref="T:System.ArgumentException"> 
	/// if jobRunShellFactory is null.
	/// </exception>
	public virtual IJobRunShellFactory JobRunShellFactory
	{
		get
		{
			return jobRunShellFactory;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentException("JobRunShellFactory cannot be null.");
			}
			jobRunShellFactory = value;
		}
	}

	/// <summary>
	/// Get the <see cref="T:System.Collections.Generic.IList`1" /> of all  <see cref="T:Quartz.Spi.ISchedulerPlugin" />s for the 
	/// <see cref="T:Quartz.Core.QuartzScheduler" /> to use.
	/// </summary>
	/// <returns></returns>
	public IList<ISchedulerPlugin> SchedulerPlugins => schedulerPlugins;

	/// <summary>
	/// Gets or sets a value indicating whether to make scheduler thread daemon.
	/// </summary>
	/// <value>
	/// 	<c>true</c> if scheduler should be thread daemon; otherwise, <c>false</c>.
	/// </value>
	public bool MakeSchedulerThreadDaemon { get; set; }

	/// <summary>
	/// Gets or sets the scheduler exporter.
	/// </summary>
	/// <value>The scheduler exporter.</value>
	public ISchedulerExporter SchedulerExporter { get; set; }

	/// <summary>
	/// The ThreadExecutor which runs the QuartzSchedulerThread.
	/// </summary>
	public IThreadExecutor ThreadExecutor { get; set; }

	/// <summary>
	/// Gets or sets the batch time window.
	/// </summary>
	public TimeSpan BatchTimeWindow { get; set; }

	public int MaxBatchSize { get; set; }

	public bool InterruptJobsOnShutdown { get; set; }

	public bool InterruptJobsOnShutdownWithWait { get; set; }

	public QuartzSchedulerResources()
	{
		MaxBatchSize = 1;
		BatchTimeWindow = TimeSpan.Zero;
	}

	/// <summary>
	/// Gets the unique identifier.
	/// </summary>
	/// <param name="schedName">Name of the scheduler.</param>
	/// <param name="schedInstId">The scheduler instance id.</param>
	/// <returns></returns>
	public static string GetUniqueIdentifier(string schedName, string schedInstId)
	{
		return string.Format(CultureInfo.InvariantCulture, "{0}_$_{1}", new object[2] { schedName, schedInstId });
	}

	/// <summary>
	/// Gets the unique identifier.
	/// </summary>
	/// <returns></returns>
	public virtual string GetUniqueIdentifier()
	{
		return GetUniqueIdentifier(name, instanceId);
	}

	/// <summary>
	/// Add the given <see cref="T:Quartz.Spi.ISchedulerPlugin" /> for the 
	/// <see cref="T:Quartz.Core.QuartzScheduler" /> to use. This method expects the plugin's
	/// "initialize" method to be invoked externally (either before or after
	/// this method is called).
	/// </summary>
	/// <param name="plugin"></param>
	public void AddSchedulerPlugin(ISchedulerPlugin plugin)
	{
		schedulerPlugins.Add(plugin);
	}
}
