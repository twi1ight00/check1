namespace Quartz.Simpl;

/// <summary> 
/// The default InstanceIdGenerator used by Quartz when instance id is to be
/// automatically generated.  Instance id is of the form HOSTNAME + CURRENT_TIME.
/// </summary>
/// <author>Marko Lahma (.NET)</author>
/// <seealso cref="T:Quartz.Spi.IInstanceIdGenerator" />
/// <seealso cref="T:Quartz.Simpl.HostnameInstanceIdGenerator" />
public class SimpleInstanceIdGenerator : HostNameBasedIdGenerator
{
	private const int HostNameMaxLength = 30;

	/// <summary>
	/// Generate the instance id for a <see cref="T:Quartz.IScheduler" />
	/// </summary>
	/// <returns>The clusterwide unique instance id.</returns>
	public override string GenerateInstanceId()
	{
		string hostName = GetHostName(30);
		return hostName + SystemTime.UtcNow().Ticks;
	}
}
