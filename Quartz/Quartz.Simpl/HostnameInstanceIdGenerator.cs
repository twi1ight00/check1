namespace Quartz.Simpl;

/// <summary>
/// <see cref="T:Quartz.Spi.IInstanceIdGenerator" /> that names the scheduler instance using 
/// just the machine hostname.
/// </summary>
/// <remarks>
/// This class is useful when you know that your scheduler instance will be the 
/// only one running on a particular machine.  Each time the scheduler is 
/// restarted, it will get the same instance id as long as the machine is not 
/// renamed.
/// </remarks>
/// <author>Marko Lahma (.NET)</author>
/// <seealso cref="T:Quartz.Spi.IInstanceIdGenerator" />
/// <seealso cref="T:Quartz.Simpl.SimpleInstanceIdGenerator" />
public class HostnameInstanceIdGenerator : HostNameBasedIdGenerator
{
	/// <summary>
	/// Generate the instance id for a <see cref="T:Quartz.IScheduler" />
	/// </summary>
	/// <returns>The clusterwide unique instance id.</returns>
	public override string GenerateInstanceId()
	{
		return GetHostName(50);
	}
}
