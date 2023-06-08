namespace Quartz.Spi;

/// <summary>
/// An IInstanceIdGenerator is responsible for generating the clusterwide unique 
/// instance id for a <see cref="T:Quartz.IScheduler" /> node.
/// </summary>
/// <remarks>
/// This interface may be of use to those wishing to have specific control over 
/// the mechanism by which the <see cref="T:Quartz.IScheduler" /> instances in their 
/// application are named.
/// </remarks>
/// <seealso cref="T:Quartz.Simpl.SimpleInstanceIdGenerator" />
/// <author>Marko Lahma (.NET)</author>
public interface IInstanceIdGenerator
{
	/// <summary>
	/// Generate the instance id for a <see cref="T:Quartz.IScheduler" />
	/// </summary>
	/// <returns> The clusterwide unique instance id.
	/// </returns>
	string GenerateInstanceId();
}
