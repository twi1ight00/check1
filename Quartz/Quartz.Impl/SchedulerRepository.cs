using System.Collections.Generic;
using System.Globalization;

namespace Quartz.Impl;

/// <summary>
/// Holds references to Scheduler instances - ensuring uniqueness, and
/// preventing garbage collection, and allowing 'global' lookups.
/// </summary>
/// <author>James House</author>
/// <author>Marko Lahma (.NET)</author>
public class SchedulerRepository
{
	private readonly Dictionary<string, IScheduler> schedulers;

	private static readonly SchedulerRepository inst = new SchedulerRepository();

	private readonly object syncRoot = new object();

	/// <summary>
	/// Gets the singleton instance.
	/// </summary>
	/// <value>The instance.</value>
	public static SchedulerRepository Instance => inst;

	private SchedulerRepository()
	{
		schedulers = new Dictionary<string, IScheduler>();
	}

	/// <summary>
	/// Binds the specified sched.
	/// </summary>
	/// <param name="sched">The sched.</param>
	public virtual void Bind(IScheduler sched)
	{
		lock (syncRoot)
		{
			if (schedulers.ContainsKey(sched.SchedulerName))
			{
				throw new SchedulerException(string.Format(CultureInfo.InvariantCulture, "Scheduler with name '{0}' already exists.", new object[1] { sched.SchedulerName }));
			}
			schedulers[sched.SchedulerName] = sched;
		}
	}

	/// <summary>
	/// Removes the specified sched name.
	/// </summary>
	/// <param name="schedName">Name of the sched.</param>
	/// <returns></returns>
	public virtual bool Remove(string schedName)
	{
		lock (syncRoot)
		{
			return schedulers.Remove(schedName);
		}
	}

	/// <summary>
	/// Lookups the specified sched name.
	/// </summary>
	/// <param name="schedName">Name of the sched.</param>
	/// <returns></returns>
	public virtual IScheduler Lookup(string schedName)
	{
		lock (syncRoot)
		{
			schedulers.TryGetValue(schedName, out var retValue);
			return retValue;
		}
	}

	/// <summary>
	/// Lookups all.
	/// </summary>
	/// <returns></returns>
	public virtual ICollection<IScheduler> LookupAll()
	{
		lock (syncRoot)
		{
			return new List<IScheduler>(schedulers.Values).AsReadOnly();
		}
	}
}
