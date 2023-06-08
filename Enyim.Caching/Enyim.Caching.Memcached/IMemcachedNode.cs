using System;
using System.Net;
using Enyim.Caching.Memcached.Results;

namespace Enyim.Caching.Memcached;

public interface IMemcachedNode : IDisposable
{
	IPEndPoint EndPoint { get; }

	bool IsAlive { get; }

	event Action<IMemcachedNode> Failed;

	bool Ping();

	IOperationResult Execute(IOperation op);

	bool ExecuteAsync(IOperation op, Action<bool> next);
}
