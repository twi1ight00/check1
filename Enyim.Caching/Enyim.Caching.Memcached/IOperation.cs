using System;
using System.Collections.Generic;
using Enyim.Caching.Memcached.Results;

namespace Enyim.Caching.Memcached;

public interface IOperation
{
	int StatusCode { get; }

	IList<ArraySegment<byte>> GetBuffer();

	IOperationResult ReadResponse(PooledSocket socket);

	/// <summary>
	/// 'next' is called when the operation completes. The bool parameter indicates the success of the operation.
	/// </summary>
	/// <param name="socket"></param>
	/// <param name="next"></param>
	/// <returns></returns>
	bool ReadResponseAsync(PooledSocket socket, Action<bool> next);
}
