using System;
using System.Net;
using Common.Logging;
using Quartz.Spi;

namespace Quartz.Simpl;

/// <summary>
/// Helper base class for host name lookup requiring instance id generators.
/// </summary>
/// <author>Marko Lahma</author>
public abstract class HostNameBasedIdGenerator : IInstanceIdGenerator
{
	protected const int IdMaxLengh = 50;

	private readonly ILog logger;

	protected HostNameBasedIdGenerator()
	{
		logger = LogManager.GetLogger(GetType());
	}

	/// <summary>
	/// Generate the instance id for a <see cref="T:Quartz.IScheduler" />
	/// </summary>
	/// <returns> The clusterwide unique instance id.
	/// </returns>
	public abstract string GenerateInstanceId();

	protected string GetHostName(int maxLenght)
	{
		try
		{
			string hostName = GetHostAddress().HostName;
			if (hostName != null && hostName.Length > maxLenght)
			{
				string newName = hostName.Substring(0, maxLenght);
				logger.WarnFormat("Host name '{0}' was too long, shortened to '{1}'", hostName, newName);
				hostName = newName;
			}
			return hostName;
		}
		catch (Exception e)
		{
			throw new SchedulerException("Couldn't get host name!", e);
		}
	}

	protected virtual IPHostEntry GetHostAddress()
	{
		return Dns.GetHostByAddress(Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString());
	}
}
