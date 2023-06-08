using System;
using Enyim.Caching.Memcached;

namespace Enyim.Caching.Configuration;

public class SocketPoolConfiguration : ISocketPoolConfiguration
{
	private int minPoolSize = 10;

	private int maxPoolSize = 20;

	private TimeSpan connectionTimeout = new TimeSpan(0, 0, 10);

	private TimeSpan receiveTimeout = new TimeSpan(0, 0, 10);

	private TimeSpan deadTimeout = new TimeSpan(0, 0, 10);

	private TimeSpan queueTimeout = new TimeSpan(0, 0, 0, 0, 100);

	private INodeFailurePolicyFactory policyFactory = new FailImmediatelyPolicyFactory();

	int ISocketPoolConfiguration.MinPoolSize
	{
		get
		{
			return minPoolSize;
		}
		set
		{
			if (value < 0)
			{
				throw new ArgumentOutOfRangeException("value", "MinPoolSize must be >= 0!");
			}
			if (value > maxPoolSize)
			{
				throw new ArgumentOutOfRangeException("value", "MinPoolSize must be <= MaxPoolSize!");
			}
			minPoolSize = value;
		}
	}

	/// <summary>
	/// Gets or sets a value indicating the maximum amount of sockets per server in the socket pool.
	/// </summary>
	/// <returns>The maximum amount of sockets per server in the socket pool. The default is 20.</returns>
	/// <remarks>It should be 0.75 * (number of threads) for optimal performance.</remarks>
	int ISocketPoolConfiguration.MaxPoolSize
	{
		get
		{
			return maxPoolSize;
		}
		set
		{
			if (value < minPoolSize)
			{
				throw new ArgumentOutOfRangeException("value", "MaxPoolSize must be >= MinPoolSize!");
			}
			maxPoolSize = value;
		}
	}

	TimeSpan ISocketPoolConfiguration.ConnectionTimeout
	{
		get
		{
			return connectionTimeout;
		}
		set
		{
			if (value < TimeSpan.Zero)
			{
				throw new ArgumentOutOfRangeException("value", "value must be positive");
			}
			connectionTimeout = value;
		}
	}

	TimeSpan ISocketPoolConfiguration.ReceiveTimeout
	{
		get
		{
			return receiveTimeout;
		}
		set
		{
			if (value < TimeSpan.Zero)
			{
				throw new ArgumentOutOfRangeException("value", "value must be positive");
			}
			receiveTimeout = value;
		}
	}

	TimeSpan ISocketPoolConfiguration.QueueTimeout
	{
		get
		{
			return queueTimeout;
		}
		set
		{
			if (value < TimeSpan.Zero)
			{
				throw new ArgumentOutOfRangeException("value", "value must be positive");
			}
			queueTimeout = value;
		}
	}

	TimeSpan ISocketPoolConfiguration.DeadTimeout
	{
		get
		{
			return deadTimeout;
		}
		set
		{
			if (value < TimeSpan.Zero)
			{
				throw new ArgumentOutOfRangeException("value", "value must be positive");
			}
			deadTimeout = value;
		}
	}

	INodeFailurePolicyFactory ISocketPoolConfiguration.FailurePolicyFactory
	{
		get
		{
			return policyFactory;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			policyFactory = value;
		}
	}
}
