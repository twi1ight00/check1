using System.Collections.Generic;

namespace Quartz;

/// <summary>
/// Provides a mechanism for obtaining client-usable handles to <see cref="T:Quartz.IScheduler" />
/// instances.
/// </summary>
/// <seealso cref="T:Quartz.IScheduler" />
/// <seealso cref="T:Quartz.Impl.StdSchedulerFactory" />
/// <author>James House</author>
/// <author>Marko Lahma (.NET)</author>
public interface ISchedulerFactory
{
	/// <summary>
	/// Returns handles to all known Schedulers (made by any SchedulerFactory
	/// within this app domain.).
	/// </summary>
	ICollection<IScheduler> AllSchedulers { get; }

	/// <summary>
	/// Returns a client-usable handle to a <see cref="T:Quartz.IScheduler" />.
	/// </summary>
	IScheduler GetScheduler();

	/// <summary>
	/// Returns a handle to the Scheduler with the given name, if it exists.
	/// </summary>
	IScheduler GetScheduler(string schedName);
}
