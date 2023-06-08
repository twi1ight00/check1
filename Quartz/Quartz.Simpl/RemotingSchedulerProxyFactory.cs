using System;
using Quartz.Spi;

namespace Quartz.Simpl;

/// <summary>
/// A <see cref="T:Quartz.Spi.IRemotableSchedulerProxyFactory" /> implementation that creates
/// connection to remote scheduler using remoting.
/// </summary>
public class RemotingSchedulerProxyFactory : IRemotableSchedulerProxyFactory
{
	/// <summary>
	/// Gets or sets the remote scheduler address.
	/// </summary>
	/// <value>The remote scheduler address.</value>
	public string Address { private get; set; }

	/// <summary>
	/// Returns a client proxy to a remote <see cref="T:Quartz.Simpl.IRemotableQuartzScheduler" />.
	/// </summary>
	public IRemotableQuartzScheduler GetProxy()
	{
		return (IRemotableQuartzScheduler)Activator.GetObject(typeof(IRemotableQuartzScheduler), Address);
	}
}
