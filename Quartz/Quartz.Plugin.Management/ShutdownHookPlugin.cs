using System;
using System.Globalization;
using Common.Logging;
using Quartz.Spi;

namespace Quartz.Plugin.Management;

/// <summary> 
/// This plugin catches the event of the VM terminating (such as upon a CRTL-C)
/// and tells the scheuler to Shutdown.
/// </summary>
/// <seealso cref="M:Quartz.IScheduler.Shutdown(System.Boolean)" />
/// <author>James House</author>
/// <author>Marko Lahma (.NET)</author>
public class ShutdownHookPlugin : ISchedulerPlugin
{
	private static readonly ILog log = LogManager.GetLogger(typeof(ShutdownHookPlugin));

	/// <summary> 
	/// Determine whether or not the plug-in is configured to cause a clean
	/// Shutdown of the scheduler.
	/// <para>
	/// The default value is <see langword="true" />.
	/// </para>
	/// </summary>
	/// <seealso cref="M:Quartz.IScheduler.Shutdown(System.Boolean)" />
	public bool CleanShutdown { get; set; }

	public ShutdownHookPlugin()
	{
		CleanShutdown = true;
	}

	/// <summary>
	/// Called during creation of the <see cref="T:Quartz.IScheduler" /> in order to give
	/// the <see cref="T:Quartz.Spi.ISchedulerPlugin" /> a chance to Initialize.
	/// </summary>
	public virtual void Initialize(string pluginName, IScheduler scheduler)
	{
		log.InfoFormat(CultureInfo.InvariantCulture, "Registering Quartz Shutdown hook '{0}.", pluginName);
		AppDomain.CurrentDomain.ProcessExit += delegate
		{
			log.Info("Shutting down Quartz...");
			try
			{
				scheduler.Shutdown(CleanShutdown);
			}
			catch (SchedulerException ex)
			{
				log.Info("Error shutting down Quartz: " + ex.Message, ex);
			}
		};
	}

	/// <summary>
	/// Called when the associated <see cref="T:Quartz.IScheduler" /> is started, in order
	/// to let the plug-in know it can now make calls into the scheduler if it
	/// needs to.
	/// </summary>
	public virtual void Start()
	{
	}

	/// <summary>
	/// Called in order to inform the <see cref="T:Quartz.Spi.ISchedulerPlugin" /> that it
	/// should free up all of it's resources because the scheduler is shutting
	/// down.
	/// </summary>
	public virtual void Shutdown()
	{
	}
}
