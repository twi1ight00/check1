using System;
using System.Collections.Generic;
using System.Linq;

namespace Enyim.Caching.Memcached;

/// <summary>
/// This is a simple node locator with no computation overhead, always returns the first server from the list. Use only in single server deployments.
/// </summary>
public sealed class SingleNodeLocator : IMemcachedNodeLocator
{
	private IMemcachedNode node;

	private bool isInitialized;

	private object initLock = new object();

	void IMemcachedNodeLocator.Initialize(IList<IMemcachedNode> nodes)
	{
		if (isInitialized)
		{
			throw new InvalidOperationException("Instance is already initialized.");
		}
		lock (initLock)
		{
			if (isInitialized)
			{
				throw new InvalidOperationException("Instance is already initialized.");
			}
			if (nodes.Count > 0)
			{
				node = nodes[0];
			}
			isInitialized = true;
		}
	}

	IMemcachedNode IMemcachedNodeLocator.Locate(string key)
	{
		if (!isInitialized)
		{
			throw new InvalidOperationException("You must call Initialize first");
		}
		if (!node.IsAlive)
		{
			return null;
		}
		return node;
	}

	IEnumerable<IMemcachedNode> IMemcachedNodeLocator.GetWorkingNodes()
	{
		if (!node.IsAlive)
		{
			return Enumerable.Empty<IMemcachedNode>();
		}
		return new IMemcachedNode[1] { node };
	}
}
