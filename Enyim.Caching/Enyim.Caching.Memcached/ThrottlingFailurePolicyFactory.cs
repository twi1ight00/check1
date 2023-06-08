using System;
using System.Collections.Generic;
using Enyim.Caching.Configuration;

namespace Enyim.Caching.Memcached;

/// <summary>
/// Creates instances of <see cref="T:ThrottlingFailurePolicy" />.
/// </summary>
public class ThrottlingFailurePolicyFactory : INodeFailurePolicyFactory, IProviderFactory<INodeFailurePolicyFactory>, IProvider
{
	/// <summary>
	/// Gets or sets the amount of time of in milliseconds after the failure counter is reset.
	/// </summary>
	public int ResetAfter { get; private set; }

	/// <summary>
	/// Gets or sets the number of failures that must happen in a time window to make a node marked as failed.
	/// </summary>
	public int FailureThreshold { get; private set; }

	public ThrottlingFailurePolicyFactory(int failureThreshold, TimeSpan resetAfter)
		: this(failureThreshold, (int)resetAfter.TotalMilliseconds)
	{
	}

	public ThrottlingFailurePolicyFactory(int failureThreshold, int resetAfter)
	{
		ResetAfter = resetAfter;
		FailureThreshold = failureThreshold;
	}

	internal ThrottlingFailurePolicyFactory()
	{
	}

	INodeFailurePolicy INodeFailurePolicyFactory.Create(IMemcachedNode node)
	{
		return new ThrottlingFailurePolicy(ResetAfter, FailureThreshold);
	}

	INodeFailurePolicyFactory IProviderFactory<INodeFailurePolicyFactory>.Create()
	{
		return new ThrottlingFailurePolicyFactory(FailureThreshold, ResetAfter);
	}

	void IProvider.Initialize(Dictionary<string, string> parameters)
	{
		ConfigurationHelper.TryGetAndRemove(parameters, "failureThreshold", out int failureThreshold, required: true);
		if (failureThreshold < 1)
		{
			throw new InvalidOperationException("failureThreshold must be > 0");
		}
		FailureThreshold = failureThreshold;
		ConfigurationHelper.TryGetAndRemove(parameters, "resetAfter", out TimeSpan reset, required: true);
		if (reset <= TimeSpan.Zero)
		{
			throw new InvalidOperationException("resetAfter must be > 0msec");
		}
		ResetAfter = (int)reset.TotalMilliseconds;
	}
}
