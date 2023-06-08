using System;
using System.Collections.Generic;
using Enyim.Caching.Memcached.Results;

namespace Enyim.Caching.Memcached.Protocol;

/// <summary>
/// Base class for implementing operations.
/// </summary>
public abstract class Operation : IOperation
{
	private static readonly ILog log = LogManager.GetLogger(typeof(Operation));

	int IOperation.StatusCode => StatusCode;

	public int StatusCode { get; protected set; }

	protected internal abstract IList<ArraySegment<byte>> GetBuffer();

	protected internal abstract IOperationResult ReadResponse(PooledSocket socket);

	protected internal abstract bool ReadResponseAsync(PooledSocket socket, Action<bool> next);

	IList<ArraySegment<byte>> IOperation.GetBuffer()
	{
		return GetBuffer();
	}

	IOperationResult IOperation.ReadResponse(PooledSocket socket)
	{
		return ReadResponse(socket);
	}

	bool IOperation.ReadResponseAsync(PooledSocket socket, Action<bool> next)
	{
		return ReadResponseAsync(socket, next);
	}
}
