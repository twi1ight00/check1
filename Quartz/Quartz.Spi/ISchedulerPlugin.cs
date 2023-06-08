namespace Quartz.Spi;

/// <summary>
/// Provides an interface for a class to become a "plugin" to Quartz.
/// </summary>
/// <remarks>
/// Plugins can do virtually anything you wish, though the most interesting ones
/// will obviously interact with the scheduler in some way - either actively: by
/// invoking actions on the scheduler, or passively: by being a <see cref="T:Quartz.IJobListener" />,
/// <see cref="T:Quartz.ITriggerListener" />, and/or <see cref="T:Quartz.ISchedulerListener" />.
/// <para>
/// If you use <see cref="T:Quartz.Impl.StdSchedulerFactory" /> to
/// Initialize your Scheduler, it can also create and Initialize your plugins -
/// look at the configuration docs for details.
/// </para>
/// <para>
/// If you need direct access your plugin, you can have it explicitly put a 
/// reference to itself in the <see cref="T:Quartz.IScheduler" />'s 
/// <see cref="T:Quartz.SchedulerContext" /> as part of its
/// <see cref="M:Quartz.Spi.ISchedulerPlugin.Initialize(System.String,Quartz.IScheduler)" /> method.
/// </para>
/// </remarks>
/// <author>James House</author>
/// <author>Marko Lahma (.NET)</author>
public interface ISchedulerPlugin
{
	/// <summary>
	/// Called during creation of the <see cref="T:Quartz.IScheduler" /> in order to give
	/// the <see cref="T:Quartz.Spi.ISchedulerPlugin" /> a chance to Initialize.
	/// </summary>
	/// <remarks>
	/// At this point, the Scheduler's <see cref="T:Quartz.Spi.IJobStore" /> is not yet
	/// <para>
	/// If you need direct access your plugin, you can have it explicitly put a 
	/// reference to itself in the <see cref="T:Quartz.IScheduler" />'s 
	/// <see cref="T:Quartz.SchedulerContext" /> as part of its
	/// <see cref="M:Quartz.Spi.ISchedulerPlugin.Initialize(System.String,Quartz.IScheduler)" /> method.
	/// </para>
	/// </remarks>
	/// <param name="pluginName">
	/// The name by which the plugin is identified.
	/// </param>
	/// <param name="sched">
	/// The scheduler to which the plugin is registered.
	/// </param>
	void Initialize(string pluginName, IScheduler sched);

	/// <summary>
	/// Called when the associated <see cref="T:Quartz.IScheduler" /> is started, in order
	/// to let the plug-in know it can now make calls into the scheduler if it
	/// needs to.
	/// </summary>
	void Start();

	/// <summary>
	/// Called in order to inform the <see cref="T:Quartz.Spi.ISchedulerPlugin" /> that it
	/// should free up all of it's resources because the scheduler is shutting
	/// down.
	/// </summary>
	void Shutdown();
}
