using System;
using System.Collections.Generic;

namespace Enyim.Caching.Memcached;

/// <summary>
/// Provides custom server pool implementations
/// </summary>
public interface IServerPool : IDisposable
{
	IOperationFactory OperationFactory { get; }

	event Action<IMemcachedNode> NodeFailed;

	IMemcachedNode Locate(string key);

	IEnumerable<IMemcachedNode> GetWorkingNodes();

	void Start();
}
