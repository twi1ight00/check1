using System;
using Quartz.Spi;

namespace Quartz.Simpl;

/// <summary>
/// InstanceIdGenerator that will use a <see cref="F:Quartz.Simpl.SystemPropertyInstanceIdGenerator.SystemProperty" /> to configure the scheduler.
/// If no value set for the property, a <see cref="T:Quartz.SchedulerException" /> is thrown.
/// <author>Alex Snaps</author>
/// </summary>
public class SystemPropertyInstanceIdGenerator : IInstanceIdGenerator
{
	/// <summary>
	/// System property to read the instanceId from.
	/// </summary>
	public const string SystemProperty = "quartz.scheduler.instanceId";

	private string prepend;

	private string postpend;

	private string systemPropertyName = "quartz.scheduler.instanceId";

	/// <summary>
	/// A string of text to prepend (add to the beginning) to the instanceId found in the system property.
	/// </summary>
	public string Prepend
	{
		get
		{
			return prepend;
		}
		set
		{
			prepend = value?.Trim();
		}
	}

	/// <summary>
	/// A string of text to postpend (add to the end) to the instanceId found in the system property.
	/// </summary>
	public string Postpend
	{
		get
		{
			return postpend;
		}
		set
		{
			postpend = value?.Trim();
		}
	}

	/// <summary>
	/// The name of the system property from which to obtain the instanceId.
	/// </summary>
	/// <remarks>
	/// Defaults to <see cref="F:Quartz.Simpl.SystemPropertyInstanceIdGenerator.SystemProperty" />.
	/// </remarks>
	public string SystemPropertyName
	{
		get
		{
			return systemPropertyName;
		}
		set
		{
			systemPropertyName = ((value == null) ? "quartz.scheduler.instanceId" : value.Trim());
		}
	}

	/// <summary>
	/// Returns the cluster wide value for this scheduler instance's id, based on a system property.
	/// </summary>
	public string GenerateInstanceId()
	{
		string property = Environment.GetEnvironmentVariable(SystemPropertyName);
		if (property == null)
		{
			throw new SchedulerException("No value for 'quartz.scheduler.instanceId' system property found, please configure your environment accordingly!");
		}
		if (Prepend != null)
		{
			property = Prepend + property;
		}
		if (Postpend != null)
		{
			property += Postpend;
		}
		return property;
	}
}
